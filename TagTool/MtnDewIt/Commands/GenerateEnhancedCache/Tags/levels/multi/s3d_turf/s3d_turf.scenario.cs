using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Tags 
{
    public class levels_multi_s3d_turf_s3d_turf_scenario : TagFile
    {
        public levels_multi_s3d_turf_s3d_turf_scenario(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\multi\s3d_turf\s3d_turf");
            var scnr = CacheContext.Deserialize<Scenario>(Stream, tag);

            UpdateForgePalette(scnr);

            scnr.EnemyBiasInfluence = new List<Scenario.PlayerSpawnInfluencerBlock>
            {
                new Scenario.PlayerSpawnInfluencerBlock
                {
                    OverrideFullWeightRadius = 15f,
                    OverrideFalloffRadius = 20f,
                    OverrideUpperHeight = 7f,
                    OverrideLowerHeight = -5f,
                    OverrideWeight = -270f,
                },
            };
            scnr.AcousticsPalette = new List<ScenarioStructureBsp.AcousticsPaletteBlock>
            {
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"amb_heavy_snow"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\city"),
                    ReverbInterpolationSpeed = 0.5f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_turf\amb_heavy_snow\amb_heavy_snow"),
                    AmbienceCutoffDistance = 1,
                    AmbienceInterpolationSpeed = 0.5f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"amb_light_snow"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\hallway"),
                    ReverbInterpolationSpeed = 2f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\multi\s3d_turf\amb_light_snow\amb_light_snow"),
                    AmbienceCutoffDistance = 1,
                    AmbienceInterpolationSpeed = 2f,
                },
            };
            scnr.SimulationDefinitionTable = null;
            CacheContext.Serialize(Stream, tag, scnr);
        }
    }
}
