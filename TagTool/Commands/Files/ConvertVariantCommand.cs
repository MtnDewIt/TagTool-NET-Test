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

namespace TagTool.Commands.Files
{
    class ConvertVariantCommand : Command
    {
        private GameCache Cache;
        private string OutputPath;

        public ConvertVariantCommand(GameCache cache) : base
        (
            false,
            "ConvertVariant",
            "Converts all ElDewrito 0.6 map variants in the specified path",
            
            "ConvertVariant <input directory> [output directory]",
            "Converts all ElDewrito 0.6 map variants in the specified path"
        )
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            if (Cache.Version == CacheVersion.HaloOnlineED)
            {
                // TODO: Parse Input Data

                ConvertMaps(args[1]);
            }
            else 
            {
                new TagToolError(CommandError.CacheUnsupported, $"Unsupported Cache Version: {Cache.Version}");
            }

            return true;
        }

        private void ConvertMaps(string targetDirectory) 
        {
            // TODO: Add logic to handle BLF conversion

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
    }
}