using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class sound_dsp_effects_sound_effect_templates_global_speaker_chorus_sound_effect_template : TagFile
    {
        public sound_dsp_effects_sound_effect_templates_global_speaker_chorus_sound_effect_template(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<SoundEffectTemplate>($@"sound\dsp_effects\sound_effect_templates\global_speaker_chorus");
            var sfx = CacheContext.Deserialize<SoundEffectTemplate>(Stream, tag);
            sfx.InternalDspEffectName = StringId.Invalid;
            sfx.AdditionalSoundInputs = new List<SoundEffectTemplate.AdditionalSoundInput>
            {
                new SoundEffectTemplate.AdditionalSoundInput
                {
                    DspEffect = CacheContext.StringTable.GetOrAddString($@"sfx_oscillator_input"),
                    LowFrequencySoundFunction = new TagTool.Tags.TagFunction
                    {
                        Data = new byte[]
                        {
                            0x03, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x48, 0xE1, 0xFA, 0x3E, 0x00, 0x00, 0x00, 0x3F, 0x14, 0x00,
                            0x00, 0x00, 0x02, 0xCD, 0xCD, 0xCD, 0x00, 0x00, 0x80, 0x3F,
                            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x80, 0x3F,
                        },
                    },
                    TimePeriod = 1f,
                },
            };
            CacheContext.Serialize(Stream, tag, sfx);
        }
    }
}
