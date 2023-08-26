using TagTool.Tags.Definitions;
using System.Collections.Generic;
using TagTool.Common;
using TagTool.Geometry;
using TagTool.Commands.Editing;
using TagTool.Commands.Common;

namespace TagTool.Commands.Tags 
{
    partial class BaseCacheHaloOnlineCommand : Command 
    {
        public void ScenarioPatches() 
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                Cache.StringTable.Add("menu_spartan2");
                Cache.StringTable.Add("menu_spartan1");
                Cache.StringTable.Add("mainmenu_odst01");
                Cache.SaveStrings();

                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    if (tag.IsInGroup("scnr") && tag.Name == $@"levels\ui\mainmenu\mainmenu") 
                    {
                        var scnr = CacheContext.Deserialize<Scenario>(stream, tag);
                        scnr.MapId = 270735729;
                        scnr.MapType = ScenarioMapType.MainMenu;
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
                                PlacementIndex = 3
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
                        scnr.Scenery[7].UniqueHandle = new DatumHandle(0, 3);
                        scnr.Scenery.Add(new Scenario.SceneryInstance());
                        scnr.Scenery.Add(new Scenario.SceneryInstance());
                        scnr.Scenery.Add(new Scenario.SceneryInstance());
                        scnr.Scenery.Add(new Scenario.SceneryInstance());
                        scnr.Scenery.Add(new Scenario.SceneryInstance());
                        scnr.Scenery.Add(new Scenario.SceneryInstance());
                        scnr.Scenery.Add(new Scenario.SceneryInstance());
                        scnr.Scenery[8] = new Scenario.SceneryInstance 
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
                        };
                        scnr.Scenery[9] = new Scenario.SceneryInstance
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
                        };
                        scnr.Scenery[10] = new Scenario.SceneryInstance 
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
                            Variant = CacheContext.StringTable.GetStringId("enemy_no_turret"),
                            AiSpawningSquad = -1,
                            Multiplayer = new Scenario.MultiplayerObjectProperties
                            {
                                MapVariantParent = new ScenarioObjectParentStruct
                                {
                                    NameIndex = -1,
                                },
                            },
                        };
                        scnr.Scenery[11] = new Scenario.SceneryInstance 
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
                        };
                        scnr.Scenery[12] = new Scenario.SceneryInstance 
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
                        };
                        scnr.Scenery[13] = new Scenario.SceneryInstance 
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
                        };
                        scnr.Scenery[14] = new Scenario.SceneryInstance 
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
                        };
                        scnr.SceneryPalette.Add(new Scenario.ScenarioPaletteEntry());
                        scnr.SceneryPalette.Add(new Scenario.ScenarioPaletteEntry());
                        scnr.SceneryPalette.Add(new Scenario.ScenarioPaletteEntry());
                        scnr.SceneryPalette.Add(new Scenario.ScenarioPaletteEntry());
                        scnr.SceneryPalette.Add(new Scenario.ScenarioPaletteEntry());
                        scnr.SceneryPalette.Add(new Scenario.ScenarioPaletteEntry());
                        scnr.SceneryPalette[26] = new Scenario.ScenarioPaletteEntry
                        {
                            Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\monitor_cheap\monitor_cheap"),
                        };
                        scnr.SceneryPalette[27] = new Scenario.ScenarioPaletteEntry
                        {
                            Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\warthog_cheap\warthog_cheap"),
                        };
                        scnr.SceneryPalette[28] = new Scenario.ScenarioPaletteEntry
                        {
                            Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\vehicles\phantom\hirez_cinematic_phantom"),
                        };
                        scnr.SceneryPalette[29] = new Scenario.ScenarioPaletteEntry
                        {
                            Object = GetCachedTag<Scenery>($@"objects\weapons\pistol\automag\automag"),
                        };
                        scnr.SceneryPalette[30] = new Scenario.ScenarioPaletteEntry
                        {
                            Object = GetCachedTag<Scenery>($@"objects\weapons\rifle\smg_silenced\smg_silenced"),
                        };
                        scnr.SceneryPalette[31] = new Scenario.ScenarioPaletteEntry
                        {
                            Object = GetCachedTag<Scenery>($@"levels\ui\mainmenu\objects\matchmaking_earth\matchmaking_earth"),
                        };
                        scnr.Bipeds[0].UniqueHandle = new DatumHandle(0, 4);
                        scnr.Bipeds.Add(new Scenario.BipedInstance());
                        scnr.Bipeds.Add(new Scenario.BipedInstance());
                        scnr.Bipeds.Add(new Scenario.BipedInstance());
                        scnr.Bipeds.Add(new Scenario.BipedInstance());
                        scnr.Bipeds.Add(new Scenario.BipedInstance());
                        scnr.Bipeds.Add(new Scenario.BipedInstance());
                        scnr.Bipeds.Add(new Scenario.BipedInstance());
                        scnr.Bipeds[1] = new Scenario.BipedInstance 
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
                            CanAttachToBspFlags = 1
                        };
                        scnr.Bipeds[2] = new Scenario.BipedInstance
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
                            CanAttachToBspFlags = 1
                        };
                        scnr.Bipeds[3] = new Scenario.BipedInstance
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
                            Variant = CacheContext.StringTable.GetStringId($@"menu_spartan2"),
                            ActiveChangeColors = Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Primary | Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Secondary | Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Tertiary | Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Quaternary,
                            PrimaryColor = new ArgbColor(255, 41, 41, 41),
                            SecondaryColor = new ArgbColor(255, 211, 68, 68),
                            TertiaryColor = new ArgbColor(255, 255, 148, 0),
                            QuaternaryColor = new ArgbColor(255, 255, 255, 255),
                        };
                        scnr.Bipeds[4] = new Scenario.BipedInstance
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
                            Variant = CacheContext.StringTable.GetStringId($@"menu_spartan1"),
                            ActiveChangeColors = Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Primary | Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Secondary | Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Tertiary | Scenario.PermutationInstance.ScenarioObjectActiveChangeColorFlags.Quaternary,
                            PrimaryColor = new ArgbColor(255, 86, 86, 86),
                            SecondaryColor = new ArgbColor(255, 41, 49, 92),
                            TertiaryColor = new ArgbColor(255, 255, 148, 0),
                            QuaternaryColor = new ArgbColor(255, 255, 255, 255),
                        };
                        scnr.Bipeds[5] = new Scenario.BipedInstance
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
                            Variant = CacheContext.StringTable.GetStringId($@"mainmenu_odst01"),
                        };
                        scnr.Bipeds[6] = new Scenario.BipedInstance
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
                            Variant = CacheContext.StringTable.GetStringId($@"mainmenu_odst01"),
                        };
                        scnr.Bipeds[7] = new Scenario.BipedInstance
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
                                Object = GetCachedTag<Biped>($@"objects\characters\elite\mp_elite\mp_elite"),
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
                                Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle"),
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
                                HeightScale = 1,
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
                                HeightScale = 1,
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
                                HeightScale = 1,
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
                                Width = 1,
                                HeightScale = 1,
                            },
                        };
                        scnr.LightVolumePalette = new List<Scenario.ScenarioPaletteEntry>
                        {
                            new Scenario.ScenarioPaletteEntry
                            {
                                Object = GetCachedTag<Light>($@"levels\ui\mainmenu\lights\campaign"),
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
                                Object = GetCachedTag<Light>($@"objects\vehicles\phantom\fx\running\cinematic_gravlift"),
                            },
                        };
                        scnr.Scripts = null;
                        scnr.Globals = null;
                        scnr.ScriptSourceFileReferences = new List<TagReferenceBlock>
                        {
                            new TagReferenceBlock
                            {
                                Instance = GetCachedTag<ModelAnimationGraph>($@"objects\characters\cinematic_camera\ui\valhalla\valhalla"),
                            },
                            new TagReferenceBlock
                            {
                                Instance = GetCachedTag<SoundLooping>($@"sound\vehicles\phantom\phantom_engine_right\phantom_engine_right"),
                            },
                            new TagReferenceBlock
                            {
                                Instance = GetCachedTag<SoundLooping>($@"sound\vehicles\phantom\phantom_hover_right\phantom_hover_right"),
                            },
                            new TagReferenceBlock
                            {
                                Instance = GetCachedTag<SoundLooping>($@"sound\vehicles\phantom\phantom_engine_lod\phantom_engine_lod"),
                            },
                            new TagReferenceBlock
                            {
                                Instance = GetCachedTag<SoundLooping>($@"sound\levels\main_menu\the_world\the_world"),
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
                        
                        scnr.Crates.Add(new Scenario.CrateInstance());
                        scnr.Crates[102] = new Scenario.CrateInstance
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
                        };
                        scnr.CratePalette.Add(new Scenario.ScenarioPaletteEntry());
                        scnr.CratePalette[43] = new Scenario.ScenarioPaletteEntry 
                        {
                            Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x20x20_black_mainmenu"),
                        };
                        scnr.EditorFolders = null;
                        scnr.PerformanceThrottles = GetCachedTag<PerformanceThrottles>($@"levels\multi\riverworld\riverworld");

                        ContextStack.Push(EditTagContextFactory.Create(ContextStack, Cache, tag, scnr));
                        CommandRunner.Current.RunCommand($@"compilescripts ""{Program.TagToolDirectory}\Tools\BaseCache\Scripts\mainmenu.hsc""");
                        ContextStack.Pop();

                        CacheContext.Serialize(stream, tag, scnr);
                    }

                    if (tag.IsInGroup("scnr") && tag.Name == $@"levels\multi\guardian\guardian")
                    {
                        var scnr = CacheContext.Deserialize<Scenario>(stream, tag);
                        scnr.SandboxVehicles = null;
                        scnr.SandboxWeapons = null;
                        scnr.SandboxEquipment = null;
                        scnr.SandboxScenery = null;
                        scnr.SandboxTeleporters = null;
                        scnr.SandboxGoalObjects = null;
                        scnr.SandboxSpawning = null;
                        scnr.PlayerStartingProfile = new List<Scenario.PlayerStartingProfileBlock>
                        {
                            new Scenario.PlayerStartingProfileBlock
                            {
                                Name = "start_assault",
                                PrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
                                PrimaryRoundsLoaded = 32,
                                PrimaryRoundsTotal = 96,
                                SecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum"),
                                SecondaryRoundsLoaded = 8,
                                SecondaryRoundsTotal = 24,
                                StartingFragGrenadeCount = 2,
                                EditorFolder = -1,
                            },
                        };
                        scnr.AcousticsPalette = new List<ScenarioStructureBsp.AcousticsPaletteBlock>
                        {
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"gaurdian"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\cpaul_jungle4"),
                                ReverbCutoffDistance = 1,
                                ReverbInterpolationSpeed = 0.2f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\gaurdian\gaurdian\gaurdian"),
                                AmbienceCutoffDistance = 3,
                                AmbienceInterpolationSpeed = 0.5f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"gaurdian_inside"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\jay_hallway"),
                                ReverbCutoffDistance = 1,
                                ReverbInterpolationSpeed = 0.2f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\gaurdian\gaurdian_half_inside\gaurdian_half_inside"),
                                AmbienceCutoffDistance = 3,
                                AmbienceInterpolationSpeed = 0.5f,
                            },
                        };
                        CacheContext.Serialize(stream, tag, scnr);
                    }

                    if (tag.IsInGroup("scnr") && tag.Name == $@"levels\multi\riverworld\riverworld")
                    {
                        var scnr = CacheContext.Deserialize<Scenario>(stream, tag);
                        scnr.SandboxVehicles = null;
                        scnr.SandboxWeapons = null;
                        scnr.SandboxEquipment = null;
                        scnr.SandboxScenery = null;
                        scnr.SandboxTeleporters = null;
                        scnr.SandboxGoalObjects = null;
                        scnr.SandboxSpawning = null;
                        scnr.PlayerStartingProfile = new List<Scenario.PlayerStartingProfileBlock>
                        {
                            new Scenario.PlayerStartingProfileBlock
                            {
                                Name = "start_assault",
                                PrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
                                PrimaryRoundsLoaded = 32,
                                PrimaryRoundsTotal = 96,
                                SecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum"),
                                SecondaryRoundsLoaded = 8,
                                SecondaryRoundsTotal = 24,
                                StartingFragGrenadeCount = 2,
                                EditorFolder = -1,
                            },
                        };
                        scnr.AcousticsPalette = new List<ScenarioStructureBsp.AcousticsPaletteBlock>
                        {
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"halo_exterior"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\mountains"),
                                ReverbCutoffDistance = 1,
                                ReverbInterpolationSpeed = 0.25f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\riverworld\halo_ext\halo_ext"),
                                AmbienceCutoffDistance = 1,
                                AmbienceInterpolationSpeed = 0.5f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"interior"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\stone_room"),
                                ReverbCutoffDistance = 1,
                                ReverbInterpolationSpeed = 0.25f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\riverworld\riverworld_interior\riverworld_interior"),
                                AmbienceCutoffDistance = 1,
                                AmbienceInterpolationSpeed = 0.5f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"interior_tunnel"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\jay_stone_room"),
                                ReverbCutoffDistance = 1,
                                ReverbInterpolationSpeed = 0.25f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\riverworld\riverworld_interior\riverworld_interior"),
                                AmbienceCutoffDistance = 1,
                                AmbienceInterpolationSpeed = 0.5f,
                            },
                        };
                        CacheContext.Serialize(stream, tag, scnr);
                    }

                    if (tag.IsInGroup("scnr") && tag.Name == $@"levels\multi\s3d_avalanche\s3d_avalanche")
                    {
                        var scnr = CacheContext.Deserialize<Scenario>(stream, tag);
                        scnr.SandboxVehicles = null;
                        scnr.SandboxWeapons = null;
                        scnr.SandboxEquipment = null;
                        scnr.SandboxScenery = null;
                        scnr.SandboxTeleporters = null;
                        scnr.SandboxGoalObjects = null;
                        scnr.SandboxSpawning = null;
                        scnr.PlayerStartingProfile = new List<Scenario.PlayerStartingProfileBlock>
                        {
                            new Scenario.PlayerStartingProfileBlock
                            {
                                Name = "start_assault",
                                PrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
                                PrimaryRoundsLoaded = 32,
                                PrimaryRoundsTotal = 96,
                                SecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum"),
                                SecondaryRoundsLoaded = 8,
                                SecondaryRoundsTotal = 24,
                                StartingFragGrenadeCount = 2,
                                EditorFolder = -1,
                            },
                        };
                        scnr.AcousticsPalette = new List<ScenarioStructureBsp.AcousticsPaletteBlock>
                        {
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"desert_wind"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\mountains"),
                                ReverbInterpolationSpeed = 1f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_diamondback\amb_desert_wind\amb_desert_wind"),
                                AmbienceInterpolationSpeed = 1f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"general_roomtone"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\hallway"),
                                ReverbInterpolationSpeed = 1f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_diamondback\amb_gen_roomtone\amb_gen_roomtone"),
                                AmbienceInterpolationSpeed = 1f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"cave_wind"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\cave"),
                                ReverbInterpolationSpeed = 1f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_diamondback\amb_cave_wind\amb_cave_wind"),
                                AmbienceInterpolationSpeed = 1f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"cave_wind_and_drips"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\cave"),
                                ReverbInterpolationSpeed = 1f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_diamondback\amb_cave_wind_and_drips\amb_cave_wind_and_drips"),
                                AmbienceInterpolationSpeed = 1f,
                            },
                        };
                        CacheContext.Serialize(stream, tag, scnr);
                    }

                    if (tag.IsInGroup("scnr") && tag.Name == $@"levels\multi\s3d_edge\s3d_edge")
                    {
                        var scnr = CacheContext.Deserialize<Scenario>(stream, tag);
                        scnr.SandboxVehicles = null;
                        scnr.SandboxWeapons = null;
                        scnr.SandboxEquipment = null;
                        scnr.SandboxScenery = null;
                        scnr.SandboxTeleporters = null;
                        scnr.SandboxGoalObjects = null;
                        scnr.SandboxSpawning = null;
                        scnr.EnemyBiasInfluence = new List<Scenario.PlayerSpawnInfluencerBlock>
                        {
                            new Scenario.PlayerSpawnInfluencerBlock
                            {
                                OverrideFullWeightRadius = 10f,
                                OverrideFalloffRadius = 17f,
                                OverrideUpperHeight = 4f,
                                OverrideLowerHeight = -5f,
                                OverrideWeight = -250f,
                            },
                        };
                        scnr.PlayerStartingProfile = new List<Scenario.PlayerStartingProfileBlock>
                        {
                            new Scenario.PlayerStartingProfileBlock
                            {
                                Name = "start_assault",
                                PrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
                                PrimaryRoundsLoaded = 32,
                                PrimaryRoundsTotal = 96,
                                SecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum"),
                                SecondaryRoundsLoaded = 8,
                                SecondaryRoundsTotal = 24,
                                StartingFragGrenadeCount = 2,
                                EditorFolder = -1,
                            },
                        };
                        scnr.AcousticsPalette = new List<ScenarioStructureBsp.AcousticsPaletteBlock>
                        {
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"amb_cave_dry"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\cave"),
                                Type = ScenarioStructureBsp.SoundEnvironmentType.InteriorNarrow,
                                ReverbInterpolationSpeed = 2f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_edge\amb_cave_dry\amb_cave_dry"),
                                AmbienceInterpolationSpeed = 2f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"amb_edge_open_air"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\mountains"),
                                ReverbInterpolationSpeed = 2f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_edge\amb_edge_open_air\amb_edge_open_air"),
                                AmbienceInterpolationSpeed = 2f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"amb_sentinel_room"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\auditorium"),
                                Type = ScenarioStructureBsp.SoundEnvironmentType.InteriorNarrow,
                                ReverbInterpolationSpeed = 2f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_edge\amb_sentinel_room\amb_sentinel_room"),
                                AmbienceInterpolationSpeed = 2f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"amb_tech_room"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\hallway"),
                                Type = ScenarioStructureBsp.SoundEnvironmentType.InteriorNarrow,
                                ReverbInterpolationSpeed = 2f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_edge\amb_tech_room\amb_tech_room"),
                                AmbienceInterpolationSpeed = 2f,
                            },
                        };
                        CacheContext.Serialize(stream, tag, scnr);
                    }

                    if (tag.IsInGroup("scnr") && tag.Name == $@"levels\multi\s3d_reactor\s3d_reactor")
                    {
                        var scnr = CacheContext.Deserialize<Scenario>(stream, tag);
                        scnr.SandboxVehicles = null;
                        scnr.SandboxWeapons = null;
                        scnr.SandboxEquipment = null;
                        scnr.SandboxScenery = null;
                        scnr.SandboxTeleporters = null;
                        scnr.SandboxGoalObjects = null;
                        scnr.SandboxSpawning = null;
                        scnr.PlayerStartingProfile = new List<Scenario.PlayerStartingProfileBlock>
                        {
                            new Scenario.PlayerStartingProfileBlock
                            {
                                Name = "start_assault",
                                PrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
                                PrimaryRoundsLoaded = 32,
                                PrimaryRoundsTotal = 96,
                                SecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum"),
                                SecondaryRoundsLoaded = 8,
                                SecondaryRoundsTotal = 24,
                                StartingFragGrenadeCount = 2,
                                EditorFolder = -1,
                            },
                        };
                        scnr.AcousticsPalette = new List<ScenarioStructureBsp.AcousticsPaletteBlock>
                        {
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"amb_wind_mountains"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\mountains"),
                                ReverbInterpolationSpeed = 2f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_reactor\amb_wind_mountains\amb_wind_mountains"),
                                AmbienceInterpolationSpeed = 2f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"amb_interior_room_small"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\room"),
                                Type = ScenarioStructureBsp.SoundEnvironmentType.InteriorNarrow,
                                ReverbInterpolationSpeed = 2f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_reactor\amb_interior_room_small\amb_interior_room_small"),
                                AmbienceInterpolationSpeed = 2f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"amb_interior_reactor"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\hallway"),
                                Type = ScenarioStructureBsp.SoundEnvironmentType.InteriorNarrow,
                                ReverbInterpolationSpeed = 2f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_reactor\amb_interior_reactor\amb_interior_reactor"),
                                AmbienceInterpolationSpeed = 2f,
                            },
                        };
                        CacheContext.Serialize(stream, tag, scnr);
                    }

                    if (tag.IsInGroup("scnr") && tag.Name == $@"levels\multi\s3d_turf\s3d_turf")
                    {
                        var scnr = CacheContext.Deserialize<Scenario>(stream, tag);
                        scnr.SandboxVehicles = null;
                        scnr.SandboxWeapons = null;
                        scnr.SandboxEquipment = null;
                        scnr.SandboxScenery = null;
                        scnr.SandboxTeleporters = null;
                        scnr.SandboxGoalObjects = null;
                        scnr.SandboxSpawning = null;
                        scnr.PlayerStartingProfile = new List<Scenario.PlayerStartingProfileBlock>
                        {
                            new Scenario.PlayerStartingProfileBlock
                            {
                                Name = "start_assault",
                                PrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
                                PrimaryRoundsLoaded = 32,
                                PrimaryRoundsTotal = 96,
                                SecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum"),
                                SecondaryRoundsLoaded = 8,
                                SecondaryRoundsTotal = 24,
                                StartingFragGrenadeCount = 2,
                                EditorFolder = -1,
                            },
                        };
                        scnr.EnemyBiasInfluence = new List<Scenario.PlayerSpawnInfluencerBlock>
                        {
                            new Scenario.PlayerSpawnInfluencerBlock
                            {
                                OverrideFullWeightRadius = 15f,
                                OverrideFalloffRadius = 20f,
                                OverrideUpperHeight = 7f,
                                OverrideLowerHeight = -5f,
                                OverrideWeight = -270f,
                            },
                        };
                        scnr.AcousticsPalette = new List<ScenarioStructureBsp.AcousticsPaletteBlock>
                        {
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"amb_heavy_snow"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\city"),
                                ReverbInterpolationSpeed = 0.5f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_turf\amb_heavy_snow\amb_heavy_snow"),
                                AmbienceCutoffDistance = 1,
                                AmbienceInterpolationSpeed = 0.5f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"amb_light_snow"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\hallway"),
                                ReverbInterpolationSpeed = 2f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_turf\amb_light_snow\amb_light_snow"),
                                AmbienceCutoffDistance = 1,
                                AmbienceInterpolationSpeed = 2f,
                            },
                        };
                        CacheContext.Serialize(stream, tag, scnr);
                    }

                    if (tag.IsInGroup("scnr") && tag.Name == $@"levels\multi\cyberdyne\cyberdyne")
                    {
                        var scnr = CacheContext.Deserialize<Scenario>(stream, tag);
                        scnr.SandboxVehicles = null;
                        scnr.SandboxWeapons = null;
                        scnr.SandboxEquipment = null;
                        scnr.SandboxScenery = null;
                        scnr.SandboxTeleporters = null;
                        scnr.SandboxGoalObjects = null;
                        scnr.SandboxSpawning = null;
                        scnr.PlayerStartingProfile = new List<Scenario.PlayerStartingProfileBlock>
                        {
                            new Scenario.PlayerStartingProfileBlock
                            {
                                Name = "start_assault",
                                PrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
                                PrimaryRoundsLoaded = 32,
                                PrimaryRoundsTotal = 96,
                                SecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum"),
                                SecondaryRoundsLoaded = 8,
                                SecondaryRoundsTotal = 24,
                                StartingFragGrenadeCount = 2,
                                EditorFolder = -1,
                            },
                        };
                        scnr.AcousticsPalette = new List<ScenarioStructureBsp.AcousticsPaletteBlock>
                        {
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"main_hallway"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"ms30\sound\dsp_effects\reverbs\halo_3_presets\jay_stone_room"),
                                ReverbCutoffDistance = 1f,
                                ReverbInterpolationSpeed = 0.1f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\cyberdyne\cyberdyne_main_hallway\cyberdyne_main_hallway"),
                                AmbienceCutoffDistance = 2f,
                                AmbienceInterpolationSpeed = 0.1f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"cyberdyne_main"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\cave_salvation_cpaul"),
                                ReverbCutoffDistance = 1f,
                                ReverbInterpolationSpeed = 0.1f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\cyberdyne\cyberdyne_main\cyberdyne_main"),
                                AmbienceCutoffDistance = 2f,
                                AmbienceInterpolationSpeed = 0.1f,
                            },
                        };
                        CacheContext.Serialize(stream, tag, scnr);
                    }

                    if (tag.IsInGroup("scnr") && tag.Name == $@"levels\multi\chill\chill")
                    {
                        var scnr = CacheContext.Deserialize<Scenario>(stream, tag);
                        scnr.SandboxVehicles = null;
                        scnr.SandboxWeapons = null;
                        scnr.SandboxEquipment = null;
                        scnr.SandboxScenery = null;
                        scnr.SandboxTeleporters = null;
                        scnr.SandboxGoalObjects = null;
                        scnr.SandboxSpawning = null;
                        scnr.PlayerStartingProfile = new List<Scenario.PlayerStartingProfileBlock>
                        {
                            new Scenario.PlayerStartingProfileBlock
                            {
                                Name = "start_assault",
                                PrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
                                PrimaryRoundsLoaded = 32,
                                PrimaryRoundsTotal = 96,
                                SecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum"),
                                SecondaryRoundsLoaded = 8,
                                SecondaryRoundsTotal = 24,
                                StartingFragGrenadeCount = 2,
                                EditorFolder = -1,
                            },
                        };
                        scnr.AcousticsPalette = new List<ScenarioStructureBsp.AcousticsPaletteBlock>
                        {
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"chill"),
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\chill\chill\chill"),
                                AmbienceCutoffDistance = 2f,
                                AmbienceInterpolationSpeed = 1f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"chill_verb"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_2_presets\cpaul_little_something_slightly_bigger_new"),
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\chill\chill\chill"),
                                AmbienceCutoffDistance = 2f,
                                AmbienceInterpolationSpeed = 1f,
                            },
                        };
                        CacheContext.Serialize(stream, tag, scnr);
                    }

                    if (tag.IsInGroup("scnr") && tag.Name == $@"levels\dlc\bunkerworld\bunkerworld")
                    {
                        var scnr = CacheContext.Deserialize<Scenario>(stream, tag);
                        scnr.SandboxVehicles = null;
                        scnr.SandboxWeapons = null;
                        scnr.SandboxEquipment = null;
                        scnr.SandboxScenery = null;
                        scnr.SandboxTeleporters = null;
                        scnr.SandboxGoalObjects = null;
                        scnr.SandboxSpawning = null;
                        scnr.PlayerStartingProfile = new List<Scenario.PlayerStartingProfileBlock>
                        {
                            new Scenario.PlayerStartingProfileBlock
                            {
                                Name = "start_assault",
                                PrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
                                PrimaryRoundsLoaded = 32,
                                PrimaryRoundsTotal = 96,
                                SecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum"),
                                SecondaryRoundsLoaded = 8,
                                SecondaryRoundsTotal = 24,
                                StartingFragGrenadeCount = 2,
                                EditorFolder = -1,
                            },
                        };
                        scnr.AcousticsPalette = new List<ScenarioStructureBsp.AcousticsPaletteBlock>
                        {
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"bunkerworld_ext"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\mountains"),
                                ReverbCutoffDistance = 2f,
                                ReverbInterpolationSpeed = 1f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\dlc\bunkerworld\bunkerworld_ext\bunkerworld_ext"),
                                AmbienceCutoffDistance = 4f,
                                AmbienceInterpolationSpeed = 1.5f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"hallway"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\cpaul_stone_room"),
                                ReverbCutoffDistance = 2f,
                                ReverbInterpolationSpeed = 1f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\dlc\bunkerworld\hallway\hallway"),
                                AmbienceCutoffDistance = 3f,
                                AmbienceInterpolationSpeed = 1.5f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"controlroom"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\cpaul_stone_room"),
                                ReverbCutoffDistance = 2f,
                                ReverbInterpolationSpeed = 1f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\dlc\bunkerworld\controlroom\controlroom"),
                                AmbienceCutoffDistance = 2f,
                                AmbienceInterpolationSpeed = 1.5f,
                            },
                        };
                        CacheContext.Serialize(stream, tag, scnr);
                    }

                    if (tag.IsInGroup("scnr") && tag.Name == $@"levels\multi\zanzibar\zanzibar")
                    {
                        var scnr = CacheContext.Deserialize<Scenario>(stream, tag);
                        scnr.SandboxVehicles = null;
                        scnr.SandboxWeapons = null;
                        scnr.SandboxEquipment = null;
                        scnr.SandboxScenery = null;
                        scnr.SandboxTeleporters = null;
                        scnr.SandboxGoalObjects = null;
                        scnr.SandboxSpawning = null;
                        scnr.PlayerStartingProfile = new List<Scenario.PlayerStartingProfileBlock>
                        {
                            new Scenario.PlayerStartingProfileBlock
                            {
                                Name = "start_assault",
                                PrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
                                PrimaryRoundsLoaded = 32,
                                PrimaryRoundsTotal = 96,
                                SecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum"),
                                SecondaryRoundsLoaded = 8,
                                SecondaryRoundsTotal = 24,
                                StartingFragGrenadeCount = 2,
                                EditorFolder = -1,
                            },
                        };
                        scnr.AcousticsPalette = new List<ScenarioStructureBsp.AcousticsPaletteBlock>
                        {
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"zanzibar_courtyard"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\mountains"),
                                ReverbCutoffDistance = 2f,
                                ReverbInterpolationSpeed = 1f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\zanzibar\zanzibar_courtyard\zanzibar_courtyard"),
                                AmbienceCutoffDistance = 3f,
                                AmbienceInterpolationSpeed = 2f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"zanzibar_ocean_waves"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\mountains"),
                                ReverbCutoffDistance = 2f,
                                ReverbInterpolationSpeed = 1f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\zanzibar\zanzibar_ocean_loop\zanzibar_ocean_loop"),
                                AmbienceCutoffDistance = 2f,
                                AmbienceInterpolationSpeed = 2f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"ocean_waves_inside"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_2_presets\cpaul_little_somethin_slightly_smaller_new"),
                                ReverbCutoffDistance = 1f,
                                ReverbInterpolationSpeed = 1f,
                                AmbienceCutoffDistance = 2f,
                                AmbienceScaleFlags = ScenarioStructureBsp.BackgroundSoundScaleFlags.OverrideDefaultScale | ScenarioStructureBsp.BackgroundSoundScaleFlags.UseAdjacentClusterAsPortalScale,
                                AmbienceInteriorScale = 0.8f,
                                AmbienceInterpolationSpeed = 2f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"zanzibar_base_roomtone"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\cpaul_stone_room_zanzibar_base"),
                                Type = ScenarioStructureBsp.SoundEnvironmentType.InteriorNarrow,
                                ReverbCutoffDistance = 2f,
                                ReverbInterpolationSpeed = 1f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\zanzibar\zanzibar_base_roomtone\zanzibar_base_roomtone"),
                                AmbienceCutoffDistance = 2f,
                                AmbienceInterpolationSpeed = 2f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"zanzaibar_froman_roomtone"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\cpaul_stone_room_new_zanzibar"),
                                Type = ScenarioStructureBsp.SoundEnvironmentType.InteriorNarrow,
                                ReverbCutoffDistance = 2f,
                                ReverbInterpolationSpeed = 1f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\zanzibar\zanzibar_froman_roomtone\zanzibar_froman_roomtone"),
                                AmbienceCutoffDistance = 2f,
                                AmbienceInterpolationSpeed = 2f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"cave"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\cpaul_stone_room_new_zanzibar"),
                                ReverbCutoffDistance = 1f,
                                ReverbInterpolationSpeed = 1f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\zanzibar\zanzibar_cave\zanzibar_cave"),
                            },
                        };
                        scnr.LightmapAirprobes = new List<Scenario.LightmapAirprobe>
                        {
                            new Scenario.LightmapAirprobe
                            {
                                Position = new RealPoint3d(0.0744535f, 3.68988f, 8.19632f),
                                Name = CacheContext.StringTable.GetStringId($@"big_wheel_probe"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, scnr);
                    }

                    if (tag.IsInGroup("scnr") && tag.Name == $@"levels\multi\deadlock\deadlock")
                    {
                        var scnr = CacheContext.Deserialize<Scenario>(stream, tag);
                        scnr.SandboxVehicles = null;
                        scnr.SandboxWeapons = null;
                        scnr.SandboxEquipment = null;
                        scnr.SandboxScenery = null;
                        scnr.SandboxTeleporters = null;
                        scnr.SandboxGoalObjects = null;
                        scnr.SandboxSpawning = null;
                        scnr.PlayerStartingProfile = new List<Scenario.PlayerStartingProfileBlock>
                        {
                            new Scenario.PlayerStartingProfileBlock
                            {
                                Name = "start_assault",
                                PrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
                                PrimaryRoundsLoaded = 32,
                                PrimaryRoundsTotal = 96,
                                SecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum"),
                                SecondaryRoundsLoaded = 8,
                                SecondaryRoundsTotal = 24,
                                StartingFragGrenadeCount = 2,
                                EditorFolder = -1,
                            },
                        };
                        scnr.AcousticsPalette = new List<ScenarioStructureBsp.AcousticsPaletteBlock>
                        {
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"deadlock_air"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\mountains"),
                                ReverbCutoffDistance = 1.5f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\deadlock\deadlock_air\deadlock_air"),
                                AmbienceCutoffDistance = 3f,
                                AmbienceInterpolationSpeed = 0.5f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"deadlock_cave"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\jay_cave"),
                                ReverbCutoffDistance = 2f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\deadlock\deadlock_cave\deadlock_cave"),
                                AmbienceCutoffDistance = 2f,
                                AmbienceInterpolationSpeed = 0.5f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"deadlock_inside"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"ms30\sound\dsp_effects\reverbs\templates\stone_room"),
                                ReverbCutoffDistance = 2f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\deadlock\deadlock_inside\deadlock_inside"),
                                AmbienceCutoffDistance = 1f,
                                AmbienceInterpolationSpeed = 0.5f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"deadlock_tube"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\cpaul_sewer_pipe"),
                                ReverbCutoffDistance = 2f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\deadlock\deadlock_tube\deadlock_tube"),
                                AmbienceCutoffDistance = 1f,
                                AmbienceInterpolationSpeed = 0.5f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"deadlock_air_light"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\mountains"),
                                ReverbCutoffDistance = 2f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\deadlock\deadlock_air_light\deadlock_air_light"),
                                AmbienceCutoffDistance = 3f,
                                AmbienceInterpolationSpeed = 0.5f,
                            },
                        };
                        CacheContext.Serialize(stream, tag, scnr);
                    }

                    if (tag.IsInGroup("scnr") && tag.Name == $@"levels\multi\shrine\shrine")
                    {
                        var scnr = CacheContext.Deserialize<Scenario>(stream, tag);
                        scnr.SandboxVehicles = null;
                        scnr.SandboxWeapons = null;
                        scnr.SandboxEquipment = null;
                        scnr.SandboxScenery = null;
                        scnr.SandboxTeleporters = null;
                        scnr.SandboxGoalObjects = null;
                        scnr.SandboxSpawning = null;
                        scnr.PlayerStartingProfile = new List<Scenario.PlayerStartingProfileBlock>
                        {
                            new Scenario.PlayerStartingProfileBlock
                            {
                                Name = "start_assault",
                                PrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
                                PrimaryRoundsLoaded = 32,
                                PrimaryRoundsTotal = 96,
                                SecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum"),
                                SecondaryRoundsLoaded = 8,
                                SecondaryRoundsTotal = 24,
                                StartingFragGrenadeCount = 2,
                                EditorFolder = -1,
                            },
                        };
                        scnr.AcousticsPalette = new List<ScenarioStructureBsp.AcousticsPaletteBlock>
                        {
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"shrine_exterior"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\mountains"),
                                ReverbCutoffDistance = 1f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\shrine\desert_wind2\desert_wind2"),
                                AmbienceCutoffDistance = 3f,
                                AmbienceInterpolationSpeed = 0.5f,
                            },
                            new ScenarioStructureBsp.AcousticsPaletteBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"interior"),
                                SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\jay_cave"),
                                ReverbCutoffDistance = 1f,
                                AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\shrine\desert_wind_inside\desert_wind_inside"),
                                AmbienceCutoffDistance = 3f,
                                AmbienceInterpolationSpeed = 0.5f,
                            },
                        };
                        CacheContext.Serialize(stream, tag, scnr);
                    }
                }
            }
        }

        public void MainMenuDependencies() 
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    if (tag.IsInGroup("bloc") && tag.Name == $@"objects\eldewrito\reforge\block_01x20x20_black_mainmenu") 
                    {
                        var bloc = CacheContext.Deserialize<Crate>(stream, tag);
                        bloc.Model = GetCachedTag<Model>($@"objects\eldewrito\reforge\block_01x20x20_black_mainmenu");
                        CacheContext.Serialize(stream, tag, bloc);
                    }

                    if (tag.IsInGroup("hlmt") && tag.Name == $@"objects\eldewrito\reforge\block_01x20x20_black_mainmenu") 
                    {
                        var hlmt = CacheContext.Deserialize<Model>(stream, tag);
                        hlmt.RenderModel = GetCachedTag<RenderModel>($@"objects\eldewrito\reforge\block_01x20x20_black_mainmenu");
                        CacheContext.Serialize(stream, tag, hlmt);
                    }

                    if (tag.IsInGroup("mode") && tag.Name == $@"objects\eldewrito\reforge\block_01x20x20_black_mainmenu") 
                    {
                        var mode = CacheContext.Deserialize<RenderModel>(stream, tag);
                        mode.Materials = new List<RenderMaterial>
                        {
                            new RenderMaterial
                            {
                                RenderMethod = GetCachedTag<Shader>($@"levels\shared\shaders\simple\black"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, mode);
                    }

                    if (tag.IsInGroup("bipd") && tag.Name == $@"levels\ui\mainmenu\objects\odst_recon_cheap\odst_recon_cheap") 
                    {
                        var bipd = CacheContext.Deserialize<Biped>(stream, tag);
                        bipd.Model = GetCachedTag<Model>($@"levels\ui\mainmenu\objects\odst_recon_cheap\odst_recon_cheap");
                        bipd.DefaultModelVariant = CacheContext.StringTable.GetStringId($@"default");
                        CacheContext.Serialize(stream, tag, bipd);
                    }

                    if (tag.IsInGroup("hlmt") && tag.Name == $@"levels\ui\mainmenu\objects\odst_recon_cheap\odst_recon_cheap") 
                    {
                        var hlmt = CacheContext.Deserialize<Model>(stream, tag);
                        hlmt.RenderModel = GetCachedTag<RenderModel>($@"levels\ui\mainmenu\objects\odst_recon_cheap\odst_recon_cheap");
                        hlmt.CollisionModel = GetCachedTag<CollisionModel>($@"objects\characters\odst\odst");
                        hlmt.Animation = GetCachedTag<ModelAnimationGraph>($@"objects\characters\marine\marine");
                        hlmt.PhysicsModel = GetCachedTag<PhysicsModel>($@"objects\characters\marine\marine");
                        CacheContext.Serialize(stream, tag, hlmt);
                    }

                    if (tag.IsInGroup("mode") && tag.Name == $@"levels\ui\mainmenu\objects\odst_recon_cheap\odst_recon_cheap")
                    {
                        var mode = CacheContext.Deserialize<RenderModel>(stream, tag);
                        mode.Regions = new List<RenderModel.Region>
                        {
                            new RenderModel.Region
                            {
                                Name = CacheContext.StringTable.GetStringId($@"badge"),
                                Permutations = new List<RenderModel.Region.Permutation>
                                {
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"standard"),
                                        MeshCount = 1
                                    },
                                },
                            },
                            new RenderModel.Region
                            {
                                Name = CacheContext.StringTable.GetStringId($@"body"),
                                Permutations = new List<RenderModel.Region.Permutation>
                                {
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"standard"),
                                        MeshIndex = 1,
                                        MeshCount = 1,
                                    },
                                },
                            },
                            new RenderModel.Region
                            {
                                Name = CacheContext.StringTable.GetStringId($@"chest"),
                                Permutations = new List<RenderModel.Region.Permutation>
                                {
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"broken"),
                                        MeshIndex = 16,
                                        MeshCount = 1,
                                    },
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"standard"),
                                        MeshIndex = 16,
                                        MeshCount = 1,
                                    },
                                },
                            },
                            new RenderModel.Region
                            {
                                
                            },
                            new RenderModel.Region
                            {
                                
                            },
                            new RenderModel.Region
                            {
                                Name = CacheContext.StringTable.GetStringId($@"emblem"),
                                Permutations = new List<RenderModel.Region.Permutation>
                                {
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"dutch"),
                                        MeshIndex = 5,
                                        MeshCount = 1,
                                    },
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"on"),
                                        MeshIndex = 25,
                                        MeshCount = 1,
                                    },
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"off"),
                                        MeshIndex = 25,
                                        MeshCount = 1,
                                    },
                                },
                            },
                            new RenderModel.Region
                            {
                                Name = CacheContext.StringTable.GetStringId($@"gear"),
                                Permutations = new List<RenderModel.Region.Permutation>
                                {
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mickey"),
                                        MeshIndex = 6,
                                        MeshCount = 1,
                                    },
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"romeo"),
                                        MeshIndex = 18,
                                        MeshCount = 1,
                                    },
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"dutch"),
                                        MeshIndex = 26,
                                        MeshCount = 1,
                                    },
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"sergeant"),
                                        MeshIndex = 29,
                                        MeshCount = 1,
                                    },
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"standard"),
                                        MeshIndex = 32,
                                        MeshCount = 1,
                                    },
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"johnson"),
                                        MeshIndex = 35,
                                        MeshCount = 1,
                                    },
                                },
                            },
                            new RenderModel.Region
                            {
                                Name = CacheContext.StringTable.GetStringId($@"hands"),
                                Permutations = new List<RenderModel.Region.Permutation>
                                {
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"standard"),
                                        MeshIndex = 7,
                                        MeshCount = 1,
                                    },
                                },
                            },
                            new RenderModel.Region
                            {
                                Name = CacheContext.StringTable.GetStringId($@"head"),
                                Permutations = new List<RenderModel.Region.Permutation>
                                {
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"johnson"),
                                        MeshIndex = 36,
                                        MeshCount = 1,
                                    },
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"sergeant"),
                                        MeshIndex = 36,
                                        MeshCount = 1,
                                    },
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"romeo"),
                                        MeshIndex = 36,
                                        MeshCount = 1,
                                    },
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mickey"),
                                        MeshIndex = 36,
                                        MeshCount = 1,
                                    },
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"dutch"),
                                        MeshIndex = 36,
                                        MeshCount = 1,
                                    },
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"off"),
                                        MeshIndex = 36,
                                        MeshCount = 1,
                                    },
                                },
                            },
                            new RenderModel.Region
                            {
                                Name = CacheContext.StringTable.GetStringId($@"headgear"),
                                Permutations = new List<RenderModel.Region.Permutation>
                                {
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mickey"),
                                        MeshIndex = 9,
                                        MeshCount = 1,
                                    },
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"romeo"),
                                        MeshIndex = 20,
                                        MeshCount = 1,
                                    },
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"dutch"),
                                        MeshIndex = 28,
                                        MeshCount = 1,
                                    },
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"sergeant"),
                                        MeshIndex = 31,
                                        MeshCount = 1,
                                    },
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"off"),
                                        MeshIndex = 34,
                                        MeshCount = 1,
                                    },
                                },
                            },
                            new RenderModel.Region
                            {
                                Name = CacheContext.StringTable.GetStringId($@"helmet"),
                                Permutations = new List<RenderModel.Region.Permutation>
                                {
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"standard"),
                                        MeshIndex = 10,
                                        MeshCount = 1,
                                    },
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"off"),
                                        MeshIndex = 10,
                                        MeshCount = 1,
                                    },
                                },
                            },
                            new RenderModel.Region
                            {
                                Name = CacheContext.StringTable.GetStringId($@"knife"),
                                Permutations = new List<RenderModel.Region.Permutation>
                                {
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"on"),
                                        MeshIndex = 22,
                                        MeshCount = 1,
                                    },
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"off"),
                                        MeshIndex = 22,
                                        MeshCount = 1,
                                    },
                                },
                            },
                            new RenderModel.Region
                            {
                                Name = CacheContext.StringTable.GetStringId($@"l_shoulder"),
                                Permutations = new List<RenderModel.Region.Permutation>
                                {
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"standard"),
                                        MeshIndex = 12,
                                        MeshCount = 1,
                                    },
                                },
                            },
                            new RenderModel.Region
                            {
                                Name = CacheContext.StringTable.GetStringId($@"r_shoulder"),
                                Permutations = new List<RenderModel.Region.Permutation>
                                {
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"standard"),
                                        MeshIndex = 13,
                                        MeshCount = 1,
                                    },
                                    new RenderModel.Region.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"off"),
                                        MeshIndex = 23,
                                        MeshCount = 1,
                                    },
                                },
                            },
                            new RenderModel.Region
                            {
                                
                            },
                            new RenderModel.Region
                            {
                                
                            },
                        };
                        CacheContext.Serialize(stream, tag, mode);
                    }
                }
            }
        }
    }
}