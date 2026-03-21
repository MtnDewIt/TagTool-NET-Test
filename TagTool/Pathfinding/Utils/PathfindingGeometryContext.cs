using System;
using System.Collections.Generic;
using TagTool.Common;
using TagTool.Geometry.BspCollisionGeometry;
using TagTool.Tags.Definitions;
using TagTool.Tags.Definitions.Common;

#nullable enable

namespace TagTool.Pathfinding.Utils
{
    /// <summary>
    /// Represents a single collision surface after being read and pre-processed from any source
    /// (cluster geo, instanced geo, or scenario object collision model). Vertices are already in
    /// world space at this point. The surface normal / plane equation is also world-space.
    /// </summary>
    public class ProcessedSurface
    {
        /// <summary>World-space vertices in winding order.</summary>
        public List<RealPoint3d> Vertices { get; set; } = new List<RealPoint3d>();

        /// <summary>World-space plane equation for this surface.</summary>
        public RealPlane3d Plane { get; set; }

        /// <summary>
        /// Slope of this surface. K component of the plane normal: 1.0 = perfectly flat,
        /// 0.0 = perfectly vertical. Surfaces below the threshold are walls and are excluded
        /// from walkable sector generation.
        /// </summary>
        public float SlopeK => Plane.K;

        public bool IsWalkable(float threshold) => SlopeK >= threshold;

        /// <summary>Source this surface originated from, used for flag assignment.</summary>
        public SurfaceSource Source { get; set; }

        /// <summary>
        /// Original surface index within its source collision geometry block.
        /// Preserved for Bsp2dRef mapping back to the ObjRef block.
        /// </summary>
        public int OriginalSurfaceIndex { get; set; }

        /// <summary>
        /// For object / instanced geo surfaces, a back-reference to the owning context entry.
        /// Used during intersection and stitch tests.
        /// </summary>
        public int OwnerIndex { get; set; } = -1;
    }

    public enum SurfaceSource
    {
        ClusterGeo,
        InstancedGeo,
        ScenarioObject,
    }

    /// <summary>
    /// Represents one instanced geometry placement, with its collision surfaces already
    /// transformed into world space.
    /// </summary>
    public class ProcessedInstancedGeo
    {
        public int DefinitionIndex { get; set; }
        public RealMatrix4x3 WorldTransform { get; set; }
        public Scenery.PathfindingPolicyValue PathfindingPolicy { get; set; }
        public List<ProcessedSurface> Surfaces { get; set; } = new List<ProcessedSurface>();
    }

    /// <summary>
    /// Represents one scenario object placement (scenery, machine, crate, giant) whose
    /// collision model has been resolved and whose surfaces are in world space.
    /// </summary>
    public class ProcessedObjectPlacement
    {
        public GameObjectTypeHalo3ODST ObjectType { get; set; }
        public ObjectPathfindingPolicy PathfindingPolicy { get; set; }
        public RealMatrix4x3 WorldTransform { get; set; }

        /// <summary>
        /// The placement's ObjectIdentifier, copied directly from the scenario placement block.
        /// Used for the pathfinding ObjectReference.ObjectId and the scenario ObjectReferenceFrames
        /// entry — all three blocks must share the same identifier.
        /// </summary>
        public ObjectIdentifier PlacementObjectId { get; set; } = new ObjectIdentifier();

        /// <summary>
        /// Surfaces grouped by [region][bsp], preserving the region/bsp structure so we can
        /// write the correct BspIndex and VertexOffset values in the ObjectReference block.
        /// </summary>
        public List<List<ProcessedBspBlock>> RegionBsps { get; set; } = new List<List<ProcessedBspBlock>>();

        /// <summary>Node index per bsp block, read from the collision model.</summary>
        public List<List<short>> RegionBspNodeIndices { get; set; } = new List<List<short>>();

        /// <summary>Raw vertex count per bsp block, used to compute cumulative VertexOffset.</summary>
        public List<List<int>> RegionBspVertexCounts { get; set; } = new List<List<int>>();
    }

    public class ProcessedBspBlock
    {
        public List<ProcessedSurface> Surfaces { get; set; } = new List<ProcessedSurface>();

        /// <summary>
        /// Original collision edges in this bsp block, preserved so we can re-derive adjacency
        /// after surface culling and merging without re-reading from the tag.
        /// </summary>
        public List<Edge> OriginalEdges { get; set; } = new List<Edge>();

        /// <summary>
        /// Original vertices in world space, parallel to the collision geometry vertex list.
        /// </summary>
        public List<RealPoint3d> OriginalVertices { get; set; } = new List<RealPoint3d>();
    }

    public enum ObjectPathfindingPolicy
    {
        None,
        CutOut,
        Static,
        Dynamic,
    }

    /// <summary>
    /// The full pre-processed world representation used by the pathfinding generator.
    /// Built once from all collision sources before any sector or link generation begins.
    /// </summary>
    public class PathfindingGeometryContext
    {
        // -------------------------------------------------------------------------
        // Cluster (base map) data
        // -------------------------------------------------------------------------

        /// <summary>
        /// All walkable cluster geo surfaces in world space. These feed into the base sector
        /// generation and are the reference geometry for instanced geo intersection/cutout tests.
        /// </summary>
        public List<ProcessedSurface> ClusterSurfaces { get; set; } = new List<ProcessedSurface>();

        // -------------------------------------------------------------------------
        // Instanced geo data
        // -------------------------------------------------------------------------

        public List<ProcessedInstancedGeo> InstancedGeoEntries { get; set; } = new List<ProcessedInstancedGeo>();

        // -------------------------------------------------------------------------
        // Scenario object data
        // -------------------------------------------------------------------------

        /// <summary>
        /// Scenario object placements with Static or Dynamic policy — these get ObjectReferences
        /// and sector data written into the pathfinding block.
        /// </summary>
        public List<ProcessedObjectPlacement> ObjectPlacements { get; set; } = new List<ProcessedObjectPlacement>();

        /// <summary>
        /// Scenario object placements with CutOut policy — these affect the base map sector
        /// generation (cutout where they intersect cluster geo) but get no ObjectReference.
        /// Populated during first pass for use by GenerateBspPathfinding.
        /// </summary>
        public List<ProcessedObjectPlacement> CutOutPlacements { get; set; } = new List<ProcessedObjectPlacement>();

        // -------------------------------------------------------------------------
        // Cumulative vertex offset tracking
        // (mirrors the VertexOffset field in ObjectReference.BspReference)
        // -------------------------------------------------------------------------

        /// <summary>
        /// Running total of all collision vertices seen across cluster geo, instanced geo,
        /// and previously written object refs. Seeded from the BSP collision resource vertex
        /// count, or from StructureChecksum if we are appending to existing data.
        /// </summary>
        public int CumulativeVertexOffset { get; set; } = 0;

        // -------------------------------------------------------------------------
        // Configuration
        // -------------------------------------------------------------------------

        /// <summary>
        /// Surfaces whose plane normal K component is below this value are treated as walls.
        /// Derived from SlopeDegrees: cos(angle). Default cos(45°) ≈ 0.707.
        /// </summary>
        public float SlopeThreshold { get; set; } = 0.707f;

        /// <summary>
        /// Minimum angle change (degrees) between two adjacent sector planes to generate
        /// a threshold link. Default 15 degrees.
        /// </summary>
        public float ThresholdDegrees { get; set; } = 15.0f;

        /// <summary>
        /// Maximum gap (world units) between two coplanar surfaces that can still be merged.
        /// Surfaces within this distance are treated as touching for the purposes of merging.
        /// </summary>
        public float CoplanarMergeEpsilon { get; set; } = 0.01f;
    }

    // -------------------------------------------------------------------------
    // Small math helpers used during context construction
    // -------------------------------------------------------------------------

    public static class PathfindingMath
    {
        /// <summary>
        /// Transforms a RealPoint3d by a RealMatrix4x3 (rotation + translation, no scale column).
        /// </summary>
        public static RealPoint3d TransformPoint(RealPoint3d p, RealMatrix4x3 m)
        {
            return new RealPoint3d(
                p.X * m.m11 + p.Y * m.m21 + p.Z * m.m31 + m.m41,
                p.X * m.m12 + p.Y * m.m22 + p.Z * m.m32 + m.m42,
                p.X * m.m13 + p.Y * m.m23 + p.Z * m.m33 + m.m43
            );
        }

        /// <summary>
        /// Transforms only the direction part of a plane normal (ignores translation).
        /// </summary>
        public static RealVector3d TransformNormal(RealVector3d n, RealMatrix4x3 m)
        {
            return new RealVector3d(
                n.I * m.m11 + n.J * m.m21 + n.K * m.m31,
                n.I * m.m12 + n.J * m.m22 + n.K * m.m32,
                n.I * m.m13 + n.J * m.m23 + n.K * m.m33
            );
        }

        /// <summary>
        /// Transforms a full plane (normal + distance) by a matrix.
        /// </summary>
        public static RealPlane3d TransformPlane(RealPlane3d plane, RealMatrix4x3 m)
        {
            var normal = TransformNormal(new RealVector3d(plane.I, plane.J, plane.K), m);
            // Recompute D by projecting any transformed point on the plane
            // Using the origin of the plane: point = normal * D
            var originPoint = new RealPoint3d(plane.I * plane.D, plane.J * plane.D, plane.K * plane.D);
            var transformedOrigin = TransformPoint(originPoint, m);
            float d = normal.I * transformedOrigin.X + normal.J * transformedOrigin.Y + normal.K * transformedOrigin.Z;
            return new RealPlane3d(normal.I, normal.J, normal.K, d);
        }

        /// <summary>
        /// Returns true if two plane normals are parallel within a small angular epsilon.
        /// Used for coplanar checks.
        /// </summary>
        public static bool NormalsParallel(RealPlane3d a, RealPlane3d b, float epsilon = 0.001f)
        {
            float dot = a.I * b.I + a.J * b.J + a.K * b.K;
            return MathF.Abs(dot - 1.0f) < epsilon;
        }

        /// <summary>
        /// Returns true if point p lies on plane within distance epsilon.
        /// </summary>
        public static bool PointOnPlane(RealPoint3d p, RealPlane3d plane, float epsilon = 0.01f)
        {
            float dist = plane.I * p.X + plane.J * p.Y + plane.K * p.Z - plane.D;
            return MathF.Abs(dist) < epsilon;
        }

        /// <summary>
        /// Returns true if two surfaces are coplanar (parallel normals and all vertices of b lie on a's plane).
        /// </summary>
        public static bool AreSurfacesCoplanar(ProcessedSurface a, ProcessedSurface b, float epsilon = 0.01f)
        {
            if (!NormalsParallel(a.Plane, b.Plane, epsilon))
                return false;

            foreach (var v in b.Vertices)
            {
                if (!PointOnPlane(v, a.Plane, epsilon))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Returns true if two surfaces share at least one edge (a pair of vertices within epsilon).
        /// Used as a prerequisite for merge candidacy.
        /// </summary>
        public static bool SurfacesAdjacent(ProcessedSurface a, ProcessedSurface b, float epsilon = 0.01f)
        {
            int sharedCount = 0;
            foreach (var va in a.Vertices)
            {
                foreach (var vb in b.Vertices)
                {
                    if (PointsEqual(va, vb, epsilon))
                    {
                        sharedCount++;
                        if (sharedCount >= 2)
                            return true;
                    }
                }
            }
            return false;
        }

        public static bool PointsEqual(RealPoint3d a, RealPoint3d b, float epsilon = 0.001f)
        {
            return MathF.Abs(a.X - b.X) < epsilon &&
                   MathF.Abs(a.Y - b.Y) < epsilon &&
                   MathF.Abs(a.Z - b.Z) < epsilon;
        }

        /// <summary>
        /// Projects a 3D point onto a 2D plane defined by the largest two axes of the normal,
        /// returning a RealPoint2d. Used for convexity testing.
        /// </summary>
        public static (float u, float v) ProjectOntoPlane(RealPoint3d p, RealPlane3d plane)
        {
            float ax = MathF.Abs(plane.I);
            float ay = MathF.Abs(plane.J);
            float az = MathF.Abs(plane.K);

            if (az >= ax && az >= ay)
                return (p.X, p.Y); // project onto XY
            else if (ay >= ax)
                return (p.X, p.Z); // project onto XZ
            else
                return (p.Y, p.Z); // project onto YZ
        }

        /// <summary>
        /// Returns true if the polygon formed by the given vertices (in 2D projection) is convex.
        /// Assumes winding order is consistent.
        /// </summary>
        public static bool IsConvex2D(List<(float u, float v)> pts)
        {
            int n = pts.Count;
            if (n < 3) return true;

            float? sign = null;
            for (int i = 0; i < n; i++)
            {
                var a = pts[i];
                var b = pts[(i + 1) % n];
                var c = pts[(i + 2) % n];

                float cross = (b.u - a.u) * (c.v - b.v) - (b.v - a.v) * (c.u - b.u);

                if (MathF.Abs(cross) < 1e-6f)
                    continue;

                if (sign == null)
                    sign = MathF.Sign(cross);
                else if (MathF.Sign(cross) != sign)
                    return false;
            }
            return true;
        }
    }
}
