using TagTool.Cache;
using TagTool.IO;
using TagTool.Tags;

namespace TagTool.BlamFile.HaloOnline
{
    [TagStructure(Size = 0x29785, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnlineED)]
    [TagStructure(Size = 0x19779, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline700123)]
    public class HaloOnlineBlf : TagStructure 
    {
        public EndianFormat Format;
        public BlfFileContentFlags ContentFlags;
        public BlfAuthenticationType AuthenticationType;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public BlfChunkStartOfFile StartOfFile;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public BlfEndOfFileCRC EndOfFileCRC;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public BlfEndOfFileRSA EndOfFileRSA;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public BlfEndOfFileSHA1 EndOfFileSHA1;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public BlfChunkEndOfFile EndOfFile;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public BlfAuthor Author;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public BlfCampaign Campaign;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public BlfScenario Scenario;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public BlfModPackageReference ModReference;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnlineED)]
        public BlfMapVariantTagNames MapVariantTagNames;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public BlfMapVariant MapVariant;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public BlfGameVariant GameVariant;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public BlfContentHeader ContentHeader;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public BlfMapImage MapImage;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
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
