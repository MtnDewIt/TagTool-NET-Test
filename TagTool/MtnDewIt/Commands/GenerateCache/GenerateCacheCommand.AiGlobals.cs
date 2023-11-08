using TagTool.Common;
using TagTool.Tags.Definitions;
using System.Collections.Generic;
using TagTool.Ai;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command
    {
        public static readonly string[] Templates = new[]
        {
            @"ai\squad_templates\line_break",
            @"ai\squad_templates\campaign",
            @"ai\squad_templates\sq_camp_grunt_solo",
            @"ai\squad_templates\sq_camp_grunt_2",
            @"ai\squad_templates\sq_camp_grunt_3",
            @"ai\squad_templates\sq_camp_4_grunt",
            @"ai\squad_templates\sq_camp_grunt_flak",
            @"ai\squad_templates\sq_camp_grunt_flak_3",
            @"ai\squad_templates\sq_camp_grunt_turret",
            @"ai\squad_templates\sq_camp_grunt_turret_undeployed",
            @"ai\squad_templates\blank",
            @"ai\squad_templates\sq_camp_captain_solo",
            @"ai\squad_templates\sq_camp_captain_grunt_2",
            @"ai\squad_templates\sq_camp_captain_3_grunt",
            @"ai\squad_templates\sq_camp_captain_jackal_2",
            @"ai\squad_templates\sq_camp_captain_jackal_3",
            @"ai\squad_templates\sq_camp_captain_brute_2",
            @"ai\squad_templates\sq_camp_captain_brute_3",
            @"ai\squad_templates\sq_camp_captain_engineer_2",
            @"ai\squad_templates\sq_camp_4_cov",
            @"ai\squad_templates\sq_camp_brute_2",
            @"ai\squad_templates\sq_camp_brute_3",
            @"ai\squad_templates\sq_camp_4_brute",
            @"ai\squad_templates\sq_camp_cap_grunt_eng",
            @"ai\squad_templates\sq_camp_brute_turret",
            @"ai\squad_templates\sq_camp_jetpack_solo",
            @"ai\squad_templates\sq_camp_jetpack_2",
            @"ai\squad_templates\sq_camp_jetpack_3",
            @"ai\squad_templates\sq_camp_jetpack_4",
            @"ai\squad_templates\sq_camp_brute_stealth_2",
            @"ai\squad_templates\sq_camp_brute_stealth_4",
            @"ai\squad_templates\sq_camp_brute_stealth_6",
            @"ai\squad_templates\sq_camp_jackal_solo",
            @"ai\squad_templates\sq_camp_2_jackal",
            @"ai\squad_templates\sq_camp_jackal_3",
            @"ai\squad_templates\sq_camp_jackal_4",
            @"ai\squad_templates\sq_camp_jackal_carbine",
            @"ai\squad_templates\sq_camp_jackal_carbine_2",
            @"ai\squad_templates\sq_camp_jackal_carbine_3",
            @"ai\squad_templates\sq_camp_jackal_carbine_4",
            @"ai\squad_templates\sq_camp_jackal_sniper",
            @"ai\squad_templates\sq_camp_jackal_sniper_2",
            @"ai\squad_templates\sq_camp_jackal_sniper_3",
            @"ai\squad_templates\sq_camp_jackal_sniper_4",
            @"ai\squad_templates\sq_camp_2_bodyguards",
            @"ai\squad_templates\sq_camp_chieftain_hammer",
            @"ai\squad_templates\sq_camp_chieftain_plasma",
            @"ai\squad_templates\sq_camp_chieftain_flak",
            @"ai\squad_templates\sq_camp_1_hunter_flak",
            @"ai\squad_templates\sq_camp_1_hunter_plasma",
            @"ai\squad_templates\sq_camp_hunters",
            @"ai\squad_templates\sq_camp_bugger_pupa_2",
            @"ai\squad_templates\sq_camp_bugger_pupa_4",
            @"ai\squad_templates\sq_camp_bugger_2",
            @"ai\squad_templates\sq_camp_bugger_4",
            @"ai\squad_templates\sq_camp_engineer_free_1",
            @"ai\squad_templates\sq_camp_engineer_1",
            @"ai\squad_templates\sq_camp_engineer_2",
            @"ai\squad_templates\sq_camp_engineer_4",
            @"ai\squad_templates\vehicles",
            @"ai\squad_templates\sq_camp_1_shade",
            @"ai\squad_templates\sq_camp_1_ghost",
            @"ai\squad_templates\sq_camp_2_ghost",
            @"ai\squad_templates\sq_camp_1_chopper",
            @"ai\squad_templates\sq_camp_wraith",
            @"ai\squad_templates\sq_camp_wraith_aa",
            @"ai\squad_templates\sq_camp_1_banshee",
            @"ai\squad_templates\sq_camp_1_banshee_nobomb",
            @"ai\squad_templates\sq_camp_2_banshee_nobomb",
            @"ai\squad_templates\sq_camp_phantom",
            @"ai\squad_templates\sq_camp_phantom_cheap",
            @"ai\squad_templates\sq_camp_phantom_engineer",
            @"ai\squad_templates\sq_camp_warthog",
            @"ai\squad_templates\sq_camp_scorpion_2",
            @"ai\squad_templates\sq_camp_scorpion_full",
            @"ai\squad_templates\survival_mode",
            @"ai\squad_templates\sq_sur_grunt",
            @"ai\squad_templates\sq_sur_covenant",
            @"ai\squad_templates\sq_sur_brute_pack",
            @"ai\squad_templates\sq_sur_brute_jetpack",
            @"ai\squad_templates\sq_sur_brute_stealth",
            @"ai\squad_templates\sq_sur_bugger",
            @"ai\squad_templates\sq_sur_bugger_day",
            @"ai\squad_templates\sq_sur_jackal",
            @"ai\squad_templates\sq_sur_jackal_sniper",
            @"ai\squad_templates\sq_sur_1_hunter",
            @"ai\squad_templates\sq_sur_chieftain",
            @"ai\squad_templates\sq_sur_chieftain_1",
            @"ai\squad_templates\sq_sur_chieftain_hammer",
            @"ai\squad_templates\sq_sur_chieftain_plasma",
            @"ai\squad_templates\sq_sur_chieftain_flak",
            @"ai\squad_templates\sq_sur_phantom",
            @"ai\squad_templates\sq_sur_phantom_cheap",
            @"ai\squad_templates\sq_sur_bonus_round_01",
        };
        public void GenerateSquadTemplates() 
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                foreach (var tagName in Templates) 
                {
                    var sqtmTag = CacheContext.TagCache.AllocateTag<SquadTemplate>(tagName);
                    var sqtm = new SquadTemplate();
                    CacheContext.Serialize(stream, sqtmTag, sqtm);
                }
            }
        }

        public void SquadTemplatesSetup() 
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\blank")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\campaign")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"campaign");
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\line_break")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"====================");
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_1_banshee")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_banshee_1");
                        sqtm.CellTemplates = new System.Collections.Generic.List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_banshee"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object =  GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_1_banshee_nobomb")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_banshee_no_bomb");
                        sqtm.CellTemplates = new System.Collections.Generic.List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_banshee"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object =  GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_1_chopper")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_chopper_1");
                        sqtm.CellTemplates = new System.Collections.Generic.List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_chopper"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object =  GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_1_ghost")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_ghost_1");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate> 
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_ghost"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Easy | SquadTemplate.CellTemplate.DifficultyFlagsValue.Normal,
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Easy | SquadTemplate.CellTemplate.DifficultyFlagsValue.Normal,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };

                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_1_hunter_flak")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_hunter_flak_1");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate> 
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_hunter"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_1_hunter_plasma")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_hunter_plasma_1");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_hunter"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_1_shade")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_shade_1");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate> 
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_shade"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
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
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_2_banshee_nobomb")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_banshee_no_bomb_2");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_banshee"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_2_bodyguards")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_bodyguards_2");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"2_bodyguards"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
                                        Probability = 3,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_2_ghost")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_ghost_2");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"2_ghost"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Easy | SquadTemplate.CellTemplate.DifficultyFlagsValue.Normal,
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Easy | SquadTemplate.CellTemplate.DifficultyFlagsValue.Normal,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Easy | SquadTemplate.CellTemplate.DifficultyFlagsValue.Normal,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary, 
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_2_jackal")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_jackal_2");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"2_jackal"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
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
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_4_brute")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_brute_4");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"4_brute"),
                                NormalDiffCount = 4,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_4_cov")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_grunt_brute_combo_4");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_captain"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
                                        Probability = 1,
                                    },
                                },
                            },
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"3_grunt_brute"),
                                NormalDiffCount = 3,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Easy | SquadTemplate.CellTemplate.DifficultyFlagsValue.Normal,
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Easy | SquadTemplate.CellTemplate.DifficultyFlagsValue.Normal,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Easy | SquadTemplate.CellTemplate.DifficultyFlagsValue.Normal,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_4_grunt")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_grunt_4");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"4_grunt"),
                                NormalDiffCount = 4,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
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
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_brute_2")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_brute_2");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"2_brute"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_brute_3")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_brute_3");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"3_brute"),
                                NormalDiffCount = 3,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_brute_stealth_2")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_brute_stealth_2");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"brute_stalker"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
                                        Probability = 2,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_brute_stealth_4")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_brute_stealth_4");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"engineer"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                            },
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"brute_stalker"),
                                NormalDiffCount = 3,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
                                        Probability = 2,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_brute_stealth_6")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_brute_stealth_6");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate> 
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"brute_stealth"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 2,
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
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
                                        Probability = 2,
                                    },
                                },
                            },
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"engineer"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                            },
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"jackal_sniper"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 2,
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
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 1,
                                    },
                                },
                            },
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"brute_captain"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_brute_turret")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_brute_turret");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_turret"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_bugger_2")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_sur_bugger_2");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"2_bugger"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Easy | SquadTemplate.CellTemplate.DifficultyFlagsValue.Normal | SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_bugger_4")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_sur_bugger_4");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"4_bugger"),
                                NormalDiffCount = 4,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Easy | SquadTemplate.CellTemplate.DifficultyFlagsValue.Normal | SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 7,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_bugger_pupa_2")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_bugger_pupa_2");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"2_bugger_pupa"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
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
                                        Probability = 7,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_bugger_pupa_4")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_bugger_pupa_4");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"4_bugger_pupa"),
                                NormalDiffCount = 4,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
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
                                        Probability = 7,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_cap_grunt_eng")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_cap_grunt_eng");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_captain"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
                                        Probability = 1,
                                    },
                                },
                            },
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"3_grunt"),
                                NormalDiffCount = 3,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
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
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                },
                            },
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_engineer"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_captain_3_grunt")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_cap_grunts_3");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_captain"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
                                        Probability = 1,
                                    },
                                },
                            },
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"3_grunt"),
                                NormalDiffCount = 3,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
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
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_captain_brute_2")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_cap_brute_2");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_captain"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
                                        Probability = 1,
                                    },
                                },
                            },
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"2_brute"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_captain_brute_3")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_cap_brute_3");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_captain"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
                                        Probability = 1,
                                    },
                                },
                            },
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"3_brute"),
                                NormalDiffCount = 3,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_captain_engineer_2")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_cap_engineer_2");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_captain"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
                                        Probability = 1,
                                    },
                                },
                            },
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"2_engineer"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_captain_grunt_2")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_cap_grunts_2");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate> 
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_captain"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
                                        Probability = 1,
                                    },
                                },
                            },
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"2_grunt"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
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
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_captain_jackal_2")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_cap_jackal_2");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_captain"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
                                        Probability = 1,
                                    },
                                },
                            },
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"2_jackal"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
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
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_captain_jackal_3")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_cap_jackal_3");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_captain"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
                                        Probability = 1,
                                    },
                                },
                            },
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"3_jackal"),
                                NormalDiffCount = 3,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
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
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_captain_solo")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_cap_solo");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_captain"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_chieftain_flak")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_chieftain_flak");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_flak"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_chieftain_hammer")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_chieftain_hammer");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_hammer"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\melee\gravity_hammer\gravity_hammer"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_chieftain_plasma")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_chieftain_plasma");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_plasma"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\turret\plasma_cannon\plasma_cannon"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_engineer_1")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_engineer_1");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_engineer"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_engineer_2")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_engineer_2");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"2_engineer"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_engineer_4")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_engineer_4");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"4_engineer"),
                                NormalDiffCount = 4,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_engineer_free_1")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_engineer_free_1");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_engineer"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_grunt_2")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_grunt_2");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"2_grunt"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
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
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_grunt_3")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_grunt_3");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"3_grunt"),
                                NormalDiffCount = 3,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
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
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_grunt_flak")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_grunt_flak");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_grunt"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_grunt_flak_3")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_grunt_flak_3");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"3_grunt"),
                                NormalDiffCount = 3,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_grunt_solo")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_grunt_solo");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_grunt"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
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
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_grunt_turret")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_grunt_turret");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_turret"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
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
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_grunt_turret_undeployed")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_grunt_turret_undeployed");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_turret"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialSecondaryWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_hunters")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_hunters");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate> 
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_hunter_plasma"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                            },
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_hunter_flak"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_jackal_3")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_jackal_3");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"3_jackal"),
                                NormalDiffCount = 3,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
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
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_jackal_4")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_jackal_4");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"4_jackal"),
                                NormalDiffCount = 4,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
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
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_jackal_carbine")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_jackal_carbine");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_jackal"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 3,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_jackal_carbine_2")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_jackal_carbine_2");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"2_jackal"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 3,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_jackal_carbine_3")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_jackal_carbine_3");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"3_jackal"),
                                NormalDiffCount = 3,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 3,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_jackal_carbine_4")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_jackal_carbine_4");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"4_jackal"),
                                NormalDiffCount = 4,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 3,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_jackal_sniper")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_jackal_sniper");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_jackal"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\beam_rifle\beam_rifle"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_jackal_sniper_2")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_jackal_sniper_2");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"2_jackal"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\beam_rifle\beam_rifle"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_jackal_sniper_3")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_jackal_sniper_3");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"3_jackal"),
                                NormalDiffCount = 3,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\beam_rifle\beam_rifle"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_jackal_sniper_4")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_jackal_sniper_4");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"4_jackal"),
                                NormalDiffCount = 4,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\beam_rifle\beam_rifle"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_jackal_solo")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_jackal_solo");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_jackal"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
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
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_jetpack_2")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_brute_jetpack_2");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"2_jetpack"),
                                NormalDiffCount = 2,
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
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_jetpack_3")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_brute_jetpack_3");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"3_jetpack"),
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
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_jetpack_4")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_brute_jetpack_4");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"4_jetpack"),
                                NormalDiffCount = 4,
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
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_jetpack_solo")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_brute_jetpack_solo");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_jetpack"),
                                NormalDiffCount = 1,
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
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_phantom")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_phantom_1");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_phantom"),
                                NormalDiffCount = 3,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
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
                                        Probability = 3,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_phantom_cheap")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_phantom_cheap");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_phantom"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_phantom_engineer")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_phantom_engineer");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_phantom"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
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
                                        Probability = 3,
                                    },
                                },
                                VehicleVariant = CacheContext.StringTable.GetStringId($@"engineer_chain"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_scorpion_2")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_scorpion_1");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_scorpion"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_scorpion_full")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_scorpion_full");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_scorpion"),
                                NormalDiffCount = 6,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_warthog")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_warthog_full");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_warthog"),
                                NormalDiffCount = 3,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_wraith")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_wraith_1");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_wraith"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_camp_wraith_aa")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_camp_wraith_aa");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_wraith"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 1,
                                    },
                                },
                                VehicleVariant = CacheContext.StringTable.GetStringId($@"anti_air"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_sur_1_hunter")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_sur_hunter");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate> 
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_hunter"),
                                NormalDiffCount = 1,
                                MajorUpgrade = SquadTemplate.CellTemplate.MajorUpgradeEnum.None,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        RoundRange = new Bounds<short>(2, 3),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        RoundRange = new Bounds<short>(1, 1),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_sur_bonus_round_01")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_sur_bonus_round_01");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"4_grunt"),
                                NormalDiffCount = 4,
                                MajorUpgrade = SquadTemplate.CellTemplate.MajorUpgradeEnum.None,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
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
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_sur_brute_jetpack")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_sur_brute_jetpack");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate> 
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"4_jetpack"),
                                NormalDiffCount = 4,
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
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        RoundRange = new Bounds<short>(3, 3),
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_sur_brute_pack")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_sur_brute_pack");
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
                                Name = CacheContext.StringTable.GetStringId($@"3_brute"),
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
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 10,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_sur_brute_stealth")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_sur_brute_stealth");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"4_brute_stealth"),
                                NormalDiffCount = 4,
                                MajorUpgrade = SquadTemplate.CellTemplate.MajorUpgradeEnum.None,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_sur_bugger")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_sur_bugger_night");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_bugger_captain"),
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
                                Name = CacheContext.StringTable.GetStringId($@"4_buggers"),
                                RoundRange = new Bounds<short>(0, 1),
                                NormalDiffCount = 4,
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
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"3_buggers"),
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
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_sur_bugger_day")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_sur_bugger_day");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_bugger_captain"),
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
                                Name = CacheContext.StringTable.GetStringId($@"4_buggers"),
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
                                Name = CacheContext.StringTable.GetStringId($@"3_buggers"),
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
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_sur_chieftain")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_sur_chieftain");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate> 
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_hammer"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\melee\gravity_hammer\gravity_hammer"),
                                        Probability = 1,
                                    },
                                },
                            },
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_plasma"),
                                RoundRange = new Bounds<short>(2, 10),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\turret\plasma_cannon\plasma_cannon"),
                                        Probability = 1,
                                    },
                                },
                            },
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_flak"),
                                RoundRange = new Bounds<short>(4, 10),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_sur_chieftain_1")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_sur_chieftain_1");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate> 
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_hammer"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\melee\gravity_hammer\gravity_hammer"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_sur_chieftain_flak")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_sur_chieftain_flak");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_flak"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
                                        Probability = 1,
                                    },
                                },
                            },
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"2_bodyguards"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_sur_chieftain_hammer")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_sur_chieftain_hammer");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_hammer"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\melee\gravity_hammer\gravity_hammer"),
                                        Probability = 1,
                                    },
                                },
                            },
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"2_bodyguards"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_sur_chieftain_plasma")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_sur_chieftain_plasma");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_plasma"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\turret\plasma_cannon\plasma_cannon"),
                                        Probability = 1,
                                    },
                                },
                            },
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"2_bodyguards"),
                                NormalDiffCount = 2,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_sur_covenant")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
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
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_sur_grunt")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_sur_grunt");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"4_grunt"),
                                NormalDiffCount = 4,
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
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_sur_jackal")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_sur_jackal");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_jackal_sniper"),
                                NormalDiffCount = 1,
                                MajorUpgrade = SquadTemplate.CellTemplate.MajorUpgradeEnum.None,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        RoundRange = new Bounds<short>(3,3),
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\beam_rifle\beam_rifle"),
                                        Probability = 1,
                                    },
                                },
                            },
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"3_jackals"),
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
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_sur_jackal_sniper")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_sur_jackal_sniper");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_jackal_sniper"),
                                NormalDiffCount = 1,
                                MajorUpgrade = SquadTemplate.CellTemplate.MajorUpgradeEnum.None,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                                InitialWeapons = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\beam_rifle\beam_rifle"),
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_sur_phantom")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_sur_phantom");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate>
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_phantom"),
                                NormalDiffCount = 3,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\sq_sur_phantom_cheap")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"sq_sur_phantom_cheap");
                        sqtm.CellTemplates = new List<SquadTemplate.CellTemplate> 
                        {
                            new SquadTemplate.CellTemplate
                            {
                                Name = CacheContext.StringTable.GetStringId($@"1_phantom"),
                                NormalDiffCount = 1,
                                Characters = new List<SquadTemplate.CellTemplate.ObjectBlock>
                                {
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\survival_mode")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"survival");
                        CacheContext.Serialize(stream, tag, sqtm);
                    }

                    if (tag.IsInGroup("sqtm") && tag.Name == $@"ai\squad_templates\vehicles")
                    {
                        var sqtm = CacheContext.Deserialize<SquadTemplate>(stream, tag);
                        sqtm.Name = CacheContext.StringTable.GetStringId($@"vehicles");
                        CacheContext.Serialize(stream, tag, sqtm);
                    }
                }
            }
        }

        public void GenerateDialogueGlobals()
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                var adlgTag = CacheContext.TagCache.AllocateTag<AiDialogueGlobals>($@"ai\ai_dialogue_globals");
                var adlg = new AiDialogueGlobals
                {
                    StrikeDelayBounds = new Bounds<float>(3.5f, 7f),
                    RemindDelay = 17f,
                    CoverCurseChance = 0.4f,
                    PlayerVocalizationStaminaThreshold = 0.75f,
                    Vocalizations = new List<VocalizationDefinition>
                    {
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"dth"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"aargh!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"dth_drama"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"waaargh_guh_guh_gurgle_uh_choke_gurgle"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"dth_fall"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"aaaaaaaaaaaaargh_..._oomph!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"dth_hdsht"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"oof_[headshot]"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"dth_mjr"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"aaaaargh!!!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"dth_slnt"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"oof"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"dth_slw"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"erg_erg_arrgh_uh_uh_aargh!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"dth_reanimated"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"aarrgfgkdjhgdfdhk"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"die_ass"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Scripted,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SpeakerEmotion = AiEmotion.Pain,
                            SampleLine = CacheContext.StringTable.GetStringId($@"added_for_assassinations"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"pain"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"ah"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"pain_fall"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"oof_ow!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"pain_mdm"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"erg!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"pain_mjr"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"erk!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"pain_shld"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"uh!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"flee"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"fleeing_?!!!!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"cower"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"cowering!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"fall"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"fall!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"lift"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"lift!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"dive"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"dive!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"kill_ass"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Involuntary,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"added_for_assassinations_[assassin_kills]"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ass_grabber"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"added_for_assassinations_[assassin_grab]"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ass_grabbed"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SpeakerEmotion = AiEmotion.Surprised,
                            SampleLine = CacheContext.StringTable.GetStringId($@"added_for_assassinations_[assassin_victim_grabbed]"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"dodge"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"dodge!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"bump"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"*bump*"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"stun"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"stunnnnn?"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"thrwn"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"thrown!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"charge"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"charging!!!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"melee"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"melee!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"meleeleap"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"meelee_leap"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"brsrk"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"berserking!!!!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"kamikaze"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"kamikazeing!!!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"reanimate"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"*reanimation*"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"sigh"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"sigh!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"contempt"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"what_contempt!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"anger"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"angerrrrrr?!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"fear"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"fear_fear_fear!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"relief"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"phew!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"srprs"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Act,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"yikes!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"panic"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Act,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 2,
                            SampleLine = CacheContext.StringTable.GetStringId($@"waaaaaa!!!!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"panic_infctnfrm"),
                            ParentIndex = 38,
                            Priority = VocalizationPriority.Act,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 2,
                            SampleLine = CacheContext.StringTable.GetStringId($@"get_it_off_me!!!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"panic_onfire"),
                            ParentIndex = 38,
                            Priority = VocalizationPriority.Act,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 2,
                            SampleLine = CacheContext.StringTable.GetStringId($@"i'm_burning!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"panic_plsmgrnd"),
                            ParentIndex = 38,
                            Priority = VocalizationPriority.Act,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 2,
                            SampleLine = CacheContext.StringTable.GetStringId($@"get_it_off!_someone_get_it_off!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"betray"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Act,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 2,
                            SampleLine = CacheContext.StringTable.GetStringId($@"get_him!_he's_a_traitor!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"forgive"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Act,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 2,
                            SampleLine = CacheContext.StringTable.GetStringId($@"i'll_trust_you_for_now_..."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"entervcl"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Combat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"let's_roll!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"entervcl_drvr"),
                            ParentIndex = 44,
                            Priority = VocalizationPriority.Combat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"i'll_drive!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"entervcl_gnr"),
                            ParentIndex = 44,
                            Priority = VocalizationPriority.Combat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"i_got_the_gun!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"entervcl_psngr"),
                            ParentIndex = 44,
                            Priority = VocalizationPriority.Combat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"shotgun!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"entervcl_trrt"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"i'm_on_the_turret!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"grt_intovcl"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"let's_roll!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"grt_intovcl_imdvr"),
                            ParentIndex = 49,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"here_we_go."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"grt_intovcl_imgnr"),
                            ParentIndex = 49,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"find_me_something_to_shoot!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"grt_intovcl_mine"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"welcome_aboard."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"invt_vcl"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Act,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"want_a_ride?"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"invt_vcl_gnr"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Act,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"i_could_use_a_gunner!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"bye_extvhl"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            RepeatDelay = 60f,
                            Weight = 0.5f,
                            PlayerSpeakerSkipFraction = 1,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 1,
                            SkipFraction = 1,
                            SampleLine = CacheContext.StringTable.GetStringId($@"i'll_just_wait_here_then."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"grt"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            PlayerSkipFraction = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"hey!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"grt_plr_arb"),
                            ParentIndex = 56,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 60,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"look_an_arbiter!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"grt_plr_mc"),
                            ParentIndex = 56,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 60,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"look_a_mark_6!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"grt_plr_srprs"),
                            ParentIndex = 56,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            PlayerSkipFraction = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"woah!_don't_sneak_up_on_a_guy_like_that!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"grt_plr_vcl"),
                            ParentIndex = 56,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 30f,
                            Weight = 2,
                            PlayerSkipFraction = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"nice_ride!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"grt_plr_vcl_empty"),
                            ParentIndex = 56,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 30f,
                            Weight = 2,
                            PlayerSkipFraction = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"got_room_for_me_in_there?"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"hail"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 15,
                            Weight = 6,
                            SampleLine = CacheContext.StringTable.GetStringId($@"the_cavalry_has_arrived!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"hail_plr_arb"),
                            ParentIndex = 62,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 60,
                            Weight = 6,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"hail_plr_mc"),
                            ParentIndex = 62,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 60,
                            Weight = 6,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"hail_agg"),
                            ParentIndex = 62,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 15,
                            Weight = 4f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"welcome_to_the_party!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"hail_tim"),
                            ParentIndex = 62,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 15,
                            Weight = 4f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"keep_yer_head_down_sir!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"look"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 2.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"what're_you_lookin'_at?"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"look_plr_arb"),
                            ParentIndex = 67,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 2.5f,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"can_i_help_you?"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"look_plr_mc"),
                            ParentIndex = 67,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 2.5f,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"look_plr_fllw"),
                            ParentIndex = 67,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 2.5f,
                            Weight = 2,
                            SampleLine = CacheContext.StringTable.GetStringId($@"following_your_lead."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"look_pstcmbt"),
                            ParentIndex = 67,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 2.5f,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.35f,
                            PlayerSkipFraction = 0.35f,
                            FloodSkipFraction = 0.35f,
                            SkipFraction = 0.35f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"that_was_some_fight_huh?"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"look_pstcmbt_ez"),
                            ParentIndex = 71,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 2.5f,
                            PostVocalizationDelay = 15,
                            Weight = 3,
                            PlayerSpeakerSkipFraction = 0.35f,
                            PlayerSkipFraction = 0.35f,
                            FloodSkipFraction = 0.35f,
                            SkipFraction = 0.35f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"did_you_see_me_kick_that_guy's_ass?"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"look_pstcmbt_hrd"),
                            ParentIndex = 71,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 2.5f,
                            PostVocalizationDelay = 15,
                            Weight = 3,
                            PlayerSpeakerSkipFraction = 0.35f,
                            PlayerSkipFraction = 0.35f,
                            FloodSkipFraction = 0.35f,
                            SkipFraction = 0.35f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"we_wouldn't_have_stood_a_chance_without_you."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"look_lngtme"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 2.5f,
                            Weight = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"i_think_we_both_have_better_things_to_do..."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"lookcmbt"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 2.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"orders?"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"lookcmbt_fllw"),
                            ParentIndex = 75,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 2.5f,
                            Weight = 2,
                            SampleLine = CacheContext.StringTable.GetStringId($@"you_set_em_up_i'll_knock_em_down!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"lookcmbt_agg"),
                            ParentIndex = 75,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 2.5f,
                            Weight = 2,
                            SampleLine = CacheContext.StringTable.GetStringId($@"let's_kick_some_ass!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"lookcmbt_tim"),
                            ParentIndex = 75,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 2.5f,
                            Weight = 2,
                            SampleLine = CacheContext.StringTable.GetStringId($@"there's_no_place_like_home..."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ok"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            Weight = 1.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"ok."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ok_plr_trdwpn"),
                            ParentIndex = 79,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 2,
                            Weight = 1.5f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"it's_all_yours."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ok_plr_trdst_dvr"),
                            ParentIndex = 79,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 5,
                            Weight = 1.5f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"how_come_you_get_to_drive?"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ok_plr_trdst_gnr"),
                            ParentIndex = 79,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 5,
                            Weight = 1.5f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"aw_..._i_was_having_fun!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ok_plr_arb"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 5,
                            Weight = 1.5f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"okay_arbiter."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ok_plr_mc"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 5,
                            Weight = 1.5f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"okay_chief."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"thnk"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            Weight = 1.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"thanks."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"thnk_plr_btrwpn"),
                            ParentIndex = 85,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 2,
                            Weight = 1.5f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"nice!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"thnk_plr_arb"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 5,
                            Weight = 1.5f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"thanks_arbiter."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"thnk_plr_mc"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 5,
                            Weight = 1.5f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"thanks_chief."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"scrn"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            Weight = 1.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"great."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"scrn_plr_wrswpn"),
                            ParentIndex = 89,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 2,
                            Weight = 1.5f,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"you_gotta_be_kidding_me!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"scrn_plr_arb"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 5,
                            Weight = 1.5f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"great_arbiter."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"scrn_plr_mc"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 5,
                            Weight = 1.5f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"great_chief."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"hrdfoe"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            PlayerSkipFraction = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"did_you_hear_that?!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"seefoe"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"we've_got_company!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"seefoe_mjr"),
                            ParentIndex = 94,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 3,
                            PlayerSpeakerSkipFraction = 0.4f,
                            PlayerSkipFraction = 0.75f,
                            FloodSkipFraction = 0.4f,
                            SkipFraction = 0.4f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"scary_enemy!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"seefoe_mjr_arb"),
                            ParentIndex = 95,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.7f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.7f,
                            SkipFraction = 0.7f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"the_arbiter_is_here!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"seefoe_mjr_mc"),
                            ParentIndex = 95,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.7f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.7f,
                            SkipFraction = 0.7f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"the_demon_is_here!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"seefoe_upthere"),
                            ParentIndex = 94,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 4f,
                            PlayerSpeakerSkipFraction = 0.1f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.1f,
                            SkipFraction = 0.1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"up_there!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"seefoe_downthere"),
                            ParentIndex = 94,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 4f,
                            PlayerSpeakerSkipFraction = 0.1f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.1f,
                            SkipFraction = 0.1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"down_there!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"seefoe_agg"),
                            ParentIndex = 94,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 4f,
                            PlayerSpeakerSkipFraction = 0.1f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.1f,
                            SkipFraction = 0.1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"it's_go_time!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"seefoe_tim"),
                            ParentIndex = 94,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 4f,
                            PlayerSpeakerSkipFraction = 0.1f,
                            PlayerSkipFraction = 0.75f,
                            FloodSkipFraction = 0.1f,
                            SkipFraction = 0.1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"we're_under_attack!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"morefoe"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 1,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.35f,
                            SkipFraction = 0.35f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"there's_another_one!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"foundfoe"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 10,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"over_here!"),
                            Responses = new List<AiVocalizationResponse>
                            {
                                new AiVocalizationResponse
                                {
                                    VocalizationName = CacheContext.StringTable.GetStringId($@"foundfoe_re"),
                                    VocalizationIndex = 108,
                                    ResponseType = AiVocalizationResponseType.FriendInfantry,
                                    DialogueIndexImport = -1,
                                },
                            },
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"foundfoe_mjr_mc"),
                            ParentIndex = 103,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 20,
                            RepeatDelay = 10,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.65f,
                            PlayerSkipFraction = 0.65f,
                            FloodSkipFraction = 0.65f,
                            SkipFraction = 0.65f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"there_you_are_demon!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"foundfoe_mjr_arb"),
                            ParentIndex = 103,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 20,
                            RepeatDelay = 10,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.65f,
                            PlayerSkipFraction = 0.65f,
                            FloodSkipFraction = 0.65f,
                            SkipFraction = 0.65f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"there_you_are_arbiter!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"foundfoe_prst"),
                            ParentIndex = 103,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 10,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"found_'em!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"foundfoe_chasing"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.75f,
                            PlayerSkipFraction = 0.75f,
                            FloodSkipFraction = 0.75f,
                            SkipFraction = 0.75f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"he's_after_me!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"foundfoe_re"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 0.5f,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.75f,
                            FloodSkipFraction = 0.75f,
                            SkipFraction = 0.75f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"on_my_way!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 2,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_incmn"),
                            ParentIndex = 109,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 2,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"incoming!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_incmn_grnd"),
                            ParentIndex = 110,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 5,
                            Weight = 4f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"grenade!!!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_incmn_fldbm"),
                            ParentIndex = 109,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 2,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"it's_gonna_pop!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_incmn_vclbm"),
                            ParentIndex = 109,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 2,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"it's_gonna_blow!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_vcl"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 150,
                            Weight = 2,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_trrt"),
                            ParentIndex = 114,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 300,
                            Weight = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"they've_got_a_turret!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_vcl_bnsh"),
                            ParentIndex = 114,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 300,
                            Weight = 2,
                            PlayerSkipFraction = 0.35f,
                            FloodSkipFraction = 0.35f,
                            SkipFraction = 0.35f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"banshees_up_there!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_vcl_chpr"),
                            ParentIndex = 114,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 300,
                            Weight = 2,
                            PlayerSkipFraction = 0.35f,
                            FloodSkipFraction = 0.35f,
                            SkipFraction = 0.35f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"choppers!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_vcl_ghst"),
                            ParentIndex = 114,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 300,
                            Weight = 2,
                            PlayerSkipFraction = 0.35f,
                            FloodSkipFraction = 0.35f,
                            SkipFraction = 0.35f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"ghosts!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_vcl_phntm"),
                            ParentIndex = 114,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 300,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"here_comes_a_dropship!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_vcl_wrth"),
                            ParentIndex = 114,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 300,
                            Weight = 3,
                            PlayerSkipFraction = 0.35f,
                            FloodSkipFraction = 0.35f,
                            SkipFraction = 0.35f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"they're_bringin_in_heavy_armor!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_chr"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 60,
                            Weight = 2,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_stlth"),
                            ParentIndex = 121,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 300,
                            Weight = 2,
                            PlayerSkipFraction = 0.2f,
                            FloodSkipFraction = 0.2f,
                            SkipFraction = 0.2f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"stealth_camo!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_chr_bggr"),
                            ParentIndex = 121,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 300,
                            Weight = 2,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"buggers!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_chr_hntr"),
                            ParentIndex = 121,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 300,
                            Weight = 3,
                            SampleLine = CacheContext.StringTable.GetStringId($@"hunters!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_scrb"),
                            ParentIndex = 121,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 300,
                            Weight = 4f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"scarab!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_flood"),
                            ParentIndex = 121,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 600,
                            RepeatDelay = 120,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 1,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 1,
                            SkipFraction = 1,
                            SampleLine = CacheContext.StringTable.GetStringId($@"flood!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_swarm"),
                            ParentIndex = 121,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 600,
                            RepeatDelay = 120,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.6f,
                            PlayerSkipFraction = 0.6f,
                            FloodSkipFraction = 0.6f,
                            SkipFraction = 0.6f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"a_swarm!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_pureforms"),
                            ParentIndex = 121,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 600,
                            RepeatDelay = 120,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.6f,
                            PlayerSkipFraction = 0.6f,
                            FloodSkipFraction = 0.6f,
                            SkipFraction = 0.6f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"pureforms!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_weapon"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 60,
                            Weight = 2,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_wpn_snpr"),
                            ParentIndex = 129,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 150,
                            Weight = 2,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"sniper!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_wpn_hmmr"),
                            ParentIndex = 129,
                            Priority = VocalizationPriority.Respond,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 150,
                            Weight = 2,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"he's_got_a_hammer!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_behavior"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 60,
                            Weight = 2,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_brsrk"),
                            ParentIndex = 132,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 150,
                            Weight = 3,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"he's_gone_berserk!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_stlth_again"),
                            ParentIndex = 132,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 150,
                            Weight = 3,
                            PlayerSkipFraction = 0.2f,
                            FloodSkipFraction = 0.2f,
                            SkipFraction = 0.2f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"he's_going_stealth_again!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_trrt_dply"),
                            ParentIndex = 132,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 150,
                            Weight = 3,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"he's_deploying_a_turret!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"warn_fldreanimate"),
                            ParentIndex = 132,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 150,
                            Weight = 2,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"he's_getting_up!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"rmd"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 2,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"still_a_problem!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"rmd_plr_arb"),
                            ParentIndex = 137,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 60,
                            Weight = 3,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"someone_take_out_the_arbiter!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"rmd_plr_mc"),
                            ParentIndex = 137,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 60,
                            Weight = 3,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"someone_take_out_the_demon!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"rmd_scrb"),
                            ParentIndex = 137,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 60,
                            Weight = 2,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"someond_take_out_that_scarab!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"rmd_stlth"),
                            ParentIndex = 137,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 60,
                            Weight = 2,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"someone_take_out_that_stealth!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"rmd_wpn_snpr"),
                            ParentIndex = 137,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 60,
                            Weight = 2,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"somebody_take_out_that_sniper!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"rmd_wpn_hmmr"),
                            ParentIndex = 137,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 60,
                            Weight = 2,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"someone_take_ouf_that_hammer!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"rmd_trrt"),
                            ParentIndex = 137,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 60,
                            Weight = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"take_out_that_damn_turret!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"rmd_vcl_bnsh"),
                            ParentIndex = 137,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 60,
                            Weight = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"need_to_nail_that_banshee!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"rmd_vcl_chpr"),
                            ParentIndex = 137,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 60,
                            Weight = 2,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"someone_take_out_that_chopper!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"rmd_vcl_ghst"),
                            ParentIndex = 137,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 60,
                            Weight = 2,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"someone_kill_that_ghost!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"rmd_vcl_phntm"),
                            ParentIndex = 137,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 60,
                            Weight = 0.5f,
                            PlayerSkipFraction = 0.75f,
                            FloodSkipFraction = 0.75f,
                            SkipFraction = 0.75f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"take_down_that_phantom!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"rmd_vcl_wrth"),
                            ParentIndex = 137,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 60,
                            Weight = 3,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"take_out_that_wraith!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"dwn"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.75f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 2,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"dwn_scrb"),
                            ParentIndex = 150,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.75f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 60,
                            Weight = 4f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"scarab_down!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"dwn_vcl_bnsh"),
                            ParentIndex = 150,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.75f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 60,
                            Weight = 2,
                            PlayerSkipFraction = 0.75f,
                            FloodSkipFraction = 0.75f,
                            SkipFraction = 0.75f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"banshee_down!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"dwn_vcl_chpr"),
                            ParentIndex = 150,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.75f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 60,
                            Weight = 2,
                            PlayerSkipFraction = 0.75f,
                            FloodSkipFraction = 0.75f,
                            SkipFraction = 0.75f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"chopper_down!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"dwn_vcl_ghst"),
                            ParentIndex = 150,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.75f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 60,
                            Weight = 2,
                            PlayerSkipFraction = 0.75f,
                            FloodSkipFraction = 0.75f,
                            SkipFraction = 0.75f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"ghost_is_down!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"dwn_vcl_wrth"),
                            ParentIndex = 150,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.75f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 60,
                            Weight = 3,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"wraith_is_down!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"dwn_wpn_snpr"),
                            ParentIndex = 150,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.75f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 60,
                            Weight = 1f,
                            PlayerSkipFraction = 0.75f,
                            FloodSkipFraction = 0.75f,
                            SkipFraction = 0.75f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"sniper_down!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"lst_cntct"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 0.5f,
                            PlayerSpeakerSkipFraction = 0.4f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.65f,
                            SkipFraction = 0.65f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"lost_contact!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"srch_pinned"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 0.5f,
                            PlayerSpeakerSkipFraction = 0.4f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.65f,
                            SkipFraction = 0.65f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"he's_pinned_down!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"invsgt"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"i'll_flush_him_out!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"invsgt_fail"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"he's_not_here!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ask_invsgt_fail"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"is_he_there?"),
                            Responses = new List<AiVocalizationResponse>
                            {
                                new AiVocalizationResponse
                                {
                                    VocalizationName = CacheContext.StringTable.GetStringId($@"invsgt_fail"),
                                    VocalizationIndex = 160,
                                    ResponseType = AiVocalizationResponseType.Listener,
                                    DialogueIndexImport = -1,
                                },
                            },
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"prst"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"i'm_going_to_look_for_him!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"prst_fail"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"he's_not_over_here!"),
                            Responses = new List<AiVocalizationResponse>
                            {
                                new AiVocalizationResponse
                                {
                                    VocalizationName = CacheContext.StringTable.GetStringId($@"ordr_prst_keeplooking"),
                                    VocalizationIndex = 197,
                                    ResponseType = AiVocalizationResponseType.Leader,
                                    DialogueIndexImport = -1,
                                },
                            },
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ask_prst_fail"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"is_he_over_there?"),
                            Responses = new List<AiVocalizationResponse>
                            {
                                new AiVocalizationResponse
                                {
                                    VocalizationName = CacheContext.StringTable.GetStringId($@"prst_fail"),
                                    VocalizationIndex = 163,
                                    ResponseType = AiVocalizationResponseType.Listener,
                                    DialogueIndexImport = -1,
                                },
                            },
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"stayback"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"hold_here!"),
                            Responses = new List<AiVocalizationResponse>
                            {
                                new AiVocalizationResponse
                                {
                                    VocalizationName = CacheContext.StringTable.GetStringId($@"ordr_keepwatch"),
                                    VocalizationIndex = 199,
                                    ResponseType = AiVocalizationResponseType.Leader,
                                    DialogueIndexImport = -1,
                                },
                            },
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"stayback_agg"),
                            ParentIndex = 165,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"let_them_run!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"stayback_tim"),
                            ParentIndex = 165,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"he's_drawing_us_into_a_trap!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"join_stayback"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"we_should_hold_here!"),
                            Responses = new List<AiVocalizationResponse>
                            {
                                new AiVocalizationResponse
                                {
                                    VocalizationName = CacheContext.StringTable.GetStringId($@"ordr_keepwatch"),
                                    VocalizationIndex = 199,
                                    ResponseType = AiVocalizationResponseType.Leader,
                                    DialogueIndexImport = -1,
                                },
                            },
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"srchend"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 1,
                            SampleLine = CacheContext.StringTable.GetStringId($"\"forget_it"),
                            Responses = new List<AiVocalizationResponse>
                            {
                                new AiVocalizationResponse
                                {
                                    VocalizationName = CacheContext.StringTable.GetStringId($@"ordr_keepwatch"),
                                    VocalizationIndex = 199,
                                    ResponseType = AiVocalizationResponseType.Leader,
                                    DialogueIndexImport = -1,
                                },
                            },
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"new_order"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 2,
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"neworder_flanking"),
                            ParentIndex = 170,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 45,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"let's_flank_them!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"newordr_advance"),
                            ParentIndex = 170,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"move_up!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"newordr_arrival"),
                            ParentIndex = 170,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 45,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"regroup_marines!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"newordr_charge"),
                            ParentIndex = 170,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"okay_move_out_and_kick_ass!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"newordr_entervcl"),
                            ParentIndex = 170,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 2,
                            SampleLine = CacheContext.StringTable.GetStringId($@"okay_men_smoke_em_if_you_got_em!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"newordr_exitvcl"),
                            ParentIndex = 170,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 2,
                            SampleLine = CacheContext.StringTable.GetStringId($@"we've_lost_too_many_guys!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"newordr_fallback"),
                            ParentIndex = 170,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"okay_move_out_and_find_those_bastards!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"newordr_fllwplr"),
                            ParentIndex = 170,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 45,
                            Weight = 2,
                            SampleLine = CacheContext.StringTable.GetStringId($@"the_cavalry_has_arrived!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"newordr_leaveplr"),
                            ParentIndex = 170,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 45,
                            Weight = 2,
                            SampleLine = CacheContext.StringTable.GetStringId($@"we're_with_you_chief!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"newordr_moveon"),
                            ParentIndex = 170,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"move_on!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"newordr_retreat"),
                            ParentIndex = 170,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"reatreat!_retreat!_get_outta_here!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"newordr_support"),
                            ParentIndex = 170,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 45,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"we're_here_to_help!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"foe_orders"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 2,
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"foeordr_advance"),
                            ParentIndex = 183,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"they're_being_cautious!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"foeordr_charge"),
                            ParentIndex = 183,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"they're_advancing_on_us!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"foeordr_fallback"),
                            ParentIndex = 183,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"here_they_come!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"foeordr_flanking"),
                            ParentIndex = 183,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"they're_flanking_us!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"foeordr_retreat"),
                            ParentIndex = 183,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"careful_they're_after_us!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"foeordr_support"),
                            ParentIndex = 183,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 45,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"they've_got_backup!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ordr"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 10,
                            Weight = 2,
                            Responses = new List<AiVocalizationResponse>
                            {
                                new AiVocalizationResponse
                                {
                                    VocalizationName = CacheContext.StringTable.GetStringId($@"ordr_re"),
                                    VocalizationIndex = 202,
                                    ResponseType = AiVocalizationResponseType.Listener,
                                    DialogueIndexImport = -1,
                                },
                            },
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ordr_openfire"),
                            ParentIndex = 190,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 45,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.3f,
                            PlayerSkipFraction = 0.3f,
                            FloodSkipFraction = 0.3f,
                            SkipFraction = 0.3f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"open_fire!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ordr_grenade"),
                            ParentIndex = 190,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 10,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"throw_a_grenade!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ordr_grenade_all"),
                            ParentIndex = 190,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 10,
                            Weight = 4f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"everyone!_grenades!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ordr_pinned"),
                            ParentIndex = 190,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 10,
                            Weight = 2,
                            SampleLine = CacheContext.StringTable.GetStringId($@"keep_him_pinned_down!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ordr_stayback"),
                            ParentIndex = 190,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 10,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.35f,
                            PlayerSkipFraction = 0.35f,
                            FloodSkipFraction = 0.35f,
                            SkipFraction = 0.35f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"stay_close_don't_spread_out!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ordr_prst"),
                            ParentIndex = 190,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 10,
                            Weight = 2,
                            SampleLine = CacheContext.StringTable.GetStringId($@"spread_out!_find_him!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ordr_prst_keeplooking"),
                            ParentIndex = 190,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 10,
                            Weight = 2,
                            SampleLine = CacheContext.StringTable.GetStringId($@"keep_looking!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ordr_invsgt"),
                            ParentIndex = 190,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 10,
                            Weight = 2,
                            SampleLine = CacheContext.StringTable.GetStringId($@"see_if_he's_still_there!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ordr_keepwatch"),
                            ParentIndex = 190,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 10,
                            Weight = 2,
                            SampleLine = CacheContext.StringTable.GetStringId($@"keep_your_eyes_peeled!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ordr_keepwatch_agg"),
                            ParentIndex = 199,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 10,
                            Weight = 3,
                            SampleLine = CacheContext.StringTable.GetStringId($@"keep_watch_they_may_come_back!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ordr_keepwatch_tim"),
                            ParentIndex = 199,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 10,
                            Weight = 3,
                            SampleLine = CacheContext.StringTable.GetStringId($@"careful_we're_not_out_of_this_yet!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ordr_re"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"yes_sir!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"join"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 10,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"come_on!"),
                            Responses = new List<AiVocalizationResponse>
                            {
                                new AiVocalizationResponse
                                {
                                    VocalizationName = CacheContext.StringTable.GetStringId($@"join_re"),
                                    VocalizationIndex = 207,
                                    DialogueIndexImport = -1,
                                },
                            },
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"join_invsgt"),
                            ParentIndex = 203,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 10,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"let's_go_and_get_him!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"join_emrg"),
                            ParentIndex = 203,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 10,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"ready?"),
                            Responses = new List<AiVocalizationResponse>
                            {
                                new AiVocalizationResponse
                                {
                                    VocalizationName = CacheContext.StringTable.GetStringId($@"join_emrg_re"),
                                    VocalizationIndex = 208,
                                    ResponseType = AiVocalizationResponseType.Listener,
                                    DialogueIndexImport = -1,
                                },
                            },
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"join_prst"),
                            ParentIndex = 203,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 10,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"let's_spread_out_and_find_him."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"join_re"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 10,
                            Weight = 2,
                            SampleLine = CacheContext.StringTable.GetStringId($@"alright!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"join_emrg_re"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 10,
                            Weight = 2,
                            SampleLine = CacheContext.StringTable.GetStringId($@"let's_get_out_there!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"cvr"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.3f,
                            PlayerSkipFraction = 0.3f,
                            FloodSkipFraction = 0.3f,
                            SkipFraction = 0.3f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"cover_me!"),
                            Responses = new List<AiVocalizationResponse>
                            {
                                new AiVocalizationResponse
                                {
                                    VocalizationName = CacheContext.StringTable.GetStringId($@"cvr_re"),
                                    VocalizationIndex = 211,
                                    ResponseType = AiVocalizationResponseType.Listener,
                                    DialogueIndexImport = -1,
                                },
                            },
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"cvr_invsgt"),
                            ParentIndex = 209,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.3f,
                            PlayerSkipFraction = 0.3f,
                            FloodSkipFraction = 0.3f,
                            SkipFraction = 0.3f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"cover_me!_i'm_going_in!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"cvr_re"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 10,
                            Weight = 4f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"i_got_your_back!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"prs"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Combat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"good_job!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"prs_plr_gdgrnd"),
                            ParentIndex = 212,
                            Priority = VocalizationPriority.Combat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 20,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"good_grenade!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"prs_plr_kll"),
                            ParentIndex = 212,
                            Priority = VocalizationPriority.Combat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.8f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.8f,
                            SkipFraction = 0.8f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"that_got_'em!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"prs_plr_kll_blt"),
                            ParentIndex = 214,
                            Priority = VocalizationPriority.Combat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 1,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 1,
                            SkipFraction = 1,
                            SampleLine = CacheContext.StringTable.GetStringId($@"nice_shot!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"prs_plr_kll_mjr"),
                            ParentIndex = 214,
                            Priority = VocalizationPriority.Combat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"thank_god_you_were_here_to_take_that_guy_out!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"prs_plr_kll_vclbmp"),
                            ParentIndex = 214,
                            Priority = VocalizationPriority.Combat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            RepeatDelay = 10,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"roadkill!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"prs_plr_kll_wmelee"),
                            ParentIndex = 214,
                            Priority = VocalizationPriority.Combat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            RepeatDelay = 10,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.8f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.8f,
                            SkipFraction = 0.8f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"i_heard_that!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"prs_plr_arb"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 20,
                            RepeatDelay = 10,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"well_done_arbiter!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"prs_plr_mc"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 20,
                            RepeatDelay = 10,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"well_done_chief!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"prs_plr_kll_lots"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 3,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"he's_kicking_their_asses!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"prs_plr_sniping"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"nice_sniping!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"kllmytrgt"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.75f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 90,
                            RepeatDelay = 60f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.75f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.75f,
                            SkipFraction = 0.75f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"hey_that_one_was_mine!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"scld_plr_vclcrazy"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Act,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 30f,
                            RepeatDelay = 60f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"where'd_you_learn_to_drive_tijuana?!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"scld_plr_hrtme"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Act,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.15f,
                            NotificationDelay = 2.5f,
                            RepeatDelay = 5,
                            Weight = 1f,
                            PlayerSkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"hey_it's_me!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"scld_plr_wldgrnd"),
                            ParentIndex = 225,
                            Priority = VocalizationPriority.Act,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.15f,
                            NotificationDelay = 2.5f,
                            RepeatDelay = 5,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"watch_where_you_throw_those_things!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"scld_plr_wldvcl"),
                            ParentIndex = 225,
                            Priority = VocalizationPriority.Act,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.15f,
                            NotificationDelay = 2.5f,
                            RepeatDelay = 5,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"you_hit_me!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"scld_plr_hrt_blt"),
                            ParentIndex = 225,
                            Priority = VocalizationPriority.Act,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.15f,
                            NotificationDelay = 2.5f,
                            RepeatDelay = 5,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"point_that_thing_somewhere_else!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"scld"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Act,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.75f,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 30f,
                            Weight = 0.75f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"hey_cut_it_out!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"scld_plr_kllally"),
                            ParentIndex = 229,
                            Priority = VocalizationPriority.Act,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.75f,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 30f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"he_was_on_our_side!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"scld_plr_arb"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.75f,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 30f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.7f,
                            PlayerSkipFraction = 0.7f,
                            FloodSkipFraction = 0.7f,
                            SkipFraction = 0.7f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"nice_going_arbiturd!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"scld_plr_mc"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.75f,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 30f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.7f,
                            PlayerSkipFraction = 0.7f,
                            FloodSkipFraction = 0.7f,
                            SkipFraction = 0.7f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"nice_going_masterdork!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"scld_plr_blocking"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"get_out_of_the_way!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"chr"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.75f,
                            PreVocalizationDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"woohoo!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"chr_deadmc"),
                            ParentIndex = 234,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            PreVocalizationDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 4f,
                            PlayerSpeakerSkipFraction = 0.35f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.35f,
                            SkipFraction = 0.35f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"so_much_for_the_demon!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"chr_deadarb"),
                            ParentIndex = 234,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            PreVocalizationDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 4f,
                            PlayerSpeakerSkipFraction = 0.35f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.35f,
                            SkipFraction = 0.35f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"we_killed_the_dervish!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"chr_vcljmp"),
                            ParentIndex = 234,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.75f,
                            PreVocalizationDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"vehicle_woohoo!!!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"chr_kllfoe"),
                            ParentIndex = 234,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            PreVocalizationDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"i_killed_one!"),
                            Responses = new List<AiVocalizationResponse>
                            {
                                new AiVocalizationResponse
                                {
                                    VocalizationName = CacheContext.StringTable.GetStringId($@"prs"),
                                    VocalizationIndex = 212,
                                    DialogueIndexImport = -1,
                                },
                            },
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"chr_kllfoe_blt"),
                            ParentIndex = 238,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            PreVocalizationDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"i_shot_one!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"chr_kllfoe_mjrfoe"),
                            ParentIndex = 238,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.25f,
                            PreVocalizationDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"i_can't_believe_i_killed_that_one!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"chr_kllfoe_vclbmp"),
                            ParentIndex = 238,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.25f,
                            PreVocalizationDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"eat_grill!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"chr_kllfoe_stkplsm"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Act,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            Weight = 5,
                            SampleLine = CacheContext.StringTable.GetStringId($@"stuck_him!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"lmnt"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Combat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.25f,
                            NotificationDelay = 2.5f,
                            PostVocalizationDelay = 30f,
                            Weight = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"nooo!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"lmnt_deadally"),
                            ParentIndex = 243,
                            Priority = VocalizationPriority.Combat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.25f,
                            NotificationDelay = 2.5f,
                            PostVocalizationDelay = 60,
                            RepeatDelay = 60f,
                            Weight = 0.5f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"man_down!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"lmnt_deadplr_arb"),
                            ParentIndex = 243,
                            Priority = VocalizationPriority.Combat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 10,
                            RepeatDelay = 120,
                            Weight = 4f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"we_lost_the_arbiter!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"lmnt_deadplr_mc"),
                            ParentIndex = 243,
                            Priority = VocalizationPriority.Combat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 10,
                            RepeatDelay = 120,
                            Weight = 4f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"we_lost_the_chief!!!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"strk"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            PreVocalizationDelay = 0.25f,
                            NotificationDelay = 1,
                            PostVocalizationDelay = 6,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.2f,
                            PlayerSkipFraction = 0.8f,
                            FloodSkipFraction = 0.2f,
                            SkipFraction = 0.2f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"take_it!"),
                            Responses = new List<AiVocalizationResponse>
                            {
                                new AiVocalizationResponse
                                {
                                    Flags = AiVocalizationResponseFlags.TriggerResponse,
                                    VocalizationIndex = -1,
                                    ResponseType = AiVocalizationResponseType.Listener,
                                    DialogueIndexImport = 40,
                                },
                                new AiVocalizationResponse
                                {
                                    Flags = AiVocalizationResponseFlags.TriggerResponse,
                                    VocalizationIndex = -1,
                                    ResponseType = AiVocalizationResponseType.Listener,
                                    DialogueIndexImport = 85,
                                },
                            },
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"strk_grnd"),
                            ParentIndex = 247,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            PreVocalizationDelay = 0.25f,
                            NotificationDelay = 1,
                            PostVocalizationDelay = 6,
                            Weight = 4f,
                            PlayerSkipFraction = 0.6f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"frag_out!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"strk_grnd_uncvr"),
                            ParentIndex = 248,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            PreVocalizationDelay = 0.25f,
                            NotificationDelay = 1,
                            PostVocalizationDelay = 6,
                            Weight = 4f,
                            PlayerSkipFraction = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"this'll_flush_'em_out!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"strk_mjrfoe_arb"),
                            ParentIndex = 247,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            PreVocalizationDelay = 0.25f,
                            NotificationDelay = 1,
                            PostVocalizationDelay = 6,
                            RepeatDelay = 30,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.6f,
                            PlayerSkipFraction = 0.7f,
                            FloodSkipFraction = 0.6f,
                            SkipFraction = 0.6f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"take_this_arbiter!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"strk_mjrfoe_mc"),
                            ParentIndex = 247,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            PreVocalizationDelay = 0.25f,
                            NotificationDelay = 1,
                            PostVocalizationDelay = 6,
                            RepeatDelay = 30,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.6f,
                            PlayerSkipFraction = 0.7f,
                            FloodSkipFraction = 0.6f,
                            SkipFraction = 0.6f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"take_this_demon!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"strk_snpr"),
                            ParentIndex = 247,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            PreVocalizationDelay = 0.25f,
                            NotificationDelay = 1,
                            PostVocalizationDelay = 6,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"headshot!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"strk_vcl_gnr"),
                            ParentIndex = 247,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            PreVocalizationDelay = 0.25f,
                            NotificationDelay = 1,
                            PostVocalizationDelay = 6,
                            RepeatDelay = 30,
                            Weight = 3,
                            PlayerSpeakerSkipFraction = 0.2f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.2f,
                            SkipFraction = 0.2f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"you_set_'em_up_i'll_knock_'em_down!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"thrtn"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.3f,
                            PlayerSkipFraction = 0.85f,
                            FloodSkipFraction = 0.3f,
                            SkipFraction = 0.3f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"i'm_gonna_kill_you!"),
                            Responses = new List<AiVocalizationResponse>
                            {
                                new AiVocalizationResponse
                                {
                                    VocalizationName = CacheContext.StringTable.GetStringId($@"thrtn_foe_re"),
                                    VocalizationIndex = 258,
                                    ResponseType = AiVocalizationResponseType.Enemy,
                                    DialogueIndexImport = -1,
                                },
                                new AiVocalizationResponse
                                {
                                    Flags = AiVocalizationResponseFlags.TriggerResponse,
                                    VocalizationIndex = -1,
                                    ResponseType = AiVocalizationResponseType.Listener,
                                    DialogueIndexImport = 40,
                                },
                            },
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"thrtn_mjrfoe"),
                            ParentIndex = 254,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.3f,
                            PlayerSkipFraction = 0.85f,
                            FloodSkipFraction = 0.3f,
                            SkipFraction = 0.3f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"you_think_you're_so_tought!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"thrtn_mjrfoe_arb"),
                            ParentIndex = 255,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 15,
                            RepeatDelay = 120,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.6f,
                            PlayerSkipFraction = 0.85f,
                            FloodSkipFraction = 0.6f,
                            SkipFraction = 0.6f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"arbiter_you're_mine!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"thrtn_mjrfoe_mc"),
                            ParentIndex = 255,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 15,
                            RepeatDelay = 120,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.6f,
                            PlayerSkipFraction = 0.85f,
                            FloodSkipFraction = 0.6f,
                            SkipFraction = 0.6f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"i'll_show_you_demon!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"thrtn_foe_re"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.75f,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 30f,
                            Weight = 0.5f,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.75f,
                            FloodSkipFraction = 0.85f,
                            SkipFraction = 0.85f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"is_that_supposed_to_scare_me?"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"tnt"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.5f,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.2f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.2f,
                            SkipFraction = 0.2f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"is_that_all_you_got?!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"tnt_mjrfoe"),
                            ParentIndex = 259,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.5f,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.2f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.2f,
                            SkipFraction = 0.2f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"not_so_tough!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"tnt_mjrfoe_arb"),
                            ParentIndex = 260,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.5f,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 15,
                            RepeatDelay = 120,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.4f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.4f,
                            SkipFraction = 0.4f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"the_prophets_chose_you?!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"tnt_mjrfoe_mc"),
                            ParentIndex = 260,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1.5f,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 15,
                            RepeatDelay = 120,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.4f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.4f,
                            SkipFraction = 0.4f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"you_will_die_demon!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"tnt_invsgt_stayback"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 2.5f,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.3f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.3f,
                            SkipFraction = 0.3f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"come_back_coward!"),
                            Responses = new List<AiVocalizationResponse>
                            {
                                new AiVocalizationResponse
                                {
                                    VocalizationName = CacheContext.StringTable.GetStringId($@"tnt_re"),
                                    VocalizationIndex = 264,
                                    DialogueIndexImport = -1,
                                },
                                new AiVocalizationResponse
                                {
                                    Flags = AiVocalizationResponseFlags.TriggerResponse,
                                    VocalizationIndex = -1,
                                    ResponseType = AiVocalizationResponseType.Listener,
                                    DialogueIndexImport = 86,
                                },
                                new AiVocalizationResponse
                                {
                                    Flags = AiVocalizationResponseFlags.TriggerResponse,
                                    VocalizationIndex = -1,
                                    ResponseType = AiVocalizationResponseType.Listener,
                                    DialogueIndexImport = 85,
                                },
                            },
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"tnt_re"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 30f,
                            Weight = 0.5f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.75f,
                            SkipFraction = 0.75f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"don't_make_'em_mad!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"crs"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.7f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"curse_you!"),
                            Responses = new List<AiVocalizationResponse>
                            {
                                new AiVocalizationResponse
                                {
                                    Flags = AiVocalizationResponseFlags.TriggerResponse,
                                    VocalizationIndex = -1,
                                    ResponseType = AiVocalizationResponseType.Listener,
                                    DialogueIndexImport = 86,
                                },
                            },
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"crs_mjrfoe"),
                            ParentIndex = 265,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.4f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.4f,
                            SkipFraction = 0.4f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"you_ain't_that_tought!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"crs_mjrfoe_arb"),
                            ParentIndex = 266,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 15,
                            RepeatDelay = 120,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.6f,
                            PlayerSkipFraction = 0.7f,
                            FloodSkipFraction = 0.6f,
                            SkipFraction = 0.6f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"damn_you_dervish!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"crs_mjrfoe_mc"),
                            ParentIndex = 266,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 15,
                            RepeatDelay = 120,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.6f,
                            PlayerSkipFraction = 0.7f,
                            FloodSkipFraction = 0.6f,
                            SkipFraction = 0.6f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"a_curse_on_you_demon!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"crs_betrayingplr_arb"),
                            ParentIndex = 265,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 15,
                            RepeatDelay = 120,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"damn_you_betraying_arbiter!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"crs_betrayingplr_mc"),
                            ParentIndex = 265,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 5,
                            PostVocalizationDelay = 15,
                            RepeatDelay = 120,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"damn_you_betraying_chief!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"pld"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Involuntary,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 5,
                            Weight = 0.5f,
                            PlayerSpeakerSkipFraction = 0.8f,
                            PlayerSkipFraction = 0.2f,
                            FloodSkipFraction = 0.8f,
                            SkipFraction = 0.8f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"don't_hurt_me!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"pld_mjrfoe"),
                            ParentIndex = 271,
                            Priority = VocalizationPriority.Involuntary,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 5,
                            Weight = 0.5f,
                            PlayerSpeakerSkipFraction = 0.8f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.8f,
                            SkipFraction = 0.8f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"not_fair!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"pld_mjrfoe_arb"),
                            ParentIndex = 272,
                            Priority = VocalizationPriority.Involuntary,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 5,
                            RepeatDelay = 120,
                            Weight = 0.5f,
                            PlayerSpeakerSkipFraction = 0.9f,
                            PlayerSkipFraction = 0.9f,
                            FloodSkipFraction = 0.9f,
                            SkipFraction = 0.9f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"don't_hurt_me_arbiter!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"pld_mjrfoe_mc"),
                            ParentIndex = 272,
                            Priority = VocalizationPriority.Involuntary,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 5,
                            RepeatDelay = 120,
                            Weight = 0.5f,
                            PlayerSpeakerSkipFraction = 0.9f,
                            PlayerSkipFraction = 0.9f,
                            FloodSkipFraction = 0.9f,
                            SkipFraction = 0.9f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"don't_hurt_me_mc!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"whn"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.75f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            RepeatDelay = 30,
                            Weight = 0.5f,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"that_hurts!"),
                            Responses = new List<AiVocalizationResponse>
                            {
                                new AiVocalizationResponse
                                {
                                    VocalizationName = CacheContext.StringTable.GetStringId($@"whn_re"),
                                    VocalizationIndex = 277,
                                    DialogueIndexImport = -1,
                                },
                            },
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"whn_hrtblt"),
                            ParentIndex = 275,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.75f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            RepeatDelay = 30,
                            Weight = 0.5f,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"i've_been_shot!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"whn_re"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 30f,
                            RepeatDelay = 30,
                            Weight = 0.5f,
                            PlayerSpeakerSkipFraction = 0.75f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.75f,
                            SkipFraction = 0.75f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"stop_whining!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"rtrt"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"i'm_out_of_here!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"rtrt_ldrdead"),
                            ParentIndex = 278,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 10,
                            RepeatDelay = 10,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"leader_dead_run_away!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"endcmbt"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 3,
                            PostVocalizationDelay = 60,
                            RepeatDelay = 60f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"is_that_it?"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"pstcmbt"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 3,
                            PostVocalizationDelay = 60,
                            RepeatDelay = 60f,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"we_win!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"pstcmbt_brt"),
                            ParentIndex = 281,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 3,
                            PostVocalizationDelay = 60,
                            RepeatDelay = 60f,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"we_sure_took_those_brutes"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"pstcmbt_fld"),
                            ParentIndex = 281,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 3,
                            PostVocalizationDelay = 60,
                            RepeatDelay = 60f,
                            Weight = 2,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 0.5f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"i_hate_fighting_flood."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"pstcmbt_ez"),
                            ParentIndex = 281,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 3,
                            PostVocalizationDelay = 60,
                            RepeatDelay = 60f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.5f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.5f,
                            SkipFraction = 0.5f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"we_kicked_their_asses!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"pstcmbt_hrd"),
                            ParentIndex = 281,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 3,
                            PostVocalizationDelay = 60,
                            RepeatDelay = 60f,
                            Weight = 4f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"they_almost_kicked_our_asses!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"pstcmbt_agg"),
                            ParentIndex = 281,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 3,
                            PostVocalizationDelay = 60,
                            RepeatDelay = 60f,
                            Weight = 4f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 1f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"they_never_knew_what_hit_em!"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"pstcmbt_tim"),
                            ParentIndex = 281,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 1,
                            NotificationDelay = 3,
                            PostVocalizationDelay = 60,
                            RepeatDelay = 60f,
                            Weight = 1f,
                            PlayerSpeakerSkipFraction = 0.25f,
                            PlayerSkipFraction = 0.25f,
                            FloodSkipFraction = 0.25f,
                            SkipFraction = 0.25f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"man_i_thought_we_were_screwed."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"status"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"how_you_doin'?"),
                            Responses = new List<AiVocalizationResponse>
                            {
                                new AiVocalizationResponse
                                {
                                    VocalizationName = CacheContext.StringTable.GetStringId($@"status_re"),
                                    VocalizationIndex = 289,
                                    ResponseType = AiVocalizationResponseType.Listener,
                                    DialogueIndexImport = -1,
                                },
                            },
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"status_re"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            Weight = 4f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"i_need_ammo."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ask_chkallybdy"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"did_he_make_it?"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ask_chkallybdyf"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"did_she_make_it?"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"chckallybdy"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"he's_gone."),
                            Responses = new List<AiVocalizationResponse>
                            {
                                new AiVocalizationResponse
                                {
                                    VocalizationName = CacheContext.StringTable.GetStringId($@"regret"),
                                    VocalizationIndex = 299,
                                    DialogueIndexImport = -1,
                                },
                            },
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"chckallybdyf"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"she's_gone..."),
                            Responses = new List<AiVocalizationResponse>
                            {
                                new AiVocalizationResponse
                                {
                                    VocalizationName = CacheContext.StringTable.GetStringId($@"regret"),
                                    VocalizationIndex = 299,
                                    DialogueIndexImport = -1,
                                },
                            },
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"tchallybdy"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"i'll_miss_you_buddy."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"ordr_chkfoebdy"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"check_that_body."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"chkfoebdy"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 3f,
                            Weight = 2f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"yep_he's_dead!"),
                            Responses = new List<AiVocalizationResponse>
                            {
                                new AiVocalizationResponse
                                {
                                    VocalizationName = CacheContext.StringTable.GetStringId($@"approve"),
                                    VocalizationIndex = 298,
                                    DialogueIndexImport = -1,
                                },
                            },
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"shotfoebdy"),
                            ParentIndex = 296,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 3f,
                            Weight = 2f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"how's_it_feel_to_be_dead!?"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"approve"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15f,
                            Weight = 4f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"good"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"regret"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 0.25f,
                            NotificationDelay = 0.5f,
                            PostVocalizationDelay = 15,
                            Weight = 4f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"too_bad."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"captured"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"this_sucks_?"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"doze"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"zzzzz?."),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"injured"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"uhh_aagh_cough_cough"),
                        },
                        new VocalizationDefinition
                        {
                            Vocalization = CacheContext.StringTable.GetStringId($@"peeing"),
                            ParentIndex = -1,
                            Priority = VocalizationPriority.Postcombat,
                            MaxCombatStatus = AiCombatStatus.Dangerous,
                            ProxyDialogueIndex = -1,
                            AllowableQueueDelay = 5f,
                            NotificationDelay = 0.5f,
                            Weight = 1f,
                            SampleLine = CacheContext.StringTable.GetStringId($@"pssssssss_?."),
                        },
                    },
                    Patterns = new List<VocalizationPattern>
                    {
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 238,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"chr_kllfoe"),
                            SpeakerType = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 239,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"chr_kllfoe_blt"),
                            SpeakerType = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            DamageType = VocalizationPattern.DamageEnum.Bullet,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 241,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"chr_kllfoe_vclbmp"),
                            SpeakerType = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            DamageType = VocalizationPattern.DamageEnum.Vehicle,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 240,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"chr_kllfoe_mjrfoe"),
                            SpeakerType = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SubjectType = VocalizationPattern.DialogueObjectTypesEnum.MajorlyScary,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 235,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"chr_deadmc"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SubjectType = VocalizationPattern.DialogueObjectTypesEnum.PlayerMasterchief,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 236,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"chr_deadarb"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SubjectType = VocalizationPattern.DialogueObjectTypesEnum.PlayerDervish,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 151,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"dwn_scrb"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SubjectAiTypeName = CacheContext.StringTable.GetStringId($@"scarab"),
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 152,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"dwn_vcl_bnsh"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SubjectType = VocalizationPattern.DialogueObjectTypesEnum.Driver,
                            SubjectAiTypeName = CacheContext.StringTable.GetStringId($@"banshee"),
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 153,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"dwn_vcl_chpr"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SubjectType = VocalizationPattern.DialogueObjectTypesEnum.Driver,
                            SubjectAiTypeName = CacheContext.StringTable.GetStringId($@"chopper"),
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 154,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"dwn_vcl_ghst"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SubjectType = VocalizationPattern.DialogueObjectTypesEnum.Driver,
                            SubjectAiTypeName = CacheContext.StringTable.GetStringId($@"ghost"),
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 155,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"dwn_vcl_wrth"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SubjectType = VocalizationPattern.DialogueObjectTypesEnum.LastManInVehicle,
                            SubjectAiTypeName = CacheContext.StringTable.GetStringId($@"wraith"),
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 156,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"dwn_wpn_snpr"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SubjectAiTypeName = CacheContext.StringTable.GetStringId($@"sniper"),
                        },
                        new VocalizationPattern
                        {
                            DamageType = VocalizationPattern.DamageEnum.Bullet,
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 215,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"prs_plr_kll_blt"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SpacialRelation = VocalizationPattern.SpatialRelationEnum.Far,
                        },
                        new VocalizationPattern
                        {
                            DamageType = VocalizationPattern.DamageEnum.Vehicle,
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 217,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"prs_plr_kll_vclbmp"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,                            
                        },
                        new VocalizationPattern
                        {
                            DamageType = VocalizationPattern.DamageEnum.Melee,
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 218,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"prs_plr_kll_wmelee"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,                            
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 216,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"prs_plr_kll_mjr"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SubjectType = VocalizationPattern.DialogueObjectTypesEnum.MajorlyScary,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 222,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"prs_plr_sniping"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            CauseAiTypeName = CacheContext.StringTable.GetStringId($@"sniper"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SpacialRelation = VocalizationPattern.SpatialRelationEnum.Far,
                            DamageType = VocalizationPattern.DamageEnum.Bullet,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 213,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"prs_plr_gdgrnd"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            DamageType = VocalizationPattern.DamageEnum.Grenade,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 223,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"kllmytrgt"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.SubjectVisible | PatternFlags.SubjectIsSpeakerSTarget | PatternFlags.CauseIsInfantry,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SpacialRelation = VocalizationPattern.SpatialRelationEnum.Few,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 230,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"scld_plr_kllally"),
                            SpeakerType = SpeakerTypeEnum.Friend,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            Flags = PatternFlags.CauseVisible,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SubjectType = VocalizationPattern.DialogueObjectTypesEnum.Actor,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 244,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"lmnt_deadally"),
                            SpeakerType = SpeakerTypeEnum.JointLeader,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SubjectType = VocalizationPattern.DialogueObjectTypesEnum.Actor,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 245,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"lmnt_deadplr_arb"),
                            SpeakerType = SpeakerTypeEnum.Friend,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SubjectType = VocalizationPattern.DialogueObjectTypesEnum.PlayerDervish,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Death,
                            VocalizationIndex = 246,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"lmnt_deadplr_mc"),
                            SpeakerType = SpeakerTypeEnum.Friend,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SubjectType = VocalizationPattern.DialogueObjectTypesEnum.PlayerMasterchief,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DeathHeadshot,
                            VocalizationIndex = 275,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"whn"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Flags = PatternFlags.CauseIsPlayer,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DeathHeadshot,
                            VocalizationIndex = 276,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"whn_hrtblt"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Flags = PatternFlags.CauseIsPlayer,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            DamageType = VocalizationPattern.DamageEnum.Bullet,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DeathHeadshot,
                            VocalizationIndex = 225,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"scld_plr_hrtme"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DeathHeadshot,
                            VocalizationIndex = 228,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"scld_plr_hrt_blt"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            DamageType = VocalizationPattern.DamageEnum.Bullet,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DeathHeadshot,
                            VocalizationIndex = 226,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"scld_plr_wldgrnd"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            DamageType = VocalizationPattern.DamageEnum.Grenade,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DeathHeadshot,
                            VocalizationIndex = 227,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"scld_plr_wldvcl"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            DamageType = VocalizationPattern.DamageEnum.Vehicle,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DeathHeadshot,
                            VocalizationIndex = 40,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"panic_onfire"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            DamageType = VocalizationPattern.DamageEnum.Flame,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.SightedFirst,
                            VocalizationIndex = 93,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"hrdfoe"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.ActorOrPlayer,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.ReadyRocketLauncher,
                            VocalizationIndex = 37,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"srprs"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Announce,
                            VocalizationIndex = 102,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"morefoe"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.ActorOrPlayer,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.SightedNew,
                            VocalizationIndex = 94,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"seefoe"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.ActorOrPlayer,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.SightedNew,
                            VocalizationIndex = 100,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"seefoe_agg"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.ActorOrPlayer,
                            Attitude = VocalizationPattern.StyleAttitudeEnum.Aggressive,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.SightedNew,
                            VocalizationIndex = 101,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"seefoe_tim"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.ActorOrPlayer,
                            Attitude = VocalizationPattern.StyleAttitudeEnum.Timid,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.SightedNew,
                            VocalizationIndex = 99,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"seefoe_downthere"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.ActorOrPlayer,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SpacialRelation = VocalizationPattern.SpatialRelationEnum.Below,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.SightedNew,
                            VocalizationIndex = 98,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"seefoe_upthere"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.ActorOrPlayer,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SpacialRelation = VocalizationPattern.SpatialRelationEnum.Above,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DamageWeakspot,
                            VocalizationIndex = 111,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_incmn_grnd"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Grenade,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DamageWeakspot,
                            VocalizationIndex = 110,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_incmn"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Projectile,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DamageWeakspot,
                            VocalizationIndex = 115,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_trrt"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.UnitInTurret,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DamageWeakspot,
                            VocalizationIndex = 118,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_vcl_ghst"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Driver,
                            CauseAiTypeName = CacheContext.StringTable.GetStringId($@"ghost"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DamageWeakspot,
                            VocalizationIndex = 116,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_vcl_bnsh"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Driver,
                            CauseAiTypeName = CacheContext.StringTable.GetStringId($@"banshee"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DamageWeakspot,
                            VocalizationIndex = 120,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_vcl_wrth"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Driver,
                            CauseAiTypeName = CacheContext.StringTable.GetStringId($@"wraith"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DamageWeakspot,
                            VocalizationIndex = 119,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_vcl_phntm"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Driver,
                            CauseAiTypeName = CacheContext.StringTable.GetStringId($@"phantom"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DamageWeakspot,
                            VocalizationIndex = 117,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_vcl_chpr"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Driver,
                            CauseAiTypeName = CacheContext.StringTable.GetStringId($@"chopper"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DamageWeakspot,
                            VocalizationIndex = 97,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"seefoe_mjr_mc"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerMasterchief,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DamageWeakspot,
                            VocalizationIndex = 96,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"seefoe_mjr_arb"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerDervish,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DamageWeakspot,
                            VocalizationIndex = 95,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"seefoe_mjr"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.MajorlyScary,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DamageWeakspot,
                            VocalizationIndex = 122,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_stlth"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Stealth,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DamageWeakspot,
                            VocalizationIndex = 125,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_scrb"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseAiTypeName = CacheContext.StringTable.GetStringId($@"scarab"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DamageWeakspot,
                            VocalizationIndex = 123,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_chr_bggr"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseActorType = ActorTypeEnum.Juggernaut,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DamageWeakspot,
                            VocalizationIndex = 124,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_chr_hntr"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseActorType = ActorTypeEnum.Engineer,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DamageWeakspot,
                            VocalizationIndex = 126,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_flood"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Flood,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DamageWeakspot,
                            VocalizationIndex = 127,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_swarm"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseActorType = ActorTypeEnum.CarrierForm,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DamageWeakspot,
                            VocalizationIndex = 128,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_pureforms"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Pureform,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DamageWeakspot,
                            VocalizationIndex = 130,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_wpn_snpr"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseAiTypeName = CacheContext.StringTable.GetStringId($@"sniper"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DamageWeakspot,
                            VocalizationIndex = 131,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_wpn_hmmr"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseAiTypeName = CacheContext.StringTable.GetStringId($@"hammer"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.DamageWeakspot,
                            VocalizationIndex = 135,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_trrt_dply"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.UnitCarryingTurret,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderArriveCombat,
                            VocalizationIndex = 191,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"ordr_openfire"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Emerge,
                            VocalizationIndex = 112,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_incmn_fldbm"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Curse,
                            VocalizationIndex = 113,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_incmn_vclbm"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Threaten,
                            VocalizationIndex = 133,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_brsrk"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            Flags = PatternFlags.SubjectVisible,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.CoverFriend,
                            VocalizationIndex = 134,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_stlth_again"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            Flags = PatternFlags.SubjectVisible,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.MoveCover,
                            VocalizationIndex = 39,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"panic_infctnfrm"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.InCover,
                            VocalizationIndex = 136,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"warn_fldreanimate"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            ListenerTarget = SpeakerTypeEnum.Clump,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.ReadyFlakCannon,
                            VocalizationIndex = 157,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"lst_cntct"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsInfantry | PatternFlags.SubjectIsInfantry,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Engage,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Fighting,
                            VocalizationIndex = 158,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"srch_pinned"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsInfantry,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Fighting,
                            VocalizationIndex = 194,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"ordr_pinned"),
                            SpeakerType = SpeakerTypeEnum.Joint,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsInfantry,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Combat,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Surprised,
                            VocalizationIndex = 159,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"invsgt"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsPlayer | PatternFlags.CauseIsInfantry,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Surprised,
                            VocalizationIndex = 198,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"ordr_invsgt"),
                            SpeakerType = SpeakerTypeEnum.Joint,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsInfantry,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Surprised,
                            VocalizationIndex = 204,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"join_invsgt"),
                            SpeakerType = SpeakerTypeEnum.JointLeader,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsSpeakerSTarget | PatternFlags.CauseIsPlayer | PatternFlags.CauseIsInfantry,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Search,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Surprised,
                            VocalizationIndex = 210,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"cvr_invsgt"),
                            SpeakerType = SpeakerTypeEnum.JointLeader,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsSpeakerSTarget | PatternFlags.CauseIsPlayer | PatternFlags.CauseIsInfantry,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Search,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.ReadyPlasmaLauncher,
                            VocalizationIndex = 160,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"invsgt_fail"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsPlayer | PatternFlags.CauseIsInfantry,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.ReadyPlasmaLauncher,
                            VocalizationIndex = 161,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"ask_invsgt_fail"),
                            SpeakerType = SpeakerTypeEnum.Friend,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsPlayer | PatternFlags.CauseIsInfantry,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.InvestigateInterest,
                            VocalizationIndex = 162,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"prst"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsInfantry,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.InvestigateInterest,
                            VocalizationIndex = 196,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"ordr_prst"),
                            SpeakerType = SpeakerTypeEnum.Joint,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsSpeakerSTarget | PatternFlags.CauseIsPlayer | PatternFlags.CauseIsInfantry,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Search,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.InvestigateInterest,
                            VocalizationIndex = 206,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"join_prst"),
                            SpeakerType = SpeakerTypeEnum.JointLeader,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsSpeakerSTarget | PatternFlags.CauseIsPlayer | PatternFlags.CauseIsInfantry,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Search,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.WeaponPickup,
                            VocalizationIndex = 163,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"prst_fail"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsPlayer | PatternFlags.CauseIsInfantry,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.WeaponPickup,
                            VocalizationIndex = 164,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"ask_prst_fail"),
                            SpeakerType = SpeakerTypeEnum.Friend,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsSpeakerSTarget | PatternFlags.CauseIsPlayer | PatternFlags.CauseIsInfantry,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.HeardOld,
                            VocalizationIndex = 103,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"foundfoe"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsSpeakerSTarget,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Engage,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.HeardOld,
                            VocalizationIndex = 104,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"foundfoe_mjr_mc"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsSpeakerSTarget,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerMasterchief,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Engage,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.HeardOld,
                            VocalizationIndex = 105,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"foundfoe_mjr_arb"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsSpeakerSTarget,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerDervish,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Engage,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.HeardOld,
                            VocalizationIndex = 107,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"foundfoe_chasing"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsSpeakerSTarget,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Cover,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.HeardOld,
                            VocalizationIndex = 274,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"pld_mjrfoe_mc"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsSpeakerSTarget,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerMasterchief,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Retreat,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.HeardOld,
                            VocalizationIndex = 273,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"pld_mjrfoe_arb"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsSpeakerSTarget,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerDervish,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Retreat,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.FoundUnit,
                            VocalizationIndex = 106,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"foundfoe_prst"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsSpeakerSTarget,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Engage,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.FoundUnit,
                            VocalizationIndex = 107,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"foundfoe_chasing"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsSpeakerSTarget,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Cover,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SpacialRelation = VocalizationPattern.SpatialRelationEnum.Near,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.InvestigateStart,
                            VocalizationIndex = 165,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"stayback"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsInfantry,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.InvestigateStart,
                            VocalizationIndex = 166,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"stayback_agg"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsInfantry,
                            Attitude = VocalizationPattern.StyleAttitudeEnum.Aggressive,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.InvestigateStart,
                            VocalizationIndex = 167,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"stayback_tim"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsInfantry,
                            Attitude = VocalizationPattern.StyleAttitudeEnum.Timid,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.InvestigateStart,
                            VocalizationIndex = 168,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"join_stayback"),
                            SpeakerType = SpeakerTypeEnum.JointLeader,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsSpeakerSTarget | PatternFlags.CauseIsPlayer | PatternFlags.CauseIsInfantry,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.InvestigateStart,
                            VocalizationIndex = 195,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"ordr_stayback"),
                            SpeakerType = SpeakerTypeEnum.Joint,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsSpeakerSTarget | PatternFlags.CauseIsPlayer | PatternFlags.CauseIsInfantry,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.InvestigateStart,
                            VocalizationIndex = 263,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"tnt_invsgt_stayback"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsInfantry,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.LostContact,
                            VocalizationIndex = 169,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"srchend"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsInfantry,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.InvestigateFailed,
                            VocalizationIndex = 169,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"srchend"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseIsInfantry,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.OrderAckAttackInfantry,
                            VocalizationIndex = 144,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"rmd_trrt"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.UnitInTurret,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.OrderAckAttackInfantry,
                            VocalizationIndex = 140,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"rmd_scrb"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseAiTypeName = CacheContext.StringTable.GetStringId($@"scarab"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.OrderAckAttackInfantry,
                            VocalizationIndex = 139,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"rmd_plr_mc"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerMasterchief,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.OrderAckAttackInfantry,
                            VocalizationIndex = 138,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"rmd_plr_arb"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerDervish,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.OrderAckAttackInfantry,
                            VocalizationIndex = 141,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"rmd_stlth"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Stealth,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.OrderAckAttackInfantry,
                            VocalizationIndex = 145,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"rmd_vcl_bnsh"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.UnitInVehicle,
                            CauseAiTypeName = CacheContext.StringTable.GetStringId($@"banshee"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.OrderAckAttackInfantry,
                            VocalizationIndex = 146,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"rmd_vcl_chpr"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.UnitInVehicle,
                            CauseAiTypeName = CacheContext.StringTable.GetStringId($@"chopper"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.OrderAckAttackInfantry,
                            VocalizationIndex = 147,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"rmd_vcl_ghst"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.UnitInVehicle,
                            CauseAiTypeName = CacheContext.StringTable.GetStringId($@"ghost"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.OrderAckAttackInfantry,
                            VocalizationIndex = 149,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"rmd_vcl_wrth"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.UnitInVehicle,
                            CauseAiTypeName = CacheContext.StringTable.GetStringId($@"wraith"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.OrderAckAttackInfantry,
                            VocalizationIndex = 148,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"rmd_vcl_phntm"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.UnitInVehicle,
                            CauseAiTypeName = CacheContext.StringTable.GetStringId($@"phantom"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.OrderAckAttackInfantry,
                            VocalizationIndex = 142,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"rmd_wpn_snpr"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseAiTypeName = CacheContext.StringTable.GetStringId($@"sniper"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.OrderAckAttackInfantry,
                            VocalizationIndex = 143,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"rmd_wpn_hmmr"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseAiTypeName = CacheContext.StringTable.GetStringId($@"hammer"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.FoundUnitPursuit,
                            VocalizationIndex = 248,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"strk_grnd"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.FoundUnitPursuit,
                            VocalizationIndex = 192,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"ordr_grenade"),
                            SpeakerType = SpeakerTypeEnum.Joint,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.SuppressingFire,
                            VocalizationIndex = 249,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"strk_grnd_uncvr"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.SuppressingFire,
                            VocalizationIndex = 192,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"ordr_grenade"),
                            SpeakerType = SpeakerTypeEnum.Joint,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.ThrowingGrenade,
                            VocalizationIndex = 193,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"ordr_grenade_all"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderAdvance,
                            VocalizationIndex = 205,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"join_emrg"),
                            SpeakerType = SpeakerTypeEnum.EnemyOfCause,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.ThrowingGrenadeAll,
                            VocalizationIndex = 242,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"chr_kllfoe_stkplsm"),
                            SpeakerType = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.PostcombatInspectBody,
                            VocalizationIndex = 278,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"rtrt"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.VehicleGetIn,
                            VocalizationIndex = 279,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"rtrt_ldrdead"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.VehicleSlowDown,
                            VocalizationIndex = 278,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"rtrt"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Idle,
                            VocalizationIndex = 278,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"rtrt"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.CombatIdle,
                            VocalizationIndex = 278,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"rtrt"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.OrderAckWeaponChange,
                            VocalizationIndex = 41,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"panic_plsmgrnd"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.AssassinationAttack,
                            VocalizationIndex = 284,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"pstcmbt_ez"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.AssassinationAttack,
                            VocalizationIndex = 286,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"pstcmbt_agg"),
                            Attitude = VocalizationPattern.StyleAttitudeEnum.Aggressive,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.AssassinationAttack,
                            VocalizationIndex = 287,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"pstcmbt_tim"),
                            Attitude = VocalizationPattern.StyleAttitudeEnum.Timid,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.AssassinationAttack,
                            VocalizationIndex = 282,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"pstcmbt_brt"),
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.FoughtBrutes,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.AssassinationAttack,
                            VocalizationIndex = 283,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"pstcmbt_fld"),
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.FoughtFlood,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.AssassinationInterrupted,
                            VocalizationIndex = 285,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"pstcmbt_hrd"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.AssassinationInterrupted,
                            VocalizationIndex = 282,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"pstcmbt_brt"),
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.FoughtBrutes,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.AssassinationInterrupted,
                            VocalizationIndex = 283,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"pstcmbt_fld"),
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.FoughtFlood,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.VehicleFalling,
                            VocalizationIndex = 281,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"pstcmbt"),
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.VehicleFalling,
                            VocalizationIndex = 282,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"pstcmbt_brt"),
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.FoughtBrutes,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.VehicleFalling,
                            VocalizationIndex = 283,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"pstcmbt_fld"),
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.FoughtFlood,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.VehicleScared,
                            VocalizationIndex = 280,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"endcmbt"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Searching,
                            VocalizationIndex = 294,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"tchallybdy"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Searching,
                            VocalizationIndex = 292,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"chckallybdy"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Male,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Searching,
                            VocalizationIndex = 293,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"chckallybdyf"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Female,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.VehicleCrazy,
                            VocalizationIndex = 290,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"ask_chkallybdy"),
                            SpeakerType = SpeakerTypeEnum.Friend,
                            Hostility = HostilityEnum.Friend,
                            Flags = PatternFlags.CauseVisible,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Male,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.VehicleCrazy,
                            VocalizationIndex = 291,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"ask_chkallybdyf"),
                            SpeakerType = SpeakerTypeEnum.Friend,
                            Hostility = HostilityEnum.Friend,
                            Flags = PatternFlags.CauseVisible,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Female,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.VehicleCrazy,
                            VocalizationIndex = 295,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"ordr_chkfoebdy"),
                            SpeakerType = SpeakerTypeEnum.Joint,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseVisible,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.VehicleWoohoo,
                            VocalizationIndex = 297,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"shotfoebdy"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Leap,
                            VocalizationIndex = 288,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"status"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.PostcombatLose,
                            VocalizationIndex = 52,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"grt_intovcl_mine"),
                            SpeakerType = SpeakerTypeEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SubjectType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.PostcombatLose,
                            VocalizationIndex = 50,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"grt_intovcl_imdvr"),
                            Flags = PatternFlags.FriendsPresent,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SubjectType = VocalizationPattern.DialogueObjectTypesEnum.Driver,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.PostcombatLose,
                            VocalizationIndex = 51,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"grt_intovcl_imgnr"),
                            Flags = PatternFlags.FriendsPresent,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SubjectType = VocalizationPattern.DialogueObjectTypesEnum.Gunner,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.PostcombatWin,
                            VocalizationIndex = 45,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"entervcl_drvr"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Vehicle,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.PostcombatNeutral,
                            VocalizationIndex = 46,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"entervcl_gnr"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Vehicle,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.PostcombatNeutral,
                            VocalizationIndex = 48,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"entervcl_trrt"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Turret,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.ShootCorpse,
                            VocalizationIndex = 47,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"entervcl_psngr"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Vehicle,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.InspectBodyStart,
                            VocalizationIndex = 81,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"ok_plr_trdst_dvr"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.PostcombatStatus,
                            VocalizationIndex = 82,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"ok_plr_trdst_gnr"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.RetreatFromLowShield,
                            VocalizationIndex = 237,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"chr_vcljmp"),
                            SpeakerType = SpeakerTypeEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.MeleeCharge,
                            VocalizationIndex = 224,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"scld_plr_vclcrazy"),
                            SpeakerType = SpeakerTypeEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.PostcombatStart,
                            VocalizationIndex = 55,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"bye_extvhl"),
                            SpeakerType = SpeakerTypeEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SubjectType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Gloat,
                            VocalizationIndex = 53,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"invt_vcl"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.PlayerLook,
                            VocalizationIndex = 54,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"invt_vcl_gnr"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderInvestigate,
                            VocalizationIndex = 58,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"grt_plr_mc"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerMasterchief,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderInvestigate,
                            VocalizationIndex = 57,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"grt_plr_arb"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerDervish,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderInvestigate,
                            VocalizationIndex = 64,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"hail_plr_mc"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerMasterchief,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderInvestigate,
                            VocalizationIndex = 63,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"hail_plr_arb"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerDervish,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderInvestigate,
                            VocalizationIndex = 60,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"grt_plr_vcl"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.UnitInVehicle,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderInvestigate,
                            VocalizationIndex = 65,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"hail_agg"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Attitude = VocalizationPattern.StyleAttitudeEnum.Aggressive,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderInvestigate,
                            VocalizationIndex = 66,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"hail_tim"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Attitude = VocalizationPattern.StyleAttitudeEnum.Timid,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan |VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderInvestigate,
                            VocalizationIndex = 59,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"grt_plr_srprs"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SpacialRelation = VocalizationPattern.SpatialRelationEnum.VeryNear,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderInvestigate,
                            VocalizationIndex = 61,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"grt_plr_vcl_empty"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            Flags = PatternFlags.SpeakerIsDowned,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerEmptyVehicle,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderSpread,
                            VocalizationIndex = 69,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"look_plr_mc"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            Flags = PatternFlags.CauseVisible | PatternFlags.CauseIsInfantry,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerMasterchief,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.ClumpIdle,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderSpread,
                            VocalizationIndex = 68,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"look_plr_arb"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            Flags = PatternFlags.CauseVisible | PatternFlags.CauseIsInfantry,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerDervish,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.ClumpIdle,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderSpread,
                            VocalizationIndex = 70,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"look_plr_fllw"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            Flags = PatternFlags.CauseVisible | PatternFlags.CauseIsInfantry,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Follow,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderSpread,
                            VocalizationIndex = 71,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"look_pstcmbt"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            Flags = PatternFlags.CauseVisible | PatternFlags.CauseIsInfantry,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SubjectType = VocalizationPattern.DialogueObjectTypesEnum.Postcombat,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderSpread,
                            VocalizationIndex = 72,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"look_pstcmbt_ez"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            Flags = PatternFlags.CauseVisible | PatternFlags.CauseIsInfantry,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SubjectType = VocalizationPattern.DialogueObjectTypesEnum.PostcombatWon,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderSpread,
                            VocalizationIndex = 73,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"look_pstcmbt_hrd"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            Flags = PatternFlags.CauseVisible | PatternFlags.CauseIsInfantry,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SubjectType = VocalizationPattern.DialogueObjectTypesEnum.PostcombatLost,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderSpread,
                            VocalizationIndex = 75,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"lookcmbt"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            Flags = PatternFlags.CauseVisible | PatternFlags.CauseIsInfantry,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.ClumpCombat,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderSpread,
                            VocalizationIndex = 76,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"lookcmbt_fllw"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            Flags = PatternFlags.CauseVisible | PatternFlags.CauseIsInfantry,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Follow,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderSpread,
                            VocalizationIndex = 77,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"lookcmbt_agg"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            Flags = PatternFlags.CauseVisible | PatternFlags.CauseIsInfantry,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.ClumpCombat,
                            Attitude = VocalizationPattern.StyleAttitudeEnum.Aggressive,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderSpread,
                            VocalizationIndex = 78,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"lookcmbt_tim"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            Flags = PatternFlags.CauseVisible | PatternFlags.CauseIsInfantry,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.ClumpCombat,
                            Attitude = VocalizationPattern.StyleAttitudeEnum.Timid,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderHold,
                            VocalizationIndex = 74,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"look_lngtme"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            Flags = PatternFlags.CauseVisible | PatternFlags.CauseIsInfantry,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.OrderAckInteract,
                            VocalizationIndex = 86,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"thnk_plr_btrwpn"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.OrderAckPinnedDown,
                            VocalizationIndex = 90,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"scrn_plr_wrswpn"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.FireteamMemberJoin,
                            VocalizationIndex = 80,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"ok_plr_trdwpn"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.PlayerLookLongtime,
                            VocalizationIndex = 233,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"scld_plr_blocking"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.PanicGrenadeAttached,
                            VocalizationIndex = 221,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"prs_plr_kll_lots"),
                            SpeakerType = SpeakerTypeEnum.Friend,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                            SubjectType = VocalizationPattern.DialogueObjectTypesEnum.Player,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.FireteamMemberDanger,
                            VocalizationIndex = 42,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"betray"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Traitor,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.FireteamMemberDied,
                            VocalizationIndex = 43,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"forgive"),
                            SpeakerType = SpeakerTypeEnum.Friend,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.ShootGunner,
                            VocalizationIndex = 83,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"ok_plr_arb"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerDervish,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.ShootGunner,
                            VocalizationIndex = 84,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"ok_plr_mc"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerMasterchief,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.ShootMultiple,
                            VocalizationIndex = 87,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"thnk_plr_arb"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerDervish,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.ShootMultiple,
                            VocalizationIndex = 88,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"thnk_plr_mc"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerMasterchief,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.OpenFire,
                            VocalizationIndex = 91,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"scrn_plr_arb"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerDervish,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.OpenFire,
                            VocalizationIndex = 92,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"scrn_plr_mc"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerMasterchief,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.PinnedDown,
                            VocalizationIndex = 231,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"scld_plr_arb"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerDervish,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.PinnedDown,
                            VocalizationIndex = 232,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"scld_plr_mc"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerMasterchief,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Strike,
                            VocalizationIndex = 219,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"prs_plr_arb"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerDervish,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.Strike,
                            VocalizationIndex = 220,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"prs_plr_mc"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Friend,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerMasterchief,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.VehicleEntryStartDriver,
                            VocalizationIndex = 172,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"newordr_advance"),
                            SpeakerType = SpeakerTypeEnum.Vehicle,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.VehicleEntryStartDriver,
                            VocalizationIndex = 184,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"foeordr_advance"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.VehicleEnter,
                            VocalizationIndex = 174,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"newordr_charge"),
                            SpeakerType = SpeakerTypeEnum.Vehicle,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.VehicleEnter,
                            VocalizationIndex = 185,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"foeordr_charge"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.VehicleEntryStartGun,
                            VocalizationIndex = 177,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"newordr_fallback"),
                            SpeakerType = SpeakerTypeEnum.Vehicle,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.VehicleEntryStartGun,
                            VocalizationIndex = 186,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"foeordr_fallback"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.VehicleEntryStartPassenger,
                            VocalizationIndex = 181,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"newordr_retreat"),
                            SpeakerType = SpeakerTypeEnum.Vehicle,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.VehicleEntryStartPassenger,
                            VocalizationIndex = 188,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"foeordr_retreat"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.VehicleExit,
                            VocalizationIndex = 180,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"newordr_moveon"),
                            SpeakerType = SpeakerTypeEnum.Vehicle,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.EvictDriver,
                            VocalizationIndex = 173,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"newordr_arrival"),
                            SpeakerType = SpeakerTypeEnum.Vehicle,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.EvictGunner,
                            VocalizationIndex = 175,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"newordr_entervcl"),
                            SpeakerType = SpeakerTypeEnum.Vehicle,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.EvictPassenger,
                            VocalizationIndex = 176,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"newordr_exitvcl"),
                            SpeakerType = SpeakerTypeEnum.Vehicle,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.VehicleBoarded,
                            VocalizationIndex = 178,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"newordr_fllwplr"),
                            SpeakerType = SpeakerTypeEnum.Vehicle,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderEnemyAdvancing,
                            VocalizationIndex = 179,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"newordr_leaveplr"),
                            SpeakerType = SpeakerTypeEnum.Vehicle,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderEnemyCharging,
                            VocalizationIndex = 182,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"newordr_support"),
                            SpeakerType = SpeakerTypeEnum.Vehicle,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderEnemyCharging,
                            VocalizationIndex = 189,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"foeordr_support"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderEnemyFallingback,
                            VocalizationIndex = 171,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"neworder_flanking"),
                            SpeakerType = SpeakerTypeEnum.Vehicle,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderEnemyFallingback,
                            VocalizationIndex = 187,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"foeordr_flanking"),
                            SpeakerType = SpeakerTypeEnum.Target,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderCharge,
                            VocalizationIndex = 265,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"crs"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderCharge,
                            VocalizationIndex = 268,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"crs_mjrfoe_mc"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerMasterchief,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderCharge,
                            VocalizationIndex = 267,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"crs_mjrfoe_arb"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerDervish,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderCharge,
                            VocalizationIndex = 266,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"crs_mjrfoe"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.MajorlyScary,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderCharge,
                            VocalizationIndex = 270,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"crs_betrayingplr_mc"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Traitor,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerMasterchief,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderCharge,
                            VocalizationIndex = 269,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"crs_betrayingplr_arb"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Traitor,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerDervish,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderFallback,
                            VocalizationIndex = 254,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"thrtn"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderFallback,
                            VocalizationIndex = 257,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"thrtn_mjrfoe_mc"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerMasterchief,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderFallback,
                            VocalizationIndex = 256,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"thrtn_mjrfoe_arb"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerDervish,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderFallback,
                            VocalizationIndex = 255,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"thrtn_mjrfoe"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.MajorlyScary,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderFllplr,
                            VocalizationIndex = 254,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"thrtn"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseVisible | PatternFlags.CauseIsSpeakerSTarget,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Shoot,
                            SpeakerCausePosition = VocalizationPattern.SpatialRelationEnum.InRange,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderFllplr,
                            VocalizationIndex = 257,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"thrtn_mjrfoe_mc"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseVisible | PatternFlags.CauseIsSpeakerSTarget,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerMasterchief,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Shoot,
                            SpeakerCausePosition = VocalizationPattern.SpatialRelationEnum.InRange,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderFllplr,
                            VocalizationIndex = 256,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"thrtn_mjrfoe_arb"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseVisible | PatternFlags.CauseIsSpeakerSTarget,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerDervish,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Shoot,
                            SpeakerCausePosition = VocalizationPattern.SpatialRelationEnum.InRange,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderFllplr,
                            VocalizationIndex = 255,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"thrtn_mjrfoe"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseVisible | PatternFlags.CauseIsSpeakerSTarget,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.MajorlyScary,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Shoot,
                            SpeakerCausePosition = VocalizationPattern.SpatialRelationEnum.InRange,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderFllplr,
                            VocalizationIndex = 247,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"strk"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseVisible | PatternFlags.CauseIsSpeakerSTarget,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Shoot,
                            SpeakerCausePosition = VocalizationPattern.SpatialRelationEnum.InRange,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderFllplr,
                            VocalizationIndex = 251,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"strk_mjrfoe_mc"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseVisible | PatternFlags.CauseIsSpeakerSTarget,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerMasterchief,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Shoot,
                            SpeakerCausePosition = VocalizationPattern.SpatialRelationEnum.InRange,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderFllplr,
                            VocalizationIndex = 250,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"strk_mjrfoe_arb"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseVisible | PatternFlags.CauseIsSpeakerSTarget,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerDervish,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Shoot,
                            SpeakerCausePosition = VocalizationPattern.SpatialRelationEnum.InRange,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderFllplr,
                            VocalizationIndex = 253,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"strk_vcl_gnr"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseVisible | PatternFlags.CauseIsSpeakerSTarget,
                            SpeakerObjectType = VocalizationPattern.DialogueObjectTypesEnum.Gunner,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Shoot,
                            SpeakerCausePosition = VocalizationPattern.SpatialRelationEnum.InRange,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderFllplr,
                            VocalizationIndex = 262,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"tnt_mjrfoe_mc"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseVisible | PatternFlags.CauseIsSpeakerSTarget,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerMasterchief,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Engage,
                            SpeakerCausePosition = VocalizationPattern.SpatialRelationEnum.InRange,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.NewOrderFllplr,
                            VocalizationIndex = 261,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"tnt_mjrfoe_arb"),
                            SpeakerType = SpeakerTypeEnum.Leader,
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Flags = PatternFlags.CauseVisible | PatternFlags.CauseIsSpeakerSTarget,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerDervish,
                            SpeakerBehavior = VocalizationPattern.SpeakerBehaviorEnum.Engage,
                            SpeakerCausePosition = VocalizationPattern.SpatialRelationEnum.InRange,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.AbandonedSearchRestricted,
                            VocalizationIndex = 259,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"tnt"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.AbandonedSearchRestricted,
                            VocalizationIndex = 262,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"tnt_mjrfoe_mc"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerMasterchief,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.AbandonedSearchRestricted,
                            VocalizationIndex = 261,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"tnt_mjrfoe_arb"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.PlayerDervish,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                        new VocalizationPattern
                        {
                            DialogueType = DialogueTypeEnum.AbandonedSearchRestricted,
                            VocalizationIndex = 260,
                            VocalizationName = CacheContext.StringTable.GetStringId($@"tnt_mjrfoe"),
                            ListenerTarget = SpeakerTypeEnum.Cause,
                            Hostility = HostilityEnum.Enemy,
                            CauseType = VocalizationPattern.DialogueObjectTypesEnum.MajorlyScary,
                            Conditions = VocalizationPattern.DialogueConditionFlags.Asleep | VocalizationPattern.DialogueConditionFlags.Idle | VocalizationPattern.DialogueConditionFlags.Alert | VocalizationPattern.DialogueConditionFlags.Active | VocalizationPattern.DialogueConditionFlags.UninspectedOrphan | VocalizationPattern.DialogueConditionFlags.DefiniteOrphan | VocalizationPattern.DialogueConditionFlags.CertainOrphan | VocalizationPattern.DialogueConditionFlags.VisibleEnemy | VocalizationPattern.DialogueConditionFlags.ClearLosEnemy | VocalizationPattern.DialogueConditionFlags.DangerousEnemy | VocalizationPattern.DialogueConditionFlags.NoVehicle | VocalizationPattern.DialogueConditionFlags.VehicleDriver | VocalizationPattern.DialogueConditionFlags.VehiclePassenger,
                        },
                    },
                    DialogueData = new List<AiDialogueGlobals.DialogueDatum> 
                    {
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            LengthPostProcess = 23,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 23,
                            LengthPostProcess = 7,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 38,
                            LengthPostProcess = 21,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 32,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 33,
                            LengthPostProcess = 5,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 30,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 80,
                            LengthPostProcess = 6,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 86,
                            LengthPostProcess = 2,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 108,
                            LengthPostProcess = 2,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 112,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 114,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 67,
                            LengthPostProcess = 2,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 110,
                            LengthPostProcess = 2,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 31,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 66,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 73,
                            LengthPostProcess = 2,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 78,
                            LengthPostProcess = 2,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 69,
                            LengthPostProcess = 4,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 94,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 95,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 88,
                            LengthPostProcess = 6,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 75,
                            LengthPostProcess = 3,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 133,
                            LengthPostProcess = 3,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 230,
                            LengthPostProcess = 4,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 115,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 117,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 116,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 118,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 119,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 150,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 151,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 121,
                            LengthPostProcess = 5,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 126,
                            LengthPostProcess = 3,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 129,
                            LengthPostProcess = 3,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 139,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 132,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 136,
                            LengthPostProcess = 3,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 140,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 144,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 141,
                            LengthPostProcess = 3,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 145,
                            LengthPostProcess = 2,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 147,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 152,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 148,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 149,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 192,
                            LengthPostProcess = 2,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 194,
                            LengthPostProcess = 2,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 196,
                            LengthPostProcess = 2,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 198,
                            LengthPostProcess = 2,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 200,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 201,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 202,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 203,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 204,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 205,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 206,
                            LengthPostProcess = 2,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 208,
                            LengthPostProcess = 2,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 113,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 210,
                            LengthPostProcess = 6,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 216,
                            LengthPostProcess = 4,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 220,
                            LengthPostProcess = 10,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 59,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 155,
                            LengthPostProcess = 9,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 164,
                            LengthPostProcess = 10,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 174,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 120,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 96,
                            LengthPostProcess = 12,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 175,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 176,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 177,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 180,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 181,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 60,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 61,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 62,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 63,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 64,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 65,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 188,
                            LengthPostProcess = 2,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 190,
                            LengthPostProcess = 2,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 186,
                            LengthPostProcess = 2,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 184,
                            LengthPostProcess = 2,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 182,
                            LengthPostProcess = 2,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 153,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = -1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 154,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 178,
                            LengthPostProcess = 1,
                        },
                        new AiDialogueGlobals.DialogueDatum
                        {
                            StartIndexPostProcess = 179,
                            LengthPostProcess = 1,
                        },
                    },
                    InvoluntaryData = new List<AiDialogueGlobals.InvoluntaryDatum> 
                    {
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                        
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 2,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 4,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 6,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 3,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 5,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 1,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 7,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 25,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 20,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 19,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 21,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 8,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 9,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 11,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 12,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 13,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 10,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 14,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 15,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 16,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 17,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 18,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 22,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 23,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 24,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 32,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 33,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 34,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 35,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 36,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 26,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 27,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 28,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 29,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 30,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 31,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 302,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 300,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 303,
                        },
                        new AiDialogueGlobals.InvoluntaryDatum
                        {
                            InvoluntaryVocalizationIndex = 301,
                        },
                    },
                };
                CacheContext.Serialize(stream, adlgTag, adlg);
            };
        }
    }
}