using SevenZip.Compression.LZMA;
using System;
using System.IO;
using TagTool.Cache.CacheFile;
using TagTool.Cache.MCC.Headers;
using TagTool.IO;
using TagTool.Serialization;

namespace TagTool.Cache.MCC
{
    public static class AresCacheCompression
    {
        public const int SegmentAlignment = 0x1000;

        private const int TagDictionarySize = 0x1000000;
        private const int LanguageDictionarySize = 0x200000;

        public static CacheFileHeaderHalo3Ares AresHeader = null;

        private static readonly CacheFileSectionType[] DecompressedSectionOrder =
        {
            CacheFileSectionType.DebugSection,
            CacheFileSectionType.ResourceSection,
            CacheFileSectionType.LanguagePackSection,
            CacheFileSectionType.TagSection,
        };

        private static readonly CacheFileSectionType[] CompressedSectionOrder =
        {
            CacheFileSectionType.DebugSection,
            CacheFileSectionType.ResourceSection,
            CacheFileSectionType.TagSection,
            CacheFileSectionType.LanguagePackSection,
        };

        public static bool IsCompressed(CacheFileHeader header)
        {
            if (header?.GetCompressedSectionSize() == null || header.GetCompressedSectionCodec() == null)
                return false;

            for (int i = 0; i < (int)CacheFileSectionType.Count; i++)
            {
                if (header.GetCompressedSectionSize()[i].Value != 0 ||
                    header.GetCompressedSectionCodec()[i].Codec != CompressedSectionCodec.None)
                    return true;
            }

            return false;
        }

        public static MemoryStream Decompress(CacheFileHeader header, Stream input)
        {
            if (input == null) 
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (!input.CanRead || !input.CanSeek) 
            {
                throw new ArgumentException("Input stream must be readable and seekable.", nameof(input));
            }

            input.Position = 0;

            CacheFileHeaderHalo3Ares aresHeader = header as CacheFileHeaderHalo3Ares;

            var output = new MemoryStream(checked((int)aresHeader.Size));
            using (var reader = new EndianReader(input, true, EndianFormat.LittleEndian))
            using (var writer = new EndianWriter(output, true, EndianFormat.LittleEndian))
            {
                var serializer = new TagSerializer(CacheVersion.Halo3Ares, CachePlatform.MCC);
                var writerContext = new DataSerializationContext(writer);

                serializer.Serialize(writerContext, aresHeader);

                var updatedSectionOffsets = new int[(int)CacheFileSectionType.Count];

                foreach (int sectionIndex in DecompressedSectionOrder) 
                {
                    DecompressSection(sectionIndex, aresHeader, reader, writer, output, updatedSectionOffsets);
                }

                for (int i = 0; i < (int)CacheFileSectionType.Count; i++)
                {
                    aresHeader.SectionTable.SectionOffsets[i] = updatedSectionOffsets[i];
                    aresHeader.CompressedSectionSize[i].Value = 0;
                    aresHeader.CompressedSectionCodec[i].Codec = CompressedSectionCodec.None;
                }

                writer.Seek(0, SeekOrigin.Begin);
                serializer.Serialize(writerContext, aresHeader);
            }

            AresHeader = aresHeader;

            output.Position = 0;
            return output;
        }

        private static void DecompressSection(int sectionIndex, CacheFileHeader header, EndianReader reader, EndianWriter writer, MemoryStream output, int[] updatedSectionOffsets)
        {
            var bounds = header.GetSectionTable().OriginalSectionBounds[sectionIndex];

            if (bounds.Size <= 0)
            {
                updatedSectionOffsets[sectionIndex] = 0;
                return;
            }

            long alignedOffset = Align(output.Position, SegmentAlignment);
            writer.BaseStream.Seek(alignedOffset, SeekOrigin.Begin);
            updatedSectionOffsets[sectionIndex] = checked((int)(alignedOffset - bounds.Offset));

            uint inputOffset = header.GetCompressedSectionOffset()[sectionIndex].Value;
            uint compressedSize = header.GetCompressedSectionSize()[sectionIndex].Value;
            var codec = header.GetCompressedSectionCodec()[sectionIndex].Codec;

            if (codec == CompressedSectionCodec.None)
            {
                // Some uncompressed caches don't populate CompressedSectionOffset. Fall back to
                // the section table in that case.
                long rawOffset = inputOffset != 0
                    ? inputOffset
                    : (long)bounds.Offset + header.GetSectionTable().SectionOffsets[sectionIndex];

                using var sectionStream = new RangeStream(reader.BaseStream, rawOffset, bounds.Size);
                sectionStream.CopyTo(output);
                return;
            }

            if (codec != CompressedSectionCodec.LZMALib) 
            {
                throw new NotSupportedException($"Unsupported Ares section codec {codec}.");
            }

            if (compressedSize < 2) 
            {
                throw new InvalidDataException($"Compressed section {sectionIndex} is too small.");
            }

            reader.SeekTo(inputOffset);
            byte properties = reader.ReadByte();
            byte packedDictionary = reader.ReadByte();

            if (properties != 0x5D) 
            {
                throw new InvalidDataException($"Unexpected LZMA properties byte 0x{properties:X2} in section {sectionIndex}.");
            }

            int dictionarySize = UnpackHeader(packedDictionary);
            byte[] dictionaryBytes = BitConverter.GetBytes(dictionarySize);

            using var lzmaInput = new MemoryStream();
            lzmaInput.WriteByte(properties);
            lzmaInput.Write(dictionaryBytes, 0, dictionaryBytes.Length);
            reader.BaseStream.CopyExactlyTo(lzmaInput, compressedSize - 2);
            lzmaInput.Position = 0;

            byte[] decoderProperties = new byte[5];

            if (lzmaInput.Read(decoderProperties, 0, decoderProperties.Length) != decoderProperties.Length) 
            {
                throw new EndOfStreamException();
            }

            var decoder = new Decoder();
            decoder.SetDecoderProperties(decoderProperties);
            decoder.Code(lzmaInput, output, compressedSize, bounds.Size, null);
        }

        private static int UnpackHeader(byte value)
        {
            int shift = ((value >> 1) & 0x1F) + 10;
            int baseValue = ((value & 1) * 2) + 1;
            return baseValue << shift;
        }

        private static long Align(long value, int alignment) =>
            (value + alignment - 1) & ~((long)alignment - 1);
    }
}
