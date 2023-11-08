using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using TagTool.Tags;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_characters_masterchief_fx_shield_shield_down_light : TagFile
    {
        public objects_characters_masterchief_fx_shield_shield_down_light(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Light>($@"objects\characters\masterchief\fx\shield\shield_down");
            var ligh = CacheContext.Deserialize<Light>(Stream, tag);
            ligh.Flags = Light.LightFlags.RenderThirdPersonOnly;
            ligh.MaximumDistance = 0.45f;
            ligh.FrustumNearWidth = 0.15f;
            ligh.FrustumHeightScale = 1f;
            ligh.FrustumFieldOfView = 1.570796f;
            ligh.Color = new Light.LightColorFunctionStruct 
            {
                Function = new TagFunction 
                {
                    Data = new byte[] 
                    {
                        0x03, 0x14, 0x03, 0x00, 0x00, 0x02, 0x0B, 0x00, 0x15, 0x59,
                        0xDB, 0x00, 0x00, 0x00, 0x00, 0x00, 0x37, 0xAA, 0xFA, 0x00,
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14, 0x00,
                        0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F,
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                        0x80, 0x3F,
                    },
                },
            };
            ligh.Intensity = new Light.LightScalarFunctionStruct 
            {
                Function = new TagFunction 
                {
                    Data = new byte[] 
                    {
                        0x01, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x00, 0x00,
                        0x00, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                        0x00, 0x00,
                    },
                },
            };
            ligh.DistanceDiffusion = 0.05f;
            ligh.AngularSmoothness = 5f;
            ligh.FarPriority = Light.LightPriorityEnumeration._4;
            CacheContext.Serialize(Stream, tag, ligh);
        }
    }
}
