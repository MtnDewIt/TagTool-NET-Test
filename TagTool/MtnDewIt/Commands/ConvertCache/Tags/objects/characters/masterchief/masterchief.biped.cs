using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_characters_masterchief_masterchief_biped : TagFile
    {
        public objects_characters_masterchief_masterchief_biped(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Biped>($@"objects\characters\masterchief\masterchief");
            var bipd = CacheContext.Deserialize<Biped>(Stream, tag);
            bipd.PathfindingSpheres = null;
            CacheContext.Serialize(Stream, tag, bipd);
        }
    }
}
