using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Audio;
using TagTool.Cache;
using TagTool.Commands.Common;

namespace TagTool.Commands.Porting
{
    public partial class PortingContext 
    {
        private PortTagCommand PortTagContext;
        private Stream CacheStream;

        private string[] ObjectParameters;

        public PortingContext(GameCacheHaloOnlineBase cacheContext, GameCache blamCache, Stream cacheStream)
        {
            PortTagContext = new PortTagCommand(cacheContext, blamCache);

            CacheStream = cacheStream;
        }

        public void PortTag(string portingOptions, string tag)
        {
            var portingFlags = portingOptions != "" ? portingOptions.Split(' ').ToList() : new List<string>();

            PortTagContext.ParsePortingOptions(portingFlags);

            var initialStringIdCount = PortTagContext.CacheContext.StringTableHaloOnline.Count;

            PortTagContext.CachedTagData.Clear();

            //
            // Convert Blam data to ElDorado data
            //

            using (var blamCacheStream = PortTagContext.BlamCache is GameCacheModPackage ? ((GameCacheModPackage)PortTagContext.BlamCache).OpenCacheRead(CacheStream) : PortTagContext.BlamCache.OpenCacheRead())
            {
                var oldFlags = PortTagContext.Flags;

                foreach (var blamTag in PortTagContext.ParseLegacyTag(tag))
                {
                    if (blamTag == null)
                        new TagToolError(CommandError.TagInvalid, tag);

                    PortTagContext.ConvertTag(CacheStream, blamCacheStream, blamTag);
                    PortTagContext.Flags = oldFlags;

                    if (PortTagContext.FlagIsSet(PortTagCommand.PortingFlags.MPobject))
                        PortTagContext.TestForgePaletteCompatible(CacheStream, blamTag, ObjectParameters);
                }

                PortTagContext.FinishAsync();
                PortTagContext.ProcessDeferredActions();
                PortTagContext.FinalizeRenderMethods(CacheStream, blamCacheStream);
                if (PortTagContext.BlamCache is GameCacheGen3 gen3Cache)
                    gen3Cache.ResourceCacheGen3.ResourcePageCache.Clear();
            }

            if (initialStringIdCount != PortTagContext.CacheContext.StringTable.Count)
                PortTagContext.CacheContext.SaveStrings();

            PortTagContext.CacheContext.SaveTagNames();

            PortTagContext.Matcher.DeInit();

            PortTagContext.FinishAsync();
            PortTagContext.ProcessDeferredActions();
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

        public void PortMultiplayerObject(string paletteCategory, string paletteItemName, string portingOptions, string tag)
        {
            if (!portingOptions.Contains("MPobject"))
            {
                portingOptions = portingOptions + " MPobject";
            }

            string[] inputParameters = { paletteCategory, paletteItemName };

            ObjectParameters = inputParameters;

            PortTag(portingOptions, tag);
        }
    }
}
