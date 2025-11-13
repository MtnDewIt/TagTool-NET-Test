using TagTool.Cache;
using TagTool.IO;
using TagTool.Tags;
using TagTool.BlamFile.Chunks;

namespace TagTool.BlamFile.HaloOnline
{
    [TagStructure(Size = 0x148F8, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x14AC8, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
    [TagStructure(Size = 0x19468, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x19638, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
    [TagStructure(Size = 0x29904, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnlineED)]
    [TagStructure(Size = 0x198F9, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Size = 0x1D564, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x1D734, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
    [TagStructure(Size = 0x21C2C, MinVersion = CacheVersion.Halo4, MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x21DFC, MinVersion = CacheVersion.Halo4, MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.MCC)]
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

        //[TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo4)]
        //public BlfScreenshotCamera ScreenshotCamera;
        //
        //[TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo4)]
        //public BlfScreenshotData ScreenshotData;
        //
        //[TagField(MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.Halo4)]
        //public BlfServerSignature ServerSignature;
        //
        //[TagField(MinVersion = CacheVersion.HaloCustomEdition, MaxVersion = CacheVersion.Halo2AMP, Platform = CachePlatform.MCC)]
        //public BlfFileshareMetadata FileshareMetadata;

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
            //ScreenshotCamera = blfData.ScreenshotCamera;
            //ScreenshotData = blfData.ScreenshotData;
            //ServerSignature = blfData.ServerSignature;
            //FileshareMetadata = blfData.FileshareMetadata;
            Buffer = blfData.Buffer;
        }
    }
}
