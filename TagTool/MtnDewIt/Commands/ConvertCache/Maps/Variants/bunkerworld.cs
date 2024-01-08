using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.BlamFile;
using TagTool.IO;
using TagTool.Common;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Maps
{
    public class bunkerworld : MapVariantFile
    {
        public bunkerworld(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
        (
            cache,
            cacheContext,
            stream
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
            MapVariantData();
        }

        public override void MapVariantData()
        {
            var tag = GetCachedTag<Scenario>($@"levels\dlc\bunkerworld\bunkerworld");
            var scnr = CacheContext.Deserialize<Scenario>(Stream, tag);

            Blf blf = new Blf(Cache.Version, CachePlatform.Original)
            {
                Version = CacheVersion.HaloOnlineED,
                CachePlatform = CachePlatform.Original,
                Format = EndianFormat.LittleEndian,
                ContentFlags = BlfFileContentFlags.StartOfFile | BlfFileContentFlags.EndOfFile | BlfFileContentFlags.MapVariant | BlfFileContentFlags.Scenario | BlfFileContentFlags.MapVariantTagNames,
                AuthenticationType = BlfAuthenticationType.None,
                StartOfFile = new BlfChunkStartOfFile
                {
                    ByteOrderMarker = -2,
                    Unknown = 0,
                    InternalName = $@"",
                    Signature = new Tag("_blf"),
                    Length = 48,
                    MajorVersion = 1,
                    MinorVersion = 2,
                },
                EndOfFile = new BlfChunkEndOfFile
                {
                    AuthenticationDataSize = 0,
                    AuthenticationType = BlfAuthenticationType.None,
                    Signature = new Tag("_eof"),
                    Length = 17,
                    MajorVersion = 1,
                    MinorVersion = 2,
                },
                Scenario = new BlfScenario
                {
                    MapId = 410,
                    MapFlags = BlfScenarioFlags.Unknown0 | BlfScenarioFlags.Visible | BlfScenarioFlags.GeneratesFilm | BlfScenarioFlags.IsMultiplayer | BlfScenarioFlags.IsDlc,
                    Names = new NameUnicode32[12]
                    {
                        new NameUnicode32
                        {
                            Name = $@"Standoff",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Standoff",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Patt",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Impasse",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Standoff",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Standoff",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Standoff",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Standoff",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Standoff",
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                            Name = $@"Confronto",
                        },
                        new NameUnicode32
                        {
                        },
                    },
                    Descriptions = new NameUnicode128[12]
                    {
                        new NameUnicode128
                        {
                            Name = $@"Once, nearby telescopes listened for a message from the stars. Now, these silos contain our prepared response. 4-12 players",
                        },
                        new NameUnicode128
                        {
                            Name = $@"近距離で向かい合う基地を配した丘陵地帯 (4-12 プレイヤー向け)",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Einst lauschten hier Antennen nach einer Nachricht von den Sternen. Jetzt enthalten diese Silos unsere vorbereitete Antwort.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Autrefois, il y avait ici des télescopes qui scrutaient les étoiles dans l'attente d'un message. Ces silos sont notre réponse.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Antaño, los telescopios cercanos buscaban un mensaje en las estrellas. Ahora, estos silos contienen nuestra respuesta.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Antaño, los telescopios cercanos buscaban un mensaje en las estrellas. Ahora, estos silos contienen nuestra respuesta.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Tempo fa, i telescopi vicini captarono un messaggio proveniente dalle stelle. Ora questi silo custodiscono la nostra risposta.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"외계의 메시지에 대한 우리의 대답은 참호 속에 있습니다. 4-12인용",
                        },
                        new NameUnicode128
                        {
                            Name = $@"天文望遠鏡曾經接收到從星系傳來的訊息，我們的回應已經準備好在這些地下飛彈發射室裡。4-12 位玩家。",
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                            Name = $@"Em tempos passados, telescópios próximos procuravam uma mensagem das estrelas. Agora, esses silos contêm nossa resposta pronta.",
                        },
                        new NameUnicode128
                        {
                        },
                    },
                    ImageName = $@"dlc_bunkerworld",
                    MapName = $@"bunkerworld",
                    MapIndex = 14,
                    Unknown1 = 2,
                    Unknown2 = 8,
                    GameEngineTeamCounts = new byte[11]
                    {
                        0x00, 0x02, 0x08, 0x08, 0x08, 0x08, 0x08, 0x08, 0x04, 0x02,
                        0x08,
                    },
                    Insertions = new BlfScenarioInsertion[9],
                    Signature = new Tag("levl"),
                    Length = 39104,
                    MajorVersion = 3,
                    MinorVersion = 1,
                },
                MapVariantTagNames = new BlfMapVariantTagNames 
                {
                    Names = new TagName[256]
                    {
                        new TagName
                        {
                            Name = $@"objects\multi\spawning\respawn_point_invisible.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\vehicles\mongoose\mongoose.vehi",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\turret\machinegun_turret\machinegun_turret.vehi",
                        },
                        new TagName
                        {
                            Name = $@"objects\vehicles\warthog\warthog.vehi",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\rifle\battle_rifle\battle_rifle.weap",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\support_low\brute_shot\brute_shot.weap",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\rifle\assault_rifle\assault_rifle.weap",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\pistol\plasma_pistol\plasma_pistol.weap",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\rifle\shotgun\shotgun.weap",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\support_high\spartan_laser\spartan_laser.weap",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\rifle\smg\smg.weap",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\pistol\magnum\magnum.weap",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\pistol\needler\needler.weap",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\rifle\spike_rifle\spike_rifle.weap",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\pistol\excavator\excavator.weap",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\support_high\rocket_launcher\rocket_launcher.weap",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\grenade\plasma_grenade\plasma_grenade.eqip",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\grenade\frag_grenade\frag_grenade.eqip",
                        },
                        new TagName
                        {
                            Name = $@"objects\equipment\powerdrain_equipment\powerdrain_equipment.eqip",
                        },
                        new TagName
                        {
                            Name = $@"objects\equipment\bubbleshield_equipment\bubbleshield_equipment.eqip",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\powerups\powerup_blue\powerup_blue.eqip",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\spawning\respawn_point.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\slayer\slayer_initial_spawn_point.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\slayer\slayer_respawn_zone.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\levels\dlc\bunkerworld\sandbag_wall_45corner_bunker\sandbag_wall_45corner_bunker.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\ctf\ctf_initial_spawn_point.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\ctf\ctf_respawn_zone.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\gear\human\military\sandbag_wall_turret\sandbag_wall_turret.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\territories\territories_initial_spawn_point.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\territories\territories_respawn_zone.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\infection\infection_initial_spawn_point.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\koth\koth_initial_spawn_point.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\oddball\oddball_initial_spawn_point.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\vip\vip_initial_spawn_point.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\assault\assault_initial_spawn_point.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\assault\assault_respawn_zone.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\ctf\ctf_flag_spawn_point.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\ctf\ctf_flag_return_area.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\gear\human\military\barricade_large\barricade_large.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\gear\human\military\crate_packing_giant\crate_packing_giant_mp.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\gear\human\industrial\sawhorse\sawhorse.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\koth\koth_hill_static.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\oddball\oddball_ball_spawn_point.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\territories\territory_static.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\gear\human\industrial\jersey_barrier\jersey_barrier.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\assault\assault_bomb_goal_area.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\assault\assault_bomb_spawn_point.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\vip\vip_destination_static.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\juggernaut\juggernaut_destination_static.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\gear\human\industrial\h_barrel_rusty_small\h_barrel_rusty_small.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\gear\human\industrial\pallet_large\pallet_large.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\gear\human\military\fusion_coil\fusion_coil.bloc",
                        },
                        new TagName
                        {
                            Name = $@"ms30\objects\levels\dlc\bunkerworld\drum_55gal_bunker\drum_55gal_bunker.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\gear\human\military\crate_packing\crate_packing.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\gear\human\military\hu_mil_radio_big\hu_mil_radio_big.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\gear\human\military\drum_12gal\drum_12gal.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\gear\human\military\generator\generator.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\gear\human\military\missle_body\missle_body.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\vehicles\civilian\forklift\forklift.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\gear\human\military\antennae_mast\antennae_mast.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\gear\human\industrial\h_barrel_rusty\h_barrel_rusty.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\gear\human\industrial\jersey_barrier_short\jersey_barrier_short.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\levels\solo\030_outskirts\foliage\bushlow\bushlow.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\levels\solo\030_outskirts\foliage\small_bush\small_bush.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\levels\solo\030_outskirts\foliage\bushc\bushc.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\box_l\box_l.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\box_m\box_m.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\box_xl\box_xl.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\box_xxl\box_xxl.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\box_xxxl\box_xxxl.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\wall_l\wall_l.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\wall_m\wall_m.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\wall_xl\wall_xl.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\wall_xxl\wall_xxl.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\wall_xxxl\wall_xxxl.bloc",
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                    },
                    Signature = new Tag("tagn"),
                    Length = 65548,
                    MajorVersion = 1,
                    MinorVersion = 0,
                },
                MapVariant = new BlfMapVariant 
                {
                    MapVariant = new MapVariant 
                    {
                        Metadata = new ContentItemMetadata
                        {
                            Name = $@"Standoff",
                            Description = $@"Once, nearby telescopes listened for a message from the stars. Now, these silos contain our prepared response. 4-12 players",
                            Author = $@"Bungie",
                            ContentType = ContentItemType.SandboxMap,
                            ContentSize = 57840,
                            Timestamp = 1132661994,
                            CampaignId = -1,
                            MapId = 410,
                            CampaignDifficulty = -1,
                        },
                        Version = 12,
                        ScenarioObjectCount = 9,
                        VariantObjectCount = 342,
                        PlaceableQuotaCount = 75,
                        MapId = 410,
                        WorldBounds = new RealRectangle3d(-120.0001f, 120.0001f, -120.0001f, 120f, -20.00001f, 60f),
                        RuntimeEngineSubType = GameEngineSubType.All,
                        MaximumBudget = 13f,
                        MapChecksum = 1329238095,
                        Objects = new VariantObjectDatum[640]
                        {
                            new VariantObjectDatum
                            {
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 0,
                                Position = new RealPoint3d(-0.2690174f, 12.21076f, 3.293695f),
                                Forward = new RealVector3d(0.1259063f, -0.9920421f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 0,
                                Position = new RealPoint3d(27.23074f, 15.19937f, 5.240251f),
                                Forward = new RealVector3d(-0.6271266f, -0.7789173f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 0,
                                Position = new RealPoint3d(0.3454844f, -14.39157f, 3.434026f),
                                Forward = new RealVector3d(-0.1233475f, 0.9923636f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 0,
                                Position = new RealPoint3d(-26.31751f, -15.37064f, 5.360956f),
                                Forward = new RealVector3d(0.4696597f, 0.8828475f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 0,
                                Position = new RealPoint3d(9.853192f, 21.85539f, 6.270254f),
                                Forward = new RealVector3d(-0.07098854f, -0.9974771f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 0,
                                Position = new RealPoint3d(-10.10309f, -21.57205f, 6.270266f),
                                Forward = new RealVector3d(0.0854634f, 0.9963413f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 1,
                                Position = new RealPoint3d(18.60932f, 25.88622f, 7.744267f),
                                Forward = new RealVector3d(-0.1440658f, -0.9889755f, -0.03424399f),
                                Up = new RealVector3d(-0.004936539f, -0.0338863f, 0.9994135f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 1,
                                Position = new RealPoint3d(-18.39269f, -25.13373f, 7.655389f),
                                Forward = new RealVector3d(0.2655482f, 0.9635268f, -0.03316873f),
                                Up = new RealVector3d(0.06960887f, 0.01515261f, 0.9974593f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 2,
                                Position = new RealPoint3d(-9.64292f, -18.87641f, 6.322122f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 210,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 2,
                                Position = new RealPoint3d(9.117048f, 18.85498f, 6.322123f),
                                Forward = new RealVector3d(-4.371139E-08f, -1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 210,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 1,
                                Position = new RealPoint3d(0.4491385f, 23.55063f, 5.243937f),
                                Forward = new RealVector3d(-0.7968979f, -0.5818686f, -0.1624274f),
                                Up = new RealVector3d(-0.1736925f, -0.03683201f, 0.9841109f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 1,
                                Position = new RealPoint3d(-1.267768f, -23.62704f, 5.297356f),
                                Forward = new RealVector3d(0.8029972f, 0.5715332f, -0.1689538f),
                                Up = new RealVector3d(0.1763896f, 0.04287839f, 0.983386f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 1,
                                Position = new RealPoint3d(19.89042f, 15.95688f, 5.101617f),
                                Forward = new RealVector3d(0.0197104f, -0.999672f, 0.01634998f),
                                Up = new RealVector3d(-0.07080713f, 0.01491637f, 0.9973785f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 1,
                                Position = new RealPoint3d(-20.4581f, -16.34419f, 5.102004f),
                                Forward = new RealVector3d(-0.0549925f, 0.9984088f, -0.01247832f),
                                Up = new RealVector3d(0.06841212f, 0.01623542f, 0.997525f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 3,
                                Position = new RealPoint3d(8.50671f, 12.7212f, 3.000218f),
                                Forward = new RealVector3d(-4.371139E-08f, -1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 60,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 3,
                                Position = new RealPoint3d(-9.140142f, -12.76314f, 3.000216f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 60,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 4,
                                Position = new RealPoint3d(11.23556f, 15.82354f, 4.317109f),
                                Forward = new RealVector3d(0.07171619f, -0.2969377f, 0.9522f),
                                Up = new RealVector3d(-0.995893f, -0.07421026f, 0.05186497f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 20,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 4,
                                Position = new RealPoint3d(-11.81573f, -15.82079f, 4.318428f),
                                Forward = new RealVector3d(-0.02366721f, 0.331429f, 0.9431833f),
                                Up = new RealVector3d(0.9978809f, -0.04936607f, 0.04238668f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 20,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 5,
                                Position = new RealPoint3d(-0.8276796f, -20.64536f, 4.940189f),
                                Forward = new RealVector3d(-0.7763321f, 0.4413619f, 0.4500089f),
                                Up = new RealVector3d(0.6276956f, 0.6064634f, 0.4880578f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 45,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 6,
                                Position = new RealPoint3d(13.50447f, 20.51269f, 4.886656f),
                                Forward = new RealVector3d(0.2565469f, -0.3219326f, 0.9113414f),
                                Up = new RealVector3d(-0.7814079f, -0.6240204f, -0.0004660746f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 6,
                                Position = new RealPoint3d(-14.01589f, -20.58398f, 4.889455f),
                                Forward = new RealVector3d(-0.3912455f, 0.4456759f, 0.8051707f),
                                Up = new RealVector3d(-0.9175639f, -0.1216638f, -0.3785161f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 7,
                                Position = new RealPoint3d(-6.486219f, -17.08749f, 3.428947f),
                                Forward = new RealVector3d(0.04111008f, 0.9991515f, -0.002513518f),
                                Up = new RealVector3d(-0.9990697f, 0.04113926f, 0.01293498f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 60,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 8,
                                Position = new RealPoint3d(10.20081f, 14.37844f, 3.130872f),
                                Forward = new RealVector3d(0.3332999f, 0.1702044f, 0.9273304f),
                                Up = new RealVector3d(-0.3976426f, 0.9171881f, -0.02542267f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 120,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 8,
                                Position = new RealPoint3d(-10.73781f, -14.36357f, 3.133783f),
                                Forward = new RealVector3d(-0.2954958f, -0.2150473f, 0.9308259f),
                                Up = new RealVector3d(-0.5483388f, 0.8360387f, 0.01907559f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 120,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 5,
                                Position = new RealPoint3d(0.4075657f, 20.59217f, 4.982123f),
                                Forward = new RealVector3d(-0.8308268f, -0.4028558f, 0.3839715f),
                                Up = new RealVector3d(0.5479971f, -0.4718264f, 0.6907091f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 45,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 9,
                                Position = new RealPoint3d(0.2187805f, -0.1372887f, 2.85602f),
                                Forward = new RealVector3d(0.4646504f, 0.8854845f, -0.004148438f),
                                Up = new RealVector3d(0.8854941f, -0.4646432f, 0.002610528f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 180,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 7,
                                Position = new RealPoint3d(6.038363f, 17.11505f, 3.42939f),
                                Forward = new RealVector3d(-0.1493831f, -0.9887752f, -0.002879642f),
                                Up = new RealVector3d(0.9887761f, -0.1493895f, 0.00214982f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 60,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 10,
                                Position = new RealPoint3d(8.212791f, 19.77974f, 4.418359f),
                                Forward = new RealVector3d(0.7272151f, -0.6864095f, -0.0003807188f),
                                Up = new RealVector3d(-0.6863412f, -0.7271503f, 0.01372015f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 11,
                                Position = new RealPoint3d(14.93403f, 25.56501f, 4.729441f),
                                Forward = new RealVector3d(-0.6898682f, -0.7239351f, 3.2186E-05f),
                                Up = new RealVector3d(-0.7230967f, 0.6890714f, 0.04808042f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 10,
                                Position = new RealPoint3d(-8.72655f, -19.75461f, 4.421087f),
                                Forward = new RealVector3d(-0.6269291f, 0.7790763f, 0.0001726671f),
                                Up = new RealVector3d(0.7790247f, 0.6268901f, -0.011369f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 11,
                                Position = new RealPoint3d(-15.49769f, -25.50574f, 4.729262f),
                                Forward = new RealVector3d(0.7532598f, 0.6577019f, 0.00529099f),
                                Up = new RealVector3d(0.6569456f, -0.7527359f, 0.04255809f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 12,
                                Position = new RealPoint3d(10.82152f, -6.551648f, 2.08259f),
                                Forward = new RealVector3d(-0.8204325f, 0.5706664f, 0.03507534f),
                                Up = new RealVector3d(-0.5714422f, -0.8164649f, -0.0826973f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 90,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 12,
                                Position = new RealPoint3d(-11.4216f, 6.530093f, 2.08986f),
                                Forward = new RealVector3d(0.7973006f, -0.6022216f, 0.04050773f),
                                Up = new RealVector3d(-0.6031891f, -0.7925622f, 0.08948775f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 90,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 4,
                                Position = new RealPoint3d(-2.624362f, 7.773782f, 4.082139f),
                                Forward = new RealVector3d(-0.1489169f, -0.5677628f, 0.8096104f),
                                Up = new RealVector3d(-0.9739097f, 0.2259943f, -0.02065243f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 20,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 4,
                                Position = new RealPoint3d(2.492715f, -7.882784f, 4.070539f),
                                Forward = new RealVector3d(0.1781472f, 0.4416952f, 0.8793002f),
                                Up = new RealVector3d(-0.9786037f, 0.1730164f, 0.1113556f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 20,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 13,
                                Position = new RealPoint3d(-4.469838f, -4.744487f, 3.832122f),
                                Forward = new RealVector3d(0.9984265f, 0.05353503f, -0.01669157f),
                                Up = new RealVector3d(0.01463228f, 0.03863032f, 0.9991464f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 13,
                                Position = new RealPoint3d(3.91455f, 4.92977f, 3.833644f),
                                Forward = new RealVector3d(0.9062621f, -0.4226785f, 0.005648236f),
                                Up = new RealVector3d(-0.003855133f, 0.005096923f, 0.9999796f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 14,
                                Position = new RealPoint3d(-4.194201f, -15.36132f, 3.439135f),
                                Forward = new RealVector3d(-0.8948542f, 0.4463584f, -0.0001897801f),
                                Up = new RealVector3d(0.4463579f, 0.8948538f, 0.001120688f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 90,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 14,
                                Position = new RealPoint3d(3.72631f, 15.28277f, 3.435576f),
                                Forward = new RealVector3d(0.9999412f, -0.00993566f, 0.004350429f),
                                Up = new RealVector3d(-0.009990709f, -0.9998679f, 0.01282004f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 90,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 15,
                                Position = new RealPoint3d(12.88175f, 4.89183f, 4.663794f),
                                Forward = new RealVector3d(0.9986684f, 0.01164857f, -0.05025662f),
                                Up = new RealVector3d(0.0446944f, 0.2911689f, 0.9556271f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 180,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 15,
                                Position = new RealPoint3d(-13.49004f, -5.062179f, 4.644223f),
                                Forward = new RealVector3d(0.9984737f, 0.008960245f, 0.0544978f),
                                Up = new RealVector3d(-0.05522148f, 0.1451629f, 0.9878655f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 180,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 4,
                                Position = new RealPoint3d(7.551667f, 27.89021f, 5.232422f),
                                Forward = new RealVector3d(-0.05033887f, 0.3967129f, 0.9165614f),
                                Up = new RealVector3d(0.970368f, -0.1977337f, 0.1388786f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 20,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 4,
                                Position = new RealPoint3d(-8.336679f, -27.80762f, 5.267295f),
                                Forward = new RealVector3d(-0.07439744f, -0.2313928f, 0.9700116f),
                                Up = new RealVector3d(0.8621817f, -0.5037096f, -0.05403093f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 20,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 4,
                                Position = new RealPoint3d(-21.08828f, -10.43216f, 6.058816f),
                                Forward = new RealVector3d(-0.2616493f, 0.27184f, 0.92609f),
                                Up = new RealVector3d(-0.5433932f, -0.8344851f, 0.09142525f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 20,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 4,
                                Position = new RealPoint3d(21.67648f, 10.48316f, 6.1457f),
                                Forward = new RealVector3d(-0.02423986f, -0.3745997f, 0.9268698f),
                                Up = new RealVector3d(-0.9857412f, 0.163383f, 0.04025268f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 20,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(12.34423f, 20.42598f, 4.747278f),
                                Forward = new RealVector3d(0.0125582f, -9.256935E-05f, -0.9999211f),
                                Up = new RealVector3d(0.9999211f, 8.815463E-06f, 0.0125582f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(12.70039f, 20.07108f, 4.747259f),
                                Forward = new RealVector3d(0.01281186f, -9.255489E-05f, -0.9999179f),
                                Up = new RealVector3d(0.9999179f, 8.989842E-06f, 0.01281186f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(-12.87886f, -20.44329f, 4.747259f),
                                Forward = new RealVector3d(0.01401601f, 1.144157E-06f, -0.9999018f),
                                Up = new RealVector3d(0.9999018f, -3.544127E-08f, 0.01401601f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(-13.13856f, -20.1514f, 4.747235f),
                                Forward = new RealVector3d(0.02113073f, 9.617165E-07f, -0.9997767f),
                                Up = new RealVector3d(0.9997767f, -4.613064E-07f, 0.02113073f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(3.098982f, 5.432436f, 3.819492f),
                                Forward = new RealVector3d(0.05222676f, 0.002446155f, -0.9986323f),
                                Up = new RealVector3d(0.9973478f, -0.05088875f, 0.05203494f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 17,
                                Position = new RealPoint3d(2.848185f, 5.63107f, 3.809134f),
                                Forward = new RealVector3d(-0.3631139f, -0.009840298f, -0.9316928f),
                                Up = new RealVector3d(0.9316776f, -0.01583676f, -0.3629407f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(-3.451519f, -5.562901f, 3.819684f),
                                Forward = new RealVector3d(-0.02486584f, -0.006460863f, -0.99967f),
                                Up = new RealVector3d(0.9996877f, 0.002339361f, -0.0248814f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 17,
                                Position = new RealPoint3d(-3.323593f, -5.749824f, 3.806931f),
                                Forward = new RealVector3d(-0.3898658f, -0.1578806f, -0.9072366f),
                                Up = new RealVector3d(0.9207667f, -0.0519555f, -0.3866385f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 18,
                                Position = new RealPoint3d(5.989605f, 17.66619f, 3.408854f),
                                Forward = new RealVector3d(0.9999991f, 2.742175E-06f, -0.001346052f),
                                Up = new RealVector3d(0.001346054f, -0.003032446f, 0.9999945f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 60,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 19,
                                Position = new RealPoint3d(8.895047f, -12.25242f, 2.069414f),
                                Forward = new RealVector3d(0.046036f, -0.7256023f, 0.6865726f),
                                Up = new RealVector3d(-0.9980372f, -0.06261919f, 0.0007413751f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 60,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 19,
                                Position = new RealPoint3d(-9.470335f, 11.62981f, 2.069269f),
                                Forward = new RealVector3d(-0.02478466f, 0.6842921f, -0.7287866f),
                                Up = new RealVector3d(0.9993648f, 0.03563325f, -0.0005287744f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 60,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 18,
                                Position = new RealPoint3d(-6.484591f, -17.66837f, 3.411156f),
                                Forward = new RealVector3d(1f, 3.090909E-13f, -2.750755E-05f),
                                Up = new RealVector3d(2.750755E-05f, -2.652407E-06f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 60,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 17,
                                Position = new RealPoint3d(-7.741654f, -19.66997f, 3.463931f),
                                Forward = new RealVector3d(0.9972806f, -0.07369791f, 8.710655E-06f),
                                Up = new RealVector3d(-8.697784E-06f, 4.955913E-07f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 17,
                                Position = new RealPoint3d(-7.346146f, -19.22679f, 3.464558f),
                                Forward = new RealVector3d(0.9972806f, -0.07369791f, -7.547856E-06f),
                                Up = new RealVector3d(9.124678E-06f, 2.105906E-05f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 17,
                                Position = new RealPoint3d(7.167306f, 19.59264f, 3.443572f),
                                Forward = new RealVector3d(0.9999887f, 0.003968842f, -0.002629166f),
                                Up = new RealVector3d(0.002703422f, -0.9279863f, -0.3726045f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 17,
                                Position = new RealPoint3d(6.84684f, 19.28339f, 3.442457f),
                                Forward = new RealVector3d(0.9999984f, 0.001594552f, 0.0008586009f),
                                Up = new RealVector3d(0.001802823f, -0.9215417f, -0.3882753f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(22.86292f, 11.07586f, 6.056461f),
                                Forward = new RealVector3d(0.004336679f, -0.00353749f, -0.9999843f),
                                Up = new RealVector3d(0.9999906f, 0.0001818824f, 0.004336063f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(23.1659f, 11.18644f, 6.056531f),
                                Forward = new RealVector3d(0.004784092f, -0.003985498f, -0.9999806f),
                                Up = new RealVector3d(0.9999884f, 0.0006173576f, 0.004781669f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(-23.15611f, -10.73959f, 6.045094f),
                                Forward = new RealVector3d(-0.0290969f, 0.1292154f, -0.9911896f),
                                Up = new RealVector3d(0.9995759f, 0.00255354f, -0.0290102f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(-22.75393f, -10.73737f, 6.033427f),
                                Forward = new RealVector3d(-0.0771071f, 0.0636199f, -0.9949909f),
                                Up = new RealVector3d(0.9970183f, 0.001908621f, -0.07714217f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 20,
                                Position = new RealPoint3d(-21.71638f, -8.091278f, 6.453668f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 180,
                                    Type = MultiplayerObjectType.Powerup,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 20,
                                Position = new RealPoint3d(20.4462f, 8.543307f, 6.443978f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 180,
                                    Type = MultiplayerObjectType.Powerup,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-10.5775f, -22.7381f, 4.40022f),
                                Forward = new RealVector3d(0.2685803f, 0.9632573f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 22,
                                Position = new RealPoint3d(-9.715355f, -23.1557f, 4.400222f),
                                Forward = new RealVector3d(-4.366987E-08f, 0.9994905f, -0.03191718f),
                                Up = new RealVector3d(-0.04357353f, 0.03188686f, 0.9985412f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Slayer,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 22,
                                Position = new RealPoint3d(9.175469f, 23.20254f, 4.400222f),
                                Forward = new RealVector3d(-4.366987E-08f, -0.9994905f, 0.03191717f),
                                Up = new RealVector3d(-0.04357353f, 0.03188686f, 0.9985412f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Slayer,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-8.813676f, -22.90339f, 4.400222f),
                                Forward = new RealVector3d(-0.3750754f, 0.9269943f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-14.21651f, -21.77508f, 4.700224f),
                                Forward = new RealVector3d(0.9390357f, 0.3438197f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-6.331393f, -21.32434f, 3.400603f),
                                Forward = new RealVector3d(0.06988233f, 0.9975553f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-8.518822f, -20.79231f, 4.400222f),
                                Forward = new RealVector3d(-0.6229136f, 0.7822906f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-11.26567f, -22.07098f, 4.40022f),
                                Forward = new RealVector3d(0.421921f, 0.9066326f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-4.854043f, -18.98848f, 3.401112f),
                                Forward = new RealVector3d(-0.2550152f, 0.9669371f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-3.092439f, -23.6917f, 5.639795f),
                                Forward = new RealVector3d(-0.02643329f, 0.9870638f, -0.1581341f),
                                Up = new RealVector3d(0.2010154f, 0.1602066f, 0.9663988f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(8.684027f, 29.52171f, 6.143735f),
                                Forward = new RealVector3d(0.03412413f, -0.9989061f, 0.03197167f),
                                Up = new RealVector3d(-0.3760734f, 0.01680495f, 0.9264375f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(8.368231f, 22.99188f, 4.400223f),
                                Forward = new RealVector3d(0.2338943f, -0.972262f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(9.921325f, 22.88917f, 4.400224f),
                                Forward = new RealVector3d(-0.2607887f, -0.9653959f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(7.980549f, 20.74054f, 4.400223f),
                                Forward = new RealVector3d(0.5865801f, -0.8098912f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(10.58393f, 22.23961f, 4.400225f),
                                Forward = new RealVector3d(-0.5109711f, -0.8595979f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(13.59325f, 21.92731f, 4.700238f),
                                Forward = new RealVector3d(-0.8923299f, -0.4426072f, 0.08857926f),
                                Up = new RealVector3d(0.08261915f, 0.03277206f, 0.9960422f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(5.912553f, 21.33712f, 3.399477f),
                                Forward = new RealVector3d(-0.03754274f, -0.999295f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(4.382785f, 18.98826f, 3.398934f),
                                Forward = new RealVector3d(0.3771665f, -0.9261455f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(20.6325f, 30.23361f, 7.471947f),
                                Forward = new RealVector3d(-0.3793785f, -0.9252416f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(21.45178f, 31.26178f, 7.472167f),
                                Forward = new RealVector3d(-0.3435037f, -0.9391513f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(21.60509f, 30.08583f, 7.471818f),
                                Forward = new RealVector3d(-0.3963961f, -0.9180796f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-17.75417f, -29.6144f, 7.584117f),
                                Forward = new RealVector3d(-0.09403327f, 0.9955691f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-18.98237f, -28.10651f, 7.515677f),
                                Forward = new RealVector3d(0.158726f, 0.9873087f, -0.005233604f),
                                Up = new RealVector3d(0.0682696f, -0.005687028f, 0.9976507f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-20.24666f, -27.06183f, 7.630615f),
                                Forward = new RealVector3d(0.5251418f, 0.8510148f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 23,
                                Position = new RealPoint3d(-7.158368f, -30.52413f, 5.7131f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Slayer,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 35f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 23,
                                Position = new RealPoint3d(9.183714f, 28.38286f, 6.190394f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Slayer,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 35f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(0.2415868f, 16.98955f, 3.742368f),
                                Forward = new RealVector3d(0.158436f, -0.954254f, -0.2535693f),
                                Up = new RealVector3d(0.08182214f, -0.2432406f, 0.9665087f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-25.44678f, -10.6508f, 5.816957f),
                                Forward = new RealVector3d(0.4749109f, 0.8751152f, 0.09291418f),
                                Up = new RealVector3d(-0.185412f, -0.003711812f, 0.9826539f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-26.31833f, -10.0705f, 5.548325f),
                                Forward = new RealVector3d(0.3988773f, 0.9161029f, 0.04065041f),
                                Up = new RealVector3d(-0.3184818f, 0.09682648f, 0.9429708f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 24,
                                Position = new RealPoint3d(-11.76662f, -18.92512f, 6.251459f),
                                Forward = new RealVector3d(-0.7071068f, -0.7071068f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 24,
                                Position = new RealPoint3d(11.13867f, 18.99514f, 6.222479f),
                                Forward = new RealVector3d(0.6427876f, 0.7660444f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 25,
                                Position = new RealPoint3d(-9.71266f, -23.15879f, 4.400222f),
                                Forward = new RealVector3d(-4.366987E-08f, 0.9994905f, -0.03191718f),
                                Up = new RealVector3d(-0.04357353f, 0.03188686f, 0.9985412f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 25,
                                Position = new RealPoint3d(9.179069f, 23.20637f, 4.400222f),
                                Forward = new RealVector3d(-4.366987E-08f, -0.9994905f, 0.03191717f),
                                Up = new RealVector3d(-0.0435737f, 0.03188686f, 0.9985412f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 26,
                                Position = new RealPoint3d(-9.80781f, -21.81278f, 4.400221f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 26,
                                Position = new RealPoint3d(9.279262f, 21.84625f, 4.400243f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-1.392812f, -27.52313f, 4.671456f),
                                Forward = new RealVector3d(-0.04291734f, 0.9988126f, -0.02305639f),
                                Up = new RealVector3d(0.178355f, 0.03036648f, 0.9834976f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-23.749f, -19.3919f, 6.248762f),
                                Forward = new RealVector3d(0.4047247f, 0.7834491f, -0.4715988f),
                                Up = new RealVector3d(0.1878757f, 0.4334815f, 0.8813606f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(4.166173f, -26.46458f, 3.917037f),
                                Forward = new RealVector3d(0.2075136f, 0.971426f, -0.1151936f),
                                Up = new RealVector3d(0.105111f, 0.09493291f, 0.9899188f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(25.43558f, 18.89313f, 6.043604f),
                                Forward = new RealVector3d(-0.3676163f, -0.8421472f, -0.3945204f),
                                Up = new RealVector3d(0.07294678f, -0.4490309f, 0.8905336f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(0.05461419f, 29.00691f, 4.558383f),
                                Forward = new RealVector3d(-0.001141976f, -0.999984f, -0.005544453f),
                                Up = new RealVector3d(-0.1074419f, -0.005389668f, 0.9941967f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-0.6093753f, 26.76566f, 4.452575f),
                                Forward = new RealVector3d(0.2301309f, -0.9715452f, 0.0560331f),
                                Up = new RealVector3d(-0.1232829f, 0.02800929f, 0.9919762f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 27,
                                Position = new RealPoint3d(10.08749f, 18.97327f, 6.300241f),
                                Forward = new RealVector3d(-1f, 8.742278E-08f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 27,
                                Position = new RealPoint3d(-10.7232f, -18.91051f, 6.300248f),
                                Forward = new RealVector3d(0.9994769f, -0.03233985f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 24,
                                Position = new RealPoint3d(4.286301f, 19.5369f, 5.72955f),
                                Forward = new RealVector3d(0.661675f, -0.7497907f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 24,
                                Position = new RealPoint3d(-4.712182f, -19.56576f, 5.72955f),
                                Forward = new RealVector3d(-0.7495637f, 0.6619322f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 26,
                                Position = new RealPoint3d(20.41116f, 30.86349f, 7.475156f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 26,
                                Position = new RealPoint3d(-1.399643f, 25.94787f, 4.716756f),
                                Forward = new RealVector3d(0.9991975f, -0.04005535f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-1.395349f, 27.64836f, 4.397569f),
                                Forward = new RealVector3d(0.2409791f, -0.968837f, 0.05730481f),
                                Up = new RealVector3d(-0.1232828f, 0.02800927f, 0.9919762f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-2.338204f, 26.97677f, 4.244288f),
                                Forward = new RealVector3d(0.2421826f, -0.9692751f, 0.043051f),
                                Up = new RealVector3d(-0.1085209f, 0.01703188f, 0.9939482f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 26,
                                Position = new RealPoint3d(-19.66078f, -28.76482f, 7.531932f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 26,
                                Position = new RealPoint3d(-0.4623817f, -26.03384f, 4.663489f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-1.039916f, -25.88139f, 4.661179f),
                                Forward = new RealVector3d(-0.1758269f, 0.9319004f, 0.3172483f),
                                Up = new RealVector3d(0.137883f, -0.2957788f, 0.945253f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(0.827502f, -26.00379f, 4.438973f),
                                Forward = new RealVector3d(-0.2022313f, 0.9704506f, 0.1316361f),
                                Up = new RealVector3d(0.1160129f, -0.1097279f, 0.987168f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-0.2328664f, -26.68192f, 4.498698f),
                                Forward = new RealVector3d(-0.1289645f, 0.9838015f, 0.1245097f),
                                Up = new RealVector3d(0.1160129f, -0.1097279f, 0.987168f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-26.22276f, -10.85392f, 5.650007f),
                                Forward = new RealVector3d(0.4620663f, 0.8725942f, 0.158348f),
                                Up = new RealVector3d(-0.3182306f, -0.003519792f, 0.9480067f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(28.96555f, 9.167477f, 4.854194f),
                                Forward = new RealVector3d(-0.5493718f, -0.835578f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(27.61663f, 10.27414f, 4.994771f),
                                Forward = new RealVector3d(-0.3456253f, -0.9381921f, -0.01840771f),
                                Up = new RealVector3d(0.09458396f, -0.05434758f, 0.9940323f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(28.81402f, 10.37043f, 4.902812f),
                                Forward = new RealVector3d(-0.3440712f, -0.9389436f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 26,
                                Position = new RealPoint3d(-25.65619f, -10.31711f, 5.807378f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 26,
                                Position = new RealPoint3d(28.2028f, 9.477676f, 4.85713f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-9.717267f, -23.1558f, 4.400222f),
                                Forward = new RealVector3d(0.04962963f, 0.9987677f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(9.176954f, 23.18973f, 4.400222f),
                                Forward = new RealVector3d(-4.371139E-08f, -1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 29,
                                Position = new RealPoint3d(9.297452f, 22.06489f, 4.400243f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 20f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 29,
                                Position = new RealPoint3d(-9.769861f, -21.99125f, 4.400242f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 20f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-11.01592f, -28.89877f, 6.58856f),
                                Forward = new RealVector3d(0.3507087f, 0.9179752f, -0.1852698f),
                                Up = new RealVector3d(0.2280781f, 0.1081525f, 0.9676174f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(13.88061f, -15.55129f, 2.168359f),
                                Forward = new RealVector3d(-0.1700383f, 0.9854375f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-16.79942f, -24.88294f, 4.700222f),
                                Forward = new RealVector3d(0.781606f, 0.6237724f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-21.7858f, -23.27783f, 4.700222f),
                                Forward = new RealVector3d(0.1123587f, 0.9936677f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-14.40719f, 15.7062f, 2.156206f),
                                Forward = new RealVector3d(0.2055047f, -0.9786561f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(15.72939f, 25.38984f, 4.700239f),
                                Forward = new RealVector3d(-0.7517316f, -0.6541134f, 0.0838761f),
                                Up = new RealVector3d(0.08261924f, 0.03277205f, 0.9960422f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(21.27926f, 23.28744f, 4.700241f),
                                Forward = new RealVector3d(0.07879873f, -0.9968905f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 30,
                                Position = new RealPoint3d(-9.697726f, -23.15673f, 4.400222f),
                                Forward = new RealVector3d(0.04962963f, 0.9987677f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Infection,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 30,
                                Position = new RealPoint3d(9.183462f, 23.18173f, 4.400222f),
                                Forward = new RealVector3d(-4.371139E-08f, -1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Infection,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 31,
                                Position = new RealPoint3d(9.172963f, 23.18926f, 4.400222f),
                                Forward = new RealVector3d(-4.371139E-08f, -1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 31,
                                Position = new RealPoint3d(-9.706851f, -23.15942f, 4.400222f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 32,
                                Position = new RealPoint3d(-9.706105f, -23.14508f, 4.400222f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Oddball,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 32,
                                Position = new RealPoint3d(9.180091f, 23.20827f, 4.400222f),
                                Forward = new RealVector3d(-4.371139E-08f, -1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Oddball,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 33,
                                Position = new RealPoint3d(9.173899f, 23.21492f, 4.400222f),
                                Forward = new RealVector3d(-4.371139E-08f, -1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Vip,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 33,
                                Position = new RealPoint3d(-9.699103f, -23.16776f, 4.400222f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Vip,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 34,
                                Position = new RealPoint3d(-9.702968f, -23.15743f, 4.400222f),
                                Forward = new RealVector3d(-4.366987E-08f, 0.9994905f, -0.03191718f),
                                Up = new RealVector3d(-0.04357353f, 0.03188686f, 0.9985412f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Assault,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 34,
                                Position = new RealPoint3d(9.180223f, 23.19919f, 4.400222f),
                                Forward = new RealVector3d(-4.366987E-08f, -0.9994905f, 0.03191717f),
                                Up = new RealVector3d(-0.04357353f, 0.03188686f, 0.9985412f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Assault,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 35,
                                Position = new RealPoint3d(9.36289f, 21.92094f, 4.400243f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Assault,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 20f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 35,
                                Position = new RealPoint3d(-9.865899f, -21.99541f, 4.400243f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Assault,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 20f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(25.18125f, 10.73311f, 6.010065f),
                                Forward = new RealVector3d(-0.8072016f, -0.5902758f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(22.91093f, 13.21776f, 6.010065f),
                                Forward = new RealVector3d(-0.6355945f, -0.7720231f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-23.10492f, -12.42107f, 5.905916f),
                                Forward = new RealVector3d(0.7450843f, 0.6669703f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-23.8179f, -7.791069f, 5.705222f),
                                Forward = new RealVector3d(0.7775446f, 0.628827f, 0.0009951618f),
                                Up = new RealVector3d(-0.1806955f, 0.2219136f, 0.9581771f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(10.87039f, -8.427555f, 2.053283f),
                                Forward = new RealVector3d(-0.748916f, 0.6626649f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(12.67524f, -5.853445f, 2.053283f),
                                Forward = new RealVector3d(-0.9265497f, 0.3761724f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(3.656268f, 13.31382f, 3.053625f),
                                Forward = new RealVector3d(-0.1195792f, -0.9928247f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(14.88594f, 8.632936f, 4.568962f),
                                Forward = new RealVector3d(-0.2425031f, -0.9699391f, 0.02025933f),
                                Up = new RealVector3d(-0.3197374f, 0.09962147f, 0.9422545f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(17.33778f, 22.72687f, 6.677279f),
                                Forward = new RealVector3d(-0.2206613f, -0.9395586f, -0.2617981f),
                                Up = new RealVector3d(-0.1208583f, -0.2400063f, 0.9632187f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(6.061058f, 32.97183f, 5.758419f),
                                Forward = new RealVector3d(-0.1476578f, -0.9890385f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(19.65151f, 30.42511f, 7.471803f),
                                Forward = new RealVector3d(-0.4051265f, -0.9142606f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(13.80953f, 25.57739f, 6.680085f),
                                Forward = new RealVector3d(-0.6948299f, -0.7042841f, -0.1455859f),
                                Up = new RealVector3d(-0.09542063f, -0.1103632f, 0.9893002f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-11.67486f, 8.757165f, 2.053282f),
                                Forward = new RealVector3d(0.7350751f, -0.6779857f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-14.01359f, 6.091245f, 2.053282f),
                                Forward = new RealVector3d(0.8426911f, -0.5383974f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-14.63875f, -29.77825f, 7.704043f),
                                Forward = new RealVector3d(0.2086449f, 0.9779915f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-14.93801f, -25.09519f, 6.677769f),
                                Forward = new RealVector3d(0.4739432f, 0.843175f, -0.253838f),
                                Up = new RealVector3d(0.1679779f, 0.1964035f, 0.9660274f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-3.781857f, -13.4245f, 3.087101f),
                                Forward = new RealVector3d(0.3239238f, 0.9460832f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-15.42475f, -8.412621f, 4.590401f),
                                Forward = new RealVector3d(0.1634602f, 0.9865489f, 0.001459056f),
                                Up = new RealVector3d(0.2493839f, -0.04275097f, 0.9674606f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-7.797447f, -7.388104f, 3.597762f),
                                Forward = new RealVector3d(0.2157941f, 0.9561774f, 0.1978832f),
                                Up = new RealVector3d(0.1490875f, -0.2325467f, 0.9610905f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(0.8823866f, -7.738981f, 4.032664f),
                                Forward = new RealVector3d(-0.09070873f, 0.9958774f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-0.6915406f, 7.182511f, 4.014632f),
                                Forward = new RealVector3d(-0.04825665f, -0.998835f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(7.103097f, 6.927558f, 3.66795f),
                                Forward = new RealVector3d(-0.08077955f, -0.9636236f, 0.254763f),
                                Up = new RealVector3d(-0.180559f, 0.2655167f, 0.9470477f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(8.17807f, -21.84156f, 2.883997f),
                                Forward = new RealVector3d(-0.03700509f, 0.9949619f, -0.0931745f),
                                Up = new RealVector3d(0.1722108f, 0.09819273f, 0.9801539f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-8.5673f, 21.63012f, 2.887958f),
                                Forward = new RealVector3d(0.02897353f, -0.9995802f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-21.00735f, -23.31606f, 4.700222f),
                                Forward = new RealVector3d(-0.02710086f, 0.9996327f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-16.34644f, -25.43918f, 4.700223f),
                                Forward = new RealVector3d(0.6766638f, 0.7362922f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(13.15498f, -16.52456f, 2.053283f),
                                Forward = new RealVector3d(-0.1110459f, 0.9919788f, -0.06038977f),
                                Up = new RealVector3d(0.02617618f, 0.06366395f, 0.997628f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(9.091391f, -22.21585f, 2.781346f),
                                Forward = new RealVector3d(-0.171262f, 0.9721003f, -0.1602821f),
                                Up = new RealVector3d(0.07458586f, 0.1750114f, 0.9817372f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-24.91493f, -19.16635f, 6.207838f),
                                Forward = new RealVector3d(0.5010445f, 0.7642871f, -0.4059799f),
                                Up = new RealVector3d(0.02325367f, 0.4570533f, 0.8891353f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-13.93749f, 16.37644f, 2.053282f),
                                Forward = new RealVector3d(0.1795093f, -0.9837563f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-9.375124f, 21.85299f, 2.741953f),
                                Forward = new RealVector3d(0.0685379f, -0.9976485f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(24.43992f, 18.77258f, 5.9934f),
                                Forward = new RealVector3d(-0.3913886f, -0.803574f, -0.4484236f),
                                Up = new RealVector3d(-0.02295421f, -0.4786207f, 0.8777217f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(24.97288f, 11.92455f, 6.010065f),
                                Forward = new RealVector3d(-0.7022552f, -0.7119253f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-0.5493652f, 17.58977f, 3.938135f),
                                Forward = new RealVector3d(0.01569414f, -0.9805976f, -0.1954025f),
                                Up = new RealVector3d(-0.04108532f, -0.195894f, 0.979764f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-0.55313f, -17.19524f, 3.811369f),
                                Forward = new RealVector3d(-0.04257403f, 0.9780357f, -0.2040433f),
                                Up = new RealVector3d(-0.08807417f, 0.1997594f, 0.9758786f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(0.168588f, -17.58551f, 3.931653f),
                                Forward = new RealVector3d(-0.07965659f, 0.9822963f, -0.1695548f),
                                Up = new RealVector3d(0.0220358f, 0.171789f, 0.9848873f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(20.62486f, 23.27932f, 4.70024f),
                                Forward = new RealVector3d(0.07879873f, -0.9968905f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(16.25682f, 24.96103f, 4.700239f),
                                Forward = new RealVector3d(-0.7517316f, -0.6541134f, 0.0838761f),
                                Up = new RealVector3d(0.08261924f, 0.03277205f, 0.9960422f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 22,
                                Position = new RealPoint3d(-1.453157f, 25.22388f, 4.629177f),
                                Forward = new RealVector3d(-0.03182879f, -0.8757733f, 0.4816722f),
                                Up = new RealVector3d(-0.1567601f, 0.4803263f, 0.8629675f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Slayer,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Green,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 22,
                                Position = new RealPoint3d(-0.1519398f, -24.76814f, 5.043008f),
                                Forward = new RealVector3d(-0.04071941f, 0.9408866f, 0.3362652f),
                                Up = new RealVector3d(0.1032449f, -0.3307807f, 0.938043f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Slayer,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Orange,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(0.5665637f, -27.58821f, 4.43054f),
                                Forward = new RealVector3d(-0.06232207f, 0.9978171f, -0.02183999f),
                                Up = new RealVector3d(0.1134347f, 0.02882229f, 0.9931273f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-2.15215f, 29.11872f, 4.314513f),
                                Forward = new RealVector3d(0.1032916f, -0.9946384f, 0.005022728f),
                                Up = new RealVector3d(-0.1060103f, -0.005987739f, 0.994347f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 32,
                                Position = new RealPoint3d(-1.4659f, 25.23047f, 4.623194f),
                                Forward = new RealVector3d(-0.03182879f, -0.8757733f, 0.4816722f),
                                Up = new RealVector3d(-0.1567601f, 0.4803263f, 0.8629675f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Oddball,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Green,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 32,
                                Position = new RealPoint3d(-0.1516069f, -24.77357f, 5.033836f),
                                Forward = new RealVector3d(-0.04071941f, 0.9408866f, 0.3362652f),
                                Up = new RealVector3d(0.1032449f, -0.3307807f, 0.938043f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Oddball,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Orange,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 31,
                                Position = new RealPoint3d(-1.463649f, 25.23981f, 4.619681f),
                                Forward = new RealVector3d(-0.03182879f, -0.8757733f, 0.4816722f),
                                Up = new RealVector3d(-0.1567601f, 0.4803263f, 0.8629675f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Green,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 31,
                                Position = new RealPoint3d(-0.1519074f, -24.76803f, 5.035823f),
                                Forward = new RealVector3d(-0.04071941f, 0.9408866f, 0.3362652f),
                                Up = new RealVector3d(0.1032449f, -0.3307807f, 0.938043f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Orange,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-1.460877f, 25.23997f, 4.620049f),
                                Forward = new RealVector3d(-0.03182879f, -0.8757733f, 0.4816722f),
                                Up = new RealVector3d(-0.1567601f, 0.4803263f, 0.8629675f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Green,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-0.1428762f, -24.77807f, 5.031289f),
                                Forward = new RealVector3d(-0.04071941f, 0.9408866f, 0.3362652f),
                                Up = new RealVector3d(0.1032449f, -0.3307807f, 0.938043f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Orange,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 33,
                                Position = new RealPoint3d(-1.450985f, 25.21494f, 4.634547f),
                                Forward = new RealVector3d(-0.03182879f, -0.8757733f, 0.4816722f),
                                Up = new RealVector3d(-0.1567601f, 0.4803263f, 0.8629675f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Vip,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Green,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 33,
                                Position = new RealPoint3d(-0.1502733f, -24.77533f, 5.033071f),
                                Forward = new RealVector3d(-0.04071941f, 0.9408866f, 0.3362652f),
                                Up = new RealVector3d(0.1032449f, -0.3307807f, 0.938043f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Vip,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Orange,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-7.273726f, -23.78004f, 6.273383f),
                                Forward = new RealVector3d(0.4724455f, 0.8796614f, -0.05469075f),
                                Up = new RealVector3d(-0.1476669f, 0.1401786f, 0.9790528f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-15.83049f, -19.44717f, 5.754253f),
                                Forward = new RealVector3d(0.4839303f, 0.8560953f, -0.1814173f),
                                Up = new RealVector3d(-0.02936525f, 0.2230782f, 0.9743581f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(15.36417f, 19.83848f, 5.832499f),
                                Forward = new RealVector3d(-0.5406601f, -0.8245612f, -0.1666899f),
                                Up = new RealVector3d(-0.007303307f, -0.1935394f, 0.9810653f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(6.315629f, 24.02389f, 6.321913f),
                                Forward = new RealVector3d(-0.3399624f, -0.9319261f, -0.1262515f),
                                Up = new RealVector3d(0.01273319f, -0.1387964f, 0.9902391f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 24,
                                Position = new RealPoint3d(-16.69656f, -25.29937f, 7.467264f),
                                Forward = new RealVector3d(-0.9705151f, 0.2376616f, 0.04021701f),
                                Up = new RealVector3d(0.04508329f, 0.01507383f, 0.9988695f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 24,
                                Position = new RealPoint3d(-20.32496f, -24.71914f, 7.732729f),
                                Forward = new RealVector3d(-0.8714762f, -0.4850874f, 0.07224472f),
                                Up = new RealVector3d(0.05740945f, 0.04539388f, 0.9973182f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 36,
                                Position = new RealPoint3d(-9.7723f, -21.1688f, 4.464556f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.CtfFlagSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0.5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 37,
                                Position = new RealPoint3d(-9.77372f, -21.17038f, 4.416408f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.CtfFlagReturnArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 37,
                                Position = new RealPoint3d(9.313647f, 21.34096f, 4.426478f),
                                Forward = new RealVector3d(-1f, -8.742278E-08f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.CtfFlagReturnArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 36,
                                Position = new RealPoint3d(9.312766f, 21.33532f, 4.476351f),
                                Forward = new RealVector3d(-1f, -8.742278E-08f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.CtfFlagSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0.5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 38,
                                Position = new RealPoint3d(4.550355f, 20.90568f, 5.839767f),
                                Forward = new RealVector3d(0.9997832f, -0.0207198f, -0.002066635f),
                                Up = new RealVector3d(0.002066198f, -4.252464E-05f, 0.9999979f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 39,
                                Position = new RealPoint3d(-5.025722f, -12.58121f, 3.007753f),
                                Forward = new RealVector3d(-0.9994118f, -0.004497092f, -0.03399625f),
                                Up = new RealVector3d(-0.0340326f, 0.008270264f, 0.9993865f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 39,
                                Position = new RealPoint3d(4.687402f, 12.65796f, 3.011392f),
                                Forward = new RealVector3d(-0.9992468f, -0.0001731024f, 0.03880405f),
                                Up = new RealVector3d(0.03880413f, -0.008415169f, 0.9992114f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 38,
                                Position = new RealPoint3d(-4.891016f, -20.87469f, 5.859889f),
                                Forward = new RealVector3d(-0.9986091f, 0.01909968f, -0.04914321f),
                                Up = new RealVector3d(-0.04913765f, 0.0007603402f, 0.9987917f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 38,
                                Position = new RealPoint3d(7.697223f, 19.41865f, 6.359711f),
                                Forward = new RealVector3d(0.6782257f, 0.733201f, -0.04925673f),
                                Up = new RealVector3d(0.03344993f, 0.03615698f, 0.9987861f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 38,
                                Position = new RealPoint3d(-8.216738f, -19.44607f, 6.359116f),
                                Forward = new RealVector3d(-0.6923038f, -0.7200665f, -0.047112f),
                                Up = new RealVector3d(-0.03262319f, -0.03398927f, 0.9988896f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 40,
                                Position = new RealPoint3d(-0.1236441f, 38.87126f, 5.516367f),
                                Forward = new RealVector3d(0.1166879f, 0.9661757f, 0.2299746f),
                                Up = new RealVector3d(0.03231995f, -0.2351279f, 0.9714269f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 41,
                                Position = new RealPoint3d(-0.1427869f, 0.03143558f, 2.81366f),
                                Forward = new RealVector3d(0.9208983f, -0.3898028f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.KothHillArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 7f,
                                        BoxLength = 5f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = -0.2f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 42,
                                Position = new RealPoint3d(-2.54091f, 0.9234703f, 2.842065f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Oddball,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.HoldSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 43,
                                Position = new RealPoint3d(9.352006f, 14.58167f, 3.000223f),
                                Forward = new RealVector3d(-1f, -8.742278E-08f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2.5f,
                                        NegativeHeight = 1f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 43,
                                Position = new RealPoint3d(22.41304f, 10.29895f, 6.010065f),
                                Forward = new RealVector3d(-1f, -8.742278E-08f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3.5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 1f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 43,
                                Position = new RealPoint3d(9.028834f, -5.88892f, 2.026306f),
                                Forward = new RealVector3d(-0.9999517f, -0.004625992f, -0.008678548f),
                                Up = new RealVector3d(-0.008682482f, 0.0008309484f, 0.999962f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 2f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 43,
                                Position = new RealPoint3d(-13.52958f, -5.704332f, 4.531909f),
                                Forward = new RealVector3d(-0.9998575f, -0.01386716f, -0.009623659f),
                                Up = new RealVector3d(-0.007792411f, -0.1265369f, 0.9919313f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 2f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 43,
                                Position = new RealPoint3d(-9.754509f, -20.81823f, 4.400221f),
                                Forward = new RealVector3d(-1f, -8.742278E-08f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 4,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3.1f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1.4f,
                                        NegativeHeight = 2f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 44,
                                Position = new RealPoint3d(-20.60848f, -29.06899f, 7.586953f),
                                Forward = new RealVector3d(0.6360512f, 0.7713578f, -0.02111613f),
                                Up = new RealVector3d(0.05197776f, -0.0155252f, 0.9985275f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 44,
                                Position = new RealPoint3d(-18.86719f, -30.3397f, 7.610085f),
                                Forward = new RealVector3d(0.5031028f, 0.8631995f, -0.04212069f),
                                Up = new RealVector3d(-0.03457978f, 0.06880542f, 0.9970306f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 44,
                                Position = new RealPoint3d(-17.29595f, -30.83599f, 7.722928f),
                                Forward = new RealVector3d(0.06291721f, 0.995396f, -0.07230609f),
                                Up = new RealVector3d(-0.06010867f, 0.07609753f, 0.9952869f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 44,
                                Position = new RealPoint3d(-21.7119f, -27.75177f, 7.749906f),
                                Forward = new RealVector3d(0.9461532f, 0.323448f, -0.01324904f),
                                Up = new RealVector3d(0.04044494f, -0.07750489f, 0.9961712f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 45,
                                Position = new RealPoint3d(-9.780999f, -21.16586f, 4.429107f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Assault,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.CtfFlagReturnArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 1f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = -0.1f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 46,
                                Position = new RealPoint3d(-9.751323f, -20.50042f, 4.400221f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Assault,
                                    Flags = VariantPlacementFlags.Symmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.CtfFlagSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 46,
                                Position = new RealPoint3d(9.310546f, 20.69391f, 4.40024f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Assault,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.CtfFlagSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 45,
                                Position = new RealPoint3d(9.294803f, 21.33862f, 4.426043f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Assault,
                                    Flags = VariantPlacementFlags.Symmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.CtfFlagReturnArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 1f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = -0.1f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 46,
                                Position = new RealPoint3d(-1.212175f, 0.4474329f, 2.809513f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Assault,
                                    Flags = VariantPlacementFlags.Symmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.CtfFlagSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 47,
                                Position = new RealPoint3d(-7.936863f, -11.04209f, 2.992624f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Vip,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 47,
                                Position = new RealPoint3d(5.862868f, 12.4802f, 2.993659f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Vip,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 47,
                                Position = new RealPoint3d(18.72774f, -10.72651f, 2.629067f),
                                Forward = new RealVector3d(-0.6229985f, -0.7781565f, 0.07965823f),
                                Up = new RealVector3d(0.03320136f, 0.07543831f, 0.9965975f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Vip,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 47,
                                Position = new RealPoint3d(-18.30287f, 12.67831f, 2.622255f),
                                Forward = new RealVector3d(-0.05061726f, 0.9959946f, -0.07370644f),
                                Up = new RealVector3d(0.03320115f, 0.07543837f, 0.9965976f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Vip,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 47,
                                Position = new RealPoint3d(0.962459f, -0.5674971f, 2.827422f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Vip,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 4,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 42,
                                Position = new RealPoint3d(17.29681f, -12.15487f, 2.630845f),
                                Forward = new RealVector3d(-0.6266192f, -0.7758959f, -0.0730342f),
                                Up = new RealVector3d(-0.07521018f, -0.03307034f, 0.9966192f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Oddball,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.HoldSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 42,
                                Position = new RealPoint3d(-17.72934f, 11.81095f, 2.625639f),
                                Forward = new RealVector3d(-0.04843928f, 0.998813f, -0.005125117f),
                                Up = new RealVector3d(0.08124053f, 0.009053946f, 0.9966534f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Oddball,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.HoldSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 42,
                                Position = new RealPoint3d(-7.274662f, -11.03092f, 2.991538f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Oddball,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.HoldSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 42,
                                Position = new RealPoint3d(7.188134f, 12.473f, 2.984345f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Oddball,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 4,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.HoldSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 41,
                                Position = new RealPoint3d(18.37401f, -11.86747f, 2.63752f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.KothHillArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 6f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 2f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 41,
                                Position = new RealPoint3d(-18.83326f, 11.65546f, 2.641639f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.KothHillArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 6f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 2f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 48,
                                Position = new RealPoint3d(2.249699f, -1.074177f, 2.834079f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Juggernaut,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.JuggernautDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 48,
                                Position = new RealPoint3d(6.521643f, 12.47298f, 2.978008f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Juggernaut,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.JuggernautDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 48,
                                Position = new RealPoint3d(-8.591482f, -11.0207f, 3.008655f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Juggernaut,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.JuggernautDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 48,
                                Position = new RealPoint3d(-18.1403f, 10.85133f, 2.63771f),
                                Forward = new RealVector3d(-0.04673723f, 0.9969594f, 0.06235035f),
                                Up = new RealVector3d(0.05686628f, -0.05966184f, 0.9965976f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Juggernaut,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.JuggernautDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 48,
                                Position = new RealPoint3d(17.42835f, -11.05649f, 2.634987f),
                                Forward = new RealVector3d(-0.6283144f, -0.7778836f, -0.01087067f),
                                Up = new RealVector3d(-0.07036895f, 0.04291148f, 0.9965976f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Juggernaut,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 4,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.JuggernautDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 43,
                                Position = new RealPoint3d(8.334533f, 9.473953f, 3.077183f),
                                Forward = new RealVector3d(-0.9936481f, -0.01664316f, -0.1112946f),
                                Up = new RealVector3d(-0.1112947f, 0.2916088f, 0.9500409f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Symmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2.5f,
                                        NegativeHeight = 1f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 43,
                                Position = new RealPoint3d(-8.455666f, -9.165944f, 3.132181f),
                                Forward = new RealVector3d(-0.9969355f, -0.01025814f, 0.07755245f),
                                Up = new RealVector3d(0.07755248f, -0.2595972f, 0.962598f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Symmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2.5f,
                                        NegativeHeight = 1f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 43,
                                Position = new RealPoint3d(14.32334f, -3.344833f, 2.09729f),
                                Forward = new RealVector3d(-0.9985012f, -0.002242516f, 0.05468385f),
                                Up = new RealVector3d(0.05468385f, -0.08181729f, 0.995146f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Symmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2.5f,
                                        NegativeHeight = 1f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 43,
                                Position = new RealPoint3d(-13.75739f, 3.399555f, 2.151711f),
                                Forward = new RealVector3d(-0.9997839f, 0.0009347522f, -0.02076413f),
                                Up = new RealVector3d(-0.02062253f, 0.08011281f, 0.9965724f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Symmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2.5f,
                                        NegativeHeight = 1f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 43,
                                Position = new RealPoint3d(1.485897f, -1.005669f, 2.810562f),
                                Forward = new RealVector3d(-1f, -8.742278E-08f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Symmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 4,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2.5f,
                                        NegativeHeight = 1f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 49,
                                Position = new RealPoint3d(12.68855f, 21.41891f, 6.367115f),
                                Forward = new RealVector3d(-0.9991342f, -0.04151006f, 0.002786784f),
                                Up = new RealVector3d(0.002764949f, 0.0005834224f, 0.999996f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 49,
                                Position = new RealPoint3d(13.06927f, 21.50809f, 6.367269f),
                                Forward = new RealVector3d(-0.9990242f, -0.04416692f, 0.0001680387f),
                                Up = new RealVector3d(0.0002698572f, -0.00229936f, 0.9999973f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 40,
                                Position = new RealPoint3d(2.740672f, 38.56385f, 5.529318f),
                                Forward = new RealVector3d(0.1313576f, 0.9573448f, 0.2573636f),
                                Up = new RealVector3d(-0.05360727f, -0.2523735f, 0.9661438f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 40,
                                Position = new RealPoint3d(1.328817f, 38.56091f, 5.454923f),
                                Forward = new RealVector3d(-0.07469793f, 0.9678982f, 0.2399857f),
                                Up = new RealVector3d(-0.03830536f, -0.2432654f, 0.9692031f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 40,
                                Position = new RealPoint3d(-0.3227563f, -37.05922f, 5.198304f),
                                Forward = new RealVector3d(-0.236646f, 0.9349147f, -0.2644487f),
                                Up = new RealVector3d(0.003152649f, 0.2729172f, 0.9620324f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 50,
                                Position = new RealPoint3d(12.84671f, 21.61177f, 6.286355f),
                                Forward = new RealVector3d(-0.6553456f, 0.7553292f, 3.111129E-05f),
                                Up = new RealVector3d(2.905496E-05f, -1.598011E-05f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 51,
                                Position = new RealPoint3d(10.77006f, 19.40006f, 6.283533f),
                                Forward = new RealVector3d(0.999972f, 0.005011552f, -0.005557876f),
                                Up = new RealVector3d(0.005501161f, 0.01126051f, 0.9999214f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 90,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 51,
                                Position = new RealPoint3d(10.34816f, 19.39791f, 6.283848f),
                                Forward = new RealVector3d(0.9999887f, 1.002778E-05f, 0.004758366f),
                                Up = new RealVector3d(-0.004758376f, 0.002783445f, 0.9999848f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 90,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 51,
                                Position = new RealPoint3d(-11.33291f, -19.31878f, 6.28646f),
                                Forward = new RealVector3d(0.9930575f, 0.1176089f, -0.00221196f),
                                Up = new RealVector3d(0.002737505f, -0.004307233f, 0.9999869f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 90,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 51,
                                Position = new RealPoint3d(-10.92971f, -19.3308f, 6.283163f),
                                Forward = new RealVector3d(0.9999958f, 9.321486E-05f, 0.002898369f),
                                Up = new RealVector3d(-0.002898298f, -0.0007561432f, 0.9999955f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 90,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 52,
                                Position = new RealPoint3d(-12.7764f, -21.56772f, 6.284524f),
                                Forward = new RealVector3d(0.9999903f, 0.00440329f, -0.0002076858f),
                                Up = new RealVector3d(0.0002219048f, -0.003228928f, 0.9999948f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 52,
                                Position = new RealPoint3d(-12.95217f, -22.02434f, 6.284612f),
                                Forward = new RealVector3d(0.9999863f, 0.003293206f, 0.004074058f),
                                Up = new RealVector3d(-0.004068593f, -0.001664491f, 0.9999903f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-5.392186f, -16.11103f, 5.236003f),
                                Forward = new RealVector3d(0.4503519f, -0.8928437f, 0.003660538f),
                                Up = new RealVector3d(-0.001236719f, 0.003476033f, 0.9999932f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 54,
                                Position = new RealPoint3d(-18.45965f, -22.34571f, 4.807869f),
                                Forward = new RealVector3d(0.8625042f, -0.5060396f, -0.003233479f),
                                Up = new RealVector3d(-0.4660113f, -0.7967376f, 0.3847632f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 55,
                                Position = new RealPoint3d(-19.05845f, -22.15549f, 4.769104f),
                                Forward = new RealVector3d(0.3849403f, -0.1058827f, -0.9168478f),
                                Up = new RealVector3d(-0.2503069f, -0.9681432f, 0.006714717f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 49,
                                Position = new RealPoint3d(-19.33311f, -22.19337f, 4.701107f),
                                Forward = new RealVector3d(0.9999877f, 0.00488002f, 0.0009313516f),
                                Up = new RealVector3d(-0.0009188456f, -0.002564288f, 0.9999963f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 56,
                                Position = new RealPoint3d(4.964671f, 16.34925f, 5.231925f),
                                Forward = new RealVector3d(0.6733898f, 0.7392803f, 0.003293941f),
                                Up = new RealVector3d(-0.005153207f, 0.0002383672f, 0.9999867f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 53,
                                Position = new RealPoint3d(4.10542f, 17.2821f, 5.234783f),
                                Forward = new RealVector3d(0.9368465f, 0.3497408f, 8.910733E-05f),
                                Up = new RealVector3d(-3.741505E-05f, -0.0001545578f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 40,
                                Position = new RealPoint3d(-14.85509f, -30.99795f, 7.750824f),
                                Forward = new RealVector3d(0.06628866f, -0.9975923f, 0.02038294f),
                                Up = new RealVector3d(0.02074247f, 0.02180119f, 0.9995471f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 49,
                                Position = new RealPoint3d(20.76184f, 10.31851f, 6.010951f),
                                Forward = new RealVector3d(-0.9991383f, -0.04150581f, -3.087668E-05f),
                                Up = new RealVector3d(-9.129398E-05f, 0.00145374f, 0.9999989f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 49,
                                Position = new RealPoint3d(21.07848f, 10.50398f, 6.010998f),
                                Forward = new RealVector3d(-0.999135f, -0.04151648f, -0.002376891f),
                                Up = new RealVector3d(-0.002445418f, 0.001599905f, 0.9999958f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 50,
                                Position = new RealPoint3d(18.04801f, -2.458412f, 2.039262f),
                                Forward = new RealVector3d(0.9321227f, 0.3619394f, 0.01212786f),
                                Up = new RealVector3d(-0.01621506f, 0.008257092f, 0.9998344f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 57,
                                Position = new RealPoint3d(18.1275f, -2.547108f, 2.112941f),
                                Forward = new RealVector3d(0.9346817f, 0.355066f, 0.01727237f),
                                Up = new RealVector3d(-0.004871944f, -0.0357888f, 0.9993475f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 58,
                                Position = new RealPoint3d(20.32088f, -2.684805f, 2.025981f),
                                Forward = new RealVector3d(-0.3800316f, -0.9241397f, -0.03926607f),
                                Up = new RealVector3d(0.006351338f, -0.04505716f, 0.9989643f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 53,
                                Position = new RealPoint3d(11.62594f, -14.46689f, 2.084235f),
                                Forward = new RealVector3d(0.6369844f, -0.7707567f, 0.01360182f),
                                Up = new RealVector3d(-0.0222841f, -0.0007735005f, 0.9997514f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 53,
                                Position = new RealPoint3d(12.41945f, -14.2774f, 2.125027f),
                                Forward = new RealVector3d(0.01185798f, -0.9998854f, -0.009406718f),
                                Up = new RealVector3d(-0.1133535f, -0.01069092f, 0.9934972f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 55,
                                Position = new RealPoint3d(17.71164f, -2.524653f, 2.130621f),
                                Forward = new RealVector3d(0.9308283f, 0.3626816f, 0.04495259f),
                                Up = new RealVector3d(-0.05340328f, 0.0133032f, 0.9984844f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 55,
                                Position = new RealPoint3d(14.79947f, -8.902848f, 2.281281f),
                                Forward = new RealVector3d(0.9315715f, 0.3629769f, 0.02054733f),
                                Up = new RealVector3d(-0.03016494f, 0.02084786f, 0.9993275f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 55,
                                Position = new RealPoint3d(14.72551f, -9.347062f, 2.336958f),
                                Forward = new RealVector3d(-0.2703391f, 0.7247768f, 0.6337313f),
                                Up = new RealVector3d(0.9349092f, 0.3548184f, -0.00697715f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 54,
                                Position = new RealPoint3d(-13.31024f, -21.39654f, 6.27974f),
                                Forward = new RealVector3d(0.3856491f, 0.9226325f, 0.004897154f),
                                Up = new RealVector3d(-0.01160239f, -0.0004577892f, 0.9999326f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 59,
                                Position = new RealPoint3d(-11.82643f, 13.60094f, 2.090901f),
                                Forward = new RealVector3d(-0.9619868f, -0.2725745f, 0.01686985f),
                                Up = new RealVector3d(0.01659564f, 0.003311579f, 0.9998568f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 60,
                                Position = new RealPoint3d(-12.15176f, 13.02259f, 2.085462f),
                                Forward = new RealVector3d(-0.9679464f, -0.2505512f, 0.01743254f),
                                Up = new RealVector3d(0.01692216f, 0.004191344f, 0.9998481f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 61,
                                Position = new RealPoint3d(-19.38146f, 3.680962f, 2.067731f),
                                Forward = new RealVector3d(-0.1008774f, 0.9948726f, 0.007223011f),
                                Up = new RealVector3d(-0.0008411336f, -0.007345327f, 0.9999726f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 52,
                                Position = new RealPoint3d(-20.21216f, 4.324049f, 2.089505f),
                                Forward = new RealVector3d(-0.09851875f, 0.9950159f, 0.01540611f),
                                Up = new RealVector3d(-0.001044226f, -0.01558478f, 0.999878f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 52,
                                Position = new RealPoint3d(-20.42437f, 4.029622f, 2.084198f),
                                Forward = new RealVector3d(-0.09961177f, 0.9947987f, 0.02128326f),
                                Up = new RealVector3d(-0.0006220733f, -0.0214519f, 0.9997697f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 40,
                                Position = new RealPoint3d(-25.90887f, 10.49182f, 2.06791f),
                                Forward = new RealVector3d(0.9950674f, 0.09919976f, 0.0005176588f),
                                Up = new RealVector3d(-0.0007400602f, 0.00220517f, 0.9999973f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 62,
                                Position = new RealPoint3d(4.389949f, 30.32559f, 5.195452f),
                                Forward = new RealVector3d(0.04581488f, -0.9989499f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 63,
                                Position = new RealPoint3d(4.22804f, 31.53575f, 5.191992f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 64,
                                Position = new RealPoint3d(3.265708f, 30.56606f, 5.029471f),
                                Forward = new RealVector3d(-0.3560165f, 0.9344797f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 62,
                                Position = new RealPoint3d(-6.536743f, -24.92942f, 6.312451f),
                                Forward = new RealVector3d(0.04581488f, -0.9989499f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 63,
                                Position = new RealPoint3d(-6.211523f, -25.24836f, 6.183967f),
                                Forward = new RealVector3d(0.04581488f, -0.9989499f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 62,
                                Position = new RealPoint3d(-8.561913f, -31.9173f, 6.031104f),
                                Forward = new RealVector3d(-0.40001f, -0.9165108f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 64,
                                Position = new RealPoint3d(-3.624132f, -30.93691f, 5.008338f),
                                Forward = new RealVector3d(0.04581488f, -0.9989499f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 63,
                                Position = new RealPoint3d(-4.260583f, -30.12622f, 5.147315f),
                                Forward = new RealVector3d(0.3057615f, 0.9505486f, 0.0544727f),
                                Up = new RealVector3d(-0.1753926f, 0f, 0.9844986f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 63,
                                Position = new RealPoint3d(-21.60211f, -6.921062f, 5.765666f),
                                Forward = new RealVector3d(0.04581488f, -0.9989499f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 62,
                                Position = new RealPoint3d(-21.22355f, -6.360944f, 5.689943f),
                                Forward = new RealVector3d(0.815303f, 0.5109586f, 0.2724009f),
                                Up = new RealVector3d(-0.3982593f, 0.1533437f, 0.9043646f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 63,
                                Position = new RealPoint3d(5.170149f, 25.5603f, 5.983264f),
                                Forward = new RealVector3d(-0.7276904f, 0.6152551f, 0.3031959f),
                                Up = new RealVector3d(0.4273787f, 0.06097028f, 0.9020144f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 64,
                                Position = new RealPoint3d(23.83752f, 19.59721f, 6.378509f),
                                Forward = new RealVector3d(-0.7474757f, 0.6638768f, 0.02339951f),
                                Up = new RealVector3d(-0.2716686f, -0.3376436f, 0.9012175f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 63,
                                Position = new RealPoint3d(23.28767f, 19.21037f, 6.182879f),
                                Forward = new RealVector3d(0.7692735f, 0.595219f, 0.2322343f),
                                Up = new RealVector3d(-0.3264747f, 0.05375212f, 0.9436763f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 63,
                                Position = new RealPoint3d(11.33885f, 28.2959f, 6.704539f),
                                Forward = new RealVector3d(-0.9136429f, -0.2037721f, -0.3517579f),
                                Up = new RealVector3d(-0.2716685f, -0.3376437f, 0.9012175f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 64,
                                Position = new RealPoint3d(13.27448f, 26.29989f, 6.702773f),
                                Forward = new RealVector3d(-0.1118206f, -0.9823909f, -0.1496808f),
                                Up = new RealVector3d(-0.02708369f, -0.1475566f, 0.9886827f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 64,
                                Position = new RealPoint3d(10.05422f, 30.75695f, 6.59315f),
                                Forward = new RealVector3d(-0.1118206f, -0.9823909f, -0.1496808f),
                                Up = new RealVector3d(-0.02708369f, -0.1475566f, 0.9886827f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 63,
                                Position = new RealPoint3d(10.04657f, 29.80058f, 6.548369f),
                                Forward = new RealVector3d(0.1088634f, 0.9196442f, 0.3773637f),
                                Up = new RealVector3d(-0.2716682f, -0.3376437f, 0.9012176f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 62,
                                Position = new RealPoint3d(28.35568f, 22.2505f, 6.606402f),
                                Forward = new RealVector3d(-0.6227686f, -0.7558758f, -0.2020172f),
                                Up = new RealVector3d(0.0770564f, -0.3161992f, 0.9455582f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 65,
                                Position = new RealPoint3d(88.66147f, -53.0965f, 5.670805f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 65,
                                Position = new RealPoint3d(88.52514f, -53.93091f, 5.581813f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 66,
                                Position = new RealPoint3d(87.3269f, -53.19401f, 5.709243f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 66,
                                Position = new RealPoint3d(87.29562f, -54.08539f, 5.609941f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 67,
                                Position = new RealPoint3d(86.09391f, -53.23594f, 5.750182f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 67,
                                Position = new RealPoint3d(86.31966f, -54.17529f, 5.635955f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 68,
                                Position = new RealPoint3d(85.04024f, -53.09715f, 5.80485f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 68,
                                Position = new RealPoint3d(85.27103f, -54.12642f, 5.6803f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 69,
                                Position = new RealPoint3d(84.16426f, -53.14544f, 5.831849f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 69,
                                Position = new RealPoint3d(84.40334f, -54.1859f, 5.705733f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 70,
                                Position = new RealPoint3d(89.09789f, -55.214f, 5.366805f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 70,
                                Position = new RealPoint3d(89.21083f, -56.09155f, 5.226954f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 71,
                                Position = new RealPoint3d(87.9159f, -55.32112f, 5.411532f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 71,
                                Position = new RealPoint3d(88.12199f, -56.21219f, 5.264799f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 72,
                                Position = new RealPoint3d(86.74422f, -55.42831f, 5.455714f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 72,
                                Position = new RealPoint3d(86.86103f, -56.35952f, 5.307466f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 73,
                                Position = new RealPoint3d(85.69296f, -55.53868f, 5.493187f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 73,
                                Position = new RealPoint3d(85.90597f, -56.47168f, 5.339696f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 74,
                                Position = new RealPoint3d(84.74917f, -55.62536f, 5.528725f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 74,
                                Position = new RealPoint3d(85.00794f, -56.59194f, 5.367738f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 39,
                                Position = new RealPoint3d(-15.96766f, -26.12118f, 7.511307f),
                                Forward = new RealVector3d(-0.7585726f, -0.6514766f, 0.01208f),
                                Up = new RealVector3d(-0.01572986f, 0.0368433f, 0.9991972f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 39,
                                Position = new RealPoint3d(-15.22407f, -26.91327f, 7.548406f),
                                Forward = new RealVector3d(-0.5067548f, -0.860992f, 0.04350308f),
                                Up = new RealVector3d(-0.009349261f, 0.05594805f, 0.9983899f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                        },
                        ObjectTypeStartIndex = new short[16]
                        {
                            -1, 0, 0, 0, -1, -1, -1, 0, -1, -1, 
                            -1, 9, -1, -1, -1, 0, 
                        },
                        Quotas = new VariantObjectQuota[256]
                        {
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11942,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5526,
                                MinimumCount = 0,
                                MaximumCount = 6,
                                PlacedOnMap = 6,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 10316,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5407,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5500,
                                MinimumCount = 0,
                                MaximumCount = 16,
                                PlacedOnMap = 8,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5375,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5406,
                                MinimumCount = 0,
                                MaximumCount = 16,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5367,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 6725,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5554,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5501,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5502,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5368,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5376,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5380,
                                MinimumCount = 0,
                                MaximumCount = 3,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5555,
                                MinimumCount = 0,
                                MaximumCount = 3,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 431,
                                MinimumCount = 0,
                                MaximumCount = 32,
                                PlacedOnMap = 10,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 428,
                                MinimumCount = 0,
                                MaximumCount = 32,
                                PlacedOnMap = 6,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5473,
                                MinimumCount = 0,
                                MaximumCount = 3,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5476,
                                MinimumCount = 0,
                                MaximumCount = 3,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11946,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11920,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 91,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11922,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11924,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 19791,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 6,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11921,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11923,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 8,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 19734,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11932,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11927,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11943,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11930,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11933,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11934,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11928,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11929,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11971,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11972,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 13482,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11956,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11960,
                                MinimumCount = 0,
                                MaximumCount = 6,
                                PlacedOnMap = 6,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11976,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 3,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11977,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 5,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11978,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 10,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 18418,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11974,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11973,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 3,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11979,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 5,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11975,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 5,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11958,
                                MinimumCount = 0,
                                MaximumCount = 5,
                                PlacedOnMap = 5,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11959,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 13476,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 19960,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11955,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11951,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 13505,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11965,
                                MinimumCount = 0,
                                MaximumCount = 1,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 18505,
                                MinimumCount = 0,
                                MaximumCount = 1,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 18789,
                                MinimumCount = 0,
                                MaximumCount = 1,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 13477,
                                MinimumCount = 0,
                                MaximumCount = 1,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11957,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 18458,
                                MinimumCount = 0,
                                MaximumCount = 1,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 20228,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 5,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 20213,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 8,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 20233,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 5,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 12009,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 12010,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 12011,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 12012,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 12013,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 12014,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 12015,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 12016,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 12017,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 12018,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                        },
                        SimulationEntities = new int[80]
                        {
                            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
                            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
                            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
                            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
                            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
                            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
                            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
                            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
                        },
                    },
                    Signature = new Tag("mapv"),
                    Length = 57504,
                    MajorVersion = 12,
                    MinorVersion = 1,
                },
            };

            UpdateQuotaIndexes(blf.MapVariantTagNames.Names, blf.MapVariant.MapVariant.Quotas);

            GenerateMapFile(tag, scnr, blf);
        }
    }
}