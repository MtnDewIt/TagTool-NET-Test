using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class ai_squad_templates_sq_sur_covenant_squad_template : TagFile
    {
        public ai_squad_templates_sq_sur_covenant_squad_template(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<SquadTemplate>($@"ai\squad_templates\sq_sur_covenant");
            var sqtm = CacheContext.Deserialize<SquadTemplate>(Stream, tag);
            sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_sur_covenant");
            sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
            {
                new SquadTemplate.CellTemplate
                {
                    Name = CacheContext.StringTable.GetStringId($@"1_brute_captain"),
                    NormalDiffCount = 1,
                    MajorUpgrade = SquadTemplate.CellTemplate.MajorUpgradeEnum.None,
                    Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                    {
                        new SquadTemplate.CellTemplate.ObjectBlock
                        {
                            Probability = 5,
                        },
                        new SquadTemplate.CellTemplate.ObjectBlock
                        {
                            RoundRange = new Bounds<short>(2, 3),
                            Probability = 3,
                        },
                        new SquadTemplate.CellTemplate.ObjectBlock
                        {
                            RoundRange = new Bounds<short>(3, 3),
                            Probability = 1,
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
                            Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle"),
                            Probability = 5,
                        },
                        new SquadTemplate.CellTemplate.ObjectBlock
                        {
                            RoundRange = new Bounds<short>(3, 3),
                            Object = GetCachedTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
                            Probability = 1,
                        },
                        new SquadTemplate.CellTemplate.ObjectBlock
                        {
                            RoundRange = new Bounds<short>(2, 3),
                            Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                            Probability = 3,
                        },
                        new SquadTemplate.CellTemplate.ObjectBlock
                        {
                            RoundRange = new Bounds<short>(2, 3),
                            Object = GetCachedTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
                            Probability = 3,
                        },
                    },
                },
                new SquadTemplate.CellTemplate
                {
                    Name = CacheContext.StringTable.GetStringId($@"3_grunt"),
                    NormalDiffCount = 3,
                    MajorUpgrade = SquadTemplate.CellTemplate.MajorUpgradeEnum.None,
                    Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                    {
                        new SquadTemplate.CellTemplate.ObjectBlock
                        {
                            Probability = 5,
                        },
                        new SquadTemplate.CellTemplate.ObjectBlock
                        {
                            Probability = 3,
                        },
                        new SquadTemplate.CellTemplate.ObjectBlock
                        {
                            Probability = 1,
                        },
                    },
                    InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                    {
                        new SquadTemplate.CellTemplate.ObjectBlock
                        {
                            Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                            Probability = 5,
                        },
                        new SquadTemplate.CellTemplate.ObjectBlock
                        {
                            Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                            Probability = 3,
                        },
                        new SquadTemplate.CellTemplate.ObjectBlock
                        {
                            RoundRange = new Bounds<short>(2, 3),
                            Object = GetCachedTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
                            Probability = 1,
                        },
                    },
                },
            };
            CacheContext.Serialize(Stream, tag, sqtm);
        }
    }
}
