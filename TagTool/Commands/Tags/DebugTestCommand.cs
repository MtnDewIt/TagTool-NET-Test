using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile.Chunks.MapVariants;
using TagTool.Cache;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Tags
{
    class DebugTestCommand : Command
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnlineBase CacheContext { get; set; }
        public CommandContextStack ContextStack { get; set; }

        public DebugTestCommand(GameCache cache, GameCacheHaloOnlineBase cacheContext, CommandContextStack contextStack) : base
        (
            false,
            "DebugTest",
            "Self Explanatory",

            "DebugTest",
            "Self Explanatory"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            ContextStack = contextStack;
        }

        public override object Execute(List<string> args)
        {
            string output = args[0];

            if (Cache.Version >= CacheVersion.Halo3Retail && Cache.Platform == CachePlatform.MCC)
            {
                Dictionary<(VariantObjectQuota.MapVariantQuotaPalette, short), string> tagTable = [];

                using (Stream stream = Cache.OpenCacheRead()) 
                {
                    CachedTag scnrTag = Cache.TagCache.FindFirstInGroup<Scenario>();
                    Scenario scnr = Cache.Deserialize<Scenario>(stream, scnrTag);

                    for (int i = 0; i < scnr.SandboxVehicles.Count; i++) 
                    {
                        if (scnr.SandboxVehicles[i].Object != null) 
                        {
                            string tagName = $"{scnr.SandboxVehicles[i].Object.Name}.{scnr.SandboxVehicles[i].Object.Group.Tag}";

                            tagTable.Add((VariantObjectQuota.MapVariantQuotaPalette.Vehicle, (short)i), tagName);
                        }
                    }

                    for (int i = 0; i < scnr.SandboxWeapons.Count; i++) 
                    {
                        if (scnr.SandboxWeapons[i].Object != null)
                        {
                            string tagName = $"{scnr.SandboxWeapons[i].Object.Name}.{scnr.SandboxWeapons[i].Object.Group.Tag}";

                            tagTable.Add((VariantObjectQuota.MapVariantQuotaPalette.Weapon, (short)i), tagName);
                        }
                    }

                    for (int i = 0; i < scnr.SandboxEquipment.Count; i++) 
                    {
                        if (scnr.SandboxEquipment[i].Object != null)
                        {
                            string tagName = $"{scnr.SandboxEquipment[i].Object.Name}.{scnr.SandboxEquipment[i].Object.Group.Tag}";

                            tagTable.Add((VariantObjectQuota.MapVariantQuotaPalette.Equipment, (short)i), tagName);
                        }
                    }

                    for (int i = 0; i < scnr.SandboxScenery.Count; i++) 
                    {
                        if (scnr.SandboxScenery[i].Object != null)
                        {
                            string tagName = $"{scnr.SandboxScenery[i].Object.Name}.{scnr.SandboxScenery[i].Object.Group.Tag}";

                            tagTable.Add((VariantObjectQuota.MapVariantQuotaPalette.Scenery, (short)i), tagName);
                        }
                    }

                    for (int i = 0; i < scnr.SandboxTeleporters.Count; i++) 
                    {
                        if (scnr.SandboxTeleporters[i].Object != null)
                        {
                            string tagName = $"{scnr.SandboxTeleporters[i].Object.Name}.{scnr.SandboxTeleporters[i].Object.Group.Tag}";

                            tagTable.Add((VariantObjectQuota.MapVariantQuotaPalette.Teleporter, (short)i), tagName);
                        }
                    }

                    for (int i = 0; i < scnr.SandboxGoalObjects.Count; i++) 
                    {
                        if (scnr.SandboxGoalObjects[i].Object != null)
                        {
                            string tagName = $"{scnr.SandboxGoalObjects[i].Object.Name}.{scnr.SandboxGoalObjects[i].Object.Group.Tag}";

                            tagTable.Add((VariantObjectQuota.MapVariantQuotaPalette.Goal, (short)i), tagName);
                        }
                    }

                    for (int i = 0; i < scnr.SandboxSpawning.Count; i++) 
                    {
                        if (scnr.SandboxSpawning[i].Object != null)
                        {
                            string tagName = $"{scnr.SandboxSpawning[i].Object.Name}.{scnr.SandboxSpawning[i].Object.Group.Tag}";

                            tagTable.Add((VariantObjectQuota.MapVariantQuotaPalette.SpawnObjects, (short)i), tagName);
                        }
                    }

                    for (int i = 0; i < scnr.SceneryPalette.Count; i++) 
                    {
                        if (scnr.SceneryPalette[i].Object != null)
                        {
                            string tagName = $"{scnr.SceneryPalette[i].Object.Name}.{scnr.SceneryPalette[i].Object.Group.Tag}";

                            tagTable.Add((VariantObjectQuota.MapVariantQuotaPalette.SceneryRuntime, (short)i), tagName);
                        }
                    }

                    for (int i = 0; i < scnr.VehiclePalette.Count; i++) 
                    {
                        if (scnr.VehiclePalette[i].Object != null)
                        {
                            string tagName = $"{scnr.VehiclePalette[i].Object.Name}.{scnr.VehiclePalette[i].Object.Group.Tag}";
                    
                            tagTable.Add((VariantObjectQuota.MapVariantQuotaPalette.VehicleRuntime, (short)i), tagName);
                        }
                    }

                    for (int i = 0; i < scnr.WeaponPalette.Count; i++) 
                    {
                        if (scnr.WeaponPalette[i].Object != null)
                        {
                            string tagName = $"{scnr.WeaponPalette[i].Object.Name}.{scnr.WeaponPalette[i].Object.Group.Tag}";

                            tagTable.Add((VariantObjectQuota.MapVariantQuotaPalette.WeaponRuntime, (short)i), tagName);
                        }
                    }

                    for (int i = 0; i < scnr.EquipmentPalette.Count; i++)
                    {
                        if (scnr.EquipmentPalette[i].Object != null)
                        {
                            string tagName = $"{scnr.EquipmentPalette[i].Object.Name}.{scnr.EquipmentPalette[i].Object.Group.Tag}";

                            tagTable.Add((VariantObjectQuota.MapVariantQuotaPalette.EquipmentRuntime, (short)i), tagName);
                        }
                    }

                    for (int i = 0; i < scnr.CratePalette.Count; i++) 
                    {
                        if (scnr.CratePalette[i].Object != null)
                        {
                            string tagName = $"{scnr.CratePalette[i].Object.Name}.{scnr.CratePalette[i].Object.Group.Tag}";

                            tagTable.Add((VariantObjectQuota.MapVariantQuotaPalette.Crate, (short)i), tagName);
                        }
                    }
                }

                string mapName = Cache.DisplayName.Replace(".map", string.Empty);
                FileInfo fileInfo = new FileInfo($"{output}\\{mapName}_mappings.json");

                if (!Directory.Exists(fileInfo.DirectoryName))
                {
                    Directory.CreateDirectory(fileInfo.DirectoryName);
                }

                File.WriteAllText(fileInfo.FullName, JsonConvert.SerializeObject(tagTable, Formatting.Indented));
            }
            else 
            {
                Dictionary<int, string> tagTable = [];

                foreach (var tag in Cache.TagCache.TagTable)
                {
                    tagTable.Add((int)tag.ID, $"{tag.Name}.{tag.Group.Tag}");
                }

                string mapName = Cache.DisplayName.Replace(".map", string.Empty);
                FileInfo fileInfo = new FileInfo($"{output}\\{mapName}_mappings.json");

                if (!Directory.Exists(fileInfo.DirectoryName))
                {
                    Directory.CreateDirectory(fileInfo.DirectoryName);
                }

                File.WriteAllText(fileInfo.FullName, JsonConvert.SerializeObject(tagTable, Formatting.Indented));
            }

            return true;
        }
    }
}