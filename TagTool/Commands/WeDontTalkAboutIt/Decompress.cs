using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Cache.CacheFile;
using TagTool.Cache.MCC.Headers;
using TagTool.Commands.Common;
using TagTool.IO;
using TagTool.Serialization;
using SevenZip.Compression.LZMA;

namespace TagTool.Commands.WeDontTalkAboutIt
{
    public class DecompressCommand : Command
    {
        public static readonly int SEGMENT_ALIGNMENT = 0x1000;

        public DecompressCommand() : base
        (
            false,
            "Decompress",
            "Decompresses Data in the Specified Xbox One MCC Cache File",

            "Decompress <Path>",
            "Decompresses Data in the Specified Xbox One MCC Cache File"
        )
        {
        }

        public override object Execute(List<string> args)
        {
            if (args.Count < 1)
                return new TagToolError(CommandError.ArgCount);

            var fileName = new FileInfo(args[0]);

            if (!fileName.Exists)
                return new TagToolError(CommandError.FileNotFound, fileName.FullName);

            MemoryStream decompressed = DecompressFile(fileName.OpenRead());

            File.WriteAllBytes($"{fileName.DirectoryName}/{Path.GetFileNameWithoutExtension(fileName.Name)}_uncomp{fileName.Extension}", decompressed.ToArray());

            return true;
        }

        private static MemoryStream DecompressFile(Stream fileStream) 
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (EndianReader reader = new EndianReader(fileStream, EndianFormat.LittleEndian))
                using (EndianWriter writer = new EndianWriter(memoryStream, EndianFormat.LittleEndian))
                {
                    TagSerializer serializer = new TagSerializer(CacheVersion.Halo3XboxOne, CachePlatform.MCC);
                    TagDeserializer deserializer = new TagDeserializer(CacheVersion.Halo3XboxOne, CachePlatform.MCC);
                    DataSerializationContext readerContext = new DataSerializationContext(reader);
                    DataSerializationContext writerContext = new DataSerializationContext(writer);

                    CacheFileHeaderHalo3MCCXbox header = deserializer.Deserialize<CacheFileHeaderHalo3MCCXbox>(readerContext);

                    serializer.Serialize(writerContext, header);

                    CacheFileSectionTable sectionTable = header.SectionTable;
                    CacheFileCompressedSection[] offsets = header.CompressedSectionOffset;
                    CacheFileCompressedSection[] sizes = header.CompressedSectionSize;
                    CacheFileCompressionCodec[] codecs = header.CompressedSectionCodec;

                    int[] updatedSectionOffsets = new int[4];

                    // Unsure about cache file section order
                    int[] order = new int[4] { 0, 1, 3, 2 };

                    for (int i = 0; i < 4; i++) 
                    {
                        int index = order[i];

                        uint offset = offsets[index].Value;
                        uint compressedSize = sizes[index].Value;
                        CompressedSectionCodec codec = codecs[index].Codec;
                        int decompressedSize = sectionTable.OriginalSectionBounds[index].Size;
                        int decompressedOffset = sectionTable.OriginalSectionBounds[index].Offset;
                        int sectionOffset = sectionTable.SectionOffsets[index];

                        int finalOffset = decompressedOffset + sectionOffset;

                        int padding = ((int)writer.BaseStream.Position + SEGMENT_ALIGNMENT - 1) & ~(SEGMENT_ALIGNMENT - 1);

                        writer.Seek(padding, SeekOrigin.Begin);

                        updatedSectionOffsets[index] = padding - decompressedOffset;

                        if (codec == CompressedSectionCodec.None)
                        {
                            reader.SeekTo(offset);
                            writer.Write(reader.ReadBytes(decompressedSize));
                        }
                        else if (codec == CompressedSectionCodec.LZMALib)
                        {
                            Decoder lzmaDecoder = new Decoder();
                            reader.SeekTo(offset + 1);

                            int lzmaHeader = UnpackHeader(reader.ReadByte());

                            byte[] lzmaHeaderData = BitConverter.GetBytes(lzmaHeader);

                            using (MemoryStream compressedStream = new MemoryStream()) 
                            {
                                compressedStream.Write(new byte[1] { 0x5D }, 0, 1);
                                compressedStream.Write(lzmaHeaderData);
                                compressedStream.Write(reader.ReadBytes((int)(compressedSize - 2)), 0, (int)(compressedSize - 2));
                                compressedStream.Seek(0, SeekOrigin.Begin);

                                byte[] props = new byte[5];
                                compressedStream.Read(props, 0, 5);

                                lzmaDecoder.SetDecoderProperties(props);

                                lzmaDecoder.Code(compressedStream, memoryStream, compressedSize, decompressedSize, null);
                            }
                        }
                        else
                        {
                            throw new ArgumentException($"Unsupported Compressed Secion Codec {codec}");
                        }
                    }

                    writer.Seek(0, SeekOrigin.Begin);

                    // #INSERT MODIFICATIONS HERE

                    serializer.Serialize(writerContext, header);
                }

                return new MemoryStream(memoryStream.ToArray());
            }
        }

        private static int UnpackHeader(byte value) 
        {
            int shift = ((value >> 1) & 0x1F) + 10;
            int baseValue = (value & 1 << 1) + 1;

            return baseValue << shift;
        }
    }
}
