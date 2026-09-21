using System;
using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile;
using TagTool.BlamFile.Chunks;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.Commands.Editing
{
    public class EditBlfCommand : Command 
    {
        private CommandContextStack ContextStack { get; }
        private GameCacheHaloOnlineBase CacheContext { get; }
        private GameCache Cache { get; }

        public EditBlfCommand(CommandContextStack contextStack, GameCacheHaloOnlineBase cacheContext, GameCache cache) : base(
            false,

            "EditBlf",
            "Edit blf file specific data",

            "EditBlf <Blf File>",

            "If the blf file contains data which is supported by this program,\n" +
            "this command will make special blf file specific commands available\n" +
            "which can be used to edit or view the data in the blf.")
        {
            ContextStack = contextStack;
            CacheContext = cacheContext;
            Cache = cache;
        }

        public override object Execute(List<string> args) 
        {
            if (args.Count != 1)
                return new TagToolError(CommandError.ArgCount);

            if (!TryGetBlfFile(args[0], out var blf))
            {
                return new TagToolError(CommandError.OperationFailed);
            }

            ContextStack.Push(EditBlfContextFactory.Create(ContextStack, Cache, blf, args[0].ToLower()));


            return true;
        }

        public bool TryGetBlfFile(string input, out Blf result) 
        {
            var file = new FileInfo(input);

            var blfData = new Blf(CacheVersion.Halo3Retail, CachePlatform.MCC);

            using (var stream = file.OpenRead())
            {
                FixBlfEndianness(stream, blfData);

                var reader = new EndianReader(stream);

                blfData.Read(reader);
            }

            result = blfData;

            return true;
        }

        private void FixBlfEndianness(FileStream stream, Blf blf)
        {
            var buffer = new byte[stream.Length];
            stream.ReadExactly(buffer);

            using (var memoryStream = new MemoryStream(buffer))
            {
                var deserializer = new TagDeserializer(CacheVersion.HaloOnlineED, CachePlatform.Original);
                var serializer = new TagSerializer(CacheVersion.HaloOnlineED, CachePlatform.Original);

                var reader = new EndianReader(memoryStream, EndianFormat.BigEndian);
                var writer = new EndianWriter(memoryStream, EndianFormat.LittleEndian);
                var readerContext = new DataSerializationContext(reader);
                var writerContext = new DataSerializationContext(writer);

                if (reader.ReadTag() != "_blf")
                {
                    memoryStream.Position = 0;

                    ReadBlf(memoryStream, blf);
                }

                reader.BaseStream.Position = 0;

                while (true)
                {
                    if (reader.BaseStream.Position >= reader.BaseStream.Length)
                        break;

                    var pos = reader.BaseStream.Position;
                    var header = deserializer.Deserialize<BlfChunkHeader>(readerContext);

                    writer.BaseStream.Position = pos;
                    serializer.Serialize(writerContext, header);

                    if (header.Signature == "_eof")
                        break;

                    reader.BaseStream.Position += header.Length - (int)TagStructure.GetStructureSize(typeof(BlfChunkHeader), Cache.Version, Cache.Platform);
                }

                memoryStream.Position = 0xC;
                writer.Format = EndianFormat.LittleEndian;
                writer.Write((short)-2);
                memoryStream.Position = 0;

                ReadBlf(memoryStream, blf);
            }
        }

        private void ReadBlf(Stream stream, Blf blf)
        {
            var memoryReader = new EndianReader(stream);

            if (!blf.Read(memoryReader))
                throw new Exception("Unable to parse BLF data");
        }
    }
}
