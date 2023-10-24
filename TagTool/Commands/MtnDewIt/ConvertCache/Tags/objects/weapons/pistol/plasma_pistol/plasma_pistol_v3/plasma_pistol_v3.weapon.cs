using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.Commands.MtnDewIt.ConvertCache 
{
    public class objects_weapons_pistol_plasma_pistol_plasma_pistol_v3_plasma_pistol_v3_weapon : TagFile
    {
        public objects_weapons_pistol_plasma_pistol_plasma_pistol_v3_plasma_pistol_v3_weapon(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Weapon>($@"objects/weapons/pistol/plasma_pistol/plasma_pistol_v3/plasma_pistol_v3");
        }
    }
}
