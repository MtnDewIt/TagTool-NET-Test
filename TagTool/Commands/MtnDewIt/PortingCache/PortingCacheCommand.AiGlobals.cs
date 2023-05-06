using TagTool.Common;
using TagTool.Tags.Definitions;
using System.Collections.Generic;

namespace TagTool.Commands.Tags
{
    partial class PortingCacheCommand : Command
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
                                        Object =  CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
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
                                        Object =  CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
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
                                        Object =  CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Easy | SquadTemplate.CellTemplate.DifficultyFlagsValue.Normal,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Easy | SquadTemplate.CellTemplate.DifficultyFlagsValue.Normal,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 7,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 7,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 7,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\melee\gravity_hammer\gravity_hammer"),
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
                                        //Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\turret\plasma_cannon\plasma_cannon"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\beam_rifle\beam_rifle"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\beam_rifle\beam_rifle"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\beam_rifle\beam_rifle"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\beam_rifle\beam_rifle"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 5,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 5,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 5,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 5,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 5,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 5,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 5,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Probability = 5,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        DifficultyFlags = SquadTemplate.CellTemplate.DifficultyFlagsValue.Heroic | SquadTemplate.CellTemplate.DifficultyFlagsValue.Legendary,
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 10,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 5,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle"),
                                        Probability = 5,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        RoundRange = new Bounds<short>(2, 3),
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        RoundRange = new Bounds<short>(2, 3),
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        RoundRange = new Bounds<short>(3, 3),
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 5,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle"),
                                        Probability = 5,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        RoundRange = new Bounds<short>(3, 3),
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        RoundRange = new Bounds<short>(2, 3),
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        RoundRange = new Bounds<short>(2, 3),
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 5,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        RoundRange = new Bounds<short>(0, 5),
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 5,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        RoundRange = new Bounds<short>(0, 5),
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 5,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        RoundRange = new Bounds<short>(0, 5),
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 5,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        RoundRange = new Bounds<short>(0, 5),
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\melee\gravity_hammer\gravity_hammer"),
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
                                        //Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\turret\plasma_cannon\plasma_cannon"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\melee\gravity_hammer\gravity_hammer"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\melee\gravity_hammer\gravity_hammer"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
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
                                        //Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\turret\plasma_cannon\plasma_cannon"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                                        Probability = 5,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle"),
                                        Probability = 5,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        RoundRange = new Bounds<short>(3, 3),
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
                                        Probability = 1,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        RoundRange = new Bounds<short>(2, 3),
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        RoundRange = new Bounds<short>(2, 3),
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 5,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        RoundRange = new Bounds<short>(2, 3),
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                        Probability = 5,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        RoundRange = new Bounds<short>(2, 3),
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                        Probability = 3,
                                    },
                                    new SquadTemplate.CellTemplate.ObjectBlock
                                    {
                                        RoundRange = new Bounds<short>(3,3),
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\beam_rifle\beam_rifle"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
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
                                        Object = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\beam_rifle\beam_rifle"),
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
    }
}