using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Commands;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.IO;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.Tags;

namespace TagTool.MtnDewIt.Commands
{
    public class ConvertVariantCommand : Command
    {
        private GameCache Cache;
        private GameCache EDCache;
        private string OutputPath;

        public ConvertVariantCommand(GameCache cache) : base
        (
            false,
            "ConvertVariant",
            "Converts an ElDewrito 0.6 variant file so that it functions in an ElDewrito 0.7 cache",
            
            "ConvertVariant <0.6 Cache Directory> <Input_Variant_Folder> [Output_Path]",
            "Converts an ElDewrito 0.6 variant file so that it functions in an ElDewrito 0.7 cache. Will pull required tag data from current cache context"
        )
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            if (Cache.Version == CacheVersion.HaloOnlineED)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(args[0]);

                EDCache = GameCache.Open($@"{directoryInfo.FullName}\tags.dat");

                if (args.Count == 3)
                {
                    OutputPath = args[2];
                }
                else if (args.Count == 2)
                {
                    OutputPath = "";
                }
                else 
                {
                    new TagToolError(CommandError.ArgCount);
                }

                ConvertMaps(args[1]);
            }
            else 
            {
                new TagToolError(CommandError.CacheUnsupported, "Ensure you are using a 0.7 cache as the base cache when opening TagTool");
            }

            return true;
        }

        private void ConvertMaps(string targetDirectory) 
        {
            foreach (string filePath in Directory.GetFiles(targetDirectory, "sandbox.map"))
            {
                FileInfo input = new FileInfo(filePath);

                var inputBlf = new BlfData(CacheVersion.HaloOnline106708, CachePlatform.Original);

                using (var stream = input.OpenRead())
                {
                    var reader = new EndianReader(stream);

                    if (input.Name == "sandbox.map")
                    {
                        inputBlf.ReadLegacyData(reader);
                    }
                    else
                    {
                        new TagToolError(CommandError.CustomError, "Unsupported Variant File");
                        return;
                    }
                }

                var outputBlf = ConvertBlf(inputBlf);

                UpdateQuotaIndexes(outputBlf.MapVariantTagNames.Names, outputBlf.MapVariant.MapVariant.Quotas);

                var output = new FileInfo(Path.Combine(OutputPath, $@"maps", $@"{outputBlf.MapVariant.MapVariant.Metadata.Name}\sandbox.map"));

                if (!output.Directory.Exists)
                {
                    output.Directory.Create();
                }

                using (var stream = output.Create())
                using (var writer = new EndianWriter(stream))
                {
                    outputBlf.WriteData(writer);
                }
            }

            foreach (string subdirectory in Directory.GetDirectories(targetDirectory))
            {
                ConvertMaps(subdirectory);
            }
        }

        private BlfData ConvertBlf(BlfData inputBlf) 
        {
            var outputBlf = new BlfData(CacheVersion.HaloOnlineED, CachePlatform.Original);

            outputBlf.Format = EndianFormat.LittleEndian;
            outputBlf.ContentFlags = BlfDataFileContentFlags.StartOfFile | BlfDataFileContentFlags.EndOfFile | BlfDataFileContentFlags.ContentHeader | BlfDataFileContentFlags.MapVariant | BlfDataFileContentFlags.MapVariantTagNames;
            outputBlf.AuthenticationType = BlfDataAuthenticationType.AuthenticationTypeNone;

            outputBlf.StartOfFile = new BlfDataChunkStartOfFile() 
            {
                Signature = new Tag("_blf"),
                Length = (int)TagStructure.GetStructureSize(typeof(BlfDataChunkStartOfFile), CacheVersion.HaloOnlineED, CachePlatform.Original),
                MajorVersion = 1,
                MinorVersion = 2,
                ByteOrderMarker = -2,
            };

            outputBlf.EndOfFile = new BlfDataChunkEndOfFile() 
            {
                Signature = new Tag("_eof"),
                Length = (int)TagStructure.GetStructureSize(typeof(BlfDataChunkEndOfFile), CacheVersion.HaloOnlineED, CachePlatform.Original),
                MajorVersion = 1,
                MinorVersion = 1,
                AuthenticationDataSize = 0,
                AuthenticationType = BlfDataAuthenticationType.AuthenticationTypeNone,
            };

            outputBlf.MapVariantTagNames = GenerateTagNames(inputBlf.MapVariant.MapVariant);

            outputBlf.MapVariant = new BlfDataMapVariant() 
            {
                Signature = new Tag("mapv"),
                Length = (int)TagStructure.GetStructureSize(typeof(BlfDataMapVariant), CacheVersion.HaloOnlineED, CachePlatform.Original),
                MajorVersion = 12,
                MinorVersion = 1,
                MapVariant = inputBlf.MapVariant.MapVariant,
            };

            outputBlf.ContentHeader = new BlfDataContentHeader() 
            {
                Signature = new Tag("chdr"),
                Length = (int)TagStructure.GetStructureSize(typeof(BlfDataContentHeader), CacheVersion.HaloOnlineED, CachePlatform.Original),
                MajorVersion = 9,
                MinorVersion = 3,
                BuildVersion = 0xa0d4,
                MapMinorVersion = 0,
                Metadata = inputBlf.ContentHeader.Metadata,
            };

            return outputBlf;
        }

        private BlfDataMapVariantTagNames GenerateTagNames(MapVariantData mapVariant)
        {
            var tagNames = new BlfDataMapVariantTagNames
            {
                Signature = new Tag("tagn"),
                Length = (int)TagStructure.GetStructureSize(typeof(BlfDataMapVariantTagNames), CacheVersion.HaloOnlineED, CachePlatform.Original),
                MajorVersion = 1,
                MinorVersion = 0,
                Names = PopulateTagNames(),
            };

            for (int i = 0; i < mapVariant.Quotas.Length; i++)
            {
                var quota = mapVariant.Quotas[i];

                if (quota.ObjectDefinitionIndex != -1)
                {
                    var tag = EDCache.TagCache.GetTag(quota.ObjectDefinitionIndex);

                    tagNames.Names[i].Name = $"{UpdateEDTagsCommand.tagNameTable[quota.ObjectDefinitionIndex]}.{tag.Group.Tag}";
                }
            }

            return tagNames;
        }

        private BlfTagName[] PopulateTagNames()
        {
            var tagNames = new BlfTagName[256];

            for (int i = 0; i < tagNames.Length; i++)
            {
                tagNames[i] = new BlfTagName()
                {
                    Name = "",
                };
            }

            return tagNames;
        }

        private void UpdateQuotaIndexes(BlfTagName[] tagNames, VariantDataObjectQuota[] quotaList)
        {
            for (int i = 0; i < tagNames.Length; i++)
            {
                var tagName = tagNames[i];

                if (tagName.Name != null && tagName.Name != "")
                {
                    var tag = Cache.TagCache.GetTag(tagName.Name);

                    quotaList[i].ObjectDefinitionIndex = tag.Index;
                }
            }
        }
    }
}
