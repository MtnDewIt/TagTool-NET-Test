using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class ai_squad_templates_sq_camp_jetpack_3_squad_template : TagFile
    {
        public ai_squad_templates_sq_camp_jetpack_3_squad_template(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<SquadTemplate>($@"ai\squad_templates\sq_camp_jetpack_3");
            var sqtm = CacheContext.Deserialize<SquadTemplate>(Stream, tag);
            sqtm.Name = CacheContext.StringTable.GetOrAddString($@"sq_camp_brute_jetpack_3");
            sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
            {
                new SquadTemplate.CellTemplate
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"3_jetpack"),
                    NormalDiffCount = 3,
                    MajorUpgrade = SquadTemplate.CellTemplate.MajorUpgradeEnum.None,
                    Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                    {
                        new SquadTemplate.CellTemplate.ObjectBlock
                        {
                            Probability = 5,
                        },
                    },
                    InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                    {
                        new SquadTemplate.CellTemplate.ObjectBlock
                        {
                            Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                            Probability = 5,
                        },
                        new SquadTemplate.CellTemplate.ObjectBlock
                        {
                            Probability = 5,
                        },
                        new SquadTemplate.CellTemplate.ObjectBlock
                        {
                            DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                            Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                            Probability = 3,
                        },
                        new SquadTemplate.CellTemplate.ObjectBlock
                        {
                            DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                            Object = GetCachedTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
                            Probability = 3,
                        },
                    },
                },
            };
            CacheContext.Serialize(Stream, tag, sqtm);
        }
    }
}
