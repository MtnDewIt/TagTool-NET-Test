using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Tags 
{
    public class levels_multi_chill_chill_scenario : TagFile
    {
        public levels_multi_chill_chill_scenario(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\multi\chill\chill");
            var scnr = CacheContext.Deserialize<Scenario>(Stream, tag);

            UpdateForgePalette(scnr);

            scnr.AcousticsPalette = new List<ScenarioStructureBsp.AcousticsPaletteBlock>
            {
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"chill"),
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\chill\chill\chill"),
                    AmbienceCutoffDistance = 2f,
                    AmbienceInterpolationSpeed = 1f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"chill_verb"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_2_presets\cpaul_little_something_slightly_bigger_new"),
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\chill\chill\chill"),
                    AmbienceCutoffDistance = 2f,
                    AmbienceInterpolationSpeed = 1f,
                },
            };
            scnr.SimulationDefinitionTable = null;
            CacheContext.Serialize(Stream, tag, scnr);
        }
    }
}
