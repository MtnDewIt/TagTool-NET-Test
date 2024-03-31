using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.Commands.Common;
using TagTool.Tags;
using System.Collections;
using TagTool.Tags.Definitions.Common;
using TagTool.Common;
using System.Linq;
using System;

namespace TagTool.MtnDewIt.BlamFiles
{
    public class MapVariantDataGenerator 
    {
        private GameCache Cache;
        private Scenario Scnr;
        private ScenarioStructureBsp Sbsp;
        private Stream Stream;
        private ForgeGlobalsDefinition Forg;
        private HashSet<CachedTag> ForgePalette;
        private bool LegacyPalette = false;

        public Dictionary<GameObjectTypeHalo3ODST, ScenarioObjectTypeDefinition> ObjectTypes;

        public BlfData GenerateData(Stream stream, GameCache cache, Scenario scnr, BlfContentItemMetadata metadata, HashSet<CachedTag> palette) 
        {
            Cache = cache;
            Stream = stream;
            Scnr = scnr;
            Sbsp = cache.Deserialize<ScenarioStructureBsp>(stream, scnr.StructureBsps[0].StructureBsp);

            if (palette == null)
            {
                Forg = cache.Deserialize<ForgeGlobalsDefinition>(Stream, Cache.TagCache.GetTag("*.forg"));
                ForgePalette = new HashSet<CachedTag>(Forg.Palette.Where(x => x.Object != null).Select(x => x.Object));
            }
            else 
            {
                ForgePalette = palette;
                LegacyPalette = true;
            }

            ObjectTypes = new Dictionary<GameObjectTypeHalo3ODST, ScenarioObjectTypeDefinition>()
            {
                { GameObjectTypeHalo3ODST.Vehicle, new ScenarioObjectTypeDefinition(Scnr.Vehicles, Scnr.VehiclePalette) },
                { GameObjectTypeHalo3ODST.Weapon, new ScenarioObjectTypeDefinition(Scnr.Weapons, Scnr.WeaponPalette) },
                { GameObjectTypeHalo3ODST.Equipment, new ScenarioObjectTypeDefinition(Scnr.Equipment, Scnr.EquipmentPalette) },
                { GameObjectTypeHalo3ODST.Scenery, new ScenarioObjectTypeDefinition(Scnr.Scenery, Scnr.SceneryPalette) },
                { GameObjectTypeHalo3ODST.Crate, new ScenarioObjectTypeDefinition(Scnr.Crates, Scnr.CratePalette) },
            };

            return GenerateBlfData(metadata, GenerateMapVariantData(metadata));
        }

        private BlfData GenerateBlfData(BlfContentItemMetadata metadata, MapVariantData mapVariant) 
        {
            var blf = new BlfData(Cache.Version, CachePlatform.Original);

            blf.StartOfFile = new BlfDataChunkStartOfFile()
            {
                Signature = new Tag("_blf"),
                Length = (int)TagStructure.GetStructureSize(typeof(BlfDataChunkStartOfFile), Cache.Version, Cache.Platform),
                MajorVersion = 1,
                MinorVersion = 2,
                ByteOrderMarker = -2
            };
            blf.ContentFlags |= BlfDataFileContentFlags.StartOfFile;

            blf.ContentHeader = new BlfDataContentHeader()
            {
                Signature = new Tag("chdr"),
                Length = (int)TagStructure.GetStructureSize(typeof(BlfDataContentHeader), Cache.Version, Cache.Platform),
                MajorVersion = 9,
                MinorVersion = 3,
                BuildVersion = 0xa0d4,
                MapMinorVersion = 0xffff,
                Metadata = metadata
            };

            blf.ContentFlags |= BlfDataFileContentFlags.ContentHeader;

            blf.MapVariant = new BlfDataMapVariant()
            {
                Signature = new Tag("mapv"),
                Length = (int)TagStructure.GetStructureSize(typeof(BlfDataMapVariant), Cache.Version, Cache.Platform),
                MajorVersion = 12,
                MinorVersion = 1,
                MapVariant = mapVariant,
                VariantVersion = 0
            };
            blf.ContentFlags |= BlfDataFileContentFlags.MapVariant;

            blf.MapVariantTagNames = new BlfDataMapVariantTagNames()
            {
                Signature = new Tag("tagn"),
                Length = (int)TagStructure.GetStructureSize(typeof(BlfDataMapVariantTagNames), Cache.Version, Cache.Platform),
                MajorVersion = 1,
                MinorVersion = 0,
                Names = Enumerable.Range(0, 256).Select(x => new BlfTagName() { Name = "" }).ToArray()
            };
            blf.ContentFlags |= BlfDataFileContentFlags.MapVariantTagNames;
            
            for (int i = 0; i < mapVariant.Quotas.Length; i++)
            {
                if (mapVariant.Quotas[i].ObjectDefinitionIndex == -1)
                    continue;
            
                var tag = Cache.TagCache.GetTag(mapVariant.Quotas[i].ObjectDefinitionIndex);
                blf.MapVariantTagNames.Names[i] = new BlfTagName() { Name = $"{tag.Name}.{tag.Group.Tag}" };
            }

            blf.EndOfFile = new BlfDataChunkEndOfFile()
            {
                Signature = new Tag("_eof"),
                Length = (int)TagStructure.GetStructureSize(typeof(BlfDataChunkEndOfFile), Cache.Version, Cache.Platform),
                MajorVersion = 1,
                MinorVersion = 1,
                AuthenticationDataSize = 0,
                AuthenticationType = BlfDataAuthenticationType.AuthenticationTypeNone,
            };
            blf.ContentFlags |= BlfDataFileContentFlags.EndOfFile;

            return blf;
        }

        private MapVariantData GenerateMapVariantData(BlfContentItemMetadata metadata) 
        {
            var mapVariant = CreateEmptyMapVariant(metadata);

            short scenarioDatumsOffset = 0;
            for (var objectType = GameObjectTypeHalo3ODST.Biped; objectType <= GameObjectTypeHalo3ODST.EffectScenery; objectType++)
            {
                if (ObjectTypes.TryGetValue(objectType, out ScenarioObjectTypeDefinition objectTypeDefinition))
                {
                    mapVariant.ObjectTypeStartIndex[(int)objectType] = scenarioDatumsOffset;
                    scenarioDatumsOffset += (short)objectTypeDefinition.Instances.Count;
                }
                else
                {
                    mapVariant.ObjectTypeStartIndex[(int)objectType] = -1;
                }
            }

            for (var objectType = GameObjectTypeHalo3ODST.Biped; objectType <= GameObjectTypeHalo3ODST.EffectScenery; objectType++)
            {
                if (!ObjectTypes.TryGetValue(objectType, out ScenarioObjectTypeDefinition objectTypeDefinition))
                    continue;

                var instances = objectTypeDefinition.Instances.Cast<Scenario.ScenarioInstance>().ToList();
                var palette = objectTypeDefinition.Palette.Cast<Scenario.ScenarioPaletteEntry>().ToList();

                for (int i = 0; i < instances.Count; i++)
                {
                    var instance = instances[i];
                    if (instance.PaletteIndex < 0 || instance.PaletteIndex >= palette.Count)
                        continue;

                    var paletteEntry = palette[instance.PaletteIndex];

                    if (!ObjectIsForgeable(paletteEntry.Object)) 
                    {
                        continue;
                    }

                    var mapvPaletteIndex = GetOrAddPaletteEntry(mapVariant, paletteEntry.Object);
                    if (mapvPaletteIndex < 0)
                        throw new Exception("Pallete overflow!");

                    var mapvPlacementIndex = mapVariant.ObjectTypeStartIndex[(int)objectType] + i;
                    var mapvPlacement = mapVariant.Objects[mapvPlacementIndex];

                    InitPlacement(mapvPlacement, objectType, instance, mapvPaletteIndex);

                    mapVariant.Quotas[mapvPaletteIndex].PlacedOnMap++;
                    mapVariant.Quotas[mapvPaletteIndex].MaximumCount++;
                }
            }

            mapVariant.VariantObjectCount = (short)(scenarioDatumsOffset);
            mapVariant.ScenarioObjectCount = scenarioDatumsOffset;
            mapVariant.PlaceableQuotaCount = 0;

            return mapVariant;
        }

        protected virtual int GetOrAddPaletteEntry(MapVariantData mapVariant, CachedTag tag)
        {
            var firstEmptyIndex = -1;
            for (int i = 0; i < mapVariant.Quotas.Length; i++)
            {
                if (firstEmptyIndex == -1 && mapVariant.Quotas[i].ObjectDefinitionIndex == -1)
                    firstEmptyIndex = i;

                if (mapVariant.Quotas[i].ObjectDefinitionIndex == tag.Index)
                    return i;
            }

            var paletteEntry = mapVariant.Quotas[firstEmptyIndex];
            paletteEntry.ObjectDefinitionIndex = tag.Index;
            paletteEntry.PlacedOnMap = 0;
            paletteEntry.MaximumCount = paletteEntry.PlacedOnMap;
            paletteEntry.MaxAllowed = 255;
            paletteEntry.Cost = 0;
            mapVariant.PlaceableQuotaCount++;
            return firstEmptyIndex;
        }

        private void InitPlacement(VariantDataObjectDatum mapvPlacement, GameObjectTypeHalo3ODST objectType, Scenario.ScenarioInstance instance, int mapvPaletteIndex)
        {
            var paletteEntry = ObjectTypes[objectType].Palette[instance.PaletteIndex] as Scenario.ScenarioPaletteEntry;
            var obje = Cache.Deserialize(Stream, paletteEntry.Object) as GameObject;

            mapvPlacement.Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.ScenarioObject;
            mapvPlacement.QuotaIndex = mapvPaletteIndex;
            mapvPlacement.Position = instance.Position;
            Vectors3dFromEulerAngles(instance.Rotation, out mapvPlacement.Forward, out mapvPlacement.Up);

            var multiplayerInstance = instance as Scenario.IMultiplayerInstance;

            if (multiplayerInstance != null && multiplayerInstance.Multiplayer.MapVariantParent.NameIndex != -1) 
            {
                AttachToParent(mapvPlacement, paletteEntry.Object, multiplayerInstance.Multiplayer.MapVariantParent.NameIndex);
            }

            InitMultiplayerProperties(mapvPlacement.Properties, instance, obje);

            switch (objectType)
            {
                case GameObjectTypeHalo3ODST.Crate:
                case GameObjectTypeHalo3ODST.Equipment:
                case GameObjectTypeHalo3ODST.Weapon:
                case GameObjectTypeHalo3ODST.Vehicle:
                    if (obje.MultiplayerObject[0].Type < MultiplayerObjectType.Teleporter2way) 
                    {
                        mapvPlacement.Flags |= VariantDataObjectPlacementFlags.RuntimeCandyMonitored;
                    }
                    break;
            }
        }

        private void AttachToParent(VariantDataObjectDatum mapvPlacement, CachedTag objectTag, int parentNameIndex)
        {
            if (parentNameIndex < 0 || parentNameIndex >= Scnr.ObjectNames.Count)
            {
                new TagToolWarning($"Parent object #{parentNameIndex} not found!");
                return;
            }

            var parentName = Scnr.ObjectNames[parentNameIndex];
            var parentScrnInstanceIndex = parentName.PlacementIndex;
            var parentScnrInstance = ObjectTypes[parentName.ObjectType.Halo3ODST].Instances[parentScrnInstanceIndex] as Scenario.ScenarioInstance;
            var parrentScnrPaletteEntry = ObjectTypes[parentName.ObjectType.Halo3ODST].Palette[parentScnrInstance.PaletteIndex] as Scenario.ScenarioPaletteEntry;

            mapvPlacement.ParentObject = new ObjectDataIdentifier()
            {
                BspIndex = parentScnrInstance.OriginBspIndex,
                Source = (sbyte)parentScnrInstance.Source,
                Type = (sbyte)parentScnrInstance.ObjectType.Halo3ODST,
                UniqueID = parentScnrInstance.UniqueHandle
            };

            mapvPlacement.Flags |= VariantDataObjectPlacementFlags.SpawnsRelative;

            if (ObjectIsFixedOrPhased(objectTag) && ObjectIsEarlyMover(parrentScnrPaletteEntry.Object))
            {
                mapvPlacement.Flags |= VariantDataObjectPlacementFlags.SpawnsAttached;
            }

            RealVector3d parentForward, parentUp;
            Vectors3dFromEulerAngles(parentScnrInstance.Rotation, out parentForward, out parentUp);

            var parentToChildPos = VectorFromPoints3d(parentScnrInstance.Position, mapvPlacement.Position);
            var invParentToChildPos = InverseTransformVector3d(parentForward, parentUp, parentToChildPos);
            mapvPlacement.Forward = InverseTransformVector3d(parentForward, parentUp, mapvPlacement.Forward);
            mapvPlacement.Up = InverseTransformVector3d(parentForward, parentUp, mapvPlacement.Up);
            mapvPlacement.Position = new RealPoint3d(invParentToChildPos.I, invParentToChildPos.J, invParentToChildPos.K);
        }

        private static void InitMultiplayerProperties(VariantMultiplayerProperties properties, Scenario.ScenarioInstance instance, GameObject obje)
        {
            var multiplayerInstance = instance as Scenario.IMultiplayerInstance;
            if (multiplayerInstance == null)
                return;

            var scrnMultiplayerProperties = multiplayerInstance.Multiplayer;


            var objeMultiplayerProperties = obje.MultiplayerObject[0];
            properties.SpawnTime = (byte)objeMultiplayerProperties.DefaultSpawnTime;
            properties.Type = (VariantDataMultiplayerObjectType)objeMultiplayerProperties.Type;
            properties.Boundary = new MultiplayerObjectBoundary()
            {
                Type = (VariantDataMultiplayerObjectBoundaryShape)objeMultiplayerProperties.BoundaryShape,
                NegativeHeight = objeMultiplayerProperties.BoundaryNegativeHeight,
                BoxLength = objeMultiplayerProperties.BoundaryBoxLength,
                PositiveHeight = objeMultiplayerProperties.BoundaryPositiveHeight,
                WidthRadius = objeMultiplayerProperties.BoundaryWidthRadius
            };

            if (objeMultiplayerProperties.EngineFlags != 0) 
            {
                properties.EngineFlags = (VariantDataGameEngineSubTypeFlags)objeMultiplayerProperties.EngineFlags;
            }

            //if (((scrnMultiplayerProperties.SpawnFlags >> 6) & 1) != 0)
            //    properties.MultiplayerFlags |= MultiplayerObjectFlags.Unknown;

            //else if (((scrnMultiplayerProperties.SpawnFlags >> 7) & 1) != 0)
            //    properties.MultiplayerFlags |= MultiplayerObjectFlags.PlacedAtStart;

            properties.Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric;

            if (scrnMultiplayerProperties.Symmetry == GameEngineSymmetry.Symmetric) 
            {
                properties.Flags &= ~VariantDataPlacementFlags.Asymmetric;
            }

            if (scrnMultiplayerProperties.Symmetry == GameEngineSymmetry.Asymmetric) 
            {
                properties.Flags &= ~VariantDataPlacementFlags.Symmetric;
            }

            if (scrnMultiplayerProperties.SpawnTime != 0) 
            {
                properties.SpawnTime = (byte)scrnMultiplayerProperties.SpawnTime;
            }

            properties.Team = (VariantDataMultiplayerTeamDesignator)scrnMultiplayerProperties.Team;

            if (scrnMultiplayerProperties.Shape != MultiplayerObjectBoundaryShape.None)
            {
                properties.Boundary.Type = (VariantDataMultiplayerObjectBoundaryShape)scrnMultiplayerProperties.Shape;
                properties.Boundary.NegativeHeight = scrnMultiplayerProperties.BoundaryNegativeHeight;
                properties.Boundary.PositiveHeight = scrnMultiplayerProperties.BoundaryPositiveHeight;
                properties.Boundary.WidthRadius = scrnMultiplayerProperties.BoundaryWidthRadius;
                properties.Boundary.BoxLength = scrnMultiplayerProperties.BoundaryBoxLength;
            }

            if (scrnMultiplayerProperties.EngineFlags != 0) 
            {
                properties.EngineFlags = (VariantDataGameEngineSubTypeFlags)scrnMultiplayerProperties.EngineFlags;
            }


            if (obje.ObjectType.Halo3ODST == GameObjectTypeHalo3ODST.Weapon)
            {
                properties.SharedStorage = (byte)ComputeSpareClips(properties, instance as Scenario.WeaponInstance, obje as Weapon);
            }
            else
            {
                if (scrnMultiplayerProperties.TeleporterChannel != 0)
                    properties.SharedStorage = (byte)scrnMultiplayerProperties.TeleporterChannel;
                else
                    properties.SharedStorage = (byte)multiplayerInstance.Multiplayer.SpawnOrder;
            }
        }

        private static int ComputeSpareClips(VariantMultiplayerProperties properties, Scenario.WeaponInstance instance, Weapon weap)
        {
            if (weap.Magazines.Count > 0)
            {
                var magazine = weap.Magazines[0];

                var initial = magazine.RoundsLoadedMaximum;
                var total = magazine.RoundsTotalInitial;

                if (instance.RoundsLoaded != 0) 
                {
                    initial = instance.RoundsLoaded;
                }

                if (instance.RoundsLeft != 0) 
                {
                    total = instance.RoundsLeft;
                }

                if (initial > 0) 
                {
                    return total / initial - 1;
                }
            }

            return 0;
        }

        private MapVariantData CreateEmptyMapVariant(BlfContentItemMetadata metadata)
        {
            var mapVariant = new MapVariantData();
            mapVariant.Metadata = metadata;
            mapVariant.VariantVersion = 12;
            mapVariant.ScenarioObjectCount = 0;
            mapVariant.VariantObjectCount = 0;
            mapVariant.PlaceableQuotaCount = 0;
            mapVariant.MapId = Scnr.MapId;
            mapVariant.WorldBounds = new RealRectangle3d(Sbsp.WorldBoundsX.Lower, Sbsp.WorldBoundsX.Upper, Sbsp.WorldBoundsY.Lower, Sbsp.WorldBoundsY.Upper, Sbsp.WorldBoundsZ.Lower, Sbsp.WorldBoundsZ.Upper);
            mapVariant.RuntimeEngineSubType = VariantDataGameEngineSubType.All;
            mapVariant.MaximumBudget = Scnr.SandboxBudget;
            mapVariant.SpentBudget = 0;
            mapVariant.RuntimeShowHelpers = true;
            mapVariant.Objects = Enumerable.Range(0, 640).Select(x => CreateDefaultPlacement()).ToArray();
            mapVariant.ObjectTypeStartIndex = Enumerable.Range(0, 16).Select(x => (short)0).ToArray();
            mapVariant.Quotas = Enumerable.Range(0, 256).Select(x => CreateDefaultPaletteItem()).ToArray();
            mapVariant.SimulationEntities = Enumerable.Range(0, 80).Select(x => -1).ToArray();
            return mapVariant;
        }

        private VariantDataObjectQuota CreateDefaultPaletteItem()
        {
            var quota = new VariantDataObjectQuota() 
            {
                ObjectDefinitionIndex = -1,
            };

            return quota;
        }

        private VariantDataObjectDatum CreateDefaultPlacement()
        {
            var variantObject = new VariantDataObjectDatum() 
            {
                RuntimeObjectIndex = -1,
                RuntimeEditorObjectIndex = -1,
                QuotaIndex = -1,
                Properties = new VariantMultiplayerProperties()
                {
                    EngineFlags = VariantDataGameEngineSubTypeFlags.All,
                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric
                },
                ParentObject = new ObjectDataIdentifier()
                {
                    BspIndex = -1,
                    Type = -1,
                    Source = -1,
                    UniqueID = DatumHandle.None
                }
            };

            return variantObject;
        }

        private bool ObjectIsEarlyMover(CachedTag tag)
        {
            var obje = Cache.Deserialize(Stream, tag) as GameObject;
            return obje.ObjectFlags.HasFlag(ObjectDefinitionFlags.EarlyMoverLocalizedPhysics);
        }

        public bool ObjectIsForgeable(CachedTag tag)
        {
            if (LegacyPalette)
            {
                if (ForgePalette.Contains(tag))
                {
                    return false;
                }
            }
            else 
            {
                if (!ForgePalette.Contains(tag)) 
                {
                    return false;
                }
            }

            var obje = Cache.Deserialize(Stream, tag) as GameObject;
            return obje.MultiplayerObject != null && obje.MultiplayerObject.Count > 0;
        }

        private bool ObjectIsFixedOrPhased(CachedTag tag)
        {
            var obje = Cache.Deserialize(Stream, tag) as GameObject;
            var hlmt = Cache.Deserialize<Model>(Stream, obje.Model);
            var phmo = Cache.Deserialize<PhysicsModel>(Stream, hlmt.PhysicsModel);

            foreach (var rigidBody in phmo.RigidBodies)
            {
                if (rigidBody.MotionType != PhysicsModel.RigidBody.MotionTypeValue.Fixed &&
                    rigidBody.MotionType != PhysicsModel.RigidBody.MotionTypeValue.Keyframed)
                    return false;
            }

            return true;
        }

        #region Math
        private static void Vectors3dFromEulerAngles(RealEulerAngles3d angles, out RealVector3d forward, out RealVector3d up)
        {
            float sy = (float)Math.Sin(angles.Yaw.Radians);
            float sp = (float)Math.Sin(angles.Pitch.Radians);
            float sr = (float)Math.Sin(angles.Roll.Radians);
            float cy = (float)Math.Cos(angles.Yaw.Radians);
            float cp = (float)Math.Cos(angles.Pitch.Radians);
            float cr = (float)Math.Cos(angles.Roll.Radians);

            forward = new RealVector3d(cy * cp, (sy * cr) - (sp * sr * cy), (sp * cr * cy) + (sy * sr));
            up = new RealVector3d(-sp, -(cp * sr), cp * cr);
        }

        private static RealVector3d InverseTransformVector3d(RealVector3d forward, RealVector3d up, RealVector3d vector)
        {
            var left = RealVector3d.CrossProduct(up, forward);

            return new RealVector3d
            (
                (float)((forward.J * vector.J) + (forward.I * vector.I)) + (forward.K * vector.K),
                (float)((left.J * vector.J) + (left.I * vector.I)) + (left.K * vector.K),
                (float)((up.J * vector.J) + (up.I * vector.I)) + (up.K * vector.K)
            );
        }

        private static RealVector3d VectorFromPoints3d(RealPoint3d p0, RealPoint3d p1)
        {
            return new RealVector3d(p0.X - p1.X, p0.Y - p1.Y, p0.Z - p1.Z);
        }
        #endregion

        public class ScenarioObjectTypeDefinition
        {
            public IList Instances;
            public IList Palette;

            public ScenarioObjectTypeDefinition(IList instances, IList palette)
            {
                Instances = instances;
                Palette = palette;
            }
        }

        public void CullForgeObjectsFromScenario(Scenario scenario)
        {
            var objectTypes = new Dictionary<GameObjectTypeHalo3ODST, ScenarioObjectTypeDefinition>()
            {
                { GameObjectTypeHalo3ODST.Vehicle, new ScenarioObjectTypeDefinition(scenario.Vehicles, scenario.VehiclePalette) },
                { GameObjectTypeHalo3ODST.Weapon, new ScenarioObjectTypeDefinition(scenario.Weapons, scenario.WeaponPalette) },
                { GameObjectTypeHalo3ODST.Equipment, new ScenarioObjectTypeDefinition(scenario.Equipment, scenario.EquipmentPalette) },
                { GameObjectTypeHalo3ODST.Scenery, new ScenarioObjectTypeDefinition(scenario.Scenery, scenario.SceneryPalette) },
                { GameObjectTypeHalo3ODST.Crate, new ScenarioObjectTypeDefinition(scenario.Crates, scenario.CratePalette) },
            };

            foreach (var pair in objectTypes)
            {
                var objectType = pair.Key;
                var objectTypeDef = pair.Value;

                var newInstances = new List<Scenario.ScenarioInstance>();
                var newPalette = new List<Scenario.ScenarioPaletteEntry>();
                var oldToNewInstanceMapping = new Dictionary<int, int>();

                for (int i = 0; i < objectTypeDef.Instances.Count; i++)
                {
                    var instance = objectTypeDef.Instances[i] as Scenario.ScenarioInstance;

                    if (instance.PaletteIndex == -1)
                    {
                        continue;
                    }

                    var paletteEntry = objectTypeDef.Palette[instance.PaletteIndex] as Scenario.ScenarioPaletteEntry;

                    if (LegacyPalette)
                    {
                        if (!ForgePalette.Contains(paletteEntry.Object))
                        {
                            continue;
                        }
                    }
                    else 
                    {

                        if (ForgePalette.Contains(paletteEntry.Object))
                        {
                            continue;
                        }
                    }

                    var paletteIndex = newPalette.IndexOf(paletteEntry);

                    if (paletteIndex == -1)
                    {
                        paletteIndex = newPalette.Count;
                        newPalette.Add(paletteEntry);
                    }

                    instance.PaletteIndex = (short)paletteIndex;

                    oldToNewInstanceMapping[i] = newInstances.Count;
                    newInstances.Add(instance);
                }

                objectTypeDef.Instances.Clear();

                foreach (var instance in newInstances)
                {
                    objectTypeDef.Instances.Add(instance);
                }

                objectTypeDef.Palette.Clear();

                foreach (var entry in newPalette)
                {
                    objectTypeDef.Palette.Add(entry);
                }
            }
        }

        public List<VariantDataObjectDatum> GetForgeablePlacements(MapVariantData mapVariant)
        {
            var newUserPlacements = new List<VariantDataObjectDatum>();

            for (int i = 0; i < mapVariant.Objects.Length; i++)
            {
                var placement = mapVariant.Objects[i];

                if (!placement.Flags.HasFlag(VariantDataObjectPlacementFlags.OccupiedSlot))
                {
                    continue;
                }

                var paletteEntry = mapVariant.Quotas[placement.QuotaIndex];

                if (LegacyPalette)
                {
                    if (!ForgePalette.Contains(Cache.TagCache.GetTag(paletteEntry.ObjectDefinitionIndex)))
                    {
                        newUserPlacements.Add(placement);
                    }
                }
                else
                {
                    if (ForgePalette.Contains(Cache.TagCache.GetTag(paletteEntry.ObjectDefinitionIndex)))
                    {
                        newUserPlacements.Add(placement);
                    }
                }
            }

            return newUserPlacements;
        }

        public void ConvertScenarioPlacements(MapVariantData mapVariant, IList<VariantDataObjectQuota> palette, IList<VariantDataObjectDatum> placements)
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
                placement.Flags = (placement.Flags & ~VariantDataObjectPlacementFlags.ScenarioObject) | VariantDataObjectPlacementFlags.Edited;
                paletteEntry.PlacedOnMap++;
                paletteEntry.MaximumCount++;
                mapVariant.Objects[mapVariant.VariantObjectCount++] = placement;
            }
        }
    }
}