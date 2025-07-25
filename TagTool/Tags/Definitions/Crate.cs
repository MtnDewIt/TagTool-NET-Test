using System;
using System.Collections.Generic;
using TagTool.Tags.Definitions.Common;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "crate", Tag = "bloc", Size = 0x14)]
    public class Crate : GameObject
    {
        public CrateFlagsValue CrateFlags;

        [TagField(Flags = TagFieldFlags.Padding, Length = 2)]
        public byte[] Pad = new byte[2];

        public List<MetagameBucket> MetagameProperties;
        public int SelfDestructionTimer; // seconds

        [Flags]
        public enum CrateFlagsValue : ushort
        {
            None = 0,
            DoesNotBlockAreaOfEffect = 1 << 0,
            AttachTextureCameraHack = 1 << 1,
            Targetable = 1 << 2,
            CrateWallsBlockAreaOfEffect = 1 << 3,
            CrateBlocksDamageFlashDamageResponse = 1 << 4,
            CrateBlocksRumbleDamageResponse = 1 << 5,
            CrateTakesTopLevelAreaOfEffectDamage = 1 << 6,
            CrateBlocksForcedProjectileOverpenetration = 1 << 7,
            Unimportant = 1 << 8,
            AlwaysCheckChildrenCollision = 1 << 9,
            AllowFriendlyTeamToPassThroughInside = 1 << 10,
            AllowAllyTeamToPassThroughInside = 1 << 11,
            AllowFriendlyTeamToPassThroughOutside = 1 << 12,
            AllowAllyTeamToPassThroughOutside = 1 << 13,
            RejectAllContactPointsInside = 1 << 14,
            RejectAllContactPointsOutside = 1 << 15
        }
    }
}