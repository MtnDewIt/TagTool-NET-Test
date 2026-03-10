using SevenZip.Compression.LZMA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Cache.CacheFile;
using TagTool.Cache.MCC.Headers;
using TagTool.Commands.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;
using static TagTool.Cache.SharedResourceUsage;

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

                    ParseHeader(header);

                    serializer.Serialize(writerContext, header);

                    int[] updatedSectionOffsets = new int[4];

                    for (int section_index = 0; section_index < (int)CacheFileSectionType.Count; section_index++) 
                    {
                        uint offset = header.CompressedSectionOffset[section_index].Value;
                        uint compressedSize = header.CompressedSectionSize[section_index].Value;
                        CompressedSectionCodec codec = header.CompressedSectionCodec[section_index].Codec;
                        int decompressedSize = header.SectionTable.OriginalSectionBounds[section_index].Size;
                        int decompressedOffset = header.SectionTable.OriginalSectionBounds[section_index].Offset;
                        int sectionOffset = header.SectionTable.SectionOffsets[section_index];

                        int finalOffset = decompressedOffset + sectionOffset;

                        int padding = ((int)writer.BaseStream.Position + SEGMENT_ALIGNMENT - 1) & ~(SEGMENT_ALIGNMENT - 1);

                        writer.Seek(padding, SeekOrigin.Begin);

                        updatedSectionOffsets[section_index] = padding - decompressedOffset;

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

        private static void ParseHeader(CacheFileHeaderHalo3MCCXbox header) 
        {
            Console.WriteLine($"[Cache File Header] HeaderSignature: {header.HeaderSignature}");
            Console.WriteLine($"[Cache File Header] Version: {header.Version}");
            Console.WriteLine($"[Cache File Header] Size: {header.Size}");
            Console.WriteLine($"[Cache File Header] CompressedFilePadding: {header.CompressedFilePadding}");
            Console.WriteLine($"[Cache File Header] TagsHeaderWhenLoaded: {header.TagsHeaderWhenLoaded}");
            Console.WriteLine($"[Cache File Header] TagsOffset: {header.TagsOffset}");
            Console.WriteLine($"[Cache File Header] TotalTagsSize: {header.TotalTagsSize}");
            Console.WriteLine($"[Cache File Header] Path: {header.Path}");
            Console.WriteLine($"[Cache File Header] BuildNumber: {header.BuildNumber}");
            Console.WriteLine($"[Cache File Header] ScenarioType: {header.ScenarioType}");
            Console.WriteLine($"[Cache File Header] SharedCacheFileType: {header.SharedCacheFileType}");
            Console.WriteLine($"[Cache File Header] Uncompressed: {header.Uncompressed}");
            Console.WriteLine($"[Cache File Header] Tracked: {header.Tracked}");
            Console.WriteLine($"[Cache File Header] ValidSharedResourceUsage: {header.ValidSharedResourceUsage}");
            Console.WriteLine($"[Cache File Header] HeaderFlags: {header.HeaderFlags}");
            Console.WriteLine($"[Cache File Header] SlotModificationDate: {header.SlotModificationDate}");
            Console.WriteLine($"[Cache File Header] LowDetailTextureNumber: {header.LowDetailTextureNumber}");
            Console.WriteLine($"[Cache File Header] LowDetailTextureOffset: {header.LowDetailTextureOffset}");
            Console.WriteLine($"[Cache File Header] LowDetailTextureByteCount: {header.LowDetailTextureByteCount}");
            Console.WriteLine($"[Cache File Header] StringIdCount: {header.StringIdCount}");
            Console.WriteLine($"[Cache File Header] StringIdDataCount: {header.StringIdDataCount}");
            Console.WriteLine($"[Cache File Header] StringIdIndexOffset: {header.StringIdIndexOffset}");
            Console.WriteLine($"[Cache File Header] StringIdDataOffset: {header.StringIdDataOffset}");
            Console.WriteLine($"[Cache File Header] SharedMapUsage: {header.SharedMapUsage}");
            Console.WriteLine($"[Cache File Header] Pad1: {header.Pad1}");
            Console.WriteLine($"[Cache File Header] CreationDate: {header.CreationDate}");

            Console.WriteLine($"[Cache File Header] Name: {header.Name}");
            Console.WriteLine($"[Cache File Header] Language: {header.Language}");
            Console.WriteLine($"[Cache File Header] TagPath: {header.TagPath}");
            Console.WriteLine($"[Cache File Header] MinorVersionNumber: {header.MinorVersionNumber}");
            Console.WriteLine($"[Cache File Header] DebugTagNameCount: {header.DebugTagNameCount}");
            Console.WriteLine($"[Cache File Header] DebugTagNameDataOffset: {header.DebugTagNameDataOffset}");
            Console.WriteLine($"[Cache File Header] DebugTagNameDataSize: {header.DebugTagNameDataSize}");
            Console.WriteLine($"[Cache File Header] DebugTagNameIndexOffset: {header.DebugTagNameIndexOffset}");
            Console.WriteLine($"[Cache File Header] RealtimeChecksum: {header.RealtimeChecksum}");
            Console.WriteLine($"[Cache File Header] CreatorName: {header.CreatorName}");
            Console.WriteLine($"[Cache File Header] ExpectedBaseAddress: {header.ExpectedBaseAddress}");
            Console.WriteLine($"[Cache File Header] XDKVersion: {header.XDKVersion}");
            Console.WriteLine($"[Cache File Header] Alignment: {header.Alignment}");
            
            Console.WriteLine($"[Cache File Header] ContentHashMask: {header.ContentHashMask}");
            Console.WriteLine($"[Cache File Header] Pad2: {header.Pad2}");
            Console.WriteLine($"[Cache File Header] SignatureMarker: {header.SignatureMarker}");

            Console.WriteLine($"[Cache File Header] RSASignature: " + (header.RSASignature.Data.All(x => x == 0) ? "None" : header.RSASignature.GetSignature()));

            Console.WriteLine($"[Cache File Header] TagsAddrsOffset: {header.TagsAddrsOffset}");
            Console.WriteLine($"[Cache File Header] TagsAddrsSize: {header.TagsAddrsSize}");
            Console.WriteLine($"[Cache File Header] Patch: {header.Patch}");
            Console.WriteLine($"[Cache File Header] PatchSize: {header.PatchSize}");

            Console.WriteLine($"[Cache File Header] Padding: {header.Padding}");
            Console.WriteLine($"[Cache File Header] FooterSignature: {header.FooterSignature}");


            for (int dateIndex = 0; dateIndex < (int)SharedResourceDatabaseTypeMCC.Count; dateIndex++)
            {
                Console.WriteLine();
                Console.WriteLine($"[Cache File Header] {(SharedResourceDatabaseTypeMCC)dateIndex}: SharedCreationDate - LastModificationDate: {header.SharedCreationDate[dateIndex].LastModificationDate}");
            }

            for (int partitionIndex = 0; partitionIndex < (int)CacheFilePartitionType.Count; partitionIndex++)
            {
                Console.WriteLine();
                Console.WriteLine($"[Cache File Header] {(CacheFilePartitionType)partitionIndex}: Partitions - VirtualAddress: {header.Partitions[partitionIndex].VirtualAddress}");
                Console.WriteLine($"[Cache File Header] {(CacheFilePartitionType)partitionIndex}: Partitions - Size: {header.Partitions[partitionIndex].Size}");
            }

            for (int hashIndex = 0; hashIndex < 3; hashIndex++) 
            {
                Console.WriteLine();
                Console.WriteLine($"[Cache File Header] Unknown{hashIndex}: ContentHashes - {header.ContentHashes[hashIndex].Hash.GetHash()}");
            }

            Console.WriteLine();
            for (int identifierIndex = 0; identifierIndex < 4; identifierIndex++) 
            {
                Console.WriteLine($"[Cache File Header] SharedResourceUsage SharedLayoutIdentifier {identifierIndex}: {header.SharedResourceUsage.SharedLayoutIdentifier.Data[identifierIndex]}");
            }

            Console.WriteLine();
            Console.WriteLine($"[Cache File Header] SharedResourceUsage SharedLocationCount: {header.SharedResourceUsage.SharedLocationCount}");
            Console.WriteLine($"[Cache File Header] SharedResourceUsage LocalLocationCount: {header.SharedResourceUsage.LocalLocationCount}");
            Console.WriteLine($"[Cache File Header] SharedResourceUsage FirstFileOffset: {header.SharedResourceUsage.FirstFileOffset}");

            Console.WriteLine();
            for (int identifierIndex = 0; identifierIndex < 4; identifierIndex++) 
            {
                Console.WriteLine($"[Cache File Header] SharedResourceUsage CodecIdentifier {identifierIndex}: {header.SharedResourceUsage.CodecIdentifier.Data[identifierIndex]}");
            }

            for (int locationIndex = 0; locationIndex < header.SharedResourceUsage.LocalLocations.Length; locationIndex++) 
            {
                Console.WriteLine();
                Console.WriteLine($"[Cache File Header] SharedResourceUsage LocalLocations {locationIndex}: FlagsAndFileSize: {header.SharedResourceUsage.LocalLocations[locationIndex].FlagsAndFileSize}");
                Console.WriteLine($"[Cache File Header] SharedResourceUsage LocalLocations {locationIndex}: MemorySize: {header.SharedResourceUsage.LocalLocations[locationIndex].MemorySize}");
                Console.WriteLine($"[Cache File Header] SharedResourceUsage LocalLocations {locationIndex}: EntireChecksum: " + (header.SharedResourceUsage.LocalLocations[locationIndex].EntireChecksum.Data.All(x => x == 0) ? "None" : header.SharedResourceUsage.LocalLocations[locationIndex].EntireChecksum.GetHash()));
            }

            Console.WriteLine();
            Console.WriteLine($"[Cache File Header] SharedResourceUsage InsertionPointUsageCount: {header.SharedResourceUsage.InsertionPointUsageCount}");
            Console.WriteLine($"[Cache File Header] SharedResourceUsage Padding: {header.SharedResourceUsage.Padding}");

            for (int insertionIndex = 0; insertionIndex < header.SharedResourceUsage.InsertionPointUsages.Length; insertionIndex++) 
            {
                Console.WriteLine();
                Console.WriteLine($"[Cache File Header] SharedResourceUsage InsertionPointUsages {insertionIndex}: InitialZoneSetIndex: {header.SharedResourceUsage.InsertionPointUsages[insertionIndex].InitialZoneSetIndex}");
                Console.WriteLine($"[Cache File Header] SharedResourceUsage InsertionPointUsages {insertionIndex}: Padding: {header.SharedResourceUsage.InsertionPointUsages[insertionIndex].Padding}");
                Console.WriteLine();

                for (int sharedLocationIndex = 0; sharedLocationIndex < header.SharedResourceUsage.InsertionPointUsages[insertionIndex].SharedRequiredLocations.Length; sharedLocationIndex++) 
                {
                    Console.WriteLine($"[Cache File Header] SharedResourceUsage InsertionPointUsages {insertionIndex}: SharedRequiredLocations {sharedLocationIndex}: {header.SharedResourceUsage.InsertionPointUsages[insertionIndex].SharedRequiredLocations[sharedLocationIndex]}");
                }

                for (int localLocationIndex = 0; localLocationIndex < header.SharedResourceUsage.InsertionPointUsages[insertionIndex].LocalRequiredLocations.Length; localLocationIndex++) 
                {
                    Console.WriteLine($"[Cache File Header] SharedResourceUsage InsertionPointUsages {insertionIndex}: LocalRequiredLocations {localLocationIndex}: {header.SharedResourceUsage.InsertionPointUsages[insertionIndex].LocalRequiredLocations[localLocationIndex]}");
                }
            } 

            for (int sectionIndex = 0; sectionIndex < (int)CacheFileSectionType.Count; sectionIndex++) 
            {
                int sectionOffset = header.SectionTable.SectionOffsets[sectionIndex];
                CacheFileSectionFileBounds sectionBounds = header.SectionTable.OriginalSectionBounds[sectionIndex];
                uint compressedOffset = header.CompressedSectionOffset[sectionIndex].Value;
                uint compressedSize = header.CompressedSectionSize[sectionIndex].Value;
                CompressedSectionCodec compressedCodec = header.CompressedSectionCodec[sectionIndex].Codec;

                Console.WriteLine();
                Console.WriteLine($"[Cache File Header] {(CacheFileSectionType)sectionIndex}: SectionTable - Offset: {sectionOffset}");
                Console.WriteLine($"[Cache File Header] {(CacheFileSectionType)sectionIndex}: SectionTable - OriginalSectionBounds - Offset: {sectionBounds.Offset}");
                Console.WriteLine($"[Cache File Header] {(CacheFileSectionType)sectionIndex}: SectionTable - OriginalSectionBounds - Size: {sectionBounds.Size}");
                Console.WriteLine($"[Cache File Header] {(CacheFileSectionType)sectionIndex}: CompressedSectionOffset - Value: {compressedOffset}");
                Console.WriteLine($"[Cache File Header] {(CacheFileSectionType)sectionIndex}: CompressedSectionSize - Value: {compressedSize}");
                Console.WriteLine($"[Cache File Header] {(CacheFileSectionType)sectionIndex}: CompressedSectionCodec - Codec: {compressedCodec}");
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
