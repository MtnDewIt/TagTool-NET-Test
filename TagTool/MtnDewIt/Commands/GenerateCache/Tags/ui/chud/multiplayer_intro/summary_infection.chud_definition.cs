using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class ui_chud_multiplayer_intro_summary_infection_chud_definition : TagFile
    {
        public ui_chud_multiplayer_intro_summary_infection_chud_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<ChudDefinition>($@"ui\chud\multiplayer_intro\summary_infection");
            var chdt = CacheContext.Deserialize<ChudDefinition>(Stream, tag);
            chdt.HudWidgets[1].TextWidgets[0].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.None;
            CacheContext.Serialize(Stream, tag, chdt);
        }
    }
}
