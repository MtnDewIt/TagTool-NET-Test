using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Audio;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.Commands.Porting.Gen1
{
    public partial class PortingContextGen1 
    {
        private PortTagGen1Command PortTagContext;
        private Stream CacheStream;

        public PortingContextGen1(GameCacheHaloOnlineBase cacheContext, GameCache blamCache, Stream cacheStream)
        {
            PortTagContext = new PortTagGen1Command(cacheContext, blamCache as GameCacheGen1);

            CacheStream = cacheStream;
        }

        public void PortTag(string portingOptions, string tag) 
        {
            var resourceStreams = new Dictionary<ResourceLocation, Stream>();

            using (var gen1CacheStream = PortTagContext.Gen1Cache.OpenCacheRead())
            {
                foreach (var gen1Tag in PortTagContext.ParseLegacyTag(tag))
                    PortTagContext.ConvertTag(CacheStream, gen1CacheStream, resourceStreams, gen1Tag);
            }

            foreach (var pair in resourceStreams)
                pair.Value.Close();

            PortTagContext.Cache.SaveStrings();
            PortTagContext.Cache.SaveTagNames();
        }

        public void SetPortingOptions
        (
            int maxThreads = 0,
            Compression audioCodec = Compression.MP3,
            string lightmapCache = null,
            bool reachDecorators = true,
            bool legacyCollision = false,
            bool normalMapConversion = false,
            bool regenerateSurfaceStructures = false
        )
        {
            // TODO: Does this even check if the user sets it to zero :/
            maxThreads = Environment.ProcessorCount * 2;
            PortingOptions.Current.MaxThreads = maxThreads;
            PortingOptions.Current.AudioCodec = audioCodec;
            PortingOptions.Current.ReachLightmapCache = lightmapCache;
            PortingOptions.Current.ReachDecorators = reachDecorators;
            PortingOptions.Current.Gen1Collision = legacyCollision;
            PortingOptions.Current.HqNormalMapConversion = normalMapConversion;
            PortingOptions.Current.RegenerateStructureSurfaces = regenerateSurfaceStructures;
        }
    }
}
