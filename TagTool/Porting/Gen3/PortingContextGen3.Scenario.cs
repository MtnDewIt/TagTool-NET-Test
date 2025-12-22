using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.IO;
using TagTool.Scripting;
using TagTool.Tags.Definitions;
using TagTool.Tags.Definitions.Common;
using TagTool.Tags.Resources;
using TagTool.Geometry;
using TagTool.BlamFile;
using TagTool.Commands.ScenarioStructureBSPs;
using TagTool.Common.Logging;
using TagTool.Shaders;
using TagTool.Cache.HaloOnline;

namespace TagTool.Porting.Gen3
{
    partial class PortingContextGen3
    {
        private Scenario CurrentScenario = null;

        private static readonly byte[] DefaultScenarioFxFunction = new byte[] { 0x01, 0x34, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        public Scenario ConvertScenario(Stream cacheStream, Stream blamCacheStream, Scenario scnr, string tagName)
        {
            CurrentScenario = scnr;

            if (scnr.MapId == 0)
                scnr.MapId = GenerateScenarioMapId(cacheStream);

            if (CacheVersionDetection.GetGameTitle(BlamCache.Version) == GameTitle.Halo3)
                scnr.Flags |= ScenarioFlags.H3Compatibility;

            if (BlamCache.Version >= CacheVersion.HaloReach)
            {
                foreach (var block in scnr.StructureBsps)
                {
                    block.Flags = block.FlagsReach.ConvertLexical<Scenario.StructureBspBlock.StructureBspFlags>();
                }

                // remove unsupported healthpack controls
                if (CacheContext.TagCache.TryGetCachedTag("objects\\levels\\shared\\device_controls\\health_station\\health_station.ctrl", out CachedTag healthCtrl))
                {
                    var paletteIndex = (short)scnr.ControlPalette.FindIndex(e => e.Object == healthCtrl);

                    // substitute with health pack equipment
                    if (CacheContext.TagCache.TryGetCachedTag("objects\\powerups\\health_pack\\health_pack_large.eqip", out CachedTag healthEqip))
                    {
                        scnr.EquipmentPalette.Add(new Scenario.ScenarioPaletteEntry()
                        {
                            Object = healthEqip
                        });

                        var eqipPaletteIndex = (short)(scnr.EquipmentPalette.Count - 1);

                        foreach (var controlInstance in scnr.Controls)
                        {
                            if (controlInstance.PaletteIndex == paletteIndex)
                            {
                                scnr.Equipment.Add(new Scenario.EquipmentInstance()
                                {
                                    PaletteIndex = eqipPaletteIndex,
                                    NameIndex = controlInstance.NameIndex,
                                    PlacementFlags = controlInstance.PlacementFlags,
                                    Position = controlInstance.Position,
                                    Rotation = controlInstance.Rotation,
                                    Scale = controlInstance.Scale,
                                    NodeOrientations = controlInstance.NodeOrientations,
                                    TransformFlags = controlInstance.TransformFlags,
                                    ManualBspFlags = controlInstance.ManualBspFlags,
                                    LightAirprobeName = controlInstance.LightAirprobeName,
                                    ObjectId = new ObjectIdentifier
                                    {
                                        UniqueId = controlInstance.ObjectId.UniqueId,
                                        OriginBspIndex = controlInstance.ObjectId.OriginBspIndex,
                                        Type = new GameObjectType8() { Halo3ODST = GameObjectTypeHalo3ODST.Equipment },
                                        Source = controlInstance.ObjectId.Source,
                                    },
                                    BspPolicy = controlInstance.BspPolicy,
                                    EditingBoundToBsp = controlInstance.EditingBoundToBsp,
                                    EditorFolder = controlInstance.EditorFolder,
                                    ParentId = controlInstance.ParentId,
                                    CanAttachToBspFlags = controlInstance.CanAttachToBspFlags,
                                    Multiplayer = controlInstance.Multiplayer,
                                });
                            }

                            if (controlInstance.NameIndex != -1)
                                scnr.ObjectNames[controlInstance.NameIndex].ObjectType = new GameObjectType16() { Halo3ODST = GameObjectTypeHalo3ODST.Equipment };
                        }
                    }

                    if (paletteIndex != -1)
                        scnr.ControlPalette[paletteIndex].Object = null;

                    RemoveNullPlacements(scnr.ControlPalette, scnr.Controls);
                }
            }

            foreach (var zoneset in scnr.ZoneSets)
            {
                // cex_ff_halo references bsps that don't exist, remove them
                zoneset.Bsps &= (Scenario.BspFlags)(scnr.StructureBsps.Count >= 32 ? uint.MaxValue : ~(-1u << scnr.StructureBsps.Count));
                if (scnr.BspAtlas == null || scnr.BspAtlas.Count == 0)
                    zoneset.HintPreviousZoneSet = -1;
            }
               

            //
            // Halo 3 scenario ai data
            //

            if (BlamCache.Version == CacheVersion.Halo3Retail && FlagIsSet(PortingFlags.Recursive))
            {
                var pathfindingBsps = new List<StructureBspCacheFileTagResources>();

                Console.Write("Loading pathfinding bsps: ");

                for (var bspIndex = 0; bspIndex < scnr.StructureBsps.Count; bspIndex++)
                {
                    Console.Write($"{bspIndex}, ");

                    var sbsp = CacheContext.Deserialize<ScenarioStructureBsp>(cacheStream, scnr.StructureBsps[bspIndex].StructureBsp);

                    StructureBspCacheFileTagResources pathfindingBsp = null;

                    if (sbsp.PathfindingResource != null)
                    {
                        pathfindingBsp = CacheContext.ResourceCache.GetStructureBspCacheFileTagResources(sbsp.PathfindingResource);
                    }
                    pathfindingBsps.Add(pathfindingBsp);
                }

                Console.WriteLine("done.");

                foreach (var squad in scnr.Squads)
                {
                    squad.EditorFolderIndex = squad.EditorFolderIndexH3;
                    squad.SpawnFormations = new List<Scenario.Squad.SpawnFormation>();
                    squad.SpawnPoints = new List<Scenario.Squad.SpawnPoint>();
                    squad.SquadTemplate = null;
                    squad.TemplatedFireteams = new List<Scenario.Squad.Fireteam>();
                    squad.DesignerFireteams = new List<Scenario.Squad.Fireteam>();

                    for (var i = 0; i < squad.Fireteams.Count; i++)
                    {
                        var fireteam = squad.Fireteams[i];

                        fireteam.Name = StringId.Empty;

                        if (fireteam.CharacterTypeIndex != -1)
                        {
                            fireteam.CharacterType = new List<Scenario.Squad.Fireteam.CharacterTypeBlock>
                            {
                                new Scenario.Squad.Fireteam.CharacterTypeBlock
                                {
                                    CharacterTypeIndex = fireteam.CharacterTypeIndex,
                                    Chance = 1
                                }
                            };

                            //
                            // Determine if the character is a giant to enable zone flags
                            //

                            if (squad.InitialZoneIndex != -1)
                            {
                                var unitIndex = -1;
                                var entry = scnr.CharacterPalette[fireteam.CharacterTypeIndex];

                                if (entry.Instance != null)
                                {
                                    using (var reader = new EndianReader(cacheStream, true))
                                    {
                                        cacheStream.Position = entry.Instance.DefinitionOffset + entry.Instance.DefinitionOffset + 32;
                                        unitIndex = reader.ReadInt32();
                                    }
                                }

                                if (unitIndex != -1 && (CacheContext.TagCache.GetTag(unitIndex)?.IsInGroup("gint") ?? false))
                                    scnr.Zones[squad.InitialZoneIndex].FlagsNew |= Scenario.Zone.ZoneFlagsNew.GiantsZone;
                            }
                        }

                        if (fireteam.InitialPrimaryWeaponIndex != -1)
                        {
                            fireteam.InitialPrimaryWeapon = new List<Scenario.Squad.Fireteam.ItemTypeBlock>
                            {
                                new Scenario.Squad.Fireteam.ItemTypeBlock
                                {
                                    ItemTypeIndex = fireteam.InitialPrimaryWeaponIndex,
                                    Probability = 1
                                }
                            };
                        }

                        if (fireteam.InitialSecondaryWeaponIndex != -1)
                        {
                            fireteam.InitialSecondaryWeapon = new List<Scenario.Squad.Fireteam.ItemTypeBlock>
                            {
                                new Scenario.Squad.Fireteam.ItemTypeBlock
                                {
                                    ItemTypeIndex = fireteam.InitialSecondaryWeaponIndex,
                                    Probability = 1
                                }
                            };
                        }

                        if (fireteam.InitialEquipmentIndex != -1)
                        {
                            fireteam.InitialEquipment = new List<Scenario.Squad.Fireteam.ItemTypeBlock>
                            {
                                new Scenario.Squad.Fireteam.ItemTypeBlock
                                {
                                    ItemTypeIndex = fireteam.InitialEquipmentIndex,
                                    Probability = 1
                                }
                            };
                        }

                        fireteam.VehicleVariant = ConvertStringId(fireteam.VehicleVariant);
                        fireteam.ActivityName = ConvertStringId(fireteam.ActivityName);

                        foreach (var point in fireteam.PatrolPoints)
                            point.ActivityName = ConvertStringId(point.ActivityName);

                        foreach (var spawnPoint in fireteam.StartingLocations)
                        {
                            spawnPoint.Name = ConvertStringId(spawnPoint.Name);
                            spawnPoint.FireteamIndex = (short)i;
                            spawnPoint.InitialEquipmentIndexNew = spawnPoint.InitialEquipmentIndexOld;
                            spawnPoint.ActorVariant = ConvertStringId(spawnPoint.ActorVariant);
                            spawnPoint.VehicleVariant = ConvertStringId(spawnPoint.VehicleVariant);

                            spawnPoint.InitialMovementModeNew = spawnPoint.InitialMovementModeOld;

                            spawnPoint.ActivityName = ConvertStringId(spawnPoint.ActivityName);

                            foreach (var point in spawnPoint.PatrolPoints)
                                point.ActivityName = ConvertStringId(point.ActivityName);

                            squad.SpawnPoints.Add(spawnPoint);
                        }

                        squad.DesignerFireteams.Add(fireteam);
                    }
                }

                foreach (var pathfindingdata in scnr.AiUserHintData)
                {
                    foreach (var cookieCutter in pathfindingdata.CookieCutters)
                    {
                        cookieCutter.SectorPoints = new List<Scenario.TriggerVolume.SectorPoint>
                        {
                            new Scenario.TriggerVolume.SectorPoint
                            {
                                Position = new RealPoint3d(
                                    cookieCutter.Position.X - 0.5f,
                                    cookieCutter.Position.Y - 0.5f,
                                    cookieCutter.Position.Z),
                                Normal = new RealEulerAngles2d(Angle.FromDegrees(0.0f), Angle.FromDegrees(90.0f))
                            },
                            new Scenario.TriggerVolume.SectorPoint
                            {
                                Position = new RealPoint3d(
                                    cookieCutter.Position.X + 0.5f,
                                    cookieCutter.Position.Y - 0.5f,
                                    cookieCutter.Position.Z),
                                Normal = new RealEulerAngles2d(Angle.FromDegrees(0.0f), Angle.FromDegrees(90.0f))
                            },
                            new Scenario.TriggerVolume.SectorPoint
                            {
                                Position = new RealPoint3d(
                                    cookieCutter.Position.X + 0.5f,
                                    cookieCutter.Position.Y + 0.5f,
                                    cookieCutter.Position.Z),
                                Normal = new RealEulerAngles2d(Angle.FromDegrees(0.0f), Angle.FromDegrees(90.0f))
                            },
                            new Scenario.TriggerVolume.SectorPoint
                            {
                                Position = new RealPoint3d(
                                    cookieCutter.Position.X - 0.5f,
                                    cookieCutter.Position.Y + 0.5f,
                                    cookieCutter.Position.Z),
                                Normal = new RealEulerAngles2d(Angle.FromDegrees(0.0f), Angle.FromDegrees(90.0f))
                            }
                        };
                    }
                }

                var zoneAreaSectors = new List<List<List<(short, short)>>>();

                foreach (var zone in scnr.Zones)
                {
                    foreach (var firingPosition in zone.FiringPositions)
                    {
                        if (firingPosition.BspIndex != -1)
                            zone.BspFlags |= (ushort)(1 << firingPosition.BspIndex);

                        if (firingPosition.SectorBspIndex != -1)
                            zone.BspFlags |= (ushort)(1 << firingPosition.SectorBspIndex);
                    }

                    var areaSectors = new List<List<(short, short)>>();

                    for (var areaIndex = 0; areaIndex < zone.Areas.Count; areaIndex++)
                    {
                        var area = zone.Areas[areaIndex];

                        area.ManualReferenceFrameNew = area.ManualReferenceFrameOld;
                        //This is definitely a bsp index, not an area type
                        area.BSPIndex = zone.ManualBspIndex;
                        area.Points = new List<Scenario.Zone.Area.Point>()
                        {
                            new Scenario.Zone.Area.Point
                            {
                                Position = new RealPoint3d(
                                    area.RuntimeRelativeMeanPoint.X - area.RuntimeStandardDeviation,
                                    area.RuntimeRelativeMeanPoint.Y - area.RuntimeStandardDeviation,
                                    area.RuntimeRelativeMeanPoint.Z),
                                ReferenceFrame = -1,
                                BspIndex = area.BSPIndex, // TODO: find the proper bsp index
                                Facing = new RealEulerAngles2d(Angle.FromDegrees(0.0f), Angle.FromDegrees(90.0f))
                            },
                            new Scenario.Zone.Area.Point
                            {
                                Position = new RealPoint3d(
                                    area.RuntimeRelativeMeanPoint.X + area.RuntimeStandardDeviation,
                                    area.RuntimeRelativeMeanPoint.Y - area.RuntimeStandardDeviation,
                                    area.RuntimeRelativeMeanPoint.Z),
                                ReferenceFrame = -1,
                                BspIndex = area.BSPIndex, // TODO: find the proper bsp index
                                Facing = new RealEulerAngles2d(Angle.FromDegrees(0.0f), Angle.FromDegrees(90.0f))
                            },
                            new Scenario.Zone.Area.Point
                            {
                                Position = new RealPoint3d(
                                    area.RuntimeRelativeMeanPoint.X + area.RuntimeStandardDeviation,
                                    area.RuntimeRelativeMeanPoint.Y + area.RuntimeStandardDeviation,
                                    area.RuntimeRelativeMeanPoint.Z),
                                ReferenceFrame = -1,
                                BspIndex = area.BSPIndex, // TODO: find the proper bsp index
                                Facing = new RealEulerAngles2d(Angle.FromDegrees(0.0f), Angle.FromDegrees(90.0f))
                            },
                            new Scenario.Zone.Area.Point
                            {
                                Position = new RealPoint3d(
                                    area.RuntimeRelativeMeanPoint.X - area.RuntimeStandardDeviation,
                                    area.RuntimeRelativeMeanPoint.Y + area.RuntimeStandardDeviation,
                                    area.RuntimeRelativeMeanPoint.Z),
                                ReferenceFrame = -1,
                                BspIndex = area.BSPIndex, // TODO: find the proper bsp index
                                Facing = new RealEulerAngles2d(Angle.FromDegrees(0.0f), Angle.FromDegrees(90.0f))
                            }
                        };

                        var sectors = new List<(short, short)>();

                        foreach (var firingPosition in zone.FiringPositions)
                        {
                            if ((firingPosition.AreaIndex != areaIndex) || (firingPosition.SectorBspIndex == -1) || (firingPosition.SectorIndex == -1))
                                continue;

                            if (sectors.Contains((firingPosition.SectorBspIndex, firingPosition.SectorIndex)))
                                continue;

                            sectors.Add((firingPosition.SectorBspIndex, firingPosition.SectorIndex));
                        }

                        areaSectors.Add(sectors);
                    }

                    zoneAreaSectors.Add(areaSectors);
                }

                //
                // TODO: thoroughly check and possibly refactor the ai objective code below
                //

                foreach (var aiObjective in scnr.AiObjectives)
                {
                    foreach (var task in aiObjective.Tasks)
                    {
                        task.RuntimeFlags = Scenario.AiObjective.Task.RuntimeFlagsValue.AreaConnectivityValid;

                        if (!Enum.TryParse(task.Filter.Halo3Retail.ToString(), out task.Filter.Halo3Odst))
                            throw new NotSupportedException(task.Filter.Halo3Retail.ToString());

                        foreach (var taskArea in task.Areas)
                        {
                            if (taskArea.ZoneIndex == -1 || taskArea.AreaIndex == -1)
                                continue;

                            foreach (var entry1 in zoneAreaSectors[taskArea.ZoneIndex][taskArea.AreaIndex])
                            {
                                if (entry1.Item1 >= pathfindingBsps.Count || entry1.Item2 >= pathfindingBsps[entry1.Item1].PathfindingData[0].Sectors.Count)
                                {
                                    Log.Warning("Invalid zone area sector data!");
                                    continue;
                                }

                                var pathfinding = pathfindingBsps[entry1.Item1].PathfindingData[0];
                                var sector = pathfinding.Sectors[entry1.Item2];
                                var link = pathfinding.Links[sector.FirstLink];

                                while (true)
                                {
                                    if (link.LeftSector == entry1.Item2)
                                    {
                                        if ((link.RightSector & 0xFFFEFFFF) != 0)
                                        {
                                            for (var areaIndex = 0; areaIndex < task.Areas.Count; areaIndex++)
                                            {
                                                if (areaIndex == task.Areas.IndexOf(taskArea) || task.Areas[areaIndex].ZoneIndex != taskArea.ZoneIndex)
                                                    continue;

                                                foreach (var entry2 in zoneAreaSectors[task.Areas[areaIndex].ZoneIndex][task.Areas[areaIndex].AreaIndex])
                                                {
                                                    if (entry1.Item1 != entry2.Item1)
                                                        continue;

                                                    if (entry2.Item2 == link.LeftSector || entry2.Item2 == link.RightSector)
                                                        taskArea.ConnectivityBitVector |= 1 << areaIndex;
                                                }
                                            }
                                        }

                                        if (link.ForwardLink == sector.FirstLink)
                                            break;
                                        else
                                            link = pathfinding.Links[link.ForwardLink];
                                    }
                                    else if (link.RightSector == entry1.Item2)
                                    {
                                        if ((link.LeftSector & 0xFFFEFFFF) != 0)
                                        {
                                            for (var areaIndex = 0; areaIndex < task.Areas.Count; areaIndex++)
                                            {
                                                if (areaIndex == task.Areas.IndexOf(taskArea) || task.Areas[areaIndex].ZoneIndex != taskArea.ZoneIndex)
                                                    continue;

                                                foreach (var entry2 in zoneAreaSectors[task.Areas[areaIndex].ZoneIndex][task.Areas[areaIndex].AreaIndex])
                                                {
                                                    if (entry1.Item1 != entry2.Item1)
                                                        continue;

                                                    if (entry2.Item2 == link.LeftSector || entry2.Item2 == link.RightSector)
                                                        taskArea.ConnectivityBitVector |= 1 << areaIndex;
                                                }
                                            }
                                        }

                                        if (link.ReverseLink == sector.FirstLink)
                                            break;
                                        else
                                            link = pathfinding.Links[link.ReverseLink];
                                    }
                                }
                            }
                        }

                        foreach (var direction in task.Direction)
                            direction.Points = direction.Points_H3.ToList();
                    }
                }
            }

            AddHOCameras(cacheStream, scnr, tagName);

            //
            // Convert PlayerStartingProfiles
            //

            if (BlamCache.Version == CacheVersion.Halo3Retail)
            {
                if (scnr.PlayerStartingProfile.Count >= 4)
                {
                    var profile_0 = scnr.PlayerStartingProfile[0];
                    var profile_1 = scnr.PlayerStartingProfile[1];
                    var profile_2 = scnr.PlayerStartingProfile[2];
                    var profile_3 = scnr.PlayerStartingProfile[3];

                    scnr.PlayerStartingProfile.Insert(1, profile_2);
                    scnr.PlayerStartingProfile.Insert(2, profile_2); 
                    scnr.PlayerStartingProfile.Insert(3, profile_2); 

                    scnr.PlayerStartingProfile.Insert(4, profile_0);
                    scnr.PlayerStartingProfile.Insert(5, profile_2);
                    scnr.PlayerStartingProfile.Insert(6, profile_2);
                    scnr.PlayerStartingProfile.Insert(7, profile_2);

                    scnr.PlayerStartingProfile.Insert(8, profile_1);
                    scnr.PlayerStartingProfile.Insert(9, profile_3);
                    scnr.PlayerStartingProfile.Insert(10, profile_3);
                    scnr.PlayerStartingProfile.Insert(11, profile_3);

                    scnr.PlayerStartingProfile.Insert(12, profile_1);
                    scnr.PlayerStartingProfile.Insert(13, profile_3);
                    scnr.PlayerStartingProfile.Insert(14, profile_3);
                    scnr.PlayerStartingProfile.Insert(15, profile_3);

                    scnr.PlayerStartingProfile.RemoveAt(16);
                    scnr.PlayerStartingProfile.RemoveAt(16);
                    scnr.PlayerStartingProfile.RemoveAt(16);
                }
            }

            ConvertScripts(cacheStream, blamCacheStream, scnr, tagName);

            //
            // Remove functions from default screen fx
            //

            if (scnr.DefaultScreenFx != null)
            {
                var defaultSefc = CacheContext.Deserialize<AreaScreenEffect>(cacheStream, scnr.DefaultScreenFx);
                foreach (var screenEffect in defaultSefc.ScreenEffects)
                {
                    screenEffect.AngleFalloffFunction.Data = DefaultScenarioFxFunction;
                    screenEffect.DistanceFalloffFunction.Data = DefaultScenarioFxFunction;
                    screenEffect.TimeEvolutionFunction.Data = DefaultScenarioFxFunction;
                }
                CacheContext.Serialize(cacheStream, scnr.DefaultScreenFx, defaultSefc);
            }

            //
            // Reach fixups
            //

            if(BlamCache.Version >= CacheVersion.HaloReach)
            {
                for(int i = 0; i < scnr.TriggerVolumes.Count; i++)
                    scnr.TriggerVolumes[i] = ConvertTriggerVolumeReach(scnr.TriggerVolumes[i]);

                // TODO: Handle this a little better
                for(int i = 0; i < scnr.Decals.Count; i++)
                    scnr.Decals[i].Scale = (float)Math.Sqrt(scnr.Decals[i].ScaleReach.Lower * scnr.Decals[i].ScaleReach.Upper);
            }

            if (BlamCache.Version >= CacheVersion.HaloReach && FlagIsSet(PortingFlags.Recursive))
            {
                // convert structure design

                if (scnr.StructureDesigns.Count > 0)
                {
                    if (scnr.StructureDesigns.Count > 1)
                    {
                        Log.Warning("Multiple structure designs currently not supported.");
                    }
                    else
                    {
                        var sddtTag = ConvertTag(cacheStream, blamCacheStream, scnr.StructureDesigns[0].StructureDesign);
                        for (int i = 0; i < scnr.StructureBsps.Count; i++)
                            scnr.StructureBsps[i].Design = sddtTag;
                    }
                }

                var lightmap = CacheContext.Deserialize<ScenarioLightmap>(cacheStream, scnr.Lightmap);

                for (int i = 0; i < scnr.StructureBsps.Count; i++)
                {
                    if (scnr.StructureBsps[i].StructureBsp == null)
                        continue;

                    var sbsp = CacheContext.Deserialize<ScenarioStructureBsp>(cacheStream, scnr.StructureBsps[i].StructureBsp);


                    // Reach doesn't have these blocks in sbsp anymore, move it back
                    sbsp.CameraFxPalette = scnr.CameraFx;
                    sbsp.AtmospherePalette = scnr.Atmosphere;
                    sbsp.AcousticsPalette = scnr.AcousticsPalette;


                    // Rebuild reach instanced geometry instance per pixel data
                    //
                    // Prior to reach the "LodDataIndex" was the index of the instanced geometry instance per pixel data.
                    // In reach this is the mesh index, the per pixel data is indexed by instance index instead, 
                    // with a -1 vertex buffer index for instances that do not have per pixel data

                    if (lightmap.PerPixelLightmapDataReferences[i].LightmapBspData != null)
                    {
                        var Lbsp = CacheContext.Deserialize<ScenarioLightmapBspData>(cacheStream, lightmap.PerPixelLightmapDataReferences[i].LightmapBspData);
                        var newPerPixelLighting = new List<RenderGeometry.StaticPerPixelLighting>();
                        for (int instanceIndex = 0; instanceIndex < sbsp.InstancedGeometryInstances.Count; instanceIndex++)
                        {
                            var lightingElement = Lbsp.Geometry.InstancedGeometryPerPixelLighting[instanceIndex];
                            if (lightingElement.VertexBufferIndex != -1)
                            {
                                sbsp.InstancedGeometryInstances[instanceIndex].LightmapTexcoordBlockIndex = (short)newPerPixelLighting.Count;
                                newPerPixelLighting.Add(lightingElement);
                            }
                            else
                            {
                                sbsp.InstancedGeometryInstances[instanceIndex].LightmapTexcoordBlockIndex = -1;
                            }
                        }
                        Lbsp.Geometry.InstancedGeometryPerPixelLighting = newPerPixelLighting;

                        // Fixup foliage material
                        foreach (var mesh in Lbsp.Geometry.Meshes)
                        {
                            foreach (var part in mesh.Parts)
                            {
                                if (part.MaterialIndex != -1 && 
                                    sbsp.Materials[part.MaterialIndex].RenderMethod != null &&
                                    sbsp.Materials[part.MaterialIndex].RenderMethod.Group.Tag == "rmfl")
                                {
                                    part.FlagsNew |= Part.PartFlagsNew.PreventBackfaceCulling;
                                }
                            }
                        }

                        CacheContext.Serialize(cacheStream, lightmap.PerPixelLightmapDataReferences[i].LightmapBspData, Lbsp);
                    }

                    // Fixup instance bsp physics
                    for (int instanceIndex = 0; instanceIndex < sbsp.InstancedGeometryInstances.Count; instanceIndex++)
                    {
                        var instance = sbsp.InstancedGeometryInstances[instanceIndex];
                        foreach(var bspPhysics in instance.BspPhysics)
                        {
                            bspPhysics.GeometryShape.BspIndex = (sbyte)i;
                            bspPhysics.GeometryShape.CollisionGeometryShapeKey = (ushort)instanceIndex;
                        }
                    }

                    CacheContext.Serialize(cacheStream, scnr.StructureBsps[i].StructureBsp, sbsp);
                }

                // Generate skya from fog parameters

                CachedTag skyaTag = scnr.SkyParameters ?? CacheContext.TagCache.AllocateTag<SkyAtmParameters>(tagName);
                SkyAtmParameters skya = new SkyAtmParameters();
                skya.AtmosphereSettings = new List<SkyAtmParameters.AtmosphereProperty>();
                skya.UnderwaterSettings = new List<SkyAtmParameters.UnderwaterBlock>();

                List<string> convertedWaterFog = new List<string>();

                // Convert atmosphere globals

                if (scnr.AtmosphereGlobals != null)
                {
                    var atgf = BlamCache.Deserialize<AtmosphereGlobals>(blamCacheStream, scnr.AtmosphereGlobals);

                    skya.Flags = SkyAtmParameters.SkyAtmFlags.None;
                    skya.FogBitmap = atgf.FogBitmap != null ? (CachedTag)ConvertData(cacheStream, blamCacheStream, atgf.FogBitmap, null, atgf.FogBitmap.Name) : null;
                    skya.TextureRepeatRate = atgf.TextureRepeatRate;
                    skya.DistanceBetweenSheets = atgf.DistanceBetweenSheets;
                    skya.DepthFadeFactor = atgf.DepthFadeFactor;
                    skya.ClusterSearchRadius = 25.0f;
                    skya.TransparentSortDistance = atgf.TransparentSortDistance;

                    // This *should* fix the vertex explosions issues (Validate?)
                    skya.TransparentSortLayer = SortingLayerValue.PrePass;

                    foreach (var underwaterSetting in atgf.UnderwaterSettings)
                    {
                        var unwt = new SkyAtmParameters.UnderwaterBlock
                        {
                            Name = (StringId)ConvertData(cacheStream, blamCacheStream, underwaterSetting.Name, null, null),
                            Murkiness = underwaterSetting.Murkiness,
                            FogColor = underwaterSetting.FogColor
                        };

                        skya.UnderwaterSettings.Add(unwt);

                        convertedWaterFog.Add(CacheContext.StringTable.GetString(unwt.Name));
                    }
                }

                // Convert underwater fog

                foreach (var sDesign in scnr.StructureDesigns)
                {
                    if (sDesign.StructureDesign != null)
                    {
                        var blamSddt = BlamCache.Deserialize<StructureDesign>(blamCacheStream, BlamCache.TagCache.GetTag<StructureDesign>(sDesign.StructureDesign.Name));

                        foreach (var waterInstance in blamSddt.WaterInstances)
                        {
                            var waterNameId = (StringId)ConvertData(cacheStream, blamCacheStream, blamSddt.WaterGroups[waterInstance.WaterNameIndex].Name, null, null);
                            var waterName = CacheContext.StringTable.GetString(waterNameId);

                            if (!convertedWaterFog.Contains(waterName))
                            {
                                var unwt = new SkyAtmParameters.UnderwaterBlock
                                {
                                    Name = waterNameId,
                                    Murkiness = waterInstance.FogMurkiness,
                                    FogColor = waterInstance.FogColor
                                };

                                skya.UnderwaterSettings.Add(unwt);

                                convertedWaterFog.Add(waterName);
                            }
                        }
                    }
                }

                // Convert atmospheres

                foreach (var atmospherePalette in scnr.Atmosphere)
                {
                    while (atmospherePalette.AtmosphereSettingIndex >= skya.AtmosphereSettings.Count)
                        skya.AtmosphereSettings.Add(new SkyAtmParameters.AtmosphereProperty());

                    if (atmospherePalette.AtmosphereFog != null)
                    {
                        var fogg = BlamCache.Deserialize<AtmosphereFog>(blamCacheStream, atmospherePalette.AtmosphereFog);

                        var atmosphereSettings = skya.AtmosphereSettings[atmospherePalette.AtmosphereSettingIndex];

                        atmosphereSettings.Flags |= SkyAtmParameters.AtmosphereProperty.AtmosphereFlags.EnableAtmosphere;
                        atmosphereSettings.Name = (StringId)ConvertData(cacheStream, blamCacheStream, atmospherePalette.Name, null, null);

                        // Patchy Fog

                        if (fogg.Flags.HasFlag(AtmosphereFog.AtmosphereFogFlags.PatchyFogEnabled))
                            atmosphereSettings.Flags |= SkyAtmParameters.AtmosphereProperty.AtmosphereFlags.PatchyFog;

                        atmosphereSettings.SheetDensity = fogg.PatchyFog.SheetDensity;
                        atmosphereSettings.FullIntensityHeight = fogg.PatchyFog.FullIntensityHeight;
                        atmosphereSettings.HalfIntensityHeight = fogg.PatchyFog.HalfIntensityHeight;
                        atmosphereSettings.WindDirection = fogg.PatchyFog.WindDirection;

                        if (fogg.WeatherEffect != null)
                            atmosphereSettings.WeatherEffect = (CachedTag)ConvertData(cacheStream, blamCacheStream, fogg.WeatherEffect, null, null);

                        // Scattering
                        // TODO: proper conversion for fog.

                        AtmosphereFog.FogSettings fogSettings = null;

                        if (fogg.Flags.HasFlag(AtmosphereFog.AtmosphereFogFlags.GroundFogEnabled))
                            fogSettings = fogg.GroundFog;
                        else if (fogg.Flags.HasFlag(AtmosphereFog.AtmosphereFogFlags.SkyFogEnabled))
                            fogSettings = fogg.SkyFog;

                        if (fogSettings != null)
                        {
                            atmosphereSettings.Flags |= SkyAtmParameters.AtmosphereProperty.AtmosphereFlags.OverrideRealSunValues;
                            atmosphereSettings.Color = fogSettings.FogColor;
                            atmosphereSettings.Intensity = 1.0f; // tweak?
                            atmosphereSettings.SunAnglePitch = 0.0f;
                            atmosphereSettings.SunAngleYaw = 0.0f;

                            // reach has a fog light angle but i think this better for now
                            if (scnr.SkyReferences.Count > 0 && scnr.SkyReferences[0].SkyObject != null)
                            {
                                var skyObje = CacheContext.Deserialize<GameObject>(cacheStream, scnr.SkyReferences[0].SkyObject);
                                var hlmt = CacheContext.Deserialize<Model>(cacheStream, skyObje.Model);
                                var mode = CacheContext.Deserialize<RenderModel>(cacheStream, hlmt.RenderModel);

                                if (mode.LightgenLights.Count > 0)
                                {
                                    var direction = mode.LightgenLights.Last().Direction; // last light is sun

                                    atmosphereSettings.SunAnglePitch = (float)(Math.Asin(direction.K) * (180.0f / Math.PI));
                                    if (atmosphereSettings.SunAnglePitch < 0.0f) // limit to 0-90
                                        atmosphereSettings.SunAnglePitch = -atmosphereSettings.SunAnglePitch;

                                    atmosphereSettings.SunAngleYaw = (float)(Math.Atan2(direction.J, direction.I) * (180.0f / Math.PI));
                                }
                            }

                            atmosphereSettings.SeaLevel = fogSettings.BaseHeight; // WU, lowest height of scenario

                            // these are definitely wrong
                            atmosphereSettings.RayleignHeightScale = fogSettings.FogHeight; // WU, height above sea where atmo 30% thick
                            atmosphereSettings.MieHeightScale = fogSettings.FogHeight; // WU, height above sea where atmo 30% thick

                            atmosphereSettings.MaxFogThickness = fogSettings.FogThickness * 65536.0f;
                        }

                        // todo: scale these with fog thickness
                        atmosphereSettings.RayleighMultiplier = 0.05f; // scattering amount, small
                        atmosphereSettings.MieMultiplier = 0.025f; // scattering amount, large

                        atmosphereSettings.SunPhaseFunction = 0.2f; //todo
                        atmosphereSettings.Desaturation = 0.0f;
                        atmosphereSettings.DistanceBias = fogg.DistanceBias;
                    }
                }

                // validate all values and recalculate atmosphere constants
                skya.Postprocess();

                CacheContext.Serialize(cacheStream, skyaTag, skya);

                scnr.SkyParameters = skyaTag;

                // set Game Object Reset Height

                scnr.SpawnData = new List<Scenario.SpawnDatum> { new Scenario.SpawnDatum { GameObjectResetHeight = -20f } };

                // gametype object processing

                if (scnr.MapType == ScenarioMapType.Multiplayer)
                    AddGametypeObjects(scnr);
            }

            //
            // Misc multiplayer fixups
            //

            if (scnr.PlayerStartingProfile == null || scnr.PlayerStartingProfile.Count == 0)
            {
                scnr.PlayerStartingProfile = new List<Scenario.PlayerStartingProfileBlock>() {
                    new Scenario.PlayerStartingProfileBlock() {
                        Name = "start_assault",
                        PrimaryWeapon = CacheContext.TagCache.GetTag(@"objects\weapons\rifle\assault_rifle\assault_rifle", "weap"),
                        PrimaryRoundsLoaded = 32,
                        PrimaryRoundsTotal = 108,
                        StartingFragGrenadeCount = 2
                    }
                };
            }
            else if (scnr.MapType == ScenarioMapType.Multiplayer)
            {
                if (string.IsNullOrEmpty(scnr.PlayerStartingProfile[0].Name))
                    scnr.PlayerStartingProfile[0].Name = "start_assault";

                if (scnr.PlayerStartingProfile[0].PrimaryWeapon == null)
                    scnr.PlayerStartingProfile[0].PrimaryWeapon = CacheContext.TagCache.GetTag(@"objects\weapons\rifle\assault_rifle\assault_rifle", "weap");
            }

            if (scnr.MapType == ScenarioMapType.Multiplayer && BlamCache.Version == CacheVersion.Halo3Retail)
            {
                var spawnpoint = -1;
                for (int i = 0; i < scnr.SceneryPalette.Count; i++)
                {
                    if (scnr.SceneryPalette[i].Object?.Name == @"objects\multi\spawning\respawn_point")
                    {
                        spawnpoint = i;
                        break;
                    }
                }

                if (spawnpoint != -1)
                {
                    for (int i = 0; i < scnr.Scenery.Count; i++)
                    {
                        if (scnr.Scenery[i].PaletteIndex == spawnpoint)
                            scnr.Scenery[i].Multiplayer.Team = MultiplayerTeamDesignator.Neutral;
                    }
                }
            }

            if (Options.RegenerateStructureSurfaces)
            {
                foreach (var block in scnr.StructureBsps)
                {
                    if (block.StructureBsp == null)
                        continue;

                    CachedTag sbspTag = block.StructureBsp;
                    var sbsp = CacheContext.Deserialize<ScenarioStructureBsp>(cacheStream, sbspTag);
                    new GenerateStructureSurfacesCommand(CacheContext, sbspTag, sbsp, cacheStream, scnr).Execute(new List<string> { });
                    CacheContext.Serialize(cacheStream, sbspTag, sbsp);
                }
            }

            return scnr;
        }

        private object ConvertScenarioObjectMultiplayer(Stream cacheStream, Stream blamCacheStream, object definition, string blamTagName, Scenario.MultiplayerObjectProperties scnrObj)
        {
            if (BlamCache.Version < CacheVersion.HaloReach)
                return scnrObj;

            scnrObj.BoundaryWidthRadius = scnrObj.BoundaryWidthRadiusReach;
            scnrObj.BoundaryBoxLength = scnrObj.BoundaryBoxLengthReach;
            scnrObj.BoundaryPositiveHeight = scnrObj.BoundaryPositiveHeightReach;
            scnrObj.BoundaryNegativeHeight = scnrObj.BoundaryNegativeHeightReach;
            scnrObj.RemappingPolicy = scnrObj.RemappingPolicyReach;

            switch (scnrObj.MegaloLabel)
            {
                case "ctf_res_zone_away":
                case "ctf_res_zone":
                case "ctf_flag_return":
                case "ctf":
                    scnrObj.EngineFlags |= GameEngineSubTypeFlags.CaptureTheFlag;
                    break;
                case "slayer":
                    scnrObj.EngineFlags |= GameEngineSubTypeFlags.Slayer;
                    break;
                case "oddball_ball":
                    scnrObj.EngineFlags |= GameEngineSubTypeFlags.Oddball;
                    break;
                case "koth_hill":
                    scnrObj.EngineFlags |= GameEngineSubTypeFlags.KingOfTheHill;
                    break;
                case "terr_object":
                    scnrObj.EngineFlags |= GameEngineSubTypeFlags.Territories;
                    break;
                case "as_goal": // assault plant point
                case "as_bomb": // assault bomb spawn
                case "assault":
                    scnrObj.EngineFlags |= GameEngineSubTypeFlags.Assault;
                    break;
                case "inf_spawn":
                case "inf_haven":
                    scnrObj.EngineFlags |= GameEngineSubTypeFlags.Infection;
                    break;
                case "stp_goal": // use these for juggernaut points
                    scnrObj.EngineFlags |= GameEngineSubTypeFlags.Juggernaut;
                    break;
                case "stp_flag": // use these for VIP points
                case "stockpile":
                    scnrObj.EngineFlags |= GameEngineSubTypeFlags.Vip;
                    break;
                //case "ffa_only":
                //case "team_only":
                //case "hh_drop_point":
                //case "rally":
                //case "rally_flag":
                //case "race_flag":
                //case "race_spawn":
                //case "as_spawn":
                //case "none":
                //    break;
                default:
                    break;
            }
            return scnrObj;
        }

        private Scenario.TriggerVolume ConvertTriggerVolumeReach(Scenario.TriggerVolume volume)
        {
            RealVector3d ProjectPointOnPlane(RealPlane3d plane, RealVector3d point)
            {
                var o = new RealVector3d(plane.I * plane.D, plane.J * plane.D, plane.K * plane.D);
                var v = point - o;
                var n = plane.Normal;
                float dist = (n.I * v.I) + (n.J * v.J) + (n.K * v.K);
                return point - dist * n;
            }


            if (volume.Type == Scenario.TriggerVolumeType.Sector)
            {
                foreach (var triangle in volume.RuntimeTriangles)
                {
                    triangle.BoundsX0 = triangle.BoundsY0 = triangle.BoundsZ0 = float.MaxValue;
                    triangle.BoundsX1 = triangle.BoundsY1 = triangle.BoundsZ1 = -float.MaxValue;

                    var points = new[] { triangle.Vertex0, triangle.Vertex1, triangle.Vertex2 };
                    for (int i = 0; i < points.Length; i++)
                    {
                        var proj = ProjectPointOnPlane(triangle.Plane0, new RealVector3d(points[i].X, points[i].Y, 0));
                        triangle.BoundsX0 = Math.Min(triangle.BoundsX0, proj.I);
                        triangle.BoundsX1 = Math.Max(triangle.BoundsX1, proj.I);
                        triangle.BoundsY0 = Math.Min(triangle.BoundsY0, proj.J);
                        triangle.BoundsY1 = Math.Max(triangle.BoundsY1, proj.J);
                        triangle.BoundsZ0 = Math.Min(triangle.BoundsZ0, proj.K);
                        triangle.BoundsZ1 = Math.Max(triangle.BoundsZ1, proj.K);
                    }

                    triangle.Plane1.Normal *= -1;
                    triangle.Plane1.D *= -1;
                }
            }

            return volume;
        }

        public void AddGametypeObjects(Scenario scnr)
        {
            scnr.SceneryPalette = scnr.SceneryPalette ?? new List<Scenario.ScenarioPaletteEntry>();
            scnr.MachinePalette = scnr.MachinePalette ?? new List<Scenario.ScenarioPaletteEntry>();
            scnr.CratePalette = scnr.CratePalette ?? new List<Scenario.ScenarioPaletteEntry>();

            if (scnr.CratePalette.Count > 0)
            {
                scnr.CratePalette.AddRange(new List<Scenario.ScenarioPaletteEntry>
                    {
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\assault\assault_bomb_goal_area", "bloc") },
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\assault\assault_bomb_spawn_point", "bloc") },
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\ctf\ctf_flag_spawn_point", "bloc") },
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\infection\infection_haven_static", "bloc") },
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\juggernaut\juggernaut_destination_static", "bloc") },
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\vip\vip_destination_static", "bloc") },
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\territories\territory_static", "bloc") }
                    });

                ProcessMegaloLabels(scnr.CratePalette, scnr.Crates);
                scnr.Crates = scnr.Crates.Where(e => e.PaletteIndex != -1).ToList();

                // Teleporters must be neutral.

                for (int i = 0; i < scnr.CratePalette.Count(); i++)
                {
                    var obj = scnr.CratePalette[i].Object;
                    if (obj != null && obj.Name.Contains("teleporter"))
                    {
                        foreach (var instance in scnr.Crates.Where(n => n.PaletteIndex == i))
                            instance.Multiplayer.Team = MultiplayerTeamDesignator.Neutral;
                    }
                }

                // Reach uses a unified CTF spawn and return object. A duplicate of these instances will be used for flag spawn locations

                short flagSpawnIndex = GetPaletteIndex(scnr.CratePalette, @"objects\multi\ctf\ctf_flag_return_area");
                List<Scenario.CrateInstance> flagSpawns = new List<Scenario.CrateInstance>();
                
                foreach (var bloc in scnr.Crates.Where(n => n.PaletteIndex == flagSpawnIndex))
                    flagSpawns.Add(bloc.DeepClone());

                foreach (var flagSpawn in flagSpawns)
                {
                    flagSpawn.PaletteIndex = GetPaletteIndex(scnr.CratePalette, @"objects\multi\ctf\ctf_flag_spawn_point");
                    flagSpawn.NameIndex = -1;
                }

                scnr.Crates.AddRange(flagSpawns);
            }

            if (scnr.MachinePalette.Count > 0) 
            {
                ProcessMegaloLabels(scnr.MachinePalette, scnr.Machines);
                scnr.Machines = scnr.Machines.Where(e => e.PaletteIndex != -1).ToList();
            }

            if (scnr.SceneryPalette.Count > 0)
            {
                var invisible_spawn = scnr.SceneryPalette.FindIndex(e => e.Object?.Name == "objects\\multi\\spawning\\respawn_point_invisible");
                if (invisible_spawn != -1)
                    foreach (var entry in scnr.Scenery.Where(e => e.PaletteIndex == invisible_spawn).Skip(1))
                        entry.PaletteIndex = -1;

                scnr.SceneryPalette.AddRange(new List<Scenario.ScenarioPaletteEntry>
                    {
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\assault\assault_respawn_zone", "scen") },
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\ctf\ctf_flag_at_home_respawn_zone", "scen") },
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\ctf\ctf_flag_away_respawn_zone", "scen") },
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\ctf\ctf_respawn_zone", "scen") },
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\infection\infection_respawn_zone", "scen") },
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\koth\koth_respawn_zone", "scen") },
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\oddball\oddball_respawn_zone", "scen") },
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\territories\territories_respawn_zone", "scen") },
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\vip\vip_respawn_zone", "scen") },
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\assault\assault_initial_spawn_point", "scen") },
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\ctf\ctf_initial_spawn_point", "scen") },
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\infection\infection_initial_spawn_point", "scen") },
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\koth\koth_initial_spawn_point", "scen") },
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\oddball\oddball_initial_spawn_point", "scen") },
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\territories\territories_initial_spawn_point", "scen") },
                        new Scenario.ScenarioPaletteEntry { Object = CacheContext.TagCache.GetTag(@"objects\multi\vip\vip_initial_spawn_point", "scen") }
                    });

                ProcessMegaloLabels(scnr.SceneryPalette, scnr.Scenery);
                scnr.Scenery = scnr.Scenery.Where(e => e.PaletteIndex != -1).ToList();
            }
        }

        private void ProcessMegaloLabels<T>(List<Scenario.ScenarioPaletteEntry> palette, List<T> instanceList)
        {
            List<string> stripped = new List<string>();
            foreach (var instance in instanceList)
            {
                var mpProperties = (Scenario.MultiplayerObjectProperties)(instance.GetType().GetField("Multiplayer").GetValue(instance));
                if (mpProperties == null)
                    return;

                var permutationInstance = (instance as Scenario.PermutationInstance);
                var scenarioInstance = (instance as Scenario.ScenarioInstance);
                var newPaletteIndex = permutationInstance == null ? scenarioInstance.PaletteIndex : permutationInstance.PaletteIndex;
                var ctfReturnIndex = GetPaletteIndex(palette, @"objects\multi\ctf\ctf_flag_return_area");

                switch (mpProperties.MegaloLabel)
                {
                    case "ctf_res_zone_away":
                        newPaletteIndex = (short)(CheckTeamValue(permutationInstance) ? GetPaletteIndex(palette, @"objects\multi\ctf\ctf_flag_away_respawn_zone") : -1);
                        break;
                    case "ctf_res_zone":
                        newPaletteIndex = (short)(CheckTeamValue(permutationInstance) ? GetPaletteIndex(palette, @"objects\multi\ctf\ctf_flag_at_home_respawn_zone") : -1);
                        break;
                    case "ctf_flag_return":
                        {
                            newPaletteIndex = (short)(CheckTeamValue(permutationInstance) ? GetPaletteIndex(palette, @"objects\multi\ctf\ctf_flag_return_area") : -1);
                            //if (mpProperties.Team == MultiplayerTeamDesignator.Neutral)
                            //    newPaletteIndex = -1;
                        }
                        break;
                    case "terr_object":
                        newPaletteIndex = GetPaletteIndex(palette, @"objects\multi\territories\territory_static");
                        break;
                    case "as_goal": // assault plant point
                        newPaletteIndex = (short)(CheckTeamValue(permutationInstance) ? GetPaletteIndex(palette, @"objects\multi\assault\assault_bomb_goal_area") : -1);
                        break;
                    case "as_bomb": // assault bomb spawn
                        newPaletteIndex = (short)(CheckTeamValue(permutationInstance) ? GetPaletteIndex(palette, @"objects\multi\assault\assault_bomb_spawn_point") : -1);
                        break;
                    case "stp_goal": // substitute stockpile goal for juggernaut destination
                        newPaletteIndex = GetPaletteIndex(palette, @"objects\multi\juggernaut\juggernaut_destination_static");
                        break;
                    case "stp_flag": // substitute stockpile flag spawn for VIP destination
                        newPaletteIndex = GetPaletteIndex(palette, @"objects\multi\vip\vip_destination_static");
                        break;
                    case "assault":
                        newPaletteIndex = (short)(CheckTeamValue(permutationInstance) ? GetPaletteIndex(palette, @"objects\multi\assault\assault_respawn_zone") : -1);
                        break;
                    case "inf_spawn":
                        newPaletteIndex = GetPaletteIndex(palette, @"objects\multi\infection\infection_initial_spawn_point");
                        break;
                    case "inf_haven":
                        newPaletteIndex = GetPaletteIndex(palette, @"objects\multi\infection\infection_respawn_zone");
                        break;
                    case "stockpile":
                        newPaletteIndex = GetPaletteIndex(palette, @"objects\multi\vip\vip_initial_spawn_point");
                        break;
                    case "ctf":
                        newPaletteIndex = (short)(CheckTeamValue(permutationInstance) ? GetPaletteIndex(palette, @"objects\multi\ctf\ctf_initial_spawn_point") : -1);
                        break;
                    case "oddball_ball":
                    case "koth_hill":
                    case "slayer":
                    case "lift":
                    case "none":
                        break;
                    //case "team_only":
                    //case "hh_drop_point":
                    //case "inv_objective":
                    //case "inv_obj_flag":
                    //case "invasion":
                    //    newPaletteIndex = -1;
                    //    break;
                    default:
                        if (!string.IsNullOrEmpty(mpProperties.MegaloLabel))
                        {
                            newPaletteIndex = -1;
                            if(!stripped.Contains(mpProperties.MegaloLabel))
                            {
                                stripped.Add(mpProperties.MegaloLabel);
                                Console.WriteLine($"Placements with label \"{mpProperties.MegaloLabel}\" stripped");
                            }
                        }
                        break;
                }

                mpProperties.SpawnFlags &= ~MultiplayerObjectPlacementSpawnFlags.HideUnlessRequired;

                if (permutationInstance != null)
                    permutationInstance.PaletteIndex = newPaletteIndex;
                else if (scenarioInstance != null)
                    scenarioInstance.PaletteIndex = newPaletteIndex;
            }
        }

        public short GetPaletteIndex(List<Scenario.ScenarioPaletteEntry> palette, string name)
        {
            var itemIndex = palette.FindIndex(x => (x.Object != null && x.Object.Name == name));

            return (short)itemIndex;
        }

        public bool CheckTeamValue(Scenario.PermutationInstance instance)
        {
            bool validforRvB = false;
            var validTeams = new List<string> { "Red", "Blue", "Neutral" };

            if (instance is Scenario.CrateInstance && validTeams.Contains((instance as Scenario.CrateInstance).Multiplayer.Team.ToString()))
                validforRvB = true;
            else if (instance is Scenario.SceneryInstance && validTeams.Contains((instance as Scenario.SceneryInstance).Multiplayer.Team.ToString()))
                validforRvB = true;

            return validforRvB;
        }

        private void AddHOCameras(Stream cacheStream, Scenario scnr, string tagName)
        {

            //
            // Add podium camera position
            //

            var existingPodiumCameraPoint = scnr.CutsceneCameraPoints.FirstOrDefault(cameraPoint => cameraPoint.Name == "podium_camera");
            if (existingPodiumCameraPoint != null)
            {
                // if we already have one, just add the flag for HO
                existingPodiumCameraPoint.Flags |= Scenario.CutsceneCameraPointFlags.PodiumCameraHack;
            }

            //
            // Add prematch camera position
            //

            var existingPrematchCameraPoint = scnr.CutsceneCameraPoints.FirstOrDefault(cameraPoint => cameraPoint.Name == "prematch_camera");
            if (existingPrematchCameraPoint != null)
            {
                // if we already have one, just add the flag for HO
                existingPrematchCameraPoint.Flags |= Scenario.CutsceneCameraPointFlags.PrematchCameraHack;
                return;
            }
            
            var createPrematchCamera = false;

            var position = new RealPoint3d();
            var orientation = new RealEulerAngles3d();

            if (FlagIsSet(PortingFlags.Recursive))
            {
                switch (tagName)
                {
                    case @"levels\multi\construct\construct":
                        createPrematchCamera = true;
                        position = new RealPoint3d(4.5471f, 1.8711f, 13.4354f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(-126.7653f), Angle.FromDegrees(0f), Angle.FromDegrees(0f));
                        break;

                    case @"levels\multi\isolation\isolation":
                        createPrematchCamera = true;
                        position = new RealPoint3d(-14.4359f, -10.9502f, -5.2309f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(30f), Angle.FromDegrees(0f), Angle.FromDegrees(0f));
                        break;

                    case @"levels\multi\salvation\salvation":
                        createPrematchCamera = true;
                        position = new RealPoint3d(-0.0762f, -0.1681f, 7.1527f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(90f), Angle.FromDegrees(0f), Angle.FromDegrees(0f));
                        break;

                    case @"levels\multi\snowbound\snowbound":
                        createPrematchCamera = true;
                        position = new RealPoint3d(-7.1015f, 17.7492f, 3.9918f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(-90f), Angle.FromDegrees(0f), Angle.FromDegrees(0f));
                        break;

                    case @"levels\dlc\armory\armory":
                        createPrematchCamera = true;
                        position = new RealPoint3d(-16.8807f, 0.0363f, -8.6872f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f));
                        break;

                    case @"levels\dlc\chillout\chillout":
                        createPrematchCamera = true;
                        position = new RealPoint3d(0.7120f, -10.8107f, 5.3540f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(90f), Angle.FromDegrees(0f), Angle.FromDegrees(0f));
                        break;

                    case @"levels\dlc\descent\descent":
                        createPrematchCamera = true;
                        position = new RealPoint3d(-19.9727f, -0.0140f, -17.3611f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f));
                        break;

                    case @"levels\dlc\docks\docks":
                        createPrematchCamera = true;
                        position = new RealPoint3d(-28.5603f, 22.1670f, -3.9043f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f));
                        break;

                    case @"levels\dlc\fortress\fortress":
                        createPrematchCamera = true;
                        position = new RealPoint3d(-33.9909f, 3.4858f, -18.9907f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f));
                        break;

                    case @"levels\dlc\ghosttown\ghosttown":
                        createPrematchCamera = true;
                        position = new RealPoint3d(-10.6792f, 10.8319f, 5.6487f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f));
                        break;

                    case @"levels\dlc\lockout\lockout":
                        createPrematchCamera = true;
                        position = new RealPoint3d(-19.9729f, 0.4024f, -5.3355f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f));
                        break;

                    case @"levels\dlc\midship\midship":
                        createPrematchCamera = true;
                        position = new RealPoint3d(-5.7814f, 4.7866f, 4.5577f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f));
                        break;

                    case @"levels\dlc\sidewinder\sidewinder":
                        createPrematchCamera = true;
                        position = new RealPoint3d(-35.8092f, 42.7776f, 2.6463f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f));
                        break;

                    case @"levels\dlc\spacecamp\spacecamp":
                        createPrematchCamera = true;
                        position = new RealPoint3d(-8.7606f, 17.2195f, -0.3308f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f));
                        break;

                    case @"levels\dlc\warehouse\warehouse":
                        createPrematchCamera = true;
                        position = new RealPoint3d(-11.2818f, 0.2725f, 4.1475f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f));
                        break;

                    case @"levels\dlc\sandbox\sandbox":
                        createPrematchCamera = true;
                        position = new RealPoint3d(-24.9556f, -9.8958f, -17.2465f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(0f));
                        break;

                    case @"levels\multi\guardian\guardian":
                        createPrematchCamera = true;
                        position = new RealPoint3d(-3.856011f, -1.605904f, 22.34261f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(-58.089f), Angle.FromDegrees(-6.839594f), Angle.FromDegrees(10.82678f));
                        break;

                    case @"levels\multi\riverworld\riverworld":
                        createPrematchCamera = true;
                        position = new RealPoint3d(80f, -115f, 8f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(-72f), Angle.FromDegrees(0f), Angle.FromDegrees(0f));
                        break;

                    case @"levels\multi\s3d_avalanche\s3d_avalanche":
                        createPrematchCamera = true;
                        position = new RealPoint3d(39.68156f, 52.96737f, 13.24531f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(-101.3976f), Angle.FromDegrees(1.840378f), Angle.FromDegrees(9.051623f));
                        break;

                    case @"levels\multi\s3d_turf\s3d_turf":
                        createPrematchCamera = true;
                        position = new RealPoint3d(-11.1375f, 10.65022f, 3.68083f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(-1.106702f), Angle.FromDegrees(-6.048638f), Angle.FromDegrees(0.1166338f));
                        break;

                    case @"levels\multi\cyberdyne\cyberdyne":
                        createPrematchCamera = true;
                        position = new RealPoint3d(16.48399f, -0.2954462f, 5.926272f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(148.4995f), Angle.FromDegrees(10.94987f), Angle.FromDegrees(-6.639596f));
                        break;

                    case @"levels\multi\chill\chill":
                        createPrematchCamera = true;
                        position = new RealPoint3d(0.1023328f, 13.20142f, 67.24016f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(-91.86741f), Angle.FromDegrees(0.5627626f), Angle.FromDegrees(16.76527f));
                        break;

                    case @"levels\dlc\bunkerworld\bunkerworld":
                        createPrematchCamera = true;
                        position = new RealPoint3d(1.919771f, 39.41721f, 14.75777f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(-74.90959f), Angle.FromDegrees(-0.6069012f), Angle.FromDegrees(2.249499f));
                        break;

                    case @"levels\multi\zanzibar\zanzibar":
                        createPrematchCamera = true;
                        position = new RealPoint3d(-0.5595548f, 8.776897f, 12.80816f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(-70.32931f), Angle.FromDegrees(-4.318761f), Angle.FromDegrees(11.89593f));
                        break;

                    case @"levels\multi\deadlock\deadlock":
                        createPrematchCamera = true;
                        position = new RealPoint3d(-7.903993f, -4.081663f, 17.2834f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(74.76313f), Angle.FromDegrees(-4.653013f), Angle.FromDegrees(-16.58442f));
                        break;

                    case @"levels\multi\shrine\shrine":
                        createPrematchCamera = true;
                        position = new RealPoint3d(31.19498f, 20.94002f, -6.859918f);
                        orientation = new RealEulerAngles3d(Angle.FromDegrees(-137.8311f), Angle.FromDegrees(16.69542f), Angle.FromDegrees(15.16735f));
                        break;

                    default:
                        if (scnr.MapType == ScenarioMapType.Multiplayer)
                        {
                            var sbsp = CacheContext.Deserialize<ScenarioStructureBsp>(cacheStream, scnr.StructureBsps[0].StructureBsp);

                            createPrematchCamera = true;
                            position = new RealPoint3d(
                                (sbsp.WorldBoundsX.Lower + sbsp.WorldBoundsX.Upper) / 2.0f,
                                (sbsp.WorldBoundsY.Lower + sbsp.WorldBoundsY.Upper) / 2.0f,
                                (sbsp.WorldBoundsZ.Lower + sbsp.WorldBoundsZ.Upper) / 2.0f);
                            orientation = new RealEulerAngles3d(scnr.LocalNorth, Angle.FromDegrees(0.0f), Angle.FromDegrees(0.0f));
                        }
                        break;
                }
            }

            if (createPrematchCamera)
                scnr.CutsceneCameraPoints = new List<Scenario.CutsceneCameraPoint>() { MultiplayerPrematchCamera(position, orientation) };
        }

        /// <summary>
        /// Given the position and the yaw/pitch given by the camera coordinates, create a CutsceneCameraPoint block. Note that roll is always 0 in the coordinates.
        /// </summary>
        public Scenario.CutsceneCameraPoint MultiplayerPrematchCamera(RealPoint3d position, RealEulerAngles3d orientation)
        {
            var camera = new Scenario.CutsceneCameraPoint()
            {
                Flags = Scenario.CutsceneCameraPointFlags.PrematchCameraHack,
                Type = Scenario.CutsceneCameraPointType.Normal,
                Name = "prematch_camera",
                Position = position,
                Orientation = orientation

            };
            return camera;
        }

        public int GenerateScenarioMapId(Stream cacheStream) 
        {
            Random rng = new Random();

            const int kMinMapId = 7000;
            const int kMaxMapId = ushort.MaxValue - 1;

            var usedIds = new HashSet<int>(CacheContext.TagCache.FindAllInGroup("scnr")
                .Where(tag => !(tag as CachedTagHaloOnline).IsEmpty())
                .Select(tag => CacheContext.Deserialize<Scenario>(cacheStream, tag))
                .Select(scnr => scnr.MapId));

            while (true)
            {
                int candidateId = rng.Next(kMinMapId, kMaxMapId);

                if (!usedIds.Contains(candidateId))
                    return candidateId;
            }
        }
    }
}