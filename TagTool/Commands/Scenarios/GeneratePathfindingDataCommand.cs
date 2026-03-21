using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.Geometry.BspCollisionGeometry;
using TagTool.Pathfinding;
using TagTool.Pathfinding.Utils;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using TagTool.Tags.Resources;
using TagTool.Tags.Definitions.Common;
using static TagTool.Tags.Definitions.Scenario;

// Aliases to resolve ambiguity between collision geometry, pathfinding, and scenario nested types
using CollisionEdge   = TagTool.Geometry.BspCollisionGeometry.Edge;
using CollisionVertex = TagTool.Geometry.BspCollisionGeometry.Vertex;
using PfVertex        = TagTool.Pathfinding.Vertex;
using PfBsp2dNode     = TagTool.Pathfinding.Bsp2dNode;
using PfObjectRef     = TagTool.Pathfinding.ObjectReference;
using PfLink          = TagTool.Pathfinding.Link;

#nullable enable

namespace TagTool.Commands.Scenarios
{
    /// <summary>
    /// Generates pathfinding data for all structure BSPs in a scenario.
    ///
    /// Usage:
    ///   GeneratePathfindingData [SlopeDegrees] [ThresholdDegrees] [ObjectTypes]
    ///
    ///   SlopeDegrees      - Optional float. Default 45. Surfaces whose angle from horizontal
    ///                       exceeds this are treated as walls (not walkable).
    ///   ThresholdDegrees  - Optional float. Default 15. Minimum angle change between two
    ///                       adjacent sectors to generate a threshold link between them.
    ///   ObjectTypes       - Optional comma-separated filter. Default: all.
    ///                       Valid values: Scenery, Machine, Crate, Giant
    ///                       Example: "Scenery,Machine"
    ///
    /// The command:
    ///   1. Reads all structure BSPs referenced by the scenario.
    ///   2. For each BSP, reads the collision resource (cluster + instanced geo).
    ///   3. Reads all scenario object placements and resolves their collision models.
    ///   4. Builds a PathfindingGeometryContext (world-space first pass).
    ///   5. Runs sector merging on walkable surfaces.
    ///   6. Generates Sectors, Links, Vertices, and ObjectReferences.
    ///   7. Writes the data back to both the tag and the cache resource.
    /// </summary>
    public class GeneratePathfindingDataCommand : Command
    {
        private GameCache Cache { get; }
        private Scenario Scenario { get; }
        private CachedTag ScenarioTag { get; }

        private static readonly HashSet<string> ValidObjectTypeNames =
            new(StringComparer.OrdinalIgnoreCase) { "Scenery", "Machine", "Crate", "Giant" };

        public GeneratePathfindingDataCommand(GameCache cache, CachedTag scenarioTag, Scenario scenario) :
            base(true,
                "GeneratePathfindingData",
                "Generates pathfinding data for all structure BSPs in the scenario.",
                "GeneratePathfindingData [SlopeDegrees] [ThresholdDegrees] [ObjectTypes]",
                "SlopeDegrees: float (default 45). ThresholdDegrees: float (default 15). ObjectTypes: comma-separated Scenery/Machine/Crate/Giant (default all).")
        {
            Cache       = cache;
            ScenarioTag = scenarioTag;
            Scenario    = scenario;
        }

        public override object Execute(List<string> args)
        {
            float slopeDegrees     = 45.0f;
            float thresholdDegrees = 15.0f;
            HashSet<string>? objectTypeFilter = null;
            int floatArgCount = 0;

            foreach (var arg in args)
            {
                if (float.TryParse(arg, out float degrees))
                {
                    if (floatArgCount == 0)
                        slopeDegrees = Math.Clamp(degrees, 0.0f, 90.0f);
                    else if (floatArgCount == 1)
                        thresholdDegrees = Math.Clamp(degrees, 0.0f, 90.0f);
                    floatArgCount++;
                }
                else
                {
                    var parts = arg.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                    var invalid = parts.Where(p => !ValidObjectTypeNames.Contains(p)).ToList();
                    if (invalid.Count > 0)
                        return new TagToolError(CommandError.ArgInvalid,
                            $"Unknown object type(s): {string.Join(", ", invalid)}. Valid: {string.Join(", ", ValidObjectTypeNames)}");

                    objectTypeFilter = new HashSet<string>(parts, StringComparer.OrdinalIgnoreCase);
                }
            }

            // Convert degrees to the internal representations used by the generator:
            // slope: cos(angle) — cos(45°) ≈ 0.707, surfaces below this K value are walls
            // threshold: passed as degrees, converted to dot product inside GenerateSectorsAndLinks
            float slopeThreshold = MathF.Cos(slopeDegrees * MathF.PI / 180.0f);

            using var stream = Cache.OpenCacheReadWrite();
            return ExecuteInternal(stream, slopeThreshold, thresholdDegrees, objectTypeFilter);
        }

        private object ExecuteInternal(Stream stream, float slopeThreshold, float thresholdDegrees, HashSet<string>? objectTypeFilter)
        {
            if (Scenario.StructureBsps == null || Scenario.StructureBsps.Count == 0)
                return new TagToolError(CommandError.OperationFailed, "Scenario has no structure BSPs.");

            // Process each BSP independently — each gets its own pathfinding data block
            for (int bspIndex = 0; bspIndex < Scenario.StructureBsps.Count; bspIndex++)
            {
                var bspEntry = Scenario.StructureBsps[bspIndex];
                if (bspEntry.StructureBsp == null)
                    continue;

                var bsp = Cache.Deserialize<ScenarioStructureBsp>(stream, bspEntry.StructureBsp);

                Console.WriteLine($"[BSP {bspIndex}] Processing '{bspEntry.StructureBsp.Name}'...");

                // Build the geometry context (first pass: read + transform all collision geo)
                var context = BuildGeometryContext(stream, bsp, slopeThreshold, thresholdDegrees, objectTypeFilter);

                // Generate pathfinding data from the context
                GeneratePathfindingForBsp(bsp, context);

                // Write resource first so bsp.PathfindingResource is updated,
                // then serialize the tag so the updated resource reference is saved
                WritePathfindingResource(bsp);
                Cache.Serialize(stream, bspEntry.StructureBsp, bsp);

                Console.WriteLine($"[BSP {bspIndex}] Done. " +
                    $"Sectors: {bsp.PathfindingData[0].Sectors.Count}, " +
                    $"Links: {bsp.PathfindingData[0].Links.Count}, " +
                    $"Vertices: {bsp.PathfindingData[0].Vertices.Count}");
            }

            // Serialize the scenario tag to save any newly added ObjectReferenceFrames
            Cache.Serialize(stream, ScenarioTag, Scenario);

            return true;
        }

        // =========================================================================
        // FIRST PASS — build PathfindingGeometryContext
        // =========================================================================

        private PathfindingGeometryContext BuildGeometryContext(
            Stream stream,
            ScenarioStructureBsp bsp,
            float slopeThreshold,
            float thresholdDegrees,
            HashSet<string>? objectTypeFilter)
        {
            var context = new PathfindingGeometryContext
            {
                SlopeThreshold  = slopeThreshold,
                ThresholdDegrees = thresholdDegrees,
            };

            var collisionResource = Cache.ResourceCache.GetStructureBspTagResources(bsp.CollisionBspResource);

            // -----------------------------------------------------------------
            // 1. Cluster geo (base map collision)
            // -----------------------------------------------------------------
            // Cluster geo is world-space already; no transform needed.
            ReadClusterSurfaces(collisionResource, context);

            // -----------------------------------------------------------------
            // 2. Instanced geometry
            // -----------------------------------------------------------------
            ReadInstancedGeoSurfaces(collisionResource, bsp, context);

            // -----------------------------------------------------------------
            // 3. Scenario object placements
            // -----------------------------------------------------------------
            ReadScenarioObjectPlacements(stream, context, objectTypeFilter);

            return context;
        }

        private void ReadClusterSurfaces(
            StructureBspTagResources collisionResource,
            PathfindingGeometryContext context)
        {
            // Cluster geo may be in CollisionBsps (small) or LargeCollisionBsps.
            // In H3/ODST there is exactly one block of one type.

            if (collisionResource.CollisionBsps?.Count > 0)
            {
                var geo = collisionResource.CollisionBsps[0];
                for (int i = 0; i < geo.Surfaces.Count; i++)
                {
                    var surf = geo.Surfaces[i];
                    if (surf.Plane >= geo.Planes.Count)
                        continue;

                    var plane = geo.Planes[surf.Plane].Value;
                    var verts = GetSurfaceVertices(geo, i);

                    context.ClusterSurfaces.Add(new ProcessedSurface
                    {
                        Vertices = verts,
                        Plane = plane,
                        Source = SurfaceSource.ClusterGeo,
                        OriginalSurfaceIndex = i,
                    });

                    context.CumulativeVertexOffset += 0; // vertices counted after loop
                }

                context.CumulativeVertexOffset += geo.Vertices.Count;
            }
            else if (collisionResource.LargeCollisionBsps?.Count > 0)
            {
                var geo = collisionResource.LargeCollisionBsps[0];
                for (int i = 0; i < geo.Surfaces.Count; i++)
                {
                    var surf = geo.Surfaces[i];
                    if (surf.Plane >= geo.Planes.Count)
                        continue;

                    var plane = geo.Planes[(int)(surf.Plane & 0x7FFFFFFF)].Value;
                    var verts = GetLargeSurfaceVertices(geo, i);

                    context.ClusterSurfaces.Add(new ProcessedSurface
                    {
                        Vertices = verts,
                        Plane = plane,
                        Source = SurfaceSource.ClusterGeo,
                        OriginalSurfaceIndex = i,
                    });
                }

                context.CumulativeVertexOffset += geo.Vertices.Count;
            }
        }

        private void ReadInstancedGeoSurfaces(
            StructureBspTagResources collisionResource,
            ScenarioStructureBsp bsp,
            PathfindingGeometryContext context)
        {
            if (collisionResource.InstancedGeometry == null)
                return;

            for (int instIdx = 0; instIdx < collisionResource.InstancedGeometry.Count; instIdx++)
            {
                var def = collisionResource.InstancedGeometry[instIdx];

                // Always count vertices for every instanced geo block regardless of policy,
                // since the vertex offset is a positional index into the full resource vertex array.
                context.CumulativeVertexOffset += def.CollisionInfo.Vertices.Count;

                // Now check if this instance should contribute surfaces for pathfinding
                if (bsp.InstancedGeometryInstances == null || instIdx >= bsp.InstancedGeometryInstances.Count)
                    continue;

                var instance = bsp.InstancedGeometryInstances[instIdx];

                if (instance.Flags.HasFlag(InstancedGeometryInstance.InstancedGeometryFlags.RenderOnly))
                    continue;

                var policy = instance.PathfindingPolicy;
                if (policy == Scenery.PathfindingPolicyValue.None)
                    continue;

                var transform = instance.Matrix;
                var geo = def.CollisionInfo;
                var entry = new ProcessedInstancedGeo
                {
                    DefinitionIndex = instIdx,
                    WorldTransform = transform,
                    PathfindingPolicy = policy,
                };

                for (int surfIdx = 0; surfIdx < geo.Surfaces.Count; surfIdx++)
                {
                    var surf = geo.Surfaces[surfIdx];
                    if (surf.Plane >= geo.Planes.Count)
                        continue;

                    var localPlane = geo.Planes[surf.Plane].Value;
                    var worldPlane = PathfindingMath.TransformPlane(localPlane, transform);

                    var localVerts = GetSurfaceVertices(geo, surfIdx);
                    var worldVerts = localVerts
                        .Select(v => PathfindingMath.TransformPoint(v, transform))
                        .ToList();

                    entry.Surfaces.Add(new ProcessedSurface
                    {
                        Vertices = worldVerts,
                        Plane = worldPlane,
                        Source = SurfaceSource.InstancedGeo,
                        OriginalSurfaceIndex = surfIdx,
                        OwnerIndex = instIdx,
                    });
                }

                context.InstancedGeoEntries.Add(entry);
            }
        }

        private void ReadScenarioObjectPlacements(
            Stream stream,
            PathfindingGeometryContext context,
            HashSet<string>? objectTypeFilter)
        {
            bool ShouldProcess(string typeName) =>
                objectTypeFilter == null || objectTypeFilter.Contains(typeName);

            if (ShouldProcess("Scenery") && Scenario.Scenery != null)
            {
                foreach (var placement in Scenario.Scenery)
                {
                    if (placement.PaletteIndex < 0) continue;
                    var objectTag = GetPaletteTag(Scenario.SceneryPalette, placement.PaletteIndex);
                    if (objectTag == null) continue;
                    var objectDef = Cache.Deserialize<Scenery>(stream, objectTag);

                    // TagDefault on placement → use tag's own policy (no TagDefault in tag enum,
                    // index 0 = CutOut, which is the correct default for scenery)
                    var placementPolicy = placement.PathfindingPolicy;
                    var resolvedPolicy = placementPolicy == PathfindingPolicyValue.TagDefault
                        ? ResolveSceneryTagPolicy(objectDef.PathfindingPolicy)
                        : ResolveScenarioPolicy(placementPolicy);

                    var modelTag = objectDef.Model;
                    ProcessObjectPlacement(stream, context, placement, resolvedPolicy,
                        GameObjectTypeHalo3ODST.Scenery, modelTag);
                }
            }

            if (ShouldProcess("Crate") && Scenario.Crates != null)
            {
                foreach (var placement in Scenario.Crates)
                {
                    if (placement.PaletteIndex < 0) continue;
                    var objectTag = GetPaletteTag(Scenario.CratePalette, placement.PaletteIndex);
                    if (objectTag == null) continue;
                    var objectDef = Cache.Deserialize<Crate>(stream, objectTag);

                    // Crate tag has no policy field — TagDefault means None (skip sector gen,
                    // but still gets an object ref written)
                    var placementPolicy = placement.PathfindingPolicy;
                    var resolvedPolicy = placementPolicy == PathfindingPolicyValue.TagDefault
                        ? ObjectPathfindingPolicy.None
                        : ResolveScenarioPolicy(placementPolicy);

                    var modelTag = objectDef.Model;
                    ProcessObjectPlacement(stream, context, placement, resolvedPolicy,
                        GameObjectTypeHalo3ODST.Crate, modelTag);
                }
            }

            if (ShouldProcess("Machine") && Scenario.Machines != null)
            {
                foreach (var placement in Scenario.Machines)
                {
                    if (placement.PaletteIndex < 0) continue;
                    var objectTag = GetPaletteTag(Scenario.MachinePalette, placement.PaletteIndex);
                    if (objectTag == null) continue;
                    var objectDef = Cache.Deserialize<DeviceMachine>(stream, objectTag);

                    // Machine placement uses MachineInstance.PathfindingPolicyValue (its own enum).
                    // TagDefault → fall back to the DeviceMachine tag's policy.
                    // Machine tag enum: 0=Discs, 1=Sectors, 2=CutOut, 3=None (no TagDefault).
                    // Discs → None (no data, machine uses physics collision at runtime).
                    // Sectors → Dynamic (mobile sectors that move with the machine).
                    // CutOut → CutOut (modifies base map only).
                    var placementPolicy = placement.PathfindingPolicy;
                    var resolvedPolicy = placementPolicy == MachineInstance.PathfindingPolicyValue.TagDefault
                        ? ResolveMachineTagPolicy(objectDef.PathfindingPolicy)
                        : ResolveMachinePlacementPolicy(placementPolicy);

                    var modelTag = objectDef.Model;
                    ProcessObjectPlacement(stream, context, placement, resolvedPolicy,
                        GameObjectTypeHalo3ODST.Machine, modelTag);
                }
            }

            if (ShouldProcess("Giant") && Scenario.Giants != null)
            {
                foreach (var placement in Scenario.Giants)
                {
                    if (placement.PaletteIndex < 0) continue;
                    var objectTag = GetPaletteTag(Scenario.GiantPalette, placement.PaletteIndex);
                    if (objectTag == null) continue;
                    var objectDef = Cache.Deserialize<Giant>(stream, objectTag);

                    // Giants are always Dynamic — they have localized pathfinding data that
                    // moves with the object (e.g. the Scarab).
                    var modelTag = objectDef.Model;
                    ProcessObjectPlacement(stream, context, placement, ObjectPathfindingPolicy.Dynamic,
                        GameObjectTypeHalo3ODST.Giant, modelTag);
                }
            }
        }

        // -------------------------------------------------------------------------
        // Policy resolvers
        // -------------------------------------------------------------------------

        /// <summary>
        /// Converts a scenario-level PathfindingPolicyValue to our internal enum.
        /// TagDefault must be resolved before calling this.
        /// </summary>
        private static ObjectPathfindingPolicy ResolveScenarioPolicy(PathfindingPolicyValue policy) =>
            policy switch
            {
                PathfindingPolicyValue.CutOut   => ObjectPathfindingPolicy.CutOut,
                PathfindingPolicyValue.Standard => ObjectPathfindingPolicy.Static,
                PathfindingPolicyValue.Dynamic  => ObjectPathfindingPolicy.Dynamic,
                _ => ObjectPathfindingPolicy.None,
            };

        /// <summary>
        /// Resolves a Scenery tag's own PathfindingPolicyValue to our internal enum.
        /// The Scenery tag enum has no TagDefault (index 0 = CutOut), so its integer values
        /// are offset by -1 relative to the scenario enum. We cast via int to map correctly:
        ///   tag 0 (CutOut)  → scenario 1 (CutOut)  → CutOut
        ///   tag 1 (Static)  → scenario 2 (Standard) → Static
        ///   tag 2 (Dynamic) → scenario 3 (Dynamic)  → Dynamic
        ///   tag 3 (None)    → scenario 4 (None)     → None
        /// </summary>
        /// <summary>
        /// Resolves a Scenery tag's own PathfindingPolicyValue by name.
        /// The tag enum has no TagDefault; names match directly to our internal policy.
        /// </summary>
        private static ObjectPathfindingPolicy ResolveSceneryTagPolicy(Scenery.PathfindingPolicyValue tagPolicy) =>
            tagPolicy switch
            {
                Scenery.PathfindingPolicyValue.CutOut  => ObjectPathfindingPolicy.CutOut,
                Scenery.PathfindingPolicyValue.Static  => ObjectPathfindingPolicy.Static,
                Scenery.PathfindingPolicyValue.Dynamic => ObjectPathfindingPolicy.Dynamic,
                _                                      => ObjectPathfindingPolicy.None,
            };

        /// <summary>
        /// Resolves a DeviceMachine tag's own PathfindingPolicyValue.
        /// Machine tag enum: 0=Discs, 1=Sectors, 2=CutOut, 3=None (no TagDefault).
        /// Discs → None (no data; machine uses physics at runtime).
        /// Sectors → Dynamic (mobile sectors that move with the machine).
        /// </summary>
        private static ObjectPathfindingPolicy ResolveMachineTagPolicy(DeviceMachine.PathfindingPolicyValue tagPolicy) =>
            tagPolicy switch
            {
                DeviceMachine.PathfindingPolicyValue.Sectors => ObjectPathfindingPolicy.Dynamic,
                DeviceMachine.PathfindingPolicyValue.CutOut  => ObjectPathfindingPolicy.CutOut,
                // Discs and None both produce no pathfinding data
                _ => ObjectPathfindingPolicy.None,
            };

        /// <summary>
        /// Resolves a MachineInstance placement PathfindingPolicyValue.
        /// TagDefault must be handled before calling this.
        /// </summary>
        private static ObjectPathfindingPolicy ResolveMachinePlacementPolicy(MachineInstance.PathfindingPolicyValue placementPolicy) =>
            placementPolicy switch
            {
                MachineInstance.PathfindingPolicyValue.Sectors => ObjectPathfindingPolicy.Dynamic,
                MachineInstance.PathfindingPolicyValue.CutOut  => ObjectPathfindingPolicy.CutOut,
                // Discs and None both produce no pathfinding data
                _ => ObjectPathfindingPolicy.None,
            };

        // -------------------------------------------------------------------------
        // Shared object placement processor
        // -------------------------------------------------------------------------

        private void ProcessObjectPlacement(
            Stream stream,
            PathfindingGeometryContext context,
            ScenarioInstance placement,
            ObjectPathfindingPolicy policy,
            GameObjectTypeHalo3ODST objectType,
            CachedTag? modelTag)
        {
            // None: skip entirely — runtime bounding radius handles physics objects (barrels, crates etc.)
            if (policy == ObjectPathfindingPolicy.None)
                return;

            // Resolve collision geometry. If there's no model or no collision model,
            // CutOut has nothing to cut out and Static/Dynamic have nothing to generate sectors from,
            // so skip in all cases.
            if (modelTag == null)
                return;

            var model = Cache.Deserialize<Model>(stream, modelTag);
            if (model?.CollisionModel == null)
                return;

            var collisionModel = Cache.Deserialize<CollisionModel>(stream, model.CollisionModel);

            // Dynamic generates at world origin — sectors move with the object at runtime.
            // Static and CutOut need the full world-space transform.
            bool isDynamic = policy == ObjectPathfindingPolicy.Dynamic;
            var worldTransform = isDynamic
                ? RealMatrix4x3.Identity
                : BuildObjectTransform(placement);

            var processed = new ProcessedObjectPlacement
            {
                ObjectType        = objectType,
                PathfindingPolicy = policy,
                WorldTransform    = worldTransform,
                PlacementObjectId = placement.ObjectId,
            };

            for (int regIdx = 0; regIdx < collisionModel.Regions.Count; regIdx++)
            {
                var region = collisionModel.Regions[regIdx];
                var basePerm = region.Permutations[0]; // base permutation only

                var bspList = new List<ProcessedBspBlock>();
                var nodeList = new List<short>();
                var vertCountList = new List<int>();

                for (int bspIdx = 0; bspIdx < basePerm.Bsps.Count; bspIdx++)
                {
                    var bspBlock = basePerm.Bsps[bspIdx];
                    var geo = bspBlock.Geometry;
                    var block = new ProcessedBspBlock();

                    vertCountList.Add(geo.Vertices.Count);
                    nodeList.Add((short)bspBlock.NodeIndex);

                    // World-space vertices
                    block.OriginalVertices = geo.Vertices
                        .Select(v => PathfindingMath.TransformPoint(v.Point, worldTransform))
                        .ToList();

                    // Copy edges for adjacency re-derivation after culling/merging
                    block.OriginalEdges = geo.Edges
                        .Select(e => new CollisionEdge
                        {
                            StartVertex  = e.StartVertex,
                            EndVertex    = e.EndVertex,
                            ForwardEdge  = e.ForwardEdge,
                            ReverseEdge  = e.ReverseEdge,
                            LeftSurface  = e.LeftSurface,
                            RightSurface = e.RightSurface,
                        })
                        .ToList();

                    for (int surfIdx = 0; surfIdx < geo.Surfaces.Count; surfIdx++)
                    {
                        var surf = geo.Surfaces[surfIdx];
                        if (surf.Plane >= geo.Planes.Count)
                            continue;

                        var localPlane  = geo.Planes[surf.Plane].Value;
                        var worldPlane  = PathfindingMath.TransformPlane(localPlane, worldTransform);
                        var worldVerts  = GetSurfaceVertices(geo, surfIdx)
                            .Select(v => PathfindingMath.TransformPoint(v, worldTransform))
                            .ToList();

                        block.Surfaces.Add(new ProcessedSurface
                        {
                            Vertices             = worldVerts,
                            Plane                = worldPlane,
                            Source               = SurfaceSource.ScenarioObject,
                            OriginalSurfaceIndex = surfIdx,
                            OwnerIndex           = context.ObjectPlacements.Count,
                        });
                    }

                    bspList.Add(block);
                }

                processed.RegionBsps.Add(bspList);
                processed.RegionBspNodeIndices.Add(nodeList);
                processed.RegionBspVertexCounts.Add(vertCountList);
            }

            // CutOut: store for BSP pass (base map cutout), no ObjectReference written
            // Static/Dynamic: store for sector generation pass, ObjectReference will be written
            if (policy == ObjectPathfindingPolicy.CutOut)
                context.CutOutPlacements.Add(processed);
            else
                context.ObjectPlacements.Add(processed);
        }

        // =========================================================================
        // SECOND PASS — generate pathfinding data from context
        // =========================================================================

        private void GeneratePathfindingForBsp(ScenarioStructureBsp bsp, PathfindingGeometryContext context)
        {
            ResetPathfindingBlock(bsp);
            var pathData = bsp.PathfindingData[0];

            // TODO: GenerateBspPathfinding — cluster + instanced geo sectors.
            // This requires the full cutout/stitch logic described in the design notes
            // (cluster surfaces cut out where instances obstruct, stitched where instances
            // are walkable and adjacent). Stubbed here; object pathfinding below is functional.

            // Generate sectors for scenario objects
            GenerateObjectPathfinding(pathData, context);
        }

        private void GenerateObjectPathfinding(TagPathfinding pathData, PathfindingGeometryContext context)
        {
            // Always start from the cumulative vertex count of cluster + instanced geo,
            // since the block is reset fresh each run (StructureChecksum is always 0 here).
            int curVertOffset = context.CumulativeVertexOffset;

            foreach (var objPlacement in context.ObjectPlacements)
            {
                var objRef = new PfObjectRef
                {
                    Flags    = objPlacement.PathfindingPolicy == ObjectPathfindingPolicy.Dynamic
                        ? PfObjectRef.ObjectReferenceFlags.Mobile
                        : PfObjectRef.ObjectReferenceFlags.None,
                    ObjectId = objPlacement.PlacementObjectId,
                    Bsps     = new TagBlock<PfObjectRef.BspReference>(),
                };

                // Ensure a matching ObjectReferenceFrame exists in the scenario.
                // All three blocks (placement, reference frame, pathfinding object ref)
                // must share the same ObjectIdentifier.
                EnsureObjectReferenceFrame(objPlacement.PlacementObjectId);

                int regIdx = 0;
                foreach (var regionBsps in objPlacement.RegionBsps)
                {
                    int bspIdx = 0;
                    foreach (var bspBlock in regionBsps)
                    {
                        int nodeIndex = objPlacement.RegionBspNodeIndices[regIdx][bspIdx];

                        // BspIndex encoding: [region (8 bits)] [bsp (8 bits)] [node (16 bits)]
                        // Packed as a signed int — region in high byte, then bsp, then node.
                        int bspIndexEncoded = (regIdx << 16) | (bspIdx << 8) | (nodeIndex & 0xFF);

                        var bspRef = new PfObjectRef.BspReference
                        {
                            BspIndex = bspIndexEncoded,
                            NodeIndex = (short)nodeIndex,
                            VertexOffset = curVertOffset,
                            Bsp2dRefs = new TagBlock<PfObjectRef.BspReference.Bsp2dRef>(),
                        };

                        curVertOffset += objPlacement.RegionBspVertexCounts[regIdx][bspIdx];

                        // Run sector merging on walkable surfaces in this bsp block
                        var walkableSurfaces = bspBlock.Surfaces
                            .Where(s => s.IsWalkable(context.SlopeThreshold))
                            .ToList();

                        var mergedSurfaces = SectorMerger.MergeCoplanarSurfaces(
                            walkableSurfaces,
                            context.CoplanarMergeEpsilon);

                        // Build index mappings: original surface index -> sector index (or -1)
                        // We need a map from each original surface to whether it contributes a sector.
                        // After merging, the merged surface carries the OriginalSurfaceIndex of its seed.
                        // For Bsp2dRefs we need one entry per original surface.
                        var surfToSector = BuildSurfaceToSectorMap(
                            bspBlock.Surfaces, mergedSurfaces, context.SlopeThreshold);

                        // Generate Bsp2dRefs (one per original surface, -1 if culled)
                        foreach (var origSurf in bspBlock.Surfaces)
                        {
                            int sectorIdx = surfToSector.TryGetValue(origSurf.OriginalSurfaceIndex, out int si)
                                ? si : -1;

                            bspRef.Bsp2dRefs.Add(new PfObjectRef.BspReference.Bsp2dRef
                            {
                                NodeOrSectorIndex = sectorIdx == -1
                                    ? (int)ushort.MaxValue
                                    : (pathData.Sectors.Count + sectorIdx),
                            });
                        }

                        // Generate Sectors, Links, Vertices, and intersection hints
                        GenerateSectorsAndLinks(pathData, mergedSurfaces, bspBlock, objPlacement,
                            context.ThresholdDegrees);

                        objRef.Bsps.Add(bspRef);
                        bspIdx++;
                    }
                    regIdx++;
                }

                pathData.ObjectReferences.Add(objRef);
            }

            // Store cumulative vertex offset for future appends
            pathData.StructureChecksum = curVertOffset;
        }

        private void GenerateSectorsAndLinks(
            TagPathfinding pathData,
            List<ProcessedSurface> mergedSurfaces,
            ProcessedBspBlock bspBlock,
            ProcessedObjectPlacement objPlacement,
            float thresholdAngleDegrees = 15.0f)
        {
            bool isMobile    = objPlacement.PathfindingPolicy == ObjectPathfindingPolicy.Dynamic;
            bool isStatic    = objPlacement.PathfindingPolicy == ObjectPathfindingPolicy.Static;
            bool isBspSource = false; // object refs are never BSP source

            // Threshold: dot product cutoff for two sector planes to be considered
            // directionally different. Below this dot = angle exceeds threshold = set threshold flag.
            // NOTE: Bungie's actual generator allows concave sectors with a plain link at each
            // concave boundary vertex on the same plane. We keep strictly convex sectors since
            // it produces cleaner data, at the cost of more (smaller) sectors in concave areas.
            float thresholdDot = MathF.Cos(thresholdAngleDegrees * MathF.PI / 180.0f);

            // Build a vertex pool for this bsp block to avoid duplicates
            var vertPool = new List<RealPoint3d>();

            var edgeToLeftSector  = new Dictionary<int, int>();
            var edgeToRightSector = new Dictionary<int, int>();

            int sectorBase = pathData.Sectors.Count;

            // Walk original edges to determine which merged sectors they adjoin
            for (int edgeIdx = 0; edgeIdx < bspBlock.OriginalEdges.Count; edgeIdx++)
            {
                var edge = bspBlock.OriginalEdges[edgeIdx];
                edgeToLeftSector[edgeIdx]  = FindMergedSectorForOrigSurface(edge.LeftSurface,  bspBlock, mergedSurfaces, sectorBase);
                edgeToRightSector[edgeIdx] = FindMergedSectorForOrigSurface(edge.RightSurface, bspBlock, mergedSurfaces, sectorBase);
            }

            // Generate sectors
            for (int si = 0; si < mergedSurfaces.Count; si++)
            {
                var sectorFlags = Sector.FlagsValue.SectorWalkable | Sector.FlagsValue.Floor;
                if (isMobile)    sectorFlags |= Sector.FlagsValue.SectorMobile;
                if (isBspSource) sectorFlags |= Sector.FlagsValue.SectorBspSource;

                pathData.Sectors.Add(new Sector
                {
                    PathfindingSectorFlags = sectorFlags,
                    HintIndex  = -1,
                    FirstLink  = -1, // fixed up after links are generated
                });
            }

            // Generate links from original edges.
            // Skip if both sides are culled, or if both sides map to the same merged sector
            // (interior edge absorbed by merging).
            var linkBase   = pathData.Links.Count;
            var edgeToLink = new Dictionary<int, int>();

            for (int edgeIdx = 0; edgeIdx < bspBlock.OriginalEdges.Count; edgeIdx++)
            {
                int leftSect  = edgeToLeftSector[edgeIdx];
                int rightSect = edgeToRightSector[edgeIdx];

                if (leftSect < 0 && rightSect < 0)          { edgeToLink[edgeIdx] = -1; continue; }
                if (leftSect >= 0 && leftSect == rightSect) { edgeToLink[edgeIdx] = -1; continue; }

                edgeToLink[edgeIdx] = pathData.Links.Count;
                var edge = bspBlock.OriginalEdges[edgeIdx];

                ushort v1 = AddVertex(pathData, vertPool, bspBlock.OriginalVertices[edge.StartVertex]);
                ushort v2 = AddVertex(pathData, vertPool, bspBlock.OriginalVertices[edge.EndVertex]);

                bool leftValid  = leftSect  >= 0;
                bool rightValid = rightSect >= 0;

                // Object ref links are not derived from collision edges directly
                var linkFlags = PfLink.FlagsValue.None;

                if (leftValid && rightValid)
                {
                    // Two sectors meet here. Set threshold only if their plane normals
                    // differ by more than the threshold angle — i.e. a real directional
                    // change like a ramp meeting a floor or a hallway bend, not two nearly
                    // coplanar sectors touching.
                    var leftPlane  = mergedSurfaces[leftSect  - sectorBase].Plane;
                    var rightPlane = mergedSurfaces[rightSect - sectorBase].Plane;
                    float dot = leftPlane.I * rightPlane.I +
                                leftPlane.J * rightPlane.J +
                                leftPlane.K * rightPlane.K;

                    if (dot < thresholdDot)
                        linkFlags |= PfLink.FlagsValue.SectorLinkThreshold;

                    linkFlags |= PfLink.FlagsValue.SectorLinkBothSectorsWalkable;
                }
                else
                {
                    // One side open — determine wall base vs ledge by checking whether the
                    // neighbouring surface has any vertices above the shared edge's Z level.
                    // If any neighbour vertex is above the edge → wall base (surface rises above).
                    // If all neighbour vertices are at or below the edge → ledge (drop off).
                    int openSideOrigSurf = leftValid ? edge.RightSurface : edge.LeftSurface;
                    float edgeZ = MathF.Max(
                        bspBlock.OriginalVertices[edge.StartVertex].Z,
                        bspBlock.OriginalVertices[edge.EndVertex].Z);
                    bool isWall = IsNeighbourSurfaceAbove(openSideOrigSurf, bspBlock, edgeZ);

                    if (isWall)
                    {
                        linkFlags |= PfLink.FlagsValue.SectorLinkWallBase;
                        linkFlags |= PfLink.FlagsValue.SectorLinkStartCorner;
                        linkFlags |= PfLink.FlagsValue.SectorLinkEndCorner;
                        linkFlags |= PfLink.FlagsValue.SectorLinkLeanable;
                    }
                    else
                    {
                        linkFlags |= PfLink.FlagsValue.SectorLinkLedge;
                    }
                }

                pathData.Links.Add(new PfLink
                {
                    Vertex1     = v1,
                    Vertex2     = v2,
                    LinkFlags   = linkFlags,
                    HintIndex   = -1,
                    ForwardLink = 0,
                    ReverseLink = 0,
                    LeftSector  = leftSect  >= 0 ? (ushort)leftSect  : ushort.MaxValue,
                    RightSector = rightSect >= 0 ? (ushort)rightSect : ushort.MaxValue,
                });
            }

            FixUpLinkChains(pathData, bspBlock, edgeToLink, edgeToLeftSector, edgeToRightSector, linkBase);

            // Fix up FirstLink on sectors
            for (int si = 0; si < mergedSurfaces.Count; si++)
            {
                int sectorIdx = sectorBase + si;
                for (int edgeIdx = 0; edgeIdx < bspBlock.OriginalEdges.Count; edgeIdx++)
                {
                    if (!edgeToLink.TryGetValue(edgeIdx, out int li) || li < 0) continue;
                    int lm = edgeToLeftSector[edgeIdx];
                    int rm = edgeToRightSector[edgeIdx];
                    if (lm == sectorIdx || rm == sectorIdx)
                    {
                        pathData.Sectors[sectorIdx].FirstLink = li;
                        break;
                    }
                }
            }

            // Intersection hint generation (SectorIntersectionLink flags and overlay links)
            // is handled during the BSP intersection pass when actual geometry overlaps are
            // computed. It is not applicable here for standalone object sector generation.
        }

        /// <summary>
        /// For static objects, marks all intersection boundary links with SectorIntersectionLink,
        /// then generates standalone overlay links (claimed by no sector) at walkable entry points
        /// with IntersectionLink hints chained in perimeter order.
        ///
        /// Three categories at the object/map boundary:
        ///   - Non-walkable slope: SectorIntersectionLink + SectorLinkWallBase (yellow in Sapien)
        ///   - Walkable: SectorIntersectionLink only on the collision-derived link (base topology)
        ///     plus a new standalone overlay link (red hint links in Sapien), which also gets
        ///     SectorLinkThreshold if adjacent sector planes differ beyond the angle threshold.
        /// </summary>
        private static void GenerateIntersectionHints(
            TagPathfinding pathData,
            ProcessedBspBlock bspBlock,
            Dictionary<int, int> edgeToLink,
            Dictionary<int, int> edgeToLeftSector,
            Dictionary<int, int> edgeToRightSector,
            List<ProcessedSurface> mergedSurfaces,
            int sectorBase,
            List<RealPoint3d> vertPool,
            float thresholdDot)
        {
            // First pass: mark SectorIntersectionLink on all boundary links
            // (both walkable and non-walkable slope boundaries)
            for (int edgeIdx = 0; edgeIdx < bspBlock.OriginalEdges.Count; edgeIdx++)
            {
                if (!edgeToLink.TryGetValue(edgeIdx, out int linkIdx) || linkIdx < 0)
                    continue;

                var link = pathData.Links[linkIdx];
                link.LinkFlags |= PfLink.FlagsValue.SectorIntersectionLink;
                pathData.Links[linkIdx] = link;
            }

            // Second pass: collect walkable boundary links in edge (perimeter) order.
            // These get standalone overlay links + IntersectionLink hints.
            var walkableBoundaryEdges = new List<int>();

            for (int edgeIdx = 0; edgeIdx < bspBlock.OriginalEdges.Count; edgeIdx++)
            {
                if (!edgeToLink.TryGetValue(edgeIdx, out int linkIdx) || linkIdx < 0)
                    continue;

                int left  = edgeToLeftSector.TryGetValue(edgeIdx,  out int l) ? l : -1;
                int right = edgeToRightSector.TryGetValue(edgeIdx, out int r) ? r : -1;

                // Walkable boundary: both sides are valid sectors
                if (left >= 0 && right >= 0)
                    walkableBoundaryEdges.Add(edgeIdx);
            }

            if (walkableBoundaryEdges.Count == 0)
                return;

            // Generate standalone overlay links and hint pairs
            var overlayLinkIndices = new List<int>();

            foreach (int edgeIdx in walkableBoundaryEdges)
            {
                var edge = bspBlock.OriginalEdges[edgeIdx];

                ushort v1 = AddVertex(pathData, vertPool, bspBlock.OriginalVertices[edge.StartVertex]);
                ushort v2 = AddVertex(pathData, vertPool, bspBlock.OriginalVertices[edge.EndVertex]);

                int left  = edgeToLeftSector[edgeIdx];
                int right = edgeToRightSector[edgeIdx];

                // Overlay link flags: no SectorLinkFromCollisionEdge (synthetic),
                // no SectorIntersectionLink (that's on the base link, not the overlay).
                // Apply SectorLinkThreshold if the two adjacent sector planes differ.
                var overlayFlags = PfLink.FlagsValue.SectorLinkBothSectorsWalkable;

                var leftPlane  = mergedSurfaces[left  - sectorBase].Plane;
                var rightPlane = mergedSurfaces[right - sectorBase].Plane;
                float dot = leftPlane.I * rightPlane.I +
                            leftPlane.J * rightPlane.J +
                            leftPlane.K * rightPlane.K;
                if (dot < thresholdDot)
                    overlayFlags |= PfLink.FlagsValue.SectorLinkThreshold;

                int overlayLinkIdx = pathData.Links.Count;
                overlayLinkIndices.Add(overlayLinkIdx);

                // HintIndex will be filled in below once we know hint indices
                pathData.Links.Add(new PfLink
                {
                    Vertex1     = v1,
                    Vertex2     = v2,
                    LinkFlags   = overlayFlags,
                    HintIndex   = -1,
                    ForwardLink = ushort.MaxValue, // standalone — no sector chain
                    ReverseLink = ushort.MaxValue,
                    LeftSector  = (ushort)left,
                    RightSector = (ushort)right,
                });
            }

            // Generate two IntersectionLink hints per overlay link, chained in perimeter order.
            // Layout: [prevHint_0, nextHint_0, prevHint_1, nextHint_1, ...]
            // prevHint.NextHintIndex → its own nextHint
            // nextHint.NextHintIndex → next link's prevHint, or -1 if last
            int hintBase = pathData.PathfindingHints.Count;
            int count    = overlayLinkIndices.Count;

            for (int i = 0; i < count; i++)
            {
                int overlayLinkIdx = overlayLinkIndices[i];
                int prevHintIdx    = hintBase + i * 2;
                int nextHintIdx    = prevHintIdx + 1;
                int nextPrevHint   = i < count - 1 ? hintBase + (i + 1) * 2 : -1;

                pathData.PathfindingHints.Add(new PathfindingHint
                {
                    HintType      = PathfindingHint.HintTypeValue.IntersectionLink,
                    NextHintIndex = (short)nextHintIdx,          // prev → next (same link)
                    Data          = new[] { overlayLinkIdx, 0, 0, 0 },
                });

                pathData.PathfindingHints.Add(new PathfindingHint
                {
                    HintType      = PathfindingHint.HintTypeValue.IntersectionLink,
                    NextHintIndex = (short)nextPrevHint,         // next → next link's prev, or -1
                    Data          = new[] { overlayLinkIdx, 0, 0, 0 },
                });

                // Point overlay link's HintIndex at its prevHint
                var overlayLink = pathData.Links[overlayLinkIdx];
                overlayLink.HintIndex = (short)prevHintIdx;
                pathData.Links[overlayLinkIdx] = overlayLink;
            }
        }

        // =========================================================================
        // Helpers
        // =========================================================================

        private static int FindMergedSectorForOrigSurface(
            int origSurfIdx,
            ProcessedBspBlock block,
            List<ProcessedSurface> mergedSurfaces,
            int sectorBase)
        {
            if (origSurfIdx < 0 || origSurfIdx >= block.Surfaces.Count)
                return -1;

            var origSurf = block.Surfaces[origSurfIdx];

            // Find the merged surface that this original surface belongs to.
            // A surface belongs to a merged sector if it is coplanar and adjacent
            // to the merged sector's representative polygon.
            for (int mi = 0; mi < mergedSurfaces.Count; mi++)
            {
                var merged = mergedSurfaces[mi];

                // Quick check: are the planes compatible?
                if (!PathfindingMath.AreSurfacesCoplanar(merged, origSurf))
                    continue;

                // Check if any vertex of origSurf is within the merged surface's convex hull
                // (approximated here as vertex containment)
                foreach (var v in origSurf.Vertices)
                {
                    foreach (var mv in merged.Vertices)
                    {
                        if (PathfindingMath.PointsEqual(v, mv))
                            return sectorBase + mi;
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// Returns true if the neighbouring surface (on the open side of a boundary link)
        /// has any vertex above the shared edge's Z level, indicating a wall the AI would
        /// lean against. Returns false if all vertices are at or below the edge Z (ledge/drop off).
        /// If the surface index is out of range (open air), returns false (ledge).
        /// </summary>
        private static bool IsNeighbourSurfaceAbove(int origSurfIdx, ProcessedBspBlock block, float edgeZ,
            float epsilon = 0.01f)
        {
            if (origSurfIdx < 0 || origSurfIdx >= block.Surfaces.Count)
                return false; // open air = ledge

            foreach (var v in block.Surfaces[origSurfIdx].Vertices)
            {
                if (v.Z > edgeZ + epsilon)
                    return true;
            }
            return false;
        }

        private static ushort AddVertex(TagPathfinding pathData, List<RealPoint3d> pool, RealPoint3d pt)
        {
            for (int i = 0; i < pool.Count; i++)
            {
                if (PathfindingMath.PointsEqual(pool[i], pt))
                    return (ushort)i;
            }

            int idx = pool.Count;
            pool.Add(pt);
            pathData.Vertices.Add(new PfVertex { Point = pt });
            return (ushort)idx;
        }

        private static void FixUpLinkChains(
            TagPathfinding pathData,
            ProcessedBspBlock block,
            Dictionary<int, int> edgeToLink,
            Dictionary<int, int> edgeToLeftSector,
            Dictionary<int, int> edgeToRightSector,
            int linkBase)
        {
            for (int edgeIdx = 0; edgeIdx < block.OriginalEdges.Count; edgeIdx++)
            {
                if (!edgeToLink.TryGetValue(edgeIdx, out int linkIdx) || linkIdx < 0)
                    continue;

                var edge = block.OriginalEdges[edgeIdx];

                // Determine which original surface index this link primarily belongs to.
                // Left surface takes priority; if left is culled use right.
                int leftSect  = edgeToLeftSector.TryGetValue(edgeIdx, out int ls)  ? ls  : -1;
                int rightSect = edgeToRightSector.TryGetValue(edgeIdx, out int rs) ? rs  : -1;
                int primaryOrigSurf = leftSect >= 0 ? edge.LeftSurface : edge.RightSurface;

                int forwardLinkIdx = ResolveNextLink(edge.ForwardEdge, block, edgeToLink, primaryOrigSurf, forward: true);
                int reverseLinkIdx = ResolveNextLink(edge.ReverseEdge, block, edgeToLink, primaryOrigSurf, forward: false);

                var link = pathData.Links[linkIdx];
                link.ForwardLink = forwardLinkIdx >= 0 ? (ushort)forwardLinkIdx : (ushort)linkIdx;
                link.ReverseLink = reverseLinkIdx >= 0 ? (ushort)reverseLinkIdx : (ushort)linkIdx;
                pathData.Links[linkIdx] = link;
            }
        }

        /// <summary>
        /// Walks the collision edge perimeter from startEdgeIdx, following the correct
        /// forward or reverse pointer based on which side of each edge the primary surface is on,
        /// until a valid link is found or the chain loops back.
        /// </summary>
        private static int ResolveNextLink(
            int startEdgeIdx,
            ProcessedBspBlock block,
            Dictionary<int, int> edgeToLink,
            int primaryOrigSurf,
            bool forward)
        {
            int current = startEdgeIdx;
            int visited = 0;

            while (current >= 0 && current < block.OriginalEdges.Count && visited < block.OriginalEdges.Count)
            {
                if (edgeToLink.TryGetValue(current, out int li) && li >= 0)
                    return li;

                var e = block.OriginalEdges[current];

                // Follow the perimeter in the correct direction for this surface:
                // if this surface is the left surface of the current edge, follow ForwardEdge,
                // otherwise follow ReverseEdge to stay on the same surface's perimeter.
                current = e.LeftSurface == primaryOrigSurf ? e.ForwardEdge : e.ReverseEdge;
                visited++;
            }

            return -1;
        }

        /// <summary>
        /// Builds a map from original surface index to merged sector local index (0-based).
        /// Surfaces that were culled (not walkable) return -1.
        /// </summary>
        private static Dictionary<int, int> BuildSurfaceToSectorMap(
            List<ProcessedSurface> originalSurfaces,
            List<ProcessedSurface> mergedSurfaces,
            float slopeThreshold)
        {
            var result = new Dictionary<int, int>();

            for (int origIdx = 0; origIdx < originalSurfaces.Count; origIdx++)
            {
                var orig = originalSurfaces[origIdx];
                if (!orig.IsWalkable(slopeThreshold))
                {
                    result[orig.OriginalSurfaceIndex] = -1;
                    continue;
                }

                // Find which merged sector this original surface was absorbed into
                bool found = false;
                for (int mi = 0; mi < mergedSurfaces.Count; mi++)
                {
                    var merged = mergedSurfaces[mi];
                    if (!PathfindingMath.AreSurfacesCoplanar(merged, orig))
                        continue;

                    // Check vertex overlap
                    foreach (var v in orig.Vertices)
                    {
                        if (merged.Vertices.Any(mv => PathfindingMath.PointsEqual(mv, v)))
                        {
                            result[orig.OriginalSurfaceIndex] = mi;
                            found = true;
                            break;
                        }
                    }

                    if (found) break;
                }

                if (!found)
                    result[orig.OriginalSurfaceIndex] = -1;
            }

            return result;
        }

        /// <summary>
        /// Returns the tag reference from a palette list at the given index, or null if out of range.
        /// </summary>
        /// <summary>
        /// Ensures a matching ReferenceFrame entry exists in the scenario for the given
        /// ObjectIdentifier. If one already exists (matched by UniqueId, Type, Source, and
        /// OriginBspIndex) it is left as-is. Otherwise a new one is added with:
        ///   NodeIndex = 0 (root), ProjectionAxis = 2 (Z-up), Flags = None.
        /// All three blocks — scenario placement, reference frame, and pathfinding ObjectReference
        /// — must share the same ObjectIdentifier.
        /// </summary>
        private void EnsureObjectReferenceFrame(ObjectIdentifier objectId)
        {
            if (Scenario.ObjectReferenceFrames == null)
                Scenario.ObjectReferenceFrames = new List<ReferenceFrame>();

            // Check if a matching frame already exists
            foreach (var frame in Scenario.ObjectReferenceFrames)
            {
                if (frame.ObjectId.UniqueId       == objectId.UniqueId       &&
                    frame.ObjectId.Type.Halo3ODST == objectId.Type.Halo3ODST &&
                    frame.ObjectId.Source         == objectId.Source         &&
                    frame.ObjectId.OriginBspIndex == objectId.OriginBspIndex)
                    return;
            }

            Scenario.ObjectReferenceFrames.Add(new ReferenceFrame
            {
                ObjectId       = objectId,
                NodeIndex      = 0,  // always root for pathfinding
                ProjectionAxis = 2,  // Z-up
            });
        }

        private static CachedTag? GetPaletteTag<T>(List<T>? palette, short index)
            where T : ScenarioPaletteEntry
        {
            if (palette == null || index < 0 || index >= palette.Count)
                return null;
            return palette[index].Object;
        }

        private static RealMatrix4x3 BuildObjectTransform(ScenarioInstance placement)
        {
            // ScenarioInstance.Rotation is RealEulerAngles3d; Angle is stored in radians in TagTool.
            var rot = placement.Rotation;
            float yaw   = rot.Yaw.Radians;
            float pitch = rot.Pitch.Radians;
            float roll  = rot.Roll.Radians;

            float cy = MathF.Cos(yaw),   sy = MathF.Sin(yaw);
            float cp = MathF.Cos(pitch), sp = MathF.Sin(pitch);
            float cr = MathF.Cos(roll),  sr = MathF.Sin(roll);

            // Row-major rotation: Rz(yaw) * Ry(pitch) * Rx(roll)
            return new RealMatrix4x3(
                cy * cp,
                sy * cp,
                -sp,
                cy * sp * sr - sy * cr,
                sy * sp * sr + cy * cr,
                cp * sr,
                cy * sp * cr + sy * sr,
                sy * sp * cr - cy * sr,
                cp * cr,
                placement.Position.X,
                placement.Position.Y,
                placement.Position.Z
            );
        }

        // -------------------------------------------------------------------------
        // Collision geometry vertex extraction helpers
        // -------------------------------------------------------------------------

        private static List<RealPoint3d> GetSurfaceVertices(CollisionGeometry geo, int surfaceIndex)
        {
            var verts = new List<RealPoint3d>();
            var surf = geo.Surfaces[surfaceIndex];
            int startEdge = surf.FirstEdge;
            int curEdge = startEdge;

            // Walk the edge loop for this surface
            int safety = 0;
            do
            {
                if (curEdge < 0 || curEdge >= geo.Edges.Count || safety++ > 64)
                    break;

                var edge = geo.Edges[curEdge];

                if (edge.LeftSurface == surfaceIndex)
                {
                    verts.Add(geo.Vertices[edge.StartVertex].Point);
                    curEdge = edge.ForwardEdge;
                }
                else
                {
                    verts.Add(geo.Vertices[edge.EndVertex].Point);
                    curEdge = edge.ReverseEdge;
                }
            }
            while (curEdge != startEdge);

            return verts;
        }

        private static List<RealPoint3d> GetLargeSurfaceVertices(LargeCollisionBspBlock geo, int surfaceIndex)
        {
            var verts = new List<RealPoint3d>();
            var surf = geo.Surfaces[surfaceIndex];
            int startEdge = surf.FirstEdge;
            int curEdge = startEdge;

            int safety = 0;
            do
            {
                if (curEdge < 0 || curEdge >= geo.Edges.Count || safety++ > 64)
                    break;

                var edge = geo.Edges[curEdge];

                if (edge.LeftSurface == surfaceIndex)
                {
                    verts.Add(geo.Vertices[edge.StartVertex].Point);
                    curEdge = edge.ForwardEdge;
                }
                else
                {
                    verts.Add(geo.Vertices[edge.EndVertex].Point);
                    curEdge = edge.ReverseEdge;
                }
            }
            while (curEdge != startEdge);

            return verts;
        }

        // -------------------------------------------------------------------------
        // Pathfinding block initialisation and resource writing
        // -------------------------------------------------------------------------

        /// <summary>
        /// Always resets the pathfinding tag block to a fresh empty state regardless of
        /// what was there before, so re-running the command produces a clean result.
        /// </summary>
        private static void ResetPathfindingBlock(ScenarioStructureBsp bsp)
        {
            bsp.PathfindingData = new List<TagPathfinding>
            {
                new TagPathfinding
                {
                    Sectors                     = new TagBlock<Sector>(),
                    Links                       = new TagBlock<PfLink>(),
                    Vertices                    = new TagBlock<PfVertex>(),
                    ObjectReferences            = new TagBlock<PfObjectRef>(),
                    Bsp2dRef                    = new TagBlock<Bsp2dRef>(),
                    Bsp2dNodes                  = new TagBlock<PfBsp2dNode>(),
                    InstancedGeometryReferences = new TagBlock<InstancedGeometryReference>(), // TODO
                    PathfindingHints            = new TagBlock<PathfindingHint>(),
                    GiantPathfinding            = new TagBlock<GiantPathfindingBlock>(),
                    Doors                       = new TagBlock<Door>(),
                    Seams                       = new TagBlock<Pathfinding.Seam>(),
                    JumpSeams                   = new TagBlock<JumpSeam>(),
                }
            };
        }

        private void WritePathfindingResource(ScenarioStructureBsp bsp)
        {
            var resourceDef = Cache.ResourceCache.GetStructureBspCacheFileTagResources(bsp.PathfindingResource);

            // SurfacePlanes, Planes, and EdgeToSeams are generated during map compilation and
            // must be preserved — they are not part of the pathfinding generation process.
            // Only PathfindingData is ours to overwrite.
            resourceDef.PathfindingData = new TagBlock<ResourcePathfinding>(CacheAddressType.Definition);

            foreach (var pf in bsp.PathfindingData)
                resourceDef.PathfindingData.Add(PathfindingConverter.CreateResourcePathfindingFromTag(pf));

            bsp.PathfindingResource = Cache.ResourceCache.CreateStructureBspCacheFileResource(resourceDef);
        }
    }
}
