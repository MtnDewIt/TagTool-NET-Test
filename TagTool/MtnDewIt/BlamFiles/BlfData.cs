using System;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.BlamFiles
{
    /// <summary>
    /// Main class for blf format. Reads, parse and writes blf.
    /// </summary>
    public class BlfData
    {
        public CacheVersion Version;
        public CachePlatform CachePlatform;
        public EndianFormat Format;

        public BlfDataFileContentFlags ContentFlags;
        public BlfDataAuthenticationType AuthenticationType;

        public BlfDataChunkStartOfFile StartOfFile;
        public BlfDataEndOfFileCRC EndOfFileCRC;
        public BlfDataEndOfFileRSA EndOfFileRSA;
        public BlfDataEndOfFileSHA1 EndOfFileSHA1;
        public BlfDataChunkEndOfFile EndOfFile;
        public BlfDataAuthor Author;
        public BlfDataCampaign Campaign;
        public BlfDataScenario Scenario;
        public BlfDataModPackageReference ModReference;
        public BlfDataMapVariantTagNames MapVariantTagNames;
        public BlfDataMapVariant MapVariant;
        public BlfDataGameVariant GameVariant;
        public BlfDataContentHeader ContentHeader;
        public BlfDataMapImage MapImage;
        public byte[] Buffer;

        public BlfData(CacheVersion version, CachePlatform cachePlatform)
        {
            Version = version;
            CachePlatform = cachePlatform;
        }

        public bool ReadData(EndianReader reader)
        {
            if (!IsValidBlf(reader))
                return false;

            var deserializer = new TagDeserializer(Version, CachePlatform);

            while (!reader.EOF)
            {
                var dataContext = new DataSerializationContext(reader, useAlignment: false);
                var chunkHeaderPosition = reader.Position;

                var header = deserializer.Deserialize<BlfDataChunkHeader>(dataContext);
                reader.SeekTo(chunkHeaderPosition);

                switch (header.Signature.ToString())
                {
                    case "_blf":
                        ContentFlags |= BlfDataFileContentFlags.StartOfFile;
                        StartOfFile = deserializer.Deserialize<BlfDataChunkStartOfFile>(dataContext);
                        break;

                    case "_eof":
                        ContentFlags |= BlfDataFileContentFlags.EndOfFile;
                        var position = reader.Position;
                        EndOfFile = deserializer.Deserialize<BlfDataChunkEndOfFile>(dataContext);
                        AuthenticationType = EndOfFile.AuthenticationType;
                        switch (AuthenticationType)
                        {
                            case BlfDataAuthenticationType.AuthenticationTypeNone:
                                break;
                            case BlfDataAuthenticationType.AuthenticationTypeCRC:
                                reader.SeekTo(position);
                                EndOfFileCRC = deserializer.Deserialize<BlfDataEndOfFileCRC>(dataContext);
                                break;
                            case BlfDataAuthenticationType.AuthenticationTypeRSA:
                                reader.SeekTo(position);
                                EndOfFileRSA = deserializer.Deserialize<BlfDataEndOfFileRSA>(dataContext);
                                break;
                            case BlfDataAuthenticationType.AuthenticationTypeSHA1:
                                reader.SeekTo(position);
                                EndOfFileSHA1 = deserializer.Deserialize<BlfDataEndOfFileSHA1>(dataContext);
                                break;
                        }
                        return true;

                    case "cmpn":
                        ContentFlags |= BlfDataFileContentFlags.Campaign;
                        Campaign = deserializer.Deserialize<BlfDataCampaign>(dataContext);
                        break;

                    case "levl":
                        ContentFlags |= BlfDataFileContentFlags.Scenario;
                        Scenario = deserializer.Deserialize<BlfDataScenario>(dataContext);
                        break;

                    case "modp":
                        ContentFlags |= BlfDataFileContentFlags.ModReference;
                        if(header.MajorVersion == (short)BlfDataModPackageReferenceVersion.Version1)
                        {
                            var v1 = deserializer.Deserialize<BlfDataModPackageReferenceV1>(dataContext);
                            ModReference = new BlfDataModPackageReference(v1); // Convert to the new format
                        }
                        else
                        {
                            ModReference = deserializer.Deserialize<BlfDataModPackageReference>(dataContext);
                        }
                        break;

                    case "mapv":
                        ContentFlags |= BlfDataFileContentFlags.MapVariant;
                        MapVariant = deserializer.Deserialize<BlfDataMapVariant>(dataContext);
                        break;
                    case "tagn":
                        ContentFlags |= BlfDataFileContentFlags.MapVariantTagNames;
                        MapVariantTagNames = deserializer.Deserialize<BlfDataMapVariantTagNames>(dataContext);
                        break;


                    case "mpvr":
                        ContentFlags |= BlfDataFileContentFlags.GameVariant;
                        GameVariant = deserializer.Deserialize<BlfDataGameVariant>(dataContext);
                        break;

                    case "chdr":
                        ContentFlags |= BlfDataFileContentFlags.ContentHeader;
                        ContentHeader = deserializer.Deserialize<BlfDataContentHeader>(dataContext);
                        break;

                    case "mapi":
                        ContentFlags |= BlfDataFileContentFlags.MapImage;
                        MapImage = deserializer.Deserialize<BlfDataMapImage>(dataContext);
                        Buffer = reader.ReadBytes(MapImage.BufferSize);
                        break;

                    case "scnd":
                    case "scnc":
                    case "flmh":
                    case "flmd":
                    case "athr":
                        Author = deserializer.Deserialize<BlfDataAuthor>(dataContext);
                        break;
                    case "ssig":
                    case "mps2":
                    case "chrt":
                    default:
                        throw new NotImplementedException($"BLF chunk type {header.Signature} not implemented!");
                }
            }

            return true;
        }

        public bool WriteData(EndianWriter writer)
        {
            if (!ContentFlags.HasFlag(BlfDataFileContentFlags.StartOfFile) || !ContentFlags.HasFlag(BlfDataFileContentFlags.EndOfFile))
                return false;

            TagSerializer serializer = new TagSerializer(Version, CachePlatform, Format);
            writer.Format = Format;
            var dataContext = new DataSerializationContext(writer, useAlignment: false);
            
            serializer.Serialize(dataContext, StartOfFile);

            if (ContentFlags.HasFlag(BlfDataFileContentFlags.Scenario))
                serializer.Serialize(dataContext, Scenario);

            if (ContentFlags.HasFlag(BlfDataFileContentFlags.ContentHeader))
                serializer.Serialize(dataContext, ContentHeader);

            if (ContentFlags.HasFlag(BlfDataFileContentFlags.MapVariant))
                serializer.Serialize(dataContext, MapVariant);

            if (ContentFlags.HasFlag(BlfDataFileContentFlags.GameVariant))
                serializer.Serialize(dataContext, GameVariant);

            if (ContentFlags.HasFlag(BlfDataFileContentFlags.Campaign))
                serializer.Serialize(dataContext, Campaign);

            if (ContentFlags.HasFlag(BlfDataFileContentFlags.ModReference))
                serializer.Serialize(dataContext, ModReference);

            if (ContentFlags.HasFlag(BlfDataFileContentFlags.MapVariantTagNames))
                serializer.Serialize(dataContext, MapVariantTagNames);

            if (ContentFlags.HasFlag(BlfDataFileContentFlags.MapImage))
            {
                if (Buffer != null && Buffer.Length > 0)
                {
                    MapImage.BufferSize = Buffer.Length;
                    serializer.Serialize(dataContext, MapImage);
                    // image is always little endian
                    writer.Format = EndianFormat.LittleEndian;
                    writer.WriteBlock(Buffer);
                    writer.Format = Format;
                }
                else
                {
                    new TagToolError(CommandError.CustomError, "No data, image will not be written to BLF");
                }
            }


            switch (AuthenticationType)
            {
                case BlfDataAuthenticationType.AuthenticationTypeNone:
                    serializer.Serialize(dataContext, EndOfFile);
                    break;
                case BlfDataAuthenticationType.AuthenticationTypeCRC:
                    serializer.Serialize(dataContext, EndOfFileCRC);
                    break;
                case BlfDataAuthenticationType.AuthenticationTypeRSA:
                    serializer.Serialize(dataContext, EndOfFileRSA);
                    break;
                case BlfDataAuthenticationType.AuthenticationTypeSHA1:
                    serializer.Serialize(dataContext, EndOfFileSHA1);
                    break;
            }

            return true;
        }

        /// <summary>
        /// Verifies if the stream points to a valid blf start chunk and set the endian format.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private bool IsValidBlf(EndianReader reader)
        {
            var position = reader.Position;
            try
            {
                Format = FindChunkEndianFormat(reader);
                reader.Format = Format;
            }
            catch(Exception e)
            {
                Console.WriteLine($"BLF file is invalid: {e.Message}");
                return false;
            }

            var deserializer = new TagDeserializer(Version, CachePlatform);
            var dataContext = new DataSerializationContext(reader, useAlignment: false);

            var header = deserializer.Deserialize<BlfDataChunkHeader>(dataContext);
            reader.SeekTo(position);

            if (header.Signature == "_blf")
                return true;
            else
                return false;
        }

        /// <summary>
        /// Find the endian format of the file. Assumes that the reader points to the beginning of the blf file stream.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private EndianFormat FindChunkEndianFormat(EndianReader reader)
        {
            reader.Format = EndianFormat.LittleEndian;
            var startOfFile = reader.Position;
            var chunkHeaderSize = (int)TagStructure.GetTagStructureInfo(typeof(BlfDataChunkHeader), Version, CachePlatform).TotalSize;
            reader.SeekTo(startOfFile + chunkHeaderSize);
            if(reader.ReadInt16() == -2)
            {
                reader.SeekTo(startOfFile);
                return EndianFormat.LittleEndian;
            }
            else
            {
                reader.SeekTo(startOfFile + chunkHeaderSize);
                reader.Format = EndianFormat.BigEndian;
                if(reader.ReadInt16() == -2)
                {
                    reader.SeekTo(startOfFile);
                    return EndianFormat.BigEndian;
                }
                else
                {
                    reader.SeekTo(startOfFile);
                    throw new Exception("Invalid BOM found in BLF start of file chunk");
                }
            }
        }

        /// <summary>
        /// Convert to specified Cache Version.
        /// </summary>
        /// <param name="targetVersion"></param>
        /// <param name="platform"></param>
        public void ConvertBlf(CacheVersion targetVersion, CachePlatform platform = CachePlatform.Original)
        {
            switch (Version)
            {
                case CacheVersion.Halo3Retail:
                case CacheVersion.Halo3Beta:
                    switch (targetVersion)
                    {
                        case CacheVersion.Halo3ODST:
                        case CacheVersion.HaloOnlineED:
                        case CacheVersion.HaloOnline106708:
                            ConvertHalo3ToODSTScenarioChunk();
                            Version = targetVersion;
                            if (CacheVersionDetection.IsLittleEndian(targetVersion, platform))
                                Format = EndianFormat.LittleEndian;
                            break;
                        default:
                            throw new NotImplementedException($"Conversion from Halo 3 to {targetVersion} not supported");
                    }
                    break;

                case CacheVersion.Halo3ODST:
                case CacheVersion.HaloOnlineED:
                case CacheVersion.HaloOnline106708:
                    if (CacheVersionDetection.IsLittleEndian(targetVersion, platform))
                        Format = EndianFormat.LittleEndian;
                    return;

                case CacheVersion.HaloReach:
                    switch (targetVersion)
                    {
                        case CacheVersion.Halo3ODST:
                        case CacheVersion.HaloOnlineED:
                        case CacheVersion.HaloOnline106708:
                            ConvertReachToODSTScenarioChunk();
                            Version = targetVersion;
                            if (CacheVersionDetection.IsLittleEndian(targetVersion, platform))
                                Format = EndianFormat.LittleEndian;
                            break;
                        default:
                            throw new NotImplementedException($"Conversion from {Version} to {targetVersion} not supported");
                    }
                    break;

                default:
                    throw new NotImplementedException($"Conversion from {Version} to {targetVersion} not supported");
            }
        }

        /// <summary>
        /// Converts a Halo 3 Scenario chunk (levl) to ODST format (HO)
        /// </summary>
        private void ConvertHalo3ToODSTScenarioChunk()
        {
            if (!ContentFlags.HasFlag(BlfDataFileContentFlags.Scenario))
                return;

            var insertions = new BlfDataScenarioInsertion[9];
            for(int i = 0; i < 9; i++)
            {
                BlfDataScenarioInsertion ins;
                if( i < 4)
                    ins = Scenario.Insertions[i];
                else
                {
                    ins = new BlfDataScenarioInsertion();
                }
                insertions[i] = ins;
            }
            Scenario.Insertions = insertions;
            Scenario.Length = 0x98C0;
        }

        private void ConvertReachToODSTScenarioChunk()
        {
            if (!ContentFlags.HasFlag(BlfDataFileContentFlags.Scenario))
                return;

            var insertions = new BlfDataScenarioInsertion[9];

            for (int i = 0; i < 9; i++)
            {
                BlfDataScenarioInsertion ins;
                if (i < 9)
                    ins = Scenario.Insertions[i];
                else
                    ins = new BlfDataScenarioInsertion();

                insertions[i] = ins;
            }

            if(Scenario.MapFlags.HasFlag(BlfDataScenarioFlags.IsMultiplayer))
            {
                for (int i = 0; i < 11; i++)
                    Scenario.GameEngineTeamCounts[i] = 8;
            }

            Scenario.Insertions = insertions;
            Scenario.Length = 0x98C0;
            Scenario.MajorVersion = 3;
            Scenario.MinorVersion = 1;
        }
    }

    [Flags]
    public enum BlfDataFileContentFlags : uint
    {
        None = 0,
        StartOfFile = 1 << 0,
        EndOfFile = 1 << 1,
        ContentHeader = 1 << 2,
        MapVariant = 1 << 3,
        Scenario = 1 << 4,
        Campaign = 1 << 5,
        GameVariant = 1 << 6,
        ModReference = 1 << 7,
        MapVariantTagNames = 1 << 8,
        MapImage = 1 << 9,
    }

    [Flags]
    public enum BlfDataScenarioFlags : uint
    {
        None = 0,
        Bit1 = 1 << 0,
        Bit2 = 1 << 1,
        Visible = 1 << 2,
        GeneratesFilm = 1 << 3,
        IsMainmenu = 1 << 4,
        IsCampaign = 1 << 5,
        IsMultiplayer = 1 << 6,
        IsDlc = 1 << 7,
        TestBit = 1 << 8,
        TempBit = 1 << 9,
        IsFirefight = 1 << 10,
        IsCinematic = 1 << 11,
        IsForgeOnly = 1 << 12,
    }

    public enum BlfDataAuthenticationType : byte
    {
        AuthenticationTypeNone,
        AuthenticationTypeCRC,
        AuthenticationTypeSHA1,
        AuthenticationTypeRSA,
    }

    [TagStructure(Size = 0xC, Align = 0x1)]
    public class BlfDataChunkHeader
    {
        public Tag Signature;
        public int Length;
        public short MajorVersion;
        public short MinorVersion;
    }

    [TagStructure(Size = 0x24, Align = 0x1)]
    public class BlfDataChunkStartOfFile : BlfDataChunkHeader
    {
        // when -2, order is little endian, else order is big endian. Check byteswapepd BOM to be -2 otherwise invalid.
        public short ByteOrderMarker;

        [TagField(Length = 0x20)]
        public string InternalName;
        
        [TagField(Length = 2, Flags = TagFieldFlags.Padding)]
        public byte[] Padding;
    }

    [TagStructure(Size = 0x5, Align = 0x1)]
    public class BlfDataChunkEndOfFile : BlfDataChunkHeader 
    {
        public int AuthenticationDataSize;

        public BlfDataAuthenticationType AuthenticationType;
    }

    [TagStructure(Size = 0x4, Align = 0x1)]
    public class BlfDataEndOfFileCRC : BlfDataChunkEndOfFile
    {
        public uint Checksum;
    }

    [TagStructure(Size = 0x100, Align = 0x1)]
    public class BlfDataEndOfFileSHA1 : BlfDataChunkEndOfFile
    {
        [TagField(Length = 0x100)]
        public byte[] Hash;
    }

    [TagStructure(Size = 0x100)]
    public class BlfRSASignature
    {
        [TagField(Length = 0x100)]
        public byte[] Data;
    }

    [TagStructure(Size = 0x100, Align = 0x1)]
    public class BlfDataEndOfFileRSA : BlfDataChunkEndOfFile
    {
        public BlfRSASignature RSASignature;
    }

    [TagStructure(Size = 0x4D44, Align = 0x1, MaxVersion = CacheVersion.Halo3Retail)]
    [TagStructure(Size = 0x98B4, Align = 0x1, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Size = 0xCC8C, Align = 0x1, MinVersion = CacheVersion.HaloReach)]
    public class BlfDataScenario : BlfDataChunkHeader
    {
        public int MapId;
        public BlfDataScenarioFlags MapFlags;

        [TagField(Length = 0xC)]
        public NameUnicode32[] Names;

        [TagField(Length = 0xC)]
        public NameUnicode128[] Descriptions;

        [TagField(Length = 0x100)]
        public string ImageFileBase;

        [TagField(Length = 0x100)]
        public string ScenarioPath;

        public int PresenceContextId;
        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public int SortOrder;

        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public byte MinimumDesiredPlayers;
        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public byte MaximumDesiredPlayers;

        [TagField(Length = 0xB)]
        public byte[] GameEngineTeamCounts;

        public bool AllowSavedFilms;

        [TagField(Length = 0x2, Flags = TagFieldFlags.Padding, MaxVersion = CacheVersion.HaloOnline700123)]
        public byte[] Padding1;

        [TagField(Length = 0x4, Flags = TagFieldFlags.Padding)]
        public byte[] Padding2;

        [TagField(Length = 64, MinVersion = CacheVersion.HaloReach)]
        public uint[] MultiplayerObjects; // bit vector

        [TagField(Length = 0x4, MaxVersion = CacheVersion.Halo3Retail)]
        [TagField(Length = 0x9, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagField(Length = 0xC, MinVersion = CacheVersion.HaloReach)]
        public BlfDataScenarioInsertion[] Insertions;

        [TagField(Length = 0x10, MinVersion = CacheVersion.HaloReach)]
        public string DefaultAuthor;
    }

    [TagStructure(Size = 0xF08, Align = 0x1, MaxVersion = CacheVersion.Halo3Retail)]
    [TagStructure(Size = 0xF10, Align = 0x1, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Size = 0xF88, Align = 0x1, MinVersion = CacheVersion.HaloReach)]
    public class BlfDataScenarioInsertion
    {
        public bool Visible;
        public BlfDataScenarioInsertionFlags Flags;

        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public short ZoneSetIndex;
        [TagField(Length = 0x2, MinVersion = CacheVersion.HaloReach)]
        public byte[] Padding1;

        [TagField(Length = 128, MinVersion = CacheVersion.HaloReach)]
        public string ZoneSetName;

        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        public int ReturnFromMapId; // mombasa streets
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        public int SurvivalPresenceContextId; // not entirely sure what this is, but it's used in rich presence

        [TagField(Length = 4, Flags = TagFieldFlags.Padding)]
        public byte[] Padding2;

        [TagField(Length = 0xC)]
        public NameUnicode32[] Names;

        [TagField(Length = 0xC)]
        public NameUnicode128[] Descriptions;

        public enum BlfDataScenarioInsertionFlags : byte
        {
            SurvivalBit = 1 << 0,
            SurvivalAlwaysUnlockedBit = 1 << 1,
            Bit2 = 1 << 2,
            ReturnFromMapBit = 1 << 3,
        }
    }

    enum BlfDataModPackageReferenceVersion : short
    {
        Version1 = 1,
        Current = 2
    }

    [TagStructure(Size = 0x44, Align = 0x1)]
    public class BlfDataModPackageReferenceV1 : BlfDataChunkHeader
    {
        [TagField(Length = 0x10, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        public string Name;
        [TagField(Length = 0x10)]
        public string Author;
        [TagField(Length = 0x14)]
        public byte[] Hash;
    }

    [TagStructure(Size = 0x484)]
    public class BlfDataModPackageReference : BlfDataChunkHeader
    {
        [TagField(Length = 0x14)]
        public byte[] Hash;

        public ModPackageMetadata Metadata;

        public BlfDataModPackageReference()
        {
            Signature = new Tag("modp");
            Length = (int)typeof(BlfDataModPackageReference).GetSize() - (int)typeof(BlfDataChunkHeader).GetSize();
            MajorVersion = (short)BlfDataModPackageReferenceVersion.Current;
            MinorVersion = 0;
        }

        public BlfDataModPackageReference(BlfDataModPackageReferenceV1 v1) : this()
        {
            Hash = v1.Hash;
            Metadata = new ModPackageMetadata
            {
                Name = v1.Name,
                Author = v1.Author
            };
        }
    }

    [TagStructure(Size = 0x130C, Align = 0x1)]
    public class BlfDataCampaign : BlfDataChunkHeader
    {
        public int CampaignId;
        public uint TypeFlags;

        [TagField(Length = 0xC)]
        public NameUnicode64[] Names;

        [TagField(Length = 0xC)]
        public NameUnicode128[] Descriptions;

        [TagField(Length = 0x40)]
        public int[] MapIds;

        [TagField(Length = 4, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;
    }

    [TagStructure(Size = 0xE094, Align = 0x1)]
    public class BlfDataMapVariant : BlfDataChunkHeader
    {
        public uint VariantVersion;
        public MapVariantData MapVariant;
    }

    [TagStructure(Size = 0x10000, Align = 0x1)]
    public class BlfDataMapVariantTagNames : BlfDataChunkHeader
    {
        [TagField(Length = 0x100)]
        public BlfTagName[] Names;
    }

    [TagStructure(Size = 0xFC, Align = 0x1)]
    public class BlfDataContentHeader : BlfDataChunkHeader
    {
        public ushort BuildVersion;
        public ushort MapMinorVersion;
        public BlfContentItemMetadata Metadata;
    }

    [TagStructure(Size = 0x8, Align = 0x1)]
    public class BlfDataMapImage : BlfDataChunkHeader
    {
        public BlfDataImageType Type;
        public int BufferSize;

        public enum BlfDataImageType : uint
        {
            JPG,
            PNG,
        }
    }

    [TagStructure(Size = 0x100, Align = 0x1)]
    public class BlfTagName
    {
        [TagField(Length = 0x100)]
        public string Name;
    }

    [TagStructure(Size = 0x264, Align = 0x1)]
    public class BlfDataGameVariant : BlfDataChunkHeader
    {
        public GameEngineType GameVariantType;
        [TagField(Length = 0x260)]
        public byte[] Data; // TODO implement all the structures for each variant and take the union
    }

    [TagStructure(Size = 0x40, Align = 0x1)]
    public class NameUnicode32
    {
        [TagField(CharSet = System.Runtime.InteropServices.CharSet.Unicode, Length = 0x20, DataAlign = 0x1)]
        public string Name;
    }

    [TagStructure(Size = 0x100, Align = 0x1)]
    public class NameUnicode128
    {
        [TagField(CharSet = System.Runtime.InteropServices.CharSet.Unicode, Length = 0x80, DataAlign = 0x1)]
        public string Name;
    }

    [TagStructure(Size = 0x80, Align = 0x1)]
    public class NameUnicode64
    {
        [TagField(CharSet = System.Runtime.InteropServices.CharSet.Unicode, Length = 0x40, DataAlign = 0x1)]
        public string Name;
    }

    [TagStructure(Size = 0x44, Align = 0x1)]
    public class BlfDataAuthor : BlfDataChunkHeader 
    {
        [TagField(Length = 16)]
        public string BuildName;
        public ulong BuildIdentifier;
        [TagField(Length = 28)]
        public string BuildString;
        [TagField(Length = 16)]
        public string AuthorName;
    }
}
