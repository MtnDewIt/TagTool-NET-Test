using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Tags 
{
    public class levels_multi_s3d_avalanche_s3d_avalanche_scenario : TagFile
    {
        public levels_multi_s3d_avalanche_s3d_avalanche_scenario(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\multi\s3d_avalanche\s3d_avalanche");
            var scnr = CacheContext.Deserialize<Scenario>(Stream, tag);

            UpdateForgePalette(scnr);

            scnr.AcousticsPalette = new List<ScenarioStructureBsp.AcousticsPaletteBlock>
            {
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"desert_wind"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\mountains"),
                    ReverbInterpolationSpeed = 1f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_diamondback\amb_desert_wind\amb_desert_wind"),
                    AmbienceInterpolationSpeed = 1f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"general_roomtone"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\hallway"),
                    ReverbInterpolationSpeed = 1f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_diamondback\amb_gen_roomtone\amb_gen_roomtone"),
                    AmbienceInterpolationSpeed = 1f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"cave_wind"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\cave"),
                    ReverbInterpolationSpeed = 1f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_diamondback\amb_cave_wind\amb_cave_wind"),
                    AmbienceInterpolationSpeed = 1f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"cave_wind_and_drips"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\cave"),
                    ReverbInterpolationSpeed = 1f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_diamondback\amb_cave_wind_and_drips\amb_cave_wind_and_drips"),
                    AmbienceInterpolationSpeed = 1f,
                },
            };
            scnr.SimulationDefinitionTable = null;
            CacheContext.Serialize(Stream, tag, scnr);
        }
    }
}
