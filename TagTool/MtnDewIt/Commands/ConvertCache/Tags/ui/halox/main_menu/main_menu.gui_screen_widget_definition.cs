using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_halox_main_menu_main_menu_gui_screen_widget_definition : TagFile
    {
        public ui_halox_main_menu_main_menu_gui_screen_widget_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\main_menu\main_menu");
            var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(Stream, tag);
            scn3.Flags = GuiScreenWidgetDefinition.GuiScreenWidgetFlags.DoNotApplyOldContentUpscaling | GuiScreenWidgetDefinition.GuiScreenWidgetFlags.BBackShouldntDisposeScreen;
            scn3.GuiRenderBlock = new GuiDefinition
            {
                Name = CacheContext.StringTable.GetStringId($@"main_menu"),
                Bounds720p = new Rectangle2d(-420, -756, 420, 756),
                Bounds480i = new Rectangle2d(-315, -420, 315, 420)
            };
            scn3.StringList = GetCachedTag<MultilingualUnicodeStringList>($@"ui\halox\main_menu\strings");
            scn3.InitialButtonKeyName = CacheContext.StringTable.GetStringId($@"main_menu_offline");
            scn3.DebugDatasources = new List<GuiScreenWidgetDefinition.DataSource>
            {
                new GuiScreenWidgetDefinition.DataSource
                {
                    DataSourceTag = GetCachedTag<GuiDatasourceDefinition>($@"ui\halox\main_menu\main_menu_list"),
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
                                TemplateReference = GetCachedTag<GuiListWidgetDefinition>($@"ui\halox\main_menu\mainmenu_list"),
                                Definition = new GuiListWidgetDefinition
                                {
                                    Flags = GuiListWidgetDefinition.GuiListWidgetFlags.DoNotApplyOldContentUpscaling | GuiListWidgetDefinition.GuiListWidgetFlags.ListWraps,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"main_menu"),
                                        ScaledPositioning = GuiDefinition.WidgetPositioning.BottomReftCorner,
                                        Bounds720p = new Rectangle2d(525, 111, 0, 0),
                                        Bounds480i = new Rectangle2d(409, 63, 0, 0),
                                    },
                                    DataSourceName = CacheContext.StringTable.GetStringId($@"main_menu"),
                                    Items = new List<GuiListWidgetDefinition.ListWidgetItem>
                                    {
                                        new GuiListWidgetDefinition.ListWidgetItem
                                        {
                                            Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                            GuiRenderBlock = new GuiDefinition
                                            {
                                                Bounds720p = new Rectangle2d(-42, 0, 0, 0),
                                            },
                                        },
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
                                                Bounds720p = new Rectangle2d(32, 0, 0, 0),
                                            },
                                        },
                                        new GuiListWidgetDefinition.ListWidgetItem
                                        {
                                            Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                            GuiRenderBlock = new GuiDefinition
                                            {
                                                Bounds720p = new Rectangle2d(65, 0, 0, 0),
                                            },
                                        },
                                        new GuiListWidgetDefinition.ListWidgetItem
                                        {
                                            Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                            GuiRenderBlock = new GuiDefinition
                                            {
                                                Bounds720p = new Rectangle2d(98, 0, 0, 0),
                                            },
                                        },
                                        new GuiListWidgetDefinition.ListWidgetItem
                                        {
                                            Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                            GuiRenderBlock = new GuiDefinition
                                            {
                                                Bounds720p = new Rectangle2d(131, 0, 0, 0),
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
                                    Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify |GuiTextWidgetDefinition.GuiTextFlags.LargeTextBuffer255Chars,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"start_new_campaign"),
                                        Bounds720p = new Rectangle2d(595, 761, 682, 1359),
                                        Bounds480i = new Rectangle2d(467, 320, 538, 774),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\500_fade"),
                                    },
                                    ValueOverrideList = CacheContext.StringTable.GetStringId($@"sidebar_items"),
                                    TextColorPreset = CacheContext.StringTable.GetStringId($@"dim"),
                                    CustomFont = WidgetFontValue.SuperLargeFont,
                                },
                            },
                            new TextWidget
                            {
                                Definition = new GuiTextWidgetDefinition
                                {
                                    Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.RightJustify,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"version_number"),
                                        RenderDepthBias = -11,
                                        Bounds720p = new Rectangle2d(699, 102, 738, 489),
                                        Bounds480i = new Rectangle2d(534, 52, 573, 270),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_slide_up"),
                                    },
                                    ValueIdentifier = CacheContext.StringTable.GetStringId($@"eldewrito_version"),
                                    TextColorPreset = CacheContext.StringTable.GetStringId($@"dim"),
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
                                        Name = CacheContext.StringTable.GetStringId($@"channel"),
                                        RenderDepthBias = -10,
                                        Bounds720p = new Rectangle2d(477, 102, 780, 505),
                                        Bounds480i = new Rectangle2d(374, 52, 590, 283),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_slide_up"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\main_menu\mainmenu_bkd"),
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
                                        Name = CacheContext.StringTable.GetStringId($@"channel"),
                                        RenderDepthBias = -10,
                                        Bounds720p = new Rectangle2d(780, 102, 840, 505),
                                        Bounds480i = new Rectangle2d(590, 52, 630, 283),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_slide_up"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\main_menu\bottom_gradient_ui"),
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
                                        Name = CacheContext.StringTable.GetStringId($@"channel_blur"),
                                        RenderDepthBias = -12,
                                        Bounds720p = new Rectangle2d(477, 102, 840, 505),
                                        Bounds480i = new Rectangle2d(374, 52, 630, 283),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_slide_up"),
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
                                        Name = CacheContext.StringTable.GetStringId($@"full_black_fade_in"),
                                        RenderDepthBias = 150,
                                        Bounds720p = new Rectangle2d(-26, -1, 893, 1526),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\black_fade"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\black_fade_ui"),
                                    BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
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
                            ScaledPositioning = GuiDefinition.WidgetPositioning.RightEdge,
                            Bounds720p = new Rectangle2d(0, -26, 0, 0),
                        },
                        BitmapWidgets = new List<BitmapWidget>
                        {
                            new BitmapWidget
                            {
                                Definition = new GuiBitmapWidgetDefinition
                                {
                                    Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"title"),
                                        Bounds720p = new Rectangle2d(518, 780, 0, 0),
                                        Bounds480i = new Rectangle2d(408, 337, 0, 0),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\500_fade"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\main_menu\halo3_logo_ui"),
                                    BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                    InitialSpriteFrame = -1,
                                },
                            },
                            new BitmapWidget
                            {
                                Definition = new GuiBitmapWidgetDefinition
                                {
                                    Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"bungie"),
                                        Bounds720p = new Rectangle2d(919, 1269, 0, 0),
                                        Bounds480i = new Rectangle2d(551, 669, 0, 0),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\500_fade"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\main_menu\bungielogo"),
                                    BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
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
                    Definition = GetCachedTag<GuiButtonKeyDefinition>($@"ui\halox\main_menu\main_menu_offline"),
                },
                new GuiScreenWidgetDefinition.ButtonKeyLegend
                {
                    Definition = GetCachedTag<GuiButtonKeyDefinition>($@"ui\halox\main_menu\main_menu_online"),
                },
            };
            scn3.OnLoadScriptName = "mainmenu_cam";
            scn3.ScriptIndex = 8;
            CacheContext.Serialize(Stream, tag, scn3);
        }
    }
}
