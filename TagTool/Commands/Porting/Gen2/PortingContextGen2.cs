using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Audio;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.Commands.Porting.Gen2
{
    public partial class PortingContextGen2
    {
        private PortTagGen2Command PortTagContext;
        private Stream CacheStream;

        public PortingContextGen2(GameCacheHaloOnlineBase cacheContext, GameCache blamCache, Stream cacheStream)
        {
            PortTagContext = new PortTagGen2Command(cacheContext, blamCache as GameCacheGen2);

            CacheStream = cacheStream;
        }

        public void PortTag(string portingOptions, string tag) 
        {
            var resourceStreams = new Dictionary<ResourceLocation, Stream>();

            var portingFlags = portingOptions != "" ? portingOptions.Split(' ').ToList() : new List<string>();

            PortTagContext.argParameters = PortTagContext.ParsePortingOptions(portingFlags);

            using (var gen2CacheStream = PortTagContext.Gen2Cache.OpenCacheRead())
            {
                foreach (var gen2Tag in PortTagContext.ParseLegacyTag(tag))
                    PortTagContext.ConvertTag(CacheStream, gen2CacheStream, resourceStreams, gen2Tag);
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
