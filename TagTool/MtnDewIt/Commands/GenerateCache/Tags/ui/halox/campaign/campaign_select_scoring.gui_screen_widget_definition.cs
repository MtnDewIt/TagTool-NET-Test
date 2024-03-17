using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class ui_halox_campaign_campaign_select_scoring_gui_screen_widget_definition : TagFile
    {
        public ui_halox_campaign_campaign_select_scoring_gui_screen_widget_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\campaign\campaign_select_scoring");
            var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(Stream, tag);
            scn3.Flags = GuiScreenWidgetDefinition.GuiScreenWidgetFlags.DoNotApplyOldContentUpscaling;
            scn3.GuiRenderBlock = new GuiDefinition
            {
                Name = CacheContext.StringTable.GetOrAddString($@"campaign_select_scoring"),
                Bounds720p = new Rectangle2d(-307, -756, 307, 756),
            };
            scn3.StringList = GetCachedTag<MultilingualUnicodeStringList>($@"ui\halox\campaign\campaign_settings\strings_campaign_settings");
            scn3.InitialButtonKeyName = CacheContext.StringTable.GetOrAddString($@"a_select_b_back");
            scn3.DebugDatasources = new List<GuiScreenWidgetDefinition.DataSource>
            {
                new GuiScreenWidgetDefinition.DataSource
                {
                    DataSourceTag = GetCachedTag<GuiDatasourceDefinition>($@"ui\halox\campaign\campaign_settings_spinner"),
                },
            };
            scn3.GroupWidgets = new List<GuiScreenWidgetDefinition.GroupWidget>
            {
                new GuiScreenWidgetDefinition.GroupWidget
                {
                    Definition = new GuiGroupWidgetDefinition
                    {
                        Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                        ListWidgets = new List<ListWidget>
                        {
                            new ListWidget
                            {
                                Definition = new GuiListWidgetDefinition
                                {
                                    Flags = GuiListWidgetDefinition.GuiListWidgetFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetOrAddString($@"scoring_option"),
                                        Bounds720p = new Rectangle2d(128, 252, 196, 656),
                                    },
                                    DataSourceName = CacheContext.StringTable.GetOrAddString($@"spinner"),
                                    Skin = GetCachedTag<GuiSkinDefinition>($@"ui\halox\campaign\campaign_scoring"),
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
                                    },
                                },
                            },
                        },
                        TextWidgets = new List<TextWidget>
                        {
                            new TextWidget
                            {
                                Definition = new GuiTextWidgetDefinition
                                {
                                    Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.Uppercase | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetOrAddString($@"title"),
                                        Bounds720p = new Rectangle2d(1, 242, 53, 1275),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                    },
                                    ValueIdentifier = CacheContext.StringTable.GetOrAddString($@"title"),
                                    TextColorPreset = CacheContext.StringTable.GetOrAddString($@"hilite"),
                                    CustomFont = WidgetFontValue.Title,
                                },
                            },
                            new TextWidget
                            {
                                Definition = new GuiTextWidgetDefinition
                                {
                                    Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow | GuiTextWidgetDefinition.GuiTextFlags.LargeTextBuffer255Chars,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Bounds720p = new Rectangle2d(72, 245, 111, 1417),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                    },
                                    ValueIdentifier = CacheContext.StringTable.GetOrAddString($@"metagame_scoring_help"),
                                    TextColorPreset = CacheContext.StringTable.GetOrAddString($@"ice"),
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
                                        Name = CacheContext.StringTable.GetOrAddString($@"background"),
                                        RenderDepthBias = -10,
                                        Bounds720p = new Rectangle2d(0, 0, 614, 1512),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\selection_bkd"),
                                    BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                },
                            },
                            new BitmapWidget
                            {
                                Definition = new GuiBitmapWidgetDefinition
                                {
                                    Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.RenderAsScreenBlur,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetOrAddString($@"background_blur"),
                                        RenderDepthBias = -21,
                                        Bounds720p = new Rectangle2d(-118, 0, 840, 1512),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\black_25"),
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
                                        Name = CacheContext.StringTable.GetOrAddString($@"dark_background"),
                                        RenderDepthBias = -20,
                                        Bounds720p = new Rectangle2d(-131, 0, 840, 1512),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\black_25"),
                                    BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                },
                            },
                            new BitmapWidget
                            {
                                Definition = new GuiBitmapWidgetDefinition
                                {
                                    Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetOrAddString($@"skull_overline"),
                                        RenderDepthBias = 5,
                                        Bounds720p = new Rectangle2d(118, 242, 120, 1261),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\pregame_lobby\line_ui"),
                                    BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                },
                            },
                            new BitmapWidget
                            {
                                Definition = new GuiBitmapWidgetDefinition
                                {
                                    Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetOrAddString($@"column_gradient"),
                                        RenderDepthBias = -9,
                                        Bounds720p = new Rectangle2d(120, 242, 603, 918),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\third_column"),
                                    BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                },
                            },
                            new BitmapWidget
                            {
                                Definition = new GuiBitmapWidgetDefinition
                                {
                                    Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetOrAddString($@"player_black"),
                                        RenderDepthBias = -8,
                                        Bounds720p = new Rectangle2d(120, 918, 563, 1261),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\black_75"),
                                    BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                },
                            },
                            new BitmapWidget
                            {
                                Definition = new GuiBitmapWidgetDefinition
                                {
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetOrAddString($@"no_skull"),
                                        RenderDepthBias = 1,
                                        Bounds720p = new Rectangle2d(131, 997, 0, 0),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\campaign\skulls_lg_ui"),
                                    BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                    InitialSpriteFrame = 10,
                                },
                            },
                        },
                    },
                },
                new GuiScreenWidgetDefinition.GroupWidget
                {
                    Definition = new GuiGroupWidgetDefinition
                    {
                        Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                        GuiRenderBlock = new GuiDefinition
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"selected_otem"),
                        },
                        TextWidgets = new List<TextWidget>
                        {
                            new TextWidget
                            {
                                Definition = new GuiTextWidgetDefinition
                                {
                                    Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.StringFromExportedStringId | GuiTextWidgetDefinition.GuiTextFlags.LargeTextBuffer255Chars,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetOrAddString($@"scoring_description"),
                                        Bounds720p = new Rectangle2d(426, 929, 577, 1250),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                    },
                                    ValueOverrideList = CacheContext.StringTable.GetOrAddString($@"scoring_option"),
                                    ValueIdentifier = CacheContext.StringTable.GetOrAddString($@"description"),
                                    TextColorPreset = CacheContext.StringTable.GetOrAddString($@"ice"),
                                    CustomFont = WidgetFontValue.BodyText,
                                },
                            },
                            new TextWidget
                            {
                                Definition = new GuiTextWidgetDefinition
                                {
                                    Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.Uppercase,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetOrAddString($@"scoring_name"),
                                        Bounds720p = new Rectangle2d(393, 929, 433, 1250),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                    },
                                    ValueIdentifier = CacheContext.StringTable.GetOrAddString($@"option_display_campaign_scoring"),
                                    CustomFont = WidgetFontValue.BodyText,
                                },
                            },
                        },
                    },
                },
            };
            scn3.ButtonKeys = new List<GuiScreenWidgetDefinition.ButtonKeyLegend>
            {
                new GuiScreenWidgetDefinition.ButtonKeyLegend
                {
                    Definition = GetCachedTag<GuiButtonKeyDefinition>($@"ui\halox\campaign\button_key_a_select_b_back"),
                },
            };
            scn3.ScriptIndex = -1;
            CacheContext.Serialize(Stream, tag, scn3);
        }
    }
}
