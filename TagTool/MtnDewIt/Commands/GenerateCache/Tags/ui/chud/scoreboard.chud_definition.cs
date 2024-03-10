using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class ui_chud_scoreboard_chud_definition : TagFile
    {
        public ui_chud_scoreboard_chud_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<ChudDefinition>($@"ui\chud\scoreboard");
            var chdt = CacheContext.Deserialize<ChudDefinition>(Stream, tag);
            chdt.HudWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, -72f);
            chdt.HudWidgets[5].BitmapWidgets[8].StateData[0].GameState |= ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.Editor;
            chdt.HudWidgets[5].BitmapWidgets[8].PlacementData[0].Offset = new RealPoint2d(-221.5f, -3f);
            CacheContext.Serialize(Stream, tag, chdt);
        }
    }
}
