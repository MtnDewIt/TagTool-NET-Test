using System;
using TagTool.Tags;

namespace TagTool.Tags.Definitions.Common
{
    [TagStructure(Size = 0x8)]
    public class MetagameBucket : TagStructure
    {
        public CampaignMetagameBucketFlags Flags;
        public CampaignMetagameBucketType Type;
        public CampaignMetagameBucketClass Class;
        [TagField(Length = 1, Flags = TagFieldFlags.Padding)]
        public byte[] Padding;
        public short PointCount;
        [TagField(Length = 2, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;

        [Flags]
        public enum CampaignMetagameBucketFlags : byte
        {
            OnlyCountsWithRiders = 1 << 0
        }

        public enum CampaignMetagameBucketType : sbyte
        {
            Brute,
            Grunt,
            Jackal,
            Marine,
            Bugger,
            Hunter,
            FloodInfection,
            FloodCarrier,
            FloodCombat,
            FloodPureform,
            Sentinel,
            Elite,
            Turret,
            Mongoose,
            Warthog,
            Scorpion,
            Hornet,
            Pelican,
            Shade,
            Watchtower,
            Ghost,
            Chopper,
            Mauler,
            Wraith,
            Banshee,
            Phantom,
            Scarab,
            Guntower,
            Engineer,
            EngineerRechargeStation
        }

        public enum CampaignMetagameBucketClass : sbyte
        {
            Infantry,
            Leader,
            Hero,
            Specialist,
            LightVehicle,
            HeavyVehicle,
            GiantVehicle,
            StandardVehicle
        }
    }
}