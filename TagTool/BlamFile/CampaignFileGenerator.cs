using System;
using System.IO;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.IO;

namespace TagTool.BlamFile
{
    public class CampaignFileGenerator
    {
        public static void GenerateCampaignFile(GameCache cache, string mapInfoDir)
        {
            string fileName = "halo3.campaign";
            string srcFile = Path.Combine(mapInfoDir, fileName);

            if (!Directory.Exists(mapInfoDir))
                return;

            if (cache is GameCacheHaloOnline hoCache)
            {
                string destFile = Path.Combine(hoCache.Directory.FullName, fileName);
                using var reader = new EndianReader(File.OpenRead(srcFile));
                using var writer = new EndianWriter(File.Create(destFile));

                Blf campaignBlf = new Blf(CacheVersion.Halo3Retail, CachePlatform.Original);
                campaignBlf.Read(reader);
                campaignBlf.ConvertBlf(cache.Version);
                campaignBlf.Write(writer);
            }
            else if (cache is GameCacheModPackage modCache)
            {
                var campaignFileStream = new MemoryStream();

                using var reader = new EndianReader(File.OpenRead(srcFile));
                using var writer = new EndianWriter(campaignFileStream, leaveOpen: true);

                Blf campaignBlf = new Blf(CacheVersion.Halo3Retail, CachePlatform.Original);
                campaignBlf.Read(reader);
                campaignBlf.ConvertBlf(cache.Version);
                campaignBlf.Write(writer);

                modCache.SetCampaignFile(campaignFileStream);
            }
            else
            {
                throw new NotSupportedException("Unsupported cache");
            }
        }

        public static void GenerateCampaignFile(GameCache cache, GameCache blamCache)
        {
            string mapInfoDir = blamCache.Directory != null ? Path.Combine(blamCache.Directory.FullName, "info") : "";
            GenerateCampaignFile(cache, mapInfoDir);
        }
    }
}
