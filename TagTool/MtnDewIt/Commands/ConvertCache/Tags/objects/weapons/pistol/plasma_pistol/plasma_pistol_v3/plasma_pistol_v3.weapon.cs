using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
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
            var tag = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol_v3\plasma_pistol_v3");
            var weap = CacheContext.Deserialize<Weapon>(Stream, tag);
            weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
            {
                new Weapon.FirstPersonBlock() 
                {
                    FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol_v3\fp_plasma_pistol\fp_plasma_pistol_v3"),
                    FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\pistol\fp_plasma_pistol\fp_plasma_pistol"),
                },
                new Weapon.FirstPersonBlock()
                {
                    FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol_v3\fp_plasma_pistol\fp_plasma_pistol_v3"),
                    FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\pistol\fp_plasma_pistol\fp_plasma_pistol"),
                },
            };
            CacheContext.Serialize(Stream, tag, weap);
        }
    }
}
