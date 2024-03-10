using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.IO;
using TagTool.Common;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Maps
{
    public class campaign : MapVariantFile
    {
        public campaign(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
        (
            cache,
            cacheContext,
            stream
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
            MapVariantData();
        }

        public override void MapVariantData()
        {
            BlfData blfData = new BlfData(Cache.Version, CachePlatform.Original)
            {
                Version = CacheVersion.HaloOnlineED,
                CachePlatform = CachePlatform.Original,
                Format = EndianFormat.BigEndian,
                ContentFlags = BlfDataFileContentFlags.StartOfFile | BlfDataFileContentFlags.EndOfFile | BlfDataFileContentFlags.Campaign,
                AuthenticationType = BlfDataAuthenticationType.AuthenticationTypeRSA,
                StartOfFile = new BlfDataChunkStartOfFile
                {
                    ByteOrderMarker = -2,
                    InternalName = $@"",
                    Signature = new Tag("_blf"),
                    Length = 48,
                    MajorVersion = 1,
                    MinorVersion = 2,
                },
                EndOfFileCRC = null,
                EndOfFileRSA = new BlfDataEndOfFileRSA
                {
                    RSASignature = new RSASignature
                    {
                        Data = new byte[256]
                        {
                            0xE6, 0xA4, 0xC6, 0x96, 0xA3, 0xED, 0x05, 0x03, 0x4D, 0xE6, 0xC4, 0xB2, 0x6E, 0x9C, 0x39, 0xDE, 0xF9, 0x57, 0xD4, 0xCC,
                            0xA1, 0x3D, 0x8E, 0xC9, 0xB9, 0x1D, 0x7F, 0xE6, 0x27, 0xF3, 0xD3, 0x43, 0x39, 0x68, 0xFD, 0x6D, 0x41, 0x57, 0x8E, 0xE9,
                            0x86, 0x65, 0xD6, 0x04, 0xD9, 0x84, 0xB9, 0x02, 0x3B, 0xB6, 0x5E, 0xBC, 0x7F, 0x6B, 0x0E, 0x3B, 0x7F, 0x8F, 0xC9, 0xA2,
                            0x8B, 0xEC, 0xFD, 0x95, 0xDC, 0xD5, 0x5B, 0x3C, 0xFF, 0x2E, 0x8E, 0xBF, 0x62, 0x5F, 0x76, 0x25, 0x17, 0xB1, 0xD1, 0xBA,
                            0x47, 0x2B, 0xE6, 0x03, 0xF5, 0xB7, 0x9E, 0x78, 0x8C, 0xDC, 0x20, 0x74, 0xC7, 0xCF, 0x07, 0x23, 0x4F, 0x88, 0xE5, 0x8A,
                            0x48, 0xDC, 0x8F, 0xB6, 0xE4, 0x18, 0x3E, 0x01, 0x31, 0x8B, 0xBB, 0xC5, 0xEA, 0x5D, 0x78, 0xA3, 0xCD, 0x4A, 0x64, 0xA3,
                            0xDA, 0xF6, 0xE2, 0x28, 0xE8, 0x14, 0x29, 0x0B, 0x15, 0x51, 0xC0, 0xDC, 0x0D, 0x25, 0x53, 0xD5, 0x02, 0xE3, 0xF9, 0x71,
                            0xEF, 0xBB, 0x3F, 0xB4, 0x85, 0x2E, 0xB5, 0x5D, 0x1A, 0x8E, 0xE1, 0x77, 0xFA, 0xC9, 0xB2, 0xE0, 0x27, 0xD8, 0x58, 0x17,
                            0x23, 0x89, 0x6D, 0x4F, 0x4D, 0xBF, 0x1C, 0x4D, 0x37, 0x85, 0xBA, 0x93, 0xAB, 0x2C, 0xCF, 0x87, 0x14, 0x8D, 0xCE, 0x66,
                            0x83, 0x1D, 0x5B, 0x22, 0xB7, 0x7E, 0x8A, 0xBD, 0x77, 0xF1, 0xED, 0xEB, 0xC5, 0x20, 0x92, 0xAE, 0xF5, 0xD1, 0xBD, 0xEF,
                            0xD1, 0x0F, 0xC3, 0x85, 0x0E, 0xB1, 0x12, 0xAF, 0x68, 0x17, 0x4D, 0x69, 0xD5, 0xB7, 0xFD, 0x2D, 0xEB, 0xF6, 0x7E, 0x9E,
                            0xAB, 0x25, 0x89, 0x77, 0x14, 0x96, 0x62, 0xBF, 0x92, 0xAC, 0xC5, 0x60, 0xD7, 0x7A, 0x67, 0xD2, 0x7A, 0x11, 0x56, 0xA7,
                            0xDE, 0x73, 0x74, 0x55, 0xC6, 0xBD, 0xF4, 0x0B, 0xCF, 0x21, 0xEB, 0x41, 0xF9, 0xAD, 0x39, 0x60,
                        },
                    },
                    AuthenticationDataSize = 4936,
                    AuthenticationType = BlfDataAuthenticationType.AuthenticationTypeRSA,
                    Signature = new Tag("_eof"),
                    Length = 273,
                    MajorVersion = 1,
                    MinorVersion = 1,
                },
                EndOfFileSHA1 = null,
                EndOfFile = new BlfDataChunkEndOfFile
                {
                    AuthenticationDataSize = 4936,
                    AuthenticationType = BlfDataAuthenticationType.AuthenticationTypeRSA,
                    Signature = new Tag("_eof"),
                    Length = 273,
                    MajorVersion = 1,
                    MinorVersion = 1,
                },
                Author = null,
                Campaign = new BlfDataCampaign
                {
                    CampaignId = 1,
                    Type = 0,
                    Names = new NameUnicode64[12]
                    {
                        new NameUnicode64
                        {
                            Name = $@"Halo 3",
                        },
                        new NameUnicode64
                        {
                        },
                        new NameUnicode64
                        {
                        },
                        new NameUnicode64
                        {
                        },
                        new NameUnicode64
                        {
                        },
                        new NameUnicode64
                        {
                        },
                        new NameUnicode64
                        {
                        },
                        new NameUnicode64
                        {
                        },
                        new NameUnicode64
                        {
                        },
                        new NameUnicode64
                        {
                        },
                        new NameUnicode64
                        {
                        },
                        new NameUnicode64
                        {
                        },
                    },
                    Descriptions = new NameUnicode128[12]
                    {
                        new NameUnicode128
                        {
                            Name = $@"Finish the Fight!",
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                    },
                    MapIds = new int[64]
                    {
                        3005, 3010, 3020, 3030, 3040, 3050, 3070, 3100, 3110, 3120,
                        3130, 4100, 4200, 6100, 6110, 6120, 6130, 6140, 6150, 5200,
                        5300, 5000, 0, 0, 0, 0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                        0, 0, 0, 0,
                    },
                    Signature = new Tag("cmpn"),
                    Length = 4888,
                    MajorVersion = 1,
                    MinorVersion = 1,
                },
                Scenario = null,
                ModReference = null,
                MapVariantTagNames = null,
                MapVariant = null,
                GameVariant = null,
                ContentHeader = null,
                MapImage = null,
                Buffer = null,
            };

            GenerateCampaignFile(blfData);
        }
    }
}