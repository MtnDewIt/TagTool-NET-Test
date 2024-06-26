using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_weapons_rifle_assault_rifle_assault_rifle_damage_assault_rifle_damage_weapon : TagFile
    {
        public objects_weapons_rifle_assault_rifle_assault_rifle_damage_assault_rifle_damage_weapon(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle_damage\assault_rifle_damage");
            var weap = CacheContext.Deserialize<Weapon>(Stream, tag);
            weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
            {
                new Weapon.FirstPersonBlock() 
                {
                    FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\assault_rifle\assault_rifle_damage\fp_assault_rifle\fp_assault_rifle_damage"),
                    FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_assault_rifle\fp_assault_rifle"),
                },
                new Weapon.FirstPersonBlock()
                {
                    FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\assault_rifle\assault_rifle_damage\fp_assault_rifle\fp_assault_rifle_damage"),
                    FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_assault_rifle\fp_assault_rifle"),
                },
            };
            CacheContext.Serialize(Stream, tag, weap);
        }
    }
}
