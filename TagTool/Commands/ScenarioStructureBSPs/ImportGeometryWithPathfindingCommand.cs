using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.BlamFile;
using TagTool.Cache;
using TagTool.Commands.CollisionModels;
using TagTool.Commands.Common;
using TagTool.Commands.RenderModels;
using TagTool.Common;
using TagTool.Geometry.BspCollisionGeometry;
using TagTool.IO;
using TagTool.Pathfinding;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using TagTool.Tags.Definitions.Common;

namespace TagTool.Commands.ScenarioStructureBSPs
{
	public class ImportGeometryWithPathfindingCommand : Command
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
		public ImportGeometryWithPathfindingCommand(GameCache cache, ScenarioStructureBsp bsp) :
			base(true,
				// Name
				"ImportGeometryWithPathfinding",
				// Description
				"Imports a model into a scenario with generated AI Pathfinding data.",
				// Usage
				"ImportGeometryWithPathfinding [name] [tagName] [daeModelPath] [scenarioTagName]",
				// Help message
				"Arguments:\n" +
				//" <includeBaseMap> -- Generate pathfinding data for the base map.\n" +
				" <name>         -- Name to use for display and ID purposes.\n" +
				" <tagName>      -- Name to use for the tag.\n" +
				" <daeModelPath> -- Path to the model file to import.\n" +
				" <scenarioTagName> -- Tag name of the scenario file to edit."
			) {
			Cache = cache;
			Bsp = bsp;
			cacheStream = Cache.OpenCacheReadWrite();
		}

		//private bool IncludeBaseMap { get; set; }
		private string DaeModelPath { get; set; }
		private string IdName { get; set; }
		private string TagName { get; set; }
		private string ScenarioTagName { get; set; }

		private short NewObjectCount { get; set; }

		#region Cursed Wrappers

		private readonly Stream cacheStream;
		/// <summary>
		/// Attempts to get a named tag from the cache.<br/>
		/// Returns true if the tag was found and deserialized successfully.
		/// </summary>
		/// <typeparam name="T"> The tag type to get. <typeparamref name="T"/> must be a <see cref="TagStructure"/>. </typeparam>
		/// <param name="tagName"> The name of the tag to get. </param>
		/// <param name="tag"> The <typeparamref name="T"/> object (tag) to output the deserialized tag to. </param>
		/// <returns> True if the tag was found and deserialized successfully, false otherwise. </returns>
		private bool TryGetTag<T>(string tagName, out T tag) where T : TagStructure {
			tag = null;
			try {
				CachedTag cachedTag = Cache.TagCache.GetTag<T>(tagName);
				tag = Cache.Deserialize<T>(cacheStream, cachedTag);
				DeserializedTags[tag] = cachedTag;
				return true;
			}
			catch (Exception e) { Console.WriteLine(e); }
			return false;
		}
		private bool TryDuplicateTag<T>(string tagName, string newName, out T tag) where T : TagStructure {
			tag = null;
			try {
				CachedTag toCopy = Cache.TagCache.GetTag<T>(tagName);
				CachedTag cachedCopy = Cache.TagCache.AllocateTag(toCopy.Group, newName);
				T definition = Cache.Deserialize<T>(cacheStream, toCopy);
				Cache.Serialize(cacheStream, cachedCopy, definition);
				( Cache as GameCacheHaloOnlineBase ).SaveTagNames();
				//if (TryGetTag<T>(newName, out tag)) { return true; }
				DeserializedTags[definition] = cachedCopy;
				tag = definition;
				return true;
			}
			catch (Exception e) { Console.WriteLine(e); }
			return false;
		}
		private Dictionary<TagStructure, CachedTag> DeserializedTags = new Dictionary<TagStructure, CachedTag>();
		private bool Serialize(TagStructure tag) {
			try {
				if (DeserializedTags.TryGetValue(tag, out CachedTag cachedTag)) {
					Cache.Serialize(cacheStream, cachedTag, tag);
					return true;
				}
			}
			catch (Exception e) { Console.WriteLine(e); }
			return false;
		}

		~ImportGeometryWithPathfindingCommand() { try { cacheStream?.Close(); } catch { } }
		#endregion



		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <param name="args">The command arguments.</param>
		/// <remarks>
		/// Arguments:<br/>
		/// &lt;name&gt;         -- Name to use for display and ID purposes.<br/>
		/// &lt;tagName&gt;      -- Name to use for the tag.<br/>
		/// &lt;daeModelPath&gt; -- Path to the model file to import.<br/>
		/// &lt;scenarioPath&gt; -- Path to the scenario file to edit.
		/// </remarks>
		public override object Execute(List<string> args) {

			if (args.Count < 4)
				return new TagToolError(CommandError.ArgCount);

			ParseResult parseResult = ParseResult.Parse(
				//new Arg("includeBaseMap", args[0], Arg.Type.Bool, false),
				new Arg("name", args[0], Arg.Type.String, false),
				new Arg("tagName", args[1], Arg.Type.String, false),
				new Arg("daeModelPath", args[2], Arg.Type.FilePath, false),
				new Arg("scenarioTagName", args[3], Arg.Type.String, false)
			);

			if (!parseResult.IsValid) {
				new TagToolError(CommandError.CustomError, string.Join('\n', parseResult.Response));
				return false;
			}

			IdName = parseResult.Parameters[0];
			TagName = parseResult.Parameters[1];
			DaeModelPath = parseResult.Parameters[2];
			ScenarioTagName = parseResult.Parameters[3];

			Console.WriteLine("Successfully parsed args: \n" + string.Join('\n', parseResult.Parameters));

			CollisionTag = null;

			#region notes

			// -- Halo Pathfinding Generation Guide

			// -- Blender
			// - Ensure model has a scale of 1.0
			// - Unit ratio is 1:50 - 50 Units in Blender = 1 Unit (meter) in Halo
			// - Object (Orange Triangle Icon) Name must be "default:default"
			// - Mesh   (Green Triangle Icon ) Name must be "default:default"
			// - Export as DAE (Collada) format

			// \ElDewrito\testing\pathgen_test_ramps.dae
			// \ElDewrito\maps\tags.dat
			// \ElDewrito\mods\whatevermod.pak

			// Default tag path prefix: $"objects\\eldewrito\\forge\\path\\{name}"
			// Example scenario path: levels\eldewrito\movie_set\movie_set.scenario

			#endregion

			using Stream cache = Cache.OpenCacheReadWrite();
			StringId default_sid = Cache.StringTable.GetStringId("default");
			StringId root_sid = Cache.StringTable.GetStringId("root");


			#region Duplicate the render_model from ‘box_m’, creating data for our custom geometry
			// -- DuplicateTag objects\multi\box_m\box_m.render_model {tagName}, and edit newly created render_model tag
			if (TryDuplicateTag(@"objects\multi\box_m\box_m", TagName, out RenderModel geo_rm)) {

				// Populate at least one default region and permutation with default names / values
				geo_rm.Regions[0].Name = default_sid;                   // SetField Regions[0].Name default
				geo_rm.Regions[0].Permutations[0].Name = default_sid;   // SetField Regions[0].Permutations[0].Name default

				// Give the root node (bone) a sensible name
				geo_rm.Nodes[0].Name = root_sid;    // SetField Nodes[0].Name root

				// Replace the render geometry of the render_model tag we’re editing with our custom model
				// -- 	ReplaceRenderGeometry "{daeModelPath}"
				object replaceResult =
					ReplaceRenderGeometryCommand.ExecuteInternal(
						Cache, DeserializedTags[geo_rm], geo_rm, Cache.StringTable.Count, new FileInfo(DaeModelPath), TagTool.Geometry.IndexBufferFormat.TriangleList
					);
				if (replaceResult is bool replaceRenderGeometrySuccess) {
					if (replaceRenderGeometrySuccess) { Console.WriteLine($"Successfully replaced render geometry using:\n'{DaeModelPath}'"); }
					else { return new TagToolError(CommandError.CustomError, "Unknown error occurred while replacing render geometry."); }
				}
				else { 
					if (replaceResult is TagToolError error) { return error; }
					if (replaceResult is TagToolWarning warning) { return warning; }
					return new TagToolError(CommandError.CustomError, "Unknown error occurred while replacing render geometry.");
				}

				//# SetField Materials[0].RenderMethod objects\eldewrito\reforge\shaders\rgb\matte.shader

				#region Copies Materials from the ‘block_1x1x1’ render_model tag in the base cache
				// -- EditTag objects\eldewrito\reforge\block_1x1x1.render_model
				List<TagTool.Geometry.RenderMaterial> blockMaterials = new List<TagTool.Geometry.RenderMaterial>();
				if (TryGetTag(@"objects\eldewrito\reforge\block_1x1x1", out RenderModel block_rm)) {
					// Copy the materials from the RenderModel definition
					blockMaterials = block_rm.Materials;
				}
				// -- Exit
				#endregion

				// Remove the existing materials, then paste the previously copied materials
				geo_rm.Materials.Clear();           // -- 	RemoveBlockElements Materials 0 *
				geo_rm.Materials = blockMaterials;  // -- 	PasteBlockElements Materials

				// Save tag changes, exit the tag editing context
				if (!Serialize(geo_rm)) { return new TagToolError(CommandError.CustomError, "Failed to serialize RenderModel tag."); }
				else { Console.WriteLine("Successfully serialized RenderModel tag."); }

			}
			else { return new TagToolError(CommandError.CustomError, "Failed to duplicate render_model tag."); }
			#endregion

			#region Create a physics model tag for our custom model
			// -- CreateTag phmo {tagName}, and Edit
			if (TryDuplicateTag(@"objects\multi\box_m\box_m", TagName, out PhysicsModel phmo_tag)) {
				// Add required dummy RigidBodies / Physics elements
				phmo_tag.RigidBodies = new List<PhysicsModel.RigidBody>();          // -- 	AddBlockElements RigidBodies
				phmo_tag.RigidBodies.Add(new PhysicsModel.RigidBody {
					MotionType = PhysicsModel.RigidBody.MotionTypeValue.Keyframed,  // -- 	SetField RigidBodies[0].MotionType Keyframed
					ShapeType = TagTool.Havok.BlamShapeType.Pill                    // -- 	SetField RigidBodies[0].ShapeType Pill
				});

				// Add required Materials block with default name and non-interactive physics (phantom) type
				phmo_tag.Materials = new List<PhysicsModel.Material>();             // -- 	AddBlockElements Materials
				phmo_tag.Materials.Add(new PhysicsModel.Material {
					Name = default_sid,                                             // -- 	SetField Materials[0].Name default
					PhantomType = -1                                                // -- 	SetField Materials[0].PhantomType -1
				});

				// Add required Pills block with non-interactive physics (phantom) type and required count (128)
				phmo_tag.Pills = new List<PhysicsModel.Pill>();                     // -- 	AddBlockElements Pills
				phmo_tag.Pills.Add(new PhysicsModel.Pill {
					PhantomIndex = -1,                                              // -- 	SetField Pills[0].PhantomIndex -1
					ShapeBase = new PhysicsModel.HavokShapeBase() { Count = 128 }   // -- 	SetField Pills[0].ShapeBase.Count 128
				});

				// Add required Nodes definition with a minimal (single) Node structure
				phmo_tag.Nodes = new List<PhysicsModel.Node>();                     // -- 	AddBlockElements Nodes
				phmo_tag.Nodes.Add(new PhysicsModel.Node {
					Name = root_sid,                                                // -- 	SetField Nodes[0].Name root
					Parent = -1,                                                    // -- 	SetField Nodes[0].Parent -1
					Sibling = -1,                                                   // -- 	SetField Nodes[0].Sibling -1
					Child = -1                                                      // -- 	SetField Nodes[0].Child -1
				});

				// Save tag changes, exit the tag editing context
				if (!Serialize(phmo_tag)) { return new TagToolError(CommandError.CustomError, "Failed to serialize PhysicsModel tag."); }
				else { Console.WriteLine("Successfully serialized PhysicsModel tag."); }
			}
			else { return new TagToolError(CommandError.CustomError, "Failed to create PhysicsModel tag."); }
			#endregion

			#region ImportCollisionGeometry for our custom model from our custom model
			// -- ImportCollisionGeometry "{daeModelPath}" {tagName} , and Edit the newly created tag
			//CommandRunner.Current.RunCommand($"ImportCollisionGeometryCommand {DaeModelPath} {TagName}", true, true);
			CollisionModel collisionModel = null;
			ImportCollisionGeometryCommand importCollisionCommand = new ImportCollisionGeometryCommand((Cache as GameCacheHaloOnlineBase));
			object importCollisionCommandResult = importCollisionCommand.Execute(new List<string> { "overwrite", DaeModelPath, TagName });
			if (importCollisionCommandResult is bool importCollisionCommandSuccess) {
				if (importCollisionCommandSuccess) { 
					Console.WriteLine($"Successfully imported collision geometry using:\n'{DaeModelPath}'");
					collisionModel = ImportCollisionGeometryCommand.LastCollisionModel;
					DeserializedTags[collisionModel] = ImportCollisionGeometryCommand.LastCachedTag;
				}
				else { return new TagToolError(CommandError.CustomError, "Failed to import collision geometry."); }
			}
			else{
				if (importCollisionCommandResult is TagToolError error) { return error; }
				if (importCollisionCommandResult is TagToolWarning warning) { return warning; }
			}

			// Edit the CollisionModel tag we just created
			if (collisionModel != null) {
				// CollisionDefinition = collisionModel;
				// Make the surface invisible to physics calculations (no collision)
				// -- 	ForEach Regions[0].Permutations[0].Bsps[0].Geometry.Surfaces SetField Flags Invisible
				foreach (Surface surface in collisionModel.Regions[0].Permutations[0].Bsps[0].Geometry.Surfaces) {
						surface.Flags = SurfaceFlags.Invisible;
				}
				// Remove all block elements for BspPhysics and BspMoppCodes
				collisionModel.Regions[0].Permutations[0].BspPhysics = new List<CollisionBspPhysicsDefinition>();	// -- 	RemoveBlockElements Regions[0].Permutations[0].BspPhysics 0 *
				collisionModel.Regions[0].Permutations[0].BspMoppCodes = new List<Havok.TagHkpMoppCode>();			// -- 	RemoveBlockElements Regions[0].Permutations[0].BspMoppCodes 0 *

				// The ImportCollisionGeometry command automatically creates the Node BlockElement
				// Define the required node with a minimal (single) Node structure
				collisionModel.Nodes = new List<CollisionModel.Node>(); // -- 	AddBlockElements Nodes
				collisionModel.Nodes.Add(new CollisionModel.Node {
					Name = root_sid,    // -- 	SetField Nodes[0].Name root
					ParentNode = -1,    // -- 	SetField Nodes[0].ParentNode -1
					FirstChildNode = -1, // -- 	SetField Nodes[0].FirstChildNode -1
					NextSiblingNode = -1 // -- 	SetField Nodes[0].NextSiblingNode -1
				});
				// Save tag changes, exit the tag editing context
				if (!Serialize(collisionModel)) { return new TagToolError(CommandError.CustomError, "Failed to serialize CollisionModel tag."); }
				else { Console.WriteLine("Successfully serialized CollisionModel tag."); }
			}
			else { return new TagToolError(CommandError.CustomError, "Failed to get CollisionModel tag."); }
			#endregion

			#region Create a model tag for our custom geometry
			// -- CreateTag hlmt {tagName}, and Edit the newly created tag
			if (TryDuplicateTag(@"objects\multi\box_m\box_m", TagName, out Model model_tag)) {
				// Set the render_model, collision_model, and physics_model tags we created earlier
				model_tag.RenderModel = Cache.TagCache.GetTag($"{ TagName}.render_model");           // -- 	SetField RenderModel {tagName}.render_model
				model_tag.CollisionModel = Cache.TagCache.GetTag($"{TagName}.collision_model");     // -- 	SetField CollisionModel {tagName}.collision_model
				model_tag.PhysicsModel = Cache.TagCache.GetTag($"{TagName}.physics_model");         // -- 	SetField PhysicsModel {tagName}.physics_model
																									// Add Materials block with no section damage multiplier and a human-metallic global material
				model_tag.Materials = new List<Model.Material>();   // -- 	AddBlockElements Materials
				model_tag.Materials.Add(new Model.Material {
					DamageSectionIndex = -1,                        // -- 	SetField Materials[0].DamageSectionIndex -1
					RuntimeDamagerMaterialIndex = -1,               // -- 	SetField Materials[0].RuntimeDamagerMaterialIndex -1
					GlobalMaterialIndex = 54                        // -- 	SetField Materials[0].GlobalMaterialIndex 54
				});

				model_tag.BeginFadeDistance = 0;                    // -- 	SetField BeginFadeDistance 0
				model_tag.DisappearDistance = 0;                    // -- 	SetField DisappearDistance 0

				// Add required CollisionRegions
				model_tag.CollisionRegions = new List<Model.CollisionRegion>();     // -- 	AddBlockElements CollisionRegions 1
				model_tag.CollisionRegions.Add(new Model.CollisionRegion {
					Name = default_sid,                                             // -- 	SetField CollisionRegions[0].Name default
					Permutations = new List<Model.CollisionRegion.Permutation>()    // -- 	AddBlockElements CollisionRegions[0].Permutations 1
				});

				// Add required Permutations block with default name
				model_tag.CollisionRegions[0].Permutations.Add(new Model.CollisionRegion.Permutation {
					Name = default_sid                                  // -- 	SetField CollisionRegions[0].Permutations[0].Name default
				});

				// Add required Nodes definition with a minimal (single) Node structure
				model_tag.Nodes = new List<Model.Node>();               // -- 	AddBlockElements Nodes
				model_tag.Nodes.Add(new Model.Node {
					Name = root_sid,                                    // -- 	SetField Nodes[0].Name root
					ParentNode = -1,                                    // -- 	SetField Nodes[0].ParentNode -1
					FirstChildNode = -1,                                // -- 	SetField Nodes[0].FirstChildNode -1
					NextSiblingNode = -1,                               // -- 	SetField Nodes[0].NextSiblingNode -1
					DefaultScale = 1,                                   // -- 	SetField Nodes[0].DefaultScale 1
					DefaultRotation = new RealQuaternion(0, 0, 0, -1),  // -- 	SetField Nodes[0].DefaultRotation 0 0 0 -1
					Inverse = RealMatrix4x3.Identity
				});

				// Save tag changes, exit the tag editing context
				if (!Serialize(model_tag)) { return new TagToolError(CommandError.CustomError, "Failed to serialize Model tag."); }

			}
			else { return new TagToolError(CommandError.CustomError, "Failed to create Model tag."); }
			#endregion

			#region Create a crate tag for our custom geometry
			// -- CreateTag bloc {tagName}, and Edit the newly created tag
			if (TryDuplicateTag(@"objects\multi\box_m\box_m", TagName, out Crate crate_tag)) {
				
				// Set Crate Properties
				crate_tag.ObjectType = new GameObjectType16() { Halo3ODST = GameObjectTypeHalo3ODST.Crate };				 // -- 	SetField ObjectType.Halo3ODST Crate
				crate_tag.ObjectFlags = new ObjectDefinitionFlags() { FlagsReach = GameObjectFlagsReach.DoesNotCastShadow }; // -- 	SetField ObjectFlags.Flags DoesNotCastShadow
				crate_tag.BoundingRadius = 10000;																			 // -- 	SetField BoundingRadius 10000
				crate_tag.Model = Cache.TagCache.GetTag($"{ TagName}.model");												 // -- 	SetField Model {tagName}.model
				
				// Add MultiplayerObject Block with values to ensure it always exists
				crate_tag.MultiplayerObject = new List<GameObject.MultiplayerObjectBlock>();
				crate_tag.MultiplayerObject.Add(new GameObject.MultiplayerObjectBlock { 
					Flags = GameObject.MultiplayerObjectBlock.MultiplayerObjectFlags.CandyMonitorShouldIgnore,               // -- 	SetField MultiplayerObject[0].Flags CandyMonitorShouldIgnore
					DefaultSpawnTime = 0,																					 // -- 	SetField MultiplayerObject[0].DefaultSpawnTime 0
					DefaultAbandonTime = 32000																				 // -- 	SetField MultiplayerObject[0].DefaultAbandonTime 32000
				});
				
				// Save tag changes, exit the tag editing context
				if (!Serialize(crate_tag)) { return new TagToolError(CommandError.CustomError, "Failed to serialize Crate tag."); }
				else { Console.WriteLine("Successfully serialized Crate tag."); }
			}
			else { return new TagToolError(CommandError.CustomError, "Failed to create Crate tag."); }
			#endregion

			#region Edit the forge_globals tag to add our new crate to the palette
			// -- EditTag multiplayer\forge_globals.forge_globals_definition
			if (TryGetTag("multiplayer\\forge_globals", out ForgeGlobalsDefinition forge_globals_tag)) {
				
				// Add a new block to the ReForgeObjects block element
				forge_globals_tag.ReForgeObjects.Add(new TagReferenceBlock());
				TagReferenceBlock reForgeObject = forge_globals_tag.ReForgeObjects[forge_globals_tag.ReForgeObjects.Count - 1]; // Get the newest one
				
				// Set the ReForgeObjects block element values
				reForgeObject.Instance = Cache.TagCache.GetTag($"{TagName}.crate"); // -- 	SetField ReForgeObjects[*].Instance {tagName}.crate
				
				// Add a new block to the Palette block element for the new object
				forge_globals_tag.Palette.Add(new ForgeGlobalsDefinition.PaletteItem());
				ForgeGlobalsDefinition.PaletteItem paletteBlock = forge_globals_tag.Palette[forge_globals_tag.Palette.Count - 1]; // Get the newest one
				
				// Set the values for the last element (the new object)
				paletteBlock.Name = IdName;											// -- 	SetField Palette[*].Name "{name}"
				paletteBlock.Type = ForgeGlobalsDefinition.PaletteItemType.Prop;    // -- 	SetField Palette[*].Type Prop
				paletteBlock.CategoryIndex = -1;									// -- 	SetField Palette[*].CategoryIndex -1
				paletteBlock.DescriptionIndex = -1;									// -- 	SetField Palette[*].DescriptionIndex -1
				paletteBlock.Object = Cache.TagCache.GetTag($"{TagName}.crate");    // -- 	SetField Palette[*].Object {tagName}.crate
																					// Save tag changes, exit the tag editing context
				if (!Serialize(forge_globals_tag)) { return new TagToolError(CommandError.CustomError, "Failed to serialize ForgeGlobalsDefinition tag."); }
				else { Console.WriteLine("Successfully serialized ForgeGlobalsDefinition tag."); }

			}
			else { return new TagToolError(CommandError.CustomError, "Failed to get ForgeGlobalsDefinition tag."); }
			#endregion


			// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			// TODO in the future, to support pathfinding generation on standard maps we will need 
			// to iterate through and find all objects with the pathfinding policy set to static/standard
			// we will also need to add an incrementing index value so that we can correctly set indices
			// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

			#region Edit the scenario tag to reference our custom geometry
			// -- EditTag {scenarioPath}.scenario // TODO substitute scenario path arg
			if (TryGetTag(ScenarioTagName, out Scenario scenario_tag)) {
				// Add a new block to the CratePalettes block and reference our new crate
				scenario_tag.CratePalette.Add(new Scenario.ScenarioPaletteEntry() {
					 Object = Cache.TagCache.GetTag($"{TagName}.crate") 
				}); // -- 	SetField CratePalette[*].Object {tagName}.crate
				// Get the index of the newest one
				int cratePaletteIndex = scenario_tag.CratePalette.Count - 1; 

				// Add a new block to the Crates block and set the values
				scenario_tag.Crates.Add(new Scenario.CrateInstance() {
					PaletteIndex = (short)cratePaletteIndex,                                // -- 	SetField Crates[*].PaletteIndex 1
					NameIndex = -1,                                                         // -- 	SetField Crates[*].NameIndex -1
					ObjectId = new ObjectIdentifier 
					{
					    UniqueId = new DatumHandle(44444, 444),                                         // -- 	SetField Crates[*].UniqueHandle 44444 444
					    OriginBspIndex = -1,                                                            // -- 	SetField Crates[*].OriginBspIndex -1
					    Type = new GameObjectType8() { Halo3ODST = GameObjectTypeHalo3ODST.Crate },     // -- 	SetField Crates[*].ObjectType.Halo3ODST Crate
					    Source = ObjectIdentifier.SourceValue.Editor,                                   // -- 	SetField Crates[*].Source Editor
					},
					EditingBoundToBsp = -1,                                                 // -- 	SetField Crates[*].EditingBoundToBsp -1
					EditorFolder = -1,                                                      // -- 	SetField Crates[*].EditorFolder -1
					ParentId = new ScenarioObjectParentStruct() { NameIndex = -1 },         // -- 	SetField Crates[*].ParentId.NameIndex -1
					CanAttachToBspFlags = 65535,                                            // -- 	SetField Crates[*].CanAttachToBspFlags 65535
					PathfindingPolicy = Scenario.PathfindingPolicyValue.Standard            // Standard : Generate pathfinding data
				});

				// When we add support for adding multiple objects, this will ideally be incremented using a loop, or some kind of iterative function.
				NewObjectCount++;

				// Add a PathfindingReferences block element to our pathfinding crate
				Scenario.CrateInstance crate = scenario_tag.Crates.Last();                  // Get the newest one
				if (crate.PathfindingReferences == null){
					crate.PathfindingReferences = new List<Scenario.PathfindingReference>();
				}
				crate.PathfindingReferences.Add(new Scenario.PathfindingReference() {
					BspIndex = -1,                      // -- 	SetField Crates[*].PathfindingReferences[0].BspIndex -1
					PathfindingObjectIndex = 0			// -- 	SetField Crates[*].PathfindingReferences[0].PathfindingObjectIndex 0'
				});

				// Add a Multiplayer block element to our pathfinding crate
				crate.Multiplayer = new Scenario.MultiplayerObjectProperties() {
					Team = TagTool.Tags.Definitions.Common.MultiplayerTeamDesignator.Neutral,	// -- 	SetField Crates[*].Multiplayer.Team Neutral
					MapVariantParent = new ScenarioObjectParentStruct() { NameIndex = -1 }		// -- 	SetField Crates[*].Multiplayer.MapVariantParent.NameIndex -1
				};

				// Add a new block to the ObjectReferenceFrames block and set the values
				if (scenario_tag.ObjectReferenceFrames == null) { 
					scenario_tag.ObjectReferenceFrames = new List<Scenario.ReferenceFrame>(); 
				}
				scenario_tag.ObjectReferenceFrames.Add(new Scenario.ReferenceFrame() {
					ObjectId = new ObjectIdentifier 
					{
					    UniqueId = new DatumHandle(44444, 444),                                         // -- 	SetField ObjectReferenceFrames[*].UniqueHandle 44444 444
					    OriginBspIndex = -1,                                                            // -- 	SetField ObjectReferenceFrames[*].OriginBspIndex -1
					    Type = new GameObjectType8() { Halo3ODST = GameObjectTypeHalo3ODST.Crate },     // -- 	SetField ObjectReferenceFrames[*].ObjectType.Halo3ODST Crate
					    Source = ObjectIdentifier.SourceValue.Editor,                                   // -- 	SetField ObjectReferenceFrames[*].Source Editor
					},
					NodeIndex = 0,                                                          // -- 	SetField ObjectReferenceFrames[*].NodeIndex 0
					ProjectionAxis = 2,                                                     // -- 	SetField ObjectReferenceFrames[*].ProjectionAxis 2
					Flags = Scenario.ReferenceFrame.AiReferenceFrameFlags.ProjectionSign	// -- 	SetField ObjectReferenceFrames[*].Flags ProjectionSign
				});

				// Save tag changes, exit the tag editing context
				if (!Serialize(scenario_tag)) { return new TagToolError(CommandError.CustomError, "Failed to serialize Scenario tag."); }
				else { Console.WriteLine("Successfully serialized Scenario tag."); }

				#endregion

				// NOTE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
				// the .scenario_structure_bsp file we're referencing here would be an existing part of a built map
				// keep in mind, this process generates pathfinding data, it doesn't generate the scenario or the SSBSP
				// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

				#region Generate the Pathfinding Data
				// -- EditTag {scenarioPath}.scenario_structure_bsp // TODO either *get* the .ssbsp tag name or presume based on supplied arguments
				ScenarioStructureBsp ssbsp_tag = Bsp;				
				if (ssbsp_tag != null) { //if (TryGetTag($"{ScenarioTagName}.scenario_structure_bsp", out ScenarioStructureBsp ssbsp_tag)) {
					// Remove any existing pathfinding data
					ssbsp_tag.PathfindingData = new List<TagPathfinding>();

					// Generate the pathfinding data for our custom geometry
					GeneratePathfindingDataCommand pathfindingCommand = new GeneratePathfindingDataCommand(Cache, ssbsp_tag);
					object pathfindingResult = pathfindingCommand.ExecuteInternal(true, true, collisionModel);
					if (pathfindingResult is bool pathfindingSuccess) {
						if (pathfindingSuccess) { Console.WriteLine("Successfully generated pathfinding data."); }
						else { return new TagToolError(CommandError.CustomError, "Failed to generate pathfinding data."); }
					}
					else {
						if (pathfindingResult is TagToolError error) { return error; }
						if (pathfindingResult is TagToolWarning warning) { return warning; }
						return new TagToolError(CommandError.CustomError, "Failed to generate pathfinding data.");
					}

					// Set references for our pathfinding data
					TagPathfinding pathData = ssbsp_tag.PathfindingData[0]; // Get the newest one
					pathData.ObjectReferences = new TagBlock<ObjectReference>() {
						new ObjectReference() {
							ObjectId = new ObjectIdentifier{
								UniqueId = new DatumHandle(44444, 444),
								Type = new GameObjectType8() { Halo3ODST = GameObjectTypeHalo3ODST.Crate },
							},
							Bsps = new TagBlock<ObjectReference.BspReference>() { 
								new ObjectReference.BspReference() { 
									Bsp2dRefs = new TagBlock<ObjectReference.BspReference.Bsp2dRef>() { 
										new ObjectReference.BspReference.Bsp2dRef() 
									} 
								} 
							}
						}
					};

					// Apply the edited Pathfinding Data
					EditPathfindingGeometryCommand editPathfindingCommand = new EditPathfindingGeometryCommand(Cache, ssbsp_tag);
					object editPathfindingResult = editPathfindingCommand.Execute(new List<string>());
					if (editPathfindingResult is bool editPathfindingSuccess) {
						if (editPathfindingSuccess) { Console.WriteLine("Successfully applied pathfinding data to the scenario BSP."); }
						else { return new TagToolError(CommandError.CustomError, "Failed to apply pathfinding data."); }
					}
					else {
						if (editPathfindingResult is TagToolError error) { return error; }
						if (editPathfindingResult is TagToolWarning warning) { return warning; }
						return new TagToolError(CommandError.CustomError, "Failed to apply pathfinding data.");
					}

					#endregion

					Console.WriteLine("\nSuccessfully imported geometry with pathfinding data.\n");

					Console.WriteLine("Use 'SaveTagChanges' to save these changes, or they will be lost.");
					Console.WriteLine("And don't forget to call 'SaveModPackage' as well.");

					// Don't forget! Save the modified package
					// -- SaveModPackage

				}
				else { return new TagToolError(CommandError.CustomError, "Failed to get ScenarioStructureBsp tag."); }
			}
			else { return new TagToolError(CommandError.CustomError, "Failed to get Scenario tag."); }

			try
			{
				string mapName = null;
				if (ScenarioTagName.Contains("s3d_avalanche"))		{ mapName = "s3d_avalanche"; }		// "Diamondback", "s3d_avalanche"
				else if (ScenarioTagName.Contains("s3d_edge"))		{ mapName = "s3d_edge"; }			// "Edge", "s3d_edge"
				else if (ScenarioTagName.Contains("guardian"))		{ mapName = "guardian"; }			// "Guardian", "guardian"
				else if (ScenarioTagName.Contains("deadlock"))		{ mapName = "deadlock"; }			// "High Ground", "deadlock"
				else if (ScenarioTagName.Contains("s3d_turf"))		{ mapName = "s3d_turf"; }			// "Icebox", "s3d_turf"
				else if (ScenarioTagName.Contains("zanzibar"))		{ mapName = "zanzibar"; }			// "Last Resort", "zanzibar"
				else if (ScenarioTagName.Contains("chill"))			{ mapName = "chill"; }				// "Narrows", "chill"
				else if (ScenarioTagName.Contains("s3d_reactor"))	{ mapName = "s3d_reactor"; }		// "Reactor", "s3d_reactor"
				else if (ScenarioTagName.Contains("shrine"))		{ mapName = "shrine"; }				// "Sandtrap", "shrine"
				else if (ScenarioTagName.Contains("bunkerworld"))	{ mapName = "bunkerworld"; }		// "Standoff", "bunkerworld"
				else if (ScenarioTagName.Contains("cyberdyne"))		{ mapName = "cyberdyne"; }			// "The Pit", "cyberdyne"
				else if (ScenarioTagName.Contains("riverworld"))	{ mapName = "riverworld"; }			// "Valhalla", "riverworld"
				else { mapName = $"{ScenarioTagName.Split("/").Last()}"; }                              // Set the specified map name to equal the last string in the scenario tag name (This is only in the event that the scenario does not exist in the base cache)

                // Check if the current cache context is a mod package context
                if (Cache is GameCacheModPackage modCache)
				{
					// Intitially, we assume that the map file is not the mod package, so this gets set to true
					bool isBaseCacheMap = true;

					// Loop through each map file stream in the mod package
                    for (int i = 0; i < modCache.BaseModPackage.MapFileStreams.Count; i++)
                    {
						// Create a new empty map file object
						MapFile mapFileData = new MapFile();

						// Get the current map file stream
						Stream stream = modCache.BaseModPackage.MapFileStreams[i];

                        // Set the stream position to the beginning of the stream
                        stream.Position = 0;

						// Create a new reader instance using the file stream
						EndianReader reader = new EndianReader(stream);

                        // Read the data from the specified map file
                        mapFileData.Read(reader);

                        // Reset the stream position
                        stream.Position = 0;

						// Get the header from the current map file
						CacheFileHeaderGenHaloOnline header = mapFileData.Header as CacheFileHeaderGenHaloOnline;

						// Check if the map file header name equals the specified map name
						if (header.Name == mapName)
						{
							// Update variant placement data
							UpdateVariantPlacements(mapFileData.MapFileBlf);

							// Create a new writer instance using the file stream
							EndianWriter writer = new EndianWriter(stream);

							// Write the modified data to the specified map file
							mapFileData.Write(writer);

							// Reset the stream position
							stream.Position = 0;

							// Since we have found the map file in the mod package, we can set our flag to false
							isBaseCacheMap = false;

							// Break out of the loop, since we have made our map file changes
							break;
						}
					}

					// This should only run if we were unable to find the 
					if (isBaseCacheMap)
					{
						// Create a new stream for our modified map data
						MemoryStream mapStream = new MemoryStream();

						// Define a new file info for the specified map file
						FileInfo file = new FileInfo($@"{modCache.BaseCacheReference.Directory.FullName}\{mapName}.map");

						// Create a new empty map file object
						MapFile mapFileData = new MapFile();

                        // Open a stream to the specified map 
                        using (FileStream fs = file.OpenRead()) 
						{
							// Load the map data into our memory stream
                            fs.CopyTo(mapStream);
                        }

						// Create a new reader instance using the file stream
						EndianReader reader = new EndianReader(mapStream);

                        // Read the data from the specified map file
                        mapFileData.Read(reader);

                        // Update variant placement data
                        UpdateVariantPlacements(mapFileData.MapFileBlf);

                        // Reset the stream position
                        mapStream.Position = 0;

						// Get the header from the current map file
						CacheFileHeaderGenHaloOnline header = mapFileData.Header as CacheFileHeaderGenHaloOnline;

                        // Create a new writer instance using the file stream
                        EndianWriter writer = new EndianWriter(mapStream);

                        // Write the modified data to the specified map file stream
                        mapFileData.Write(writer);

                        // Reset the stream position
                        mapStream.Position = 0;

                        // Add the map file stream to the mod package
                        modCache.AddMapFile(mapStream, header.MapId);
                    }
				}

				// Handle map files in the base cache
				else 
				{
					// Define a new file info for the specified map file
					FileInfo file = new FileInfo($@"{Cache.Directory.FullName}\{mapName}.map");

					// Create a new empty map file object
					MapFile mapFileData = new MapFile();

					// Open a stream to the specified map 
                    using (FileStream stream = file.OpenRead())
                    {
						// Create a new reader instance using the file stream
						EndianReader reader = new EndianReader(stream);

						// Read the data from the specified map file
                        mapFileData.Read(reader);

						// Update variant placement data
                        UpdateVariantPlacements(mapFileData.MapFileBlf);

						// Create a new writer instance using the file stream
						EndianWriter writer = new EndianWriter(stream);

                        // Write the modified data to the specified map file
                        mapFileData.Write(writer);
                    }
                }
            }
			catch (Exception e) 
			{
				Console.WriteLine(e);
				return new TagToolError(CommandError.CustomError, "Failed to Update Scenario Map File Data");
			}

            return true;
        }

		public void UpdateVariantPlacements(Blf blf) 
		{
			// Check if the map blf has a valid map variant
            if (blf.MapVariant != null)
            {
				// The lower index is equal to the current scenario object count minus one
				int lowerIndex = blf.MapVariant.MapVariant.ScenarioObjectCount - 1;
                int upperIndex = 639;

                // Loop through all object placements backwards, so we can get the last placement in the variant.
                // This represents our upper index bounds
                for (int i = 639; i > 0; i--)
                {
                    VariantObjectDatum currentPlacement = blf.MapVariant.MapVariant.Objects[i];

                    // If the current placements flags do not equal none (which is the defult value for this field)
                    if (currentPlacement.Flags != VariantObjectPlacementFlags.None)
                    {
                        // We set the upperIndex to equal the minimum value of the current index and zero
                        upperIndex = Math.Min(i, upperIndex);

                        // Once we have our upper bounds we can now break out of the loop
                        break;
                    }
                }

                // Loop through all placements between our upper index and our lower index
                for (int i = upperIndex; i >= lowerIndex; i--)
                {
                    // Set our target index to equal the current index, plus the number of new objects we add to the scenario
                    int targetIndex = i + NewObjectCount;

                    // if the target index is less than the placement count, we can move the corrresponding placement into  its new index
                    if (targetIndex < blf.MapVariant.MapVariant.Objects.Length)
                    {
                        blf.MapVariant.MapVariant.Objects[targetIndex] = blf.MapVariant.MapVariant.Objects[i];
                    }
                }

                // We then loop back through the placements that were "added" to our array, and reset the data for each placement
                for (int i = blf.MapVariant.MapVariant.ScenarioObjectCount; i < NewObjectCount; i++)
                {
                    VariantObjectDatum currentPlacement = blf.MapVariant.MapVariant.Objects[i];

                    // In this case, we use the data for the closest scenario placement, which in our case is equal to the scenario object count
                    currentPlacement = blf.MapVariant.MapVariant.Objects[blf.MapVariant.MapVariant.ScenarioObjectCount];
                }

                // We can now update the scenario object count for the variant itselfs
                blf.MapVariant.MapVariant.ScenarioObjectCount += NewObjectCount;
            }
        }
    }
}
