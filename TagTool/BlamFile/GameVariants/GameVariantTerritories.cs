using System;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.BlamFile.GameVariants
{
    [TagStructure]
    public class GameVariantTerritories : GameVariantBase
    {
        public TerritoriesFlags VariantFlags;
        public TerritoriesRespawnOnCaptureSettings RespawnOnCapture;
        public TerritoriesCaptureTimeSettings CaptureTime;
        public TerritoriesSuddenDeathSettings SuddenDeathTime;
        public GameVariantPlayerTraits DefenderTraits;
        public GameVariantPlayerTraits AttackerTraits;

        //[TagField(Flags = TagFieldFlags.Padding, Length = 0x70, MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(Flags = TagFieldFlags.Padding, Length = 0x50, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public byte[] Alignment;

        [Flags]
        public enum TerritoriesFlags : short
        {
            None = 0,
            OneSided = 1 << 0,
            LockAfterFirstCapture = 1 << 1,
        }

        public enum TerritoriesRespawnOnCaptureSettings : short
        {
            Disabled,
            Friendly,
            Enemy,
            All,
        }

        public enum TerritoriesCaptureTimeSettings : short
        {
            Instant = 0,
            Seconds_5 = 5,
            Seconds_10 = 10,
            Seconds_15 = 15,
            Seconds_20 = 20,
            Seconds_30 = 30,
            Seconds_45 = 45,
            Minutes_1 = 60,
            Minutes_2 = 120,
        }

        public enum TerritoriesSuddenDeathSettings : short
        {
            Indefinite = -1,
            Off = 0,
            Seconds_15 = 15,
            Seconds_30 = 30,
            Minutes_1 = 60,
            Minutes_2 = 120,
            Minutes_5 = 300,
        }

        public static GameVariantTerritories Decode(BitStream stream)
        {
            var variant = new GameVariantTerritories();

            // TODO: Implement

            return variant;
        }

        public static void Encode(BitStream stream, GameVariantTerritories variant)
        {
            // TODO: Implement
        }
    }
}