using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class levels_multi_zanzibar_zanzibar_scenario : TagFile
    {
        public levels_multi_zanzibar_zanzibar_scenario(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\multi\zanzibar\zanzibar");
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
                    Name = CacheContext.StringTable.GetStringId($@"zanzibar_courtyard"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\mountains"),
                    ReverbCutoffDistance = 2f,
                    ReverbInterpolationSpeed = 1f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\zanzibar\zanzibar_courtyard\zanzibar_courtyard"),
                    AmbienceCutoffDistance = 3f,
                    AmbienceInterpolationSpeed = 2f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"zanzibar_ocean_waves"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\mountains"),
                    ReverbCutoffDistance = 2f,
                    ReverbInterpolationSpeed = 1f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\zanzibar\zanzibar_ocean_loop\zanzibar_ocean_loop"),
                    AmbienceCutoffDistance = 2f,
                    AmbienceInterpolationSpeed = 2f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"ocean_waves_inside"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_2_presets\cpaul_little_somethin_slightly_smaller_new"),
                    ReverbCutoffDistance = 1f,
                    ReverbInterpolationSpeed = 1f,
                    AmbienceCutoffDistance = 2f,
                    AmbienceScaleFlags = ScenarioStructureBsp.BackgroundSoundScaleFlags.OverrideDefaultScale | ScenarioStructureBsp.BackgroundSoundScaleFlags.UseAdjacentClusterAsPortalScale,
                    AmbienceInteriorScale = 0.8f,
                    AmbienceInterpolationSpeed = 2f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"zanzibar_base_roomtone"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\cpaul_stone_room_zanzibar_base"),
                    Type = ScenarioStructureBsp.SoundEnvironmentType.InteriorNarrow,
                    ReverbCutoffDistance = 2f,
                    ReverbInterpolationSpeed = 1f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\zanzibar\zanzibar_base_roomtone\zanzibar_base_roomtone"),
                    AmbienceCutoffDistance = 2f,
                    AmbienceInterpolationSpeed = 2f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"zanzaibar_froman_roomtone"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\cpaul_stone_room_new_zanzibar"),
                    Type = ScenarioStructureBsp.SoundEnvironmentType.InteriorNarrow,
                    ReverbCutoffDistance = 2f,
                    ReverbInterpolationSpeed = 1f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\zanzibar\zanzibar_froman_roomtone\zanzibar_froman_roomtone"),
                    AmbienceCutoffDistance = 2f,
                    AmbienceInterpolationSpeed = 2f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"cave"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\cpaul_stone_room_new_zanzibar"),
                    ReverbCutoffDistance = 1f,
                    ReverbInterpolationSpeed = 1f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\zanzibar\zanzibar_cave\zanzibar_cave"),
                },
            };
            scnr.LightmapAirprobes = new List<Scenario.LightmapAirprobe>
            {
                new Scenario.LightmapAirprobe
                {
                    Position = new RealPoint3d(0.0744535f, 3.68988f, 8.19632f),
                    Name = CacheContext.StringTable.GetStringId($@"big_wheel_probe"),
                },
            };
            CacheContext.Serialize(Stream, tag, scnr);
        }
    }
}
