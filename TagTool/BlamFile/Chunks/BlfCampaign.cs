using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0x130C, Align = 0x1)]
    public class BlfCampaign : BlfChunkHeader
    {
        public int CampaignId;
        public uint TypeFlags;

        [TagField(Length = 0xC)]
        public CampaignNameUnicode32[] Names;

        [TagField(Length = 0xC)]
        public BlfScenario.NameUnicode128[] Descriptions;

        [TagField(Length = 0x40)]
        public int[] MapIds;

        [TagField(Length = 4, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;

        [TagStructure(Size = 0x80, Align = 0x1)]
        public class CampaignNameUnicode32 : TagStructure
        {
            [TagField(CharSet = System.Runtime.InteropServices.CharSet.Unicode, Length = 0x40, DataAlign = 0x1)]
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
