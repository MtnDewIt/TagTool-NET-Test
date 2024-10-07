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
using System;
using System.Linq;

namespace TagTool.Commands.Files
{
    class ConvertVariantCommand : Command
    {
        private GameCache Cache;

        private string OutputPath = "";

        private Dictionary<int, string> TagMap;

        public ConvertVariantCommand(GameCache cache) : base
        (
            true,
            "ConvertVariant",
            "Converts all ElDewrito 0.6 variants in the specified path",
            
            "ConvertVariant <input directory> [output directory]",
            "Converts all ElDewrito 0.6 variants in the specified path"
        )
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            if (Cache.Version == CacheVersion.HaloOnlineED)
            {
                if (args.Count == 2)
                {
                    OutputPath = args[1];
                }
                else if (args.Count == 1)
                {
                    OutputPath = "";
                }
                else
                {
                    new TagToolError(CommandError.ArgCount);
                }

                ConvertMaps(args[0]);
            }
            else 
            {
                new TagToolError(CommandError.CacheUnsupported, $"Unsupported Cache Version: {Cache.Version}");
            }

            return true;
        }

        private void ConvertMaps(string targetDirectory) 
        {
            // TODO: Get files based on file type
            // TODO: Create a map of valid file extensions
            foreach (string filePath in Directory.GetFiles(targetDirectory)) 
            {
                FileInfo input = new FileInfo(filePath);

                var blf = new Blf(Cache.Version, Cache.Platform);

                using (var stream = input.OpenRead()) 
                {
                    var reader = new EndianReader(stream);

                    FixBlfEndianness(stream);

                    blf.Read(reader);

                    if (blf.MapVariant == null)
                        return;

                    if (blf.MapVariantTagNames == null) 
                    {
                        ConvertBlf(blf);
                    }

                    if (blf.EndOfFile == null)
                    {
                        blf.EndOfFile = new BlfChunkEndOfFile()
                        {
                            Signature = new Tag("_eof"),
                            Length = (int)TagStructure.GetStructureSize(typeof(BlfChunkEndOfFile), blf.Version, Cache.Platform),
                            MajorVersion = 1,
                            MinorVersion = 1,
                        };
                        blf.ContentFlags |= BlfFileContentFlags.EndOfFile;
                    }
                }

                var output = new FileInfo(Path.Combine(OutputPath, $@"maps", $@"{blf.MapVariant.MapVariant.Metadata.Name}\sandbox.map"));

                if (!output.Directory.Exists)
                {
                    output.Directory.Create();
                }

                using (var stream = output.Create())
                {
                    var writer = new EndianWriter(stream);

                    blf.Write(writer);
                }
            }

            foreach (string subdirectory in Directory.GetDirectories(targetDirectory))
            {
                ConvertMaps(subdirectory);
            }
        }

        private void FixBlfEndianness(Stream stream)
        {
            var deserializer = new TagDeserializer(CacheVersion.HaloOnlineED, CachePlatform.Original);
            var serializer = new TagSerializer(CacheVersion.HaloOnlineED, CachePlatform.Original);

            var reader = new EndianReader(stream, EndianFormat.BigEndian);
            var writer = new EndianWriter(stream, EndianFormat.LittleEndian);
            var readerContext = new DataSerializationContext(reader);
            var writerContext = new DataSerializationContext(writer);

            if(reader.ReadTag() != "_blf")
            {
                stream.Position = 0;
                return;
            }

            reader.BaseStream.Position = 0;

            while (true)
            {
                var pos = reader.BaseStream.Position;
                var header = (BlfChunkHeader)deserializer.Deserialize(readerContext, typeof(BlfChunkHeader));
               
                writer.BaseStream.Position = pos;
                serializer.Serialize(writerContext, header);
                if (header.Signature == "_eof")
                    break;

                reader.BaseStream.Position += header.Length - typeof(BlfChunkHeader).GetSize();
            }

            stream.Position = 0xC;
            writer.Format = EndianFormat.LittleEndian;
            writer.Write((short)-2);
            stream.Position = 0;
        }

        private void ConvertBlf(Blf blf) 
        {
            blf.MapVariantTagNames = new BlfMapVariantTagNames()
            {
                Signature = new Tag("tagn"),
                Length = (int)TagStructure.GetStructureSize(typeof(BlfMapVariantTagNames), blf.Version, CachePlatform.Original),
                MajorVersion = 1,
                MinorVersion = 0,
                Names = Enumerable.Range(0, 256).Select(x => new TagName()).ToArray(),
            };
            blf.ContentFlags |= BlfFileContentFlags.MapVariantTagNames;

            for (int i = 0; i < blf.MapVariant.MapVariant.Quotas.Length; i++) 
            {
                var objectIndex = blf.MapVariant.MapVariant.Quotas[i].ObjectDefinitionIndex;

                if (objectIndex == -1)
                    continue;

                // TODO: Add parser to convert 0.6 object indexes to 0.7 object indexes
            }
        }
    }
}