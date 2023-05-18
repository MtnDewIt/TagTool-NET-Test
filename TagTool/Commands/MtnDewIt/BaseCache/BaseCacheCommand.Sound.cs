using TagTool.Common;
using TagTool.Tags.Definitions;
using System.Collections.Generic;

namespace TagTool.Commands.Tags
{
    partial class BaseCacheCommand : Command
    {
        public void GenerateSoundEffectTemplates()
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                var sfxTag = CacheContext.TagCache.AllocateTag<SoundEffectTemplate>($@"sound\dsp_effects\sound_effect_templates\controller_0_headset");
                var sfx = new SoundEffectTemplate();
                CacheContext.Serialize(stream, sfxTag, sfx);

                sfxTag = CacheContext.TagCache.AllocateTag<SoundEffectTemplate>($@"sound\dsp_effects\sound_effect_templates\controller_1_headset");
                sfx = new SoundEffectTemplate();
                CacheContext.Serialize(stream, sfxTag, sfx);

                sfxTag = CacheContext.TagCache.AllocateTag<SoundEffectTemplate>($@"sound\dsp_effects\sound_effect_templates\controller_2_headset");
                sfx = new SoundEffectTemplate();
                CacheContext.Serialize(stream, sfxTag, sfx);

                sfxTag = CacheContext.TagCache.AllocateTag<SoundEffectTemplate>($@"sound\dsp_effects\sound_effect_templates\controller_3_headset");
                sfx = new SoundEffectTemplate();
                CacheContext.Serialize(stream, sfxTag, sfx);

                sfxTag = CacheContext.TagCache.AllocateTag<SoundEffectTemplate>($@"sound\dsp_effects\sound_effect_templates\global_speaker_chorus");
                sfx = new SoundEffectTemplate();
                CacheContext.Serialize(stream, sfxTag, sfx);

                sfxTag = CacheContext.TagCache.AllocateTag<SoundEffectTemplate>($@"sound\dsp_effects\sound_effect_templates\mono_distortion");
                sfx = new SoundEffectTemplate();
                CacheContext.Serialize(stream, sfxTag, sfx);
            }
        }

        public void SoundEffectTemplateSetup()
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    if (tag.IsInGroup("sfx+") && tag.Name == $@"sound\dsp_effects\sound_effect_templates\controller_0_headset") 
                    {
                        var sfx = CacheContext.Deserialize<SoundEffectTemplate>(stream, tag);
                        sfx.InternalDspEffectName = StringId.Invalid;
                        CacheContext.Serialize(stream, tag, sfx);
                    }

                    if (tag.IsInGroup("sfx+") && tag.Name == $@"sound\dsp_effects\sound_effect_templates\controller_1_headset")
                    {
                        var sfx = CacheContext.Deserialize<SoundEffectTemplate>(stream, tag);
                        sfx.InternalDspEffectName = StringId.Invalid;
                        CacheContext.Serialize(stream, tag, sfx);
                    }

                    if (tag.IsInGroup("sfx+") && tag.Name == $@"sound\dsp_effects\sound_effect_templates\controller_2_headset")
                    {
                        var sfx = CacheContext.Deserialize<SoundEffectTemplate>(stream, tag);
                        sfx.InternalDspEffectName = StringId.Invalid;
                        CacheContext.Serialize(stream, tag, sfx);
                    }

                    if (tag.IsInGroup("sfx+") && tag.Name == $@"sound\dsp_effects\sound_effect_templates\controller_3_headset")
                    {
                        var sfx = CacheContext.Deserialize<SoundEffectTemplate>(stream, tag);
                        sfx.InternalDspEffectName = StringId.Invalid;
                        CacheContext.Serialize(stream, tag, sfx);
                    }

                    if (tag.IsInGroup("sfx+") && tag.Name == $@"sound\dsp_effects\sound_effect_templates\global_speaker_chorus")
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

                    if (tag.IsInGroup("sfx+") && tag.Name == $@"sound\dsp_effects\sound_effect_templates\mono_distortion")
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