using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TagTool.BlamFile.Chunks;
using TagTool.BlamFile.Chunks.MapVariants;
using TagTool.BlamFile.Chunks.Megalo;
using TagTool.BlamFile.Chunks.Metadata;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.Common.Logging;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using TagTool.Tags.Definitions.Common;
using static TagTool.Tags.Definitions.Scenario;

namespace TagTool.BlamFile
{
    public class ReachMapVariantGenerator
    {
        private ReachMapVariant SourceMapVariant;
        private List<string> MegaloStrings;

        public HashSet<string> ExcludedMegaloLabels = new HashSet<string>();
        public HashSet<string> ExcludedTags = new HashSet<string>();
        public Dictionary<string, string> SubstitutedTags = new Dictionary<string, string>();

        public Blf Convert(Scenario sourceScenario, ReachMapVariant sourceBlf)
        {
            SourceMapVariant = sourceBlf;
            MegaloStrings = SingleLanguageStringTable.GetStrings(sourceBlf.StringTable);

            Console.WriteLine($"Converting Reach map variant`{SourceMapVariant.Metadata.Name}`...");

            var metadata = ConvertMetadata(SourceMapVariant);
            var mapVariant = ConvertMapVariant(SourceMapVariant, sourceScenario, out List<string> tagNames);
            mapVariant.Metadata = metadata;
            return GenerateBlf(mapVariant, tagNames);
        }

        private ContentItemMetadata ConvertMetadata(ReachMapVariant sourceMapVariant)
        {
            var metadata = new ContentItemMetadata();
            metadata.Name = sourceMapVariant.Metadata.Name;
            metadata.Description = sourceMapVariant.Metadata.Description;
            metadata.GameId = sourceMapVariant.Metadata.GameId;
            metadata.ContentType = ContentItemMetadata.ContentItemType.Usermap;
            metadata.ContentSize = typeof(BlfMapVariant).GetSize();
            metadata.GameEngineType = GameEngineType.None;
            metadata.MapId = sourceMapVariant.MapId;
            metadata.UniqueId = sourceMapVariant.Metadata.UniqueId;

            if (sourceMapVariant.Metadata.ModificationHistory.Timestamp >= sourceMapVariant.Metadata.CreationHistory.Timestamp)
                SetAuthorInfo(sourceMapVariant.Metadata.ModificationHistory);
            else
                SetAuthorInfo(sourceMapVariant.Metadata.CreationHistory);

            void SetAuthorInfo(ReachContentItemMetadata.ContentItemAuthor history)
            {
                metadata.Author = history.Author;
                metadata.AuthorId = history.AuthorId;
                metadata.Timestamp = history.Timestamp;
            }

            return metadata;
        }

        private MapVariant ConvertMapVariant(ReachMapVariant sourceMapVariant, Scenario sourceScenario, out List<string> destTagNames)
        {
            var result = new MapVariant();
            result.VariantVersion = 12;
            result.MapId = sourceMapVariant.MapId;
            result.WorldBounds = sourceMapVariant.WorldBounds;
            result.MaximumBudget = sourceMapVariant.MaximumBudget;
            result.SpentBudget = sourceMapVariant.SpentBudget;
            result.OriginalMapRSASignatureHash = sourceMapVariant.OriginalMapRSASignatureHash;

            var objectTypeMap = new ObjectTypeMap(sourceScenario);
            result.ObjectTypeStartIndex = objectTypeMap.CalculateObjetTypeStartIndices();
            result.ScenarioObjectCount = result.ObjectTypeStartIndex.Max();
            result.VariantObjectCount = result.ScenarioObjectCount;

            result.Objects = new VariantObjectDatum[640];
            result.Quotas = new VariantObjectQuota[256];

            for (int i = 0; i < result.Quotas.Length; i++)
                result.Quotas[i] = new VariantObjectQuota();

            for (int i = 0; i < result.ScenarioObjectCount; i++)
                result.Objects[i] = new VariantObjectDatum() { Flags = VariantObjectDatum.VariantObjectPlacementFlags.ScenarioObject | VariantObjectDatum.VariantObjectPlacementFlags.ScenarioObjectRemoved };
               
            var quotaBuilder = new VariantQuotaBuilder();
            for (int i = 0; i < sourceMapVariant.Objects.Length; i++)
            {
                if (result.VariantObjectCount >= 640)
                {
                    Log.Warning($"Map variant object limit reached!");
                    break;
                }

                var reachVariantObject = sourceMapVariant.Objects[i];
                if (!reachVariantObject.Flags.HasFlag(ReachVariantObjectDatum.ObjectPlacementFlags.OccupiedSlot))
                    continue;

                if (reachVariantObject.SpawnRelativeToIndex != -1)
                    Log.Warning("Relative placement found. Not currently supported!");

                var reachQuota = sourceMapVariant.Quotas[reachVariantObject.QuotaIndex];

                var paletteEntry = GetPaletteEntry(sourceScenario, reachVariantObject.QuotaIndex);
                var sourceObjectTag = paletteEntry.Variants[reachVariantObject.VariantIndex].Object;
                if (ExcludedTags.Contains($"{sourceObjectTag.Name}.{ sourceObjectTag.Group.Tag}"))
                {
                    Console.WriteLine($"Deleted placement #{i} due to tag '{sourceObjectTag}'");
                    continue;
                }        

                if(reachVariantObject.Properties.LabelIndex != -1)
                {
                    var megaloLabel = MegaloStrings[reachVariantObject.Properties.LabelIndex];
                    if (ExcludedMegaloLabels.Contains(megaloLabel))
                    {
                        Console.WriteLine($"Deleted placement #{i} due to megalo label '{megaloLabel}'");
                        continue;
                    } 
                }

                var variantObject = ConvertVariantObject(reachVariantObject);
                result.Objects[result.VariantObjectCount++] = variantObject;

                var newQuotaIndex = quotaBuilder.FindObject(sourceObjectTag);
                if (newQuotaIndex == -1)
                {
                    newQuotaIndex = quotaBuilder.AddObject(sourceObjectTag);
                    var newQuota = quotaBuilder[newQuotaIndex];
                    newQuota.Tag = sourceObjectTag;
                    newQuota.MaxAllowed = paletteEntry.MaximumAllowed;
                    newQuota.MinimumCount = reachQuota.MinimumCount;
                    newQuota.MaximumCount = reachQuota.MaximumCount;
                }

                var quota = quotaBuilder[newQuotaIndex];
                quota.PlacedOnMap++;
                variantObject.QuotaIndex = newQuotaIndex;
            }

            for (int i = 0; i < quotaBuilder.Count; i++)
            {
                result.Quotas[i].ObjectDefinitionIndex = 0;
                result.Quotas[i].MaximumCount = (byte)quotaBuilder[i].MinimumCount;
                result.Quotas[i].MaximumCount = (byte)quotaBuilder[i].MaximumCount;
                result.Quotas[i].PlacedOnMap = (byte)quotaBuilder[i].PlacedOnMap;
                result.Quotas[i].MaxAllowed = (sbyte)quotaBuilder[i].MaxAllowed;
                // result.PlaceableQuotaCount++;
            }

            destTagNames = new List<string>();
            for(int i = 0; i < quotaBuilder.Count; i++)
            {
                var quota = quotaBuilder[i];
                var name = $"{quota.Tag.Name}.{quota.Tag.Group.Tag}";
                if (SubstitutedTags.TryGetValue(name, out string sub))
                {
                    Console.WriteLine($"Substituted {name} -> {sub}");
                    name = sub;
                }

                destTagNames.Add(name);
            }

            return result;
        }

        private static Blf GenerateBlf(MapVariant mapVariant, IList<string> tagnames)
        {
            var blf = new Blf(CacheVersion.HaloOnlineED, CachePlatform.Original);

            blf.StartOfFile = new BlfChunkStartOfFile()
            {
                Signature = new Tag("_blf"),
                Length = (int)TagStructure.GetStructureSize(typeof(BlfChunkStartOfFile), blf.Version, blf.CachePlatform),
                MajorVersion = 1,
                MinorVersion = 2,
                ByteOrderMark = -2
            };
            blf.ContentFlags |= Blf.BlfFileContentFlags.StartOfFile;

            blf.ContentHeader = new BlfContentHeader()
            {
                Signature = new Tag("chdr"),
                Length = (int)TagStructure.GetStructureSize(typeof(BlfContentHeader), blf.Version, blf.CachePlatform),
                MajorVersion = 9,
                MinorVersion = 3,
                BuildVersion = -24364,
                MapMinorVersion = -1,
                Metadata = mapVariant.Metadata
            };

            blf.ContentFlags |= Blf.BlfFileContentFlags.ContentHeader;

            blf.MapVariant = new BlfMapVariant()
            {
                Signature = new Tag("mapv"),
                Length = (int)TagStructure.GetStructureSize(typeof(BlfMapVariant), blf.Version, blf.CachePlatform),
                MajorVersion = 12,
                MinorVersion = 1,
                MapVariant = mapVariant,
            };
            blf.ContentFlags |= Blf.BlfFileContentFlags.MapVariant;

            blf.MapVariantTagNames = new BlfMapVariantTagNames()
            {
                Signature = new Tag("tagn"),
                Length = (int)TagStructure.GetStructureSize(typeof(BlfMapVariantTagNames), blf.Version, blf.CachePlatform),
                MajorVersion = 1,
                MinorVersion = 0,
                Names = Enumerable.Range(0, 256).Select(x => new BlfMapVariantTagNames.TagName() { Name = "" }).ToArray()
            };
            blf.ContentFlags |= Blf.BlfFileContentFlags.MapVariantTagNames;

            blf.MapVariantTagNames.Names = new BlfMapVariantTagNames.TagName[256];
            for (int i = 0; i < tagnames.Count; i++)
                blf.MapVariantTagNames.Names[i] = new BlfMapVariantTagNames.TagName() { Name = tagnames[i] };

            blf.EndOfFile = new BlfChunkEndOfFile()
            {
                Signature = new Tag("_eof"),
                Length = (int)TagStructure.GetStructureSize(typeof(BlfChunkEndOfFile), blf.Version, blf.CachePlatform),
                MajorVersion = 1,
                MinorVersion = 1,
                AuthenticationDataSize = 0,
                AuthenticationType = BlfChunkEndOfFile.BlfAuthenticationType.None
            };
            blf.ContentFlags |= Blf.BlfFileContentFlags.EndOfFile;

            return blf;
        }

        public MapVariantPaletteBlock.MapVariantPaletteEntryBlock GetPaletteEntry(Scenario scenario, int quotaIndex)
        {
            GetPaletteIndices(scenario, quotaIndex, out int paletteIndex, out int entryIndex);
            return scenario.MapVariantPalettes[paletteIndex].Entries[entryIndex];
        }

        public bool GetPaletteIndices(Scenario scenario, int quotaIndex, out int paletteIndex, out int entryIndex)
        {
            paletteIndex = -1;
            entryIndex = -1;

            var absoluteIndex = quotaIndex;
            for (int i = 0; i < scenario.MapVariantPalettes.Count; i++)
            {
                var palette = scenario.MapVariantPalettes[i];

                if (absoluteIndex < palette.Entries.Count)
                {
                    paletteIndex = i;
                    entryIndex = absoluteIndex;
                    return true;
                }
                absoluteIndex -= palette.Entries.Count;
            }
            return false;
        }

        class VariantQuotaBuilder : IReadOnlyList<AuxVariantQuota>
        {
            private List<AuxVariantQuota> _quotas = new List<AuxVariantQuota>();
            private Dictionary<CachedTag, int> _tagToQuotaIndex = new Dictionary<CachedTag, int>();

            public AuxVariantQuota this[int index] => _quotas[index];
            public List<CachedTag> GetObjects() => _quotas.Select(x => x.Tag).ToList();
            public IReadOnlyList<AuxVariantQuota> Quotas => _quotas;

            public int Count => _quotas.Count;

            public int FindObject(CachedTag tag)
            {
                return _tagToQuotaIndex.TryGetValue(tag, out int index) ? index : -1;
            }

            public int AddObject(CachedTag tag)
            {
                var index = _quotas.Count;
                _tagToQuotaIndex.Add(tag, index);
                _quotas.Add(new AuxVariantQuota() { Tag = tag });
                return index;
            }

            public IEnumerator<AuxVariantQuota> GetEnumerator() => _quotas.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class AuxVariantQuota
        {
            public CachedTag Tag;
            public int MaxAllowed;
            public int MinimumCount;
            public int MaximumCount;
            public int MaximumAllowed = 255;
            public int PlacedOnMap;
        }


        private VariantObjectDatum ConvertVariantObject(ReachVariantObjectDatum reachObject)
        {
            var result = new VariantObjectDatum();
            result.Flags = VariantObjectDatum.VariantObjectPlacementFlags.OccupiedSlot | VariantObjectDatum.VariantObjectPlacementFlags.Edited;
            result.Position = reachObject.Position;
            result.Forward = reachObject.Forward;
            result.Up = reachObject.Up;
            result.Properties = ConvertMultiplayerProperties(reachObject.Properties);
            return result;
        }

        private VariantObjectDatum.VariantMultiplayerProperties ConvertMultiplayerProperties(ReachVariantMultiplayerObjectProperties reachProperties)
        {
            var result = new VariantObjectDatum.VariantMultiplayerProperties();

            result.EngineFlags = DetermineEngineFlags(reachProperties.LabelIndex);
            result.Flags = reachProperties.Flags.ConvertLexical<VariantObjectDatum.VariantMultiplayerProperties.VariantPlacementFlags>();
            result.Team = reachProperties.Team;
            result.SpawnTime = reachProperties.SpawnTime;
            result.Type = reachProperties.CachedType.ConvertLexical<MultiplayerObjectType>();

            switch (reachProperties.CachedType)
            {
                // TODO: Add proper handling for each object type

                case MultiplayerObjectTypeReach.Weapon:
                    result.SharedStorage = reachProperties.SharedStorage[0];
                    break;
                case MultiplayerObjectTypeReach.TeleporterTwoWay:
                case MultiplayerObjectTypeReach.TeleporterReceiver:
                case MultiplayerObjectTypeReach.TeleporterSender:
                    result.SharedStorage = reachProperties.SharedStorage[0];
                    break;
                default:
                    result.SharedStorage = reachProperties.UserData;
                    break;
            }

            result.Boundary.Type = reachProperties.Boundary.Shape;
            result.Boundary.WidthRadius = reachProperties.Boundary.WidthRadius;
            result.Boundary.BoxLength = reachProperties.Boundary.BoxLength;
            result.Boundary.PositiveHeight = reachProperties.Boundary.PositiveHeight;
            result.Boundary.NegativeHeight = reachProperties.Boundary.NegativeHeight;
            return result;
        }

        private GameEngineSubTypeFlags DetermineEngineFlags(int megaloLabelIndex)
        {
            if (megaloLabelIndex == -1)
                return GameEngineSubTypeFlags.All;

            var flags = GameEngineSubTypeFlags.TargetTraining;

            var label = MegaloStrings[megaloLabelIndex];
            switch (label)
            {
                case "as_bomb":
                case "as_goal":
                case "as_res_zone":
                case "as_res_zone_away":
                case "as_spawn":
                case "assault":
                    flags |= GameEngineSubTypeFlags.Assault;
                    break;
                case "ctf":
                case "ctf_flag_return":
                case "ctf_res_zone":
                case "ctf_res_zone_away":
                    flags |= GameEngineSubTypeFlags.CaptureTheFlag;
                    break;
                case "inf_haven":
                case "inf_spawn":
                    flags |= GameEngineSubTypeFlags.Infection;
                    break;
                case "juggernaut":
                    flags |= GameEngineSubTypeFlags.Juggernaut;
                    break;
                case "koth_hill":
                    flags |= GameEngineSubTypeFlags.KingOfTheHill;
                    break;
                case "oddball_ball":
                    flags |= GameEngineSubTypeFlags.Oddball;
                    break;
                case "slayer":
                    flags |= GameEngineSubTypeFlags.Slayer;
                    break;
                case "terr_object":
                case "territories":
                    flags |= GameEngineSubTypeFlags.Territories;
                    break;
                case "vip":
                    flags |= GameEngineSubTypeFlags.Vip;
                    break;
                default:
                    flags |= GameEngineSubTypeFlags.All;
                    break;
            }
            return flags;
        }

        class ObjectTypeMap
        {
            public Dictionary<GameObjectTypeHalo3ODST, ObjectTypeInfo> ObjectTypes
                = new Dictionary<GameObjectTypeHalo3ODST, ObjectTypeInfo>();

            public ObjectTypeMap(Scenario scenario)
            {
                ObjectTypes.Add(GameObjectTypeHalo3ODST.Vehicle, new ObjectTypeInfo(scenario.Vehicles, scenario.VehiclePalette));
                ObjectTypes.Add(GameObjectTypeHalo3ODST.Weapon, new ObjectTypeInfo(scenario.Weapons, scenario.WeaponPalette));
                ObjectTypes.Add(GameObjectTypeHalo3ODST.Equipment, new ObjectTypeInfo(scenario.Equipment, scenario.EquipmentPalette));
                ObjectTypes.Add(GameObjectTypeHalo3ODST.Scenery, new ObjectTypeInfo(scenario.Scenery, scenario.SceneryPalette));
                ObjectTypes.Add(GameObjectTypeHalo3ODST.Crate, new ObjectTypeInfo(scenario.Crates, scenario.CratePalette));
            }

            public ObjectTypeInfo this[GameObjectTypeHalo3ODST type] => ObjectTypes[type];
            public ObjectTypeInfo this[GameObjectType16 type] => ObjectTypes[ConvertObjectType(type)];

            public GameObjectTypeHalo3ODST ConvertObjectType(GameObjectType16 objectType)
            {
                int index = (int)objectType.Halo3Retail;
                if (objectType.Halo3Retail > GameObjectTypeHalo3Retail.Equipment)
                    index++;

                return (GameObjectTypeHalo3ODST)index;
            }

            public short[] CalculateObjetTypeStartIndices()
            {
                var indices = new short[16];
                for (int i = 0; i < 16; i++)
                    indices[i] = -1;

                int placementCount = 0;
                foreach (var type in ObjectTypes)
                {
                    indices[(int)type.Key] = (short)placementCount;
                    placementCount += type.Value.Placements.Count;
                }
                return indices;
            }
        }

        class ObjectTypeInfo
        {
            public List<ScenarioInstance> Placements;
            public List<ScenarioPaletteEntry> Palette;

            public ObjectTypeInfo(IList placements, IList palette)
            {
                Placements = placements.Cast<ScenarioInstance>().ToList();
                Palette = palette.Cast<ScenarioPaletteEntry>().ToList();
            }
        }
    }
}
