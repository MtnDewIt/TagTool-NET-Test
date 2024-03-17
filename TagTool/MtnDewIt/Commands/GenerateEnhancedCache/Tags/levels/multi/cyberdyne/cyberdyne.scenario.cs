using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Tags 
{
    public class levels_multi_cyberdyne_cyberdyne_scenario : TagFile
    {
        public levels_multi_cyberdyne_cyberdyne_scenario(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\multi\cyberdyne\cyberdyne");
            var scnr = CacheContext.Deserialize<Scenario>(Stream, tag);

            UpdateForgePalette(scnr);

            scnr.AcousticsPalette = new List<ScenarioStructureBsp.AcousticsPaletteBlock>
            {
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"main_hallway"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"ms30\sound\dsp_effects\reverbs\halo_3_presets\jay_stone_room"),
                    ReverbCutoffDistance = 1f,
                    ReverbInterpolationSpeed = 0.1f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\cyberdyne\cyberdyne_main_hallway\cyberdyne_main_hallway"),
                    AmbienceCutoffDistance = 2f,
                    AmbienceInterpolationSpeed = 0.1f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"cyberdyne_main"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\cave_salvation_cpaul"),
                    ReverbCutoffDistance = 1f,
                    ReverbInterpolationSpeed = 0.1f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\cyberdyne\cyberdyne_main\cyberdyne_main"),
                    AmbienceCutoffDistance = 2f,
                    AmbienceInterpolationSpeed = 0.1f,
                },
            };
            scnr.SimulationDefinitionTable = null;
            CacheContext.Serialize(Stream, tag, scnr);
        }
    }
}
