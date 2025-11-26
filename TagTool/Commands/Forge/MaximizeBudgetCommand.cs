using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.BlamFile;
using TagTool.BlamFile.Chunks;
using TagTool.BlamFile.Chunks.MapVariants;
using TagTool.BlamFile.Chunks.Metadata;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands.Common;
using TagTool.Tags.Definitions;
using static TagTool.BlamFile.MapVariantGenerator;
using static TagTool.Tags.Definitions.Scenario;

namespace TagTool.Commands.Forge
{
    class MaximizeBudgetCommand : Command
    {
        private readonly GameCacheHaloOnlineBase Cache;
        private readonly ForgeGlobalsDefinition Definition;
        private readonly HashSet<string> ForgePalette;

        public MaximizeBudgetCommand(GameCacheHaloOnlineBase cache, ForgeGlobalsDefinition definition) : base(true,
            "MaximizeBudget",
            "Moves placements for objects that are in the global forge palette into a map variant to maximize the number of objects that can be placed",

            "MaximizeBudget [object-types: {type1,type2,...}>] [scenario-tag]",

            "Moves placements for objects that are in the global forge palette into a map variant to maximize the number of objects that can be placed\n\n" +
            "Use the \"All\" flag to move placements for all objects in the global forge palette, even if they have an invalid category or category index")
        {
            Cache = cache;
            Definition = definition;
            ForgePalette = [.. definition.Palette.Where(x => x.CategoryIndex != -1 && x.Object != null).Select(x => x.Object.ToString())];
        }

        public override object Execute(List<string> args)
        {
            uint objectTypes =
               (1 << (int)GameObjectTypeHalo3ODST.Vehicle) |
               (1 << (int)GameObjectTypeHalo3ODST.Weapon) |
               (1 << (int)GameObjectTypeHalo3ODST.Equipment) |
               (1 << (int)GameObjectTypeHalo3ODST.Scenery) |
               (1 << (int)GameObjectTypeHalo3ODST.Crate) |
               (1 << (int)GameObjectTypeHalo3ODST.Machine) |
               (1 << (int)GameObjectTypeHalo3ODST.Control) |
               (1 << (int)GameObjectTypeHalo3ODST.EffectScenery);

            for (int i = 0; i < args.Count;)
            {
                string arg = args[i].ToLower();
                switch (arg)
                {
                    case "object-types:":
                        {
                            if (!TryParseObjectTypes(args[1], out objectTypes))
                                return new TagToolError(CommandError.ArgInvalid, $"One or more of the specified object types are invalid '{args[1]}'");
                            args.RemoveRange(i, 2);
                        }
                        break;

                    default:
                        i++;
                        break;
                }
            }

            List<CachedTag> scenarioTagList = [];

            if (args.Count > 0)
            {
                if (!Cache.TagCache.TryGetTag(args[0], out CachedTag tag))
                    return new TagToolError(CommandError.TagInvalid, args[0]);

                scenarioTagList.Add(tag);
            }
            else
            {
                foreach (var scnrTag in Cache.TagCache.FindAllInGroup<Scenario>().Cast<CachedTagHaloOnline>())
                {
                    if (scnrTag.IsEmpty() || scnrTag.Name == @"levels\ui\mainmenu\mainmenu")
                        continue;

                    scenarioTagList.Add(scnrTag);
                }
            }

            foreach (CachedTag scenarioTag in scenarioTagList)
            {
                Scenario scenario;
                using (Stream stream = Cache.OpenCacheRead())
                    scenario = Cache.Deserialize<Scenario>(stream, scenarioTag);

                MapFile mapFile = Cache.MapFiles.FindByMapId(scenario.MapId);
                if (mapFile == null)
                    return new TagToolError(CommandError.FileNotFound, $"Could not find map file for '{scenarioTag}'");

                MaximizeMapForgeBudget(scenarioTag, scenario, mapFile, objectTypes);
            }

            return true;
        }

        private void MaximizeMapForgeBudget(CachedTag scenarioTag, Scenario scenario, MapFile mapFile, uint objectTypes)
        {
            Console.WriteLine($"Maximizing budget for scenario '{scenarioTag.Name}'...");

            using (var cacheStream = Cache.OpenCacheReadWrite())
            {
                var metadata = new ContentItemMetadata()
                {
                    Name = mapFile.MapFileBlf.Scenario.Names[0].Name,
                    Description = mapFile.MapFileBlf.Scenario.Descriptions[0].Name,
                    Author = "Bungie",
                    ContentType = ContentItemMetadata.ContentItemType.Usermap,
                    ContentSize = typeof(BlfMapVariant).GetSize(),
                    Timestamp = (ulong)DateTime.Now.ToFileTime(),
                    CampaignId = -1,
                    MapId = scenario.MapId,
                    GameEngineType = 0,
                    CampaignDifficulty = -1,
                    CampaignInsertionPoint = 0,
                    SurvivalEnabled = false,
                    GameId = 0
                };

                var generator = new MapVariantGenerator();
                generator.ObjectTypeMask = objectTypes;

                // Generate a map variant from the current scenario first
                var oldBlf = generator.Generate(cacheStream, Cache, scenario, metadata);
                // Generate a list of placements for objects that are in the forge palette
                var newUserPlacements = GetForgeablePlacements(oldBlf.MapVariant.MapVariant);
                // Perform the culling
                CullForgeObjectsFromScenario(scenario);
                // Regenerate the map variant from the culled scenario
                var blf = generator.Generate(cacheStream, Cache, scenario, metadata);
                // Convert the culled scenario placements to user placements and add them to the new map variant
                ConvertScenarioPlacements(blf.MapVariant.MapVariant, oldBlf.MapVariant.MapVariant.Quotas, newUserPlacements);
                // Update the tag names
                RebuildTagNameChunk(blf);
                // Assign the new blf chunks to the map file
                mapFile.MapFileBlf.MapVariant = blf.MapVariant;
                mapFile.MapFileBlf.ContentFlags |= Blf.BlfFileContentFlags.MapVariant;
                mapFile.MapFileBlf.MapVariantTagNames = blf.MapVariantTagNames;
                mapFile.MapFileBlf.ContentFlags |= Blf.BlfFileContentFlags.MapVariantTagNames;
                // Update the map File
                Cache.MapFiles.Add(mapFile, overwrite: true);

                // Finally serialize the scenario
                Cache.Serialize(cacheStream, scenarioTag, scenario);

                var numCulled = oldBlf.MapVariant.MapVariant.ScenarioObjectCount - blf.MapVariant.MapVariant.ScenarioObjectCount;
                var numAvailable = blf.MapVariant.MapVariant.Objects.Length - blf.MapVariant.MapVariant.ScenarioObjectCount;
                Console.WriteLine($"Culled {numCulled} placements, Available: {numAvailable}");
            }
        }

        private void RebuildTagNameChunk(Blf blf)
        {
            var mapVariant = blf.MapVariant.MapVariant;
            for (int i = 0; i < mapVariant.Quotas.Length; i++)
            {
                if (mapVariant.Quotas[i].ObjectDefinitionIndex == -1)
                    continue;

                var tag = Cache.TagCache.GetTag(mapVariant.Quotas[i].ObjectDefinitionIndex);
                blf.MapVariantTagNames.Names[i] = new BlfMapVariantTagNames.TagName() { Name = $"{tag.Name}.{tag.Group.Tag}" };
            }
        }

        private static void ConvertScenarioPlacements(MapVariant mapVariant, IList<VariantObjectQuota> palette, IList<VariantObjectDatum> placements)
        {
            foreach (var placement in placements)
            {
                var paletteEntry = palette[placement.QuotaIndex];

                var newPaletteIndex = -1;
                for (int i = 0; i < mapVariant.Quotas.Length; i++)
                {
                    if (mapVariant.Quotas[i].ObjectDefinitionIndex == paletteEntry.ObjectDefinitionIndex)
                    {
                        newPaletteIndex = i;
                        break;
                    }
                }

                if (newPaletteIndex == -1)
                {
                    newPaletteIndex = mapVariant.PlaceableQuotaCount;
                    mapVariant.Quotas[mapVariant.PlaceableQuotaCount++] = paletteEntry;
                }

                placement.QuotaIndex = newPaletteIndex;
                placement.Flags = (placement.Flags & ~VariantObjectDatum.VariantObjectPlacementFlags.ScenarioObject) | VariantObjectDatum.VariantObjectPlacementFlags.Edited;
                paletteEntry.PlacedOnMap++;
                paletteEntry.MaximumCount++;
                mapVariant.Objects[mapVariant.VariantObjectCount++] = placement;
            }
        }

        private List<VariantObjectDatum> GetForgeablePlacements(MapVariant mapVariant)
        {
            var newUserPlacements = new List<VariantObjectDatum>();

            for (int i = 0; i < mapVariant.Objects.Length; i++)
            {
                var placement = mapVariant.Objects[i];
                if (!placement.Flags.HasFlag(VariantObjectDatum.VariantObjectPlacementFlags.OccupiedSlot))
                    continue;
                var paletteEntry = mapVariant.Quotas[placement.QuotaIndex];

                if (ForgePalette.Contains(Cache.TagCache.GetTag(paletteEntry.ObjectDefinitionIndex).ToString()))
                    newUserPlacements.Add(placement);
            }

            return newUserPlacements;
        }

        private void CullForgeObjectsFromScenario(Scenario scenario)
        {
            var objectTypes = new Dictionary<GameObjectTypeHalo3ODST, ObjectTypeDefinition>();
            objectTypes.Add(GameObjectTypeHalo3ODST.Biped, new ObjectTypeDefinition(scenario.Bipeds, scenario.BipedPalette));
            objectTypes.Add(GameObjectTypeHalo3ODST.Vehicle, new ObjectTypeDefinition(scenario.Vehicles, scenario.VehiclePalette));
            objectTypes.Add(GameObjectTypeHalo3ODST.Weapon, new ObjectTypeDefinition(scenario.Weapons, scenario.WeaponPalette));
            objectTypes.Add(GameObjectTypeHalo3ODST.Equipment, new ObjectTypeDefinition(scenario.Equipment, scenario.EquipmentPalette));
            objectTypes.Add(GameObjectTypeHalo3ODST.AlternateRealityDevice, new ObjectTypeDefinition(scenario.AlternateRealityDevices, scenario.AlternateRealityDevicePalette));
            objectTypes.Add(GameObjectTypeHalo3ODST.Terminal, new ObjectTypeDefinition(scenario.Terminals, scenario.TerminalPalette));
            objectTypes.Add(GameObjectTypeHalo3ODST.Scenery, new ObjectTypeDefinition(scenario.Scenery, scenario.SceneryPalette));
            objectTypes.Add(GameObjectTypeHalo3ODST.Machine, new ObjectTypeDefinition(scenario.Machines, scenario.MachinePalette));
            objectTypes.Add(GameObjectTypeHalo3ODST.Control, new ObjectTypeDefinition(scenario.Controls, scenario.ControlPalette));
            objectTypes.Add(GameObjectTypeHalo3ODST.SoundScenery, new ObjectTypeDefinition(scenario.SoundScenery, scenario.SoundSceneryPalette));
            objectTypes.Add(GameObjectTypeHalo3ODST.Crate, new ObjectTypeDefinition(scenario.Crates, scenario.CratePalette));
            objectTypes.Add(GameObjectTypeHalo3ODST.Creature, new ObjectTypeDefinition(scenario.Creatures, scenario.CreaturePalette));
            objectTypes.Add(GameObjectTypeHalo3ODST.Giant, new ObjectTypeDefinition(scenario.Giants, scenario.GiantPalette));
            objectTypes.Add(GameObjectTypeHalo3ODST.EffectScenery, new ObjectTypeDefinition(scenario.EffectScenery, scenario.EffectSceneryPalette));

            foreach (var pair in objectTypes)
            {
                var objectType = pair.Key;
                var objectTypeDef = pair.Value;

                var newInstances = new List<ScenarioInstance>();
                var newPalette = new List<ScenarioPaletteEntry>();
                var oldToNewInstanceMapping = new Dictionary<int, int>();

                // Check to see if we have have any placements to process for each object type
                if (objectTypeDef.Instances.Count > 0) 
                {
                    // Generate the new instances block, keeping track of the old to new indices
                    for (int i = 0; i < objectTypeDef.Instances.Count; i++)
                    {
                        var instance = objectTypeDef.Instances[i] as ScenarioInstance;

                        // We can ignore objects that don't have any palette object associated with them. We also only want to leave objects that are not in the forge palette left in the scenario
                        if (instance.PaletteIndex == -1 || ForgePalette.Contains((objectTypeDef.Palette[instance.PaletteIndex] as ScenarioPaletteEntry).Object.ToString()))
                        {
                            // If the ignored placement has a valid object name index, update the corresponding object name block accordingly
                            if (instance.NameIndex != -1)
                            {
                                // We set the data to use default values as the corresponding placement no longer exists
                                scenario.ObjectNames[instance.NameIndex].ObjectType.Halo3ODST = GameObjectTypeHalo3ODST.None;
                                scenario.ObjectNames[instance.NameIndex].PlacementIndex = -1;
                            }

                            continue;
                        }

                        var paletteEntry = objectTypeDef.Palette[instance.PaletteIndex] as ScenarioPaletteEntry;

                        // try to find an existing palette entry, if not add one to the new palette block and use that index
                        var paletteIndex = newPalette.IndexOf(paletteEntry);
                        if (paletteIndex == -1)
                        {
                            paletteIndex = newPalette.Count;
                            newPalette.Add(paletteEntry);
                        }

                        // if the instance contains a valid name index, update the placement index for the corresponding object name block
                        if (instance.NameIndex != -1)
                        {
                            scenario.ObjectNames[instance.NameIndex].PlacementIndex = (short)newInstances.Count;
                        }

                        instance.PaletteIndex = (short)paletteIndex;

                        oldToNewInstanceMapping[i] = newInstances.Count;
                        newInstances.Add(instance);
                    }

                    if (pair.Key == GameObjectTypeHalo3ODST.Creature)
                    {
                        foreach (var flock in scenario.Flocks)
                        {
                            if (flock.CreaturePaletteIndex == -1) continue;
    
                            var paletteEntry = scenario.CreaturePalette[flock.CreaturePaletteIndex];
                            var paletteIndex = newPalette.IndexOf(paletteEntry);
                            if (paletteIndex == -1)
                            {
                                paletteIndex = newPalette.Count;
                                newPalette.Add(paletteEntry);
                            }
                            flock.CreaturePaletteIndex = (short)paletteIndex;
                        }
                    }

                    // Assign the new instances block
                    objectTypeDef.Instances.Clear();
                    foreach (var instance in newInstances)
                        objectTypeDef.Instances.Add(instance);

                    // Assign the new palette block
                    objectTypeDef.Palette.Clear();
                    foreach (var entry in newPalette)
                        objectTypeDef.Palette.Add(entry);
                }
            }

            // Clear out legacy sandbox palettes
            scenario.SandboxEquipment = new List<SandboxObject>();
            scenario.SandboxVehicles = new List<SandboxObject>();
            scenario.SandboxEquipment = new List<SandboxObject>();
            scenario.SandboxGoalObjects = new List<SandboxObject>();
            scenario.SandboxScenery = new List<SandboxObject>();
            scenario.SandboxTeleporters = new List<SandboxObject>();
            scenario.SandboxSpawning = new List<SandboxObject>();
            scenario.SandboxWeapons = new List<SandboxObject>();
        }

        private static bool TryParseObjectTypes(string types, out uint mask)
        {
            mask = 0u;
            foreach (string type in types.Split(','))
            {
                if (!Enum.TryParse<ObjectTypeFlagsHalo3ODST>(type, ignoreCase: true, out var value) || !Enum.IsDefined(value))
                    return false;

                mask |= 1u << (int)value;
            }
            return true;
        }
    }
}
