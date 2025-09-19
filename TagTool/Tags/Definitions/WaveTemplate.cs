using System;
using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "wave_template", Tag = "wave", Size = 0xC, MaxVersion = CacheVersion.HaloReach11883)]
    public class WaveTemplate : TagStructure
    {
        public List<SquadSpecification> SquadSpecifications;

        [TagStructure(Size = 0x28, Version = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
        public class SquadSpecification : TagStructure 
        {
            public CachedTag SquadTemplate;
            public WaveDifficultyFlags DifficultyFlags;

            [TagField(Flags = TagFieldFlags.Padding, Length = 0x2)]
            public byte[] Padding;

            public Bounds<short> RoundRange;
            public Bounds<short> SetRange;
            public short Weight;
            public byte MinimumSpawn;
            public byte MaximumSpawn;
            public WavePlacementValue PlacementFilter;
            public WaveFlags Flags;
            public WaveTeamValue Team;
        }

        [Flags]
        public enum WaveDifficultyFlags : short 
        {
            None = 0,
            Easy = 1 << 0,
            Normal = 1 << 1,
            Heroic = 1 << 2,
            Legendary = 1 << 3,
        }

        public enum WavePlacementValue : int 
        {
            None = 0,
            HeavyInfantry,
            BossInfantry,
            LightVehicle,
            HeavyVehicle,
            FlyingInfantry,
            FlyingVehicle,
            Bonus,
            NoVaultAnim,
        }

        [Flags]
        public enum WaveFlags : short 
        {
            None = 0,
            IncompatibleWithDropships = 1 << 0,
        }

        public enum WaveTeamValue : short 
        {
            Default = 0,
            Player,
            Human,
            Covenant,
            Flood,
            Sentinel,
            Heretic,
            Prophet,
            Guilty,
            Unused9,
            Unused10,
            Unused11,
            Unused12,
            Unused13,
            Unused14,
            Unused15,
        }
    }
}
