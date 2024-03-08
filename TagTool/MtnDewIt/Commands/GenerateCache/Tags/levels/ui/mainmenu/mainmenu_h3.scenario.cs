using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Commands;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags
{
    public class levels_ui_mainmenu_mainmenu_h3_scenario : TagFile
    {
        public levels_ui_mainmenu_mainmenu_h3_scenario(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
                    Name = $@"sky",
                    PlacementIndex = -1,
                },
                new Scenario.ObjectName
                {
                    Name = $@"cruiser1",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 2,
                },
                new Scenario.ObjectName
                {
                    Name = $@"cruiser2",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 3,
                },
                new Scenario.ObjectName
                {
                    Name = $@"cruiser3",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 4,
                },
                new Scenario.ObjectName
                {
                    Name = $@"clouds_ark",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 5,
                },
                new Scenario.ObjectName
                {
                    Name = $@"matchmaking_earth",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 7,
                },
                new Scenario.ObjectName
                {
                    Name = $@"editor_monitor",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 8,
                },
                new Scenario.ObjectName
                {
                    Name = $@"editor_warthog",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 6,
                },
                new Scenario.ObjectName
                {
                    Name = $@"earth",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 9,
                },
                new Scenario.ObjectName
                {
                    Name = $@"ark",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 10,
                },
                new Scenario.ObjectName
                {
                    Name = $@"forerunner_ship",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 11,
                },
                new Scenario.ObjectName
                {
                    Name = $@"cruiser4",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 12,
                },
                new Scenario.ObjectName
                {
                    Name = $@"banshee1",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 13,
                },
                new Scenario.ObjectName
                {
                    Name = $@"banshee2",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 14,
                },
                new Scenario.ObjectName
                {
                    Name = $@"elite_appearance",
                    PlacementIndex = 1,
                },
                new Scenario.ObjectName
                {
                    Name = $@"spartan_appearance",
                    PlacementIndex = 0,
                },
                new Scenario.ObjectName
                {
                    Name = $@"campaign_aribter",
                    PlacementIndex = 3,
                },
                new Scenario.ObjectName
                {
                    Name = $@"campaign_chief",
                    PlacementIndex = 2,
                },
                new Scenario.ObjectName
                {
                    Name = $@"custom_elite_01",
                    PlacementIndex = 5,
                },
                new Scenario.ObjectName
                {
                    Name = $@"custom_chief_01",
                    PlacementIndex = 4,
                },
                new Scenario.ObjectName
                {
                    Name = $@"appearance_ar",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 0,
                },
                new Scenario.ObjectName
                {
                    Name = $@"appearance_pr",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 1,
                },
                new Scenario.ObjectName
                {
                    Name = $@"campaign_ar",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 2,
                },
                new Scenario.ObjectName
                {
                    Name = $@"campaign_pr",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 3,
                },
                new Scenario.ObjectName
                {
                    Name = $@"custom_ar_01",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 4,
                },
                new Scenario.ObjectName
                {
                    Name = $@"custom_pr_01",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 5,
                },
                new Scenario.ObjectName
                {
                    Name = $@"custom_pr_02",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 6,
                },
                new Scenario.ObjectName
                {
                    Name = $@"custom_flag",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Weapon,
                    },
                    PlacementIndex = 7,
                },
                new Scenario.ObjectName
                {
                    Name = $@"custom_light",
                    PlacementIndex = -1,
                },
                new Scenario.ObjectName
                {
                    Name = $@"campaign_light",
                    PlacementIndex = -1,
                },
                new Scenario.ObjectName
                {
                    Name = $@"editor_light",
                    PlacementIndex = -1,
                },
                new Scenario.ObjectName
                {
                    Name = $@"storm",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Machine,
                    },
                    PlacementIndex = 0,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_phantom",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 15,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_light",
                    PlacementIndex = -1,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_odst_recon_01",
                    PlacementIndex = 6,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_odst_recon_02",
                    PlacementIndex = 7,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_automag_2",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 17,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_ssmg_1",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 18,
                },
                new Scenario.ObjectName
                {
                    Name = "survival_ssmg_2",
                    ObjectType = new GameObjectType16
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    PlacementIndex = 19,
                },
            };
            scnr.Scenery = new List<Scenario.SceneryInstance>
            {
                new Scenario.SceneryInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(-45.5f, -9.9951f, -35f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(90f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(3112, 77),
                    OriginBspIndex = -1,
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
                    CanAttachToBspFlags = 2,
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
                    NameIndex = -1,
                    Position = new RealPoint3d(-45.5f, -19.976f, -35f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(90f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(3112, 78),
                    OriginBspIndex = -1,
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
                    CanAttachToBspFlags = 2,
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
                    PaletteIndex = 3,
                    NameIndex = 1,
                    Position = new RealPoint3d(464.8235f, 136.6842f, -279.9998f),
                    ManualBspFlags = 3,
                    UniqueHandle = new DatumHandle(27376, 81),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    BspPolicy = Scenario.ScenarioInstance.BspPolicyValue.ManualBspIndex,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = 0,
                        ParentMarker = CacheContext.StringTable.GetStringId($@"ark"),
                    },
                    CanAttachToBspFlags = 3,
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
                    PaletteIndex = 3,
                    NameIndex = 2,
                    Position = new RealPoint3d(464.8235f, 136.6842f, -279.9998f),
                    ManualBspFlags = 3,
                    UniqueHandle = new DatumHandle(27380, 82),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = 0,
                        ParentMarker = CacheContext.StringTable.GetStringId($@"ark"),
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
                    NameIndex = 3,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(464.8235f, 136.6842f, -279.9998f),
                    UniqueHandle = new DatumHandle(27380, 83),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = 0,
                        ParentMarker = CacheContext.StringTable.GetStringId($@"ship_1"),
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
                    PaletteIndex = 2,
                    NameIndex = 4,
                    Position = new RealPoint3d(452.4061f, 53.32013f, -279.9997f),
                    UniqueHandle = new DatumHandle(27392, 84),
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = 0,
                        ParentMarker = CacheContext.StringTable.GetStringId($@"clouds_ark"),
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
                    PaletteIndex = 5,
                    NameIndex = 7,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(5.117751f, 12.88167f, -1.350703f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(36.05838f), Angle.FromDegrees(-11.26188f), Angle.FromDegrees(8.477079f)),
                    Scale = 1f,
                    UniqueHandle = new DatumHandle(35136, 86),
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
                    PaletteIndex = 4,
                    NameIndex = 5,
                    Position = new RealPoint3d(-30.08521f, -55.62581f, -32.66299f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(35212, 87),
                    OriginBspIndex = 1,
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
                    CanAttachToBspFlags = 2,
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
                    PaletteIndex = 6,
                    NameIndex = 6,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(5.49919f, 13.35025f, -0.64973f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-29.09379f), Angle.FromDegrees(-14.37994f), Angle.FromDegrees(7.868167f)),
                    UniqueHandle = new DatumHandle(35572, 88),
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
                    PaletteIndex = 4,
                    NameIndex = 8,
                    Position = new RealPoint3d(-109.6182f, -230.9343f, 250.3744f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(134.7043f), Angle.FromDegrees(-46.78879f), Angle.FromDegrees(-33.98746f)),
                    UniqueHandle = new DatumHandle(37648, 91),
                    OriginBspIndex = -1,
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
                    PaletteIndex = 7,
                    NameIndex = 9,
                    Position = new RealPoint3d(464.8235f, 136.6842f, -279.9998f),
                    ManualBspFlags = 3,
                    UniqueHandle = new DatumHandle(39252, 93),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    BspPolicy = Scenario.ScenarioInstance.BspPolicyValue.ManualBspIndex,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = 0,
                        ParentMarker = CacheContext.StringTable.GetStringId($@"ark"),
                    },
                    CanAttachToBspFlags = 3,
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
                    PaletteIndex = 8,
                    NameIndex = 10,
                    Position = new RealPoint3d(1000f, -267.791f, -380.6325f),
                    Scale = 1.75f,
                    UniqueHandle = new DatumHandle(40940, 100),
                    OriginBspIndex = -1,
                    ObjectType = new GameObjectType8
                    {
                        Halo3ODST = GameObjectTypeHalo3ODST.Scenery,
                    },
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = 0,
                        ParentMarker = CacheContext.StringTable.GetStringId($@"forerunner_ship"),
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
                    NameIndex = 11,
                    Position = new RealPoint3d(249.5646f, 21.54015f, 180.405f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(90.27715f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(42588, 101),
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
                    PaletteIndex = 9,
                    NameIndex = 12,
                    Position = new RealPoint3d(160.7892f, 282.5293f, -249.9998f),
                    UniqueHandle = new DatumHandle(43576, 103),
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
                    PaletteIndex = 9,
                    NameIndex = 13,
                    Position = new RealPoint3d(134.8648f, 220.8092f, -249.9998f),
                    UniqueHandle = new DatumHandle(43576, 104),
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
                    PaletteIndex = 10,
                    NameIndex = 32,
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
                    Variant = CacheContext.StringTable.GetStringId($@"enemy_no_turret"),
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
                    PaletteIndex = 11,
                    NameIndex = 36,
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
                    PaletteIndex = 12,
                    NameIndex = 37,
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
                    PaletteIndex = 12,
                    NameIndex = 38,
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
            };
            scnr.SceneryPalette = new List<Scenario.ScenarioPaletteEntry>
            {
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\matte_appearance\matte_appearance"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\cov_cruiser_cheap\cov_cruiser_cheap"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\skies\clouds_ark\clouds_ark"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\vehicles\cov_cruiser\cov_cruiser_digging"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\matchmaking_earth\matchmaking_earth"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\warthog_cheap\warthog_cheap"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\monitor_cheap\monitor_cheap"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\ark_cheap\ark_cheap"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\forerunner_ship_cheap\forerunner_ship"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\banshee_cheap\banshee_cheap"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\vehicles\phantom\hirez_cinematic_phantom"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\weapons\pistol\automag\automag"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Scenery>($@"objects\weapons\rifle\smg_silenced\smg_silenced"),
                },
            };
            scnr.Bipeds = new List<Scenario.BipedInstance>
            {
                new Scenario.BipedInstance
                {
                    PaletteIndex = 0,
                    NameIndex = 15,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(-45f, -10f, -34.99976f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(42040, 26),
                    OriginBspIndex = -1,
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 2,
                },
                new Scenario.BipedInstance
                {
                    PaletteIndex = 6,
                    NameIndex = 14,
                    PlacementFlags = Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(-45f, -10f, -34.99976f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-180f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(42040, 27),
                    OriginBspIndex = -1,
                    Source = Scenario.ScenarioInstance.SourceValue.Editor,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    CanAttachToBspFlags = 2,
                },
                new Scenario.BipedInstance
                {
                    PaletteIndex = 2,
                    NameIndex = 17,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(-3.065369f, -4.330749f, -1.151731f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(66.6044f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(35124, 36),
                    OriginBspIndex = -1,
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
                    NameIndex = 16,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically | Scenario.ObjectPlacementFlags.CreateAtRest,
                    Position = new RealPoint3d(-3.682616f, -4.602558f, -1.16243f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(52.07759f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(35124, 37),
                    OriginBspIndex = -1,
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
                    NameIndex = 19,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(-7.401524f, -1.076341f, -1.460741f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-37.79264f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(35128, 41),
                    OriginBspIndex = -1,
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
                    PaletteIndex = 5,
                    NameIndex = 18,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(-7.560285f, -0.6917072f, -1.520749f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-116.8475f), Angle.FromDegrees(0f), Angle.FromDegrees(0f)),
                    UniqueHandle = new DatumHandle(35128, 38),
                    OriginBspIndex = -1,
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
                    PaletteIndex = 4,
                    NameIndex = 34,
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
                    Variant = CacheContext.StringTable.GetStringId($@"mainmenu_odst01"),
                },
                new Scenario.BipedInstance
                {
                    PaletteIndex = 4,
                    NameIndex = 35,
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
                    Variant = CacheContext.StringTable.GetStringId($@"mainmenu_odst01"),
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
                    Object = GetCachedTag<Biped>($@"objects\characters\dervish\dervish"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Biped>($@"objects\characters\masterchief\masterchief"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Biped>($@"levels\ui\mainmenu\objects\spartan_cheap\spartan_cheap"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Biped>($@"levels\ui\mainmenu\objects\odst_recon_cheap\odst_recon_cheap"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Biped>($@"levels\ui\mainmenu\objects\elite_cheap\elite_cheap"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Biped>($@"objects\characters\elite\mp_elite\mp_elite"),
                },
            };
            scnr.LightVolumes = new List<Scenario.LightVolumeInstance>
            {
                new Scenario.LightVolumeInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(-44.84623f, -10.35312f, -34.05933f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(2.24619E-08f), Angle.FromDegrees(11.43129f), Angle.FromDegrees(-149.7608f)),
                    OriginBspIndex = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    PowerGroup = -1,
                    PositionGroup = -1,
                    Type2 = Scenario.LightVolumeInstance.TypeValue2.Projective,
                    X = -45.04442f,
                    Y = -9.859501f,
                    Z = -34.90612f,
                    Width = 1f,
                    HeightScale = 1f,
                    FieldOfView = Angle.FromDegrees(60f),
                    FalloffDistance = 0.4414063f,
                    CutoffDistance = 0.9999984f,
                },
                new Scenario.LightVolumeInstance
                {
                    NameIndex = -1,
                    Position = new RealPoint3d(-44.65631f, -20.28198f, -33.87003f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(-2.370878E-08f), Angle.FromDegrees(17.19552f), Angle.FromDegrees(-153.8557f)),
                    OriginBspIndex = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    PowerGroup = -1,
                    PositionGroup = -1,
                    Type2 = Scenario.LightVolumeInstance.TypeValue2.Projective,
                    X = -44.95195f,
                    Y = -19.86103f,
                    Z = -34.72758f,
                    Width = 1f,
                    HeightScale = 1f,
                    FieldOfView = Angle.FromDegrees(60f),
                    FalloffDistance = 0.4414063f,
                    CutoffDistance = 0.9999979f,
                },
                new Scenario.LightVolumeInstance
                {
                    PaletteIndex = 1,
                    NameIndex = -1,
                    Position = new RealPoint3d(-45.11104f, -19.56704f, -34.76589f),
                    OriginBspIndex = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    PowerGroup = -1,
                    PositionGroup = -1,
                    X = -45.11104f,
                    Y = -19.56706f,
                    Z = -30.76589f,
                    Width = 1f,
                    HeightScale = 1f,
                    FalloffDistance = 0.4414063f,
                    CutoffDistance = 4f,
                },
                new Scenario.LightVolumeInstance
                {
                    PaletteIndex = 1,
                    NameIndex = -1,
                    Position = new RealPoint3d(-45.06665f, -9.585737f, -34.64215f),
                    OriginBspIndex = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    PowerGroup = -1,
                    PositionGroup = -1,
                    X = -45.06665f,
                    Y = -9.585737f,
                    Z = -33.44215f,
                    Width = 1f,
                    HeightScale = 1f,
                    FalloffDistance = 0.4414063f,
                    CutoffDistance = 4f,
                },
                new Scenario.LightVolumeInstance
                {
                    PaletteIndex = 2,
                    NameIndex = 28,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(-6.858373f, 0.09113751f, -1.063934f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(63.09137f), Angle.FromDegrees(17.67388f), Angle.FromDegrees(92.07263f)),
                    OriginBspIndex = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    PowerGroup = -1,
                    PositionGroup = -1,
                    Type2 = Scenario.LightVolumeInstance.TypeValue2.Projective,
                    Flags = 1,
                    X = -7.494576f,
                    Y = -0.9573539f,
                    Z = -1.009141f,
                    Width = 1.839451f,
                    HeightScale = 1f,
                    FieldOfView = Angle.FromDegrees(75.35489f),
                    FalloffDistance = 0.6302913f,
                    CutoffDistance = 1.189611f,
                },
                new Scenario.LightVolumeInstance
                {
                    PaletteIndex = 3,
                    NameIndex = 29,
                    PlacementFlags = Scenario.ObjectPlacementFlags.NotAutomatically,
                    Position = new RealPoint3d(-3.634852f, -3.120619f, -0.9906012f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(7.247242f), Angle.FromDegrees(-10.34807f), Angle.FromDegrees(60.06319f)),
                    OriginBspIndex = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    PowerGroup = -1,
                    PositionGroup = -1,
                    Type2 = Scenario.LightVolumeInstance.TypeValue2.Projective,
                    Flags = 1,
                    X = -2.945851f,
                    Y = -6.390334f,
                    Z = 0.8923973f,
                    Width = 0.015625f,
                    HeightScale = 1f,
                    FieldOfView = Angle.FromDegrees(125.9875f),
                    FalloffDistance = 0.4414063f,
                    CutoffDistance = 3.835549f,
                },
                new Scenario.LightVolumeInstance
                {
                    PaletteIndex = 5,
                    NameIndex = 30,
                    Position = new RealPoint3d(6.8576f, 12.80801f, 0.6717849f),
                    Rotation = new RealEulerAngles3d(Angle.FromDegrees(3.833187f), Angle.FromDegrees(48.52651f), Angle.FromDegrees(179.0844f)),
                    OriginBspIndex = -1,
                    EditorFolder = -1,
                    ParentId = new ScenarioObjectParentStruct
                    {
                        NameIndex = -1,
                    },
                    PowerGroup = -1,
                    PositionGroup = -1,
                    Type2 = Scenario.LightVolumeInstance.TypeValue2.Projective,
                    Flags = 1,
                    X = 4.706595f,
                    Y = 12.08864f,
                    Z = -0.4163572f,
                    Width = 0.015625f,
                    HeightScale = 1f,
                    FieldOfView = Angle.FromDegrees(111.5836f),
                    FalloffDistance = 0.4414063f,
                    CutoffDistance = 2.339835f,
                },
                new Scenario.LightVolumeInstance
                {
                    PaletteIndex = 6,
                    NameIndex = 33,
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
                    Object = GetCachedTag<Light>($@"levels\ui\mainmenu\lights\appearance"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Light>($@"levels\ui\mainmenu\lights\appearance_fill"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Light>($@"levels\ui\mainmenu\lights\custom_games"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Light>($@"levels\ui\mainmenu\lights\campaign"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Light>($@"levels\ui\mainmenu\lights\theater"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Light>($@"levels\ui\mainmenu\lights\editor"),
                },
                new Scenario.ScenarioPaletteEntry
                {
                    Object = GetCachedTag<Light>($@"objects\vehicles\phantom\fx\running\cinematic_gravlift"),
                },
            };
            scnr.Scripts = null;
            scnr.Globals = null;
            scnr.ScriptSourceFileReferences = null;
            scnr.CutsceneCameraPoints = new List<Scenario.CutsceneCameraPoint>
            {
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"light_anchor",
                    Position = new RealPoint3d(111.9694f, 12.57247f, -80.04536f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(8.505559f), Angle.FromDegrees(-4.878534f), Angle.FromDegrees(-0.7286655f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"campaign_in",
                    Position = new RealPoint3d(-2.783262f, -3.859817f, -0.7919874f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-115.4425f), Angle.FromDegrees(-6.147651f), Angle.FromDegrees(-10.10798f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"campaign",
                    Position = new RealPoint3d(-2.658308f, -3.940777f, -0.7919874f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-126.6335f), Angle.FromDegrees(-9.414923f), Angle.FromDegrees(-10.5665f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"campaign_path_02",
                    Position = new RealPoint3d(-2.591148f, -3.69542f, -0.7919874f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-116.4707f), Angle.FromDegrees(-5.092006f), Angle.FromDegrees(-7.577425f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"campaign_path_03",
                    Position = new RealPoint3d(-2.690809f, -3.983063f, -0.7919874f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-127.1006f), Angle.FromDegrees(-10.12939f), Angle.FromDegrees(-11.28327f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"campaign_path_04",
                    Position = new RealPoint3d(-2.478235f, -4.130247f, -0.7919874f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-150.1906f), Angle.FromDegrees(-9.65366f), Angle.FromDegrees(-4.181489f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"matchmaking_in",
                    Position = new RealPoint3d(-109.2913f, -230.1818f, 249.6066f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-96.70016f), Angle.FromDegrees(-5.832463f), Angle.FromDegrees(-40.85712f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"matchmaking",
                    Position = new RealPoint3d(-108.8834f, -230.3295f, 249.6066f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-114.6049f), Angle.FromDegrees(-19.05827f), Angle.FromDegrees(-35.48944f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"mm_path_02",
                    Position = new RealPoint3d(-108.738f, -230.4373f, 249.3507f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-117.1435f), Angle.FromDegrees(-25.78415f), Angle.FromDegrees(-40.31187f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"mm_path_03",
                    Position = new RealPoint3d(-109.3495f, -230.1522f, 249.7026f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-93.07613f), Angle.FromDegrees(-2.550249f), Angle.FromDegrees(-39.61562f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"mm_path_04",
                    Position = new RealPoint3d(-108.8306f, -230.1168f, 249.7026f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-113.9313f), Angle.FromDegrees(-13.6645f), Angle.FromDegrees(-28.02653f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"custom_in",
                    Position = new RealPoint3d(-7.260052f, -1.914379f, -1.031894f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(97.76698f), Angle.FromDegrees(5.038599f), Angle.FromDegrees(0.3009008f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"custom_games",
                    Position = new RealPoint3d(-7.631313f, -1.950026f, -1.031894f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(92.50669f), Angle.FromDegrees(5.023069f), Angle.FromDegrees(0.3404699f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"custom_path_02",
                    Position = new RealPoint3d(-6.846344f, -1.798082f, -1.031894f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(109.4133f), Angle.FromDegrees(3.636668f), Angle.FromDegrees(4.827899f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"custom_path_03",
                    Position = new RealPoint3d(-7.959418f, -1.590729f, -0.8185608f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(91.69172f), Angle.FromDegrees(5.166923f), Angle.FromDegrees(-4.460439f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"custom_path_04",
                    Position = new RealPoint3d(-8.004598f, -1.976056f, -1.031894f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(79.17783f), Angle.FromDegrees(4.966138f), Angle.FromDegrees(-0.827791f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"editor",
                    Position = new RealPoint3d(7.667727f, 13.1801f, -0.7279867f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-168.5137f), Angle.FromDegrees(6.510793f), Angle.FromDegrees(2.493183f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"editor_in",
                    Position = new RealPoint3d(7.216995f, 14.35544f, -0.7279867f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-142.0234f), Angle.FromDegrees(5.122333f), Angle.FromDegrees(5.440699f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"editor_path_02",
                    Position = new RealPoint3d(7.62511f, 12.98714f, -0.6319867f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-173.1839f), Angle.FromDegrees(6.289372f), Angle.FromDegrees(1.909284f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"editor_path_03",
                    Position = new RealPoint3d(7.482448f, 13.55463f, -0.6319866f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-157.3258f), Angle.FromDegrees(7.385588f), Angle.FromDegrees(4.313767f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"editor_path_04",
                    Position = new RealPoint3d(7.482708f, 13.54315f, -0.8133199f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-156.9684f), Angle.FromDegrees(6.993937f), Angle.FromDegrees(4.207599f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"theater_in",
                    Position = new RealPoint3d(801.6006f, 133.8912f, 150.8401f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(61.80203f), Angle.FromDegrees(17.58917f), Angle.FromDegrees(21.10417f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"theater",
                    Position = new RealPoint3d(778.9628f, 148.9992f, 150.84f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(38.44106f), Angle.FromDegrees(23.91669f), Angle.FromDegrees(12.35304f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"theater_path_02",
                    Position = new RealPoint3d(789.6351f, 155.7335f, 157.6666f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(40.4451f), Angle.FromDegrees(22.85756f), Angle.FromDegrees(12.65188f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"theater_path_03",
                    Position = new RealPoint3d(783.1628f, 143.8975f, 150.8401f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(47.91618f), Angle.FromDegrees(20.02225f), Angle.FromDegrees(14.34176f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = $@"theater_path_04",
                    Position = new RealPoint3d(772.3842f, 158.1918f, 142.5201f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(37.1562f), Angle.FromDegrees(25.00277f), Angle.FromDegrees(12.41606f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "settings_cam",
                    Position = new RealPoint3d(-37.977f, -54.24f, -24.64976f),
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
                    Position = new RealPoint3d(-108.8834f, -230.3295f, 249.6066f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-114.6049f), Angle.FromDegrees(-19.05827f), Angle.FromDegrees(-35.48944f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "server_browser_path_02",
                    Position = new RealPoint3d(-108.738f, -230.4373f, 249.3507f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-117.1435f), Angle.FromDegrees(-25.78415f), Angle.FromDegrees(-40.31187f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "server_browser_path_03",
                    Position = new RealPoint3d(-109.3495f, -230.1522f, 249.7026f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-93.07613f), Angle.FromDegrees(-2.550249f), Angle.FromDegrees(-39.61562f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "server_browser_path_04",
                    Position = new RealPoint3d(-108.8306f, -230.1168f, 249.7026f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-113.9313f), Angle.FromDegrees(-13.6645f), Angle.FromDegrees(-28.02653f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_helmet_wide",
                    Position = new RealPoint3d(-38.308f, -54.34f, -24.47776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_body_wide",
                    Position = new RealPoint3d(-38.308f, -54.369f, -24.57776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_leftshoulder_wide",
                    Position = new RealPoint3d(-38.208f, -54.264f, -24.57776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_rightshoulder_wide",
                    Position = new RealPoint3d(-38.108f, -54.34f, -24.57776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_helmet_wide",
                    Position = new RealPoint3d(-38.208f, -54.31f, -24.54776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_body_wide",
                    Position = new RealPoint3d(-38.308f, -54.34f, -24.62776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_leftshoulder_wide",
                    Position = new RealPoint3d(-38.208f, -54.324f, -24.57776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_rightshoulder_wide",
                    Position = new RealPoint3d(-38.158f, -54.424f, -24.57776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_helmet_standard",
                    Position = new RealPoint3d(-38.308f, -54.424f, -24.47776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_body_standard",
                    Position = new RealPoint3d(-38.208f, -54.389f, -24.57776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_leftshoulder_standard",
                    Position = new RealPoint3d(-38.208f, -54.324f, -24.57776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "spartan_rightshoulder_standard",
                    Position = new RealPoint3d(-38.108f, -54.414f, -24.57776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_helmet_standard",
                    Position = new RealPoint3d(-38.208f, -54.364f, -24.54776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_body_standard",
                    Position = new RealPoint3d(-38.358f, -54.444f, -24.62776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_leftshoulder_standard",
                    Position = new RealPoint3d(-38.208f, -54.414f, -24.57776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
                new Scenario.CutsceneCameraPoint
                {
                    Name = "elite_rightshoulder_standard",
                    Position = new RealPoint3d(-38.158f, -54.454f, -24.57776f),
                    Orientation = new RealEulerAngles3d(Angle.FromDegrees(-135.571f), Angle.FromDegrees(0.284f), Angle.FromDegrees(0.279f)),
                },
            };
            scnr.ScriptExpressions = null;
            scnr.SimulationDefinitionTable = null;
            scnr.EditorFolders = null;
            CacheContext.Serialize(Stream, tag, scnr);

            CompileScript(tag, $@"{Program.TagToolDirectory}\Tools\BaseCache\Scripts\mainmenu_h3.hsc");
        }
    }
}
