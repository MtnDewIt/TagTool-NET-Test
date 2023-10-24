using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.Commands.MtnDewIt.ConvertCache 
{
    public class objects_characters_masterchief_shaders_mp_ryu_visor_shader : TagFile
    {
        public objects_characters_masterchief_shaders_mp_ryu_visor_shader(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Shader>($@"objects/characters/masterchief/shaders/mp_ryu_visor");
        }
    }
}
