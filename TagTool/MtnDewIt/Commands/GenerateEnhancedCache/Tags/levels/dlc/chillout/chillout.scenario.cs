using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Tags
{
    public class levels_dlc_chillout_chillout_scenario : TagFile
    {
        public levels_dlc_chillout_chillout_scenario(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\dlc\armory\armory");
            var scnr = CacheContext.Deserialize<Scenario>(Stream, tag);

            UpdateForgePalette(scnr);

            scnr.SimulationDefinitionTable = null;
            CacheContext.Serialize(Stream, tag, scnr);
        }
    }
}
