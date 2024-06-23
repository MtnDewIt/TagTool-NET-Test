using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using static TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class multiplayer_multiplayer_globals_multiplayer_globals : TagFile
    {
        public multiplayer_multiplayer_globals_multiplayer_globals(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<MultiplayerGlobals>($@"multiplayer\multiplayer_globals");
            var mulg = CacheContext.Deserialize<MultiplayerGlobals>(Stream, tag);
            mulg.Universal = new List<MultiplayerGlobals.MultiplayerUniversalBlock>()
            {
                new MultiplayerGlobals.MultiplayerUniversalBlock()
                {
                    RandomPlayerNameStrings = GetCachedTag<MultilingualUnicodeStringList>($@"multiplayer\random_player_names"),
                    TeamNameStrings = GetCachedTag<MultilingualUnicodeStringList>($@"multiplayer\team_names"),
                    TeamColors = new List<MultiplayerGlobals.MultiplayerUniversalBlock.MultiplayerColor>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.MultiplayerColor()
                        {
                            Color = new RealRgbColor(0.384314f, 0.0431373f, 0.0431373f),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.MultiplayerColor()
                        {
                            Color = new RealRgbColor(0.0470588f, 0.141176f, 0.384314f),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.MultiplayerColor()
                        {
                            Color = new RealRgbColor(0.12549f, 0.215686f, 0.0117647f),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.MultiplayerColor()
                        {
                            Color = new RealRgbColor(0.737255f, 0.305882f, 0f),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.MultiplayerColor()
                        {
                            Color = new RealRgbColor(0.117647f, 0.0627451f, 0.32549f),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.MultiplayerColor()
                        {
                            Color = new RealRgbColor(0.654902f, 0.470588f, 0.0313726f),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.MultiplayerColor()
                        {
                            Color = new RealRgbColor(0.109804f, 0.0509804f, 0.00784314f),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.MultiplayerColor()
                        {
                            Color = new RealRgbColor(1f, 0.305882f, 0.545098f),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.MultiplayerColor()
                        {
                            Color = new RealRgbColor(0.85098f, 0.85098f, 0.85098f),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.MultiplayerColor()
                        {
                            Color = new RealRgbColor(0.0431373f, 0.0431373f, 0.0431373f),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.MultiplayerColor()
                        {
                            Color = new RealRgbColor(0.462745f, 0.478431f, 0.247059f),
                        },
                    },
                    CustomizableCharacters = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter()
                        {
                            CharacterName = CacheContext.StringTable.GetOrAddString($@"masterchief"),
                            Regions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region()
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"helmet"),
                                    Permutations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation>()
                                    {
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_helmet_default"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_helmet_default_description"),
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_helmet_mp_cobra"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_helmet_mp_cobra_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"helmet"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_cobra"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_helmet_mp_intruder"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_helmet_mp_intruder_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"_achievement_complete_campaign_normal"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"helmet"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_intruder"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_helmet_mp_ninja"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_helmet_mp_ninja_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement | MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasSpecialRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"community"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"helmet"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_ninja"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_helmet_mp_regulator"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_helmet_mp_regulator_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"_achievement_complete_campaign_legendary"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"helmet"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_regulator"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_helmet_mp_ryu"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_helmet_mp_ryu_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"skulls_third_tier"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"helmet"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_ryu"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_helmet_mp_marathon"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_helmet_mp_marathon_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"achievements_1000"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"helmet"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_marathon"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_helmet_mp_scout"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_helmet_mp_scout_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"_achievement_full_vehicle_kill"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"helmet"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_scout"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_helmet_mp_odst"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_helmet_mp_odst_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"_achievement_spartan_recruit"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"helmet"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_odst"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_helmet_mp_markv"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_helmet_mp_markv_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"_achievement_spartan_graduate"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"helmet"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_markv"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_helmet_mp_rogue"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_helmet_mp_rogue_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"_achievement_spartan_officer"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"helmet"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_rogue"),
                                                },
                                            },
                                        },
                                    },
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region()
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"leftshoulder"),
                                    Permutations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation>()
                                    {
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_leftshoulder_default"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_leftshoulder_default_description"),
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_leftshoulder_cobra"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_leftshoulder_cobra_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"leftshoulder"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_cobra"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_leftshoulder_intruder"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_leftshoulder_intruder_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"_achievement_complete_mission_wasteland"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"leftshoulder"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_intruder"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_leftshoulder_ninja"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_leftshoulder_ninja_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement | MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasSpecialRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"community"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"leftshoulder"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_ninja"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_leftshoulder_regulator"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_leftshoulder_regulator_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"completed_070_legendary"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"leftshoulder"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_regulator"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_leftshoulder_ryu"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_leftshoulder_ryu_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"skulls_second_tier"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"leftshoulder"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_ryu"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_leftshoulder_marathon"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_leftshoulder_marathon_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"achievements_750"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"leftshoulder"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_marathon"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_leftshoulder_scout"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_leftshoulder_scout_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"_achievement_mongoose_splatter"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"leftshoulder"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_scout"),
                                                },
                                            },
                                        },
                                    },
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region()
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"rightshoulder"),
                                    Permutations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation>()
                                    {
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_rightshoulder_default"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_rightshoulder_default_description"),
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_rightshoulder_cobra"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_rightshoulder_cobra_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"rightshoulder"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_cobra"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_rightshoulder_intruder"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_rightshoulder_intruder_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"_achievement_complete_mission_wasteland"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"rightshoulder"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_intruder"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_rightshoulder_ninja"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_rightshoulder_ninja_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement | MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasSpecialRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"community"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"rightshoulder"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_ninja"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_rightshoulder_regulator"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_rightshoulder_regulator_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"completed_070_legendary"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"rightshoulder"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_regulator"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_rightshoulder_ryu"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_rightshoulder_ryu_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"skulls_second_tier"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"rightshoulder"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_ryu"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_rightshoulder_marathon"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_rightshoulder_marathon_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"achievements_750"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"rightshoulder"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_marathon"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_rightshoulder_scout"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_rightshoulder_scout_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"_achievement_mongoose_splatter"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"rightshoulder"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_scout"),
                                                },
                                            },
                                        },
                                    },
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region()
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"body"),
                                    Permutations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation>()
                                    {
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_body_default"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_body_default_description"),
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_body_cobra"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_body_cobra_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_cobra"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_body_intruder"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_body_intruder_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"_achievement_complete_mission_outskirts"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_intruder"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_body_ninja"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_body_ninja_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement | MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasSpecialRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"community"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_ninja"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_body_ryu"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_body_ryu_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"skulls_first_tier"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_ryu"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_body_regulator"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_body_regulator_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"completed_030_legendary"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_regulator"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_body_scout"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_body_scout_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"_achievement_laser_or_missle_kill_banshee"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_scout"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_body_katana"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_body_katana_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement | MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasSpecialRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"achievements_1000"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_katana"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"spartan_body_bungie"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"spartan_body_bungie_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement | MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasSpecialRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"bungie"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_bungie"),
                                                },
                                            },
                                        },
                                    },
                                },
                            },
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter()
                        {
                            CharacterName = CacheContext.StringTable.GetOrAddString($@"dervish"),
                            Regions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region()
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"helmet"),
                                    Permutations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation>()
                                    {
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"elite_head_default"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"elite_head_default_description"),
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"elite_head_mp_predator"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"elite_head_mp_predator_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.None,
                                            AchievementRequirement = StringId.Invalid,
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"head"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_raptor"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"elite_head_mp_raptor"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"elite_head_mp_raptor_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"_achievement_complete_campaign_heroic"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"head"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_predator"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"elite_head_mp_blades"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"elite_head_mp_blades_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"_achievement_triple_sword_kill"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"head"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_blades"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"elite_head_mp_scythe"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"elite_head_mp_scythe_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"_achievement_overkill"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"head"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_scythe"),
                                                },
                                            },
                                        },
                                    },
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region()
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"leftshoulder"),
                                    Permutations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation>()
                                    {
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"elite_leftshoulder_default"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"elite_leftshoulder_default_description"),
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"elite_leftshoulder_mp_predator"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"elite_leftshoulder_mp_predator_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"leftshoulder"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_raptor"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"elite_leftshoulder_mp_raptor"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"elite_leftshoulder_mp_raptor_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"completed_070_heroic_or_legendary"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"leftshoulder"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_predator"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"elite_leftshoulder_mp_blades"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"elite_leftshoulder_mp_blades_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"_achievement_overkill"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"leftshoulder"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_blades"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"elite_leftshoulder_mp_scythe"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"elite_leftshoulder_mp_scythe_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"_achievement_killing_frenzy"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"leftshoulder"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_scythe"),
                                                },
                                            },
                                        },
                                    },
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region()
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"rightshoulder"),
                                    Permutations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation>()
                                    {
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"elite_rightshoulder_default"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"elite_rightshoulder_default_description"),
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"elite_rightshoulder_mp_predator"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"elite_rightshoulder_mp_predator_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"rightshoulder"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_raptor"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"elite_rightshoulder_mp_raptor"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"elite_rightshoulder_mp_raptor_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"completed_070_heroic_or_legendary"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"rightshoulder"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_predator"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"elite_rightshoulder_mp_blades"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"elite_rightshoulder_mp_blades_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"_achievement_overkill"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"rightshoulder"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_blades"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"elite_rightshoulder_mp_scythe"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"elite_rightshoulder_mp_scythe_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"_achievement_killing_frenzy"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"rightshoulder"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_scythe"),
                                                },
                                            },
                                        },
                                    },
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region()
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"body"),
                                    Permutations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation>()
                                    {
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"elite_body_default"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"elite_body_default_description"),
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"elite_body_mp_predator"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"elite_body_mp_predator_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_raptor"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"elite_body_mp_raptor"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"elite_body_mp_raptor_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"completed_030_heroic_or_legendary"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_predator"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"elite_body_mp_blades"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"elite_body_mp_blades_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"_achievement_melee_kill_x5"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_blades"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetOrAddString($@"elite_body_mp_scythe"),
                                            Description = CacheContext.StringTable.GetOrAddString($@"elite_body_mp_scythe_description"),
                                            Flags = MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.CustomizedModelSelectionFlags.HasRequirement,
                                            AchievementRequirement = CacheContext.StringTable.GetOrAddString($@"_achievement_triple_kill"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetOrAddString($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetOrAddString($@"mp_scythe"),
                                                },
                                            },
                                        },
                                    },
                                },
                            },
                        },
                    },
                    Equipment = new List<MultiplayerGlobals.MultiplayerUniversalBlock.Consumable>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("empty"),
                            Object = null,
                            Type = 0,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("jammer"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\jammer_equipment\jammer_equipment"),
                            Type = 8,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("powerdrain"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\powerdrain_equipment\powerdrain_equipment"),
                            Type = 1,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("invisibility"),
                            Object = GetCachedTag<Equipment>($@"objects\equipment\invisibility_equipment\invisibility_equipment"),
                            Type = 13,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("invisibility_vehicle"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\invisibility_vehicle_equipment\invisibility_vehicle_equipment"),
                            Type = 19,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("bubbleshield"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\bubbleshield_equipment\bubbleshield_equipment"),
                            Type = 2,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("superflare"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\superflare_equipment\superflare_equipment"),
                            Type = 10,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("regenerator"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\regenerator_equipment\regenerator_equipment"),
                            Type = 4,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("tripmine"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\tripmine_equipment\tripmine_equipment"),
                            Type = 5,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("auto_turret"),
                            Type = 9,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("deployable_cover"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\instantcover_equipment\instantcover_equipment"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("forced_reload"),
                            Type = 18,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("concussive_blast"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\concussiveblast_equipment\concussiveblast_equipment"),
                            Type = 11,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("tank_mode"),
                            Type = 20,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("mag_pulse"),
                            Type = 27,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("hologram"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\hologram_equipment\hologram_equipment"),
                            Type = 14,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("reactive_armor"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\reactive_armor_equipment\reactive_armor_equipment"),
                            Type = 16,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("bomb_run"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\bombrun_equipment\bombrun_equipment"),
                            Type = 12,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("armor_lock"),
                            Type = 17,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("adrenaline"),
                            Type = 7,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("lightning_strike"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\lightningstrike_equipment\lightningstrike_equipment"),
                            Type = 22,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("scrambler"),
                            Type = 25,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("weapon_jammer"),
                            Type = 24,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("ammo_pack"),
                            Object = GetCachedTag<Equipment>($@"objects\equipment\ammo_pack_equipment\ammo_pack_equipment"),
                            Type = 23,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("consumable_vision"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\vision_equipment\vision_equipment"),
                            Type = 15,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("invincibility"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\invincibility_equipment\invincibility_equipment"),
                            Type = 26,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetOrAddString("gravlift"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\gravlift_equipment\gravlift_equipment"),
                            Type = 3,
                        },
                    },
                    EnergyRegeneration = new List<MultiplayerGlobals.MultiplayerUniversalBlock.EnergyRegenerationBlock>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.EnergyRegenerationBlock()
                        {
                            Duration = 15,
                            EnergyLevel = 1,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.EnergyRegenerationBlock()
                        {
                            Duration = 15,
                            EnergyLevel = 1,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.EnergyRegenerationBlock()
                        {
                            Duration = 15,
                            EnergyLevel = 1,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.EnergyRegenerationBlock()
                        {
                            Duration = 15,
                            EnergyLevel = 1,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.EnergyRegenerationBlock()
                        {
                            Duration = 15,
                            EnergyLevel = 1,
                        },
                    },
                    MultiplayerStrings = GetCachedTag<MultilingualUnicodeStringList>($@"multiplayer\global_multiplayer_messages"),
                    SandboxUiStrings = GetCachedTag<MultilingualUnicodeStringList>($@"ui\halox\sandbox_ui\strings"),
                    SandboxObjectProperties = GetCachedTag<SandboxTextValuePairDefinition>($@"ui\halox\sandbox_ui\object_properties_menu_values"),
                    GameVariantWeapons = new List<MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("battle_rifle"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\battle_rifle\battle_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("assault_rifle"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\assault_rifle\assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("plasma_pistol"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\pistol\plasma_pistol\plasma_pistol")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("spike_rifle"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\spike_rifle\spike_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("smg"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\smg\smg")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("carbine"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\covenant_carbine\covenant_carbine")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("energy_sword"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\melee\energy_blade\energy_blade")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("magnum"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\pistol\magnum\magnum")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("needler"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\pistol\needler\needler")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("plasma_rifle"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\plasma_rifle\plasma_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("rocket_launcher"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\support_high\rocket_launcher\rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("shotgun"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\shotgun\shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("sniper_rifle"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\sniper_rifle\sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("brute_shot"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\support_low\brute_shot\brute_shot")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("unarmed"),
                            RandomChance = 0f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\melee\energy_blade\energy_blade_useless")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("beam_rifle"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\beam_rifle\beam_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("spartan_laser"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\support_high\spartan_laser\spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("none"),
                            RandomChance = 0f,
                            Weapon = null
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("gravity_hammer"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\melee\gravity_hammer\gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("excavator"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\pistol\excavator\excavator")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("flamethrower"),
                            RandomChance = 0f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\turret\flamethrower\flamethrower")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("missile_pod"),
                            RandomChance = 0f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\turret\missile_pod\missile_pod")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("sentinel_beam"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\support_low\sentinel_gun\sentinel_gun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("fuel_rod_gun"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\support_high\flak_cannon\flak_cannon")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("dmr"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\dmr\dmr")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("assault_rifle_v1"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("assault_rifle_v2"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\assault_rifle\assault_rifle_v2\assault_rifle_v2")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("assault_rifle_v3"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\assault_rifle\assault_rifle_v3\assault_rifle_v3")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("assault_rifle_v4"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("assault_rifle_v5"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\assault_rifle\assault_rifle_v5\assault_rifle_v5")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("assault_rifle_v6"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\assault_rifle\assault_rifle_v6\assault_rifle_v6")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("battle_rifle_v1"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\battle_rifle\battle_rifle_v1\battle_rifle_v1")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("battle_rifle_v2"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\battle_rifle\battle_rifle_v2\battle_rifle_v2")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("battle_rifle_v3"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\battle_rifle\battle_rifle_v3\battle_rifle_v3")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("battle_rifle_v4"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\battle_rifle\battle_rifle_v4\battle_rifle_v4")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("battle_rifle_v5"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\battle_rifle\battle_rifle_v5\battle_rifle_v5")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("battle_rifle_v6"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\battle_rifle\battle_rifle_v6\battle_rifle_v6")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("dmr_v1"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\dmr\dmr_v1\dmr_v1")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("dmr_v2"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\dmr\dmr_v2\dmr_v2")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("dmr_v3"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\dmr\dmr_v3\dmr_v3")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("dmr_v4"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\dmr\dmr_v4\dmr_v4")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("dmr_v5"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("dmr_v6"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\dmr\dmr_v6\dmr_v6")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("smg_v1"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\smg\smg_v1\smg_v1")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("smg_v2"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\smg\smg_v2\smg_v2")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("smg_v3"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("smg_v4"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\smg\smg_v4\smg_v4")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("smg_v5"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("smg_v6"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\smg\smg_v6\smg_v6")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("plasma_rifle_v1"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("plasma_rifle_v2"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("plasma_rifle_v3"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("plasma_rifle_v4"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("plasma_rifle_v5"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("plasma_rifle_v6"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\plasma_rifle\plasma_rifle_v6\plasma_rifle_v6")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("covenant_carbine_v1"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v1\covenant_carbine_v1")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("covenant_carbine_v2"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v2\covenant_carbine_v2")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("covenant_carbine_v3"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v3\covenant_carbine_v3")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("covenant_carbine_v4"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v4\covenant_carbine_v4")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("covenant_carbine_v5"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v5\covenant_carbine_v5")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("covenant_carbine_v6"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v6\covenant_carbine_v6")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("excavator_v1"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("excavator_v2"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("excavator_v3"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\pistol\excavator\excavator_v3\excavator_v3")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("magnum_v1"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("magnum_v2"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\pistol\magnum\magnum_v2\magnum_v2")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("magnum_v3"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\pistol\magnum\magnum_v3\magnum_v3")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("plasma_pistol_v3"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\pistol\plasma_pistol\plasma_pistol_v3\plasma_pistol_v3")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("plasma_pistol_v2"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("machinegun_turret"),
                            RandomChance = 0f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\turret\machinegun_turret\machinegun_turret")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetOrAddString("plasma_cannon"),
                            RandomChance = 0f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\turret\plasma_cannon\plasma_cannon")
                        },
                    },
                    GameVariantVehicles = new List<MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("warthog"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("ghost"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\ghost\ghost"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("scorpion"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\scorpion\scorpion"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("wraith"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\wraith\wraith"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("banshee"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\banshee\banshee"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("mongoose"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\mongoose\mongoose"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("chopper"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\brute_chopper\brute_chopper"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("mauler"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("hornet"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\hornet\hornet"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("warthog_snow"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_snow"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("mongoose_snow"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("hornet_lite"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\levels\dlc\sidewinder\hornet_lite\hornet_lite"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("scorpion_snow"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("ghost_snow"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("warthog_gauss"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_gauss"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("warthog_01"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_troop"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("warthog_02"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_no_turret"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("warthog_03"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_wrecked"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("warthog_04"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_snow_gauss"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("warthog_05"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_snow_troop"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("warthog_06"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_snow_no_turret"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("warthog_07"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_snow_wrecked"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetOrAddString("wraith1"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\wraith\wraith_anti_air"),
                        },
                    },
                    GameVariantGrenades = new List<MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantGrenadeBlock>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantGrenadeBlock
                        {
                            Name = CacheContext.StringTable.GetOrAddString("frag_grenade"),
                            Grenade = GetCachedTag<Equipment>(@"objects\weapons\grenade\frag_grenade\frag_grenade"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantGrenadeBlock
                        {
                            Name = CacheContext.StringTable.GetOrAddString("plasma_grenade"),
                            Grenade = GetCachedTag<Equipment>(@"objects\weapons\grenade\plasma_grenade\plasma_grenade"),
                        },
                    },
                    WeaponSets = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("default"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spike_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("carbine")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("needler")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("brute_shot")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("fuel_rod_gun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sentinel_beam")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("beam_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("excavator")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("flamethrower")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("missile_pod")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("excavator_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("excavator_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("excavator_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v3"),
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("assault_rifles"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("duals"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spike_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("excavator")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v1"),
                                   SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("excavator_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("excavator_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("excavator_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v3"),
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("hammers"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("lasers"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser")
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("rockets"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("shotguns"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("sniper_rifles"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("beam_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle")
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("swords"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("no_power_weapons"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spike_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("carbine")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("needler")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("brute_shot")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sentinel_beam")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("excavator")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("excavator_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("excavator_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("excavator_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v3"),
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("no_snipers"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spike_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("carbine")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("needler")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("brute_shot")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("fuel_rod_gun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sentinel_beam")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("excavator")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("flamethrower")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("missile_pod")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("excavator_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("excavator_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("excavator_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v3"),
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("no_weapons"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spike_rifle"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("carbine"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("energy_sword"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("needler"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("shotgun"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("brute_shot"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("fuel_rod_gun"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sentinel_beam"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("beam_rifle"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("flamethrower"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("missile_pod"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v1"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v2"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v3"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v4"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v5"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v6"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v1"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v2"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v3"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v4"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v5"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v6"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v1"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v2"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v3"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v4"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v5"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v6"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v1"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v2"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v3"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v4"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v5"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v6"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v1"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v2"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v3"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v4"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v5"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v6"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v1"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v2"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v3"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v4"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v5"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v6"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v1"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v2"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v3"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v1"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v2"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v3"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v1"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v2"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v3"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("random"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("random")
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"base"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spike_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("carbine"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("energy_sword"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("needler"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("rocket_launcher"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("shotgun"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sniper_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("brute_shot"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("fuel_rod_gun"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("sentinel_beam"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("beam_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("spartan_laser"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("gravity_hammer"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("excavator"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("flamethrower"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("missile_pod"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("battle_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("assault_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("dmr"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("smg"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("carbine"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("carbine"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("carbine"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("carbine"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("carbine"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("carbine"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("excavator"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("excavator"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("excavator"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("magnum"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetOrAddString("plasma_pistol"),
                                },
                            },
                        },
                    },
                    VehicleSets = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("default"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("no_vehicles"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("ghost"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("scorpion"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("wraith"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("mongoose"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("banshee"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("chopper"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("mauler"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("hornet"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("mongoose_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("hornet_lite"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("scorpion_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("ghost_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_gauss"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_01"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_02"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_03"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_04"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_05"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_06"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_07"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("wraith1"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("mongooses_only"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("ghost"),
                                    SubstitutedVehicle = CacheContext.StringTable.GetOrAddString("mongoose")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("scorpion"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("wraith"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("banshee"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("chopper"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("mauler"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("hornet"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("hornet_lite"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("scorpion_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("ghost_snow"),
                                    SubstitutedVehicle = CacheContext.StringTable.GetOrAddString("mongoose_snow"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_gauss"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_01"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_02"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_03"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_04"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_05"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_06"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_07"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("wraith1"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("light_ground_only"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("scorpion"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("wraith"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("banshee"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("hornet"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("hornet_lite"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("scorpion_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("wraith1"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("tanks_only"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("ghost"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("mongoose"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("banshee"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("chopper"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("mauler"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("hornet"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("mongoose_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("hornet_lite"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("ghost_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_gauss"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_01"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_02"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_03"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_04"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_05"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_06"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_07"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("aircraft_only"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("ghost"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("scorpion"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("wraith"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("mongoose"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("chopper"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("mauler"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("mongoose_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("scorpion_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("ghost_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_gauss"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_01"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_02"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_03"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_04"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_05"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_06"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_07"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("wraith1"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("no_light_ground"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("ghost"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("mongoose"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("chopper"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("mauler"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("mongoose_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("ghost_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_gauss"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_01"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_02"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_03"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_04"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_05"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_06"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("warthog_07"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("no_tanks"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("scorpion"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("wraith"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("scorpion_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("wraith1"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("no_aircraft"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("banshee"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("hornet"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetOrAddString("hornet_lite"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                        {
                            Name = CacheContext.StringTable.GetOrAddString("all_vehicles"),
                        }
                    },
                    PodiumAnimations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation>
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation
                        {
                            AnimationGraph = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\masterchief_podium"),
                            DefaultUnarmed = StringId.Invalid,
                            DefaultArmed = StringId.Invalid,
                            StanceAnimations = null,
                            MoveAnimations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = $@"podium_stance_standard",
                                    InAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:standard"),
                                    LoopAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:standard_loop"),
                                    OutAnimation = StringId.Invalid,
                                    Offset = 0f,
                                    CustomPrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle"),
                                    CustomSecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = $@"podium_stance_assault",
                                    InAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:assault"),
                                    LoopAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:assault_loop"),
                                    OutAnimation = StringId.Invalid,
                                    Offset = 0.04f,
                                    CustomPrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle"),
                                    CustomSecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = $@"podium_stance_gameover",
                                    InAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:game_over"),
                                    LoopAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:game_over_loop"),
                                    OutAnimation = StringId.Invalid,
                                    Offset = 0f,
                                    CustomPrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle"),
                                    CustomSecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = $@"podium_stance_ready",
                                    InAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:ready"),
                                    LoopAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:ready_loop"),
                                    OutAnimation = StringId.Invalid,
                                    Offset = 0.1f,
                                    CustomPrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle"),
                                    CustomSecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = $@"podium_stance_relaxed",
                                    InAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:relaxed"),
                                    LoopAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:relaxed_loop"),
                                    OutAnimation = StringId.Invalid,
                                    Offset = 0f,
                                    CustomPrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle"),
                                    CustomSecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = $@"podium_stance_shoulder",
                                    InAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:shoulder"),
                                    LoopAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:shoulder_loop"),
                                    OutAnimation = StringId.Invalid,
                                    Offset = 0.15f,
                                    CustomPrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle"),
                                    CustomSecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum"),
                                },
                            },
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation
                        {
                            AnimationGraph = GetCachedTag<ModelAnimationGraph>($@"objects\characters\elite\elite_podium"),
                            DefaultUnarmed = StringId.Invalid,
                            DefaultArmed = StringId.Invalid,
                            StanceAnimations = null,
                            MoveAnimations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = $@"podium_e_stance_standard",
                                    InAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:standart"),
                                    LoopAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:standart_loop"),
                                    OutAnimation = StringId.Invalid,
                                    Offset = 0.5f,
                                    CustomPrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle"),
                                    CustomSecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = $@"podium_e_stance_charge",
                                    InAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:charge"),
                                    LoopAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:charge_loop"),
                                    OutAnimation = StringId.Invalid,
                                    Offset = 0.5f,
                                    CustomPrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle"),
                                    CustomSecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = $@"podium_e_stance_gameover",
                                    InAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:gameover"),
                                    LoopAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:gameover_loop"),
                                    OutAnimation = StringId.Invalid,
                                    Offset = 0.5f,
                                    CustomPrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle"),
                                    CustomSecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = $@"podium_e_stance_honor",
                                    InAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:honor"),
                                    LoopAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:honor_loop"),
                                    OutAnimation = StringId.Invalid,
                                    Offset = 0.5f,
                                    CustomPrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle"),
                                    CustomSecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = $@"podium_e_stance_watchman",
                                    InAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:watchman"),
                                    LoopAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:watchman_loop"),
                                    OutAnimation = StringId.Invalid,
                                    Offset = 0.5f,
                                    CustomPrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle"),
                                    CustomSecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = $@"podium_e_stance_zealot",
                                    InAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:zealot"),
                                    LoopAnimation = CacheContext.StringTable.GetOrAddString($@"combat:any:any:zealot_loop"),
                                    OutAnimation = StringId.Invalid,
                                    Offset = 0.5f,
                                    CustomPrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle"),
                                    CustomSecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                                },
                            },
                        },
                    },
                    GameEngineSettings = GetCachedTag<GameEngineSettingsDefinition>($@"multiplayer\game_engine_settings"),
                },
            };
            mulg.Runtime = new List<MultiplayerGlobals.MultiplayerRuntimeBlock>()
            {
                new MultiplayerGlobals.MultiplayerRuntimeBlock()
                {
                    EditorBiped = GetCachedTag<Biped>($@"objects\characters\monitor\monitor_editor"),
                    EditorHelperObject = GetCachedTag<Scenery>($@"objects\ui\editor_gizmo\editor_gizmo"),
                    Flag = GetCachedTag<Weapon>($@"objects\weapons\multiplayer\flag\flag"),
                    Ball = GetCachedTag<Weapon>($@"objects\weapons\multiplayer\ball\ball"),
                    Bomb = GetCachedTag<Weapon>($@"objects\weapons\multiplayer\assault_bomb\assault_bomb"),
                    VipInfluenceArea = GetCachedTag<Crate>($@"objects\multi\vip\vip_boundary"),
                    InGameStrings = GetCachedTag<MultilingualUnicodeStringList>($@"multiplayer\in_game_multiplayer_messages"),
                    HaloOnlineRuntimeEffects = new MultiplayerGlobals.MultiplayerRuntimeBlock.HORuntimeFxStruct()
                    {
                        ThusIRefuteTheeEffect = GetCachedTag<Projectile>($@"objects\weapons\grenade\plasma_grenade\plasma_grenade2"),
                        AutoFlipEffect = GetCachedTag<Effect>($@"multiplayer\vehicle_autoflip"),
                        SafetyBoosterEffect = GetCachedTag<Effect>($@"multiplayer\safety_booster"),
                        RespawnBeep = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\player_respawn"),
                        EarlyRespawnSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\transport"),
                    },
                    Sounds = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.Sound>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.Sound
                        {
                            Type = GetCachedTag<Sound>($@"sound\game_sfx\ui\death_gurgle"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.Sound
                        {
                            Type = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\comm_fail"),
                        }
                    },
                    LoopingSounds = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.LoopingSound>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.LoopingSound
                        {
                            Type = GetCachedTag<SoundLooping>($@"sound\game_sfx\multiplayer\comm_loop_mp\comm_loop_mp"),
                        }
                    },
                    EarnWpEvents = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_kill"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_kill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_assist"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_assist"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_perfection"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_perfection"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_extermination"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_extermination"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_multikill_2"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_multikill_x2"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_multikill_3"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_multikill_x3"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_multikill_4"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_multikill_x4"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_multikill_5"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_multikill_x5"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_multikill_6"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_multikill_x6"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_multikill_7"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_multikill_x7"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_multikill_8"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_multikill_x8"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_multikill_9"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_multikill_x9"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_multikill_10"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_multikill_x10"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_bash_kill"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_kill_bash"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_bashbehind_kill"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_kill_bash_behind"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_kill_sniper"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_kill_sniper"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_stickygrenade_kill"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_kill_sticky_grenade"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_spartanlaser_kill"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_kill_laser"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_oddball_carrier_kill_player"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_kill_oddball"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_ctf_flag_carrier_kill_player"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_kill_flag"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_flame_kill"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_kill_flame"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_player_kill_spreeplayer"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_broke_killing_spree"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_deadplayer_kill"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_from_the_grave"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_vehicle_impact_kill"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_splatter"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_vehicle_hijack"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_hijack"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_shotgun_kill_sword"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_bulltrue"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_driver_assist_gunner"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_assist_to_driver"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_aircraft_hijack"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_skyjack"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_ctf_flag_player_kill_carrier"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_kill_flag_carrier"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_ctf_flag_captured"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_flag_capture"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_koth_5"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_hill_kill_5x"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_revenge"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_revenge"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_flag_grabbed_from_stand"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_flag_grabbed_from_stand"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_flag_returned_by_player"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_flag_returned_by_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_5_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_5_in_a_row"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_10_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_10_in_a_row"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_15_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_15_in_a_row"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_20_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_20_in_a_row"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_25_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_25_in_a_row"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_30_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_30_in_a_row"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_vehicle_5"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_splatter_5x"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetOrAddString($@"earn_wp_event_headshot"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"wp_headshot"),
                        },
                    },
                    GeneralEvents = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_round_over"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_round_over_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\round_over"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_suicide"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_suicide_cause_player"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\suicide"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_suicide"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_suicide_cause_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_teammate"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_teammate_effect_player"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\betrayed"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_teammate"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_teammate_cause_player"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\betrayal"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_teammate"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_teammate_cause_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_victory"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_victory_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\game_over"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_team_victory"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_team_victory_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\game_over"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_gained_lead"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_gained_lead_all"),
                            RequiredField = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CausePlayer,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_gained_lead"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_gained_lead_cause_player"),
                            SplitscreenSuppression = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CausePlayer,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\gained_the_lead"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_gained_team_lead"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_gained_team_lead_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_gained_team_lead"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_gained_team_lead_cause_team"),
                            SplitscreenSuppression = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CausePlayer,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\gained_the_lead"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_lost_lead"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            SplitscreenSuppression = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CausePlayer,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_lost_team_lead"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            SplitscreenSuppression = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CausePlayer,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_tied_leader"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_tied_leader"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_tied_team_leader"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_tied_team_leader"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_30_minutes_left"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_30_minutes_left_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\thirty_mins_remaining"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_15_minutes_left"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_15_minutes_left_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\fifteen_mins_remaining"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_5_minutes_left"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_5_minutes_left_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\five_mins_remaining"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_1_minute_left"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_1_minute_left_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\one_min_remaining"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_game_over"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_game_over_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\game_over"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_player_quit"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_player_quit_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_player_joined"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_player_joined_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_player_rejoined"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_player_rejoined_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_killed_by_unknown"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_killed_by_unknown_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_respawn_tick"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            EnglishSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\countdown_for_respawn"),
                            JapaneseSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\countdown_for_respawn"),
                            GermanSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\countdown_for_respawn"),
                            FrenchSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\countdown_for_respawn"),
                            SpanishSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\countdown_for_respawn"),
                            LatinAmericanSpanishSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\countdown_for_respawn"),
                            ItalianSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\countdown_for_respawn"),
                            KoreanSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\countdown_for_respawn"),
                            ChineseTraditionalSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\countdown_for_respawn"),
                            PortugueseSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\countdown_for_respawn"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_respawn_final_tick"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            EnglishSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\player_respawn"),
                            JapaneseSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\player_respawn"),
                            GermanSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\player_respawn"),
                            FrenchSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\player_respawn"),
                            SpanishSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\player_respawn"),
                            LatinAmericanSpanishSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\player_respawn"),
                            ItalianSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\player_respawn"),
                            KoreanSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\player_respawn"),
                            ChineseTraditionalSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\player_respawn"),
                            PortugueseSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\player_respawn"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_teleporter_used"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            EnglishSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\teleporter_activate"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_player_switched_team"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_player_changed_team_effect_team"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\teamate_gained"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_player_switched_team"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_player_changed_team_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_30_seconds_left"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_30_seconds_left_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\thirty_secs_remaining"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_10_seconds_left"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_10_seconds_left_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\ten_secs_remaining"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_collision"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_col_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_collision"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_col_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_collision"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_col_effect_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_collision"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_col_cause_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_melee"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_melee_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_melee"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_melee_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_melee"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_melee_effect_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_melee"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_melee_cause_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_killed_by_falling"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_killed_by_falling_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_sudden_death"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            PrimaryString = CacheContext.StringTable.GetOrAddString($@"gen_sudden_death_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\sudden_death"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_sticky_grenade"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_sticky_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_sticky_grenade"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_sticky_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_sticky_grenade"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_sticky_effect_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_sticky_grenade"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_sticky_cause_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_sniper"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_sniper_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_sniper"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_sniper_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_sniper"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_sniper_effect_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_sniper"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_sniper_cause_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_stealth_melee"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_sneak_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_stealth_melee"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_sneak_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_stealth_melee"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_sneak_effect_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_stealth_melee"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_sneak_cause_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_boarded_vehicle"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_boarded_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_boarded_vehicle"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_boarded_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_player_booted_player"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_player_booted_player_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_game_start_team_notification"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_start_team_notice_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_teleporter_telefrag"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_telefrag_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_flag_carrier"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_kill_carrier_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_flag_carrier"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_kill_carrier_ep"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_flag_carrier"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_kill_carrier_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_flag_carrier"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_kill_carrier_et"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_bomb_carrier"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"assault_kill_carrier_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_bomb_carrier"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"assault_kill_carrier_ep"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_bomb_carrier"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"assault_kill_carrier_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_bomb_carrier"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"assault_kill_carrier_et"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_collision"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_col_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_shotgun_kill_sword"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_bulltrue_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_deadplayer"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_deadplayer_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_deadplayer"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_deadplayer_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_vehicle_hijack"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_hijack_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_vehicle_hijack"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_hijack_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_aircraft_hijack"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_skyjack_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_aircraft_hijack"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_skyjack_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_spartanlaser"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_spartanlaser_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_spartanlaser"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_spartanlaser_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_flame"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_flame_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_flame"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_flame_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_occupied_vehicle_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_driver_assist_gunner"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_driverassist_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_driver_assist_gunner"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_driverassist_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_teleporter_blocked"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"game_engine_blocked_teleporter"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_spartanlaser"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_effect_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_spartanlaser"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_cause_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_flame"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_cause_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_flame"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_effect_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_teammate"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_teammate_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_collision"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_col_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_melee"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_melee_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_sticky_grenade"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_sticky_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_sniper"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_sniper_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_stealth_melee"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_sneak_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_flag_carrier"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_kill_carrier_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_bomb_carrier"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"assault_kill_carrier_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_spartanlaser"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_spartanlaser_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_flame"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_flame_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_kill_deadplayer"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_kill_deadplayer_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetOrAddString($@"general_event_suicide"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"gen_suicide_cause_team"),
                        },

                    },
                    FlavorEvents = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_extermination"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_extermination"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_extermination"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\extermination"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_perfection"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_perfection"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_perfection"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\misc\perfection"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_multikill_2"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_multikill_2"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_multikill_2"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\double_kill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_multikill_3"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_multikill_3"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_multikill_3"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\triple_kill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_multikill_4"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_multikill_4"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_multikill_4"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\overkill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_multikill_5"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_multikill_5"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_multikill_5"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\killtacular"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_multikill_6"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_multikill_6"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_multikill_6"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\killtrocity"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_multikill_7"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_multikill_7"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_multikill_7"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\killimanjaro"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_multikill_8"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_multikill_8"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_multikill_8"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\killtastrophe"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_multikill_9"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_multikill_9"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_multikill_9"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\killpocalypse"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_multikill_10"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_multikill_10"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_multikill_10"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\killionaire"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_5_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_kill_spree_5"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_kill_spree_5"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\killing_spree"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_10_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_kill_spree_10"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_kill_spree_10"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\killing_frenzy"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_15_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_kill_spree_15"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_kill_spree_15"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\running_riot"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_20_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_kill_spree_20"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_kill_spree_20"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\rampage"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_25_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_kill_spree_25"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_kill_spree_25"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\untouchable"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_30_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_kill_spree_30"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_kill_spree_30"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\invincible"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_sniper_5"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_sniper_5"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_sniper_5"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\sniper_spree"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_sniper_10"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_sniper_10"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_sniper_10"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\sharpshooter"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_shotgun_5"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_shotgun_5"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_shotgun_5"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\shotgun_spree"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_shotgun_10"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_shotgun_10"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_shotgun_10"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\open_season"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_vehicle_5"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_splatter_5"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_splatter_5"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\splatter_spree"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_vehicle_10"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_splatter_10"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_splatter_10"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\vehicular_manslaughter"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_sword_5"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_sword_5"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_sword_5"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\sword_spree"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_sword_10"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_sword_10"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_sword_10"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\slice_n_dice"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_juggernaut_5"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_juggernaut_5"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_juggernaut_5"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\juggernaut_spree"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_juggernaut_10"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_juggernaut_10"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_juggernaut_10"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\unstoppable"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_zombie_5"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_zombie_5"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_zombie_5"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\infection_spree"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_zombie_10"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_zombie_10"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_zombie_10"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\mmm_brains"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_human_5"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_survivor_5"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_survivor_5"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\zombie_killing_spree"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_human_10"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_survivor_10"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_survivor_10"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\hells_janitor"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_human_15"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_koth_5"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_koth_5"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_koth_5"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\hail_to_the_king"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_shotgun_kill_sword"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_shotgun_kill_sword"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_vehicle_impact_kill"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_vehicle_impact_kill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_vehicle_hijack"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_vehicle_hijack"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_aircraft_hijack"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_aircraft_hijack"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_deadplayer_kill"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_deadplayer_kill_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_player_kill_spreeplayer"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_broke_killing_spree_cause_player"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_player_kill_spreeplayer"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\killjoy"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_player_kill_spreeplayer"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_broke_killing_spree_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_spartanlaser_kill"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_spartanlaser_kill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_stickygrenade_kill"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_stickygrenade_kill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_sniper_kill"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_sniper_kill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_bashbehind_kill"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_bashbehind_kill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_bash_kill"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_bash_kill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_flame_kill"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_flame_kill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_extermination"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_player_kill_occupiedvehicle"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_driver_assist_gunner"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_driver_assist_gunner"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_assault_bomb_planted"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_assault_bomb_planted"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_assault_player_kill_carrier"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_assault_player_kill_carrier"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_vip_player_kill_vip"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_vip_player_kill_vip"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_juggernaut_player_kill_juggernaut"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_juggernaut_player_kill_juggernaut"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_oddball_carrier_kill_player"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_oddball_carrier_kill_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_ctf_flag_captured"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_ctf_flag_captured"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_ctf_flag_player_kill_carrier"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_ctf_flag_player_kill_carrier"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_ctf_flag_carrier_kill_player"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_ctf_flag_carrier_kill_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_infection_survive"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_infection_survive"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_nemesis"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_nemesis"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_nemesis"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_event_avenger"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"flavor_revenge"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_revenge"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_forge_cannot_place_object"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"forge_error_no_room"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\game_sfx\ui\flag_fail"),
                            JapaneseSound = GetCachedTag<Sound>($@"sound\game_sfx\ui\flag_fail"),
                            GermanSound = GetCachedTag<Sound>($@"sound\game_sfx\ui\flag_fail"),
                            FrenchSound = GetCachedTag<Sound>($@"sound\game_sfx\ui\flag_fail"),
                            SpanishSound = GetCachedTag<Sound>($@"sound\game_sfx\ui\flag_fail"),
                            LatinAmericanSpanishSound = GetCachedTag<Sound>($@"sound\game_sfx\ui\flag_fail"),
                            ItalianSound = GetCachedTag<Sound>($@"sound\game_sfx\ui\flag_fail"),
                            KoreanSound = GetCachedTag<Sound>($@"sound\game_sfx\ui\flag_fail"),
                            ChineseTraditionalSound = GetCachedTag<Sound>($@"sound\game_sfx\ui\flag_fail"),
                            ChineseSimplifiedSound = GetCachedTag<Sound>($@"sound\game_sfx\ui\flag_fail"),
                            PortugueseSound = GetCachedTag<Sound>($@"sound\game_sfx\ui\flag_fail"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetOrAddString($@"flavor_forge_theoretical_object_limit_reached"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"forge_error_out_of_objects"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\game_sfx\ui\flag_fail"),
                            JapaneseSound = GetCachedTag<Sound>($@"sound\game_sfx\ui\flag_fail"),
                            GermanSound = GetCachedTag<Sound>($@"sound\game_sfx\ui\flag_fail"),
                            FrenchSound = GetCachedTag<Sound>($@"sound\game_sfx\ui\flag_fail"),
                            SpanishSound = GetCachedTag<Sound>($@"sound\game_sfx\ui\flag_fail"),
                            LatinAmericanSpanishSound = GetCachedTag<Sound>($@"sound\game_sfx\ui\flag_fail"),
                            ItalianSound = GetCachedTag<Sound>($@"sound\game_sfx\ui\flag_fail"),
                            KoreanSound = GetCachedTag<Sound>($@"sound\game_sfx\ui\flag_fail"),
                            ChineseTraditionalSound = GetCachedTag<Sound>($@"sound\game_sfx\ui\flag_fail"),
                            ChineseSimplifiedSound = GetCachedTag<Sound>($@"sound\game_sfx\ui\flag_fail"),
                            PortugueseSound = GetCachedTag<Sound>($@"sound\game_sfx\ui\flag_fail"),
                        },
                    },
                    SlayerEvents = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Slayer,
                            Event = CacheContext.StringTable.GetOrAddString($@"slayer_event_game_start"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"slayer_game_start"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\slayer\slayer"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Slayer,
                            Event = CacheContext.StringTable.GetOrAddString($@"slayer_event_new_target"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"slayer_new_target"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\slayer\target_changed"),
                        },
                    },
                    CtfEvents = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetOrAddString($@"ctf_event_game_start"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_game_start"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\capture_the_flag"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetOrAddString($@"ctf_event_flag_new_defensive_team"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_new_defensive_team"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\offense"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetOrAddString($@"ctf_event_flag_new_defensive_team"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_new_defensive_team_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\defense"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetOrAddString($@"ctf_event_flag_captured"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_flag_captured"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_captured"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetOrAddString($@"ctf_event_flag_captured"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_flag_captured"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_captured"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetOrAddString($@"ctf_event_flag_captured"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_flag_captured_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_captured"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetOrAddString($@"ctf_event_flag_returned_by_timeout"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_flag_reset"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_reset"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetOrAddString($@"ctf_event_flag_returned_by_timeout"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_flag_reset_et"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_reset"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetOrAddString($@"ctf_event_flag_returned_by_player"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_flag_recovered"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_recovered"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetOrAddString($@"ctf_event_flag_returned_by_player"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_flag_recovered_et"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_recovered"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetOrAddString($@"ctf_event_flag_taken"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_flag_grabbed_ct"),
                            SplitscreenSuppression = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CauseTeam,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_taken"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetOrAddString($@"ctf_event_flag_taken"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_flag_grabbed_cp"),
                            SplitscreenSuppression = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CauseTeam,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_taken"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetOrAddString($@"ctf_event_flag_taken"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_flag_grabbed_et"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_stolen"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetOrAddString($@"ctf_event_flag_dropped"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_flag_dropped"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetOrAddString($@"ctf_event_flag_dropped"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_flag_dropped_et"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetOrAddString($@"ctf_event_flag_capture_faliure"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_failed_capture_cp"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetOrAddString($@"ctf_event_flag_grabbed_from_stand"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_flag_grabbed_ct"),
                            SplitscreenSuppression = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CauseTeam,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_taken"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetOrAddString($@"ctf_event_flag_grabbed_from_stand"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_flag_grabbed_cp"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_flag_grab"),
                            SplitscreenSuppression = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CauseTeam,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_taken"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetOrAddString($@"ctf_event_flag_grabbed_from_stand"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"ctf_flag_grabbed_et"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_stolen"),
                        },
                    },
                    OddballEvents = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetOrAddString($@"oddball_event_game_start"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"oddball_game_start"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\oddball\oddball"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetOrAddString($@"oddball_event_ball_picked_up"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"oddball_picked_up"),
                            ExcludedAudience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CausePlayer,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\oddball\ball_taken"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetOrAddString($@"oddball_event_ball_picked_up"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"oddball_picked_up"),
                            ExcludedAudience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CausePlayer,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\oddball\ball_taken"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetOrAddString($@"oddball_event_ball_dropped"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"oddball_dropped"),
                            ExcludedAudience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CausePlayer,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\oddball\ball_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetOrAddString($@"oddball_event_ball_spawned"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"oddball_spawned"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\oddball\play_ball"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetOrAddString($@"oddball_event_ball_reset"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"oddball_reset"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\oddball\ball_reset"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetOrAddString($@"oddball_event_25_points_remaining"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\twenty_five_points_remaining"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetOrAddString($@"oddball_event_25_points_remaining"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\twenty_five_points_to_win"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetOrAddString($@"oddball_event_25_points_remaining"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\twenty_five_points_to_win"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetOrAddString($@"oddball_event_10_points_remaining"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\ten_points_remaining"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetOrAddString($@"oddball_event_10_points_remaining"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\ten_points_to_win"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetOrAddString($@"oddball_event_10_points_remaining"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\ten_points_to_win"),
                        },
                    },
                    KingOfTheHillEvents = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.KingOfTheHill,
                            Event = CacheContext.StringTable.GetOrAddString($@"king_event_game_start"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"koth_game_start"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\king_of_the_hill\king_of_the_hill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.KingOfTheHill,
                            Event = CacheContext.StringTable.GetOrAddString($@"king_event_hill_move"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\king_of_the_hill\hill_moved"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.KingOfTheHill,
                            Event = CacheContext.StringTable.GetOrAddString($@"king_event_hill_controlled"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"koth_hill_controlled"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.KingOfTheHill,
                            Event = CacheContext.StringTable.GetOrAddString($@"king_event_hill_controlled"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"koth_hill_controlled_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\king_of_the_hill\hill_controlled"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.KingOfTheHill,
                            Event = CacheContext.StringTable.GetOrAddString($@"king_event_hill_controlled_team"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"koth_hill_controlled_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.KingOfTheHill,
                            Event = CacheContext.StringTable.GetOrAddString($@"king_event_hill_controlled_team"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"koth_hill_controlled_team_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\king_of_the_hill\hill_controlled"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.KingOfTheHill,
                            Event = CacheContext.StringTable.GetOrAddString($@"king_event_hill_contested"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.KingOfTheHill,
                            Event = CacheContext.StringTable.GetOrAddString($@"king_event_hill_contested"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"koth_hill_contested_cp"),
                            SplitscreenSuppression = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CausePlayer,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\king_of_the_hill\hill_contested"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.KingOfTheHill,
                            Event = CacheContext.StringTable.GetOrAddString($@"king_event_hill_contested_team"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.KingOfTheHill,
                            Event = CacheContext.StringTable.GetOrAddString($@"king_event_hill_contested_team"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"koth_hill_contested_team_ct"),
                            SplitscreenSuppression = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CausePlayer,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\king_of_the_hill\hill_contested"),
                        },
                    },
                    VipEvents = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetOrAddString($@"vip_event_game_start"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"vip_game_start"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetOrAddString($@"vip_event_side_switch"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"vip_new_defensive_team"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\offense"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetOrAddString($@"vip_event_side_switch"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"vip_new_defensive_game_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\defense"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetOrAddString($@"vip_event_new_vip"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"vip_new_vip"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\vip\new_vip"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetOrAddString($@"vip_event_new_vip"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"vip_new_vip_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\vip\new_vip"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetOrAddString($@"vip_event_vip_killed"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"vip_killed_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\vip\vip_killed"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetOrAddString($@"vip_event_vip_killed"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"vip_killed_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\vip\vip_killed"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetOrAddString($@"vip_event_vip_killed"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"vip_killed_et"),
                            ExcludedAudience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.EffectPlayer,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\vip\vip_killed"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetOrAddString($@"vip_event_vip_died"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"vip_death"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetOrAddString($@"vip_event_vip_died"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"vip_death_et"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetOrAddString($@"vip_event_reached_destination_area"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"vip_destination_arrived"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetOrAddString($@"vip_event_reached_destination_area"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"vip_destination_arrived_cp"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetOrAddString($@"vip_event_destination_area_moved"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"jugg_destination_moved"),
                            SplitscreenSuppression = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.EffectPlayer,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\juggernaut\destination_moved"),
                        },
                    },
                    JuggernautEvents = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Juggernaut,
                            Event = CacheContext.StringTable.GetOrAddString($@"juggernaut_event_game_start"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"jugg_game_start"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\juggernaut\juggernaut"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Juggernaut,
                            Event = CacheContext.StringTable.GetOrAddString($@"juggernaut_event_new_juggernaut"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"jugg_new_juggernaut"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\juggernaut\new_juggernaut"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Juggernaut,
                            Event = CacheContext.StringTable.GetOrAddString($@"juggernaut_event_new_juggernaut"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"jugg_new_juggernaut_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\juggernaut\new_juggernaut"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Juggernaut,
                            Event = CacheContext.StringTable.GetOrAddString($@"juggernaut_event_zone_moved"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"jugg_destination_moved"),
                            SplitscreenSuppression = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.EffectPlayer,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\juggernaut\destination_moved"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Juggernaut,
                            Event = CacheContext.StringTable.GetOrAddString($@"juggernaut_event_player_kill_juggernaut"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"jugg_kill"),
                            ExcludedAudience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.EffectPlayer,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Juggernaut,
                            Event = CacheContext.StringTable.GetOrAddString($@"juggernaut_event_player_kill_juggernaut"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"jugg_kill_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                        },
                    },
                    TerritoriesEvents = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Territories,
                            Event = CacheContext.StringTable.GetOrAddString($@"territories_event_game_start"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"terr_game_start"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\territories\territories"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Territories,
                            Event = CacheContext.StringTable.GetOrAddString($@"territories_event_side_switch"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"terr_new_defensive_team"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\offense"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Territories,
                            Event = CacheContext.StringTable.GetOrAddString($@"territories_event_side_switch"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"terr_new_defensive_team_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\defense"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Territories,
                            Event = CacheContext.StringTable.GetOrAddString($@"territories_event_territory_captured"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"terr_captured"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\territories\territory_captured"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Territories,
                            Event = CacheContext.StringTable.GetOrAddString($@"territories_event_territory_captured"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"terr_captured_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\territories\territory_captured"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Territories,
                            Event = CacheContext.StringTable.GetOrAddString($@"territories_event_territory_captured"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"terr_captured_et"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\territories\territory_lost"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Territories,
                            Event = CacheContext.StringTable.GetOrAddString($@"territories_event_territory_captured"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"terr_captured_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\territories\territory_captured"),
                        },
                    },
                    AssaultEvents = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetOrAddString($@"assault_event_game_start"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"assault_game_start"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\assault"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetOrAddString($@"assault_event_bomb_taken"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_taken"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetOrAddString($@"assault_event_bomb_taken"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"assault_bomb_pickup_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_taken"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetOrAddString($@"assault_event_bomb_dropped"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetOrAddString($@"assault_event_bomb_dropped"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"assault_bomb_dropped_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetOrAddString($@"assault_event_bomb_returned_by_player"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"assault_bomb_returned"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_returned"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetOrAddString($@"assault_event_bomb_returned_by_player"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"assault_bomb_returned_cp"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_bomb_return"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_returned"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetOrAddString($@"assault_event_bomb_returned_by_player"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"assault_bomb_returned_et"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_returned"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetOrAddString($@"assault_event_bomb_returned_by_timeout"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"assault_bomb_reset"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_reset"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetOrAddString($@"assault_event_bomb_returned_by_timeout"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"assault_bomb_reset_et"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_reset"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetOrAddString($@"assault_event_bomb_placed_on_enemy_post"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"assault_bomb_armed"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_armed"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetOrAddString($@"assault_event_bomb_placed_on_enemy_post"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"assault_bomb_armed_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_armed"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetOrAddString($@"assault_event_bomb_placed_on_enemy_post"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"assault_bomb_armed_cp"),
                            MedalAward = CacheContext.StringTable.GetOrAddString($@"medal_bomb_planted"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_armed"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetOrAddString($@"assault_event_bomb_captured"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"assault_bomb_detonated"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_detonated"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetOrAddString($@"assault_event_bomb_captured"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"assault_bomb_detonated_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_detonated"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetOrAddString($@"assault_event_bomb_disarmed"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"assault_bomb_disarmed"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_disarmed"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetOrAddString($@"assault_event_bomb_disarmed"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"assault_bomb_disarmed_et"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_disarmed"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetOrAddString($@"assault_event_bomb_disarmed"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"assault_bomb_disarmed_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_disarmed"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetOrAddString($@"assault_event_neutral_bomb_returned"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"assault_bomb_neutral_reset"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_reset"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetOrAddString($@"assault_event_last_player_on_team"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"inf_last_man"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                        },
                    },
                    InfectionEvents = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Infection,
                            Event = CacheContext.StringTable.GetOrAddString($@"infection_event_game_start"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"inf_game_start"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Infection,
                            Event = CacheContext.StringTable.GetOrAddString($@"infection_event_new_infection"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"inf_new_infection_cp"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Infection,
                            Event = CacheContext.StringTable.GetOrAddString($@"infection_event_new_infection"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"inf_new_infection_ct"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Infection,
                            Event = CacheContext.StringTable.GetOrAddString($@"infection_event_new_infection"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"inf_new_infection_et"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Infection,
                            Event = CacheContext.StringTable.GetOrAddString($@"infection_event_new_infection"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"inf_new_infection_ep"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\infection\infected"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Infection,
                            Event = CacheContext.StringTable.GetOrAddString($@"infection_event_zombie_spawn"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"inf_new_zombie"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\infection\new_zombie"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Infection,
                            Event = CacheContext.StringTable.GetOrAddString($@"infection_event_zombie_spawn"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"inf_new_zombie_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\infection\new_zombie"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Infection,
                            Event = CacheContext.StringTable.GetOrAddString($@"infection_event_survive"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"inf_last_man_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\infection\last_man_standing"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Infection,
                            Event = CacheContext.StringTable.GetOrAddString($@"infection_event_survive"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"inf_last_man"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Infection,
                            Event = CacheContext.StringTable.GetOrAddString($@"infection_event_alpha_zombie_spawn"),
                            DisplayString = CacheContext.StringTable.GetOrAddString($@"inf_new_alpha"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\infection\infected"),
                        },
                    },
                    MaximumFragCount = 4,
                    MaximumPlasmaCount = 4,
                    MultiplayerConstants = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant
                        {
                            ForbidEnemySpawnConstants = new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.SpawnConstantStruct
                            {
                                FullWeightRadius = 3.5f,
                                FalloffRadius = 3.5f,
                                CylinderUpperHeight = 1f,
                                CylinderLowerHeight = -1.2f,
                                Weight = -1000f,
                            },
                            EnemySpawnBiasConstants = new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.SpawnConstantStruct
                            {
                                FullWeightRadius = 8f,
                                FalloffRadius = 12f,
                                CylinderUpperHeight = 2f,
                                CylinderLowerHeight = -3f,
                                Weight = -200f,
                            },
                            AllySpawnBias = new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.SpawnConstantStruct
                            {
                                FalloffRadius = 7.5f,
                                CylinderUpperHeight = 2f,
                                CylinderLowerHeight = -2f,
                                Weight = 100f,
                            },
                            SpectatedAllySpawnBias = new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.SpawnConstantStruct
                            {
                                FalloffRadius = 7.5f,
                                CylinderUpperHeight = 2f,
                                CylinderLowerHeight = -2f,
                                Weight = 150f,
                            },
                            ForbidAllySpawnConstants = new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.SpawnConstantStruct
                            {
                                FullWeightRadius = 15f,
                                FalloffRadius = 15f,
                                CylinderUpperHeight = 5f,
                                CylinderLowerHeight = -5f,
                                Weight = -500f,
                            },
                            DeadTeammateInfluenceDuration = 20f,
                            Weapons = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence>()
                            {
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\sniper_rifle\sniper_rifle"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\beam_rifle\beam_rifle"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\support_high\spartan_laser\spartan_laser"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\support_high\rocket_launcher\rocket_launcher"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\vehicles\warthog\turrets\chaingun\weapon\chaingun_turret"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\turret\machinegun_turret\machinegun_turret"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\turret\machinegun_turret\machinegun_turret_integrated"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\turret\plasma_cannon\plasma_cannon"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\turret\plasma_cannon\plasma_cannon_integrated"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\vehicles\warthog\turrets\gauss\weapon\gauss_turret"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v1\battle_rifle_v1"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v2\battle_rifle_v2"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v3\battle_rifle_v3"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v4\battle_rifle_v4"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v5\battle_rifle_v5"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v6\battle_rifle_v6"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\dmr\dmr"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\dmr\dmr_v1\dmr_v1"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\dmr\dmr_v2\dmr_v2"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\dmr\dmr_v3\dmr_v3"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\dmr\dmr_v4\dmr_v4"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\dmr\dmr_v6\dmr_v6"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v1\covenant_carbine_v1"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v2\covenant_carbine_v2"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v3\covenant_carbine_v3"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v4\covenant_carbine_v4"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v5\covenant_carbine_v5"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.WeaponSpawnInfluence
                                {
                                    Weapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v6\covenant_carbine_v6"),
                                    FullWeightRadius = 5f,
                                    FalloffRadius = 15f,
                                    FalloffConeRadius = 3f,
                                    Weight = -10f,
                                },
                            },
                            Vehicles = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.VehicleSpawnInfluence>()
                            {
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.VehicleSpawnInfluence
                                {
                                    Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\ghost\ghost"),
                                    PillRadius = 2f,
                                    LeadTime = 1.5f,
                                    MinimumVelocity = 0.5f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.VehicleSpawnInfluence
                                {
                                    Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog"),
                                    PillRadius = 2f,
                                    LeadTime = 1.5f,
                                    MinimumVelocity = 0.5f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.VehicleSpawnInfluence
                                {
                                    Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\banshee\banshee"),
                                    PillRadius = 2f,
                                    LeadTime = 1.5f,
                                    MinimumVelocity = 0.5f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.VehicleSpawnInfluence
                                {
                                    Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\mongoose\mongoose"),
                                    PillRadius = 1.5f,
                                    LeadTime = 1.5f,
                                    MinimumVelocity = 0.5f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.VehicleSpawnInfluence
                                {
                                    PillRadius = 3f,
                                    LeadTime = 1.5f,
                                    MinimumVelocity = 0f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.VehicleSpawnInfluence
                                {
                                    Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\brute_chopper\brute_chopper"),
                                    PillRadius = 3f,
                                    LeadTime = 1.5f,
                                    MinimumVelocity = 0.25f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.VehicleSpawnInfluence
                                {
                                    PillRadius = 2f,
                                    LeadTime = 1.5f,
                                    MinimumVelocity = 0.5f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.VehicleSpawnInfluence
                                {
                                    PillRadius = 2f,
                                    LeadTime = 1.5f,
                                    MinimumVelocity = 0.5f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.VehicleSpawnInfluence
                                {
                                    Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\hornet\hornet"),
                                    PillRadius = 2f,
                                    LeadTime = 1.5f,
                                    MinimumVelocity = 0.5f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.VehicleSpawnInfluence
                                {
                                    Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\scorpion\scorpion"),
                                    PillRadius = 3f,
                                    LeadTime = 1.5f,
                                    MinimumVelocity = 0.5f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.VehicleSpawnInfluence
                                {
                                    Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\wraith\wraith"),
                                    PillRadius = 3f,
                                    LeadTime = 1.5f,
                                    MinimumVelocity = 0.5f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.VehicleSpawnInfluence
                                {
                                    Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_snow"),
                                    PillRadius = 2f,
                                    LeadTime = 1.5f,
                                    MinimumVelocity = 0.5f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.VehicleSpawnInfluence
                                {
                                    PillRadius = 1.5f,
                                    LeadTime = 1.5f,
                                    MinimumVelocity = 0.5f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.VehicleSpawnInfluence
                                {
                                    Vehicle = GetCachedTag<Vehicle>($@"objects\levels\dlc\sidewinder\hornet_lite\hornet_lite"),
                                    PillRadius = 2f,
                                    LeadTime = 1.5f,
                                    MinimumVelocity = 0.5f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.VehicleSpawnInfluence
                                {
                                    PillRadius = 3f,
                                    LeadTime = 1.5f,
                                    MinimumVelocity = 0.5f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.VehicleSpawnInfluence
                                {
                                    PillRadius = 2f,
                                    LeadTime = 1.5f,
                                    MinimumVelocity = 0.5f,
                                    Weight = -1000f,
                                },
                            },
                            Projectiles = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.ProjectileSpawnInfluence>()
                            {
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.ProjectileSpawnInfluence
                                {
                                    Projectile = GetCachedTag<Projectile>($@"objects\weapons\grenade\frag_grenade\frag_grenade"),
                                    LeadTime = 1f,
                                    CollisionCylinderRadius = 3f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.ProjectileSpawnInfluence
                                {
                                    Projectile = GetCachedTag<Projectile>($@"objects\weapons\grenade\plasma_grenade\plasma_grenade"),
                                    LeadTime = 1f,
                                    CollisionCylinderRadius = 3f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.ProjectileSpawnInfluence
                                {
                                    Projectile = GetCachedTag<Projectile>($@"objects\vehicles\banshee\weapon\banshee_bomb"),
                                    LeadTime = 2f,
                                    CollisionCylinderRadius = 3f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.ProjectileSpawnInfluence
                                {
                                    Projectile = GetCachedTag<Projectile>($@"objects\weapons\grenade\claymore_grenade\claymore_grenade"),
                                    LeadTime = 1f,
                                    CollisionCylinderRadius = 3f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.ProjectileSpawnInfluence
                                {
                                    Projectile = GetCachedTag<Projectile>($@"objects\weapons\support_high\rocket_launcher\projectiles\rocket"),
                                    LeadTime = 2f,
                                    CollisionCylinderRadius = 3f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.ProjectileSpawnInfluence
                                {
                                    Projectile = GetCachedTag<Projectile>($@"objects\weapons\turret\missile_pod\projectiles\missile_pod_missile"),
                                    LeadTime = 1f,
                                    CollisionCylinderRadius = 3f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.ProjectileSpawnInfluence
                                {
                                    Projectile = GetCachedTag<Projectile>($@"objects\vehicles\wraith\turrets\mortar\mortar_turret_charged"),
                                    LeadTime = 2f,
                                    CollisionCylinderRadius = 3f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.ProjectileSpawnInfluence
                                {
                                    LeadTime = 1f,
                                    CollisionCylinderRadius = 3f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.ProjectileSpawnInfluence
                                {
                                    Projectile = GetCachedTag<Projectile>($@"objects\weapons\support_low\brute_shot\projectiles\grenade\grenade"),
                                    LeadTime = 1f,
                                    CollisionCylinderRadius = 3f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.ProjectileSpawnInfluence
                                {
                                    Projectile = GetCachedTag<Projectile>($@"objects\weapons\grenade\firebomb_grenade\projectiles\firebomb_grenade"),
                                    LeadTime = 1f,
                                    CollisionCylinderRadius = 3f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.ProjectileSpawnInfluence
                                {
                                    Projectile = GetCachedTag<Projectile>($@"objects\weapons\grenade\firebomb_grenade\projectiles\primary_impact"),
                                    LeadTime = 1f,
                                    CollisionCylinderRadius = 3f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.ProjectileSpawnInfluence
                                {
                                    Projectile = GetCachedTag<Projectile>($@"objects\vehicles\hornet\weapon\hornet_missile"),
                                    LeadTime = 1f,
                                    CollisionCylinderRadius = 3f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.ProjectileSpawnInfluence
                                {
                                    Projectile = GetCachedTag<Projectile>($@"objects\weapons\support_high\flak_cannon\projectiles\flak_bolt\flak_bolt"),
                                    LeadTime = 2f,
                                    CollisionCylinderRadius = 3f,
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.ProjectileSpawnInfluence
                                {
                                    Projectile = GetCachedTag<Projectile>($@"objects\equipment\bombrun_equipment\projectiles\bombrun_grenade"),
                                    LeadTime = 1f,
                                    CollisionCylinderRadius = 3f,
                                    Weight = -1000f,
                                },
                            },
                            Equipment = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.EquipmentSpawnInfluence>()
                            {
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.EquipmentSpawnInfluence
                                {
                                    Equipment = GetCachedTag<Equipment>($@"objects\equipment\tripmine\tripmine"),
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.EquipmentSpawnInfluence
                                {
                                    Equipment = GetCachedTag<Equipment>($@"objects\equipment\powerdrain\powerdrain"),
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.EquipmentSpawnInfluence
                                {
                                    Equipment = GetCachedTag<Equipment>($@"objects\equipment\superflare\superflare"),
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.EquipmentSpawnInfluence
                                {
                                    Weight = -1000f,
                                },
                                new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.EquipmentSpawnInfluence
                                {
                                    Weight = -1000f,
                                },
                            },
                            GametypeSpawnConstants = new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.GametypeSpawnConstantStruct()
                            {
                                KingOfTheHill = new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.SpawnConstantStruct
                                {
                                    FullWeightRadius = 3f,
                                    FalloffRadius = 15f,
                                    CylinderUpperHeight = 10f,
                                    CylinderLowerHeight = -10f,
                                    Weight = -1000f,
                                },
                                Oddball = new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.SpawnConstantStruct
                                {
                                    FullWeightRadius = 3f,
                                    FalloffRadius = 15f,
                                    CylinderUpperHeight = 10f,
                                    CylinderLowerHeight = -10f,
                                    Weight = -1000f,
                                },
                                CaptureTheFlag = new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.SpawnConstantStruct
                                {
                                    FullWeightRadius = 3f,
                                    FalloffRadius = 5f,
                                    CylinderUpperHeight = 1f,
                                },
                                TeraSpawnConstants = new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.SpawnConstantStruct
                                {
                                    FullWeightRadius = 4f,
                                    FalloffRadius = 4f,
                                    CylinderUpperHeight = 1f,
                                    CylinderLowerHeight = -0.75f,
                                    Weight = 10000f,
                                },
                                Territories = new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.SpawnConstantStruct
                                {
                                    FullWeightRadius = 4f,
                                    FalloffRadius = 4f,
                                    CylinderUpperHeight = 1f,
                                    CylinderLowerHeight = -0.75f,
                                    Weight = -10005
                                },
                                InfectionHumans = new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.SpawnConstantStruct
                                {
                                    FullWeightRadius = 3f,
                                    FalloffRadius = 15f,
                                    CylinderUpperHeight = 10f,
                                    CylinderLowerHeight = -10f,
                                    Weight = 100f,
                                },
                                InfectionZombies = new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.SpawnConstantStruct
                                {
                                    FullWeightRadius = 3f,
                                    FalloffRadius = 15f,
                                    CylinderUpperHeight = 10f,
                                    CylinderLowerHeight = -10f,
                                    Weight = -1000f,
                                },
                                Vip = new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.SpawnConstantStruct
                                {
                                    FullWeightRadius = 1f,
                                    FalloffRadius = 2f,
                                    CylinderUpperHeight = 1f,
                                },
                            },
                            MaximumRandomSpawnBias = 1f,
                            GrenadeConstants = new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.GrenadeDangerStruct
                            {
                                Weight = -5f,
                                InnerRadius = 3.5f,
                                OuterRadius = 4f,
                                LeadTime = 0.75f,
                            },
                            VehicleConstants = new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.VehicleConstantStruct
                            {
                                DangerMinimumSpeed = 1f,
                                DangerWeight = -5f,
                                DangerRadius = 4f,
                                DangerLeadTime = 0.75f,
                                NearbyPlayerDistance = 4f,
                            },
                            HillBitmap = GetCachedTag<Bitmap>($@"multiplayer\hill\hill"),
                            FlagConstants = new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.FlagConstantStruct
                            {
                                ReturnDistance = 3.5f,
                                ContestedInnerRadius = 2f,
                                ContestedOuterRadius = 4f,
                            },
                            TerritoriesWaypointVerticalOffset = -0.1f,
                            AssaultBombEffects = new MultiplayerGlobals.MultiplayerRuntimeBlock.MultiplayerConstant.BombEffectStruct
                            {
                                ExplodeEffect = GetCachedTag<Effect>($@"fx\scenery_fx\explosions\human_explosion_huge\human_explosion_huge"),
                                ExplodeDamageEffect = GetCachedTag<DamageEffect>($@"objects\weapons\multiplayer\assault_bomb\damage_effects\bomb_explosion"),
                            },
                            ForgeCursorImpactEffect = GetCachedTag<Effect>($@"multiplayer\sandbox\cursor_impact"),
                            BombDefusalString = CacheContext.StringTable.GetOrAddString($@"assault_defusal"),
                            BlockedTeleporterString = CacheContext.StringTable.GetOrAddString($@"game_engine_blocked_teleporter"),
                            UnknownHO = 3,
                            SpawnAllowedDefaultRespawnString = CacheContext.StringTable.GetOrAddString($@"spawn_allowed_default_respawn_string"),
                            SpawnAtPlayerAllowedLookingAtSelfString = CacheContext.StringTable.GetOrAddString($@"spawn_at_player_allowed_looking_at_self_string"),
                            SpawnAtPlayerAllowedLookingAtTargetString = CacheContext.StringTable.GetOrAddString($@"spawn_at_player_allowed_looking_at_target_string"),
                            SpawnAtPlayerAllowedLookingAtPotentialTargetString = CacheContext.StringTable.GetOrAddString($@"spawn_at_player_allowed_looking_at_potential_target_string"),
                            SpawnAtTerritoryAllowedLookingAtTargetString = CacheContext.StringTable.GetOrAddString($@"spawn_at_territory_allowed_looking_at_target_string"),
                            SpawnAtTerritoryAllowedLookingAtPotentialTargetString = CacheContext.StringTable.GetOrAddString($@"spawn_at_territory_allowed_looking_at_potential_target_string"),
                            PlayerOutOfLivesString = CacheContext.StringTable.GetOrAddString($@"player_out_of_lives_string"),
                            InvalidSpawnTargetString = CacheContext.StringTable.GetOrAddString($@"invalid_spawn_target_string"),
                            TargetedPlayerEnemiesNearbyString = CacheContext.StringTable.GetOrAddString($@"targetted_player_enemies_near_by_string"),
                            TargetedPlayerUnfriendlyTeamString = CacheContext.StringTable.GetOrAddString($@"targetted_player_unfriendly_team_string"),
                            TargetedPlayerIsDeadString = CacheContext.StringTable.GetOrAddString($@"targetted_player_is_dead_string"),
                            TargetedPlayerInCombatString = CacheContext.StringTable.GetOrAddString($@"targetted_player_in_combat_shields_string"),
                            TargetedPlayerTooFarFromOwnedFlagString = CacheContext.StringTable.GetOrAddString($@"targetted_player_too_far_from_owned_flag_string"),
                            NoAvailableNetpointsString = CacheContext.StringTable.GetOrAddString($@"no_available_netpoints_string"),
                            NetpointContestedString = CacheContext.StringTable.GetOrAddString($@"netpoint_contested_string"),
                        },
                    },
                    StateResponses = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"state_waiting_for_space_to_clear"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"state_waiting_for_space_to_clear"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.Observing,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"state_observing"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"state_observing"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.RespawningSoon,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"state_respawning_soon"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"state_respawning_soon"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.SittingOut,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"state_sitting_out"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"state_sitting_out"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.OutOfLives,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"state_out_of_lives"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"state_out_of_lives"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.GameOverWon,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"state_game_over_won_ffa"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"state_game_over_won_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.GameOverTied,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"state_game_over_tied"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"state_game_over_tied"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.GameOverTied2,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"state_game_over_tied"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"state_game_over_tied"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.GameOverLost,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"state_game_over_lost_ffa"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"state_game_over_lost_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.EnemyHasFlag,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"state_enemy_has_your_flag"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"state_enemy_has_your_flag"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.YouAreJuggernaut,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"state_you_are_juggernaut"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"state_you_are_juggernaut"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.YouControlHill,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"state_you_control_hill"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"state_you_control_hill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.PlayerRecentlyStarted,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"state_recently_started"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"state_recently_started"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.FlagContested,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"state_flag_contested"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"state_flag_contested"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.BombContested,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"state_bomb_contested"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"state_bomb_contested"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.PlayingWinning,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"playing_winning_f"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"playing_winning_t"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.PlayingTied,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"playing_tied_f"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"playing_tied_t"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.PlayingLosing,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"playing_losing_f"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"playing_losing_t"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.LimitedLivesMultiple,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"state_limited_lives_multiple"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"state_limited_lives_multiple"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.LimitedLivesSingle,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"state_limited_lives_multiple"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"state_limited_lives_multiple"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.LimitedLivesFinal,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"state_limited_lives_final"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"state_limited_lives_final"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.PlayingWinningUnlimited,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"playing_winning_f_unlimited"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"playing_winning_t_unlimited"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.PlayingTiedUnlimited,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"playing_tied_f_unlimited"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"playing_tied_t_unlimited"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.PlayingLosingUnlimited,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"playing_losing_f_unlimited"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"playing_losing_t_unlimited"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            Flags = 0,
                            State = MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.StartingSoon,
                            FreeForAllMessage = CacheContext.StringTable.GetOrAddString($@"state_spawning_soon"),
                            TeamMessage = CacheContext.StringTable.GetOrAddString($@"state_spawning_soon"),
                        },
                    },
                    ScoreboardEmblemBitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\emblems"),
                    ScoreboardDeadBitmap = GetCachedTag<Bitmap>($@"ui\halox\scoreboard\dead_player_ui"),
                    HillShader = GetCachedTag<ShaderHalogram>($@"objects\multi\shaders\koth_shield"),
                    GameIntroMessages = new MultiplayerGlobals.MultiplayerRuntimeBlock.IntroMessageStruct()
                    {
                        Pregame = null,
                        Ctf = GetCachedTag<ChudDefinition>($@"ui\chud\multiplayer_intro\summary_ctf"),
                        Slayer = GetCachedTag<ChudDefinition>($@"ui\chud\multiplayer_intro\summary_slayer"),
                        Oddball = GetCachedTag<ChudDefinition>($@"ui\chud\multiplayer_intro\summary_oddball"),
                        King = GetCachedTag<ChudDefinition>($@"ui\chud\multiplayer_intro\summary_king"),
                        Sandbox = GetCachedTag<ChudDefinition>($@"ui\chud\multiplayer_intro\summary_editor"),
                        Vip = GetCachedTag<ChudDefinition>($@"ui\chud\multiplayer_intro\summary_vip"),
                        Juggernaut = GetCachedTag<ChudDefinition>($@"ui\chud\multiplayer_intro\summary_juggernaut"),
                        Territories = GetCachedTag<ChudDefinition>($@"ui\chud\multiplayer_intro\summary_territories"),
                        Assault = GetCachedTag<ChudDefinition>($@"ui\chud\multiplayer_intro\summary_assault"),
                        Infection = GetCachedTag<ChudDefinition>($@"ui\chud\multiplayer_intro\summary_infection"),
                    },
                    MusicFirstPlace = GetCachedTag<SoundLooping>($@"sound\music\postmatch_new\spartan_hero\postmatch_spartan_hero"),
                    MusicSecondPlace = GetCachedTag<SoundLooping>($@"sound\music\postmatch_new\spartan_engage\postmatch_spartan_engage"),
                    MusicThirdPlace = GetCachedTag<SoundLooping>($@"sound\music\postmatch_new\headhunters\postmatch_headhunters"),
                    MusicPostMatch = GetCachedTag<SoundLooping>($@"sound\music\postmatch_new\spartan_hero\postmatch_spartan_hero"),
                }
            };
            CacheContext.Serialize(Stream, tag, mulg);
        }
    }
}
