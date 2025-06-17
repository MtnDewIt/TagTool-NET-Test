using TagTool.Cache;
using TagTool.IO;
using TagTool.Tags;
using TagTool.BlamFile.Chunks;

namespace TagTool.BlamFile.HaloOnline
{
    [TagStructure(Size = 0x148F8, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail)]
    [TagStructure(Size = 0x19469, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0x29904, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnlineED)]
    [TagStructure(Size = 0x198F9, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Size = 0x1C841, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach)]
    [TagStructure(Size = 0x21C2C, MinVersion = CacheVersion.Halo4)]
    public class HaloOnlineBlf : TagStructure 
    {
        public EndianFormat Format;
        public Blf.BlfFileContentFlags ContentFlags;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo4)]
        public BlfChunkStartOfFile StartOfFile;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo4)]
        public BlfEndOfFileCRC EndOfFileCRC;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo4)]
        public BlfEndOfFileRSA EndOfFileRSA;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo4)]
        public BlfEndOfFileSHA1 EndOfFileSHA1;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo4)]
        public BlfChunkEndOfFile EndOfFile;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo4)]
        public BlfAuthor Author;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo4)]
        public BlfCampaign Campaign;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo4)]
        public BlfScenario Scenario;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnlineED)]
        public BlfModPackageReference ModReference;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnlineED)]
        public BlfMapVariantTagNames MapVariantTagNames;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo4)]
        public BlfMapVariant MapVariant;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo4)]
        public BlfGameVariant GameVariant;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo4)]
        public BlfContentHeader ContentHeader;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo4)]
        public BlfMapImage MapImage;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo4)]
        public BlfScreenshotCamera ScreenshotCamera;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo4)]
        public BlfScreenshotData ScreenshotData;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo4)]
        public byte[] Buffer;

        public HaloOnlineBlf(Blf blfData) 
        {
            Format = blfData.Format;
            ContentFlags = blfData.ContentFlags;

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
            ScreenshotCamera = blfData.ScreenshotCamera;
            ScreenshotData = blfData.ScreenshotData;
            Buffer = blfData.Buffer;
        }
    }
}
