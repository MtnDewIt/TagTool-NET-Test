using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Commands;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Tags
{
    public class levels_ui_mainmenu_mainmenu_scenario : TagFile
    {
        public levels_ui_mainmenu_mainmenu_scenario(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
        (
            cache,
            cacheContext,
            stream
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
            TagData();
        }

        public override void TagData()
        {
            var tag = GetCachedTag<Scenario>($@"levels\ui\mainmenu\mainmenu");
            var scnr = CacheContext.Deserialize<Scenario>(Stream, tag);
            scnr.ObjectNames = new List<Scenario.ObjectName>
            {
                new Scenario.ObjectName
                {
                    Name = "char_platform",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 7,
                },
                new Scenario.ObjectName
                {
                    Name = "spartan_appearance",
                },
                new Scenario.ObjectName
                {
                    Name = "campaign_chief",
                    PlacementIndex = 1,
                },
                new Scenario.ObjectName
                {
                    Name = "campaign_aribter",
                    PlacementIndex = 2,
                },
                new Scenario.ObjectName
                {
                    Name = "campaign_ar",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                },
                new Scenario.ObjectName
                {
                    Name = "campaign_pr",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 1,
                },
                new Scenario.ObjectName
                {
                    Name = "campaign_light",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = (GameObjectTypeHalo3ODST)255,
                    },
                    PlacementIndex = -1,
                },
                new Scenario.ObjectName
                {
                    Name = "appearance_ar",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 2,
                },
                new Scenario.ObjectName
                {
                    Name = "custom_chief_01",
                    PlacementIndex = 3,
                },
                new Scenario.ObjectName
                {
                    Name = "custom_chief_02",
                    PlacementIndex = 4,
                },
                new Scenario.ObjectName
                {
                    Name = "custom_ar_01",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 3,
                },
                new Scenario.ObjectName
                {
                    Name = "custom_sg_01",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 4,
                },
                new Scenario.ObjectName
                {
                    Name = "custom_flag",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 5,
                },
                new Scenario.ObjectName
                {
                    Name = "custom_light",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = (GameObjectTypeHalo3ODST)255,
                    },
                    PlacementIndex = -1,
                },
                new Scenario.ObjectName
                {
                    Name = "editor_monitor",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 8,
                },
                new Scenario.ObjectName
                {
                    Name = "editor_warthog",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 9,
                },
                new Scenario.ObjectName
                {
                    Name = "editor_light",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = (GameObjectTypeHalo3ODST)255,
                    },
                    PlacementIndex = -1,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_phantom",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 10,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_light",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = (GameObjectTypeHalo3ODST)255,
                    },
                    PlacementIndex = -1,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_odst_recon_01",
                    PlacementIndex = 5,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_odst_recon_02",
                    PlacementIndex = 6,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_automag_2",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 11,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_ssmg_1",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 12,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_ssmg_2",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 13,
                },
                new Scenario.ObjectName
                {
                    Name = "server_browser_earth",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 14,
                },
                new Scenario.ObjectName
                {
                    Name = "server_browser_black",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    PlacementIndex = 102,
                },
                new Scenario.ObjectName
                {
                    Name = "elite_appearance",
                    PlacementIndex = 7,
                },
                new Scenario.ObjectName
                {
                    Name = "appearance_pr",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 6,
                },
            };
            scnr.Scenery = new List<Scenario.SceneryInstance>
            {
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 12,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6f, -57.5948f, 6.362535f),
                    UniqueHandle = new DatumHandle(6832, 220),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 12,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6f, -147.0875f, 7.344046f),
                    UniqueHandle = new DatumHandle(6832, 221),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 13,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.55968f, -142.3525f, 2.75f),
                    UniqueHandle = new DatumHandle(6832, 222),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 21,
                    NameIndex = -1,
                    Position = new RealPoint3d(77.9584f, -143.7763f, 2.75f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(45f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(6836, 223),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 21,
                    NameIndex = -1,
                    Position = new RealPoint3d(78.01319f, -60.69084f, 1.8f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(135f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(6836, 225),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 13,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.59317f, -62.13622f, 1.8f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(6836, 226),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 22,
                    NameIndex = -1,
                    Position = new RealPoint3d(100.223f, -147.906f, 0.6631185f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-42.73426f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(6840, 227),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(74.108f, -101.926f, -20f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(0, 3),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 26,
                    NameIndex = 14,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(55.12044f, -98.26942f, 3.532973f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-28.29517f), Angle.FromDegrees(-14.60906f), Angle.FromDegrees(5.956088f)),
                    UniqueHandle = new DatumHandle(0, 17),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 27,
                    NameIndex = 15,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(54.739f, -98.738f, 2.832f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(36.857f), Angle.FromDegrees(-11.491f), Angle.FromDegrees(6.565f)),
                    UniqueHandle = new DatumHandle(0, 18),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 28,
                    NameIndex = 17,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(0f, 0f, 10.147f),
                    UniqueHandle = new DatumHandle(0, 20),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Variant = CacheContext.StringTable.GetOrAddString($@"enemy_no_turret"),
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 29,
                    NameIndex = 21,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    UniqueHandle = new DatumHandle(0, 24),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 30,
                    NameIndex = 22,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    UniqueHandle = new DatumHandle(0, 25),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 30,
                    NameIndex = 23,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    UniqueHandle = new DatumHandle(0, 26),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.SceneryInstance
                {
                    PaletteIndex = 31,
                    NameIndex = 24,
                    Position = new RealPoint3d(1.6942f, -100.1158f, 324.0898f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(134.7043f), Angle.FromDegrees(-46.78879f), Angle.FromDegrees(-33.98746f)),
                    UniqueHandle = new DatumHandle(0, 27),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    AiSpawningSquad = -1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
            };
            scnr.SceneryPalette = new List<Scenario.ScenarioPaletteEntry>
            {
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\spawning\respawn_point"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\menu_platform\menu_platform"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\oddball\oddball_initial_spawn_point"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\slayer\slayer_respawn_zone"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_flag_away_respawn_zone"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_flag_at_home_respawn_zone"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_respawn_zone"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_initial_spawn_point"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\koth\koth_initial_spawn_point"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\territories\territories_respawn_zone"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\military\resupply_capsule_fired\resupply_capsule_fired"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\territories\territories_initial_spawn_point"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\multi\riverworld\fx\tower_pulse\tower_pulse"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\multi\riverworld\fx\man_cannon\man_cannon"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\assault\assault_initial_spawn_point"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\assault\assault_respawn_zone"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\military\resupply_capsule_ground_scar\ground_scar"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\vip\vip_initial_spawn_point"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\vip\vip_respawn_zone"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\scenery\human\military\warthog_drop_palette\warthog_drop_palette"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\scenery\human\military\mongoose_drop_palette\mongoose_drop_palette"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\multi\riverworld\fx\man_cannon\mini_man_cannon"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\multi\riverworld\fx\waterfall\waterfall_base"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\multi\riverworld\fx\waterfall\waterfall_top"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\multi\riverworld\fx\waterfall\waterfall_mid"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\spawning\respawn_point_invisible"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\monitor_cheap\monitor_cheap"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\warthog_cheap\warthog_cheap"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    //Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\vehicles\phantom\hirez_cinematic_phantom"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    //Object = GetCachedTag<Scenery>($@"objects\weapons\pistol\automag\automag"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    //Object = GetCachedTag<Scenery>($@"objects\weapons\rifle\smg_silenced\smg_silenced"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\matchmaking_earth\matchmaking_earth"),
                },
            };
            scnr.Bipeds = new List<Scenario.BipedInstance>
            {
                new Scenario.BipedInstance
                {
                    NameIndex = 1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(74.108f, -101.926f, 11.65f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(120f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Scale = 1.1f,
                    UniqueHandle = new DatumHandle(0, 4),
                    OriginBspIndex = -1,
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                },
                new Scenario.BipedInstance
                {
                    PaletteIndex = 2,
                    NameIndex = 2,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(88.52471f, -92.73032f, 3.0033f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-155.3412f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(0, 5),
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                },
                new Scenario.BipedInstance
                {
                    PaletteIndex = 1,
                    NameIndex = 3,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(89.14196f, -93.00212f, 2.9926f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-169.868f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(0, 6),
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                },
                new Scenario.BipedInstance
                {
                    PaletteIndex = 3,
                    NameIndex = 8,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(80.835f, -153.812f, 1.979f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-91.98899f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(0, 11),
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Variant = CacheContext.StringTable.GetOrAddString($@"menu_spartan2"),
                    ActiveChangeColors = Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Primary | Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Secondary | Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Tertiary | Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Quaternary,
                    PrimaryColor = new ArgbColor(255, 41, 41, 41),
                    SecondaryColor = new ArgbColor(255, 211, 68, 68),
                    TertiaryColor = new ArgbColor(255, 255, 148, 0),
                    QuaternaryColor = new ArgbColor(255, 255, 255, 255),
                },
                new Scenario.BipedInstance
                {
                    PaletteIndex = 3,
                    NameIndex = 9,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(80.893f, -153.553f, 1.979f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-163.1319f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(0, 12),
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Variant = CacheContext.StringTable.GetOrAddString($@"menu_spartan1"),
                    ActiveChangeColors = Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Primary | Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Secondary | Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Tertiary | Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Quaternary,
                    PrimaryColor = new ArgbColor(255, 86, 86, 86),
                    SecondaryColor = new ArgbColor(255, 41, 49, 92),
                    TertiaryColor = new ArgbColor(255, 255, 148, 0),
                    QuaternaryColor = new ArgbColor(255, 255, 255, 255),
                },
                new Scenario.BipedInstance
                {
                    PaletteIndex = 4,
                    NameIndex = 19,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(-0.123f, -2.991f, 11.551f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-104.257f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(0, 22),
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Variant = CacheContext.StringTable.GetOrAddString($@"mainmenu_odst01"),
                },
                new Scenario.BipedInstance
                {
                    PaletteIndex = 4,
                    NameIndex = 20,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(-1.988f, -0.989f, 11.828f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-90f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(0, 23),
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Variant = CacheContext.StringTable.GetOrAddString($@"mainmenu_odst01"),
                },
                new Scenario.BipedInstance
                {
                    PaletteIndex = 5,
                    NameIndex = 26,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(74.108f, -101.926f, 11.65f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(120f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    Scale = 1.1f,
                    OriginBspIndex = -1,
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                },
            };
            scnr.BipedPalette = new List<Scenario.ScenarioPaletteEntry>
            {
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Biped>($@"objects\characters\masterchief\mp_masterchief\mp_masterchief"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    //Object = GetCachedTag<Biped>($@"objects\characters\dervish\dervish"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    //Object = GetCachedTag<Biped>($@"objects\characters\masterchief\masterchief"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Biped>($@"levels\ui\mainmenu\objects\spartan_cheap\spartan_cheap"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    //Object = GetCachedTag<Biped>($@"levels\ui\mainmenu\objects\odst_recon_cheap\odst_recon_cheap"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    //Object = GetCachedTag<Biped>($@"objects\characters\elite\mp_elite\mp_elite"),
                },
            };
            scnr.Weapons = new List<Scenario.WeaponInstance>
            {
                new Scenario.WeaponInstance
                {
                    NameIndex = 4,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
                    UniqueHandle = new DatumHandle(0, 7),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.WeaponInstance
                {
                    PaletteIndex = 1,
                    NameIndex = 5,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
                    UniqueHandle = new DatumHandle(0, 8),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.WeaponInstance
                {
                    NameIndex = 7,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    UniqueHandle = new DatumHandle(0, 10),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.WeaponInstance
                {
                    NameIndex = 10,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
                    UniqueHandle = new DatumHandle(0, 13),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.WeaponInstance
                {
                    PaletteIndex = 3,
                    NameIndex = 11,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
                    UniqueHandle = new DatumHandle(0, 14),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.WeaponInstance
                {
                    PaletteIndex = 2,
                    NameIndex = 12,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(81.397f, -153.856f, 2.210711f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-81.45872f), Angle.FromDegrees(-10.39058f), Angle.FromDegrees(4.628513f)),
                    UniqueHandle = new DatumHandle(0, 15),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.WeaponInstance
                {
                    PaletteIndex = 1,
                    NameIndex = 27,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = 0,
                        },
                    },
                },
            };
            scnr.WeaponPalette = new List<Scenario.ScenarioPaletteEntry>
            {
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    //Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\multiplayer\flag\flag"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\shotgun\shotgun"),
                },
            };
            scnr.LightVolumes = new List<Scenario.LightVolumeInstance>
            {
                new Scenario.LightVolumeInstance
                {
                    NameIndex = 6,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(87.95523f, -91.52019f, 3.164429f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(7.247242f), Angle.FromDegrees(-10.34807f), Angle.FromDegrees(60.06319f)),
                    UniqueHandle = new DatumHandle(0, 9),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.None,
                    },
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    PowerGroup = -1,
                    PositionGroup = -1,
                    Type2 = Scenario.LightVolumeInstance.TypeValue2.Projective,
                    Flags = 1,
                    X = 88.64423f,
                    Y = -94.7899f,
                    Z = 5.047427f,
                    Width = 0.015625f,
                    HeightScale = 1f,
                    FieldOfView = Angle.FromDegrees(125.9875f),
                    FalloffDistance = 0.4414063f,
                    CutoffDistance = 3.835549f,
                },
                new Scenario.LightVolumeInstance
                {
                    PaletteIndex = 1,
                    NameIndex = 13,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(81.37815f, -152.6445f, 2.375807f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(63.09137f), Angle.FromDegrees(17.67388f), Angle.FromDegrees(92.07263f)),
                    UniqueHandle = new DatumHandle(0, 16),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.None,
                    },
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    PowerGroup = -1,
                    PositionGroup = -1,
                    Type2 = Scenario.LightVolumeInstance.TypeValue2.Projective,
                    Flags = 1,
                    X = 80.88482f,
                    Y = -153.6694f,
                    Z = 2.4306f,
                    Width = 1.839451f,
                    HeightScale = 1f,
                    FieldOfView = Angle.FromDegrees(75.35489f),
                    FalloffDistance = 0.6302913f,
                    CutoffDistance = 1.189611f,
                },
                new Scenario.LightVolumeInstance
                {
                    PaletteIndex = 2,
                    NameIndex = 16,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(56.47885f, -98.81166f, 4.854488f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(4.631807f), Angle.FromDegrees(48.29739f), Angle.FromDegrees(177.1723f)),
                    UniqueHandle = new DatumHandle(0, 19),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.None,
                    },
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    PowerGroup = -1,
                    PositionGroup = -1,
                    Type2 = Scenario.LightVolumeInstance.TypeValue2.Projective,
                    Flags = 1,
                    X = 54.32784f,
                    Y = -99.53103f,
                    Z = 3.766346f,
                    Width = 0.015625f,
                    HeightScale = 1f,
                    FieldOfView = Angle.FromDegrees(111.5836f),
                    FalloffDistance = 0.4414063f,
                    CutoffDistance = 2.339835f,
                },
                new Scenario.LightVolumeInstance
                {
                    PaletteIndex = 3,
                    NameIndex = 18,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(-2.028954f, 0.04164451f, 12.14188f),
                    UniqueHandle = new DatumHandle(0, 21),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.None,
                    },
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    PowerGroup = -1,
                    PositionGroup = -1,
                    Type2 = Scenario.LightVolumeInstance.TypeValue2.Projective,
                    Flags = 1,
                    X = -2.028954f,
                    Y = 0.04164451f,
                    Z = 12.14188f,
                    Width = 1f,
                    HeightScale = 1f,
                },
            };
            scnr.LightVolumePalette = new List<Scenario.ScenarioPaletteEntry>
            {
                new Scenario.ScenarioPaletteEntry
                {
                    //Object = GetCachedTag<Light>($@"levels\ui\mainmenu\lights\campaign"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Light>($@"levels\ui\mainmenu\lights\custom_games"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Light>($@"levels\ui\mainmenu\lights\editor"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    //Object = GetCachedTag<Light>($@"objects\vehicles\phantom\fx\running\cinematic_gravlift"),
                },
            };
            scnr.CutsceneCameraPoints = new List<Scenario.CutsceneCameraPoint>
            {
                new Scenario.CutsceneCameraPoint
                {
                    Name = "campaign_in",
                    Position = new RealPoint3d(88.0001f, -92.89202f, 3.363f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(22.1844f), Angle.FromDegrees(10.87839f), Angle.FromDegrees(4.494625f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "campaign",
                    Position = new RealPoint3d(87.96129f, -92.74828f, 3.363f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(10.6944f), Angle.FromDegrees(13.82072f), Angle.FromDegrees(2.662841f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "campaign_path_02",
                    Position = new RealPoint3d(87.74733f, -92.88589f, 3.363f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(21.3344f), Angle.FromDegrees(8.425151f), Angle.FromDegrees(3.316434f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "campaign_path_03",
                    Position = new RealPoint3d(88.01371f, -92.73856f, 3.363f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(10.1044f), Angle.FromDegrees(14.84068f), Angle.FromDegrees(2.706487f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "campaign_path_04",
                    Position = new RealPoint3d(87.854f, -92.487f, 3.363f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-12.3856f), Angle.FromDegrees(10.20415f), Angle.FromDegrees(2.265426f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "custom_in",
                    Position = new RealPoint3d(80.27019f, -154.412f, 2.433f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(51.79529f), Angle.FromDegrees(3.20953f), Angle.FromDegrees(0.3009008f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "custom_games",
                    Position = new RealPoint3d(80.116f, -154.238f, 2.433f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(46.535f), Angle.FromDegrees(3.194f), Angle.FromDegrees(0.3404699f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "custom_path_02",
                    Position = new RealPoint3d(80.485f, -154.526f, 2.353f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(75.957f), Angle.FromDegrees(10.557f), Angle.FromDegrees(4.827899f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "custom_path_03",
                    Position = new RealPoint3d(79.988f, -153.812f, 2.461f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(21.335f), Angle.FromDegrees(5.93f), Angle.FromDegrees(-4.460439f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "custom_path_04",
                    Position = new RealPoint3d(79.967f, -153.195f, 2.576f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-13.867f), Angle.FromDegrees(-4.908f), Angle.FromDegrees(-0.827791f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "editor",
                    Position = new RealPoint3d(57.28f, -98.474f, 3.535f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-163.306f), Angle.FromDegrees(7.142f), Angle.FromDegrees(2.135f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "editor_in",
                    Position = new RealPoint3d(56.82927f, -97.29866f, 3.535f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-136.8157f), Angle.FromDegrees(5.75354f), Angle.FromDegrees(5.082516f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "editor_path_02",
                    Position = new RealPoint3d(57.23738f, -98.66696f, 3.581f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-167.9762f), Angle.FromDegrees(6.920579f), Angle.FromDegrees(1.551101f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "editor_path_03",
                    Position = new RealPoint3d(57.09472f, -98.09947f, 3.581f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-152.1181f), Angle.FromDegrees(8.016795f), Angle.FromDegrees(3.955584f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "editor_path_04",
                    Position = new RealPoint3d(57.09498f, -98.11095f, 3.499667f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-151.7607f), Angle.FromDegrees(7.625144f), Angle.FromDegrees(3.849416f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "settings_cam",
                    Position = new RealPoint3d(81.131f, -146.166f, 1.3f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "survival",
                    Position = new RealPoint3d(-0.125f, -3.542f, 11.769f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(113.005f), Angle.FromDegrees(-2.619f), Angle.FromDegrees(6.142f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "survival_in",
                    Position = new RealPoint3d(-0.007f, -3.488f, 11.749f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(116.683f), Angle.FromDegrees(-4.455f), Angle.FromDegrees(8.785f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "survival_path_02",
                    Position = new RealPoint3d(-0.239f, -3.58f, 11.749f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(98.453f), Angle.FromDegrees(-1.195f), Angle.FromDegrees(7.99f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "survival_path_03",
                    Position = new RealPoint3d(-0.331f, -3.559f, 11.915f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(87.372f), Angle.FromDegrees(-0.477f), Angle.FromDegrees(-10.286f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "survival_path_04",
                    Position = new RealPoint3d(-0.237f, -3.619f, 11.686f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(97.894f), Angle.FromDegrees(-1.746f), Angle.FromDegrees(12.396f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "server_browser",
                    Position = new RealPoint3d(2.429f, -99.511f, 323.322f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-114.6049f), Angle.FromDegrees(-19.05827f), Angle.FromDegrees(-35.48944f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "server_browser_path_02",
                    Position = new RealPoint3d(2.5744f, -99.6188f, 323.0661f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-117.1435f), Angle.FromDegrees(-25.78415f), Angle.FromDegrees(-40.31187f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "server_browser_path_03",
                    Position = new RealPoint3d(1.9629f, -99.3337f, 323.418f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-93.07613f), Angle.FromDegrees(-2.550249f), Angle.FromDegrees(-39.61562f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "server_browser_path_04",
                    Position = new RealPoint3d(2.4818f, -99.2983f, 323.418f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-113.9313f), Angle.FromDegrees(-13.6645f), Angle.FromDegrees(-28.02653f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_helmet_wide",
                    Position = new RealPoint3d(80.8f, -146.266f, 1.472f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_body_wide",
                    Position = new RealPoint3d(80.8f, -146.295f, 1.372f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_leftshoulder_wide",
                    Position = new RealPoint3d(80.9f, -146.19f, 1.372f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_rightshoulder_wide",
                    Position = new RealPoint3d(81f, -146.266f, 1.372f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_helmet_wide",
                    Position = new RealPoint3d(80.9f, -146.236f, 1.402f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_body_wide",
                    Position = new RealPoint3d(80.8f, -146.266f, 1.322f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_leftshoulder_wide",
                    Position = new RealPoint3d(80.9f, -146.25f, 1.372f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_rightshoulder_wide",
                    Position = new RealPoint3d(80.95f, -146.35f, 1.372f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_helmet_standard",
                    Position = new RealPoint3d(80.8f, -146.35f, 1.472f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_body_standard",
                    Position = new RealPoint3d(80.9f, -146.315f, 1.372f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_leftshoulder_standard",
                    Position = new RealPoint3d(80.9f, -146.25f, 1.372f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_rightshoulder_standard",
                    Position = new RealPoint3d(81f, -146.34f, 1.372f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_helmet_standard",
                    Position = new RealPoint3d(80.9f, -146.29f, 1.402f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_body_standard",
                    Position = new RealPoint3d(80.75f, -146.37f, 1.322f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_leftshoulder_standard",
                    Position = new RealPoint3d(80.9f, -146.34f, 1.372f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_rightshoulder_standard",
                    Position = new RealPoint3d(80.95f, -146.38f, 1.372f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
            };
            scnr.Crates = new List<Scenario.CrateInstance>
            {
                new Scenario.CrateInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(81.5977f, -141.485f, 2.75009f),
                    UniqueHandle = new DatumHandle(33344, 0),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6012f, -62.8223f, 1.79816f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(33344, 1),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 2,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.9019f, -104.075f, 4.83276f),
                    UniqueHandle = new DatumHandle(22752, 26),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Neutral,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 4f,
                        BoundaryPositiveHeight = 1.5f,
                        BoundaryNegativeHeight = 2f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 3,
                    NameIndex = -1,
                    Position = new RealPoint3d(83.6514f, -102.729f, 4.92305f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(50.649f), Angle.FromDegrees(2.4522E-08f), Angle.FromDegrees(3.10183f)),
                    UniqueHandle = new DatumHandle(29908, 30),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        SpawnOrder = -1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 7,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(55.2181f, -93.367f, 3.39098f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(0.00315627f), Angle.FromDegrees(0.152158f), Angle.FromDegrees(-0.143134f)),
                    UniqueHandle = new DatumHandle(55836, 40),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 8,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(55.2781f, -94.43f, 3.37838f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-0.161738f), Angle.FromDegrees(1.45908f), Angle.FromDegrees(3.96555f)),
                    UniqueHandle = new DatumHandle(55836, 42),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 2,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 9,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(54.8503f, -93.4026f, 3.39398f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(118.878f), Angle.FromDegrees(-1.42381f), Angle.FromDegrees(-0.0332819f)),
                    UniqueHandle = new DatumHandle(55836, 43),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 2,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 6,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(55.1228f, -94.1875f, 3.68882f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-1.4065f), Angle.FromDegrees(-0.310194f), Angle.FromDegrees(-89.9454f)),
                    UniqueHandle = new DatumHandle(55836, 47),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 2,
                    NameIndex = -1,
                    Position = new RealPoint3d(58.495f, -99.4875f, 2.28512f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0.892326f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(61288, 48),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 4f,
                        BoundaryPositiveHeight = 1.5f,
                        BoundaryNegativeHeight = 2f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 2,
                    NameIndex = -1,
                    Position = new RealPoint3d(97.3108f, -104.583f, 3.4546f),
                    UniqueHandle = new DatumHandle(61288, 49),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 2,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 4f,
                        BoundaryPositiveHeight = 1.5f,
                        BoundaryNegativeHeight = 2f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 3,
                    NameIndex = -1,
                    Position = new RealPoint3d(62.3146f, -104.132f, 4.03979f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-151.69f), Angle.FromDegrees(1.82319f), Angle.FromDegrees(-1.25808f)),
                    UniqueHandle = new DatumHandle(63656, 50),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        SpawnOrder = -1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 3,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(97.58749f, -102.2085f, 3.353781f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-96.31224f), Angle.FromDegrees(6.914569f), Angle.FromDegrees(-2.89644f)),
                    UniqueHandle = new DatumHandle(63656, 51),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        SpawnOrder = -1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 10,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(80.7472f, -142.03f, 4.2433f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(90.0081f), Angle.FromDegrees(0.0697498f), Angle.FromDegrees(90f)),
                    UniqueHandle = new DatumHandle(1432, 52),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 2,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 9,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(80.8345f, -142.667f, 4.10471f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(177.329f), Angle.FromDegrees(-0.230709f), Angle.FromDegrees(-0.397928f)),
                    UniqueHandle = new DatumHandle(1432, 53),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 2,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 10,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(82.3423f, -61.9768f, 3.3484f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(89.959f), Angle.FromDegrees(-0.0162934f), Angle.FromDegrees(89.9557f)),
                    UniqueHandle = new DatumHandle(1432, 54),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 2,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 11,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(83.2876f, -62.0242f, 2.45998f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-0.0009941329f), Angle.FromDegrees(-0.0248938f), Angle.FromDegrees(0.00130895f)),
                    UniqueHandle = new DatumHandle(1432, 55),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 5,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 11,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(83.287f, -62.1586f, 2.46016f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-0.0193956f), Angle.FromDegrees(0.341322f), Angle.FromDegrees(-0.12768f)),
                    UniqueHandle = new DatumHandle(1432, 56),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 5,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 11,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(95.3214f, -93.6129f, 2.54849f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(2.58068f), Angle.FromDegrees(-38.1643f), Angle.FromDegrees(86.2996f)),
                    UniqueHandle = new DatumHandle(1436, 61),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 5,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 11,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(96.7029f, -98.2882f, 2.90641f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-41.4827f), Angle.FromDegrees(-55.271f), Angle.FromDegrees(85.0975f)),
                    UniqueHandle = new DatumHandle(1436, 62),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 5,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 14,
                    NameIndex = -1,
                    Position = new RealPoint3d(97.415f, -104.005f, 3.43122f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(5.08809f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(1440, 64),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Asymmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 4f,
                        BoundaryPositiveHeight = 2f,
                        BoundaryNegativeHeight = 0.5f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 14,
                    NameIndex = -1,
                    Position = new RealPoint3d(66.8165f, -127.02f, 1.49332f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-79.73471f), Angle.FromDegrees(12.25162f), Angle.FromDegrees(9.74352f)),
                    UniqueHandle = new DatumHandle(1440, 65),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Asymmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 4f,
                        BoundaryPositiveHeight = 2f,
                        BoundaryNegativeHeight = 0.5f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 14,
                    NameIndex = -1,
                    Position = new RealPoint3d(95.9943f, -83.4863f, 3.22161f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(10.8234f), Angle.FromDegrees(2.09226f), Angle.FromDegrees(-1.16793f)),
                    UniqueHandle = new DatumHandle(1440, 66),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Asymmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 3,
                        Shape = MultiplayerObjectBoundaryShape.Cylinder,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 3.3f,
                        BoundaryPositiveHeight = 1.8f,
                        BoundaryNegativeHeight = 0.5f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 14,
                    NameIndex = -1,
                    Position = new RealPoint3d(63.515f, -83.6171f, 2.2964f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(136.977f), Angle.FromDegrees(-1.84222f), Angle.FromDegrees(10.4759f)),
                    UniqueHandle = new DatumHandle(1440, 67),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Asymmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 2,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 3.5f,
                        BoundaryPositiveHeight = 2f,
                        BoundaryNegativeHeight = 0.5f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 14,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6071f, -57.9788f, 1.47689f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(1440, 68),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Asymmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 4,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 3f,
                        BoundaryPositiveHeight = 2f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 16,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(51.18001f, -107.3762f, 3.464443f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(5.650116f), Angle.FromDegrees(74.38197f), Angle.FromDegrees(1.959057f)),
                    UniqueHandle = new DatumHandle(1512, 71),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        QuotaMaximum = 3,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 16,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(95.0155f, -97.5372f, 2.92663f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(95.9787f), Angle.FromDegrees(79.8178f), Angle.FromDegrees(94.5635f)),
                    UniqueHandle = new DatumHandle(1512, 72),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        QuotaMaximum = 3,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 16,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(100.013f, -101.708f, 3.83229f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-61.2035f), Angle.FromDegrees(37.4607f), Angle.FromDegrees(101.167f)),
                    UniqueHandle = new DatumHandle(1512, 73),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        QuotaMaximum = 3,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 11,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(102.312f, -104.858f, 3.82136f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(164.523f), Angle.FromDegrees(-65.4259f), Angle.FromDegrees(81.706f)),
                    UniqueHandle = new DatumHandle(1512, 74),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 5,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 18,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6071f, -57.9788f, 1.52532f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(4156, 78),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 19,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6071f, -57.9788f, 1.47689f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(4156, 79),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 18,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.63f, -146.506f, 2.43179f),
                    UniqueHandle = new DatumHandle(4156, 80),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 19,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.63f, -146.506f, 2.38217f),
                    UniqueHandle = new DatumHandle(4156, 81),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 21,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6093f, -61.0276f, 2.10034f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-45f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(6884, 84),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 20,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.5551f, -58.3443f, -0.0497548f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(6884, 85),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 21,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6111f, -143.387f, 2.99493f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(45f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(6884, 86),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 20,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.5931f, -146.064f, 0.844945f),
                    UniqueHandle = new DatumHandle(6884, 87),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 8,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(92.2137f, -91.8829f, 2.57696f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-0.298925f), Angle.FromDegrees(1.62492f), Angle.FromDegrees(-12.1614f)),
                    UniqueHandle = new DatumHandle(8972, 91),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        QuotaMaximum = 2,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 22,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6071f, -57.9788f, 1.47689f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(10964, 95),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Asymmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 22,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.63f, -146.506f, 2.38217f),
                    UniqueHandle = new DatumHandle(10964, 93),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Asymmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 2,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 22,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(95.9026f, -100.872f, 3.21009f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-96.1524f), Angle.FromDegrees(10.226f), Angle.FromDegrees(-2.07378E-07f)),
                    UniqueHandle = new DatumHandle(25408, 107),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Asymmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 22,
                    NameIndex = -1,
                    Position = new RealPoint3d(57.0105f, -98.4585f, 2.43212f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(53.8965f), Angle.FromDegrees(-10.512f), Angle.FromDegrees(7.579f)),
                    UniqueHandle = new DatumHandle(25408, 108),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Asymmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 3,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 17,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(84.4004f, -153.901f, 1.54089f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-7.70968f), Angle.FromDegrees(-72.0696f), Angle.FromDegrees(99.942f)),
                    UniqueHandle = new DatumHandle(11636, 97),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        QuotaMaximum = 3,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 17,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(84.4789f, -154.151f, 1.48953f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(14.4356f), Angle.FromDegrees(-2.42724f), Angle.FromDegrees(0.829414f)),
                    UniqueHandle = new DatumHandle(11636, 98),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        QuotaMaximum = 3,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 12,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(76.6112f, -51.3018f, 0.525322f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(99.4492f), Angle.FromDegrees(45.475f), Angle.FromDegrees(89.3162f)),
                    UniqueHandle = new DatumHandle(11636, 99),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        QuotaMaximum = 1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 17,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(76.293f, -51.6978f, 0.397189f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(131.484f), Angle.FromDegrees(7.26191f), Angle.FromDegrees(-6.87392f)),
                    UniqueHandle = new DatumHandle(11636, 100),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        QuotaMaximum = 3,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 21,
                    NameIndex = -1,
                    Position = new RealPoint3d(83.6342f, -102.709f, 4.92467f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(45f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(20404, 101),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Neutral,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 23,
                    NameIndex = -1,
                    Position = new RealPoint3d(77.6742f, -101.999f, 5.3752f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(41.1875f), Angle.FromDegrees(-7.399169f), Angle.FromDegrees(4.48083f)),
                    UniqueHandle = new DatumHandle(20404, 102),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Neutral,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 23,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6071f, -57.9788f, 1.47689f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(20404, 103),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 23,
                    NameIndex = -1,
                    Position = new RealPoint3d(57.0105f, -98.4585f, 2.43212f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(53.8965f), Angle.FromDegrees(-10.512f), Angle.FromDegrees(7.579f)),
                    UniqueHandle = new DatumHandle(20404, 104),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 2,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 23,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.63f, -146.506f, 2.38217f),
                    UniqueHandle = new DatumHandle(20404, 105),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 3,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 23,
                    NameIndex = -1,
                    Position = new RealPoint3d(97.58749f, -102.2085f, 3.353781f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-96.31224f), Angle.FromDegrees(6.914569f), Angle.FromDegrees(-2.89644f)),
                    UniqueHandle = new DatumHandle(20408, 106),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 4,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 22,
                    NameIndex = -1,
                    Position = new RealPoint3d(57.0105f, -98.4585f, 2.43212f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(53.8965f), Angle.FromDegrees(-10.512f), Angle.FromDegrees(7.579f)),
                    UniqueHandle = new DatumHandle(25408, 109),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Symmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 22,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(95.9026f, -100.872f, 3.21009f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-96.1524f), Angle.FromDegrees(10.226f), Angle.FromDegrees(-2.07378E-07f)),
                    UniqueHandle = new DatumHandle(25408, 110),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Symmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 22,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.63f, -146.506f, 2.38217f),
                    UniqueHandle = new DatumHandle(25408, 111),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Symmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 2,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 22,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6071f, -57.9788f, 1.47689f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(25408, 112),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Symmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        SpawnOrder = 3,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 14,
                    NameIndex = -1,
                    Position = new RealPoint3d(70.7251f, -127.831f, 2.87516f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(4.446648f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(25788, 113),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Symmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 3f,
                        BoundaryPositiveHeight = 2f,
                        BoundaryNegativeHeight = 2f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 14,
                    NameIndex = -1,
                    Position = new RealPoint3d(93.3272f, -118.508f, 3.44034f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(5.08809f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(25788, 114),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Symmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        Shape = MultiplayerObjectBoundaryShape.Cylinder,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 3f,
                        BoundaryPositiveHeight = 2f,
                        BoundaryNegativeHeight = 0.5f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 14,
                    NameIndex = -1,
                    Position = new RealPoint3d(83.61036f, -102.9507f, 4.906605f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(5.56306f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(25788, 115),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Symmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 4f,
                        BoundaryPositiveHeight = 2f,
                        BoundaryNegativeHeight = 1f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 14,
                    NameIndex = -1,
                    Position = new RealPoint3d(95.9943f, -83.4863f, 3.22161f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(10.8234f), Angle.FromDegrees(2.09226f), Angle.FromDegrees(-1.16793f)),
                    UniqueHandle = new DatumHandle(25788, 116),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Symmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        Shape = MultiplayerObjectBoundaryShape.Cylinder,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 3.3f,
                        BoundaryPositiveHeight = 1.8f,
                        BoundaryNegativeHeight = 0.5f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 14,
                    NameIndex = -1,
                    Position = new RealPoint3d(75.20548f, -80.30006f, 2.33234f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(-7.496149f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(25788, 117),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Symmetry = GameEngineSymmetry.Ignore | GameEngineSymmetry.Symmetric,
                        Team = MultiplayerTeamDesignator.Neutral,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                        BoundaryWidthRadius = 3f,
                        BoundaryPositiveHeight = 2f,
                        BoundaryNegativeHeight = 0.5f,
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 1,
                    NameIndex = -1,
                    Position = new RealPoint3d(77.5905f, -143.266f, 2.63948f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(45f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(53816, 119),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 1,
                    NameIndex = -1,
                    Position = new RealPoint3d(77.5784f, -61.1388f, 1.84828f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(135f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(53816, 120),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        Team = MultiplayerTeamDesignator.Blue,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 24,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(85.6133f, -121.082f, 2.98847f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(0f), Angle.FromDegrees(0f), Angle.FromDegrees(2.99796f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 252,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 3,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 74,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 44,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 7,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 4,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1163,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 15321,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6386,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28227,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 881,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 156,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -294,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5403,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3566,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13100,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29328,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 798,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -255,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -70,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -17334,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5552,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -14988,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22753,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 799,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -133,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 360,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3670,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2783,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 11983,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 30147,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 820,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 123,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(56568, 127),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 24,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(72.4726f, -77.9601f, 3.01574f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(164.65f), Angle.FromDegrees(-4.44972f), Angle.FromDegrees(0f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 254,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 3,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1156,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1166,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23238,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23042,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 60,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 62,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 35,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 42,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 9,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1084,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 15456,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5890,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28265,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 881,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 157,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -293,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6615,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3565,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13294,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28990,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 796,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -255,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -72,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -17567,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5239,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -15221,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22492,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 798,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -135,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 359,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3686,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 11763,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 30233,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 822,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 123,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(56568, 131),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 24,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(71.2153f, -74.4041f, 3.21789f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-86.7571f), Angle.FromDegrees(-0.415209f), Angle.FromDegrees(-3.52906f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 254,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 3,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1185,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1192,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23220,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23057,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 82,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 52,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 49,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 35,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 8,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 417,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 15289,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6022,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28345,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 881,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 157,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -293,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6991,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3386,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13225,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28955,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 796,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -255,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -72,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -17407,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5335,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -15241,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22581,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 798,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -135,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 359,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3561,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2886,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 11803,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 30221,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 821,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 124,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(56568, 132),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 25,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(71.6165f, -78.0496f, 3.24951f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-33.7462f), Angle.FromDegrees(-5.29115f), Angle.FromDegrees(-7.71016f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 252,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 3,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 75,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 44,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 7,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 4,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1195,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 15317,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6392,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28227,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 881,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 156,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -294,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5427,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3560,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13099,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29324,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 798,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -255,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -70,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -17332,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5551,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -14988,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22754,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 799,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -133,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 360,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3669,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2785,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 11988,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 30145,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 820,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 123,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(56572, 133),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 24,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(74.6567f, -83.129f, 2.49623f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(6.72464f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 252,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 3,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 74,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 44,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 7,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 4,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1161,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 15321,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6385,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28227,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 881,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 156,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -294,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5401,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3567,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13100,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29328,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 798,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -255,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -70,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -17334,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5550,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -14988,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22754,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 799,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -133,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 360,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3670,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2784,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 11988,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 30144,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 820,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 123,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(56572, 134),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 24,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(87.0449f, -106.241f, 4.01366f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(164.65f), Angle.FromDegrees(1.30201f), Angle.FromDegrees(0f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 254,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 3,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1185,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1182,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23119,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23159,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 78,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -9,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 47,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1528,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 15292,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6466,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28207,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 881,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 156,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -294,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5092,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3554,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13037,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29413,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 798,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -255,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -69,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -17265,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5642,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -14918,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22829,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 799,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -133,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 360,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3663,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2790,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 12050,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 30120,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 820,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 123,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(56572, 135),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 24,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(88.5995f, -114.545f, 2.69899f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-171.057f), Angle.FromDegrees(1.18676f), Angle.FromDegrees(0.535613f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 254,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 3,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1185,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1182,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23119,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23159,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 78,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -9,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 46,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 4,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1527,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 15283,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6465,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28212,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 881,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 156,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -294,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5077,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3556,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13032,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29417,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 798,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -255,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -69,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -17264,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5642,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -14915,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22831,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 799,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -133,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 360,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3660,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2793,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 12047,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 30121,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 820,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 123,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(56572, 137),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 24,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(93.7792f, -128.393f, 3.48919f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(78.572f), Angle.FromDegrees(0.0890814f), Angle.FromDegrees(-1.29896f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 254,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 3,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1186,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1183,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23118,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23159,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 78,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -9,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 46,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1529,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 15291,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6467,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28207,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 881,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 156,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -294,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5087,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3555,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13036,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29414,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 798,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -255,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -69,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -17265,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5642,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -14918,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22828,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 799,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -133,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 360,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3663,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2791,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 12050,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 30120,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 820,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 123,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(56572, 139),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 24,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(90.2448f, -128.221f, 2.67069f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(164.65f), Angle.FromDegrees(-2.09624f), Angle.FromDegrees(0f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 254,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 3,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1168,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1172,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23189,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23090,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 68,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 40,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 4,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -98,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 15398,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6158,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28259,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 881,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 156,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -294,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5916,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3580,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13194,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29184,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 797,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -255,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -71,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -17440,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5406,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -15102,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22631,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 799,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -134,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 359,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3677,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2776,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 11885,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 30185,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 821,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 123,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(56572, 140),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 24,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(74.4966f, -86.7925f, 2.12612f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(164.65f), Angle.FromDegrees(-2.09624f), Angle.FromDegrees(-6.26744f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 254,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 3,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1077,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1078,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23158,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23131,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -8,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 11,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -7,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 10,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -4,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 98,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 16006,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6201,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 27910,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 878,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 157,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -296,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3760,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 4209,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13176,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29465,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 796,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -256,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -70,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -17834,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5375,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -14735,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22573,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 801,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -133,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 358,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5493,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2201,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 11981,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29918,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 821,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 123,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(56572, 144),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 24,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(88.3602f, -99.9714f, 3.63971f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(176.914f), Angle.FromDegrees(-7.41199f), Angle.FromDegrees(-15.8917f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 254,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 3,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -955,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 953,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23117,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23183,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -110,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -16,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 4,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -68,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -15,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 514,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 16685,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6202,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 27505,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 875,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 157,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -297,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 2709,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 4709,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13092,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29542,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 795,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -255,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -72,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -18933,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5201,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -14226,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22039,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 804,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -129,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 357,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 7131,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1482,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 12019,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29599,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 821,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 123,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(56572, 145),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 26,
                    NameIndex = -1,
                    Position = new RealPoint3d(55.473f, -93.9713f, 3.97739f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(106.149f), Angle.FromDegrees(1.42243f), Angle.FromDegrees(0.0354396f)),
                    UniqueHandle = new DatumHandle(57868, 146),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        QuotaMaximum = 1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 27,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(55.7763f, -93.7475f, 3.51947f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(12.2654f), Angle.FromDegrees(1.35789f), Angle.FromDegrees(-2.20627f)),
                    UniqueHandle = new DatumHandle(57868, 147),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        QuotaMaximum = 1,
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 25,
                    NameIndex = -1,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest | Scenario.ObjectPlacementFlags.StoreOrientations,
                    Position = new RealPoint3d(91.5979f, -130.075f, 2.4999f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-56.7772f), Angle.FromDegrees(6.34539f), Angle.FromDegrees(10.6483f)),
                    NodeOrientations = new List<Scenario.ObjectNodeOrientation>
                    {
                        new Scenario.ObjectNodeOrientation
                        {
                            NodeCount = 9,
                            BitVectors = new List<Scenario.ObjectNodeOrientation.BitVector>
                            {
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 254,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 193,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                    Data = 3,
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                                new Scenario.ObjectNodeOrientation.BitVector
                                {
                                },
                            },
                            Orientations = new List<Scenario.ObjectNodeOrientation.Orientation>
                            {
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1185,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1182,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23119,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 23159,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 79,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -9,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 47,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32766,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 1,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 32767,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -1529,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 15294,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 6463,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 28207,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 881,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 156,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -294,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 5172,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3532,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -13034,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 29403,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 798,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -255,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -69,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -17263,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -5644,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -14918,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 22830,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 799,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -133,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 360,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 3662,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = -2790,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 12043,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 30123,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 820,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 302,
                                },
                                new Scenario.ObjectNodeOrientation.Orientation
                                {
                                    Number = 123,
                                },
                            },
                        },
                    },
                    UniqueHandle = new DatumHandle(61608, 150),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 29,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6033f, -148.224f, 9.43382f),
                    UniqueHandle = new DatumHandle(4432, 156),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 29,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6054f, -148.246f, 11.4267f),
                    UniqueHandle = new DatumHandle(4436, 157),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 29,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.6068f, -148.246f, 13.4394f),
                    UniqueHandle = new DatumHandle(4436, 158),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 29,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.599f, -56.1892f, 8.31408f),
                    UniqueHandle = new DatumHandle(4436, 159),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 29,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.5976f, -56.2105f, 10.3039f),
                    UniqueHandle = new DatumHandle(4436, 160),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 29,
                    NameIndex = -1,
                    Position = new RealPoint3d(81.59657f, -56.20533f, 12.35192f),
                    UniqueHandle = new DatumHandle(4436, 161),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 33,
                    NameIndex = -1,
                    Position = new RealPoint3d(72.13075f, -7.151678f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 172),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 33,
                    NameIndex = -1,
                    Position = new RealPoint3d(72.10191f, -7.930175f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 173),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 34,
                    NameIndex = -1,
                    Position = new RealPoint3d(71.47431f, -7.118358f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 174),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 34,
                    NameIndex = -1,
                    Position = new RealPoint3d(71.48746f, -7.902164f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 175),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 35,
                    NameIndex = -1,
                    Position = new RealPoint3d(70.91357f, -7.03483f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 176),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 35,
                    NameIndex = -1,
                    Position = new RealPoint3d(70.92479f, -7.886478f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 177),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 36,
                    NameIndex = -1,
                    Position = new RealPoint3d(70.36563f, -7.144942f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 178),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 36,
                    NameIndex = -1,
                    Position = new RealPoint3d(70.35686f, -7.839686f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 179),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 37,
                    NameIndex = -1,
                    Position = new RealPoint3d(69.77449f, -7.128363f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 180),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 37,
                    NameIndex = -1,
                    Position = new RealPoint3d(69.80562f, -7.815611f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 181),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 38,
                    NameIndex = -1,
                    Position = new RealPoint3d(69.17648f, -7.101247f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 182),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 38,
                    NameIndex = -1,
                    Position = new RealPoint3d(69.17175f, -7.832245f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 183),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 39,
                    NameIndex = -1,
                    Position = new RealPoint3d(68.54926f, -7.124963f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 184),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 39,
                    NameIndex = -1,
                    Position = new RealPoint3d(68.55874f, -7.756835f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 185),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 40,
                    NameIndex = -1,
                    Position = new RealPoint3d(67.96917f, -7.030532f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 186),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 40,
                    NameIndex = -1,
                    Position = new RealPoint3d(68.01935f, -7.707038f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 187),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 41,
                    NameIndex = -1,
                    Position = new RealPoint3d(67.41357f, -7.055074f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 188),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 41,
                    NameIndex = -1,
                    Position = new RealPoint3d(67.37775f, -7.718326f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 189),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 42,
                    NameIndex = -1,
                    Position = new RealPoint3d(66.82541f, -7.047056f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 190),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 42,
                    NameIndex = -1,
                    Position = new RealPoint3d(66.88258f, -7.681393f, -6.549201f),
                    UniqueHandle = new DatumHandle(34116, 191),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
                new Scenario.CrateInstance
                {
                    PaletteIndex = 43,
                    NameIndex = 25,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(3.068f, -102.909f, 328.322f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-135.244f), Angle.FromDegrees(-18.04f), Angle.FromDegrees(-18.975f)),
                    UniqueHandle = new DatumHandle(0, 28),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Crate,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditingBoundToBsp = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = 0,
                    },
                    CanAttachToBspFlags = 1,
                    Multiplayer = new Scenario.MultiplayerObjectProperties
                    {
                        MapVariantParent = new ScenarioObjectParentStruct
                        {
                            NameIndex = -1,
                        },
                    },
                },
            };
            scnr.CratePalette = new List<Scenario.ScenarioPaletteEntry>
            {
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\riverworld\man_cannon_river\man_cannon_river"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\riverworld\man_cannon_river_short\man_cannon_river_short"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                },
                new Scenario.ScenarioPaletteEntry
                {
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\covenant\military\crate_space\crate_space"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\case_ap_turret\case_ap_turret"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\antennae_mast\antennae_mast"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\generator\generator"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\fusion_coil\fusion_coil"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\drum_12gal\drum_12gal"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\bunkerworld\drum_55gal_bunker\drum_55gal_bunker"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\crate_packing_lid\crate_packing_lid"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\resupply_capsule_unfired\resupply_capsule_unfired"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\resupply_capsule_panel\resupply_capsule_panel"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\blitzcan\blitzcan"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                },
                new Scenario.ScenarioPaletteEntry
                {
                },
                new Scenario.ScenarioPaletteEntry
                {
                },
                new Scenario.ScenarioPaletteEntry
                {
                },
                new Scenario.ScenarioPaletteEntry
                {
                },
                new Scenario.ScenarioPaletteEntry
                {
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\100_citadel\foliage\plant_tree_pine\plant_tree_pine"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\100_citadel\foliage\plant_tree_pine\plant_tree_pine"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\hu_mil_radio_small\hu_mil_radio_small"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\camping_stool_mp\camping_stool_mp"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\100_citadel\foliage\plant_pine_tree_large\plant_pine_tree_large"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\physics\nutblocker_1x1x2\nutblocker_1x1x2"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_sender\teleporter_sender"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_reciever\teleporter_reciever"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_2way\teleporter_2way"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\box_l\box_l"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\box_m\box_m"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\box_xl\box_xl"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\box_xxl\box_xxl"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\box_xxxl\box_xxxl"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\wall_l\wall_l"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\wall_m\wall_m"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\wall_xl\wall_xl"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\wall_xxl\wall_xxl"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\wall_xxxl\wall_xxxl"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x20x20_black_mainmenu"),
                },
            };
            scnr.SimulationDefinitionTable = null;
            CacheContext.Serialize(Stream, tag, scnr);

            CompileScript(tag, $@"{Program.TagToolDirectory}\Tools\BaseCache\Scripts\mainmenu_enhanced.hsc");
        }
    }
}
