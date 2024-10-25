using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.IO;
using TagTool.BlamFile;
using TagTool.BlamFile.MCC;
using TagTool.Cache.HaloOnline;
using TagTool.Commands.Common;

namespace TagTool.Commands.Files
{
    class GenerateCampaignFileCommand : Command
    {
        public GameCache Cache { get; }
        public Blf CampaignBlf { get; set; }

        public GenerateCampaignFileCommand(GameCache cache)
            : base(true,

                  "GenerateCampaignFile",
                  "Generate the halo3.campaign file for the specificed map info folder",

                  "GenerateCampaignFile [MapInfo Directory]",

                  "Generate the halo3.campaign file for the specificed map info folder")
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count > 1)
                return new TagToolError(CommandError.ArgCount);

            string fileName = $"halo3.campaign";
            DirectoryInfo mapInfoDir = null;
            FileInfo srcFile = null;
            FileInfo modInfoFile = null;

            if (args.Count > 0)
            {
                mapInfoDir = new DirectoryInfo(args[0]);

                modInfoFile = new FileInfo(Path.Combine(args[0], "ModInfo.json"));
                srcFile = new FileInfo(Path.Combine(mapInfoDir.FullName, fileName));

                if (!srcFile.Exists && !modInfoFile.Exists)
                    return new TagToolError(CommandError.FileNotFound);
            }

            if (mapInfoDir != null && !modInfoFile.Exists)
            {
                CampaignBlf = new Blf(CacheVersion.Halo3Retail, CachePlatform.Original);

                using (var stream = srcFile.Open(FileMode.Open, FileAccess.Read))
                using (var reader = new EndianReader(stream))
                {
                    CampaignBlf.Read(reader);
                    CampaignBlf.ConvertBlf(Cache.Version);
                }
            }
            else if (modInfoFile.Exists && mapInfoDir != null) 
            {
                var campaignBuilder = new CampaignBuilder(Cache);
                CampaignBlf = campaignBuilder.GenerateCampaign(modInfoFile);
            }
            else
            {
                CampaignBlf = GenerateCampaignBlf();

                if (CampaignBlf == null)
                    return new TagToolError(CommandError.OperationFailed);
            }

            if (Cache is GameCacheHaloOnline)
            {
                var destFile = new FileInfo(Path.Combine(Cache.Directory.FullName, fileName));

                using (var destStream = destFile.Create())
                using (var writer = new EndianWriter(destStream))
                {
                    CampaignBlf.Write(writer);
                }
            }
            else if (Cache is GameCacheModPackage)
            {
                var campaignFileStream = new MemoryStream();

                using (var writer = new EndianWriter(campaignFileStream, leaveOpen: true))
                {
                    CampaignBlf.Write(writer);
                }
                var modCache = Cache as GameCacheModPackage;

                modCache.SetCampaignFile(campaignFileStream);
            }
            else
            {
                return new TagToolError(CommandError.CacheUnsupported);
            }

            Console.WriteLine("Done!");
            return true;
        }

        public Blf GenerateCampaignBlf()
        {
            var campaignFileBuilder = new CampaignFileBuilder(Cache);
            campaignFileBuilder.Name = "Halo 3";
            campaignFileBuilder.Description = "Finish the Fight!";

            var campaignBlf = campaignFileBuilder.GenerateCampaignBlf(true);

            return campaignBlf;
        }
    }
}