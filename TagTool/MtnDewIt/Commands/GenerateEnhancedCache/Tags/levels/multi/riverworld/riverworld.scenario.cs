using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Tags 
{
    public class levels_multi_riverworld_riverworld_scenario : TagFile
    {
        public levels_multi_riverworld_riverworld_scenario(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\multi\riverworld\riverworld");
            var scnr = CacheContext.Deserialize<Scenario>(Stream, tag);

            UpdateForgePalette(scnr);

            scnr.AcousticsPalette = new List<ScenarioStructureBsp.AcousticsPaletteBlock>
            {
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"halo_exterior"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\mountains"),
                    ReverbCutoffDistance = 1,
                    ReverbInterpolationSpeed = 0.25f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\riverworld\halo_ext\halo_ext"),
                    AmbienceCutoffDistance = 1,
                    AmbienceInterpolationSpeed = 0.5f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"interior"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\templates\stone_room"),
                    ReverbCutoffDistance = 1,
                    ReverbInterpolationSpeed = 0.25f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\riverworld\riverworld_interior\riverworld_interior"),
                    AmbienceCutoffDistance = 1,
                    AmbienceInterpolationSpeed = 0.5f,
                },
                new ScenarioStructureBsp.AcousticsPaletteBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"interior_tunnel"),
                    SoundEnvironment = GetCachedTag<SoundEnvironment>($@"sound\dsp_effects\reverbs\halo_3_presets\jay_stone_room"),
                    ReverbCutoffDistance = 1,
                    ReverbInterpolationSpeed = 0.25f,
                    AmbienceBackgroundSound = GetCachedTag<SoundLooping>($@"sound\levels\riverworld\riverworld_interior\riverworld_interior"),
                    AmbienceCutoffDistance = 1,
                    AmbienceInterpolationSpeed = 0.5f,
                },
            };
            scnr.SimulationDefinitionTable = null;
            CacheContext.Serialize(Stream, tag, scnr);
        }
    }
}
