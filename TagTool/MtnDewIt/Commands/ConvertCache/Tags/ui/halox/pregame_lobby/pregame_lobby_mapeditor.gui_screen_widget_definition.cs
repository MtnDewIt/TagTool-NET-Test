using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_halox_pregame_lobby_pregame_lobby_mapeditor_gui_screen_widget_definition : TagFile
    {
        public ui_halox_pregame_lobby_pregame_lobby_mapeditor_gui_screen_widget_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_mapeditor");
            var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(Stream, tag);
            scn3.Flags = GuiScreenWidgetDefinition.GuiScreenWidgetFlags.DoNotApplyOldContentUpscaling;
            scn3.GuiRenderBlock = new GuiDefinition
            {
                Name = CacheContext.StringTable.GetStringId($@"pregame_lobby_mapeditor"),
            };
            scn3.ScreenTemplate = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_template");
            scn3.DebugDatasources = new List<GuiScreenWidgetDefinition.DataSource>
            {
                new GuiScreenWidgetDefinition.DataSource
                {
                    DataSourceTag = GetCachedTag<GuiDatasourceDefinition>($@"ui\halox\pregame_lobby\lobby_list_mapeditor"),
                },
                new GuiScreenWidgetDefinition.DataSource
                {
                    DataSourceTag = GetCachedTag<GuiDatasourceDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_constants"),
                },
            };
            scn3.GroupWidgets = new List<GuiScreenWidgetDefinition.GroupWidget>
            {
                new GuiScreenWidgetDefinition.GroupWidget
                {
                    TemplateReference = GetCachedTag<GuiGroupWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_template"),
                    Definition = new GuiGroupWidgetDefinition
                    {
                        Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                        GuiRenderBlock = new GuiDefinition
                        {
                            Name = CacheContext.StringTable.GetStringId($@"template"),
                        },
                        ListWidgets = new List<ListWidget>
                        {
                            new ListWidget
                            {
                                TemplateReference = GetCachedTag<GuiListWidgetDefinition>($@"ui\halox\pregame_lobby\lobby_ui_list"),
                                Definition = new GuiListWidgetDefinition
                                {
                                    Flags = GuiListWidgetDefinition.GuiListWidgetFlags.DoNotApplyOldContentUpscaling | GuiListWidgetDefinition.GuiListWidgetFlags.ListWraps,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"lobby_list"),
                                        Bounds720p = new Rectangle2d(111, 112, 0, 0),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                    },
                                    DataSourceName = CacheContext.StringTable.GetStringId($@"lobby_list"),
                                    Items = new List<GuiListWidgetDefinition.ListWidgetItem>
                                    {
                                        new GuiListWidgetDefinition.ListWidgetItem
                                        {
                                            Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                            GuiRenderBlock = new GuiDefinition
                                            {
                                                Bounds720p = new Rectangle2d(0, 0, 0, 0),
                                            },
                                        },
                                        new GuiListWidgetDefinition.ListWidgetItem
                                        {
                                            Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                            GuiRenderBlock = new GuiDefinition
                                            {
                                                Bounds720p = new Rectangle2d(34, 0, 0, 0),
                                            },
                                        },
                                        new GuiListWidgetDefinition.ListWidgetItem
                                        {
                                            Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                            GuiRenderBlock = new GuiDefinition
                                            {
                                                Bounds720p = new Rectangle2d(68, 0, 0, 0),
                                            },
                                        },
                                        new GuiListWidgetDefinition.ListWidgetItem
                                        {
                                            Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                            GuiRenderBlock = new GuiDefinition
                                            {
                                                Bounds720p = new Rectangle2d(102, 0, 0, 0),
                                            },
                                        },
                                        new GuiListWidgetDefinition.ListWidgetItem
                                        {
                                            Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                            GuiRenderBlock = new GuiDefinition
                                            {
                                                Bounds720p = new Rectangle2d(144, 0, 0, 0),
                                            },
                                        },
                                        new GuiListWidgetDefinition.ListWidgetItem
                                        {
                                            Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                            GuiRenderBlock = new GuiDefinition
                                            {
                                                Bounds720p = new Rectangle2d(186, 0, 0, 0),
                                            },
                                        },
                                    },
                                },
                            },
                        },
                    },
                },
                new GuiScreenWidgetDefinition.GroupWidget
                {
                    TemplateReference = GetCachedTag<GuiGroupWidgetDefinition>($@"ui\halox\common\roster\roster"),
                    Definition = new GuiGroupWidgetDefinition
                    {
                        Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                        GuiRenderBlock = new GuiDefinition
                        {
                            Name = CacheContext.StringTable.GetStringId($@"roster"),
                            ScaledPositioning = GuiDefinition.WidgetPositioning.RightEdge,
                            Bounds720p = new Rectangle2d(84, 1106, 0, 0),
                            Bounds480i = new Rectangle2d(59, 580, 0, 0),
                        },

                    },
                },
                new GuiScreenWidgetDefinition.GroupWidget
                {
                    Definition = new GuiGroupWidgetDefinition
                    {
                        TextWidgets = new List<TextWidget>
                        {
                            new TextWidget
                            {
                                Definition = new GuiTextWidgetDefinition
                                {
                                    Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mapeditor_map_name"),
                                        Bounds720p = new Rectangle2d(656, 116, 715, 704),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\lobby_slide"),
                                    },
                                    ValueIdentifier = CacheContext.StringTable.GetStringId($@"mapeditor_map_name"),
                                    TextColorPreset = CacheContext.StringTable.GetStringId($@"ice"),
                                    CustomFont = WidgetFontValue.BodyText,
                                },
                            },
                            new TextWidget
                            {
                                Definition = new GuiTextWidgetDefinition
                                {
                                    Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.LargeTextBuffer255Chars | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"lobby_status"),
                                        Bounds720p = new Rectangle2d(334, 116, 494, 704),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\lobby_slide_with_alt_flash"),
                                    },
                                    TextColorPreset = CacheContext.StringTable.GetStringId($@"ice"),
                                    CustomFont = WidgetFontValue.BodyText,
                                },
                            },
                        },
                        BitmapWidgets = new List<BitmapWidget>
                        {
                            new BitmapWidget
                            {
                                Definition = new GuiBitmapWidgetDefinition
                                {
                                    Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"map_image"),
                                        RenderDepthBias = -30,
                                        Bounds720p = new Rectangle2d(454, 103, 653, 711),
                                        Bounds480i = new Rectangle2d(333, 72, 531, 679),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\lobby_slide"),
                                    },
                                    BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                },
                            },
                            new BitmapWidget
                            {
                                Definition = new GuiBitmapWidgetDefinition
                                {
                                    Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"gametype_image"),
                                        Bounds720p = new Rectangle2d(467, 118, 637, 288),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\lobby_slide"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\pregame_lobby\gametypes_large_ui"),
                                    BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                    InitialSpriteFrame = 5,
                                },
                            },
                        },
                    },
                },
                new GuiScreenWidgetDefinition.GroupWidget
                {
                    TemplateReference = GetCachedTag<GuiGroupWidgetDefinition>($@"ui\halox\pregame_lobby\map_load"),
                    Definition = new GuiGroupWidgetDefinition
                    {
                        Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                        GuiRenderBlock = new GuiDefinition
                        {
                            Name = CacheContext.StringTable.GetStringId($@"precaching"),
                        },
                    },
                },
            };
            scn3.OnLoadScriptName = "editor_cam";
            scn3.ScriptIndex = 12;
            CacheContext.Serialize(Stream, tag, scn3);
        }
    }
}
