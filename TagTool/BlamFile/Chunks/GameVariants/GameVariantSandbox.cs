using System;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks.GameVariants
{
    [TagStructure]
    public class GameVariantSandbox : GameVariantBase
    {
        public SandboxFlags VariantFlags;
        public SandboxEditModeSettings EditMode;
        public SandboxRespawnTime RespawnTime;
        public GameVariantPlayerTraits PlayerTraits;

        [TagField(Flags = TagFieldFlags.Padding, Length = 0x90, MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(Flags = TagFieldFlags.Padding, Length = 0x70, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public byte[] Alignment;

        [Flags]
        public enum SandboxFlags : byte
        {
            None = 0,
            OpenChannelVoice = 1 << 0,
        }

        public enum SandboxEditModeSettings : byte
        {
            AllPlayers = 0,
            OnlyLeader,
        }

        public enum SandboxRespawnTime : short
        {
            Instant = 0,
            Seconds_3 = 3,
            Seconds_4 = 4,
            Seconds_5 = 5,
            Seconds_6 = 6,
            Seconds_7 = 7,
            Seconds_8 = 8,
            Seconds_9 = 9,
            Seconds_10 = 10,
            Seconds_15 = 15,
            Seconds_30 = 30,
            Seconds_60 = 60,
        }

        public static GameVariantSandbox Decode(BitStreamReader stream)
        {
            var variant = new GameVariantSandbox();

            variant.BaseFlags = (BaseVariantFlags)stream.ReadUnsigned(1);
            variant.MiscellaneousOptions = VariantMiscellaneousOptions.Decode(stream);
            variant.RespawnOptions = VariantRespawnOptions.Decode(stream);
            variant.SocialOptions = VariantSocialOptions.Decode(stream);
            variant.MapOverrideOptions = VariantMapOverrideOptions.Decode(stream);
            variant.TeamScoringMethod = (TeamScoring)stream.ReadUnsigned(3);

            variant.VariantFlags = (SandboxFlags)stream.ReadUnsigned(1);
            variant.EditMode = (SandboxEditModeSettings)stream.ReadUnsigned(2);
            variant.RespawnTime = (SandboxRespawnTime)stream.ReadUnsigned(6);
            variant.PlayerTraits = GameVariantPlayerTraits.Decode(stream);

            return variant;
        }

        public static void Encode(BitStreamWriter stream, GameVariantSandbox variant)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}