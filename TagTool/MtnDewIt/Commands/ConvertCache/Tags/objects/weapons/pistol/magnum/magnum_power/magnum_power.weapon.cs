using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_weapons_pistol_magnum_magnum_power_magnum_power_weapon : TagFile
    {
        public objects_weapons_pistol_magnum_magnum_power_magnum_power_weapon(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum_power\magnum_power");
            var weap = CacheContext.Deserialize<Weapon>(Stream, tag);
            weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
            {
                new Weapon.FirstPersonBlock() 
                {
                    FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\pistol\magnum\magnum_power\fp_magnum\fp_magnum_power"),
                    FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\pistol\fp_magnum\fp_magnum"),
                },
                new Weapon.FirstPersonBlock()
                {
                    FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\pistol\magnum\magnum_power\fp_magnum\fp_magnum_power"),
                    FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\pistol\fp_magnum\fp_magnum"),
                },
            };
            CacheContext.Serialize(Stream, tag, weap);
        }
    }
}
