using System.Collections.Generic;
using TagTool.Tags.Definitions;
using TagTool.Common;

namespace TagTool.Commands.Tags
{
    partial class PortingCacheCommand : Command
    {
        // Modifies the global tags, with valid data (This is required as all these values are null after the cache is rebuilt)
        public void modifyGlobals() 
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    if (tag.IsInGroup("matg") && tag.Name == $@"globals\globals")
                    {
                        var matg = CacheContext.Deserialize<Globals>(stream, tag);
                        matg.Grenades[0].Equipment = CacheContext.TagCache.GetTag<Equipment>($@"objects\weapons\grenade\frag_grenade\frag_grenade");
                        matg.Grenades[0].Projectile = CacheContext.TagCache.GetTag<Projectile>($@"objects\weapons\grenade\frag_grenade\frag_grenade");
                        matg.Grenades[1].Equipment = CacheContext.TagCache.GetTag<Equipment>($@"objects\weapons\grenade\plasma_grenade\plasma_grenade");
                        matg.Grenades[1].Projectile = CacheContext.TagCache.GetTag<Projectile>($@"objects\weapons\grenade\plasma_grenade\plasma_grenade");
                        matg.Grenades[2].Equipment = CacheContext.TagCache.GetTag<Equipment>($@"objects\weapons\grenade\claymore_grenade\claymore_grenade");
                        matg.Grenades[2].Projectile = CacheContext.TagCache.GetTag<Projectile>($@"objects\weapons\grenade\claymore_grenade\claymore_grenade");
                        matg.Grenades[3].Equipment = CacheContext.TagCache.GetTag<Equipment>($@"objects\weapons\grenade\firebomb_grenade\firebomb_grenade");
                        matg.Grenades[3].Projectile = CacheContext.TagCache.GetTag<Projectile>($@"objects\weapons\grenade\firebomb_grenade\projectiles\firebomb_grenade");
                        matg.InterfaceTags[0].MainMenuUiGlobals = CacheContext.TagCache.GetTag<UserInterfaceGlobalsDefinition>($@"ui\main_menu");
                        matg.InterfaceTags[0].SinglePlayerUiGlobals = CacheContext.TagCache.GetTag<UserInterfaceGlobalsDefinition>($@"ui\single_player");
                        matg.InterfaceTags[0].MultiplayerUiGlobals = CacheContext.TagCache.GetTag<UserInterfaceGlobalsDefinition>($@"ui\multiplayer");
                        matg.InterfaceTags[0].HudGlobals = CacheContext.TagCache.GetTag<ChudGlobalsDefinition>($@"ui\chud\globals");

                        // Assigns Halo 3 player bipeds
                        matg.PlayerRepresentation[0].Name = CacheContext.StringTable.GetStringId($@"masterchief"); // 0.7 specifc (used in the PlayerCharacterType blocks)
                        matg.PlayerRepresentation[0].FirstPersonHands = CacheContext.TagCache.GetTag<RenderModel>($@"objects\characters\masterchief\fp\fp");
                        matg.PlayerRepresentation[0].FirstPersonBody = CacheContext.TagCache.GetTag<RenderModel>($@"objects\characters\masterchief\fp_body\fp_body");
                        matg.PlayerRepresentation[0].ThirdPersonUnit = CacheContext.TagCache.GetTag<Biped>($@"objects\characters\masterchief\masterchief");
                        matg.PlayerRepresentation[0].BinocularsZoomInSound = CacheContext.TagCache.GetTag<Sound>($@"sound\game_sfx\ui\binoculars\binocs_in_click");
                        matg.PlayerRepresentation[0].BinocularsZoomOutSound = CacheContext.TagCache.GetTag<Sound>($@"sound\game_sfx\ui\binoculars\binocs_out_click");
                        matg.PlayerRepresentation[1].FirstPersonHands = CacheContext.TagCache.GetTag<RenderModel>($@"objects\characters\dervish\fp\fp");
                        matg.PlayerRepresentation[1].FirstPersonBody = CacheContext.TagCache.GetTag<RenderModel>($@"objects\characters\dervish\fp_body\fp_body");
                        matg.PlayerRepresentation[1].ThirdPersonUnit = CacheContext.TagCache.GetTag<Biped>($@"objects\characters\dervish\dervish");
                        matg.PlayerRepresentation[1].BinocularsZoomInSound = CacheContext.TagCache.GetTag<Sound>($@"sound\game_sfx\ui\binoculars\binocs_in_click");
                        matg.PlayerRepresentation[1].BinocularsZoomOutSound = CacheContext.TagCache.GetTag<Sound>($@"sound\game_sfx\ui\binoculars\binocs_out_click");
                        matg.PlayerRepresentation[2].FirstPersonHands = CacheContext.TagCache.GetTag<RenderModel>($@"objects\characters\masterchief\mp_masterchief\fp\fp");
                        matg.PlayerRepresentation[2].FirstPersonBody = CacheContext.TagCache.GetTag<RenderModel>($@"objects\characters\masterchief\mp_masterchief\fp_body\fp_body");
                        matg.PlayerRepresentation[2].ThirdPersonUnit = CacheContext.TagCache.GetTag<Biped>($@"objects\characters\masterchief\mp_masterchief\mp_masterchief");
                        matg.PlayerRepresentation[2].BinocularsZoomInSound = CacheContext.TagCache.GetTag<Sound>($@"sound\game_sfx\ui\binoculars\binocs_in_click");
                        matg.PlayerRepresentation[2].BinocularsZoomOutSound = CacheContext.TagCache.GetTag<Sound>($@"sound\game_sfx\ui\binoculars\binocs_out_click");
                        matg.PlayerRepresentation[3].FirstPersonHands = CacheContext.TagCache.GetTag<RenderModel>($@"objects\characters\elite\mp_elite\fp\fp");
                        matg.PlayerRepresentation[3].FirstPersonBody = CacheContext.TagCache.GetTag<RenderModel>($@"objects\characters\elite\mp_elite\fp_body\fp_body");
                        matg.PlayerRepresentation[3].ThirdPersonUnit = CacheContext.TagCache.GetTag<Biped>($@"objects\characters\elite\mp_elite\mp_elite");
                        matg.PlayerRepresentation[3].BinocularsZoomInSound = CacheContext.TagCache.GetTag<Sound>($@"sound\game_sfx\ui\binoculars\binocs_in_click");
                        matg.PlayerRepresentation[3].BinocularsZoomOutSound = CacheContext.TagCache.GetTag<Sound>($@"sound\game_sfx\ui\binoculars\binocs_out_click");
                        matg.PlayerRepresentation[4].FirstPersonHands = CacheContext.TagCache.GetTag<RenderModel>($@"objects\characters\elite\fp_arms\fp_arms");
                        matg.PlayerRepresentation[4].FirstPersonBody = CacheContext.TagCache.GetTag<RenderModel>($@"objects\characters\elite\fp_body\fp_body");
                        matg.PlayerRepresentation[4].ThirdPersonUnit = CacheContext.TagCache.GetTag<Biped>($@"objects\characters\elite\elite_sp");
                        matg.PlayerRepresentation[4].BinocularsZoomInSound = CacheContext.TagCache.GetTag<Sound>($@"sound\game_sfx\ui\binoculars\binocs_in_click");
                        matg.PlayerRepresentation[4].BinocularsZoomOutSound = CacheContext.TagCache.GetTag<Sound>($@"sound\game_sfx\ui\binoculars\binocs_out_click");
                        matg.PlayerRepresentation[5].ThirdPersonUnit = CacheContext.TagCache.GetTag<Biped>($@"objects\characters\monitor\monitor_editor");

                        // Used to assign player character types (string ids and sbyte values reference data from player representation blocks)
                        matg.PlayerCharacterTypes = new List<Globals.PlayerCharacterType>()
                        {
                            new Globals.PlayerCharacterType()
                            {
                                Name = CacheContext.StringTable.GetStringId($@"masterchief"),
                                CampaignRepresentation = 0,
                                MultiplayerRepresentation = 2,
                                MultiplayerArmorCustomization = 0,
                            },
                            new Globals.PlayerCharacterType()
                            {
                                Name = CacheContext.StringTable.GetStringId($@"dervish"),
                                CampaignRepresentation = 1,
                                MultiplayerRepresentation = 3,
                                MultiplayerArmorCustomization = 1,
                            },
                        };

                        matg.CinematicGlobals[0].CinematicAnchor = CacheContext.TagCache.GetTag<Scenery>($@"objects\cinematics\cinematic_anchor\cinematic_anchor"); // Required in order for cutscenes to function correctly
                        CacheContext.Serialize(stream, tag, matg);
                    }

                    // Modifies the multiplayer globals data (this tag is completely reformated with Halo 3 weapon values during the rebuilding process)
                    if (tag.IsInGroup("mulg") && tag.Name == $@"multiplayer\multiplayer_globals")
                    {
                        var mulg = CacheContext.Deserialize<MultiplayerGlobals>(stream, tag);

                        mulg.Universal[0].TeamColors = new List<MultiplayerGlobals.MultiplayerUniversalBlock.MultiplayerColor>()
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
                        };

                        mulg.Universal[0].CustomizableCharacters = new List<MultiplayerGlobals.MultiplayerUniversalBlock.CustomizedModelCharacter>()
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
                        };

                        mulg.Universal[0].Equipment[0].Object = null;
                        mulg.Universal[0].Equipment[1].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\jammer_equipment\jammer_equipment");
                        mulg.Universal[0].Equipment[2].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\powerdrain_equipment\powerdrain_equipment");
                        mulg.Universal[0].Equipment[3].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\bubbleshield_equipment\bubbleshield_equipment");
                        mulg.Universal[0].Equipment[4].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\superflare_equipment\superflare_equipment");
                        mulg.Universal[0].Equipment[5].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\regenerator_equipment\regenerator_equipment");
                        mulg.Universal[0].Equipment[6].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\tripmine_equipment\tripmine_equipment");
                        mulg.Universal[0].Equipment[7].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\instantcover_equipment\instantcover_equipment_mp");
                        mulg.Universal[0].Equipment[8].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\invincibility_equipment\invincibility_equipment");
                        mulg.Universal[0].Equipment[9].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\gravlift_equipment\gravlift_equipment");
                        mulg.Universal[0].Equipment[10].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\autoturret_equipment\autoturret_equipment");
                        mulg.Universal[0].Equipment[11].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\invisibility_equipment\invisibility_equipment");
                        mulg.Universal[0].Equipment[12].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\instantcover_equipment\instantcover_equipment");
                        mulg.Universal[0].GameVariantWeapons[0].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle");
                        mulg.Universal[0].GameVariantWeapons[1].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle");
                        mulg.Universal[0].GameVariantWeapons[2].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol");
                        mulg.Universal[0].GameVariantWeapons[3].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle");
                        mulg.Universal[0].GameVariantWeapons[4].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\smg\smg");
                        mulg.Universal[0].GameVariantWeapons[5].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine");
                        mulg.Universal[0].GameVariantWeapons[6].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\melee\energy_blade\energy_blade");
                        mulg.Universal[0].GameVariantWeapons[7].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\magnum\magnum");
                        mulg.Universal[0].GameVariantWeapons[8].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler");
                        mulg.Universal[0].GameVariantWeapons[9].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle");
                        mulg.Universal[0].GameVariantWeapons[10].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_high\rocket_launcher\rocket_launcher");
                        mulg.Universal[0].GameVariantWeapons[11].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\shotgun\shotgun");
                        mulg.Universal[0].GameVariantWeapons[12].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\sniper_rifle\sniper_rifle");
                        mulg.Universal[0].GameVariantWeapons[13].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot");
                        mulg.Universal[0].GameVariantWeapons[14].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\melee\energy_blade\energy_blade_useless");
                        mulg.Universal[0].GameVariantWeapons[15].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\beam_rifle\beam_rifle");
                        mulg.Universal[0].GameVariantWeapons[16].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_high\spartan_laser\spartan_laser");
                        mulg.Universal[0].GameVariantWeapons[17].Weapon = null;
                        mulg.Universal[0].GameVariantWeapons[18].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\melee\gravity_hammer\gravity_hammer");
                        mulg.Universal[0].GameVariantWeapons[19].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\excavator\excavator");
                        mulg.Universal[0].GameVariantWeapons[20].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\turret\flamethrower\flamethrower");
                        mulg.Universal[0].GameVariantWeapons[21].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\turret\missile_pod\missile_pod");
                        mulg.Universal[0].GameVariantGrenades[0].Grenade = CacheContext.TagCache.GetTag<Equipment>($@"objects\weapons\grenade\frag_grenade\frag_grenade");
                        mulg.Universal[0].GameVariantGrenades[1].Grenade = CacheContext.TagCache.GetTag<Equipment>($@"objects\weapons\grenade\plasma_grenade\plasma_grenade");
                        mulg.Runtime[0].EditorBiped = CacheContext.TagCache.GetTag<Biped>($@"objects\characters\monitor\monitor_editor");
                        mulg.Runtime[0].EditorHelperObject = CacheContext.TagCache.GetTag<Scenery>($@"objects\ui\editor_gizmo\editor_gizmo");
                        mulg.Runtime[0].Flag = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\multiplayer\flag\flag");
                        mulg.Runtime[0].Ball = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\multiplayer\ball\ball");
                        mulg.Runtime[0].Bomb = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\multiplayer\assault_bomb\assault_bomb");
                        mulg.Runtime[0].VipInfluenceArea = CacheContext.TagCache.GetTag<Crate>($@"objects\multi\vip\vip_boundary");
                        mulg.Runtime[0].HaloOnlineRuntimeEffects.ThusIRefuteTheeEffect = CacheContext.TagCache.GetTag<Projectile>($@"objects\weapons\grenade\plasma_grenade\plasma_grenade");
                        CacheContext.Serialize(stream, tag, mulg);
                    }
                }
            }
        }
    }
}