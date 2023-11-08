using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_characters_masterchief_fx_flaming_ninja_effect : TagFile
    {
        public objects_characters_masterchief_fx_flaming_ninja_effect(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Effect>($@"objects\characters\masterchief\fx\flaming_ninja");
            var effe = CacheContext.Deserialize<Effect>(Stream, tag);
            effe.Events[0].ParticleSystems[0].NearCutoff = 0.34f;
            CacheContext.Serialize(Stream, tag, effe);
        }
    }
}
