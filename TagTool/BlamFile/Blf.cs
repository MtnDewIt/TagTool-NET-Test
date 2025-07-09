using System;
using System.IO;
using TagTool.BlamFile.Chunks;
using TagTool.Cache;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

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
        public BlfSavedFilmData SavedFilmData;
        public BlfSavedFilmHeader SavedFilmHeader;
        public BlfScreenshotCamera ScreenshotCamera;
        public BlfScreenshotData ScreenshotData;
        public BlfServerSignature ServerSignature;
        public BlfFileshareMetadata FileshareMetadata;
        public byte[] Buffer;

        public Blf(CacheVersion version, CachePlatform cachePlatform)
        {
            Version = version;
            CachePlatform = cachePlatform;
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
            Author = 1 << 10,
            PackedMapVariant = 1 << 11,
            PackedGameVariant = 1 << 12,
            SavedFilmData = 1 << 13,
            SavedFilmHeader = 1 << 14,
            ScreenshotCamera = 1 << 15,
            ScreenshotData = 1 << 16,
            ServerSignature = 1 << 17,
            FileshareMetadata = 1 << 18,
        }

        // TODO: Verify All Read / Write methods for all chunks
        // TODO: Add Missing Chunks (Fileshare Metadata, Maybe Campaign Save Files??)
        // TODO: Clean up reach class structure
        // TODO: Add system for determing engine type from file data (WE MUST IGNORE THE CACHE CONTEXT)
        // TODO: Update definition versioning (Should stop all the damn warnings)
        // TODO: look into reach MCC support

        public bool Read(EndianReader reader)
        {
            if (!IsValid(reader))
                return false;

            GetFileVersion(reader, ref Version, ref CachePlatform);

            var deserializer = new TagDeserializer(Version, CachePlatform);

            while (!reader.EOF)
            {
                if (reader.Position == reader.Length || ContentFlags.HasFlag(BlfFileContentFlags.EndOfFile) && CachePlatform != CachePlatform.MCC)
                    return true;

                var dataContext = new DataSerializationContext(reader, useAlignment: false);
                var chunkHeaderPosition = reader.Position;

                var header = (BlfChunkHeader)deserializer.Deserialize(dataContext, typeof(BlfChunkHeader));
                reader.SeekTo(chunkHeaderPosition);

                switch (header.Signature.ToString())
                {
                    case "_blf":
                        ContentFlags |= BlfFileContentFlags.StartOfFile;
                        StartOfFile = BlfChunkStartOfFile.Decode(deserializer, dataContext);
                        break;

                    case "_eof":
                        ContentFlags |= BlfFileContentFlags.EndOfFile;
                        var position = reader.Position;
                        EndOfFile = BlfChunkEndOfFile.Decode(reader, deserializer, dataContext);
                        switch (EndOfFile.AuthenticationType) 
                        {
                            case BlfChunkEndOfFile.BlfAuthenticationType.None:
                                break;
                            case BlfChunkEndOfFile.BlfAuthenticationType.CRC:
                                reader.SeekTo(position);
                                EndOfFileCRC = BlfChunkEndOfFile.Decode(reader, deserializer, dataContext) as BlfEndOfFileCRC;
                                break;
                            case BlfChunkEndOfFile.BlfAuthenticationType.RSA:
                                reader.SeekTo(position);
                                EndOfFileRSA = BlfChunkEndOfFile.Decode(reader, deserializer, dataContext) as BlfEndOfFileRSA;
                                break;
                            case BlfChunkEndOfFile.BlfAuthenticationType.SHA1:
                                reader.SeekTo(position);
                                EndOfFileSHA1 = BlfChunkEndOfFile.Decode(reader, deserializer, dataContext) as BlfEndOfFileSHA1;
                                break;
                        }
                        break;

                    case "_cmp":
                        ContentFlags |= BlfFileContentFlags.MapVariant;
                        MapVariant = BlfChunkCompressedData.Decode(reader, deserializer, dataContext);
                        break;

                    case "_fsm":
                        ContentFlags |= BlfFileContentFlags.FileshareMetadata;
                        FileshareMetadata = BlfFileshareMetadata.Decode(deserializer, dataContext);
                        break;

                    case "cmpn":
                        ContentFlags |= BlfFileContentFlags.Campaign;
                        Campaign = BlfCampaign.Decode(deserializer, dataContext);
                        break;

                    case "levl":
                        ContentFlags |= BlfFileContentFlags.Scenario;
                        Scenario = BlfScenario.Decode(deserializer, dataContext);
                        break;

                    case "modp":
                        ContentFlags |= BlfFileContentFlags.ModReference;
                        ModReference = BlfModPackageReference.Decode(deserializer, dataContext);
                        break;

                    case "mapv":
                        ContentFlags |= BlfFileContentFlags.MapVariant;
                        MapVariant = BlfMapVariant.Decode(reader, deserializer, dataContext, false);
                        break;

                    case "mvar":
                        ContentFlags |= BlfFileContentFlags.PackedMapVariant;
                        MapVariant = BlfMapVariant.Decode(reader, deserializer, dataContext, true);
                        break;

                    case "tagn":
                        ContentFlags |= BlfFileContentFlags.MapVariantTagNames;
                        MapVariantTagNames = BlfMapVariantTagNames.Decode(deserializer, dataContext);
                        break;

                    case "mpvr":
                        ContentFlags |= BlfFileContentFlags.GameVariant;
                        GameVariant = BlfGameVariant.Decode(reader, deserializer, dataContext, false);
                        break;

                    case "gvar":
                        ContentFlags |= BlfFileContentFlags.PackedGameVariant;
                        GameVariant = BlfGameVariant.Decode(reader, deserializer, dataContext, true);
                        break;

                    case "chdr":
                        ContentFlags |= BlfFileContentFlags.ContentHeader;
                        ContentHeader = BlfContentHeader.Decode(reader, deserializer, dataContext);
                        break;

                    case "mapi":
                        ContentFlags |= BlfFileContentFlags.MapImage;
                        MapImage = BlfMapImage.Decode(reader, deserializer, dataContext, out Buffer);
                        break;

                    case "athr":
                        ContentFlags |= BlfFileContentFlags.Author;
                        Author = BlfAuthor.Decode(deserializer, dataContext);
                        break;

                    case "scnd":
                        ContentFlags |= BlfFileContentFlags.ScreenshotData;
                        ScreenshotData = BlfScreenshotData.Decode(reader, deserializer, dataContext, out Buffer);
                        break;

                    case "scnc":
                        ContentFlags |= BlfFileContentFlags.ScreenshotCamera;
                        ScreenshotCamera = BlfScreenshotCamera.Decode(deserializer, dataContext);
                        break;

                    case "flmh":
                        ContentFlags |= BlfFileContentFlags.SavedFilmHeader;
                        SavedFilmHeader = BlfSavedFilmHeader.Decode(reader, deserializer, dataContext);
                        break;

                    case "flmd":
                        ContentFlags |= BlfFileContentFlags.SavedFilmData;
                        SavedFilmData = BlfSavedFilmData.Decode(reader, deserializer, dataContext, out Buffer);
                        break;

                    case "ssig":
                        ContentFlags |= BlfFileContentFlags.ServerSignature;
                        ServerSignature = BlfServerSignature.Decode(deserializer, dataContext);
                        break;

                    case "mps2": // s_blf_chunk_multiplayer_player_vs_player_statistics
                    case "chrt": // s_blf_chunk_network_banhammer_cheating_report
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
            
            BlfChunkStartOfFile.Encode(serializer, dataContext, StartOfFile);

            if (ContentFlags.HasFlag(BlfFileContentFlags.Scenario))
                BlfScenario.Encode(serializer, dataContext, Scenario);

            if (ContentFlags.HasFlag(BlfFileContentFlags.ContentHeader))
                BlfContentHeader.Encode(writer, serializer, dataContext, ContentHeader);

            if (ContentFlags.HasFlag(BlfFileContentFlags.MapVariant))
                BlfMapVariant.Encode(writer, serializer, dataContext, MapVariant, false);

            if (ContentFlags.HasFlag(BlfFileContentFlags.PackedMapVariant))
                BlfMapVariant.Encode(writer, serializer, dataContext, MapVariant, true);

            if (ContentFlags.HasFlag(BlfFileContentFlags.GameVariant)) 
                BlfGameVariant.Encode(writer, serializer, dataContext, GameVariant, false);

            if (ContentFlags.HasFlag(BlfFileContentFlags.PackedGameVariant))
                BlfGameVariant.Encode(writer, serializer, dataContext, GameVariant, true);

            if (ContentFlags.HasFlag(BlfFileContentFlags.Campaign))
                BlfCampaign.Encode(serializer, dataContext, Campaign);

            if (ContentFlags.HasFlag(BlfFileContentFlags.ModReference))
                BlfModPackageReference.Encode(serializer, dataContext, ModReference);

            if (ContentFlags.HasFlag(BlfFileContentFlags.MapVariantTagNames))
                BlfMapVariantTagNames.Encode(serializer, dataContext, MapVariantTagNames);

            if (ContentFlags.HasFlag(BlfFileContentFlags.MapImage))
                BlfMapImage.Encode(writer, serializer, dataContext, MapImage, Buffer);

            if (ContentFlags.HasFlag(BlfFileContentFlags.Author))
                BlfAuthor.Encode(serializer, dataContext, Author);

            if (ContentFlags.HasFlag(BlfFileContentFlags.ScreenshotData))
                BlfScreenshotData.Encode(writer, serializer, dataContext, ScreenshotData, Buffer);

            if (ContentFlags.HasFlag(BlfFileContentFlags.ScreenshotCamera))
                BlfScreenshotCamera.Encode(serializer, dataContext, ScreenshotCamera);

            if (ContentFlags.HasFlag(BlfFileContentFlags.SavedFilmHeader))
                BlfSavedFilmHeader.Encode(serializer, dataContext, SavedFilmHeader);

            if (ContentFlags.HasFlag(BlfFileContentFlags.SavedFilmData))
                BlfSavedFilmData.Encode(writer, serializer, dataContext, SavedFilmData, Buffer);

            if (ContentFlags.HasFlag(BlfFileContentFlags.ServerSignature))
                BlfServerSignature.Encode(serializer, dataContext, ServerSignature);

            if (ContentFlags.HasFlag(BlfFileContentFlags.FileshareMetadata))
                BlfFileshareMetadata.Encode(serializer, dataContext, FileshareMetadata);

            switch (EndOfFile.AuthenticationType) 
            {
                case BlfChunkEndOfFile.BlfAuthenticationType.None:
                    BlfChunkEndOfFile.Encode(serializer, dataContext, EndOfFile);
                    break;
                case BlfChunkEndOfFile.BlfAuthenticationType.CRC:
                    BlfChunkEndOfFile.Encode(serializer, dataContext, EndOfFileCRC);
                    break;
                case BlfChunkEndOfFile.BlfAuthenticationType.RSA:
                    BlfChunkEndOfFile.Encode(serializer, dataContext, EndOfFileRSA);
                    break;
                case BlfChunkEndOfFile.BlfAuthenticationType.SHA1:
                    BlfChunkEndOfFile.Encode(serializer, dataContext, EndOfFileSHA1);
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

        private static void GetFileVersion(EndianReader reader, ref CacheVersion version, ref CachePlatform platform) 
        {
            var startOfFile = reader.Position;

            reader.SeekTo(0xE);
            var name = reader.ReadString(0x20);

            reader.SeekTo(0x30);
            var signature = reader.ReadTag();

            if (name == "map variant" || name == "game var" || signature == "athr")
            {
                reader.SeekTo(0x80);
                var mccSignature = reader.ReadTag();

                if (mccSignature == "mvar" || mccSignature == "gvar") 
                {
                    version = CacheVersion.Halo3Retail;
                    platform = CachePlatform.MCC;
                    reader.SeekTo(startOfFile);
                    return;
                }
            }
            else if (signature == "chdr")
            {
                reader.SeekTo(0x2F0);
                var reachSignature = reader.ReadTag();

                if (reachSignature == "mvar" || reachSignature == "mpvr" || reachSignature == "scnc" || reachSignature == "athr") 
                {
                    reader.SeekTo(0x3C);
                    var buildVersion = reader.ReadInt16();

                    if (buildVersion == 0x2E54 || buildVersion == 0x2F21)
                    {
                        version = CacheVersion.HaloReach;
                        platform = CachePlatform.Original;
                        reader.SeekTo(startOfFile);
                        return;
                    }
                    else if (buildVersion == 0x514A) 
                    {
                        version = CacheVersion.Halo4;
                        platform = CachePlatform.Original;
                        reader.SeekTo(startOfFile);
                        return;
                    }
                    else if (buildVersion == -1)
                    {
                        reader.SeekTo(0x2F8);
                        var majorVersion = reader.ReadInt16();

                        if (majorVersion == 0x3)
                        {
                            reader.SeekTo(0x348);
                            majorVersion = reader.ReadInt16();

                            switch (majorVersion)
                            {
                                case 0x360E:
                                    version = CacheVersion.HaloReach;
                                    platform = CachePlatform.MCC;
                                    reader.SeekTo(startOfFile);
                                    return;
                                case 0x4C8F:
                                    version = CacheVersion.Halo4;
                                    platform = CachePlatform.MCC;
                                    reader.SeekTo(startOfFile);
                                    return;
                                case 0x5530:
                                    version = CacheVersion.Halo2AMP;
                                    platform = CachePlatform.MCC;
                                    reader.SeekTo(startOfFile);
                                    return;
                            }
                        }
                        else
                        {
                            switch (majorVersion)
                            {
                                case 0x36:
                                case 0x1F:
                                    version = CacheVersion.HaloReach;
                                    platform = CachePlatform.MCC;
                                    reader.SeekTo(startOfFile);
                                    return;
                                case 0x84:
                                case 0x32:
                                    version = CacheVersion.Halo4;
                                    platform = CachePlatform.MCC;
                                    reader.SeekTo(startOfFile);
                                    return;
                                case 0x89:
                                case 0x34:
                                    version = CacheVersion.Halo2AMP;
                                    platform = CachePlatform.MCC;
                                    reader.SeekTo(startOfFile);
                                    return;
                            }
                        }
                    }
                }

                reader.SeekTo(0x138);
                var h3Signature = reader.ReadTag();

                if (h3Signature == "mapv" || h3Signature == "mpvr" || h3Signature == "scnc" || h3Signature == "athr")
                {
                    reader.SeekTo(0x3A);
                    var contentMinorVersion = reader.ReadInt16();

                    if (contentMinorVersion == 0x3)
                    {
                        reader.SeekTo(0x3C);
                        var buildVersion = reader.ReadInt16();

                        if (buildVersion == -24364)
                        {
                            version = CacheVersion.HaloOnlineED;
                            platform = CachePlatform.Original;
                            reader.SeekTo(startOfFile);
                            return;
                        }
                        else if (buildVersion == 0x3647) 
                        {
                            if (h3Signature == "athr")
                            {
                                reader.SeekTo(0x198);
                                var buildName = reader.ReadString(0x20);

                                if (buildName == "13895.09.04.27.2201.atlas_relea")
                                {
                                    version = CacheVersion.Halo3ODST;
                                    platform = CachePlatform.Original;
                                    reader.SeekTo(startOfFile);
                                    return;
                                }
                                else if (buildName == "untracked version")
                                {
                                    version = CacheVersion.Halo3ODST;
                                    platform = CachePlatform.MCC;
                                    reader.SeekTo(startOfFile);
                                    return;
                                }
                            }
                            else if (h3Signature == "mapv" || h3Signature == "mpvr" || h3Signature == "scnc") 
                            {
                                version = CacheVersion.Halo3ODST;
                                platform = CachePlatform.Original;
                                reader.SeekTo(startOfFile);
                                return;
                            }
                        }
                    }
                    else if (contentMinorVersion == 0x2)
                    {
                        if (h3Signature == "athr")
                        {
                            reader.SeekTo(0x198);
                            var buildName = reader.ReadString(0x20);

                            if (buildName == "12070.08.09.05.2031.halo3_ship")
                            {
                                version = CacheVersion.Halo3Retail;
                                platform = CachePlatform.Original;
                                reader.SeekTo(startOfFile);
                                return;
                            }
                            else if (buildName == "untracked version") 
                            {
                                version = CacheVersion.Halo3Retail;
                                platform = CachePlatform.MCC;
                                reader.SeekTo(startOfFile);
                                return;
                            }
                        }
                        else if (h3Signature == "mapv" || h3Signature == "mpvr" || h3Signature == "scnc") 
                        {
                            version = CacheVersion.Halo3Retail;
                            platform = CachePlatform.Original;
                            reader.SeekTo(startOfFile);
                            return;
                        }
                    }
                }
            }
            else if (signature == "mapi")
            {
                version = CacheVersion.Halo3Retail;
                platform = CachePlatform.Original;
                reader.SeekTo(startOfFile);
                return;
            }
            else if (signature == "cmpn")
            {
                reader.SeekTo(0x38);
                var campaignMajorVersion = reader.ReadInt16();

                if (campaignMajorVersion == 0x3)
                {
                    version = CacheVersion.Halo4;
                    platform = CachePlatform.Original;
                    reader.SeekTo(startOfFile);
                    return;
                }
                else if (campaignMajorVersion == 0x1) 
                {
                    version = CacheVersion.Halo3Retail;
                    platform = CachePlatform.Original;
                    reader.SeekTo(startOfFile);
                    return;
                }
            }
            else if (signature == "levl") 
            {
                switch (reader.Length)
                {
                    case 0x4E91:
                        version = CacheVersion.Halo3Retail;
                        platform = CachePlatform.Original;
                        reader.SeekTo(startOfFile);
                        return;
                    case 0x9A01:
                        version = CacheVersion.Halo3ODST;
                        platform = CachePlatform.Original;
                        reader.SeekTo(startOfFile);
                        return;
                    case 0xCDD9:
                        version = CacheVersion.HaloReach;
                        platform = CachePlatform.Original;
                        reader.SeekTo(startOfFile);
                        return;
                    case 0x11F19:
                        version = CacheVersion.Halo4;
                        platform = CachePlatform.Original;
                        reader.SeekTo(startOfFile);
                        return;
                }
            }

            reader.SeekTo(startOfFile);
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

            var insertions = new BlfScenario.BlfScenarioInsertion[9];
            for(int i = 0; i < 9; i++)
            {
                BlfScenario.BlfScenarioInsertion ins;
                if( i < 4)
                    ins = Scenario.Insertions[i];
                else
                {
                    ins = new BlfScenario.BlfScenarioInsertion();
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

            var insertions = new BlfScenario.BlfScenarioInsertion[9];

            for (int i = 0; i < 9; i++)
            {
                BlfScenario.BlfScenarioInsertion ins;
                if (i < 9)
                    ins = Scenario.Insertions[i];
                else
                    ins = new BlfScenario.BlfScenarioInsertion();

                insertions[i] = ins;
            }

            if(Scenario.MapFlags.HasFlag(BlfScenario.BlfScenarioFlags.IsMultiplayer))
            {
                Scenario.GameEngineTeamCounts = new BlfScenario.GameEngineTeams
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
}
