using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Audio;
using TagTool.Cache;

namespace TagTool.Commands.Porting.HaloOnline
{
    public partial class PortingContextHO
    {
        private PortTagHOCommand PortTagContext;
        private Stream CacheStream;

        public PortingContextHO(GameCacheHaloOnlineBase cacheContext, GameCache blamCache, Stream cacheStream)
        {
            PortTagContext = new PortTagHOCommand(cacheContext, blamCache as GameCacheHaloOnlineBase);

            CacheStream = cacheStream;
        }

        public void PortTag(string portingOptions, string tag)
        {
            var portingFlags = portingOptions != "" ? portingOptions.Split(' ').ToList() : new List<string>();

            PortTagContext.ParsePortingFlags(portingFlags, out PortTagContext.Flags);

            using (PortTagContext.DestStream = CacheStream)
            using (PortTagContext.SrcStream = PortTagContext.SrcCache.OpenCacheRead())
            {
                foreach (var srcTag in PortTagContext.ParseLegacyTag(tag))
                    PortTagContext.ConvertTag(srcTag);
            }

            PortTagContext.DestCache.SaveStrings();
            PortTagContext.DestCache.SaveTagNames();
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
