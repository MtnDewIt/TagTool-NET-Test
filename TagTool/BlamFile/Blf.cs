﻿using System;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;
using TagTool.Tags.Definitions.Common;

namespace TagTool.BlamFile
{
    /// <summary>
    /// Main class for blf format. Reads, parse and writes blf.
    /// </summary>
    public class Blf
    {
        public CacheVersion Version;
        public CachePlatform CachePlatform;
        public EndianFormat Format;

        public BlfFileContentFlags ContentFlags;
        public BlfAuthenticationType AuthenticationType;

        public BlfChunkStartOfFile StartOfFile;
        public BlfEndOfFileCRC EndOfFileCRC;
        public BlfEndOfFileRSA EndOfFileRSA;
        public BlfEndOfFileSHA1 EndOfFileSHA1;
        public BlfChunkEndOfFile EndOfFile;
        public BlfAuthor Author;
        public BlfCampaign Campaign;
        public BlfScenario Scenario;
        public BlfModPackageReference ModReference;
        public BlfMapVariantTagNames MapVariantTagNames;
        public BlfMapVariant MapVariant;
        public BlfGameVariant GameVariant;
        public BlfContentHeader ContentHeader;
        public BlfMapImage MapImage;
        public byte[] Buffer;

        public Blf(CacheVersion version, CachePlatform cachePlatform)
        {
            Version = version;
            CachePlatform = cachePlatform;
        }

        public bool Read(EndianReader reader)
        {
            if (!IsValid(reader))
                return false;

            var deserializer = new TagDeserializer(Version, CachePlatform);

            while (!reader.EOF)
            {
                var dataContext = new DataSerializationContext(reader, useAlignment: false);
                var chunkHeaderPosition = reader.Position;

                var header = (BlfChunkHeader)deserializer.Deserialize(dataContext, typeof(BlfChunkHeader));
                reader.SeekTo(chunkHeaderPosition);

                switch (header.Signature.ToString())
                {
                    case "_blf":
                        ContentFlags |= BlfFileContentFlags.StartOfFile;
                        StartOfFile = (BlfChunkStartOfFile)deserializer.Deserialize(dataContext, typeof(BlfChunkStartOfFile));
                        break;

                    case "_eof":
                        ContentFlags |= BlfFileContentFlags.EndOfFile;
                        var position = reader.Position;
                        EndOfFile = (BlfChunkEndOfFile)deserializer.Deserialize(dataContext, typeof(BlfChunkEndOfFile));
                        AuthenticationType = EndOfFile.AuthenticationType;
                        switch (AuthenticationType)
                        {
                            case BlfAuthenticationType.None:
                                break;
                            case BlfAuthenticationType.CRC:
                                reader.SeekTo(position);
                                EndOfFileCRC = (BlfEndOfFileCRC)deserializer.Deserialize(dataContext, typeof(BlfEndOfFileCRC));
                                break;
                            case BlfAuthenticationType.RSA:
                                reader.SeekTo(position);
                                EndOfFileRSA = (BlfEndOfFileRSA)deserializer.Deserialize(dataContext, typeof(BlfEndOfFileRSA));
                                break;
                            case BlfAuthenticationType.SHA1:
                                reader.SeekTo(position);
                                EndOfFileSHA1 = (BlfEndOfFileSHA1)deserializer.Deserialize(dataContext, typeof(BlfEndOfFileSHA1));
                                break;
                        }
                        return true;

                    case "cmpn":
                        ContentFlags |= BlfFileContentFlags.Campaign;
                        Campaign = (BlfCampaign)deserializer.Deserialize(dataContext, typeof(BlfCampaign));
                        break;

                    case "levl":
                        ContentFlags |= BlfFileContentFlags.Scenario;
                        Scenario = (BlfScenario)deserializer.Deserialize(dataContext, typeof(BlfScenario));
                        break;

                    case "modp":
                        ContentFlags |= BlfFileContentFlags.ModReference;
                        if(header.MajorVersion == (short)BlfModPackageReferenceVersion.Version1)
                        {
                            var v1 = (BlfModPackageReferenceV1)deserializer.Deserialize(dataContext, typeof(BlfModPackageReferenceV1));
                            ModReference = new BlfModPackageReference(v1); // Convert to the new format
                        }
                        else
                        {
                            ModReference = (BlfModPackageReference)deserializer.Deserialize(dataContext, typeof(BlfModPackageReference));
                        }
                        break;

                    case "mapv":
                        ContentFlags |= BlfFileContentFlags.MapVariant;
                        MapVariant = (BlfMapVariant)deserializer.Deserialize(dataContext, typeof(BlfMapVariant));
                        break;
                    case "tagn":
                        ContentFlags |= BlfFileContentFlags.MapVariantTagNames;
                        MapVariantTagNames = (BlfMapVariantTagNames)deserializer.Deserialize(dataContext, typeof(BlfMapVariantTagNames));
                        break;


                    case "mpvr":
                        ContentFlags |= BlfFileContentFlags.GameVariant;
                        GameVariant = (BlfGameVariant)deserializer.Deserialize(dataContext, typeof(BlfGameVariant));
                        break;

                    case "chdr":
                        ContentFlags |= BlfFileContentFlags.ContentHeader;
                        ContentHeader = (BlfContentHeader)deserializer.Deserialize(dataContext, typeof(BlfContentHeader));
                        break;

                    case "mapi":
                        ContentFlags |= BlfFileContentFlags.MapImage;
                        MapImage = (BlfMapImage)deserializer.Deserialize(dataContext, typeof(BlfMapImage));
                        Buffer = reader.ReadBytes(MapImage.BufferSize);
                        break;

                    case "scnd":
                    case "scnc":
                    case "flmh":
                    case "flmd":
                    case "athr":
                        Author = deserializer.Deserialize<BlfAuthor>(dataContext);
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

        public bool Write(EndianWriter writer)
        {
            if (!ContentFlags.HasFlag(BlfFileContentFlags.StartOfFile) || !ContentFlags.HasFlag(BlfFileContentFlags.EndOfFile))
                return false;

            TagSerializer serializer = new TagSerializer(Version, CachePlatform, Format);
            writer.Format = Format;
            var dataContext = new DataSerializationContext(writer, useAlignment: false);
            
            serializer.Serialize(dataContext, StartOfFile);

            if(ContentFlags.HasFlag(BlfFileContentFlags.Scenario))
                serializer.Serialize(dataContext, Scenario);

            if (ContentFlags.HasFlag(BlfFileContentFlags.ContentHeader))
                serializer.Serialize(dataContext, ContentHeader);

            if(ContentFlags.HasFlag(BlfFileContentFlags.MapVariant))
                serializer.Serialize(dataContext, MapVariant);

            if (ContentFlags.HasFlag(BlfFileContentFlags.GameVariant))
                serializer.Serialize(dataContext, GameVariant);

            if (ContentFlags.HasFlag(BlfFileContentFlags.Campaign))
                serializer.Serialize(dataContext, Campaign);

            if (ContentFlags.HasFlag(BlfFileContentFlags.ModReference))
                serializer.Serialize(dataContext, ModReference);

            if (ContentFlags.HasFlag(BlfFileContentFlags.MapVariantTagNames))
                serializer.Serialize(dataContext, MapVariantTagNames);

            if (ContentFlags.HasFlag(BlfFileContentFlags.MapImage))
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
                case BlfAuthenticationType.None:
                    serializer.Serialize(dataContext, EndOfFile);
                    break;
                case BlfAuthenticationType.CRC:
                    serializer.Serialize(dataContext, EndOfFileCRC);
                    break;
                case BlfAuthenticationType.RSA:
                    serializer.Serialize(dataContext, EndOfFileRSA);
                    break;
                case BlfAuthenticationType.SHA1:
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
        private bool IsValid(EndianReader reader)
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

            var header = (BlfChunkHeader)deserializer.Deserialize(dataContext, typeof(BlfChunkHeader));
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
            var chunkHeaderSize = (int)TagStructure.GetTagStructureInfo(typeof(BlfChunkHeader), Version, CachePlatform).TotalSize;
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
            if (!ContentFlags.HasFlag(BlfFileContentFlags.Scenario))
                return;

            var insertions = new BlfScenarioInsertion[9];
            for(int i = 0; i < 9; i++)
            {
                BlfScenarioInsertion ins;
                if( i < 4)
                    ins = Scenario.Insertions[i];
                else
                {
                    ins = new BlfScenarioInsertion();
                }
                insertions[i] = ins;
            }
            Scenario.Insertions = insertions;
            Scenario.Length = 0x98C0;
        }

        private void ConvertReachToODSTScenarioChunk()
        {
            if (!ContentFlags.HasFlag(BlfFileContentFlags.Scenario))
                return;

            var insertions = new BlfScenarioInsertion[9];

            for (int i = 0; i < 9; i++)
            {
                BlfScenarioInsertion ins;
                if (i < 9)
                    ins = Scenario.Insertions[i];
                else
                    ins = new BlfScenarioInsertion();

                insertions[i] = ins;
            }

            if(Scenario.MapFlags.HasFlag(BlfScenarioFlags.IsMultiplayer))
            {
                Scenario.GameEngineTeamCounts = new GameEngineTeams
                {
                    NoGametypeTeamCount = 8,
                    CtfTeamCount = 8,
                    SlayerTeamCount = 8,
                    OddballTeamCount = 8,
                    KingTeamCount = 8,
                    SandboxTeamCount = 8,
                    VipTeamCount = 8,
                    JuggernautTeamCount = 8,
                    TerritoriesTeamCount = 8,
                    AssaultTeamCount = 8,
                    InfectionTeamCount = 8,
                };
            }

            Scenario.Insertions = insertions;
            Scenario.Length = 0x98C0;
            Scenario.MajorVersion = 3;
            Scenario.MinorVersion = 1;
        }
    }

    [Flags]
    public enum BlfFileContentFlags : uint
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
    public enum BlfScenarioFlags : uint
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

    public enum BlfAuthenticationType : byte
    {
        None,
        CRC,
        SHA1,
        RSA
    }

    [TagStructure(Size = 0xC, Align = 0x1)]
    public class BlfChunkHeader : TagStructure
    {
        public Tag Signature;
        public int Length;
        public short MajorVersion;
        public short MinorVersion;
    }

    [TagStructure(Size = 0x24, Align = 0x1)]
    public class BlfChunkStartOfFile : BlfChunkHeader
    {
        // when -2, order is little endian, else order is big endian. Check byteswapepd BOM to be -2 otherwise invalid.
        public short ByteOrderMarker;

        [TagField(Length = 0x20)]
        public string InternalName;
        
        [TagField(Length = 2, Flags = TagFieldFlags.Padding)]
        public byte[] Padding;
    }

    [TagStructure(Size = 0x5, Align = 0x1)]
    public class BlfChunkEndOfFile : BlfChunkHeader
    {
        public int AuthenticationDataSize;
        public BlfAuthenticationType AuthenticationType;
    }

    [TagStructure(Size = 0x4, Align = 0x1)]
    public class BlfEndOfFileCRC : BlfChunkEndOfFile
    {
        public BlfCRCChecksum Checksum;

        [TagStructure(Size = 0x4, Align = 0x1)]
        public class BlfCRCChecksum
        {
            public uint Checksum;
        }
    }

    [TagStructure(Size = 0x100, Align = 0x1)]
    public class BlfEndOfFileSHA1 : BlfChunkEndOfFile
    {
        public BlfSHA1Hash Hash;

        [TagStructure(Size = 0x100, Align = 0x1)]
        public class BlfSHA1Hash
        {
            [TagField(Length = 0x100)]
            public byte[] Hash;
        }
    }

    [TagStructure(Size = 0x100, Align = 0x1)]
    public class BlfEndOfFileRSA : BlfChunkEndOfFile
    {
        public RSASignature RSASignature;
    }

    [TagStructure(Size = 0x4D44, Align = 0x1, MaxVersion = CacheVersion.Halo3Retail)]
    [TagStructure(Size = 0x98B4, Align = 0x1, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Size = 0xCC8C, Align = 0x1, MinVersion = CacheVersion.HaloReach)]
    public class BlfScenario : BlfChunkHeader
    {
        public int MapId;
        public BlfScenarioFlags MapFlags;

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

        public GameEngineTeams GameEngineTeamCounts;

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
        public BlfScenarioInsertion[] Insertions;

        [TagField(Length = 0x10, MinVersion = CacheVersion.HaloReach)]
        public string DefaultAuthor;
    }

    [TagStructure(Size = 0xB, Align = 0x1)]
    public class GameEngineTeams : TagStructure 
    {
        public byte NoGametypeTeamCount;
        public byte CtfTeamCount;
        public byte SlayerTeamCount;
        public byte OddballTeamCount;
        public byte KingTeamCount;
        public byte SandboxTeamCount;
        public byte VipTeamCount;
        public byte JuggernautTeamCount;
        public byte TerritoriesTeamCount;
        public byte AssaultTeamCount;
        public byte InfectionTeamCount;
    }

    [TagStructure(Size = 0xF08, Align = 0x1, MaxVersion = CacheVersion.Halo3Retail)]
    [TagStructure(Size = 0xF10, Align = 0x1, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Size = 0xF88, Align = 0x1, MinVersion = CacheVersion.HaloReach)]
    public class BlfScenarioInsertion : TagStructure
    {
        public bool Visible;
        public BlfScenarioInsertionFlags Flags;

        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public short ZoneSetIndex;
        [TagField(Length = 0x2, MinVersion = CacheVersion.HaloReach)]
        public byte[] Padding1;

        [TagField(Length = 128, MinVersion = CacheVersion.HaloReach)]
        public string ZoneSetName;

        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        public int ReturnFromMapId;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        public int SurvivalPresenceContextId;

        [TagField(Length = 4, Flags = TagFieldFlags.Padding)]
        public byte[] Padding2;

        [TagField(Length = 0xC)]
        public NameUnicode32[] Names;

        [TagField(Length = 0xC)]
        public NameUnicode128[] Descriptions;

        [Flags]
        public enum BlfScenarioInsertionFlags : byte
        {
            None = 0,
            SurvivalBit = 1 << 0,
            SurvivalAlwaysUnlockedBit = 1 << 1,
            Bit2 = 1 << 2,
            ReturnFromMapBit = 1 << 3,
        }
    }

    enum BlfModPackageReferenceVersion : short
    {
        Version1 = 1,
        Current = 2
    }

    [TagStructure(Size = 0x44, Align = 0x1)]
    public class BlfModPackageReferenceV1 : BlfChunkHeader
    {
        [TagField(Length = 0x10, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        public string Name;
        [TagField(Length = 0x10)]
        public string Author;
        [TagField(Length = 0x14)]
        public byte[] Hash;
    }

    [TagStructure(Size = 0x484, Align = 0x1)]
    public class BlfModPackageReference : BlfChunkHeader
    {
        [TagField(Length = 0x14)]
        public byte[] Hash;

        public ModPackageMetadata Metadata;

        public BlfModPackageReference()
        {
            Signature = new Tag("modp");
            Length = (int)typeof(BlfModPackageReference).GetSize() - (int)typeof(BlfChunkHeader).GetSize();
            MajorVersion = (short)BlfModPackageReferenceVersion.Current;
            MinorVersion = 0;
        }

        public BlfModPackageReference(BlfModPackageReferenceV1 v1) : this()
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
    public class BlfCampaign : BlfChunkHeader
    {
        public int CampaignId;
        public uint TypeFlags;

        [TagField(Length = 0xC)]
        public CampaignNameUnicode32[] Names;

        [TagField(Length = 0xC)]
        public NameUnicode128[] Descriptions;

        [TagField(Length = 0x40)]
        public int[] MapIds;

        [TagField(Length = 4, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;
    }

    [TagStructure(Size = 0xE094, Align = 0x1)]
    public class BlfMapVariant : BlfChunkHeader
    {
        public uint VariantVersion;
        public MapVariant MapVariant;
    }

    [TagStructure(Size = 0x10000, Align = 0x1)]
    public class BlfMapVariantTagNames : BlfChunkHeader
    {
        [TagField(Length = 0x100)]
        public TagName[] Names;
    }

    [TagStructure(Size = 0xFC, Align = 0x1)]
    public class BlfContentHeader : BlfChunkHeader
    {
        public ushort BuildVersion;
        public ushort MapMinorVersion;
        public ContentItemMetadata Metadata;
    }

    [TagStructure(Size = 0x8, Align = 0x1)]
    public class BlfMapImage : BlfChunkHeader
    {
        public BlfImageType Type;
        public int BufferSize;

        public enum BlfImageType : uint
        {
            JPG,
            PNG,
        }
    }

    [TagStructure(Size = 0x100, Align = 0x1)]
    public class TagName : TagStructure
    {
        [TagField(Length = 0x100)]
        public string Name;
    }

    [TagStructure(Size = 0x264, Align = 0x1)]
    public class BlfGameVariant : BlfChunkHeader
    {
        public GameEngineType GameVariantType;

        [TagField(Length = 0x260)]
        public byte[] Variant;
    }

    [TagStructure(Size = 0x40, Align = 0x1)]
    public class NameUnicode32 : TagStructure
    {
        [TagField(CharSet = System.Runtime.InteropServices.CharSet.Unicode, Length = 0x20, DataAlign = 0x1)]
        public string Name;
    }

    [TagStructure(Size = 0x100, Align = 0x1)]
    public class NameUnicode128 : TagStructure
    {
        [TagField(CharSet = System.Runtime.InteropServices.CharSet.Unicode, Length = 0x80, DataAlign = 0x1)]
        public string Name;
    }

    [TagStructure(Size = 0x80, Align = 0x1)]
    public class CampaignNameUnicode32 : TagStructure
    {
        [TagField(CharSet = System.Runtime.InteropServices.CharSet.Unicode, Length = 0x40, DataAlign = 0x1)]
        public string Name;
    }

    [TagStructure(Size = 0x44, Align = 0x1)]
    public class BlfAuthor : BlfChunkHeader
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
