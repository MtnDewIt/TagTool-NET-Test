using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Commands;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags
{
    public class levels_ui_mainmenu_mainmenu_halo_online_scenario : TagFile
    {
        public levels_ui_mainmenu_mainmenu_halo_online_scenario(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\ui\mainmenu\mainmenu");
            var scnr = CacheContext.Deserialize<Scenario>(Stream, tag);
            CacheContext.Serialize(Stream, tag, scnr);

            //CompileScript(tag, $@"{Program.TagToolDirectory}\Tools\JSON\data\{tag.Name}\scripts\mainmenu_halo_online.hsc");
        }
    }
}
