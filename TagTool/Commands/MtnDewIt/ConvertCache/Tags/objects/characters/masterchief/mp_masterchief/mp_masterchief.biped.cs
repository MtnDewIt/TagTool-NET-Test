using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.Commands.MtnDewIt.ConvertCache 
{
    public class objects_characters_masterchief_mp_masterchief_mp_masterchief_biped : TagFile
    {
        public objects_characters_masterchief_mp_masterchief_mp_masterchief_biped(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Biped>($@"objects/characters/masterchief/mp_masterchief/mp_masterchief");
        }
    }
}
