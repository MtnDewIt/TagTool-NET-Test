using System;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Tags.Definitions.Common;

namespace TagTool.BlamFile.Reach
{

    [TagStructure(Size = 0x2B0, MinVersion = CacheVersion.HaloReach)]
    public class ReachMetadata : TagStructure
    {
        public ContentItemTypeReach ContentTypeReach;

        [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
        public byte[] PaddingReach1;

        public int FileLength;

        public ulong UniqueId;
        public ulong ParentUniqueId;
        public ulong RootUniqueId;
        public ulong GameId;

        public GameEngineActivity GameActivity = GameEngineActivity.None;
        public GameEngineMode GameMode;
        public GameEngineTypeReach GameEngineType;

        [TagField(Length = 0x1, Flags = TagFieldFlags.Padding)]
        public byte[] PaddingReach2;

        public int MapId = -1;
        public GameEngineCategory EngineCategory = GameEngineCategory.None;

        [TagField(Length = 0x7, Flags = TagFieldFlags.Padding)]
        public byte[] PaddingReach4;

        public ContentItemAuthor CreationHistory;
        public ContentItemAuthor ModificationHistory;

        [TagField(Length = 128, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        public string Name = string.Empty;

        [TagField(Length = 128, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        public string Description = string.Empty;

        [TagField(Length = 0x10)]
        public byte[] FilmDataOrIconIndex;

        [TagField(Length = 0x10)]
        public byte[] MatchmakingData;

        [TagField(Length = 0x10)]
        public byte[] CampaignDataOrFirefightData;

        public enum ContentItemTypeReach : sbyte
        {
            None = -1,
            DLC,
            Save,
            Screenshot,
            Film,
            FilmClip,
            MapVariant,
            GameVariant,
            Playlist,
        }

        public enum GameEngineActivity : sbyte
        {
            None = -1,
            Activities,
            Campaign,
            Survival,
            Matchmaking,
            Forge,
            Theater,
        }

        public enum GameEngineMode : byte
        {
            None = 0,
            Campaign,
            Survival,
            Multiplayer,
            Forge,
            Theater,
        }

        public enum GameEngineTypeReach : byte
        {
            None = 0,
            Forge,
            Megalo,
            Campaign,
            Survival,
        }

        public enum GameEngineCategory : sbyte 
        {
            None = -1,
            CTF,
            Slayer,
            Oddball,
            King,
            Juggernaut,
            Territories,
            Assault,
            Infection,
            VIP,
            Invasion,
            Stockpile,

            Race = 12,
            Headhunter = 13,

            Insane = 16,
        }

        public enum GameEngineIcon : sbyte 
        {
            None = -1,
            CTF,
            Slayer,
            Oddball,
            King,
            Juggernaut,
            Territories,
            Assault,
            Infection,
            VIP,
            Invasion,
            InvasionSlayer,
            Stockpile,
            ActionSack,
            Race,
            RocketRace,
            Grifball,
            Soccer,
            Headhunter,
            Crosshair,
            Wheel,
            Swirl,
            Bunker,
            HealthPack,
            CastleDefense,
            Return,
            Shapes,
            Cartographer,
            EightBall,
            Noble,
            Covenant,
            Attack,
            Defend,
            Ordnance,
            Circle,
            Recon,
            Recover,
            Ammo,
            Skull,
            Forge,

            RecentGames = 49,
            FileShare,
        }

        public enum GameCampaignId : sbyte 
        {
            None = -1,
            Default = 1,
        }

        public enum GameDifficulty : sbyte 
        {
            Easy,
            Normal,
            Heroic,
            Legendary,
        }

        public enum GameMetagameScoring : sbyte
        {
            None = 0,
            Team,
            FreeForAll,
        }

        public enum GameCampaignSkulls : uint 
        {
            None = 0,
            Iron = 1 << 0,
            BlackEye = 1 << 1,
            ToughLuck = 1 << 2,
            Catch = 1 << 3,
            Fog = 1 << 4,
            Famine = 1 << 5,
            Thunderstorm = 1 << 6,
            Tilt = 1 << 7,
            Mythic = 1 << 8,
            Assassin = 1 << 9,
            Blind = 1 << 10,
            Superman = 1 << 11,
            BirthdayParty = 1 << 12,
            Daddy = 1 << 13,
        }

        [TagStructure(Size = 0x24)]
        public class ContentItemAuthor : TagStructure 
        {
            public ulong Timestamp;
            public ulong AuthorId;

            [TagField(Length = 16, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
            public string Author = string.Empty;

            public bool AuthorIsOnline;

            [TagField(Length = 0x3)]
            public byte[] Padding;
        }
    }

    public class ContentItemHistory
    {
        public DateTimeOffset Timestamp;
        public ulong AuthorUID;
        public string AuthorName;
        public bool AuthorIsOnline;

        public void Decode(BitStream stream)
        {
            var timestamp = (long)stream.ReadUnsigned64(64);  
            Timestamp = DateTimeOffset.FromUnixTimeSeconds(timestamp);
            AuthorUID = stream.ReadUnsigned(64);
            AuthorName = stream.ReadString(16);
            AuthorIsOnline = stream.ReadUnsigned(1) != 0;
        }
    }

    public class ReachContentItemMetadata
    {
        public ReachContentItemType Type;
        public int Size;
        public ulong Uid;
        public ulong ParentUid;
        public ulong RootUid;
        public ulong GameId;
        public int Activity;
        public int GameMode;
        public int GameEngineType;
        public int MapId = -1;
        public int MagaloCategoryIndex;
        public ContentItemHistory CreationHistory;
        public ContentItemHistory ModificationHistory;
        public int Filmduration;
        public int GameVariantIconIndex = -1;
        public int HopperId = -1;
        public int CampaignId = -1;
        public int CampaignDifficulty = -1;
        public int CampaignMetagameScoring;
        public int CampaignInsertionPoint = -1;
        public uint CampaignSkulls;

        public void Decode(BitStream bitstream)
        {
            Type = (ReachContentItemType)((int)bitstream.ReadUnsigned(4) - 1);
            Size = (int)bitstream.ReadUnsigned(32);
            Uid = bitstream.ReadUnsigned64(64);
            ParentUid = bitstream.ReadUnsigned64(64);
            RootUid = bitstream.ReadUnsigned64(64);
            GameId = bitstream.ReadUnsigned64(64);
            Activity = (int)bitstream.ReadUnsigned(3) - 1;
            GameMode = (int)bitstream.ReadUnsigned(3);
            GameEngineType = (int)bitstream.ReadUnsigned(3);
            MapId = (int)bitstream.ReadUnsigned(32);
            MagaloCategoryIndex = (sbyte)bitstream.ReadUnsigned(8);
            CreationHistory = new ContentItemHistory();
            ModificationHistory = new ContentItemHistory();
            CreationHistory.Decode(bitstream);
            ModificationHistory.Decode(bitstream);

            if(Type == ReachContentItemType.Film || Type == ReachContentItemType.FilmClip)
            {
                Filmduration = (int)bitstream.ReadUnsigned(32);
            }
            else if(Type == ReachContentItemType.GameVariant)
            {
                GameVariantIconIndex = (byte)bitstream.ReadUnsigned(8);
            }

            if (Activity == 2) // matchmaking
                HopperId = (short)bitstream.ReadUnsigned(16);

            if (GameMode == 1) // campaign
            {
                CampaignId = (int)bitstream.ReadUnsigned(8);
                CampaignDifficulty = (int)bitstream.ReadUnsigned(2);
                CampaignMetagameScoring = (int)bitstream.ReadUnsigned(2);
                CampaignInsertionPoint = (int)bitstream.ReadUnsigned(2);
                CampaignSkulls = bitstream.ReadUnsigned(32);
            }
            else if (GameMode == 2) // firefight
            {
                CampaignDifficulty = (int)bitstream.ReadUnsigned(8);
                CampaignSkulls = bitstream.ReadUnsigned(32);
            }
        }
    }

    public enum ReachContentItemType : int
    {
        Unknown0,
        Unknown1,
        Unknown2,
        Film,
        FilmClip,
        MapVariant,
        GameVariant
    }
}
