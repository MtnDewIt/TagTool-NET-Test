using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_weapons_rifle_battle_rifle_battle_rifle_power_battle_rifle_power_weapon : TagFile
    {
        public objects_weapons_rifle_battle_rifle_battle_rifle_power_battle_rifle_power_weapon(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle_power\battle_rifle_power");
            var weap = CacheContext.Deserialize<Weapon>(Stream, tag);
            weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
            {
                new Weapon.FirstPersonBlock() 
                {
                    FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\battle_rifle\battle_rifle_power\fp_battle_rifle\fp_battle_rifle_power"),
                    FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_battle_rifle\fp_battle_rifle"),
                },
                new Weapon.FirstPersonBlock()
                {
                    FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\battle_rifle\battle_rifle_power\fp_battle_rifle\fp_battle_rifle_power"),
                    FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_battle_rifle\fp_battle_rifle"),
                },
            };
            CacheContext.Serialize(Stream, tag, weap);
        }
    }
}
