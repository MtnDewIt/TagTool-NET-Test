using TagTool.Cache;
using TagTool.Serialization;
using TagTool.Tags;
using System.Runtime.InteropServices;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0x130C, MaxVersion = CacheVersion.HaloReach)]
    [TagStructure(Size = 0x1ACC, MinVersion = CacheVersion.Halo4)]
    public class BlfCampaign : BlfChunkHeader
    {
        public int CampaignId;
        public uint TypeFlags;

        [TagField(Length = 0xC, MaxVersion = CacheVersion.HaloReach)]
        [TagField(Length = 0x11, MinVersion = CacheVersion.Halo4)]
        public CampaignNameUnicode32[] Names;

        [TagField(Length = 0xC, MaxVersion = CacheVersion.HaloReach)]
        [TagField(Length = 0x11, MinVersion = CacheVersion.Halo4)]
        public BlfScenario.NameUnicode128[] Descriptions;

        [TagField(Length = 0x40)]
        public int[] MapIds;

        [TagField(MinVersion = CacheVersion.Halo4)]
        public int Unknown1AC4;

        [TagField(Length = 0x4, Flags = TagFieldFlags.Padding, MaxVersion = CacheVersion.HaloReach)]
        [TagField(Length = 0x40, Flags = TagFieldFlags.Padding, MinVersion = CacheVersion.Halo4)]
        public byte[] Padding1;

        [TagStructure(Size = 0x80)]
        public class CampaignNameUnicode32 : TagStructure
        {
            [TagField(CharSet = CharSet.Unicode, Length = 0x40)]
            public string Name;
        }

        public static BlfCampaign Decode(TagDeserializer deserializer, DataSerializationContext dataContext)
        {
            return (BlfCampaign)deserializer.Deserialize(dataContext, typeof(BlfCampaign));
        }

        public static void Encode(TagSerializer serializer, DataSerializationContext dataContext, BlfCampaign campaign)
        {
            serializer.Serialize(dataContext, campaign);
        }
    }
}
