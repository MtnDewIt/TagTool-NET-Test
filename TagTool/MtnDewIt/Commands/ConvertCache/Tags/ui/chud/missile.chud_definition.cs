using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_chud_missile_chud_definition : TagFile
    {
        public ui_chud_missile_chud_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<ChudDefinition>($@"ui\chud\missile");
            var chdt = CacheContext.Deserialize<ChudDefinition>(Stream, tag);
            chdt.HudWidgets[1].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
            chdt.HudWidgets[1].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
            chdt.HudWidgets[1].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
            chdt.HudWidgets[1].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
            chdt.HudWidgets[1].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
            //chdt.HudWidgets[3].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.605f, 0.605f);
            //chdt.HudWidgets[3].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.605f, 0.605f);
            //chdt.HudWidgets[3].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.605f, 0.605f);
            //chdt.HudWidgets[3].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.7139f, 0.7139f);
            //chdt.HudWidgets[3].BitmapWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.7139f, 0.7139f);
            //chdt.HudWidgets[3].BitmapWidgets[5].PlacementData[0].Scale = new RealPoint2d(0.7139f, 0.7139f);
            CacheContext.Serialize(Stream, tag, chdt);
        }
    }
}
