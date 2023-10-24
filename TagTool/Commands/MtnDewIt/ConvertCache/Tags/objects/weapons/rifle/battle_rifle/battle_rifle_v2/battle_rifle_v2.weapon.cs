using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.Commands.MtnDewIt.ConvertCache 
{
    public class objects_weapons_rifle_battle_rifle_battle_rifle_v2_battle_rifle_v2_weapon : TagFile
    {
        public objects_weapons_rifle_battle_rifle_battle_rifle_v2_battle_rifle_v2_weapon(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Weapon>($@"objects/weapons/rifle/battle_rifle/battle_rifle_v2/battle_rifle_v2");
        }
    }
}
