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
                            CharacterName = CacheContext.StringTable.GetStringId($@"masterchief"),
                            Regions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region()
                                {
                                    Name = CacheContext.StringTable.GetStringId($@"helmet"),
                                    Permutations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation>()
                                    {
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_helmet_default"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_helmet_default_description"),
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_helmet_mp_cobra"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_helmet_mp_cobra_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"helmet"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_cobra"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_helmet_mp_intruder"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_helmet_mp_intruder_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"helmet"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_intruder"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_helmet_mp_ninja"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_helmet_mp_ninja_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"helmet"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_ninja"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_helmet_mp_regulator"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_helmet_mp_regulator_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"helmet"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_regulator"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_helmet_mp_ryu"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_helmet_mp_ryu_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"helmet"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_ryu"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_helmet_mp_marathon"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_helmet_mp_marathon_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"helmet"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_marathon"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_helmet_mp_scout"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_helmet_mp_scout_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"helmet"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_scout"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_helmet_mp_odst"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_helmet_mp_odst_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"helmet"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_odst"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_helmet_mp_markv"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_helmet_mp_markv_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"helmet"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_markv"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_helmet_mp_rogue"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_helmet_mp_rogue_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"helmet"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_rogue"),
                                                },
                                            },
                                        },
                                    },
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region()
                                {
                                    Name = CacheContext.StringTable.GetStringId($@"leftshoulder"),
                                    Permutations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation>()
                                    {
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_leftshoulder_default"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_leftshoulder_default_description"),
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_leftshoulder_cobra"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_leftshoulder_cobra_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"leftshoulder"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_cobra"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_leftshoulder_intruder"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_leftshoulder_intruder_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"leftshoulder"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_intruder"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_leftshoulder_ninja"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_leftshoulder_ninja_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"leftshoulder"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_ninja"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_leftshoulder_regulator"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_leftshoulder_regulator_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"leftshoulder"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_regulator"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_leftshoulder_ryu"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_leftshoulder_ryu_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"leftshoulder"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_ryu"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_leftshoulder_marathon"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_leftshoulder_marathon_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"leftshoulder"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_marathon"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_leftshoulder_scout"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_leftshoulder_scout_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"leftshoulder"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_scout"),
                                                },
                                            },
                                        },
                                    },
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region()
                                {
                                    Name = CacheContext.StringTable.GetStringId($@"rightshoulder"),
                                    Permutations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation>()
                                    {
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_rightshoulder_default"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_rightshoulder_default_description"),
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_rightshoulder_cobra"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_rightshoulder_cobra_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"rightshoulder"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_cobra"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_rightshoulder_intruder"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_rightshoulder_intruder_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"rightshoulder"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_intruder"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_rightshoulder_ninja"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_rightshoulder_ninja_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"rightshoulder"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_ninja"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_rightshoulder_regulator"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_rightshoulder_regulator_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"rightshoulder"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_regulator"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_rightshoulder_ryu"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_rightshoulder_ryu_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"rightshoulder"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_ryu"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_rightshoulder_marathon"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_rightshoulder_marathon_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"rightshoulder"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_marathon"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_rightshoulder_scout"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_rightshoulder_scout_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"rightshoulder"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_scout"),
                                                },
                                            },
                                        },
                                    },
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region()
                                {
                                    Name = CacheContext.StringTable.GetStringId($@"body"),
                                    Permutations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation>()
                                    {
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_body_default"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_body_default_description"),
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_body_cobra"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_body_cobra_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_cobra"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_body_intruder"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_body_intruder_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_intruder"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_body_ninja"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_body_ninja_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_ninja"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_body_ryu"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_body_ryu_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_ryu"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_body_regulator"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_body_regulator_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_regulator"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_body_scout"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_body_scout_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_scout"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_body_katana"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_body_katana_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_katana"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_body_bungie"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_body_bungie_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_bungie"),
                                                },
                                            },
                                        },
                                    },
                                },
                            },
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter()
                        {
                            CharacterName = CacheContext.StringTable.GetStringId($@"dervish"),
                            Regions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region()
                                {
                                    Name = CacheContext.StringTable.GetStringId($@"helmet"),
                                    Permutations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation>()
                                    {
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"spartan_helmet_default"),
                                            Description = CacheContext.StringTable.GetStringId($@"spartan_helmet_default_description"),
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"elite_head_mp_predator"),
                                            Description = CacheContext.StringTable.GetStringId($@"elite_head_mp_predator_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"head"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_raptor"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"elite_head_mp_raptor"),
                                            Description = CacheContext.StringTable.GetStringId($@"elite_head_mp_raptor_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"head"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_predator"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"elite_head_mp_blades"),
                                            Description = CacheContext.StringTable.GetStringId($@"elite_head_mp_blades_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"head"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_blades"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"elite_head_mp_scythe"),
                                            Description = CacheContext.StringTable.GetStringId($@"elite_head_mp_scythe_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"head"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_scythe"),
                                                },
                                            },
                                        },
                                    },
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region()
                                {
                                    Name = CacheContext.StringTable.GetStringId($@"leftshoulder"),
                                    Permutations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation>()
                                    {
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"elite_leftshoulder_default"),
                                            Description = CacheContext.StringTable.GetStringId($@"elite_leftshoulder_default_description"),
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"elite_leftshoulder_mp_predator"),
                                            Description = CacheContext.StringTable.GetStringId($@"elite_leftshoulder_mp_predator_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"leftshoulder"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_raptor"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"elite_leftshoulder_mp_raptor"),
                                            Description = CacheContext.StringTable.GetStringId($@"elite_leftshoulder_mp_raptor_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"leftshoulder"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_predator"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"elite_leftshoulder_mp_blades"),
                                            Description = CacheContext.StringTable.GetStringId($@"elite_leftshoulder_mp_blades_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"leftshoulder"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_blades"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"elite_leftshoulder_mp_scythe"),
                                            Description = CacheContext.StringTable.GetStringId($@"elite_leftshoulder_mp_scythe_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"leftshoulder"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_scythe"),
                                                },
                                            },
                                        },
                                    },
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region()
                                {
                                    Name = CacheContext.StringTable.GetStringId($@"rightshoulder"),
                                    Permutations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation>()
                                    {
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"elite_rightshoulder_default"),
                                            Description = CacheContext.StringTable.GetStringId($@"elite_rightshoulder_default_description"),
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"elite_rightshoulder_mp_predator"),
                                            Description = CacheContext.StringTable.GetStringId($@"elite_rightshoulder_mp_predator_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"rightshoulder"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_raptor"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"elite_rightshoulder_mp_raptor"),
                                            Description = CacheContext.StringTable.GetStringId($@"elite_rightshoulder_mp_raptor_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"rightshoulder"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_predator"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"elite_rightshoulder_mp_blades"),
                                            Description = CacheContext.StringTable.GetStringId($@"elite_rightshoulder_mp_blades_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"rightshoulder"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_blades"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"elite_rightshoulder_mp_scythe"),
                                            Description = CacheContext.StringTable.GetStringId($@"elite_rightshoulder_mp_scythe_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"rightshoulder"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_scythe"),
                                                },
                                            },
                                        },
                                    },
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region()
                                {
                                    Name = CacheContext.StringTable.GetStringId($@"body"),
                                    Permutations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation>()
                                    {
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"elite_body_default"),
                                            Description = CacheContext.StringTable.GetStringId($@"elite_body_default_description"),
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"elite_body_mp_predator"),
                                            Description = CacheContext.StringTable.GetStringId($@"elite_body_mp_predator_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_raptor"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"elite_body_mp_raptor"),
                                            Description = CacheContext.StringTable.GetStringId($@"elite_body_mp_raptor_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_predator"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"elite_body_mp_blades"),
                                            Description = CacheContext.StringTable.GetStringId($@"elite_body_mp_blades_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_blades"),
                                                },
                                            },
                                        },
                                        new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation()
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"elite_body_mp_scythe"),
                                            Description = CacheContext.StringTable.GetStringId($@"elite_body_mp_scythe_description"),
                                            Variant = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock>()
                                            {
                                                new MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter.Region.Permutation.VariantBlock()
                                                {
                                                    Region = CacheContext.StringTable.GetStringId($@"chest"),
                                                    Permutation = CacheContext.StringTable.GetStringId($@"mp_scythe"),
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
                            Name = CacheContext.StringTable.GetStringId("empty"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\concussiveblast_equipment\concussiveblast_equipment"),
                            Type = 0,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("jammer"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\jammer_equipment\jammer_equipment"),
                            Type = 8,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("powerdrain"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\powerdrain_equipment\powerdrain_equipment"),
                            Type = 1,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("invisibility"),
                            Type = 13,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("invisibility_vehicle"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\invisibility_vehicle_equipment\invisibility_vehicle_equipment"),
                            Type = 19,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("bubbleshield"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\bubbleshield_equipment\bubbleshield_equipment"),
                            Type = 2,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("superflare"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\superflare_equipment\superflare_equipment"),
                            Type = 10,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("regenerator"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\regenerator_equipment\regenerator_equipment"),
                            Type = 4,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("tripmine"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\tripmine_equipment\tripmine_equipment"),
                            Type = 5,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("auto_turret"),
                            Type = 9,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("deployable_cover"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\instantcover_equipment\instantcover_equipment"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("forced_reload"),
                            Type = 18,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("concussive_blast"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\concussiveblast_equipment\concussiveblast_equipment"),
                            Type = 11,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("tank_mode"),
                            Type = 20,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("mag_pulse"),
                            Type = 27,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("hologram"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\hologram_equipment\hologram_equipment"),
                            Type = 14,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("reactive_armor"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\reactive_armor_equipment\reactive_armor_equipment"),
                            Type = 16,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("bomb_run"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\bombrun_equipment\bombrun_equipment"),
                            Type = 12,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("armor_lock"),
                            Type = 17,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("adrenaline"),
                            Type = 7,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("lightning_strike"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\lightningstrike_equipment\lightningstrike_equipment"),
                            Type = 22,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("scrambler"),
                            Type = 25,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("weapon_jammer"),
                            Type = 24,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("ammo_pack"),
                            Type = 23,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("consumable_vision"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\vision_equipment\vision_equipment"),
                            Type = 15,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("invincibility"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\invincibility_equipment\invincibility_equipment"),
                            Type = 26,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("gravlift"),
                            Object = GetCachedTag<Equipment>(@"objects\equipment\gravlift_equipment\gravlift_equipment"),
                            Type = 3,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("bubbleshield"),
                            Type = 2,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("deployable_cover"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("deployable_cover"),
                            Type = 21,
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                        {
                            Name = CacheContext.StringTable.GetStringId("vision"),
                            Type = 15,
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
                            Name = CacheContext.StringTable.GetStringId("battle_rifle"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\battle_rifle\battle_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("assault_rifle"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\assault_rifle\assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("plasma_pistol"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\pistol\plasma_pistol\plasma_pistol")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("spike_rifle"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\spike_rifle\spike_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("smg"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\smg\smg")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("carbine"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\covenant_carbine\covenant_carbine")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("energy_sword"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\melee\energy_blade\energy_blade")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("magnum"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\pistol\magnum\magnum")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("needler"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\pistol\needler\needler")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("plasma_rifle"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\plasma_rifle\plasma_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("rocket_launcher"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\support_high\rocket_launcher\rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("shotgun"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\shotgun\shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("sniper_rifle"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\sniper_rifle\sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("brute_shot"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\support_low\brute_shot\brute_shot")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("unarmed"),
                            RandomChance = 0f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\melee\energy_blade\energy_blade_useless")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("beam_rifle"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\beam_rifle\beam_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("spartan_laser"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\support_high\spartan_laser\spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("none"),
                            RandomChance = 0f,
                            Weapon = null
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("gravity_hammer"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\melee\gravity_hammer\gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("excavator"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\pistol\excavator\excavator")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("flamethrower"),
                            RandomChance = 0f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\turret\flamethrower\flamethrower")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("missile_pod"),
                            RandomChance = 0f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\turret\missile_pod\missile_pod")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("sentinel_beam"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\support_low\sentinel_gun\sentinel_gun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\support_high\flak_cannon\flak_cannon")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("dmr"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\dmr\dmr")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("assault_rifle_v1"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("assault_rifle_v2"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\assault_rifle\assault_rifle_v2\assault_rifle_v2")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("assault_rifle_v3"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\assault_rifle\assault_rifle_v3\assault_rifle_v3")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("assault_rifle_v4"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("assault_rifle_v5"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\assault_rifle\assault_rifle_v5\assault_rifle_v5")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("assault_rifle_v6"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\assault_rifle\assault_rifle_v6\assault_rifle_v6")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("battle_rifle_v1"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\battle_rifle\battle_rifle_v1\battle_rifle_v1")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("battle_rifle_v2"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\battle_rifle\battle_rifle_v2\battle_rifle_v2")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("battle_rifle_v3"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\battle_rifle\battle_rifle_v3\battle_rifle_v3")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("battle_rifle_v4"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\battle_rifle\battle_rifle_v4\battle_rifle_v4")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("battle_rifle_v5"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\battle_rifle\battle_rifle_v5\battle_rifle_v5")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("battle_rifle_v6"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\battle_rifle\battle_rifle_v6\battle_rifle_v6")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("dmr_v1"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\dmr\dmr_v1\dmr_v1")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("dmr_v2"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\dmr\dmr_v2\dmr_v2")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("dmr_v3"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\dmr\dmr_v3\dmr_v3")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("dmr_v4"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\dmr\dmr_v4\dmr_v4")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("dmr_v5"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("dmr_v6"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\dmr\dmr_v6\dmr_v6")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("smg_v1"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\smg\smg_v1\smg_v1")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("smg_v2"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\smg\smg_v2\smg_v2")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("smg_v3"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("smg_v4"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\smg\smg_v4\smg_v4")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("smg_v5"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("smg_v6"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\smg\smg_v6\smg_v6")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("plasma_rifle_v1"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("plasma_rifle_v2"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("plasma_rifle_v3"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("plasma_rifle_v4"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("plasma_rifle_v5"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("plasma_rifle_v6"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\plasma_rifle\plasma_rifle_v6\plasma_rifle_v6")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("covenant_carbine_v1"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v1\covenant_carbine_v1")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("covenant_carbine_v2"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v2\covenant_carbine_v2")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("covenant_carbine_v3"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v3\covenant_carbine_v3")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("covenant_carbine_v4"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v4\covenant_carbine_v4")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("covenant_carbine_v5"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v5\covenant_carbine_v5")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("covenant_carbine_v6"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v6\covenant_carbine_v6")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("excavator_v1"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("excavator_v2"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("excavator_v3"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\pistol\excavator\excavator_v3\excavator_v3")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("magnum_v1"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("magnum_v2"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\pistol\magnum\magnum_v2\magnum_v2")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("magnum_v3"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\pistol\magnum\magnum_v3\magnum_v3")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("plasma_pistol_v3"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\pistol\plasma_pistol\plasma_pistol_v3\plasma_pistol_v3")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("plasma_pistol_v2"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("machinegun_turret"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\turret\machinegun_turret\machinegun_turret")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                        {
                            Name = CacheContext.StringTable.GetStringId("plasma_cannon"),
                            RandomChance = 0.1f,
                            Weapon = GetCachedTag<Weapon>(@"objects\weapons\turret\plasma_cannon\plasma_cannon")
                        },
                    },
                    GameVariantVehicles = new List<MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("warthog"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("ghost"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\ghost\ghost"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("scorpion"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\scorpion\scorpion"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("wraith"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\wraith\wraith"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("banshee"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\banshee\banshee"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("mongoose"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\mongoose\mongoose"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("chopper"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\brute_chopper\brute_chopper"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("mauler"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("hornet"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\hornet\hornet"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("warthog_snow"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_snow"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("mongoose_snow"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("hornet_lite"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\levels\dlc\sidewinder\hornet_lite\hornet_lite"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("scorpion_snow"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("ghost_snow"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("warthog_gauss"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_gauss"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("warthog_01"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_troop"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("warthog_02"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_no_turret"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("warthog_03"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_wrecked"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("warthog_04"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_snow_gauss"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("warthog_05"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_snow_troop"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("warthog_06"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_snow_no_turret"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("warthog_07"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_snow_wrecked"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                        {
                            Name = CacheContext.StringTable.GetStringId("wraith1"),
                            Vehicle = GetCachedTag<Vehicle>($@"objects\vehicles\wraith\wraith_anti_air"),
                        },
                    },
                    GameVariantGrenades = new List<MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantGrenadeBlock>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantGrenadeBlock
                        {
                            Name = CacheContext.StringTable.GetStringId("frag_grenade"),
                            Grenade = GetCachedTag<Equipment>(@"objects\weapons\grenade\frag_grenade\frag_grenade"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantGrenadeBlock
                        {
                            Name = CacheContext.StringTable.GetStringId("plasma_grenade"),
                            Grenade = GetCachedTag<Equipment>(@"objects\weapons\grenade\plasma_grenade\plasma_grenade"),
                        },
                    },
                    WeaponSets = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetStringId("default"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spike_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("carbine")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("needler")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("brute_shot")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sentinel_beam")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("beam_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("flamethrower")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("missile_pod")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v3"),
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetStringId("assault_rifles"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetStringId("duals"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spike_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v1"),
                                   SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v3"),
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetStringId("hammers"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetStringId("lasers"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetStringId("rockets"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetStringId("shotguns"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetStringId("sniper_rifles"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("beam_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetStringId("swords"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetStringId("no_power_weapons"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spike_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("carbine")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("needler")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("brute_shot")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sentinel_beam")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v3"),
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetStringId("no_snipers"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spike_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("carbine")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("needler")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("brute_shot")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sentinel_beam")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("flamethrower")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("missile_pod")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v4"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v5"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v6"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum_v3"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v1"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v3"),
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetStringId("no_weapons"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v1"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v2"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v3"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v4"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v5"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v6"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v1"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v2"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v3"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v4"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v5"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v6"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v1"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v2"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v3"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v4"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v5"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v6"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v1"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v2"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v3"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v4"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v5"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v6"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v1"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v2"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v3"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v4"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v5"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v6"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v1"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v2"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v3"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v4"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v5"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v6"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v1"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v2"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v3"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v1"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v2"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v3"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v1"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v2"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v3"),
                                    SubstitutedWeapon = StringId.Invalid
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetStringId("random"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                        {
                            Name = CacheContext.StringTable.GetStringId($@"base"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("carbine"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("needler"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launch"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("dmr_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("dmr"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("smg_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v4"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v5"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle_v6"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("carbine"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("carbine"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("carbine"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("carbine"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("carbine"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("covenant_carbine"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("carbine"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("excavator_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("magnum_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v1"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v2"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                                {
                                    OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol_v3"),
                                    SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                                },
                            },
                        },
                    },
                    VehicleSets = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                        {
                            Name = CacheContext.StringTable.GetStringId("default"),
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                        {
                            Name = CacheContext.StringTable.GetStringId("no_vehicles"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("ghost"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("scorpion"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("wraith"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("mongoose"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("banshee"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("chopper"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("mauler"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("hornet"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("mongoose_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("hornet_lite"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("scorpion_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("ghost_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_gauss"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_01"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_02"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_03"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_04"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_05"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_06"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_07"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("wraith1"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                        {
                            Name = CacheContext.StringTable.GetStringId("mongooses_only"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("ghost"),
                                    SubstitutedVehicle = CacheContext.StringTable.GetStringId("mongoose")
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("scorpion"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("wraith"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("banshee"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("chopper"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("mauler"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("hornet"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("hornet_lite"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("scorpion_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("ghost_snow"),
                                    SubstitutedVehicle = CacheContext.StringTable.GetStringId("mongoose_snow"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_gauss"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_01"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_02"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_03"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_04"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_05"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_06"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_07"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("wraith1"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                        {
                            Name = CacheContext.StringTable.GetStringId("light_ground_only"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("scorpion"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("wraith"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("banshee"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("hornet"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("hornet_lite"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("scorpion_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("wraith1"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                        {
                            Name = CacheContext.StringTable.GetStringId("tanks_only"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("ghost"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("mongoose"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("banshee"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("chopper"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("mauler"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("hornet"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("mongoose_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("hornet_lite"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("ghost_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_gauss"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_01"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_02"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_03"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_04"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_05"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_06"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_07"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                        {
                            Name = CacheContext.StringTable.GetStringId("aircraft_only"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("ghost"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("scorpion"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("wraith"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("mongoose"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("chopper"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("mauler"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("mongoose_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("scorpion_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("ghost_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_gauss"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_01"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_02"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_03"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_04"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_05"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_06"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_07"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("wraith1"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                        {
                            Name = CacheContext.StringTable.GetStringId("no_light_ground"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("ghost"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("mongoose"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("chopper"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("mauler"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("mongoose_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("ghost_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_gauss"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_01"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_02"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_03"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_04"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_05"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_06"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("warthog_07"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                        {
                            Name = CacheContext.StringTable.GetStringId("no_tanks"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("scorpion"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("wraith"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("scorpion_snow"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("wraith1"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                        {
                            Name = CacheContext.StringTable.GetStringId("no_aircraft"),
                            Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("banshee"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("hornet"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                                {
                                    OriginalVehicle = CacheContext.StringTable.GetStringId("hornet_lite"),
                                    SubstitutedVehicle = StringId.Invalid
                                },
                            }
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                        {
                            Name = CacheContext.StringTable.GetStringId("all_vehicles"),
                        }
                    },
                    PodiumAnimations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation>
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation
                        {
                            DefaultUnarmed = CacheContext.StringTable.GetStringId($@"combat:any:any:default_pose_unarmed"),
                            DefaultArmed = CacheContext.StringTable.GetStringId($@"combat:any:any:default_pose_armed"),
                            StanceAnimations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.StanceAnimation>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.StanceAnimation
                                {
                                    Name = "podium_stance_standard",
                                    BaseAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:standard"),
                                    LoopAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:standard_loop"),
                                    UnarmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:standard_transition_unarmed"),
                                    ArmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:standard_transition_armed"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.StanceAnimation
                                {
                                    Name = "podium_stance_assault",
                                    BaseAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:assault"),
                                    LoopAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:assault_loop"),
                                    UnarmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:assault_transition_unarmed"),
                                    ArmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:assault_transition_armed"),
                                    CameraDistanceOffset = 0.04f,
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.StanceAnimation
                                {
                                    Name = "podium_stance_gameover",
                                    BaseAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:game_over"),
                                    LoopAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:game_over_loop"),
                                    UnarmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:game_over_transition_unarmed"),
                                    ArmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:game_over_transition_armed"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.StanceAnimation
                                {
                                    Name = "podium_stance_ready",
                                    BaseAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:ready"),
                                    LoopAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:ready_loop"),
                                    UnarmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:ready_transition_unarmed"),
                                    ArmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:ready_transition_armed"),
                                    CameraDistanceOffset = 0.1f,
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.StanceAnimation
                                {
                                    Name = "podium_stance_relaxed",
                                    BaseAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:relaxed"),
                                    LoopAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:relaxed_loop"),
                                    UnarmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:relax_transition_unarmed"),
                                    ArmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:relax_transition_armed"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.StanceAnimation
                                {
                                    Name = "podium_stance_shoulder",
                                    BaseAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:shoulder"),
                                    LoopAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:shoulder_loop"),
                                    UnarmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:shoulder_transition_unarmed"),
                                    ArmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:shoulder_transition_armed"),
                                    CameraDistanceOffset = 0.15f,
                                },
                            },
                            MoveAnimations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = "podium_move_victory",
                                    InAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:victory"),
                                    WeaponLoadout = WeaponLoadout.LoadoutPrimary,
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = "podium_move_comeon",
                                    InAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:come_on"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = "podium_move_comeon2",
                                    InAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:come_on_2"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = "podium_move_mad",
                                    InAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:mad"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = "podium_move_melee",
                                    InAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:melee"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = "podium_move_menace",
                                    InAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:menace"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = "podium_move_pistolero",
                                    InAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:pistolero_in"),
                                    LoopAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:pistolero_loop"),
                                    OutAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:pistolero_out"),
                                    WeaponLoadout = WeaponLoadout.LoadoutSecondary,
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = "podium_move_salute",
                                    InAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:salute"),
                                    WeaponLoadout = WeaponLoadout.LoadoutPrimary,
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = "podium_move_steroids",
                                    InAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:steroids"),
                                },
                            },
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation
                        {
                            DefaultUnarmed = CacheContext.StringTable.GetStringId($@"combat:any:any:default_pose_unarmed"),
                            DefaultArmed = CacheContext.StringTable.GetStringId($@"combat:any:any:default_pose_armed"),
                            StanceAnimations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.StanceAnimation>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.StanceAnimation
                                {
                                    Name = "podium_e_stance_standard",
                                    BaseAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:standart"),
                                    LoopAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:standart_loop"),
                                    UnarmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:standart_transition_unarmed"),
                                    ArmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:standart_transition_armed"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.StanceAnimation
                                {
                                    Name = "podium_e_stance_charge",
                                    BaseAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:charge"),
                                    LoopAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:charge_loop"),
                                    UnarmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:charge_transition_unarmed"),
                                    ArmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:charge_transition_armed"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.StanceAnimation
                                {
                                    Name = "podium_e_stance_gameover",
                                    BaseAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:gameover"),
                                    LoopAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:gameover_loop"),
                                    UnarmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:gameover_transition_unarmed"),
                                    ArmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:gameover_transition_armed"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.StanceAnimation
                                {
                                    Name = "podium_e_stance_honor",
                                    BaseAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:honor"),
                                    LoopAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:honor_loop"),
                                    UnarmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:honor_transition_unarmed"),
                                    ArmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:honor_transition_armed"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.StanceAnimation
                                {
                                    Name = "podium_e_stance_watchman",
                                    BaseAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:watchman"),
                                    LoopAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:watchman_loop"),
                                    UnarmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:watchman_transition_unarmed"),
                                    ArmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:watchman_transition_armed"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.StanceAnimation
                                {
                                    Name = "podium_e_stance_zealot",
                                    BaseAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:zealot"),
                                    LoopAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:zealot_loop"),
                                    UnarmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:zealot_transition_unarmed"),
                                    ArmedTransition = CacheContext.StringTable.GetStringId($@"combat:any:any:zealot_transition_armed"),
                                },
                            },
                            MoveAnimations = new List<MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation>
                            {
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = "podium_move_e_berserk",
                                    InAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:berserk"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = "podium_move_e_confident",
                                    InAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:confident"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = "podium_move_e_dual",
                                    InAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:dual"),
                                    WeaponLoadout = WeaponLoadout.Custom,
                                    CustomPrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\melee\energy_blade\energy_blade"),
                                    CustomSecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\melee\energy_blade\energy_blade"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = "podium_move_e_howl",
                                    InAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:howl"),
                                    WeaponLoadout = WeaponLoadout.LoadoutPrimary,
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = "podium_move_e_sniper",
                                    InAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:sniper"),
                                    WeaponLoadout = WeaponLoadout.Custom,
                                    CustomPrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\beam_rifle\beam_rifle"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = "podium_move_e_stomp",
                                    InAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:stomp"),
                                    WeaponLoadout = WeaponLoadout.LoadoutPrimary,
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = "podium_move_e_strike",
                                    InAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:strike"),
                                    WeaponLoadout = WeaponLoadout.Custom,
                                    CustomPrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\melee\energy_blade\energy_blade"),
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = "podium_move_e_threaten",
                                    InAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:threaten"),
                                    WeaponLoadout = WeaponLoadout.LoadoutPrimary,
                                },
                                new MultiplayerGlobals.MultiplayerUniversalBlock.PodiumAnimation.MoveAnimation
                                {
                                    Name = "podium_move_e_victory",
                                    InAnimation = CacheContext.StringTable.GetStringId($@"combat:any:any:victory"),
                                    WeaponLoadout = WeaponLoadout.LoadoutPrimary,
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
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_kill"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_kill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_assist"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_assist"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_perfection"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_perfection"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_extermination"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_extermination"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_multikill_2"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_multikill_x2"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_multikill_3"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_multikill_x3"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_multikill_4"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_multikill_x4"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_multikill_5"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_multikill_x5"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_multikill_6"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_multikill_x6"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_multikill_7"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_multikill_x7"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_multikill_8"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_multikill_x8"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_multikill_9"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_multikill_x9"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_multikill_10"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_multikill_x10"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_bash_kill"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_kill_bash"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_bashbehind_kill"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_kill_bash_behind"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_kill_sniper"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_kill_sniper"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_stickygrenade_kill"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_kill_sticky_grenade"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_spartanlaser_kill"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_kill_laser"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_oddball_carrier_kill_player"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_kill_oddball"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_ctf_flag_carrier_kill_player"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_kill_flag"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_flame_kill"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_kill_flame"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_player_kill_spreeplayer"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_broke_killing_spree"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_deadplayer_kill"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_from_the_grave"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_vehicle_impact_kill"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_splatter"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_vehicle_hijack"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_hijack"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_shotgun_kill_sword"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_bulltrue"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_driver_assist_gunner"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_assist_to_driver"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_aircraft_hijack"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_skyjack"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_ctf_flag_player_kill_carrier"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_kill_flag_carrier"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_ctf_flag_captured"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_flag_capture"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_koth_5"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_hill_kill_5x"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_revenge"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_revenge"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_flag_grabbed_from_stand"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_flag_grabbed_from_stand"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_flag_returned_by_player"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_flag_returned_by_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_5_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_5_in_a_row"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_10_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_10_in_a_row"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_15_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_15_in_a_row"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_20_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_20_in_a_row"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_25_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_25_in_a_row"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_30_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_30_in_a_row"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_vehicle_5"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_splatter_5x"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.EarnWp,
                            Event = CacheContext.StringTable.GetStringId($@"earn_wp_event_headshot"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"wp_headshot"),
                        },
                    },
                    GeneralEvents = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_round_over"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_round_over_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\round_over"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_suicide"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_suicide_cause_player"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\suicide"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_suicide"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_suicide_cause_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_teammate"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_teammate_effect_player"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\betrayed"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_teammate"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_teammate_cause_player"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\betrayal"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_teammate"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_teammate_cause_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_victory"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_victory_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\game_over"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_team_victory"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_team_victory_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\game_over"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_gained_lead"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_gained_lead_all"),
                            RequiredField = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CausePlayer,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_gained_lead"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_gained_lead_cause_player"),
                            SplitscreenSuppression = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CausePlayer,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\gained_the_lead"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_gained_team_lead"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_gained_team_lead_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_gained_team_lead"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_gained_team_lead_cause_team"),
                            SplitscreenSuppression = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CausePlayer,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\gained_the_lead"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_lost_lead"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            SplitscreenSuppression = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CausePlayer,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_lost_team_lead"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            SplitscreenSuppression = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CausePlayer,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_tied_leader"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_tied_leader"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_tied_team_leader"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_tied_team_leader"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_30_minutes_left"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_30_minutes_left_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\thirty_mins_remaining"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_15_minutes_left"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_15_minutes_left_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\fifteen_mins_remaining"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_5_minutes_left"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_5_minutes_left_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\five_mins_remaining"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_1_minute_left"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_1_minute_left_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\one_min_remaining"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_game_over"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_game_over_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\game_over"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_player_quit"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_player_quit_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_player_joined"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_player_joined_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_player_rejoined"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_player_rejoined_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_killed_by_unknown"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_killed_by_unknown_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_respawn_tick"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
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
                            Event = CacheContext.StringTable.GetStringId($@"general_event_respawn_final_tick"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
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
                            Event = CacheContext.StringTable.GetStringId($@"general_event_teleporter_used"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            EnglishSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\teleporter_activate"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_player_switched_team"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_player_changed_team_effect_team"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\teamate_gained"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_player_switched_team"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_player_changed_team_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_30_seconds_left"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_30_seconds_left_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\thirty_secs_remaining"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_10_seconds_left"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_10_seconds_left_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\ten_secs_remaining"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_collision"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_col_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_collision"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_col_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_collision"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_col_effect_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_collision"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_col_cause_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_melee"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_melee_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_melee"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_melee_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_melee"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_melee_effect_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_melee"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_melee_cause_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_killed_by_falling"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_killed_by_falling_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_sudden_death"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            PrimaryString = CacheContext.StringTable.GetStringId($@"gen_sudden_death_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\sudden_death"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_sticky_grenade"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_sticky_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_sticky_grenade"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_sticky_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_sticky_grenade"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_sticky_effect_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_sticky_grenade"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_sticky_cause_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_sniper"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_sniper_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_sniper"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_sniper_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_sniper"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_sniper_effect_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_sniper"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_sniper_cause_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_stealth_melee"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_sneak_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_stealth_melee"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_sneak_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_stealth_melee"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_sneak_effect_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_stealth_melee"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_sneak_cause_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_boarded_vehicle"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_boarded_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_boarded_vehicle"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_boarded_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_player_booted_player"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_player_booted_player_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_game_start_team_notification"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_start_team_notice_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_teleporter_telefrag"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_telefrag_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_flag_carrier"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_kill_carrier_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_flag_carrier"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_kill_carrier_ep"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_flag_carrier"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_kill_carrier_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_flag_carrier"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_kill_carrier_et"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_bomb_carrier"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"assault_kill_carrier_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_bomb_carrier"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetStringId($@"assault_kill_carrier_ep"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_bomb_carrier"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"assault_kill_carrier_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_bomb_carrier"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"assault_kill_carrier_et"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_collision"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_col_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_shotgun_kill_sword"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_bulltrue_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_deadplayer"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_deadplayer_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_deadplayer"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_deadplayer_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_vehicle_hijack"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_hijack_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_vehicle_hijack"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_hijack_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_aircraft_hijack"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_skyjack_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_aircraft_hijack"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_skyjack_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_spartanlaser"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_spartanlaser_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_spartanlaser"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_spartanlaser_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_flame"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_flame_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_flame"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_flame_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_occupied_vehicle_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_driver_assist_gunner"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_driverassist_cause_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_driver_assist_gunner"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_driverassist_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_teleporter_blocked"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"game_engine_blocked_teleporter"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_spartanlaser"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_effect_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_spartanlaser"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_cause_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_flame"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_cause_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_flame"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_effect_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_teammate"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_teammate_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_collision"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_col_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_melee"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_melee_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_sticky_grenade"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_sticky_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_sniper"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_sniper_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_stealth_melee"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_sneak_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_flag_carrier"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_kill_carrier_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_bomb_carrier"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetStringId($@"assault_kill_carrier_all"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_spartanlaser"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_spartanlaser_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_flame"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_flame_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_kill_deadplayer"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_kill_deadplayer_all"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            Event = CacheContext.StringTable.GetStringId($@"general_event_suicide"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"gen_suicide_cause_team"),
                        },

                    },
                    FlavorEvents = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_extermination"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_extermination"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_extermination"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\extermination"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_perfection"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_perfection"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_perfection"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\misc\perfection"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_multikill_2"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_multikill_2"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_multikill_2"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\double_kill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_multikill_3"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_multikill_3"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_multikill_3"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\triple_kill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_multikill_4"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_multikill_4"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_multikill_4"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\overkill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_multikill_5"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_multikill_5"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_multikill_5"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\killtacular"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_multikill_6"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_multikill_6"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_multikill_6"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\killtrocity"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_multikill_7"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_multikill_7"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_multikill_7"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\killimanjaro"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_multikill_8"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_multikill_8"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_multikill_8"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\killtastrophe"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_multikill_9"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_multikill_9"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_multikill_9"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\killpocalypse"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_multikill_10"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_multikill_10"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_multikill_10"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\killionaire"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_5_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_kill_spree_5"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_kill_spree_5"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\killing_spree"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_10_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_kill_spree_10"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_kill_spree_10"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\killing_frenzy"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_15_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_kill_spree_15"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_kill_spree_15"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\running_riot"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_20_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_kill_spree_20"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_kill_spree_20"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\rampage"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_25_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_kill_spree_25"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_kill_spree_25"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\untouchable"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_30_kills_in_a_row"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_kill_spree_30"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_kill_spree_30"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\invincible"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_sniper_5"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_sniper_5"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_sniper_5"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\sniper_spree"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_sniper_10"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_sniper_10"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_sniper_10"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\sharpshooter"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_shotgun_5"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_shotgun_5"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_shotgun_5"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\shotgun_spree"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_shotgun_10"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_shotgun_10"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_shotgun_10"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\open_season"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_vehicle_5"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_splatter_5"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_splatter_5"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\splatter_spree"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_vehicle_10"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_splatter_10"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_splatter_10"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\vehicular_manslaughter"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_sword_5"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_sword_5"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_sword_5"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\sword_spree"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_sword_10"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_sword_10"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_sword_10"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\slice_n_dice"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_juggernaut_5"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_juggernaut_5"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_juggernaut_5"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\juggernaut_spree"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_juggernaut_10"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_juggernaut_10"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_juggernaut_10"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\unstoppable"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_zombie_5"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_zombie_5"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_zombie_5"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\infection_spree"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_zombie_10"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_zombie_10"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_zombie_10"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\mmm_brains"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_human_5"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_survivor_5"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_survivor_5"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\zombie_killing_spree"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_human_10"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_survivor_10"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_survivor_10"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\hells_janitor"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_human_15"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_koth_5"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_koth_5"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_koth_5"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\hail_to_the_king"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_shotgun_kill_sword"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_shotgun_kill_sword"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_vehicle_impact_kill"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_vehicle_impact_kill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_vehicle_hijack"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_vehicle_hijack"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_aircraft_hijack"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_aircraft_hijack"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_deadplayer_kill"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_deadplayer_kill_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_player_kill_spreeplayer"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_broke_killing_spree_cause_player"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_player_kill_spreeplayer"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\flavor\killjoy"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_player_kill_spreeplayer"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_broke_killing_spree_effect_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_spartanlaser_kill"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_spartanlaser_kill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_stickygrenade_kill"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_stickygrenade_kill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_sniper_kill"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_sniper_kill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_bashbehind_kill"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_bashbehind_kill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_bash_kill"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_bash_kill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_flame_kill"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_flame_kill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_extermination"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_player_kill_occupiedvehicle"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_driver_assist_gunner"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_driver_assist_gunner"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_assault_bomb_planted"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_assault_bomb_planted"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_assault_player_kill_carrier"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_assault_player_kill_carrier"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_vip_player_kill_vip"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_vip_player_kill_vip"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_juggernaut_player_kill_juggernaut"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_juggernaut_player_kill_juggernaut"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_oddball_carrier_kill_player"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_oddball_carrier_kill_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_ctf_flag_captured"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_ctf_flag_captured"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_ctf_flag_player_kill_carrier"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_ctf_flag_player_kill_carrier"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_ctf_flag_carrier_kill_player"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_ctf_flag_carrier_kill_player"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_infection_survive"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_infection_survive"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_nemesis"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_nemesis"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_nemesis"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_event_avenger"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"flavor_revenge"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_revenge"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Flavor,
                            Event = CacheContext.StringTable.GetStringId($@"flavor_forge_cannot_place_object"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"forge_error_no_room"),
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
                            Event = CacheContext.StringTable.GetStringId($@"flavor_forge_theoretical_object_limit_reached"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"forge_error_out_of_objects"),
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
                            Event = CacheContext.StringTable.GetStringId($@"slayer_event_game_start"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetStringId($@"slayer_game_start"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\slayer\slayer"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Slayer,
                            Event = CacheContext.StringTable.GetStringId($@"slayer_event_new_target"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetStringId($@"slayer_new_target"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\slayer\target_changed"),
                        },
                    },
                    CtfEvents = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetStringId($@"ctf_event_game_start"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_game_start"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\capture_the_flag"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetStringId($@"ctf_event_flag_new_defensive_team"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_new_defensive_team"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\offense"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetStringId($@"ctf_event_flag_new_defensive_team"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_new_defensive_team_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\defense"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetStringId($@"ctf_event_flag_captured"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_flag_captured"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_captured"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetStringId($@"ctf_event_flag_captured"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_flag_captured"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_captured"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetStringId($@"ctf_event_flag_captured"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_flag_captured_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_captured"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetStringId($@"ctf_event_flag_returned_by_timeout"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_flag_reset"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_reset"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetStringId($@"ctf_event_flag_returned_by_timeout"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_flag_reset_et"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_reset"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetStringId($@"ctf_event_flag_returned_by_player"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_flag_recovered"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_recovered"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetStringId($@"ctf_event_flag_returned_by_player"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_flag_recovered_et"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_recovered"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetStringId($@"ctf_event_flag_taken"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_flag_grabbed_ct"),
                            SplitscreenSuppression = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CauseTeam,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_taken"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetStringId($@"ctf_event_flag_taken"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_flag_grabbed_cp"),
                            SplitscreenSuppression = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CauseTeam,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_taken"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetStringId($@"ctf_event_flag_taken"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_flag_grabbed_et"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_stolen"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetStringId($@"ctf_event_flag_dropped"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_flag_dropped"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetStringId($@"ctf_event_flag_dropped"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_flag_dropped_et"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetStringId($@"ctf_event_flag_capture_faliure"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_failed_capture_cp"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetStringId($@"ctf_event_flag_grabbed_from_stand"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_flag_grabbed_ct"),
                            SplitscreenSuppression = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CauseTeam,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_taken"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetStringId($@"ctf_event_flag_grabbed_from_stand"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_flag_grabbed_cp"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_flag_grab"),
                            SplitscreenSuppression = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CauseTeam,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_taken"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.CaptureTheFlag,
                            Event = CacheContext.StringTable.GetStringId($@"ctf_event_flag_grabbed_from_stand"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"ctf_flag_grabbed_et"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\flag_stolen"),
                        },
                    },
                    OddballEvents = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetStringId($@"oddball_event_game_start"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"oddball_game_start"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\oddball\oddball"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetStringId($@"oddball_event_ball_picked_up"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"oddball_picked_up"),
                            ExcludedAudience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CausePlayer,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\oddball\ball_taken"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetStringId($@"oddball_event_ball_picked_up"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"oddball_picked_up"),
                            ExcludedAudience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CausePlayer,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\oddball\ball_taken"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetStringId($@"oddball_event_ball_dropped"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"oddball_dropped"),
                            ExcludedAudience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CausePlayer,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\oddball\ball_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetStringId($@"oddball_event_ball_spawned"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"oddball_spawned"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\oddball\play_ball"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetStringId($@"oddball_event_ball_reset"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"oddball_reset"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\oddball\ball_reset"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetStringId($@"oddball_event_25_points_remaining"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\twenty_five_points_remaining"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetStringId($@"oddball_event_25_points_remaining"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\twenty_five_points_to_win"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetStringId($@"oddball_event_25_points_remaining"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\twenty_five_points_to_win"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetStringId($@"oddball_event_10_points_remaining"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\ten_points_remaining"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetStringId($@"oddball_event_10_points_remaining"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\general\ten_points_to_win"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Oddball,
                            Event = CacheContext.StringTable.GetStringId($@"oddball_event_10_points_remaining"),
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
                            Event = CacheContext.StringTable.GetStringId($@"king_event_game_start"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"koth_game_start"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\king_of_the_hill\king_of_the_hill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.KingOfTheHill,
                            Event = CacheContext.StringTable.GetStringId($@"king_event_hill_move"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\king_of_the_hill\hill_moved"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.KingOfTheHill,
                            Event = CacheContext.StringTable.GetStringId($@"king_event_hill_controlled"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"koth_hill_controlled"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.KingOfTheHill,
                            Event = CacheContext.StringTable.GetStringId($@"king_event_hill_controlled"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"koth_hill_controlled_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\king_of_the_hill\hill_controlled"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.KingOfTheHill,
                            Event = CacheContext.StringTable.GetStringId($@"king_event_hill_controlled_team"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"koth_hill_controlled_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.KingOfTheHill,
                            Event = CacheContext.StringTable.GetStringId($@"king_event_hill_controlled_team"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"koth_hill_controlled_team_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\king_of_the_hill\hill_controlled"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.KingOfTheHill,
                            Event = CacheContext.StringTable.GetStringId($@"king_event_hill_contested"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.KingOfTheHill,
                            Event = CacheContext.StringTable.GetStringId($@"king_event_hill_contested"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"koth_hill_contested_cp"),
                            SplitscreenSuppression = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.CausePlayer,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\king_of_the_hill\hill_contested"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.KingOfTheHill,
                            Event = CacheContext.StringTable.GetStringId($@"king_event_hill_contested_team"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.KingOfTheHill,
                            Event = CacheContext.StringTable.GetStringId($@"king_event_hill_contested_team"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"koth_hill_contested_team_ct"),
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
                            Event = CacheContext.StringTable.GetStringId($@"vip_event_game_start"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"vip_game_start"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetStringId($@"vip_event_side_switch"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"vip_new_defensive_team"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\offense"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetStringId($@"vip_event_side_switch"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"vip_new_defensive_game_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\defense"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetStringId($@"vip_event_new_vip"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"vip_new_vip"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\vip\new_vip"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetStringId($@"vip_event_new_vip"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"vip_new_vip_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\vip\new_vip"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetStringId($@"vip_event_vip_killed"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"vip_killed_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\vip\vip_killed"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetStringId($@"vip_event_vip_killed"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"vip_killed_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\vip\vip_killed"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetStringId($@"vip_event_vip_killed"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"vip_killed_et"),
                            ExcludedAudience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.EffectPlayer,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\vip\vip_killed"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetStringId($@"vip_event_vip_died"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"vip_death"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetStringId($@"vip_event_vip_died"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"vip_death_et"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetStringId($@"vip_event_reached_destination_area"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"vip_destination_arrived"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetStringId($@"vip_event_reached_destination_area"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayString = CacheContext.StringTable.GetStringId($@"vip_destination_arrived_cp"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Vip,
                            Event = CacheContext.StringTable.GetStringId($@"vip_event_destination_area_moved"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"jugg_destination_moved"),
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
                            Event = CacheContext.StringTable.GetStringId($@"juggernaut_event_game_start"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"jugg_game_start"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\juggernaut\juggernaut"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Juggernaut,
                            Event = CacheContext.StringTable.GetStringId($@"juggernaut_event_new_juggernaut"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"jugg_new_juggernaut"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\juggernaut\new_juggernaut"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Juggernaut,
                            Event = CacheContext.StringTable.GetStringId($@"juggernaut_event_new_juggernaut"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"jugg_new_juggernaut_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\juggernaut\new_juggernaut"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Juggernaut,
                            Event = CacheContext.StringTable.GetStringId($@"juggernaut_event_zone_moved"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"jugg_destination_moved"),
                            SplitscreenSuppression = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.EffectPlayer,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\juggernaut\destination_moved"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Juggernaut,
                            Event = CacheContext.StringTable.GetStringId($@"juggernaut_event_player_kill_juggernaut"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"jugg_kill"),
                            ExcludedAudience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventInputEnum.EffectPlayer,
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Juggernaut,
                            Event = CacheContext.StringTable.GetStringId($@"juggernaut_event_player_kill_juggernaut"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"jugg_kill_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                        },
                    },
                    TerritoriesEvents = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Territories,
                            Event = CacheContext.StringTable.GetStringId($@"territories_event_game_start"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"terr_game_start"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\territories\territories"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Territories,
                            Event = CacheContext.StringTable.GetStringId($@"territories_event_side_switch"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"terr_new_defensive_team"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\offense"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Territories,
                            Event = CacheContext.StringTable.GetStringId($@"territories_event_side_switch"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"terr_new_defensive_team_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\capture_the_flag\defense"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Territories,
                            Event = CacheContext.StringTable.GetStringId($@"territories_event_territory_captured"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"terr_captured"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\territories\territory_captured"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Territories,
                            Event = CacheContext.StringTable.GetStringId($@"territories_event_territory_captured"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"terr_captured_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\territories\territory_captured"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Territories,
                            Event = CacheContext.StringTable.GetStringId($@"territories_event_territory_captured"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"terr_captured_et"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\territories\territory_lost"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Territories,
                            Event = CacheContext.StringTable.GetStringId($@"territories_event_territory_captured"),
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"terr_captured_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\territories\territory_captured"),
                        },
                    },
                    AssaultEvents = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetStringId($@"assault_event_game_start"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"assault_game_start"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\assault"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetStringId($@"assault_event_bomb_taken"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_taken"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetStringId($@"assault_event_bomb_taken"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"assault_bomb_pickup_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_taken"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetStringId($@"assault_event_bomb_dropped"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetStringId($@"assault_event_bomb_dropped"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"assault_bomb_dropped_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_dropped"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetStringId($@"assault_event_bomb_returned_by_player"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"assault_bomb_returned"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_returned"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetStringId($@"assault_event_bomb_returned_by_player"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"assault_bomb_returned_cp"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_bomb_return"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_returned"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetStringId($@"assault_event_bomb_returned_by_player"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"assault_bomb_returned_et"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_returned"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetStringId($@"assault_event_bomb_returned_by_timeout"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"assault_bomb_reset"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_reset"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetStringId($@"assault_event_bomb_returned_by_timeout"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"assault_bomb_reset_et"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_reset"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetStringId($@"assault_event_bomb_placed_on_enemy_post"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"assault_bomb_armed"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_armed"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetStringId($@"assault_event_bomb_placed_on_enemy_post"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"assault_bomb_armed_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_armed"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetStringId($@"assault_event_bomb_placed_on_enemy_post"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"assault_bomb_armed_cp"),
                            MedalAward = CacheContext.StringTable.GetStringId($@"medal_bomb_planted"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_armed"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetStringId($@"assault_event_bomb_captured"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"assault_bomb_detonated"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_detonated"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetStringId($@"assault_event_bomb_captured"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"assault_bomb_detonated_ct"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_detonated"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetStringId($@"assault_event_bomb_disarmed"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"assault_bomb_disarmed"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_disarmed"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetStringId($@"assault_event_bomb_disarmed"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"assault_bomb_disarmed_et"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_disarmed"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetStringId($@"assault_event_bomb_disarmed"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"assault_bomb_disarmed_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_disarmed"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetStringId($@"assault_event_neutral_bomb_returned"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"assault_bomb_neutral_reset"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\assault\bomb_reset"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Assault,
                            Event = CacheContext.StringTable.GetStringId($@"assault_event_last_player_on_team"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"inf_last_man"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                        },
                    },
                    InfectionEvents = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Infection,
                            Event = CacheContext.StringTable.GetStringId($@"infection_event_game_start"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"inf_game_start"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Infection,
                            Event = CacheContext.StringTable.GetStringId($@"infection_event_new_infection"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"inf_new_infection_cp"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Infection,
                            Event = CacheContext.StringTable.GetStringId($@"infection_event_new_infection"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.CauseTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Friendly,
                            DisplayString = CacheContext.StringTable.GetStringId($@"inf_new_infection_ct"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Infection,
                            Event = CacheContext.StringTable.GetStringId($@"infection_event_new_infection"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectTeam,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Enemy,
                            DisplayString = CacheContext.StringTable.GetStringId($@"inf_new_infection_et"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Infection,
                            Event = CacheContext.StringTable.GetStringId($@"infection_event_new_infection"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.EffectPlayer,
                            DisplayString = CacheContext.StringTable.GetStringId($@"inf_new_infection_ep"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\infection\infected"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Infection,
                            Event = CacheContext.StringTable.GetStringId($@"infection_event_zombie_spawn"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"inf_new_zombie"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\infection\new_zombie"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Infection,
                            Event = CacheContext.StringTable.GetStringId($@"infection_event_zombie_spawn"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"inf_new_zombie_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\infection\new_zombie"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Infection,
                            Event = CacheContext.StringTable.GetStringId($@"infection_event_survive"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"inf_last_man_cp"),
                            SoundFlags = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.SoundResponseFlags.AnnouncerSound,
                            EnglishSound = GetCachedTag<Sound>($@"sound\dialog\multiplayer_en\infection\last_man_standing"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Infection,
                            Event = CacheContext.StringTable.GetStringId($@"infection_event_survive"),
                            Audience = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.AudienceValue.All,
                            DisplayContext = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.EventResponseContext.Neutral,
                            DisplayString = CacheContext.StringTable.GetStringId($@"inf_last_man"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock()
                        {
                            RuntimeEventType = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.EventBlock.TypeValue.Infection,
                            Event = CacheContext.StringTable.GetStringId($@"infection_event_alpha_zombie_spawn"),
                            DisplayString = CacheContext.StringTable.GetStringId($@"inf_new_alpha"),
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
                            BombDefusalString = CacheContext.StringTable.GetStringId($@"assault_defusal"),
                            BlockedTeleporterString = CacheContext.StringTable.GetStringId($@"game_engine_blocked_teleporter"),
                            UnknownHO = 3,
                            SpawnAllowedDefaultRespawnString = CacheContext.StringTable.GetStringId($@"spawn_allowed_default_respawn_string"),
                            SpawnAtPlayerAllowedLookingAtSelfString = CacheContext.StringTable.GetStringId($@"spawn_at_player_allowed_looking_at_self_string"),
                            SpawnAtPlayerAllowedLookingAtTargetString = CacheContext.StringTable.GetStringId($@"spawn_at_player_allowed_looking_at_target_string"),
                            SpawnAtPlayerAllowedLookingAtPotentialTargetString = CacheContext.StringTable.GetStringId($@"spawn_at_player_allowed_looking_at_potential_target_string"),
                            SpawnAtTerritoryAllowedLookingAtTargetString = CacheContext.StringTable.GetStringId($@"spawn_at_territory_allowed_looking_at_target_string"),
                            SpawnAtTerritoryAllowedLookingAtPotentialTargetString = CacheContext.StringTable.GetStringId($@"spawn_at_territory_allowed_looking_at_potential_target_string"),
                            PlayerOutOfLivesString = CacheContext.StringTable.GetStringId($@"player_out_of_lives_string"),
                            InvalidSpawnTargetString = CacheContext.StringTable.GetStringId($@"invalid_spawn_target_string"),
                            TargetedPlayerEnemiesNearbyString = CacheContext.StringTable.GetStringId($@"targetted_player_enemies_near_by_string"),
                            TargetedPlayerUnfriendlyTeamString = CacheContext.StringTable.GetStringId($@"targetted_player_unfriendly_team_string"),
                            TargetedPlayerIsDeadString = CacheContext.StringTable.GetStringId($@"targetted_player_is_dead_string"),
                            TargetedPlayerInCombatString = CacheContext.StringTable.GetStringId($@"targetted_player_in_combat_shields_string"),
                            TargetedPlayerTooFarFromOwnedFlagString = CacheContext.StringTable.GetStringId($@"targetted_player_too_far_from_owned_flag_string"),
                            NoAvailableNetpointsString = CacheContext.StringTable.GetStringId($@"no_available_netpoints_string"),
                            NetpointContestedString = CacheContext.StringTable.GetStringId($@"netpoint_contested_string"),
                        },
                    },
                    StateResponses = new List<MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse>()
                    {
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"state_waiting_for_space_to_clear"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"state_waiting_for_space_to_clear"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.Observing,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"state_observing"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"state_observing"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.RespawningSoon,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"state_respawning_soon"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"state_respawning_soon"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.SittingOut,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"state_sitting_out"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"state_sitting_out"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.OutOfLives,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"state_out_of_lives"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"state_out_of_lives"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.GameOverWon,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"state_game_over_won_ffa"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"state_game_over_won_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.GameOverTied,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"state_game_over_tied"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"state_game_over_tied"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.GameOverTied2,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"state_game_over_tied"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"state_game_over_tied"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.GameOverLost,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"state_game_over_lost_ffa"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"state_game_over_lost_team"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.EnemyHasFlag,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"state_enemy_has_your_flag"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"state_enemy_has_your_flag"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.YouAreJuggernaut,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"state_you_are_juggernaut"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"state_you_are_juggernaut"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.YouControlHill,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"state_you_control_hill"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"state_you_control_hill"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.PlayerRecentlyStarted,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"state_recently_started"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"state_recently_started"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.FlagContested,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"state_flag_contested"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"state_flag_contested"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.BombContested,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"state_bomb_contested"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"state_bomb_contested"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.PlayingWinning,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"playing_winning_f"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"playing_winning_t"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.PlayingTied,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"playing_tied_f"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"playing_tied_t"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.PlayingLosing,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"playing_losing_f"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"playing_losing_t"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.LimitedLivesMultiple,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"state_limited_lives_multiple"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"state_limited_lives_multiple"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.LimitedLivesSingle,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"state_limited_lives_multiple"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"state_limited_lives_multiple"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.LimitedLivesFinal,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"state_limited_lives_final"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"state_limited_lives_final"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.PlayingWinningUnlimited,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"playing_winning_f_unlimited"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"playing_winning_t_unlimited"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.PlayingTiedUnlimited,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"playing_tied_f_unlimited"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"playing_tied_t_unlimited"),
                        },
                        new MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse
                        {
                            State = TagTool.Tags.Definitions.MultiplayerGlobals.MultiplayerRuntimeBlock.StateResponse.GameEngineStatus.PlayingLosingUnlimited,
                            FreeForAllMessage = CacheContext.StringTable.GetStringId($@"playing_losing_f_unlimited"),
                            TeamMessage = CacheContext.StringTable.GetStringId($@"playing_losing_t_unlimited"),
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
                }
            };
            CacheContext.Serialize(Stream, tag, mulg);
        }
    }
}
