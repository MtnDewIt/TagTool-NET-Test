using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Tags 
{
    public class ui_halox_common_roster_animations_player_scale_up_gui_widget_scale_animation_definition : TagFile
    {
        public ui_halox_common_roster_animations_player_scale_up_gui_widget_scale_animation_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<GuiWidgetScaleAnimationDefinition>($@"ui\halox\common\roster\animations\player_scale_up");
            var wscl = CacheContext.Deserialize<GuiWidgetScaleAnimationDefinition>(Stream, tag);
            wscl.Keyframes = new List<GuiWidgetScaleAnimationDefinition.WidgetScaleAnimationKeyframeBlock>()
            {
                new GuiWidgetScaleAnimationDefinition.WidgetScaleAnimationKeyframeBlock()
                {
                    TimeOffset = 0,
                    LocalOrigin = new RealPoint2d(0,26),
                    ScaleFactor = new RealVector2d(1f,0.67f),
                },
                new GuiWidgetScaleAnimationDefinition.WidgetScaleAnimationKeyframeBlock()
                {
                    TimeOffset = 64,
                    LocalOrigin = new RealPoint2d(0,26),
                    ScaleFactor = new RealVector2d(1f,1f),
                },
            };
            CacheContext.Serialize(Stream, tag, wscl);
        }
    }
}
