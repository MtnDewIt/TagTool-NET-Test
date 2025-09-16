using TagTool.Cache;
using System.IO;

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
            else
            {
                switch (version)
                {
                    case CacheVersion.Halo3Beta:
                    case CacheVersion.Halo3Retail:
                    case CacheVersion.Halo3ODST:
                        return new VertexStreamXbox(stream);
                    case CacheVersion.EldoradoED:
                    case CacheVersion.Eldorado106708:
                        return new VertexStreamMS23(stream);
                    case CacheVersion.Eldorado235640:
                    case CacheVersion.Eldorado301003:
                    case CacheVersion.Eldorado327043:
                    case CacheVersion.Eldorado372731:
                    case CacheVersion.Eldorado416097:
                    case CacheVersion.Eldorado430475:
                    case CacheVersion.Eldorado449175:
                    case CacheVersion.Eldorado454665:
                    case CacheVersion.Eldorado498295:
                    case CacheVersion.Eldorado530605:
                    case CacheVersion.Eldorado532911:
                    case CacheVersion.Eldorado554482:
                    case CacheVersion.Eldorado571627:
                    case CacheVersion.Eldorado604673:
                    case CacheVersion.Eldorado700123:
                        return new VertexStreamMS25(stream);

                    case CacheVersion.HaloReach:
                    case CacheVersion.HaloReach11883:
                    case CacheVersion.Halo4:
                        return new VertexStreamReach(stream);

                    default:
                        return new VertexStreamMS23(stream);
                }

            }
            
        }
    }
}
