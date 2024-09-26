using TagTool.Cache;
using TagTool.IO;
using TagTool.Tags;

namespace TagTool.BlamFile.HaloOnline
{
    [TagStructure(Size = 0x14779, MaxVersion = CacheVersion.Halo3Retail)]
    [TagStructure(Size = 0x192E9, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0x29785, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnlineED)]
    [TagStructure(Size = 0x19779, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Size = 0x1C6C1, MinVersion = CacheVersion.HaloReach)]
    public class HaloOnlineBlf : TagStructure 
    {
        public EndianFormat Format;
        public BlfFileContentFlags ContentFlags;
        public BlfAuthenticationType AuthenticationType;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloReach)]
        public BlfChunkStartOfFile StartOfFile;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloReach)]
        public BlfEndOfFileCRC EndOfFileCRC;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloReach)]
        public BlfEndOfFileRSA EndOfFileRSA;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloReach)]
        public BlfEndOfFileSHA1 EndOfFileSHA1;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloReach)]
        public BlfChunkEndOfFile EndOfFile;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloReach)]
        public BlfAuthor Author;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloReach)]
        public BlfCampaign Campaign;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloReach)]
        public BlfScenario Scenario;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnlineED)]
        public BlfModPackageReference ModReference;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnlineED)]
        public BlfMapVariantTagNames MapVariantTagNames;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloReach)]
        public BlfMapVariant MapVariant;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloReach)]
        public BlfGameVariant GameVariant;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloReach)]
        public BlfContentHeader ContentHeader;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloReach)]
        public BlfMapImage MapImage;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloReach)]
        public byte[] Buffer;

        public HaloOnlineBlf(Blf blfData) 
        {
            Format = blfData.Format;
            ContentFlags = blfData.ContentFlags;
            AuthenticationType = blfData.AuthenticationType;

            StartOfFile = blfData.StartOfFile;
            EndOfFileCRC = blfData.EndOfFileCRC;
            EndOfFileRSA = blfData.EndOfFileRSA;
            EndOfFileSHA1 = blfData.EndOfFileSHA1;
            EndOfFile = blfData.EndOfFile;
            Author = blfData.Author;
            Campaign = blfData.Campaign;
            Scenario = blfData.Scenario;
            ModReference = blfData.ModReference;
            MapVariantTagNames = blfData.MapVariantTagNames;
            MapVariant = blfData.MapVariant;
            GameVariant = blfData.GameVariant;
            ContentHeader = blfData.ContentHeader;
            MapImage = blfData.MapImage;
            Buffer = blfData.Buffer;
        }
    }
}
