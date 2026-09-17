using SevenZip;
using SevenZip.Compression.LZMA;
using System;
using System.IO;
using TagTool.Cache.CacheFile;
using TagTool.Cache.MCC.Headers;
using TagTool.IO;
using TagTool.Serialization;

namespace TagTool.Cache.Gen3
{
    /// <summary>
    /// Compression/decompression support for the 2014 Xbox One Halo 3 MCC cache format.
    ///
    /// These maps store four logical sections. Compressed files store them physically in
    /// 0,1,2,3 order, while the decompressed cache layout is 0,1,3,2. LZMA sections use
    /// a compact two-byte header: the normal LZMA properties byte (0x5D) followed by a
    /// packed dictionary-size byte.
    /// </summary>
    public static class DurangoCacheCompression
    {
        public const int SegmentAlignment = 0x1000;

        private const int TagDictionarySize = 0x1000000;      // 16 MiB (0x1C packed)
        private const int LanguageDictionarySize = 0x200000;  //  2 MiB (0x16 packed, as decoded by Ares.exe)

        private static readonly int[] DecompressedSectionOrder =
        {
            (int)CacheFileSectionType.DebugSection,
            (int)CacheFileSectionType.ResourceSection,
            (int)CacheFileSectionType.LanguagePackSection,
            (int)CacheFileSectionType.TagSection,
        };

        private static readonly int[] CompressedSectionOrder =
        {
            (int)CacheFileSectionType.DebugSection,
            (int)CacheFileSectionType.ResourceSection,
            (int)CacheFileSectionType.TagSection,
            (int)CacheFileSectionType.LanguagePackSection,
        };

        public static bool IsCompressed(CacheFileHeaderHalo3MCCXbox header)
        {
            if (header?.CompressedSectionSize == null || header.CompressedSectionCodec == null)
                return false;

            for (int i = 0; i < (int)CacheFileSectionType.Count; i++)
            {
                if (header.CompressedSectionSize[i].Value != 0 ||
                    header.CompressedSectionCodec[i].Codec != CompressedSectionCodec.None)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Probes a stream as a 2014 Halo 3 Xbox One MCC cache without going through
        /// MapFile/GameCache construction. This is safe to use before TagCacheGen3 exists.
        /// </summary>
        public static bool TryReadHeader(Stream input, out CacheFileHeaderHalo3MCCXbox header)
        {
            header = null;
            if (input == null || !input.CanRead || !input.CanSeek)
                return false;

            long originalPosition = input.Position;
            try
            {
                input.Position = 0;
                using var reader = new EndianReader(input, true, EndianFormat.LittleEndian);
                var deserializer = new TagDeserializer(CacheVersion.Halo3XboxOne, CachePlatform.MCC);
                var candidate = deserializer.Deserialize<CacheFileHeaderHalo3MCCXbox>(new DataSerializationContext(reader));
                ValidateHeader(candidate);
                header = candidate;
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                input.Position = originalPosition;
            }
        }

        public static MemoryStream Decompress(Stream input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            if (!input.CanRead || !input.CanSeek)
                throw new ArgumentException("Input stream must be readable and seekable.", nameof(input));

            input.Position = 0;

            CacheFileHeaderHalo3MCCXbox header;
            using (var reader = new EndianReader(input, true, EndianFormat.LittleEndian))
            {
                var deserializer = new TagDeserializer(CacheVersion.Halo3XboxOne, CachePlatform.MCC);
                header = deserializer.Deserialize<CacheFileHeaderHalo3MCCXbox>(new DataSerializationContext(reader));
            }

            ValidateHeader(header);

            // Shared maps such as campaign.map can have no section data at all. If the map is
            // already uncompressed, preserve it exactly instead of rebuilding a 0x3000-byte shell.
            if (!IsCompressed(header))
                return CopyToMemory(input);

            var output = new MemoryStream(checked((int)header.Size));
            using (var reader = new EndianReader(input, true, EndianFormat.LittleEndian))
            using (var writer = new EndianWriter(output, true, EndianFormat.LittleEndian))
            {
                var serializer = new TagSerializer(CacheVersion.Halo3XboxOne, CachePlatform.MCC);
                var writerContext = new DataSerializationContext(writer);

                // Reserve/write the original header first. It is rewritten with corrected masks below.
                serializer.Serialize(writerContext, header);

                var updatedSectionOffsets = new int[(int)CacheFileSectionType.Count];

                foreach (int sectionIndex in DecompressedSectionOrder)
                    DecompressSection(sectionIndex, header, reader, writer, output, updatedSectionOffsets);

                for (int i = 0; i < (int)CacheFileSectionType.Count; i++)
                {
                    header.SectionTable.SectionOffsets[i] = updatedSectionOffsets[i];
                    header.CompressedSectionSize[i].Value = 0;
                    header.CompressedSectionCodec[i].Codec = CompressedSectionCodec.None;
                }

                writer.Seek(0, SeekOrigin.Begin);
                serializer.Serialize(writerContext, header);
            }

            output.Position = 0;
            return output;
        }

        public static MemoryStream Compress(Stream input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            if (!input.CanRead || !input.CanSeek)
                throw new ArgumentException("Input stream must be readable and seekable.", nameof(input));

            input.Position = 0;

            CacheFileHeaderHalo3MCCXbox header;
            using (var reader = new EndianReader(input, true, EndianFormat.LittleEndian))
            {
                var deserializer = new TagDeserializer(CacheVersion.Halo3XboxOne, CachePlatform.MCC);
                header = deserializer.Deserialize<CacheFileHeaderHalo3MCCXbox>(new DataSerializationContext(reader));
            }

            ValidateHeader(header);

            if (IsCompressed(header))
                throw new InvalidOperationException("The cache is already compressed. Decompress it before recompressing.");

            bool hasSectionData = false;
            for (int i = 0; i < (int)CacheFileSectionType.Count; i++)
                hasSectionData |= header.SectionTable.OriginalSectionBounds[i].Size > 0;

            // campaign.map and similar shared caches from these builds can contain no standard
            // cache sections. There is nothing useful to section-compress, so preserve the file.
            if (!hasSectionData)
                return CopyToMemory(input);

            bool hasCompressibleSection =
                header.SectionTable.OriginalSectionBounds[(int)CacheFileSectionType.TagSection].Size > 0 ||
                header.SectionTable.OriginalSectionBounds[(int)CacheFileSectionType.LanguagePackSection].Size > 0;

            // A cache with only debug/resource data has no section type that this format normally
            // LZMA-compresses. Preserve it instead of creating a misleading "compressed" cache.
            if (!hasCompressibleSection)
                return CopyToMemory(input);

            // The input section masks describe the decompressed physical layout and are needed
            // to locate each source section before we overwrite them with compressed-layout masks.
            var sourceSectionOffsets = (int[])header.SectionTable.SectionOffsets.Clone();

            // Ares keeps using the section-mask table after loading a compressed cache.
            // In stock Durango H3 maps the compressed resource-section mask is the same
            // value that the decompressed layout uses for the language section. Assembly's
            // decompressor turns the stock [0, 0xED000, 0, ...] layout into
            // [0, 0, ..., 0xED000]; restoring that value is part of the inverse transform.
            int compressedResourceMask = sourceSectionOffsets[(int)CacheFileSectionType.LanguagePackSection];

            var output = new MemoryStream(checked((int)Math.Min(input.Length, int.MaxValue)));
            using (var reader = new EndianReader(input, true, EndianFormat.LittleEndian))
            using (var writer = new EndianWriter(output, true, EndianFormat.LittleEndian))
            {
                var serializer = new TagSerializer(CacheVersion.Halo3XboxOne, CachePlatform.MCC);
                var writerContext = new DataSerializationContext(writer);

                serializer.Serialize(writerContext, header);

                foreach (int sectionIndex in CompressedSectionOrder)
                {
                    var bounds = header.SectionTable.OriginalSectionBounds[sectionIndex];
                    if (bounds.Size <= 0)
                    {
                        header.SectionTable.SectionOffsets[sectionIndex] = 0;
                        header.CompressedSectionOffset[sectionIndex].Value = 0;
                        header.CompressedSectionSize[sectionIndex].Value = 0;
                        header.CompressedSectionCodec[sectionIndex].Codec = CompressedSectionCodec.None;
                        continue;
                    }

                    long alignedOffset = Align(output.Position, SegmentAlignment);
                    writer.BaseStream.Seek(alignedOffset, SeekOrigin.Begin);

                    long sourceOffset = (long)bounds.Offset + sourceSectionOffsets[sectionIndex];
                    int compressedMask = checked((int)(alignedOffset - bounds.Offset));
                    if (sectionIndex == (int)CacheFileSectionType.ResourceSection)
                        compressedMask = compressedResourceMask;

                    header.SectionTable.SectionOffsets[sectionIndex] = compressedMask;
                    header.CompressedSectionOffset[sectionIndex].Value = checked((uint)alignedOffset);

                    using var sectionStream = new RangeStream(input, sourceOffset, bounds.Size);

                    if (ShouldCompress(sectionIndex))
                    {
                        int dictionarySize = GetDictionarySize(sectionIndex);
                        using var compressedPayload = EncodeLzma(sectionStream, dictionarySize);

                        writer.Write((byte)0x5D);
                        writer.Write(PackHeader(dictionarySize));
                        compressedPayload.Position = 0;
                        compressedPayload.CopyTo(output);

                        header.CompressedSectionSize[sectionIndex].Value = checked((uint)(compressedPayload.Length + 2));
                        header.CompressedSectionCodec[sectionIndex].Codec = CompressedSectionCodec.LZMALib;
                        continue;
                    }

                    sectionStream.CopyTo(output);
                    header.CompressedSectionSize[sectionIndex].Value = 0;
                    header.CompressedSectionCodec[sectionIndex].Codec = CompressedSectionCodec.None;
                }

                // Real Xbox One MCC caches are padded to a 0x1000 boundary.
                output.SetLength(Align(output.Length, SegmentAlignment));

                writer.Seek(0, SeekOrigin.Begin);
                serializer.Serialize(writerContext, header);
            }

            output.Position = 0;
            return output;
        }

        private static void DecompressSection(
            int sectionIndex,
            CacheFileHeaderHalo3MCCXbox header,
            EndianReader reader,
            EndianWriter writer,
            MemoryStream output,
            int[] updatedSectionOffsets)
        {
            var bounds = header.SectionTable.OriginalSectionBounds[sectionIndex];
            if (bounds.Size <= 0)
            {
                updatedSectionOffsets[sectionIndex] = 0;
                return;
            }

            long alignedOffset = Align(output.Position, SegmentAlignment);
            writer.BaseStream.Seek(alignedOffset, SeekOrigin.Begin);
            updatedSectionOffsets[sectionIndex] = checked((int)(alignedOffset - bounds.Offset));

            uint inputOffset = header.CompressedSectionOffset[sectionIndex].Value;
            uint compressedSize = header.CompressedSectionSize[sectionIndex].Value;
            var codec = header.CompressedSectionCodec[sectionIndex].Codec;

            if (codec == CompressedSectionCodec.None)
            {
                // Some uncompressed caches don't populate CompressedSectionOffset. Fall back to
                // the section table in that case.
                long rawOffset = inputOffset != 0
                    ? inputOffset
                    : (long)bounds.Offset + header.SectionTable.SectionOffsets[sectionIndex];

                using var sectionStream = new RangeStream(reader.BaseStream, rawOffset, bounds.Size);
                sectionStream.CopyTo(output);
                return;
            }

            if (codec != CompressedSectionCodec.LZMALib)
                throw new NotSupportedException($"Unsupported Xbox One MCC section codec {codec}.");

            if (compressedSize < 2)
                throw new InvalidDataException($"Compressed section {sectionIndex} is too small.");

            reader.SeekTo(inputOffset);
            byte properties = reader.ReadByte();
            byte packedDictionary = reader.ReadByte();

            if (properties != 0x5D)
                throw new InvalidDataException($"Unexpected LZMA properties byte 0x{properties:X2} in section {sectionIndex}.");

            int dictionarySize = UnpackHeader(packedDictionary);
            byte[] dictionaryBytes = BitConverter.GetBytes(dictionarySize);

            using var lzmaInput = new MemoryStream();
            lzmaInput.WriteByte(properties);
            lzmaInput.Write(dictionaryBytes, 0, dictionaryBytes.Length);
            reader.BaseStream.CopyExactlyTo(lzmaInput, compressedSize - 2);
            lzmaInput.Position = 0;

            byte[] decoderProperties = new byte[5];
            if (lzmaInput.Read(decoderProperties, 0, decoderProperties.Length) != decoderProperties.Length)
                throw new EndOfStreamException();

            var decoder = new Decoder();
            decoder.SetDecoderProperties(decoderProperties);
            decoder.Code(lzmaInput, output, compressedSize, bounds.Size, null);
        }

        private static MemoryStream EncodeLzma(Stream input, int dictionarySize)
        {
            input.Position = 0;

            var encoder = new Encoder();
            encoder.SetCoderProperties(
                new[]
                {
                    CoderPropID.DictionarySize,
                    CoderPropID.PosStateBits,
                    CoderPropID.LitContextBits,
                    CoderPropID.LitPosBits,
                    CoderPropID.NumFastBytes,
                    CoderPropID.MatchFinder,
                    CoderPropID.EndMarker,
                },
                new object[]
                {
                    dictionarySize,
                    2,
                    3,
                    0,
                    32,
                    "BT4",
                    false,
                });

            var output = new MemoryStream();
            encoder.Code(input, output, input.Length, -1, null);
            output.Position = 0;
            return output;
        }

        private static void ValidateHeader(CacheFileHeaderHalo3MCCXbox header)
        {
            if (header == null || !header.IsValid())
                throw new InvalidDataException("The input is not a valid Halo 3 Xbox One MCC cache file.");

            if (header.BuildNumber != "Oct  1 2014 16:20:07" &&
                header.BuildNumber != "Oct 30 2014 19:01:55")
            {
                throw new NotSupportedException(
                    $"Unsupported Halo 3 Xbox One MCC build '{header.BuildNumber}'.");
            }

            if (header.SectionTable == null ||
                header.CompressedSectionOffset == null ||
                header.CompressedSectionSize == null ||
                header.CompressedSectionCodec == null)
            {
                throw new InvalidDataException("The cache header does not contain the expected section metadata.");
            }
        }

        private static bool ShouldCompress(int sectionIndex) =>
            sectionIndex == (int)CacheFileSectionType.TagSection ||
            sectionIndex == (int)CacheFileSectionType.LanguagePackSection;

        private static int GetDictionarySize(int sectionIndex) =>
            sectionIndex == (int)CacheFileSectionType.LanguagePackSection
                ? LanguageDictionarySize
                : TagDictionarySize;

        private static byte PackHeader(int dictionarySize)
        {
            for (int value = 0; value <= byte.MaxValue; value++)
                if (UnpackHeader((byte)value) == dictionarySize)
                    return (byte)value;

            throw new ArgumentOutOfRangeException(nameof(dictionarySize),
                $"Dictionary size 0x{dictionarySize:X} cannot be represented by the MCC compact LZMA header.");
        }

        private static int UnpackHeader(byte value)
        {
            int shift = ((value >> 1) & 0x1F) + 10;
            // Ares.exe (Windows) uses bit 0 here:
            //   base = ((value & 1) * 2) + 1
            // This makes 0x16 = 2 MiB and 0x1C = 16 MiB.
            int baseValue = ((value & 1) * 2) + 1;
            return baseValue << shift;
        }

        private static long Align(long value, int alignment) =>
            (value + alignment - 1) & ~((long)alignment - 1);

        private static MemoryStream CopyToMemory(Stream input)
        {
            input.Position = 0;
            var result = new MemoryStream();
            input.CopyTo(result);
            result.Position = 0;
            return result;
        }
    }

    internal static class DurangoStreamExtensions
    {
        public static void CopyExactlyTo(this Stream source, Stream destination, long count)
        {
            byte[] buffer = new byte[1024 * 1024];
            long remaining = count;

            while (remaining > 0)
            {
                int read = source.Read(buffer, 0, (int)Math.Min(buffer.Length, remaining));
                if (read <= 0)
                    throw new EndOfStreamException();

                destination.Write(buffer, 0, read);
                remaining -= read;
            }
        }
    }
}
