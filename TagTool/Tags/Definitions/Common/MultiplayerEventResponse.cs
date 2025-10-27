using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.Tags.Definitions.Common
{
    [TagStructure(Size = 0x104, MaxVersion = CacheVersion.Halo3Retail)]
    [TagStructure(Size = 0x108, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0x10C, MaxVersion = CacheVersion.HaloOnline449175)]
    [TagStructure(Size = 0x20C, MinVersion = CacheVersion.HaloOnline498295)]
    public class MultiplayerEventResponse : TagStructure
    {
        public GameEngineEventFlags Flags;
        public TypeValue RuntimeEventType;

        [TagField(MaxVersion = CacheVersion.Halo3Retail)]
        public GameEngineGeneralEventH3 Event_H3;

        [TagField(Flags = TagFieldFlags.Label, MinVersion = CacheVersion.Halo3ODST)]
        public StringId Event;

        [TagField(Length = 256, MinVersion = CacheVersion.HaloOnline498295)]
        public string Unknown1;

        public AudienceValue Audience;
        public short DisplayPriority;
        public short SubPriority;
        public EventResponseContext DisplayContext;

        [TagField(Length = 2, Flags = TagFieldFlags.Padding, MaxVersion = CacheVersion.Halo3Retail)]
        public byte[] Padding0;

        public StringId DisplayString;
        public StringId MedalAward;

        [TagField(MinVersion = CacheVersion.HaloOnlineED)]
        public short EarnedWp; // earned wp/exp
        [TagField(Length = 2, Flags = TagFieldFlags.Padding, MinVersion = CacheVersion.HaloOnlineED)]
        public byte[] Padding1;

        [TagField(MinVersion = CacheVersion.Halo3ODST)]
        public float DisplayTime; // seconds

        public EventInputEnum RequiredField;
        public EventInputEnum ExcludedAudience;
        public EventInputEnum SplitscreenSuppression;

        [TagField(Length = 2, Flags = TagFieldFlags.Padding)]
        public byte[] Padding2;

        public StringId PrimaryString;
        public int PrimaryStringDuration;
        public StringId PluralDisplayString;
        public float SoundDelayAnnouncerOnly;
        public SoundResponseFlags SoundFlags;

        [TagField(Length = 2, Flags = TagFieldFlags.Padding)]
        public byte[] Padding3;

        public CachedTag EnglishSound;
        public CachedTag JapaneseSound;
        public CachedTag GermanSound;
        public CachedTag FrenchSound;
        public CachedTag SpanishSound;
        public CachedTag LatinAmericanSpanishSound;
        public CachedTag ItalianSound;
        public CachedTag KoreanSound;
        public CachedTag ChineseTraditionalSound;
        public CachedTag ChineseSimplifiedSound;
        public CachedTag PortugueseSound;
        public CachedTag PolishSound;

        public float Probability;
        public List<SoundResponseDefinitionBlock> SoundPermutations;

        [Flags]
        public enum GameEngineEventFlags : ushort
        {
            QuantityMessage = 1 << 0
        }

        public enum TypeValue : short
        {
            General,
            Flavor,
            Slayer,
            CaptureTheFlag,
            Oddball,
            Unused,
            KingOfTheHill,
            Vip,
            Juggernaut,
            Territories,
            Assault,
            Infection,
            Survival,
            EarnWp, // HO
        }

        public enum GameEngineGeneralEventH3 : short
        {
            Kill,
            Suicide,
            KillTeammate,
            Victory,
            TeamVictory,
            Unused1,
            Unused2,
            _1MinToWin,
            Team1MinToWin,
            _30SecsToWin,
            Team30SecsToWin,
            PlayerQuit,
            PlayerJoined,
            KilledByUnknown,
            _30MinutesLeft,
            _15MinutesLeft,
            _5MinutesLeft,
            _1MinuteLeft,
            TimeExpired,
            GameOver,
            RespawnTick,
            LastRespawnTick,
            TeleporterUsed,
            TeleporterBlocked,
            PlayerChangedTeam,
            PlayerRejoined,
            GainedLead,
            GainedTeamLead,
            LostLead,
            LostTeamLead,
            TiedLeader,
            TiedTeamLeader,
            RoundOver,
            _30SecondsLeft,
            _10SecondsLeft,
            Killfalling,
            Killcollision,
            Killmelee,
            SuddenDeath,
            PlayerBootedPlayer,
            KillflagCarrier,
            KillbombCarrier,
            KillstickyGrenade,
            Killsniper,
            KillstMelee,
            BoardedVehicle,
            StartTeamNoti,
            Telefrag,
            _10SecsToWin,
            Team10SecsToWin,
            Bulltrue,
            DeathFromTheGrave,
            Hijack,
            Skyjack,
            KillspartanLaser,
            Killflame,
            AssisttoDriver,
            Assist,
            PreGameOver
        }

        public enum AudienceValue : short
        {
            CausePlayer,
            CauseTeam,
            EffectPlayer,
            EffectTeam,
            All
        }

        public enum EventResponseContext : short
        {
            Self,
            Friendly,
            Enemy,
            Neutral,
            Unknown4, // HO
            Unknown5  // HO
        }

        public enum EventInputEnum : short
        {
            None,
            CausePlayer,
            CauseTeam,
            EffectPlayer,
            EffectTeam
        }

        [Flags]
        public enum SoundResponseFlags : ushort
        {
            AnnouncerSound = 1 << 0
        }

        [TagStructure(Size = 0xC8)]
        public class SoundResponseDefinitionBlock : TagStructure
        {
            public GameEngineSoundResponseFlagsDefinition SoundFlags;
            [TagField(Length = 2, Flags = TagFieldFlags.Padding)]
            public byte[] AGQD;
            public CachedTag EnglishSound;
            public CachedTag JapaneseSound;
            public CachedTag GermanSound;
            public CachedTag FrenchSound;
            public CachedTag SpanishSound;
            public CachedTag MexicanSound;
            public CachedTag ItalianSound;
            public CachedTag KoreanSound;
            public CachedTag ChineseSoundtraditional;
            public CachedTag ChineseSoundsimplified;
            public CachedTag PortugueseSound;
            public CachedTag PolishSound;
            public float Probability;

            [Flags]
            public enum GameEngineSoundResponseFlagsDefinition : ushort
            {
                AnnouncerSound = 1 << 0
            }
        }
    }
}
