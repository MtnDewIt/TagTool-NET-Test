using TagTool.Cache;
using System.IO;
using System;

namespace TagTool.Geometry
{
    public static class VertexStreamFactory
    {
        /// <summary>
        /// Creates a vertex stream for a given engine version.
        /// </summary>
        /// <param name="version">The engine version.</param>
        /// <param name="cachePlatform">the engine platform</param>
        /// <param name="stream">The base stream.</param>
        /// <returns>The created vertex stream.</returns>
        public static IVertexStream Create(CacheVersion version, CachePlatform cachePlatform, Stream stream)
        {
            if(cachePlatform == CachePlatform.MCC)
            {
                switch (version)
                {
                    case CacheVersion.Halo3Retail:
                        return new VertexStreamHalo3RetailMCC(stream);
                    case CacheVersion.Halo3ODST:
                        return new VertexStreamHalo3ODSTMCC(stream);

                    // Ideally we would have one for each supported build, but we'll default to halo 3's for now
                    default:
                        return new VertexStreamHalo3RetailMCC(stream);
                }
            }
       
            return version switch
            {
                CacheVersion.Halo3Beta or CacheVersion.Halo3Retail or CacheVersion.Halo3ODST => new VertexStreamXbox(stream),
                >= CacheVersion.HaloOnlineED and <= CacheVersion.HaloOnline106708 => new VertexStreamMS23(stream),
                >= CacheVersion.HaloOnline235640 and <= CacheVersion.HaloOnline700123 => new VertexStreamMS25(stream),
                >= CacheVersion.HaloReach => new VertexStreamReach(stream),
                _ => throw new NotSupportedException($"Unsupported version {version}"),
            };
        }
    }
}
