using TagTool.Cache;
using TagTool.Tags;
using static TagTool.Tags.TagFieldFlags;

namespace TagTool.Ai
{
    [TagStructure(Size = 0x2C)]
    public class CharacterMovementProperties : TagStructure
    {
        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloOnline700123)]
        public CharacterMovementFlagsH3 FlagsH3;
        [TagField(MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach11883)]
        public CharacterMovementFlagsReach FlagsReach;
        [TagField(Version = CacheVersion.Halo4)]
        public CharacterMovementFlagsH4 FlagsH4;
        public float PathfindingRadius;
        public float DestinationRadius;
        public float DiveGrenadeChance;
        public AiSize ObstacleLeapMinSize;
        public AiSize ObstacleLeapMaxSize;
        public AiSize ObstacleIgnoreSize;
        public AiSize ObstaceSmashableSize;

        [TagField(Flags = Padding, Length = 2)]
        public byte[] Unused = new byte[2];

        public CharacterJumpHeight JumpHeight;
        public CharacterMovementHintFlags MovementHints;
        public float ThrottleScale;
        public float ThrottleDampening; // 0 = slow change in throttle, 1 = fast change in throttle
        public float WalkDistance; // Under this distance, actors will walk instead of run (world units)
    }
}