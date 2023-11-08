using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_halox_pregame_lobby_selection_survival_select_difficulty_gui_screen_widget_definition : TagFile
    {
        public ui_halox_pregame_lobby_selection_survival_select_difficulty_gui_screen_widget_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\selection\survival_select_difficulty");
            var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(Stream, tag);
            scn3.Flags = GuiScreenWidgetDefinition.GuiScreenWidgetFlags.DoNotApplyOldContentUpscaling;
            scn3.GuiRenderBlock = new GuiDefinition
            {
                Name = CacheContext.StringTable.GetStringId($@"survival_select_difficulty"),
                Bounds720p = new Rectangle2d(-307, -756, 307, 756),
            };
            scn3.StringList = GetCachedTag<MultilingualUnicodeStringList>($@"ui\halox\campaign\strings_difficulty");
            scn3.InitialButtonKeyName = CacheContext.StringTable.GetStringId($@"a_select_b_back");
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
                                        Name = CacheContext.StringTable.GetStringId($@"difficulty"),
                                        Bounds720p = new Rectangle2d(70, 245, 0, 0),
                                    },
                                    DataSourceName = CacheContext.StringTable.GetStringId($@"difficulty"),
                                    Skin = GetCachedTag<GuiSkinDefinition>($@"ui\halox\campaign\campaign_select_difficulty"),
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
                                    Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"title"),
                                        Bounds720p = new Rectangle2d(1, 242, 53, 1275),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                    },
                                    ValueIdentifier = CacheContext.StringTable.GetStringId($@"title"),
                                    TextColorPreset = CacheContext.StringTable.GetStringId($@"hilite"),
                                    CustomFont = WidgetFontValue.Title,
                                },
                            },
                            new TextWidget
                            {
                                Definition = new GuiTextWidgetDefinition
                                {
                                    Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.LargeTextBuffer255Chars | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"description"),
                                        Bounds720p = new Rectangle2d(343, 652, 561, 1266),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                    },
                                    ValueIdentifier = CacheContext.StringTable.GetStringId($@"description"),
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
                                        Name = CacheContext.StringTable.GetStringId($@"background"),
                                        RenderDepthBias = -9,
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
                                    Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"difficulty_image"),
                                        RenderDepthBias = 5,
                                        Bounds720p = new Rectangle2d(70, 652, 0, 0),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\campaign\difficulty_ui"),
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
                                        Name = CacheContext.StringTable.GetStringId($@"background_blur"),
                                        RenderDepthBias = -11,
                                        Bounds720p = new Rectangle2d(-157, 0, 840, 1512),
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
                                        Name = CacheContext.StringTable.GetStringId($@"background_darkening"),
                                        RenderDepthBias = -10,
                                        Bounds720p = new Rectangle2d(-157, 0, 840, 1512),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\black_25"),
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
                    Definition = GetCachedTag<GuiButtonKeyDefinition>($@"ui\halox\campaign\button_key_a_select_b_back"),
                },
            };
            scn3.ScriptIndex = -1;
            CacheContext.Serialize(Stream, tag, scn3);
        }
    }
}
