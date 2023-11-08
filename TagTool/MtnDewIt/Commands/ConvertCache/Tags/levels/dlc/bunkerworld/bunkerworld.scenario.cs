using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class levels_dlc_bunkerworld_bunkerworld_scenario : TagFile
    {
        public levels_dlc_bunkerworld_bunkerworld_scenario(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\dlc\bunkerworld\bunkerworld");
            var scnr = CacheContext.Deserialize<Scenario>(Stream, tag);
            scnr.SandboxVehicles = null;
            scnr.SandboxWeapons = null;
            scnr.SandboxEquipment = null;
            scnr.SandboxScenery = null;
            scnr.SandboxTeleporters = null;
            scnr.SandboxGoalObjects = null;
            scnr.SandboxSpawning = null;
            scnr.PlayerStartingProfile = new List<Scenario.PlayerStartingProfileBlock>
            {
                new Scenario.PlayerStartingProfileBlock
                {
                    Name = "start_assault",
                    PrimaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
                    PrimaryRoundsLoaded = 32,
                    PrimaryRoundsTotal = 96,
                    SecondaryWeapon = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum"),
                    SecondaryRoundsLoaded = 8,
                    SecondaryRoundsTotal = 24,
                    StartingFragGrenadeCount = 2,
                    EditorFolder = -1,
                },
            };
            scnr.AcousticsPalette = new List<ScenarioStructureBsp.AcousticsPaletteBlock>
            {
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"bunkerworld_ext"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\mountains"),
                    ReverbCutoffDistance = 2f,
                    ReverbInterpolationSpeed = 1f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\dlc\bunkerworld\bunkerworld_ext\bunkerworld_ext"),
                    AmbienceCutoffDistance = 4f,
                    AmbienceInterpolationSpeed = 1.5f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"hallway"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\cpaul_stone_room"),
                    ReverbCutoffDistance = 2f,
                    ReverbInterpolationSpeed = 1f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\dlc\bunkerworld\hallway\hallway"),
                    AmbienceCutoffDistance = 3f,
                    AmbienceInterpolationSpeed = 1.5f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"controlroom"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\cpaul_stone_room"),
                    ReverbCutoffDistance = 2f,
                    ReverbInterpolationSpeed = 1f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\dlc\bunkerworld\controlroom\controlroom"),
                    AmbienceCutoffDistance = 2f,
                    AmbienceInterpolationSpeed = 1.5f,
                },
            };
            CacheContext.Serialize(Stream, tag, scnr);
        }
    }
}
