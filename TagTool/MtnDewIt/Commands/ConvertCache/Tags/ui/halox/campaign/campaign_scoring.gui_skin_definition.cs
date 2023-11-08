using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_halox_campaign_campaign_scoring_gui_skin_definition : TagFile
    {
        public ui_halox_campaign_campaign_scoring_gui_skin_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<GuiSkinDefinition>($@"ui\halox\campaign\campaign_scoring");
            var skn3 = CacheContext.Deserialize<GuiSkinDefinition>(Stream, tag);
            skn3.TextWidgets = new List<TextWidget>
            {
                new TextWidget
                {
                    Definition = new GuiTextWidgetDefinition
                    {
                        Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.Uppercase | GuiTextWidgetDefinition.GuiTextFlags.StringFromExportedStringId | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow | GuiTextWidgetDefinition.GuiTextFlags.AllowListItemToOverrideAnimationSkin,
                        GuiRenderBlock = new GuiDefinition
                        {
                            RenderDepthBias = 1,
                            Bounds720p = new Rectangle2d(2, 5, 45, 599),
                            AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                        },
                        ValueIdentifier = CacheContext.StringTable.GetStringId($@"name"),
                        CustomFont = WidgetFontValue.BodyText,
                    },
                },
            };
            skn3.BitmapWidgets = new List<BitmapWidget> 
            {
                new BitmapWidget
                {
                    Definition = new GuiBitmapWidgetDefinition
                    {
                        Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                        GuiRenderBlock = new GuiDefinition
                        {
                            Bounds720p = new Rectangle2d(0, -9, 32, 598),
                            AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\pregame_lobby\switch_lobby\immediate_dismiss_list_bitmaps"),
                        },
                        Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\standard_list\black_bar"),
                        BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                    },
                },
            };
            CacheContext.Serialize(Stream, tag, skn3);
        }
    }
}
