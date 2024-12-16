using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assimp.Configs;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Pathfinding;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using static TagTool.Tags.Definitions.Gen2.ScreenEffect.RasterizerScreenEffectPassReferenceBlock;
using static TagTool.Tags.Definitions.ScenarioStructureBsp.Cluster;

namespace TagTool.Commands.ScenarioStructureBSPs
{
	public class GeneratePathfindingDataCommand : Command
	{
		private GameCache Cache { get; }
		private ScenarioStructureBsp Bsp { get; }
		private CachedTag CollisionTag { get; set; }
		private CollisionModel CollisionDefinition { get; set; }
		private enum UpAxis
		{
			I,
			J,
			K
		}
		public GeneratePathfindingDataCommand(GameCache cache, ScenarioStructureBsp bsp) :
			base(true,

				"GeneratePathfindingData",
				"",

				"GeneratePathfindingData [Object Collision Model] [IncludeBsp]",
				"") {
			Cache = cache;
			Bsp = bsp;
		}

		public override object Execute(List<string> args) {
			if (args.Count > 2)
				return new TagToolError(CommandError.ArgCount);

			bool bspPathfinding = false;
			bool includeBsp = false;

			if (args.Count == 0) {
				bspPathfinding = true;
			}

			if (args.Count >= 1) {
				if (!Cache.TagCache.TryGetTag<CollisionModel>(args[0], out CachedTag collisionTag)) {
					return new TagToolError(CommandError.TagInvalid);
				}
				else {
					CollisionTag = collisionTag;
				}
			}

			if (args.Count == 2) {
				if (args[1].ToLower() == "includebsp") {
					includeBsp = true;
				}
			}

			return ExecuteInternal(bspPathfinding, includeBsp);

		}

		public object ExecuteInternal(bool bspPathfinding, bool includeBsp, CollisionModel useModel = null) {
			// Does this current sbsp have any tag pathfinding data, if not, create a new block for it, else, append the data
			// There should always only be one block for this, so the array index is always going to be [0]
			// We have to create all the types regardless if we use them or not otherwise it can't be written to resource
			if (Bsp.PathfindingData.Count == 0) {
				Bsp.PathfindingData = new List<TagPathfinding>();
				Bsp.PathfindingData.Add(new TagPathfinding());
				Bsp.PathfindingData[0].Sectors = new TagBlock<Sector>();
				Bsp.PathfindingData[0].Links = new TagBlock<Link>();
				Bsp.PathfindingData[0].Vertices = new TagBlock<Vertex>();
				Bsp.PathfindingData[0].ObjectReferences = new TagBlock<ObjectReference>();
				Bsp.PathfindingData[0].Bsp2dRef = new TagBlock<Bsp2dRef>();
				Bsp.PathfindingData[0].Bsp2dNodes = new TagBlock<Bsp2dNode>();
				Bsp.PathfindingData[0].InstancedGeometryReferences = new TagBlock<InstancedGeometryReference>();
				Bsp.PathfindingData[0].PathfindingHints = new TagBlock<PathfindingHint>();
				Bsp.PathfindingData[0].GiantPathfinding = new TagBlock<GiantPathfindingBlock>();
				Bsp.PathfindingData[0].Doors = new TagBlock<Door>();
				Bsp.PathfindingData[0].Seams = new TagBlock<Pathfinding.Seam>();
				Bsp.PathfindingData[0].JumpSeams = new TagBlock<JumpSeam>();
			}

			if (useModel != null) { CollisionDefinition = useModel; }

			using (Stream cacheStream = Cache.OpenCacheReadWrite()) {
				if (bspPathfinding) {
					GenerateBspPathfinding(cacheStream);
				}
				else {
					GenerateObjectPathfinding(cacheStream, Bsp, includeBsp);
				}
			}

			return true;
		}

		public void GenerateBspPathfinding(Stream cacheStream) {
			// Add logic to handle bsp pathfinding data
		}

		public void GenerateObjectPathfinding(Stream cacheStream, ScenarioStructureBsp Bsp, bool includeBsp) {
			if (CollisionDefinition == null) {
				CollisionDefinition = Cache.Deserialize<CollisionModel>(cacheStream, CollisionTag);
			}

			//var PathData = Bsp.PathfindingData[0];
			//var PathData = new TagPathfinding {};
			var PathData = Bsp.PathfindingData[0];

			// Add logic to handle object pathfinding data
			int CurVertOffset = 0;

			// SLIGHTLY HACKY TRICK TO USE A POSTGEN INFO FIELD FOR STORING WHERE THE VERTEX OFFSET LEFT OFF
			// Is this the first time we are adding an object to the pathfinding, if so, calculate
			// starting offset from the base map collision, if not, just grab the value we stored before
			if (PathData.StructureChecksum == 0) {
				var BspCollVertCount = Cache.ResourceCache.GetStructureBspTagResources(Bsp.CollisionBspResource);

				// There should only be one block for either collision bsp or large collision bsp per sbsp
				if (BspCollVertCount.CollisionBsps.Count == 1)
					CurVertOffset += BspCollVertCount.CollisionBsps[0].Vertices.Count;
				if (BspCollVertCount.LargeCollisionBsps.Count == 1)
					CurVertOffset += BspCollVertCount.LargeCollisionBsps[0].Vertices.Count;

				// Loop through all instanced geo to grab their vertices as well
				if (BspCollVertCount.InstancedGeometry.Count > 0) {
					foreach (var InstGeo in BspCollVertCount.InstancedGeometry)
						CurVertOffset += InstGeo.CollisionInfo.Vertices.Count;
				}

			}
			else {
				CurVertOffset = PathData.StructureChecksum;
			}


			// One block per scenario placed object we want to have pathfinding for
			//if (PathData.ObjectReferences.Count == 0)
			//{
			//    PathData.ObjectReferences = new List<ObjectReference>();
			//}
			PathData.ObjectReferences.Add(new ObjectReference());
			var ObjRef = PathData.ObjectReferences[PathData.ObjectReferences.Count - 1]; // Get the newest one
			ObjRef.Bsps = new TagBlock<ObjectReference.BspReference>();

			// Values that are always going to be the same for our purposes, object type and unique id need to be manually set (for now)
			ObjRef.ObjectReferenceFlags = ObjectReference.Flags.Mobile;
			ObjRef.OriginBspIndex = -1;
			ObjRef.Source = ObjectReference.ObjectSourceEnumDefinition.Editor;

			// Pathfinding is only generated for the base permutation, aka, if a model has damage states, these are not included
			// So for each region, in the base permutation, how many bsps are there, so if you had 4 regions with 5 bps in each
			// base permutation we would need 20 bsp blocks for the object ref

			// The bsp index is another value that should be displayed in 8 digit signed hex (int) to make sense, it is composed of 3 values
			// lets take this example: 50332189, which is 0300021D in signed hex
			// the first 4 bytes are for the region so 0300 is the 4th region (because of little endian)
			// next two bytes are the bsp index within that region, so 02 is the 3rd bsp in the 4th region
			// last two bytes are the node index that the bsp block refs, so 1D is the 29th node/bone
			// a good representation of this would be: Region[3].Permutation[0].Bsp[2].NodeIndex
			// it could also be the region is 2 bytes and the bsp is 4 bytes, but what model should
			// ever have more then 255 bsps per region? and regions are limited to 16
			// we'll go with the latter def for now

			// Not sure why there is an explicit node index value since the last one already stores this, but it's much simpler to understand

			// Vertex offset is a cumulative value in regards to ALL vertices in the collision bsp of the base map and 
			// any objects used for pathfinding (in that order), it doesn't matter if all the vertices get used for the pathfinding or not
			// so if you have a base map which has 300 vertices for it's entire collision bsp, and you have an object with 1 region and 3 bsps
			// each bsp having 50 vertices
			// the first vertex offset value would be 300 (accounting for the base map), then the next bsp block offset would be 350
			// the last being 400, then if you had another object with 1 region and 2 bsps with 30 vertices each
			// the starting offset for that second object would 450 (accounting for base map and first object) and it's last offset would be 480
			// Not sure if this value has any actual usefulness or if it's just post gen info, since it "appears" to work regardless

			// For as many surfaces there are in the collision model per bsp block there will be the same amount
			// of reference blocks in the object pathfinding block, if surfaces are culled based on plane angle then the
			// corresponding surface ref will be set to -1 since the refs must always be in the same order and amount
			// and this tells it has no corresponding sector to link


			//int CurObjRefBsp = 0;
			//
			//for (int CurReg = 0; CurReg < CollisionDefinition.Regions.Count; CurReg++)
			//    for (int CurBsp = 0; CurBsp < CollisionDefinition.Regions[CurReg].Permutations[0].Bsps.Count; CurBsp++)
			//    {
			//        Bsp.PathfindingData[0].ObjectReferences[CurObjRefIndex].Bsps.Add(1);
			//        Bsp.PathfindingData[0].ObjectReferences[CurObjRefIndex].Bsps[CurObjRefBsp].BspIndex =
			//
			//        for (int CurSurf = 0; CurSurf < CollisionDefinition.Regions[CurReg].Permutations[0].Bsps[CurBsp].Geometry.Surfaces.Count; CurSurf++)
			//
			//        CurObjRefBsp++;
			//    }

			// Order of operations: surface, get first edge, then go through the edge loop till
			// you get back to the starting edge, grabbing vertices along the way
			// creating an edge and vertice mapping dictionary since we need to cull
			// some, then link the original index to the new index 


			float SurfSlope = 0.70f;
			//bool Cull = true;

			// Current block indexes for the collision model
			int CurReg = 0;
			int CurBsp = 0;
			int CurSurf = 0;
			int CurEdge = 0;
			// int CurVert = 0;

			// Current block indexes for the pathfinding data
			int CurSect = 0;
			int CurLink = 0;
			int CurPoint = 0;

			// Since we are culling surfaces, edges, and vertices, we need to keep track of what the original indexes were, and then re-map them
			var SurfMap = new Dictionary<int, int>();
			var EdgeMap = new Dictionary<int, int>();
			var VertMap = new Dictionary<int, int>();

			// Just seperate into two seperate versions 

			// could do slope checking of the forward and reverse edges to determine other flags (if it matters)
			// ledge vs wall base hmmm 

			foreach (var ColReg in CollisionDefinition.Regions) {
				foreach (var ColBsp in ColReg.Permutations[0].Bsps) {
					ObjRef.Bsps.Add(new ObjectReference.BspReference());
					ObjRef.Bsps[CurBsp].BspIndex = ( CurReg << 6 ) + ( CurBsp << 2 ) + ColBsp.NodeIndex;
					ObjRef.Bsps[CurBsp].NodeIndex = ColBsp.NodeIndex;
					ObjRef.Bsps[CurBsp].VertexOffset = CurVertOffset;
					CurVertOffset += ColBsp.Geometry.Vertices.Count;

					// Map all surfaces whether they are going to have a corresponding sector or not,
					// this reduces the time complexity for the next part
					foreach (var ColSurf in ColBsp.Geometry.Surfaces) {
						if (ColSurf.Plane > ColBsp.Geometry.Planes.Count - 1) // some wack plane index values in some models
						{
							SurfMap.Add(CurSurf++, -1);
							continue;
						}
						if (ColBsp.Geometry.Planes[ColSurf.Plane].Value.K > SurfSlope) // 1 means flat for this axis, and 0.001 would be almost vertical relative
						{
							SurfMap.Add(CurSurf++, CurSect++);
							//CurSect++;
						}
						else {
							SurfMap.Add(CurSurf++, -1);
						}

						//CurSurf++;
					}

					// SurfMap.ElementAt(ColEdge.LeftSurface).Value != -1
					// we may be able to remove that system.linq value 

					// See what edges we are going to keep, and create a mapping so we can re-link everything properly
					foreach (var ColEdge in ColBsp.Geometry.Edges) {
						if (SurfMap[ColEdge.LeftSurface] != -1 || SurfMap[ColEdge.RightSurface] != -1) {
							EdgeMap.Add(CurEdge++, CurLink++);

							// Make sure we don't already have these vertices
							if (!VertMap.TryGetValue(ColEdge.StartVertex, out int dummy)) {
								VertMap.Add(ColEdge.StartVertex, CurPoint++);
							}
							if (!VertMap.TryGetValue(ColEdge.EndVertex, out int dummy2)) {
								VertMap.Add(ColEdge.EndVertex, CurPoint++);
							}

							//CurLine++;
						}
						else {
							EdgeMap.Add(CurEdge++, -1);
						}
					}

					ObjRef.Bsps[CurBsp].Bsp2dRefs = new TagBlock<ObjectReference.BspReference.Bsp2dRef>();
					int ValSectIndex = 0;

					// Now that we have all our mappings, time to generate and reorder
					for (int i = 0; i < SurfMap.Count; i++) {
						if (SurfMap[i] != -1) {
							PathData.Sectors.Add(new Sector());
							PathData.Sectors[ValSectIndex].PathfindingSectorFlags = Sector.FlagsValue.SectorWalkable | Sector.FlagsValue.SectorMobile | Sector.FlagsValue.Floor;
							PathData.Sectors[ValSectIndex].HintIndex = -1;
							PathData.Sectors[ValSectIndex++].FirstLink = EdgeMap[ColBsp.Geometry.Surfaces[i].FirstEdge];
						}
						ObjRef.Bsps[CurBsp].Bsp2dRefs.Add(new ObjectReference.BspReference.Bsp2dRef());
						ObjRef.Bsps[CurBsp].Bsp2dRefs[i].NodeOrSectorIndex = SurfMap[i];

					}

					int ValLinkIndex = 0;

					for (int i = 0; i < EdgeMap.Count; i++) {
						if (EdgeMap[i] != -1) {
							PathData.Links.Add(new Link());
							PathData.Links[ValLinkIndex].Vertex1 = (short)VertMap[ColBsp.Geometry.Edges[i].StartVertex];// (short)VertMap[i]
							PathData.Links[ValLinkIndex].Vertex2 = (short)VertMap[ColBsp.Geometry.Edges[i].EndVertex];
							PathData.Links[ValLinkIndex].ForwardLink = (short)EdgeMap[ColBsp.Geometry.Edges[i].ForwardEdge];
							PathData.Links[ValLinkIndex].ReverseLink = (short)EdgeMap[ColBsp.Geometry.Edges[i].ReverseEdge];
							PathData.Links[ValLinkIndex].LeftSector = (short)SurfMap[ColBsp.Geometry.Edges[i].LeftSurface];
							PathData.Links[ValLinkIndex].RightSector = (short)SurfMap[ColBsp.Geometry.Edges[i].RightSurface];
							PathData.Links[ValLinkIndex].HintIndex = -1;
							if (PathData.Links[ValLinkIndex].LeftSector != -1 && PathData.Links[ValLinkIndex].RightSector != -1) {
								PathData.Links[ValLinkIndex++].LinkFlags = Link.FlagsValue.SectorLinkThreshold;
							}
							else {
								PathData.Links[ValLinkIndex++].LinkFlags = Link.FlagsValue.SectorLinkLedge; // wall base or ledge, hmm
							}
						}
					}

					var keys = new List<int>(VertMap.Keys);

					for (int i = 0; i < VertMap.Count; i++) {
						PathData.Vertices.Add(new Vertex());
						PathData.Vertices[i].Position = ColBsp.Geometry.Vertices[keys[i]].Point; // I need to know more how dictionaries work lol
					}

					// ColBsp.Geometry.Vertices[VertMap.Select(i => i.Key).First()].Point;

					// See what vertices we are going to keep, and create a mapping so we can re-link everything properly
					//foreach (var ColVert in ColBsp.Geometry.Vertices)
					//{
					//    foreach (EdgeMap.ElementAt(ColEdge.LeftSurface).Value != -1 || SurfMap.ElementAt(ColEdge.RightSurface).Value != -1)
					//    {
					//        EdgeMap.Add(CurEdge, CurLine);
					//
					//        // Make sure we don't already have these vertices
					//        //if (VertMap.TryGetValue()
					//
					//        CurLine++;
					//        //CurPoint += 2;
					//    }
					//
					//    CurEdge++;
					//}

					// Reset these for each bsp
					CurSurf = 0;
					CurEdge = 0;
					ValSectIndex = 0;
					ValLinkIndex = 0;
					SurfMap.Clear();
					EdgeMap.Clear();
					VertMap.Clear();

					// CurVert = 0;

					CurBsp++;
				}
				CurReg++;
			}

			// Store where we left off
			PathData.StructureChecksum = CurVertOffset;

			// Write our new/appended tag data
			Bsp.PathfindingData[0] = PathData;

			if (includeBsp) {
				// Add logic to handle referencing of bsp collision data
			}
		}
	}
}
