﻿using System;
using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.BlamFile.GameVariants
{
    [TagStructure]
    public class GameVariantJuggernaut : GameVariantBase
    {
        public short ScoreToWinRound;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public short ScoreToWinEarly;

        [TagField(Flags = TagFieldFlags.Padding, Length = 2)]
        public byte[] Padding1 = new byte[2];

        public JuggernautInitialJuggernautSettings InitialJuggernaut;
        public JuggernautNextJuggernautSettings NextJuggernaut;
        public JuggernautFlags VariantFlags;
        public JuggernautZoneMovementSettings ZoneMovement;
        public JuggernautZoneOrderSettings ZoneOrder;
        public sbyte KillPoints;
        public sbyte JuggernautKillPoints;
        public sbyte KillAsJuggernautPoints;
        public sbyte DestinationArrivalPoints;
        public sbyte SuicidePoints;
        public sbyte BetrayalPoints;
        public byte JuggernautDelay;

        public GameVariantPlayerTraits JuggernautTraits;

        [TagField(Flags = TagFieldFlags.Padding, Length = 2)]
        public byte[] Padding2 = new byte[2];

        //[TagField(Flags = TagFieldFlags.Padding, Length = 0x80, MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(Flags = TagFieldFlags.Padding, Length = 0x60, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public byte[] Alignment;

        public enum JuggernautInitialJuggernautSettings : byte
        {
            Random = 0,
            FirstKill,
            FirstDeath,
        }

        public enum JuggernautNextJuggernautSettings : byte
        {
            OnKillingJuggernaut = 0,
            OnKilledByJuggernaut,
            Unchanged,
            Random,
        }

        [Flags]
        public enum JuggernautFlags : byte
        {
            None = 0,
            AlliedAgainstJuggernaut = 1 << 0,
            RespawnOnLoneJuggernaut = 1 << 1,
            DestinationZonesEnabled = 1 << 2,
        }

        public enum JuggernautZoneMovementSettings : byte
        {
            Off = 0,
            Seconds_10,
            Seconds_15,
            Seconds_30,
            Minutes_1,
            Minutes_2,
            Minutes_3,
            Minutes_4,
            Minutes_5,
            OnArrival,
            OnSwitch,
        }

        public enum JuggernautZoneOrderSettings : byte
        {
            Random = 0,
            Sequence,
        }
    }
}