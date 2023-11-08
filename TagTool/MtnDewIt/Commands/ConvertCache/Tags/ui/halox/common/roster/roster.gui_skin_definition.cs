using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_halox_common_roster_roster_gui_skin_definition : TagFile
    {
        public ui_halox_common_roster_roster_gui_skin_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<GuiSkinDefinition>($@"ui\halox\common\roster\roster");
            var skn3 = CacheContext.Deserialize<GuiSkinDefinition>(Stream, tag);
            skn3.TextWidgets = new List<TextWidget>()
            {
                new TextWidget()
                {
                    Definition = new GuiTextWidgetDefinition()
                    {
                        Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify,
                        GuiRenderBlock = new GuiDefinition()
                        {
                            Name = CacheContext.StringTable.GetStringId("name"),
                            RenderDepthBias = 89,
                            Bounds720p = new Rectangle2d(5, 0, 43, 265),
                            AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\mp_list_name"),
                        },
                        CustomFont = WidgetFontValue.BodyText,
                    },
                },
                new TextWidget()
                {
                    Definition = new GuiTextWidgetDefinition()
                    {
                        Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.StringFromExportedText,
                        GuiRenderBlock = new GuiDefinition()
                        {
                            Name = CacheContext.StringTable.GetStringId("name_hilite"),
                            RenderDepthBias = 100,
                            Bounds720p = new Rectangle2d(-9, 9, 32, 274),
                            AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\mp_name_hilite"),
                        },
                        ValueOverrideList = CacheContext.StringTable.GetStringId("player_name"),
                        ValueIdentifier = CacheContext.StringTable.GetStringId("player_name"),
                        CustomFont = WidgetFontValue.BodyText,
                    },
                },
                new TextWidget()
                {
                    Definition = new GuiTextWidgetDefinition()
                    {
                        GuiRenderBlock = new GuiDefinition()
                        {
                            Name = CacheContext.StringTable.GetStringId("player_found"),
                        },
                    },
                },
                new TextWidget()
                {
                    Definition = new GuiTextWidgetDefinition()
                    {
                        Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.Uppercase | GuiTextWidgetDefinition.GuiTextFlags.StringFromExportedText,
                        GuiRenderBlock = new GuiDefinition()
                        {
                            Name = CacheContext.StringTable.GetStringId("service_tag"),
                            RenderDepthBias = 100,
                            Bounds720p = new Rectangle2d(19, 9, 60, 274),
                            AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\rank_hilite"),
                        },
                        ValueIdentifier = CacheContext.StringTable.GetStringId("service_tag"),
                        CustomFont = WidgetFontValue.BodyText,
                    },
                },
            };
            skn3.BitmapWidgets = new List<BitmapWidget>()
            {
                new BitmapWidget()
                {
                    Definition = new GuiBitmapWidgetDefinition()
                    {
                        Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling,
                        GuiRenderBlock = new GuiDefinition()
                        {
                            Name = CacheContext.StringTable.GetStringId("base_color"),
                            RenderDepthBias = 83,
                            Bounds720p = new Rectangle2d(0, -47, 0, 0),
                            AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\mp_list_bitmap"),
                        },
                        Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\roster\roster_unfocused_ui"),
                        BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                    },
                },
                new BitmapWidget()
                {
                    Definition = new GuiBitmapWidgetDefinition()
                    {
                        Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling,
                        GuiRenderBlock = new GuiDefinition()
                        {
                            Name = CacheContext.StringTable.GetStringId("base_color_hilite"),
                            RenderDepthBias = 93,
                            Bounds720p = new Rectangle2d(-15, -47, 0, 0),
                            AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\mp_hilite"),
                        },
                        Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\roster\roster_focused_ui"),
                        BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                    },
                },
                new BitmapWidget()
                {
                    Definition = new GuiBitmapWidgetDefinition()
                    {
                        Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                        GuiRenderBlock = new GuiDefinition()
                        {
                            Name = CacheContext.StringTable.GetStringId("player_emblem"),
                            RenderDepthBias = 87,
                            Bounds720p = new Rectangle2d(2, -42, 36, -7),
                            AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\mp_list_emblem"),
                        },
                        Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\emblems"),
                        BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                    },
                },
                new BitmapWidget()
                {
                    Definition = new GuiBitmapWidgetDefinition()
                    {
                        Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                        GuiRenderBlock = new GuiDefinition()
                        {
                            Name = CacheContext.StringTable.GetStringId("player_emblem_hilite"),
                            RenderDepthBias = 97,
                            Bounds720p = new Rectangle2d(-5, -43, 43, 5),
                            AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\emblem_hilite"),
                        },
                        Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\emblems"),
                        BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                    },
                },
                new BitmapWidget()
                {
                    Definition = new GuiBitmapWidgetDefinition()
                    {
                        GuiRenderBlock = new GuiDefinition()
                        {
                            Name = CacheContext.StringTable.GetStringId("skill_level"),
                        },
                    },
                },
                new BitmapWidget()
                {
                    Definition = new GuiBitmapWidgetDefinition()
                    {
                        GuiRenderBlock = new GuiDefinition()
                        {
                            Name = CacheContext.StringTable.GetStringId("skill_level_hilite"),
                        },
                    },
                },
                new BitmapWidget()
                {
                    Definition = new GuiBitmapWidgetDefinition()
                    {
                        Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                        GuiRenderBlock = new GuiDefinition()
                        {
                            Name = CacheContext.StringTable.GetStringId("experience"),
                            RenderDepthBias = 88,
                            Bounds720p = new Rectangle2d(3, 296, 35, 318),
                            AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\rating_list_bitmap"),
                        },
                        Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\roster\exp_med_ui"),
                        BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                    },
                },
                new BitmapWidget()
                {
                    Definition = new GuiBitmapWidgetDefinition()
                    {
                        Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                        GuiRenderBlock = new GuiDefinition()
                        {
                            Name = CacheContext.StringTable.GetStringId("experience_hilite"),
                            RenderDepthBias = 98,
                            Bounds720p = new Rectangle2d(0, 295, 39, 322),
                            AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\rating_hilite"),
                        },
                        Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\roster\exp_med_ui"),
                        BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                    },
                },
                new BitmapWidget()
                {
                    Definition = new GuiBitmapWidgetDefinition()
                    {
                        Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling,
                        GuiRenderBlock = new GuiDefinition()
                        {
                            Name = CacheContext.StringTable.GetStringId("ring_of_light"),
                            RenderDepthBias = 85,
                            Bounds720p = new Rectangle2d(3, -82, 0, 0),
                            AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\roster_fade"),
                        },
                        Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\roster\ringspeak_ui"),
                        BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                    },
                },
                new BitmapWidget()
                {
                    Definition = new GuiBitmapWidgetDefinition()
                    {
                        GuiRenderBlock = new GuiDefinition()
                        {
                            Name = CacheContext.StringTable.GetStringId("player_found"),
                        },
                    },
                },
                new BitmapWidget()
                {
                    Definition = new GuiBitmapWidgetDefinition()
                    {
                        Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling,
                        GuiRenderBlock = new GuiDefinition()
                        {
                            Name = CacheContext.StringTable.GetStringId("rank_tray"),
                            RenderDepthBias = 85,
                            Bounds720p = new Rectangle2d(0, 253, 0, 0),
                            AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\mp_list_bitmap"),
                        },
                        Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\roster\rank_tray_ui"),
                        BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                    },
                },
                new BitmapWidget()
                {
                    Definition = new GuiBitmapWidgetDefinition()
                    {
                        GuiRenderBlock = new GuiDefinition()
                        {
                            Name = CacheContext.StringTable.GetStringId("rank_tray_hilite"),
                            RenderDepthBias = 95,
                            Bounds720p = new Rectangle2d(-10, 253, 0, 0),
                            AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\mp_hilite"),
                        },
                        Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\roster\rank_tray_ui"),
                        BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                        InitialSpriteFrame = 1,
                    },
                },
            };
            CacheContext.Serialize(Stream, tag, skn3);
        }
    }
}
