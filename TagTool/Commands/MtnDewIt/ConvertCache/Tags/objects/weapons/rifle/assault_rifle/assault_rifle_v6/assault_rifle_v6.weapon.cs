using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.Commands.MtnDewIt.ConvertCache 
{
    public class objects_weapons_rifle_assault_rifle_assault_rifle_v6_assault_rifle_v6_weapon : TagFile
    {
        public objects_weapons_rifle_assault_rifle_assault_rifle_v6_assault_rifle_v6_weapon(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Weapon>($@"objects/weapons/rifle/assault_rifle/assault_rifle_v6/assault_rifle_v6");
        }
    }
}
