using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using System.IO;
using System.Linq;
using TagTool.Common;
using TagTool.IO;
using TagTool.Tags.Definitions;
using TagTool.Tags;
using TagTool.Commands.Common;
using TagTool.MtnDewIt.BlamFiles;
using System;
using System.Text;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps 
{
    public abstract class MapVariantFile 
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }
        public Stream Stream { get; set; }

        public MapVariantFile(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream)
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
        }

        public void GenerateMapFile(CachedTag scnrTag, BlfData mapVariant)
        {
            MapFileData mapFileData;

            Scenario scnr = CacheContext.Deserialize<Scenario>(Stream, scnrTag);

            if (mapVariant != null)
            {
                UpdateBlfData(mapVariant, scnr);
            }

            mapFileData = GenerateMap(scnrTag, scnr, mapVariant, Cache.Endianness, Cache.Version);

            var mapFilePath = $"{Path.Combine(Cache.Directory.FullName, scnrTag.Name.Split('\\').Last())}.map";
            var mapFile = new FileInfo(mapFilePath);

            using (var stream = mapFile.Create())
            using (var writer = new EndianWriter(stream))
            {
                mapFileData.WriteData(writer);
            }
        }

        public MapFileData GenerateMap(CachedTag scnrTag, Scenario scnr, BlfData mapVariant, EndianFormat format, CacheVersion version)
        {
            var mapFile = new MapFileData();
            mapFile.Version = version;
            mapFile.CachePlatform = CachePlatform.Original;
            mapFile.EndianFormat = format;
            mapFile.MapVersion = CacheFileVersion.HaloOnline;
            var header = new CacheFileHeaderDataHaloOnline();
            header.HeaderSignature = new Tag("head");
            header.FileVersion = CacheFileVersion.HaloOnline;
            header.FileLength = 339984;
            header.Build = CacheVersionDetection.GetBuildName(version, CachePlatform.Original);

            switch (scnr.MapType)
            {
                case ScenarioMapType.MainMenu:
                    header.CacheType = CacheFileType.MainMenu;
                    break;
                case ScenarioMapType.SinglePlayer:
                    header.CacheType = CacheFileType.Campaign;
                    break;
                case ScenarioMapType.Multiplayer:
                    header.CacheType = CacheFileType.Multiplayer;
                    break;
            }

            header.SharedCacheType = CacheFileSharedType.None;
            header.Unknown1 = true;
            header.TrackedBuild = true;
            header.SharedFileFlags = 62;
            header.CreationTime = new LastModificationDate
            {
                Low = 1497946735,
                High = 30434076,
            };
            header.SharedFileTimes = new LastModificationDate[6]
            {
                new LastModificationDate
                {
                    Low = 3430487812,
                    High = 30434075,
                },
                new LastModificationDate
                {
                    Low = 3432157979,
                    High = 30434075,
                },
                new LastModificationDate
                {
                    Low = 3432157979,
                    High = 30434075,
                },
                new LastModificationDate
                {
                    Low = 3432157979,
                    High = 30434075,
                },
                new LastModificationDate
                {
                    Low = 3432157979,
                    High = 30434075,
                },
                new LastModificationDate
                {
                    Low = 3432157979,
                    High = 30434075,
                },
            };
            header.Name = scnrTag.Name.Split('\\').Last();
            header.ScenarioPath = scnrTag.Name;
            header.MinorVersion = -1;
            header.Reports = new SectionFileBounds
            {
                Offset = 13200,
                Size = 326784,
            };
            header.Author = new FileAuthor
            {
                Data = CacheFileHeaderData.SetAuthor("builder"),
            };
            header.Unknown4 = new byte[16]
            {
                0x00, 0x00, 0x00, 0x00, 0xF4, 0x17, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            };
            header.Unknown5 = 1693369567698058236;

            switch (header.Name) 
            {
                case "riverworld":
                    header.CreationTime = new LastModificationDate
                    {
                        Low = 2933940320,
                        High = 30434076,
                    };
                    header.Hash = new NetworkRequestHash
                    {
                        Data = new uint[5]
                        {
                            1369946014, 3119276595, 2058872008, 2312267805, 2476282176,
                        },
                    };
                    header.RSASignature = new RSASignature
                    {
                        Data = new ulong[32]
                        {
                            11982412396427248963, 12821017550494269063, 6185678252664358023, 13870243400537293972, 4569884276976962679, 2293515661021616961, 2372749741852090903, 484202074277084144, 15152420005417132772, 4732511044456302342,
                            9306010607843187067, 3710795090046527163, 7335441266709675033, 7615704155200547658, 16832022106235420044, 12346493210893590322, 11940124157452375977, 18243310098983525026, 16419408974482789040, 15731751471983234828,
                            13343298094685359331, 8954090367725250621, 7535810311150509833, 12136029159044059220, 1575510858770469868, 17489368772981917650, 8923097243944838928, 6025994848145208235, 14775725004376067884, 3901767960255637440,
                            2472239200460155264, 12269664069245410565,
                        },
                    };
                    break;
                case "s3d_avalanche":
                    header.CreationTime = new LastModificationDate
                    {
                        Low = 2231494,
                        High = 30434078,
                    };
                    header.Hash = new NetworkRequestHash
                    {
                        Data = new uint[5]
                        {
                            3302670585, 1887054330, 1710695593, 3857255546, 7743156,
                        },
                    };
                    header.RSASignature = new RSASignature
                    {
                        Data = new ulong[32]
                        {
                            17133532565153956360, 16663799486481064985, 2322364037841702295, 81260351799500437, 14988202767228949756, 12596050068950125094, 9748615300339622711, 6579288702574599062, 1871305779845272307, 13283135367969033269,
                            7309002712529792798, 10309779145416730796, 6505999308231071549, 9241637923190541293, 6685203361008480076, 10412801436606961760, 12755032334261713025, 17527950673382393964, 1043752230823395677, 9392268334517969855,
                            10800477958472447941, 6733351136510152557, 17040095113005187519, 7637409874780237799, 18187008101817933545, 1715759608823540219, 8497500703955205310, 8525791213293785541, 1392945670531045025, 14823424291517763047,
                            4847892605001705859, 5267559494495122427,
                        },
                    };
                    break;
                case "s3d_edge":
                    header.CreationTime = new LastModificationDate
                    {
                        Low = 1543175573,
                        High = 30434078,
                    };
                    header.Hash = new NetworkRequestHash
                    {
                        Data = new uint[5]
                        {
                            70104474, 3805660745, 454946643, 391776474, 3934069415,
                        },
                    };
                    header.RSASignature = new RSASignature
                    {
                        Data = new ulong[32]
                        {
                            15051987361609259350, 8526083260686183400, 11278999306113370670, 406109723952082387, 286696655250470985, 13765023384161662963, 8743834750584018702, 17622950246759096363, 6376536699058161353, 1725116537639745250,
                            312753303384309578, 10294766502063319219, 14834544839409606162, 15827208615170378219, 6124672500758466113, 10774807111603192941, 9123725425642595746, 6959403211978442428, 6077786613080325842, 7035384324381500029,
                            10318728582779585865, 16434737359200506549, 7049392396130832218, 2644160335329950258, 10835044558558837613, 871446742997770213, 2020279885563532889, 10710048823454293218, 9583713703554056365, 342041021728716944,
                            12297147690881461812, 9820376023417124874,
                        },
                    };
                    break;
                case "s3d_reactor":
                    header.CreationTime = new LastModificationDate
                    {
                        Low = 3451976434,
                        High = 30434078,
                    };
                    header.Hash = new NetworkRequestHash
                    {
                        Data = new uint[5]
                        {
                            28150004, 3922607544, 483552354, 357344758, 684107749,
                        },
                    };
                    header.RSASignature = new RSASignature
                    {
                        Data = new ulong[32]
                        {
                            1758715598520858578, 5134300862150356395, 1974561845948387413, 17907338088872693694, 7097083254862461363, 960101167733825421, 9361617816953490302, 9173225077653318973, 3852849465797765396, 757961163981923817,
                            15356231790792874402, 6602720735694932015, 3531886766208731025, 11062492775772500573, 11667644594344733533, 12892507291616039402, 11115814411036664971, 2746562007924041371, 8539897529106993541, 3427614727032821095,
                            12093230573790762948, 11533091234687699178, 12462200603223138289, 15540140345687868950, 8289175436900791790, 11084868119417129377, 13213480896582762603, 15693590925307569909, 15194164063780467929, 12495095205588426151,
                            9019253431598516423, 8558473570304017744,
                        },
                    };
                    break;
                case "s3d_turf":
                    header.CreationTime = new LastModificationDate
                    {
                        Low = 627756198,
                        High = 30434079,
                    };
                    header.Hash = new NetworkRequestHash
                    {
                        Data = new uint[5]
                        {
                            3383731654, 2174866070, 1452228945, 4112225116, 3054922121,
                        },
                    };
                    header.RSASignature = new RSASignature
                    {
                        Data = new ulong[32]
                        {
                            6825527482161549577, 5324003146539620450, 15487792669316237282, 7947884622914775122, 295702999939875196, 18431591247368862536, 6076433019907906666, 5701807063988731777, 4930431028135893915, 10118450440741376524,
                            18116277527125330429, 17185388788024047687, 2738101105648011746, 15949028687798068455, 15266692436134392067, 15532393873343502821, 7329051351399472100, 9347277734293129490, 11483849243424230751, 12669398807371679617,
                            13288963239654809057, 9213841734407051731, 3268993512034670807, 17524759682550285352, 4588828072362826496, 13947492785470262343, 11256453041303655779, 15698844589758300667, 13855601795051122718, 11109419569242631129,
                            188144829127114352, 7556508124801713170,
                        },
                    };
                    break;
                default:
                    header.CreationTime = new LastModificationDate
                    {
                        Low = 1497946735,
                        High = 30434076,
                    };
                    header.Hash = new NetworkRequestHash
                    {
                        Data = new uint[5]
                        {
                            1961340354, 592528155, 1389252821, 3333181734, 1566121884,
                        },
                    };
                    header.RSASignature = new RSASignature
                    {
                        Data = new ulong[32]
                        {
                            1364809335882665978, 18269941122795469082, 2319919015463633988, 13969155041126813317, 17749661851250191155, 14491492943073825341, 11596070317558956623, 9760198012812704706, 9634784248627116922, 1404523416097737799,
                            9307505579238429194, 10455571150539799640, 7613048112384907601, 17000443677961962225, 11380724319532577381, 17286549536402711991, 12546782975187070652, 17110958633532790604, 873542523889005935, 979720889357273377,
                            15310101141997071761, 656951351936697696, 11251395024336835301, 12426984508257679424, 17356562460000330802, 17485407345886496508, 11999317062900749281, 9944307177821876249, 15561861088235611244, 13950092135888117847,
                            11407002650072343604, 5738198808858687009,
                        },
                    };
                    break;
            };
            header.SectionOffsets = new int[4]
            {
                0, 0, 0, 0,
            };
            header.OriginalSectionBounds = new SectionFileBounds[4]
            {
                new SectionFileBounds
                {
                    Offset = 13200,
                    Size = 326784,
                },
                new SectionFileBounds
                {
                    Offset = 13200,
                    Size = 0,
                },
                new SectionFileBounds
                {
                    Offset = 13200,
                    Size = 0,
                },
                new SectionFileBounds
                {
                    Offset = -1,
                    Size = 0,
                },
            };
            header.MapId = scnr.MapId;
            header.ScenarioTagIndex = scnrTag.Index;
            header.FooterSignature = new Tag("foot");
            mapFile.Header = header;
            mapFile.MapFileBlf = mapVariant;
            return mapFile;
        }

        public void UpdateBlfData(BlfData mapVariant, Scenario scnr)
        {
            mapVariant.StartOfFile.Signature = new Tag(InvertString(mapVariant.StartOfFile.Signature.ToString()));
            mapVariant.StartOfFile.Length = InvertInt(mapVariant.StartOfFile.Length);
            mapVariant.StartOfFile.MajorVersion = InvertShort(mapVariant.StartOfFile.MajorVersion);
            mapVariant.StartOfFile.MinorVersion = InvertShort(mapVariant.StartOfFile.MinorVersion);
            mapVariant.StartOfFile.ByteOrderMarker = InvertShort(mapVariant.StartOfFile.ByteOrderMarker);

            mapVariant.Scenario.Signature = new Tag(InvertString(mapVariant.Scenario.Signature.ToString()));
            mapVariant.Scenario.Length = InvertInt(mapVariant.Scenario.Length);
            mapVariant.Scenario.MajorVersion = InvertShort(mapVariant.Scenario.MajorVersion);
            mapVariant.Scenario.MinorVersion = InvertShort(mapVariant.Scenario.MinorVersion);

            mapVariant.MapVariant.Signature = new Tag(InvertString(mapVariant.MapVariant.Signature.ToString()));
            mapVariant.MapVariant.Length = InvertInt(mapVariant.MapVariant.Length);
            mapVariant.MapVariant.MajorVersion = InvertShort(mapVariant.MapVariant.MajorVersion);
            mapVariant.MapVariant.MinorVersion = InvertShort(mapVariant.MapVariant.MinorVersion);

            if (mapVariant.MapVariant.MapVariant.Objects != null) 
            {
                for (int i = 0; i < mapVariant.MapVariant.MapVariant.Objects.Length; i++)
                {
                    var variantObject = mapVariant.MapVariant.MapVariant.Objects[i];

                    if (variantObject.QuotaIndex == -1)
                    {
                        if (variantObject.Properties == null)
                        {
                            variantObject.Properties = new VariantMultiplayerProperties();
                        }

                        if (variantObject.Properties.Team != (VariantDataMultiplayerTeamDesignator)9)
                        {
                            variantObject.Properties.EngineFlags = VariantDataGameEngineSubTypeFlags.None;
                            variantObject.Properties.Team = VariantDataMultiplayerTeamDesignator.None;
                            variantObject.Properties.Type = VariantDataMultiplayerObjectType.None;
                        }
                    }
                }

                mapVariant.MapVariant.MapVariant.VariantObjectCount = GetVariantObjectCount(mapVariant.MapVariant.MapVariant);
            }

            if (mapVariant.MapVariant.MapVariant.Quotas != null) 
            {
                for (int i = 0; i < mapVariant.MapVariant.MapVariant.Quotas.Length; i++)
                {
                    var quota = mapVariant.MapVariant.MapVariant.Quotas[i];

                    if (quota.ObjectDefinitionIndex == -1)
                    {
                        quota.MaxAllowed = 0;
                        quota.Cost = -1f;
                    }
                    else
                    {
                        quota.MaxAllowed = 255;

                        if (quota.Cost != -1f)
                        {
                            quota.Cost = 0f;
                        }
                    }
                }

                mapVariant.MapVariant.MapVariant.PlaceableQuotaCount = GetVariantObjectCount(mapVariant.MapVariant.MapVariant);
            }

            if (mapVariant.MapVariant.MapVariant.ObjectTypeStartIndex != null) 
            {
                mapVariant.MapVariant.MapVariant.ScenarioObjectCount = GetScenarioObjectCount(mapVariant.MapVariant.MapVariant, scnr);
            }

            mapVariant.EndOfFile.Signature = new Tag(InvertString(mapVariant.EndOfFile.Signature.ToString()));
            mapVariant.EndOfFile.Length = InvertInt(mapVariant.EndOfFile.Length);
            mapVariant.EndOfFile.MajorVersion = InvertShort(mapVariant.EndOfFile.MajorVersion);
            mapVariant.EndOfFile.MinorVersion = InvertShort(mapVariant.EndOfFile.MinorVersion);
        }

        public short GetScenarioObjectCount(MapVariantData mapVariant, Scenario scnr)
        {
            var scenarioObjectTypes = new Dictionary<GameObjectTypeHalo3ODST, MapVariantDataGenerator.ScenarioObjectTypeDefinition>()
            {
                { GameObjectTypeHalo3ODST.Vehicle, new MapVariantDataGenerator.ScenarioObjectTypeDefinition(scnr.Vehicles, scnr.VehiclePalette) },
                { GameObjectTypeHalo3ODST.Weapon, new MapVariantDataGenerator.ScenarioObjectTypeDefinition(scnr.Weapons, scnr.WeaponPalette) },
                { GameObjectTypeHalo3ODST.Equipment, new MapVariantDataGenerator.ScenarioObjectTypeDefinition(scnr.Equipment, scnr.EquipmentPalette) },
                { GameObjectTypeHalo3ODST.Scenery, new MapVariantDataGenerator.ScenarioObjectTypeDefinition(scnr.Scenery, scnr.SceneryPalette) },
                { GameObjectTypeHalo3ODST.Crate, new MapVariantDataGenerator.ScenarioObjectTypeDefinition(scnr.Crates, scnr.CratePalette) },
            };

            short scenarioDatumsOffset = 0;
            for (var objectType = GameObjectTypeHalo3ODST.Biped; objectType <= GameObjectTypeHalo3ODST.EffectScenery; objectType++)
            {
                if (scenarioObjectTypes.TryGetValue(objectType, out MapVariantDataGenerator.ScenarioObjectTypeDefinition objectTypeDefinition))
                {
                    mapVariant.ObjectTypeStartIndex[(int)objectType] = scenarioDatumsOffset;
                    scenarioDatumsOffset += (short)objectTypeDefinition.Instances.Count;
                }
                else
                {
                    mapVariant.ObjectTypeStartIndex[(int)objectType] = -1;
                }
            }

            return scenarioDatumsOffset;
        }

        public short GetVariantObjectCount(MapVariantData mapVariant)
        {
            short count = 0;
            
            for (int i = mapVariant.Objects.Length - 1; i >= 0; i--)
            {
                var variantObject = mapVariant.Objects[i];
            
                if (variantObject.QuotaIndex == -1)
                {
                    count++;
                }
                else 
                {
                    break;
                }
            }
            
            return (short)(mapVariant.Objects.Length - count);
        }

        public short GetPlaceableQuotaCount(MapVariantData mapVariant)
        {
            short count = 0;
            
            for (int i = mapVariant.Quotas.Length - 1; i >= 0; i--)
            {
                var quota = mapVariant.Quotas[i];
            
                if (quota.ObjectDefinitionIndex == -1)
                {
                    count++;
                }
                else 
                {
                    break;
                }
            }
            
            return (short)(mapVariant.Quotas.Length - count);
        }

        private string InvertString(string value)
        {
            byte[] data = Encoding.UTF8.GetBytes(value);

            Array.Reverse(data);

            return Encoding.UTF8.GetString(data);
        }

        private int InvertInt(int value)
        {
            byte[] data = BitConverter.GetBytes(value);

            Array.Reverse(data);

            return BitConverter.ToInt32(data, 0);
        }

        private short InvertShort(short value)
        {
            byte[] data = BitConverter.GetBytes(value);

            Array.Reverse(data);

            return BitConverter.ToInt16(data, 0);
        }

        public void GenerateMapVariant(CachedTag tag, BlfData mapVariant)
        {
            var scenario = Cache.Deserialize<Scenario>(Stream, tag);

            var culledObjects = new HashSet<CachedTag>() 
            {
                GetCachedTag<Crate>($@"objects\levels\dlc\chillout\teleporter_2way\teleporter_2way"),
                GetCachedTag<Crate>($@"objects\levels\dlc\chillout\teleporter_reciever\teleporter_reciever"),
                GetCachedTag<Crate>($@"objects\levels\dlc\chillout\teleporter_sender\teleporter_sender"),
                GetCachedTag<Crate>($@"objects\levels\dlc\descent\base_gravlift_descent\base_gravlift_descent"),
                GetCachedTag<Crate>($@"objects\levels\dlc\descent\base_gravlift_descent_yellow\base_gravlift_descent_yellow"),
                GetCachedTag<Crate>($@"objects\levels\dlc\descent\egg_shield\egg_shield"),
                GetCachedTag<Crate>($@"objects\levels\dlc\descent\man_cannon_descent\man_cannon_descent"),
                GetCachedTag<Crate>($@"objects\levels\dlc\lockout\lift_interior\lift_interior"),
                GetCachedTag<Crate>($@"objects\levels\dlc\midship\middle_physics_volume\middle_physics_volume"),
                GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\teleporter_2way_sandbox"),
                GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\lift_sidewinder\lift_sidewinder"),
                GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_01\man_cannon_sidewinder_01"),
                GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_02\man_cannon_sidewinder_02"),
                GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_03\man_cannon_sidewinder_03"),
                GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_04\man_cannon_sidewinder_04"),
                GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_05\man_cannon_sidewinder_05"),
                GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_06\man_cannon_sidewinder_06"),
                GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_07\man_cannon_sidewinder_07"),
                GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_08\man_cannon_sidewinder_08"),
                GetCachedTag<Crate>($@"objects\levels\multi\chill\man_cannon_chill\man_cannon_chill"),
                GetCachedTag<Crate>($@"objects\levels\multi\construct\construct_lift_lg\construct_lift_lg"),
                GetCachedTag<Crate>($@"objects\levels\multi\construct\construct_lift_sm\construct_lift_sm"),
                GetCachedTag<Crate>($@"objects\levels\multi\cyberdyne\cyber_pad\cyber_pad"),
                GetCachedTag<Crate>($@"objects\levels\multi\cyberdyne\cyber_pad\cyber_pad_midship"),
                GetCachedTag<Crate>($@"objects\levels\multi\guardian\man_cannon_guardian_ii\man_cannon_guardian_ii"),
                GetCachedTag<Crate>($@"objects\levels\multi\isolation\isolation_lift_curve\isolation_lift_curve"),
                GetCachedTag<Crate>($@"objects\levels\multi\isolation\launch_tube\launch_tube"),
                GetCachedTag<Crate>($@"objects\levels\multi\isolation\launch_tube_opp\launch_tube_opp"),
                GetCachedTag<Crate>($@"objects\levels\multi\riverworld\man_cannon_river\man_cannon_river"),
                GetCachedTag<Crate>($@"objects\levels\multi\s3d_lockout\s3d_lockout_lift\s3d_lockout_lift"),
                GetCachedTag<Crate>($@"objects\levels\multi\s3d_sky_bridgenew\man_cannon_bridge\man_cannon_bridge"),
                GetCachedTag<Crate>($@"objects\levels\multi\s3d_sky_bridgenew\man_cannon_skybridge\man_cannon_skybridge"),
                GetCachedTag<Crate>($@"objects\levels\multi\s3d_sky_bridgenew\man_cannon_skybridge_new\man_cannon_skybridge_new"),
                GetCachedTag<Crate>($@"objects\levels\multi\s3d_sky_bridgenew\s3d_sky_bridge_lift\sky_bridge"),
                GetCachedTag<Crate>($@"objects\levels\multi\s3d_waterfall\cyber_pad\cyber_pad"),
                GetCachedTag<Crate>($@"objects\levels\multi\s3d_waterfall\man_cannon_waterfall_2\man_cannon_waterfall_2"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\grav_platform\grav_platform"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\holo_panel_01\holo_panel_01"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\holo_panel_02\holo_panel_02"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\holo_panel_03\holo_panel_03"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\holy_jump_pad\holy_jump_pad"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\holy_light_main\holy_light_main"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\holy_light_side\holy_light_side"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\jittery_holo\jittery_holo"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\jittery_holo_01\jittery_holo_01"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\jittery_holo_02\jittery_holo_02"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\jittery_holo_03\jittery_holo_03"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\jittery_holo_04\jittery_holo_04"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\jittery_holo_05\jittery_holo_05"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\platform_volume\platform_volume"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\small_field\small_field"),
                GetCachedTag<Crate>($@"objects\levels\multi\shrine\sand_jump_pad\sand_jump_pad"),
                GetCachedTag<Crate>($@"objects\levels\solo\060_floodship\flood_danglers\large_dangler\large_dangler"),
                GetCachedTag<Crate>($@"objects\levels\solo\060_floodship\flood_danglers\small_dangler\small_dangler"),
                GetCachedTag<Scenery>($@"levels\dlc\descent\sky\scarab_inc\scarab_inc"),
                GetCachedTag<Scenery>($@"levels\dlc\docks\sky\aircraft_carrier\aircraft_carrier"),
                GetCachedTag<Scenery>($@"levels\dlc\midship\sky\spacedust"),
                GetCachedTag<Scenery>($@"levels\solo\070_waste\sky\waterfall\waterfall"),
                GetCachedTag<Scenery>($@"objects\gear\human\industrial\man_cannon_01\man_cannon_01"),
                GetCachedTag<Scenery>($@"objects\gear\human\industrial\man_cannon_02\man_cannon_02"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\armory\bulb_flicker\bulb_flicker"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\armory\industrial_vent_large\industrial_vent_large"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\chillout\flood_tank\flood_tank"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\descent\egg_shield\egg_shield"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\descent\holo_panel_script1\holo_panel_script1"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\descent\holo_panel_script_yellow\holo_panel_script_yellow"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\docks\decal_holiday_3\decal_holiday_3"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\docks\decal_holiday_\decal_holiday_"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\docks\decal_holiday_menu\decal_holiday_menu"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\docks\security_red_light\security_red_light"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\docks\speaker\speaker_sound"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\ghosttown\god_ray_small\god_ray_small"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\lockout\celltower\celltower"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\lockout\celltower_simple\celltower_simple"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\lockout\core_shelf\core_shelf"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\lockout\h_locker_closed"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\lockout\windcups\windcups"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\lockout\windsock\windsock"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\lockout\z_poop_cover\z_poop_cover"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\midship\base_floor\base_floor"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\midship\base_floor_red\base_floor_red"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\midship\cov_capital_ship\cov_capital_ship"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\midship\cov_cruiser\cov_cruiser"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\midship\jump_pad\jump_pad"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\midship\jump_pad_mirror\jump_pad_mirror"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\sandbox\grid\grid"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\flag_waver_blue\flag_waver_blue"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\flag_waver_red\flag_waver_red"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\space_ad_blue\space_ad_blue"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\space_ad_red\space_ad_red"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\space_door_small\space_door_small"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\space_lamp2\space_lamp2"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\space_lamp\space_lamp"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\space_rays\space_rays"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\spacecamp_collision_hall_lower\spacecamp_collision_hall_lower"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\spacecamp_collision_hall_upper\spacecamp_collision_hall_upper"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\spacecamp_collision_lobase_backedge\spacecamp_collision_lobase_backedge"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\spacecamp_collision_ramp\spacecamp_collision_ramp"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\spacecamp_welcome\spacecamp_welcome"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\warehouse\security_yellow_light\security_yellow_light"),
                GetCachedTag<Scenery>($@"objects\levels\multi\isolation\isolation_collision_walls\isolation_collision_walls"),
                GetCachedTag<Scenery>($@"objects\levels\multi\s3d_lockout\s3d_lockout_lift_visual\s3d_lockout_lift_visual"),
                GetCachedTag<Scenery>($@"objects\levels\multi\s3d_sky_bridge\man_cannon\man_cannon"),
                GetCachedTag<Scenery>($@"objects\levels\multi\s3d_waterfall\longsword_waterfall\longsword_waterfall"),
                GetCachedTag<Scenery>($@"objects\levels\multi\salvation\altar_holo\altar_holo"),
                GetCachedTag<Scenery>($@"objects\levels\multi\salvation\holo_panel_01\holo_panel_01"),
                GetCachedTag<Scenery>($@"objects\levels\multi\salvation\holo_panel_02\holo_panel_02"),
                GetCachedTag<Scenery>($@"objects\levels\multi\salvation\holo_panel_03\holo_panel_03"),
                GetCachedTag<Scenery>($@"objects\levels\multi\snowbound\airlock_field\airlock_field"),
                GetCachedTag<Scenery>($@"objects\levels\multi\snowbound\airlock_field_cave\airlock_field_cave"),
                GetCachedTag<Scenery>($@"objects\levels\multi\snowbound\airlock_field_lg\airlock_field_lg"),
                GetCachedTag<Scenery>($@"objects\levels\multi\snowbound\cov_defender_mon\cov_defender_mon"),
                GetCachedTag<Scenery>($@"objects\levels\solo\040_voi\voi_door_warehouse_door_a\voi_door_warehouse_door_a"),
                GetCachedTag<Scenery>($@"objects\levels\solo\060_floodship\floodball_pulsing\floodball_pulsing"),
                GetCachedTag<Scenery>($@"objects\levels\solo\060_floodship\floodball_pulsing\floodball_pulsing_isolation"),
                GetCachedTag<Scenery>($@"objects\levels\solo\110_hc\god_rays\god_rays"),
                GetCachedTag<Scenery>($@"objects\levels\solo\110_hc\god_rays_blue\god_rays_blue"),
                GetCachedTag<Scenery>($@"objects\levels\solo\110_hc\god_rays_long\god_rays_long"),
                GetCachedTag<Scenery>($@"objects\multi\spawning\respawn_point_invisible"),
                GetCachedTag<Scenery>($@"objects\multi\test\player_spawn"),
                GetCachedTag<Scenery>($@"objects\vehicles\hornet\hornet_waterfall"),
                GetCachedTag<Scenery>($@"objects\vehicles\longsword\longsword"),
                GetCachedTag<Scenery>($@"objects\vehicles\pelican\pelican_parked\pelican_parked"),
                GetCachedTag<Scenery>($@"objects\vehicles\pelican\pelican_waterfall"),
                GetCachedTag<Vehicle>($@"objects\levels\dlc\chillout\monitor\monitor"),
                GetCachedTag<Vehicle>($@"objects\levels\dlc\sandbox\sandbox_defender\sandbox_defender"),
                GetCachedTag<Vehicle>($@"objects\levels\multi\cyberdyne\security_camera\security_camera"),
                GetCachedTag<Vehicle>($@"objects\levels\multi\s3d_sky_bridge\hornet_lite\hornet_lite"),
                GetCachedTag<Vehicle>($@"objects\levels\multi\snowbound\cov_defender\cov_defender"),
            };

            var generator = new MapVariantDataGenerator();

            var oldBlf = generator.GenerateData(Stream, Cache, scenario, mapVariant.MapVariant.MapVariant.Metadata, culledObjects);

            var newUserPlacements = generator.GetForgeablePlacements(oldBlf.MapVariant.MapVariant);

            generator.CullForgeObjectsFromScenario(scenario);

            var blf = generator.GenerateData(Stream, Cache, scenario, mapVariant.MapVariant.MapVariant.Metadata, culledObjects);

            generator.ConvertScenarioPlacements(blf.MapVariant.MapVariant, oldBlf.MapVariant.MapVariant.Quotas, newUserPlacements);

            mapVariant.MapVariant.MapVariant.ScenarioObjectCount = GetScenarioObjectCount(blf.MapVariant.MapVariant, scenario);
            mapVariant.MapVariant.MapVariant.VariantObjectCount = GetVariantObjectCount(blf.MapVariant.MapVariant);
            mapVariant.MapVariant.MapVariant.PlaceableQuotaCount = GetPlaceableQuotaCount(blf.MapVariant.MapVariant);
            mapVariant.MapVariant.MapVariant.Objects = blf.MapVariant.MapVariant.Objects;
            mapVariant.MapVariant.MapVariant.ObjectTypeStartIndex = blf.MapVariant.MapVariant.ObjectTypeStartIndex;
            mapVariant.MapVariant.MapVariant.Quotas = blf.MapVariant.MapVariant.Quotas;

            Cache.Serialize(Stream, tag, scenario);
        }

        public CachedTag GetCachedTag<T>(string tagName) where T : TagStructure
        {
            var tagAttribute = TagStructure.GetTagStructureAttribute(typeof(T), CacheContext.Version, CacheContext.Platform);
            var typeName = tagAttribute.Tag;

            if (CacheContext.TagCache.TryGetTag<T>(tagName, out var result))
            {
                return result;
            }
            else
            {
                new TagToolWarning($@"Could not find tag: '{tagName}.{typeName}'. Assigning null tag instead");
                return null;
            }
        }

        public abstract void MapVariantData();
    }
}