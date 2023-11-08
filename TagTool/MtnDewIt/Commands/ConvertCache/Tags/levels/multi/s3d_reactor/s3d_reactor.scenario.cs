using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class levels_multi_s3d_reactor_s3d_reactor_scenario : TagFile
    {
        public levels_multi_s3d_reactor_s3d_reactor_scenario(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\multi\s3d_reactor\s3d_reactor");
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
                    Name = CacheContext.StringTable.GetStringId($@"amb_wind_mountains"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\mountains"),
                    ReverbInterpolationSpeed = 2f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_reactor\amb_wind_mountains\amb_wind_mountains"),
                    AmbienceInterpolationSpeed = 2f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"amb_interior_room_small"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\room"),
                    Type = ScenarioStructureBsp.SoundEnvironmentType.InteriorNarrow,
                    ReverbInterpolationSpeed = 2f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_reactor\amb_interior_room_small\amb_interior_room_small"),
                    AmbienceInterpolationSpeed = 2f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"amb_interior_reactor"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\hallway"),
                    Type = ScenarioStructureBsp.SoundEnvironmentType.InteriorNarrow,
                    ReverbInterpolationSpeed = 2f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_reactor\amb_interior_reactor\amb_interior_reactor"),
                    AmbienceInterpolationSpeed = 2f,
                },
            };
            CacheContext.Serialize(Stream, tag, scnr);
        }
    }
}
