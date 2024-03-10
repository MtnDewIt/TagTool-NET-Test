using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class sound_dsp_effects_sound_effect_templates_controller_3_headset_sound_effect_template : TagFile
    {
        public sound_dsp_effects_sound_effect_templates_controller_3_headset_sound_effect_template(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<SoundEffectTemplate>($@"sound\dsp_effects\sound_effect_templates\controller_3_headset");
            var sfx = CacheContext.Deserialize<SoundEffectTemplate>(Stream, tag);
            sfx.InternalDspEffectName = StringId.Invalid;
            CacheContext.Serialize(Stream, tag, sfx);
        }
    }
}
