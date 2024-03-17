using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class ai_squad_templates_sq_sur_bugger_day_squad_template : TagFile
    {
        public ai_squad_templates_sq_sur_bugger_day_squad_template(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<SquadTemplate>($@"ai\squad_templates\sq_sur_bugger_day");
            var sqtm = CacheContext.Deserialize<SquadTemplate>(Stream, tag);
            sqtm.Name = CacheContext.StringTable.GetOrAddString($@"sq_sur_bugger_day");
            sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
            {
                new SquadTemplate.CellTemplate
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"1_bugger_captain"),
                    RoundRange = new Bounds<short>(2, 3),
                    NormalDiffCount = 1,
                    MajorUpgrade = SquadTemplate.CellTemplate.MajorUpgradeEnum.None,
                    Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                    {
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
                            Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle"),
                            Probability = 1,
                        },
                    },
                },
                new SquadTemplate.CellTemplate
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"4_buggers"),
                    RoundRange = new Bounds<short>(1, 1),
                    NormalDiffCount = 4,
                    MajorUpgrade = SquadTemplate.CellTemplate.MajorUpgradeEnum.None,
                    Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                    {
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
                            RoundRange = new Bounds<short>(0, 5),
                            Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                            Probability = 5,
                        },
                        new SquadTemplate.CellTemplate.ObjectBlock
                        {
                            RoundRange = new Bounds<short>(0, 5),
                            Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                            Probability = 3,
                        },
                    },
                },
                new SquadTemplate.CellTemplate
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"3_buggers"),
                    RoundRange = new Bounds<short>(2, 3),
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
                            RoundRange = new Bounds<short>(0, 5),
                            Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                            Probability = 5,
                        },
                        new SquadTemplate.CellTemplate.ObjectBlock
                        {
                            RoundRange = new Bounds<short>(0, 5),
                            Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                            Probability = 3,
                        },
                    },
                },
            };
            CacheContext.Serialize(Stream, tag, sqtm);
        }
    }
}
