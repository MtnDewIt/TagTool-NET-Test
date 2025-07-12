using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagTool.Cache.Gen3;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags.Definitions;

namespace TagTool.Porting.Gen3
{
    public partial class PortingContextGen3
    {
        private void PreConvertReachDefinition(Stream cacheStream, Stream blamCacheStream, object definition)
        {
            if (definition is Scenario scnr)
            {
                var lightmap = BlamCache.Deserialize<ScenarioLightmap>(blamCacheStream, scnr.Lightmap);
                ConvertReachLightmap(cacheStream, blamCacheStream, scnr.Lightmap.Name, lightmap);
            }

            if (definition is ScenarioStructureBsp sbsp)
            {
                if (!Options.ReachDecorators)
                {
                    sbsp.Decorators.Clear();
                    foreach (var cluster in sbsp.Clusters)
                        cluster.DecoratorGrids.Clear();
                }

                foreach (var cluster in sbsp.Clusters)
                {
                    cluster.RuntimeDecalCount = 0;
                    cluster.RuntimeDecalStartIndex = -1;
                }
            }

            if (definition is AreaScreenEffect sefc)
            {
                foreach (var screenEffect in sefc.ScreenEffects)
                    screenEffect.ContrastEnhance = 0;
            }

            if (definition is Scenario scenario)
            {
                scenario.Bipeds.Clear();
                scenario.BipedPalette.Clear();
                //scenario.Vehicles.Clear();
                //scenario.VehiclePalette.Clear();
                //scenario.Weapons.Clear();
                //scenario.WeaponPalette.Clear();
                //scenario.Equipment.Clear();
                //scenario.EquipmentPalette.Clear();
                //scenario.Scenery.Clear();
                //scenario.SceneryPalette.Clear();
                scenario.Terminals.Clear();
                scenario.TerminalPalette.Clear();
                //scenario.Machines.Clear();
                //scenario.MachinePalette.Clear();
                //scenario.Controls.Clear();
                //scenario.ControlPalette.Clear();
                //scenario.Crates.Clear();
                //scenario.CratePalette.Clear();
                scenario.Giants.Clear();
                scenario.GiantPalette.Clear();
                //scenario.EffectScenery.Clear();
                //scenario.EffectSceneryPalette.Clear();
                //scenario.SoundScenery.Clear();
                //scenario.SoundSceneryPalette.Clear();

                foreach (var ssceInstance in scenario.SoundScenery)
                {
                    ssceInstance.OverrideDistance = new Bounds<float>
                    {
                        Lower = ssceInstance.DistanceParameters.DontPlayDistance,
                        Upper = ssceInstance.DistanceParameters.MaximumDistance
                    };
                }

                scenario.Flocks.Clear();
                scenario.FlockPalette.Clear();
                scenario.Creatures.Clear();
                scenario.CreaturePalette.Clear();

                //scenario.LightVolumes.Clear();
                //scenario.LightVolumePalette.Clear();
                //scenario.DecalPalette.Clear();
                //scenario.Decals.Clear();

                scenario.Squads.Clear();
                scenario.SquadPatrols.Clear();
                scenario.SquadGroups.Clear();
                scenario.AiObjectives.Clear();
                scenario.AiUserHintData.Clear();
                scenario.Scripts.Clear();
                scenario.ScriptStrings = null;

                scenario.CharacterPalette.Clear();
                scenario.UnitSeatsMapping.Clear();
                scenario.MissionScenes.Clear();

                scenario.SkyParameters = null; // unused in reach, we will create a new one
                scenario.PerformanceThrottles = null;
                scenario.GamePerformanceThrottles = null;

                //scenario.ScenarioKillTriggers.Clear();
                scenario.ScenarioSafeTriggers.Clear();

                scenario.PlayerStartingProfile = new List<Scenario.PlayerStartingProfileBlock>() {
                    new Scenario.PlayerStartingProfileBlock() {
                        Name = "start_assault",
                        PrimaryWeapon = CacheContext.TagCache.GetTag(@"objects\weapons\rifle\assault_rifle\assault_rifle", "weap"),
                        PrimaryRoundsLoaded = 32,
                        PrimaryRoundsTotal = 108,
                        StartingFragGrenadeCount = 2
                    }
                };

                Dictionary<string, string> reachObjectives = new Dictionary<string, string>()
                {
                    {"objects\\multi\\models\\mp_hill_beacon\\mp_hill_beacon", "objects\\multi\\koth\\koth_hill_static"},
                    {"objects\\multi\\models\\mp_flag_base\\mp_flag_base", "objects\\multi\\ctf\\ctf_flag_return_area"},
                    {"objects\\multi\\models\\mp_circle\\mp_circle", "objects\\multi\\oddball\\oddball_ball_spawn_point"},
                    {"objects\\multi\\archive\\vip\\vip_boundary", "objects\\multi\\vip\\vip_destination_static"},
                    {"objects\\multi\\spawning\\respawn_zone","objects\\multi\\slayer\\slayer_respawn_zone"},
                    {"objects\\multi\\spawning\\initial_spawn_point","objects\\multi\\slayer\\slayer_initial_spawn_point"}
                };

                Dictionary<string, string> reachVehicles = new Dictionary<string, string>()
                {
                    {"objects\\vehicles\\human\\warthog\\warthog", "objects\\vehicles\\warthog\\warthog"},
                    {"objects\\vehicles\\human\\mongoose\\mongoose", "objects\\vehicles\\mongoose\\mongoose"},
                    {"objects\\vehicles\\human\\scorpion\\scorpion", "objects\\vehicles\\scorpion\\scorpion"},
                    {"objects\\vehicles\\human\\falcon\\falcon", "objects\\vehicles\\hornet\\hornet"},
                    {"objects\\vehicles\\covenant\\ghost\\ghost", "objects\\vehicles\\ghost\\ghost"},
                    {"objects\\vehicles\\covenant\\wraith\\wraith", "objects\\vehicles\\wraith\\wraith"},
                    {"objects\\vehicles\\covenant\\banshee\\banshee", "objects\\vehicles\\banshee\\banshee"},
                    {"objects\\vehicles\\human\\turrets\\machinegun\\machinegun", "objects\\weapons\\turret\\machinegun_turret\\machinegun_turret"},
                    {"objects\\vehicles\\covenant\\turrets\\plasma_turret\\plasma_turret_mounted", "objects\\weapons\\turret\\plasma_cannon\\plasma_cannon"},
                    {"objects\\vehicles\\covenant\\turrets\\shade\\shade", "objects\\vehicles\\shade\\shade"}
                };

                Dictionary<string, string> reachEquipment = new Dictionary<string, string>()
                {
                    {"objects\\equipment\\hologram\\hologram", "objects\\equipment\\hologram_equipment\\hologram_equipment"},
                    {"objects\\equipment\\active_camouflage\\active_camouflage", "objects\\equipment\\invisibility_equipment\\invisibility_equipment"}
                };

                Dictionary<string, string> reachWeapons = new Dictionary<string, string>()
                {
                    {"objects\\weapons\\melee\\energy_sword\\energy_sword", "objects\\weapons\\melee\\energy_blade\\energy_blade"}
                };

                ReplaceObjects(scenario.SceneryPalette, reachObjectives);
                ReplaceObjects(scenario.CratePalette, reachObjectives);
                ReplaceObjects(scenario.VehiclePalette, reachVehicles);
                ReplaceObjects(scenario.EquipmentPalette, reachEquipment);
                ReplaceObjects(scenario.WeaponPalette, reachWeapons);

                foreach (var entry in scenario.Weapons)
                {
                    if (entry.Multiplayer.MegaloLabel == "inv_weapon")
                        entry.PaletteIndex = -1;
                }

                foreach (var entry in scenario.Vehicles)
                {
                    if (entry.Multiplayer.MegaloLabel == "inv_vehicle")
                        entry.PaletteIndex = -1;
                }

                CullNewObjects(scenario.VehiclePalette, scenario.Vehicles, reachObjectives);
                CullNewObjects(scenario.WeaponPalette, scenario.Weapons, reachObjectives);
                CullNewObjects(scenario.EquipmentPalette, scenario.Equipment, reachObjectives);

                RemoveNullPlacements(scenario.SceneryPalette, scenario.Scenery);
                RemoveNullPlacements(scenario.CratePalette, scenario.Crates);

                // remove unsupported healthpack controls
                if (BlamCache.TagCache.TryGetCachedTag("objects\\levels\\shared\\device_controls\\health_station\\health_station.ctrl", out CachedTag healthCtrl))
                {
                    short index = (short)scenario.ControlPalette.FindIndex(e => e.Object == healthCtrl);
                    if (index != -1)
                        scenario.ControlPalette[index].Object = null;

                    RemoveNullPlacements(scenario.ControlPalette, scenario.Controls);
                }
            }

            //if (definition is SkyAtmParameters skya)
            //{
            //    foreach (SkyAtmParameters.AtmosphereProperty atmProperty in skya.AtmosphereProperties)
            //    {
            //        atmProperty.Name = ConvertStringId(atmProperty.ReachName);
            //        atmProperty.FogColor = atmProperty.FogColorReach;
            //        atmProperty.UnknownFlags = 0;
            //        atmProperty.FogIntensityCyan = 1;
            //        atmProperty.FogIntensityMagenta = 1;
            //        atmProperty.FogIntensityYellow = 1;
            //    }
            //}

            if (definition is Model hlmt)
            {
                foreach (var variant in hlmt.Variants)
                    foreach (var item in variant.Objects)
                        if (item.ChildObject != null)
                            switch ((item.ChildObject.Group as TagGroupGen3).Name)
                            {
                                case "weapon":
                                case "equipment":
                                case "vehicle":
                                    item.ChildObject = null;
                                    break;
                            }

                if (hlmt.NewDamageInfo == null || hlmt.NewDamageInfo.Count == 0)
                    hlmt.NewDamageInfo = new List<Model.GlobalDamageInfoBlock>() { ConvertDamageInfoReach(hlmt.OmahaDamageInfo) };
            }

            if (definition is GameObject obj)
            {
                foreach (var block in obj.MultiplayerObject)
                    if (block.SpawnedObject != null)
                        switch ((block.SpawnedObject.Group as TagGroupGen3).Name)
                        {
                            case "weapon":
                            case "equipment":
                            case "vehicle":
                                block.SpawnedObject = null;
                                break;
                        }
            }

            if (definition is Effect effe)
            {
                foreach (var block in effe.Events)
                    foreach (var part in block.Parts)
                    {
                        string name = ((TagGroupGen3)part.Type.Group).Name;

                        if (name == "cheap_particle_emitter")
                            part.Type = null;
                        if (name == "decal_system")
                            part.Type = null;
                    }
            }

            if (definition is Equipment eqip)
            {
                eqip.Duration = 5;
                eqip.Charges = 1;
                Enum.TryParse(eqip.EquipmentFlagsReach.ToString(), out eqip.EquipmentFlags);

                if (eqip.EquipmentFlagsReach.HasFlag(Equipment.EquipmentFlagBitsReach.ThirdPersonCameraWhileActive))
                    eqip.EquipmentFlags |= Equipment.EquipmentFlagBits.ThirdPersonCameraAlways;
            }

            if (definition is Projectile proj)
            {
                // merge old and new material response lists
                var newMaterials = new List<Projectile.ProjectileMaterialResponseBlock>();
                var converter = new StructureAutoConverter(BlamCache, CacheContext);
                converter.TranslateList(proj.MaterialResponsesNew, newMaterials);

                if (proj.MaterialResponses != null && proj.MaterialResponses.Count > 0)
                    proj.MaterialResponses.AddRange(newMaterials);
                else
                    proj.MaterialResponses = newMaterials;

                // some reach old materials have mismatched names and indices
                var reachGlobals = TagDefinitionCache.Deserialize<Globals>(BlamCache, blamCacheStream, BlamCache.TagCache.FindFirstInGroup<Globals>());
                var reachMaterials = reachGlobals.AlternateMaterials;
                foreach (var response in proj.MaterialResponses)
                {
                    if (response.RuntimeMaterialIndex < 0 || response.RuntimeMaterialIndex >= reachMaterials.Count)
                        response.RuntimeMaterialIndex = -1;
                    else if (reachMaterials[response.RuntimeMaterialIndex].Name != response.MaterialName)
                        response.RuntimeMaterialIndex = (short)reachMaterials.FindIndex(m => m.Name == response.MaterialName);
                }

                // preconvert projectile flags
                converter.TranslateEnum(proj.FlagsReach, out proj.Flags, proj.Flags.GetType());

                // handle required flags Reach doesn't have
                if (proj.SuperDetonationProjectileCount > 0)
                    proj.Flags |= Projectile.ProjectileFlags.HasSuperCombiningExplosion;

                if (proj.ConicalSpread.Any())
                    proj.Flags |= Projectile.ProjectileFlags.TravelsInstantaneously;
            }
        }

        public void CullNewObjects<T>(List<Scenario.ScenarioPaletteEntry> palette, List<T> instanceList, Dictionary<string, string> replacements)
        {
            if (palette.Count() > 0)
            {
                foreach (Scenario.ScenarioPaletteEntry block in palette)
                    if (block.Object != null && !CacheContext.TagCache.TryGetTag($"{block.Object.Name}.{block.Object.Group}", out _))
                        block.Object = null;

                RemoveNullPlacements(palette, instanceList);
            }
        }

        public void ReplaceObjects(List<Scenario.ScenarioPaletteEntry> palette, Dictionary<string, string> replacements)
        {
            foreach (var block in palette)
            {
                if (block.Object != null)
                {
                    string name = block.Object.Name;
                    if (replacements.TryGetValue(name, out string result))
                        block.Object.Name = result;

                    if (name.Contains("spawning\\fireteam"))
                        block.Object = null;

                    switch (name)
                    {
                        case "objects\\multi\\boundaries\\soft_kill_volume":
                            BlamCache.TagCache.TryGetCachedTag("objects\\multi\\boundaries\\kill_volume.scen", out block.Object);
                            break;
                        case "objects\\multi\\boundaries\\safe_volume":
                        case "objects\\multi\\boundaries\\soft_safe_volume":
                        case "objects\\multi\\named_location_area\\named_location_area":
                        case "objects\\multi\\spawning\\danger_zone":
                            block.Object = null;
                            break;
                    }
                }
            }
        }

        public void RemoveNullPlacements<T>(List<Scenario.ScenarioPaletteEntry> palette, List<T> instanceList)
        {
            if (palette.Count() > 0)
            {
                List<int> indices = new List<int>();

                for (int i = 0; i < instanceList.Count; i++)
                {
                    var paletteIndex = (instanceList[i] as Scenario.ScenarioInstance).PaletteIndex;
                    if (paletteIndex == -1 || palette[paletteIndex].Object == null)
                        indices.Add(i);
                }


                indices.Sort();
                indices.Reverse();
                for (int i = 0; i < indices.Count; i++)
                    instanceList.RemoveAt(indices[i]);
            }
        }

        private static object ConvertDecoratorSetReach(DecoratorSet decoratorSet)
        {
            switch (decoratorSet.RenderShaderReach)
            {
                case DecoratorSet.DecoratorShaderReach.BillboardWindDynamicLights:
                    decoratorSet.RenderShader = DecoratorSet.DecoratorShader.WindDynamicLights; // default
                    break;
                case DecoratorSet.DecoratorShaderReach.BillboardDynamicLights:
                    decoratorSet.RenderShader = DecoratorSet.DecoratorShader.StillDynamicLights; // no_wind
                    break;
                case DecoratorSet.DecoratorShaderReach.SolidMeshDynamicLights:
                    decoratorSet.RenderShader = DecoratorSet.DecoratorShader.StillDynamicLights; // no_wind
                    break;
                case DecoratorSet.DecoratorShaderReach.SolidMesh:
                    decoratorSet.RenderShader = DecoratorSet.DecoratorShader.StillSunLightOnly; // sun
                    break;
                case DecoratorSet.DecoratorShaderReach.UnderwaterDynamicLights:
                    decoratorSet.RenderShader = DecoratorSet.DecoratorShader.WavyDynamicLights; // wavy
                    break;
                case DecoratorSet.DecoratorShaderReach.VolumetricBillboardDynamicLights:
                    decoratorSet.RenderShader = DecoratorSet.DecoratorShader.ShadedDynamicLights; //shaded
                    break;
                case DecoratorSet.DecoratorShaderReach.VolumetricBillboardWindDynamicLights:
                    decoratorSet.RenderShader = DecoratorSet.DecoratorShader.WindDynamicLights; // unsupported: default + shaded
                    break;
            }

            int lodIndex = decoratorSet.LodSettings.MaxValidLod;
            decoratorSet.LodSettings.StartFade = decoratorSet.LodSettings.TransitionsReach[lodIndex].StartPoint;
            decoratorSet.LodSettings.EndFade = decoratorSet.LodSettings.TransitionsReach[lodIndex].EndPoint;
            return decoratorSet;
        }
    }
}
