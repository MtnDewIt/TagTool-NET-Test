using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Tags 
{
    public class levels_multi_guardian_guardian_scenario : TagFile
    {
        public levels_multi_guardian_guardian_scenario(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\multi\guardian\guardian");
            var scnr = CacheContext.Deserialize<Scenario>(Stream, tag);

            UpdateForgePalette(scnr);

            scnr.AcousticsPalette = new List<ScenarioStructureBsp.AcousticsPaletteBlock>
            {
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"gaurdian"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\cpaul_jungle4"),
                    ReverbCutoffDistance = 1,
                    ReverbInterpolationSpeed = 0.2f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\gaurdian\gaurdian\gaurdian"),
                    AmbienceCutoffDistance = 3,
                    AmbienceInterpolationSpeed = 0.5f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"gaurdian_inside"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\jay_hallway"),
                    ReverbCutoffDistance = 1,
                    ReverbInterpolationSpeed = 0.2f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\gaurdian\gaurdian_half_inside\gaurdian_half_inside"),
                    AmbienceCutoffDistance = 3,
                    AmbienceInterpolationSpeed = 0.5f,
                },
            };
            scnr.SimulationDefinitionTable = null;
            CacheContext.Serialize(Stream, tag, scnr);
        }
    }
}
