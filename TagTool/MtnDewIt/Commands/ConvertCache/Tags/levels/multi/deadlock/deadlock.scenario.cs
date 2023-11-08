using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class levels_multi_deadlock_deadlock_scenario : TagFile
    {
        public levels_multi_deadlock_deadlock_scenario(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\multi\deadlock\deadlock");
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
                    Name = CacheContext.StringTable.GetStringId($@"deadlock_air"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\mountains"),
                    ReverbCutoffDistance = 1.5f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\deadlock\deadlock_air\deadlock_air"),
                    AmbienceCutoffDistance = 3f,
                    AmbienceInterpolationSpeed = 0.5f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"deadlock_cave"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\jay_cave"),
                    ReverbCutoffDistance = 2f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\deadlock\deadlock_cave\deadlock_cave"),
                    AmbienceCutoffDistance = 2f,
                    AmbienceInterpolationSpeed = 0.5f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"deadlock_inside"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"ms30\sound\dsp_effects\reverbs\templates\stone_room"),
                    ReverbCutoffDistance = 2f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\deadlock\deadlock_inside\deadlock_inside"),
                    AmbienceCutoffDistance = 1f,
                    AmbienceInterpolationSpeed = 0.5f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"deadlock_tube"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\cpaul_sewer_pipe"),
                    ReverbCutoffDistance = 2f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\deadlock\deadlock_tube\deadlock_tube"),
                    AmbienceCutoffDistance = 1f,
                    AmbienceInterpolationSpeed = 0.5f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"deadlock_air_light"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\mountains"),
                    ReverbCutoffDistance = 2f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\deadlock\deadlock_air_light\deadlock_air_light"),
                    AmbienceCutoffDistance = 3f,
                    AmbienceInterpolationSpeed = 0.5f,
                },
            };
            CacheContext.Serialize(Stream, tag, scnr);
        }
    }
}
