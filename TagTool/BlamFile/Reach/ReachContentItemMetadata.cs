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

        [TagField(Length = 0x3)]
        public byte[] PaddingReach1;

        public int FileLength;

        public ulong Unknown4; // UnknownID1? // might be: OwnerId, ShareId, ServerFileId
        public ulong Unknown6; // UnknownID2? // might be: OwnerId, ShareId, ServerFileId
        public ulong Unknown8; // UnknownID3? // might be: OwnerId, ShareId, ServerFileId
        public ulong Unknown10; // UnknownID4? // might be: OwnerId, ShareId, ServerFileId

        public GameEngineActivity GameActivity;
        public GameEngineMode GameMode;
        public GameEngineTypeReach GameEngineType; // GameEngineType (Move enum out of definition)

        [TagField(Length = 0x1)]
        public byte[] PaddingReach2;

        public int MapId = -1;
        public int EngineCategory = -1;

        [TagField(Length = 0x4)]
        public byte[] PaddingReach3;

        public ContentItemAuthor CreationHistory;
        public ContentItemAuthor ModificationHistory;

        [TagField(Length = 128, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        public string Name = string.Empty;

        [TagField(Length = 128, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        public string Description = string.Empty;

        public int EngineIcon = -1;

        public int Unknown29; // Unknown? 
        public int Unknown30; // Unknown? 
        public int Unknown31; // Unknown? 
        public int Unknown32; // Unknown?
        public int Unknown33; // Unknown?
        public int Unknown34; // Unknown?
        public int Unknown35; // Unknown?

        public sbyte Unknown36; // CampaignId?
        public sbyte Unknown36A; // CampaignDifficulty?
        public sbyte Unknown36B; // CampaignMetagameScoring?
        public sbyte Unknown36C; // CampaignInsertionPoint?
        public int Unknown37; // CampaignSkulls?

        public int Unknown38; // Unknown?
        public int Unknown39; // Unknown?

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
