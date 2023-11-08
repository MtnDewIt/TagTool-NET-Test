using TagTool.Common;
using TagTool.Tags.Definitions;
using System.Collections.Generic;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command
    {
        public void SoundEffectTemplateSetup()
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    if (tag.IsInGroup("<fx>") && tag.Name == $@"sound\dsp_effects\sound_effect_templates\controller_0_headset") 
                    {
                        var sfx = CacheContext.Deserialize<SoundEffectTemplate>(stream, tag);
                        sfx.InternalDspEffectName = StringId.Invalid;
                        CacheContext.Serialize(stream, tag, sfx);
                    }

                    if (tag.IsInGroup("<fx>") && tag.Name == $@"sound\dsp_effects\sound_effect_templates\controller_1_headset")
                    {
                        var sfx = CacheContext.Deserialize<SoundEffectTemplate>(stream, tag);
                        sfx.InternalDspEffectName = StringId.Invalid;
                        CacheContext.Serialize(stream, tag, sfx);
                    }

                    if (tag.IsInGroup("<fx>") && tag.Name == $@"sound\dsp_effects\sound_effect_templates\controller_2_headset")
                    {
                        var sfx = CacheContext.Deserialize<SoundEffectTemplate>(stream, tag);
                        sfx.InternalDspEffectName = StringId.Invalid;
                        CacheContext.Serialize(stream, tag, sfx);
                    }

                    if (tag.IsInGroup("<fx>") && tag.Name == $@"sound\dsp_effects\sound_effect_templates\controller_3_headset")
                    {
                        var sfx = CacheContext.Deserialize<SoundEffectTemplate>(stream, tag);
                        sfx.InternalDspEffectName = StringId.Invalid;
                        CacheContext.Serialize(stream, tag, sfx);
                    }

                    if (tag.IsInGroup("<fx>") && tag.Name == $@"sound\dsp_effects\sound_effect_templates\global_speaker_chorus")
                    {
                        var sfx = CacheContext.Deserialize<SoundEffectTemplate>(stream, tag);
                        sfx.InternalDspEffectName = StringId.Invalid;
                        sfx.AdditionalSoundInputs = new List<SoundEffectTemplate.AdditionalSoundInput>
                        {
                            new SoundEffectTemplate.AdditionalSoundInput
                            {
                                DspEffect = CacheContext.StringTable.GetStringId($@"sfx_oscillator_input"),
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
                        CacheContext.Serialize(stream, tag, sfx);
                    }

                    if (tag.IsInGroup("<fx>") && tag.Name == $@"sound\dsp_effects\sound_effect_templates\mono_distortion")
                    {
                        var sfx = CacheContext.Deserialize<SoundEffectTemplate>(stream, tag);
                        sfx.InternalDspEffectName = StringId.Invalid;
                        CacheContext.Serialize(stream, tag, sfx);
                    }
                }
            }
        }
    }
}