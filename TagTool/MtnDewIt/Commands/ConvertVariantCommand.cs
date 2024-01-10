using System;
using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile;
using TagTool.Cache;
using TagTool.Commands;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.MtnDewIt.Commands
{
    public class ConvertVariantCommand : Command
    {
        private GameCache Cache;
        private GameCache EDCache;

        public ConvertVariantCommand(GameCache cache) : base
        (
            false,
            "ConvertVariant",
            "Converts an ElDewrito 0.6 variant file so that it functions in an ElDewrito 0.7 cache",
            
            "ConvertVariant <0.6 Cache Directory> <Input_Variant_Path> <Output_Path>",
            "Converts an ElDewrito 0.6 variant file so that it functions in an ElDewrito 0.7 cache. Will pull required tag data from current cache context"
        )
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            if (Cache.Version == CacheVersion.HaloOnlineED)
            {
                var directoryInfo = new DirectoryInfo(args[0]);

                EDCache = GameCache.Open($@"{directoryInfo.FullName}\tags.dat");

                var output = new FileInfo(args[2]);

                if (!output.Directory.Exists)
                {
                    output.Directory.Create();
                }

                var input = new FileInfo(args[1]);

                var inputBlf = new Blf(CacheVersion.HaloOnline106708, CachePlatform.Original);

                using (var stream = input.OpenRead())
                {
                    var reader = new EndianReader(stream);

                    if (input.Name == "sandbox.map")
                    {
                        inputBlf = ReadBlf(reader, inputBlf);
                    }
                    else
                    {
                        new TagToolError(CommandError.CustomError, "Unsupported Variant File");
                        return false;
                    }
                }

                var outputBlf = ConvertBlf(inputBlf);

                UpdateQuotaIndexes(outputBlf.MapVariantTagNames.Names, outputBlf.MapVariant.MapVariant.Quotas);

                using (var stream = output.Create())
                using (var writer = new EndianWriter(stream))
                {
                    // While converted variants are functional, they are 3KB smaller than expected (121KB vs 124KB).
                    // TODO: Figure out why :/
                    outputBlf.Write(writer);
                }
            }
            else 
            {
                new TagToolError(CommandError.CacheUnsupported, "Ensure you are using a 0.7 cache as the base cache when opening TagTool");
            }

            return true;
        }

        // New reader required as the 0.6 variant files are formatted strangely :/
        // The chunk header uses the endianness as the rest of the file
        // The actual data stored in the chunk header however uses the opposite endianess (in 0.6's case, LittleEndian vs BigEndian)
        // This does cause the chunk header's base attributes to be incorrect, however since we are creating a new BLF object, this isn't too big of an issue
        private Blf ReadBlf(EndianReader reader, Blf inputBlf) 
        {
            reader.Format = EndianFormat.BigEndian;

            var deserializer = new TagDeserializer(CacheVersion.HaloOnline106708, CachePlatform.Original);

            while (!reader.EOF)
            {
                var dataContext = new DataSerializationContext(reader, useAlignment: false);
                var chunkHeaderPosition = reader.Position;

                var header = (BlfChunkHeader)deserializer.Deserialize(dataContext, typeof(BlfChunkHeader));
                reader.SeekTo(chunkHeaderPosition);

                switch (header.Signature.ToString())
                {
                    case "_blf":
                        inputBlf.ContentFlags |= BlfFileContentFlags.StartOfFile;
                        inputBlf.StartOfFile = (BlfChunkStartOfFile)deserializer.Deserialize(dataContext, typeof(BlfChunkStartOfFile));
                        break;

                    case "_eof":
                        inputBlf.ContentFlags |= BlfFileContentFlags.EndOfFile;
                        var position = reader.Position;
                        inputBlf.EndOfFile = (BlfChunkEndOfFile)deserializer.Deserialize(dataContext, typeof(BlfChunkEndOfFile));
                        inputBlf.AuthenticationType = inputBlf.EndOfFile.AuthenticationType;
                        switch (inputBlf.AuthenticationType)
                        {
                            case BlfAuthenticationType.None:
                                break;
                            case BlfAuthenticationType.CRC:
                                reader.SeekTo(position);
                                inputBlf.EndOfFileCRC = (BlfEndOfFileCRC)deserializer.Deserialize(dataContext, typeof(BlfEndOfFileCRC));
                                break;
                            case BlfAuthenticationType.RSA:
                                reader.SeekTo(position);
                                inputBlf.EndOfFileRSA = (BlfEndOfFileRSA)deserializer.Deserialize(dataContext, typeof(BlfEndOfFileRSA));
                                break;
                            case BlfAuthenticationType.SHA1:
                                reader.SeekTo(position);
                                inputBlf.EndOfFileSHA1 = (BlfEndOfFileSHA1)deserializer.Deserialize(dataContext, typeof(BlfEndOfFileSHA1));
                                break;
                        }
                        return inputBlf;

                    case "cmpn":
                        inputBlf.ContentFlags |= BlfFileContentFlags.Campaign;
                        reader.Format = EndianFormat.LittleEndian;
                        inputBlf.Campaign = (BlfCampaign)deserializer.Deserialize(dataContext, typeof(BlfCampaign));
                        reader.Format = EndianFormat.BigEndian;
                        break;

                    case "levl":
                        inputBlf.ContentFlags |= BlfFileContentFlags.Scenario;
                        reader.Format = EndianFormat.LittleEndian;
                        inputBlf.Scenario = (BlfScenario)deserializer.Deserialize(dataContext, typeof(BlfScenario));
                        reader.Format = EndianFormat.BigEndian;
                        break;

                    case "modp":
                        inputBlf.ContentFlags |= BlfFileContentFlags.ModReference;
                        if (header.MajorVersion == (short)BlfModPackageReferenceVersion.Version1)
                        {
                            var v1 = (BlfModPackageReferenceV1)deserializer.Deserialize(dataContext, typeof(BlfModPackageReferenceV1));
                            inputBlf.ModReference = new BlfModPackageReference(v1); // Convert to the new format
                        }
                        else
                        {
                            inputBlf.ModReference = (BlfModPackageReference)deserializer.Deserialize(dataContext, typeof(BlfModPackageReference));
                        }
                        break;

                    case "mapv":
                        inputBlf.ContentFlags |= BlfFileContentFlags.MapVariant;
                        reader.Format = EndianFormat.LittleEndian;
                        inputBlf.MapVariant = (BlfMapVariant)deserializer.Deserialize(dataContext, typeof(BlfMapVariant));
                        reader.Format = EndianFormat.BigEndian;
                        break;
                    case "tagn":
                        inputBlf.ContentFlags |= BlfFileContentFlags.MapVariantTagNames;
                        reader.Format = EndianFormat.LittleEndian;
                        inputBlf.MapVariantTagNames = (BlfMapVariantTagNames)deserializer.Deserialize(dataContext, typeof(BlfMapVariantTagNames));
                        reader.Format = EndianFormat.BigEndian;
                        break;


                    case "mpvr":
                        inputBlf.ContentFlags |= BlfFileContentFlags.GameVariant;
                        reader.Format = EndianFormat.LittleEndian;
                        inputBlf.GameVariant = (BlfGameVariant)deserializer.Deserialize(dataContext, typeof(BlfGameVariant));
                        reader.Format = EndianFormat.BigEndian;
                        break;

                    case "chdr":
                        inputBlf.ContentFlags |= BlfFileContentFlags.ContentHeader;
                        reader.Format = EndianFormat.LittleEndian;
                        inputBlf.ContentHeader = (BlfContentHeader)deserializer.Deserialize(dataContext, typeof(BlfContentHeader));
                        reader.Format = EndianFormat.BigEndian;
                        break;

                    case "mapi":
                        inputBlf.ContentFlags |= BlfFileContentFlags.MapImage;
                        reader.Format = EndianFormat.LittleEndian;
                        inputBlf.MapImage = (BlfMapImage)deserializer.Deserialize(dataContext, typeof(BlfMapImage));
                        inputBlf.JpegImage = reader.ReadBytes(inputBlf.MapImage.JpegSize);
                        reader.Format = EndianFormat.BigEndian;
                        break;

                    case "scnd":
                    case "scnc":
                    case "flmh":
                    case "flmd":
                    case "athr":
                        reader.Format = EndianFormat.LittleEndian;
                        inputBlf.Author = deserializer.Deserialize<BlfAuthor>(dataContext);
                        reader.Format = EndianFormat.BigEndian;
                        break;
                    case "ssig":
                    case "mps2":
                    case "chrt":
                    default:
                        throw new NotImplementedException($"BLF chunk type {header.Signature} not implemented!");
                }
            }

            return inputBlf;
        }

        private Blf ConvertBlf(Blf inputBlf) 
        {
            var outputBlf = new Blf(CacheVersion.HaloOnlineED, CachePlatform.Original);

            outputBlf.Format = EndianFormat.LittleEndian;
            outputBlf.ContentFlags = BlfFileContentFlags.StartOfFile | BlfFileContentFlags.EndOfFile | BlfFileContentFlags.ContentHeader | BlfFileContentFlags.MapVariant | BlfFileContentFlags.MapVariantTagNames;
            outputBlf.AuthenticationType = BlfAuthenticationType.None;

            outputBlf.StartOfFile = new BlfChunkStartOfFile() 
            {
                Signature = new Tag("_blf"),
                Length = (int)TagStructure.GetStructureSize(typeof(BlfChunkStartOfFile), CacheVersion.HaloOnlineED, CachePlatform.Original),
                MajorVersion = 1,
                MinorVersion = 2,
                ByteOrderMarker = -2,
            };

            outputBlf.EndOfFile = new BlfChunkEndOfFile() 
            {
                Signature = new Tag("_eof"),
                Length = (int)TagStructure.GetStructureSize(typeof(BlfChunkEndOfFile), CacheVersion.HaloOnlineED, CachePlatform.Original),
                MajorVersion = 1,
                MinorVersion = 1,
                AuthenticationDataSize = 0,
                AuthenticationType = BlfAuthenticationType.None,
            };

            outputBlf.MapVariantTagNames = GenerateTagNames(inputBlf.MapVariant.MapVariant);

            outputBlf.MapVariant = new BlfMapVariant() 
            {
                Signature = new Tag("mapv"),
                Length = (int)TagStructure.GetStructureSize(typeof(BlfMapVariant), CacheVersion.HaloOnlineED, CachePlatform.Original),
                MajorVersion = 12,
                MinorVersion = 1,
                MapVariant = inputBlf.MapVariant.MapVariant,
            };

            outputBlf.ContentHeader = new BlfContentHeader() 
            {
                Signature = new Tag("chdr"),
                Length = (int)TagStructure.GetStructureSize(typeof(BlfContentHeader), CacheVersion.HaloOnlineED, CachePlatform.Original),
                MajorVersion = 9,
                MinorVersion = 3,
                BuildVersion = 0xffffa0d4,
                Metadata = inputBlf.ContentHeader.Metadata,
            };

            return outputBlf;
        }

        private BlfMapVariantTagNames GenerateTagNames(MapVariant mapVariant)
        {
            var tagNames = new BlfMapVariantTagNames
            {
                Signature = new Tag("tagn"),
                Length = (int)TagStructure.GetStructureSize(typeof(BlfMapVariantTagNames), CacheVersion.HaloOnlineED, CachePlatform.Original),
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

                    // TODO: Calculate names based off of internal tag list, rather than the cache
                    // The 0.6 indexes are static, while the tag names are dynamic, so as long we have a valid tag name and type, finding them in the 0.7 cache is trivial
                    tagNames.Names[i].Name = $"{tag.Name}.{tag.Group.Tag}";
                }
            }

            return tagNames;
        }

        private TagName[] PopulateTagNames()
        {
            var tagNames = new TagName[256];

            for (int i = 0; i < tagNames.Length; i++)
            {
                tagNames[i] = new TagName()
                {
                    Name = "",
                };
            }

            return tagNames;
        }

        private void UpdateQuotaIndexes(TagName[] tagNames, VariantObjectQuota[] quotaList)
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
