using System;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.BlamFile.Reach
{

    [TagStructure(Size = 0x2B4, MinVersion = CacheVersion.HaloReach)]
    public class ReachMetadata : TagStructure
    {
        public short Unknown1; // BuildVersion?
        public short Unknown1A; // MapMinorVersion?

        public int Unknown2; // Type?
        public int Size;
        public int Unknown4;
        public int Unknown5;
        public int Unknown6;
        public int Unknown7;
        public int Unknown8;
        public int Unknown9;
        public int Unknown10;
        public int Unknown11;
        public int Unknown12;
        public int MapId = -1;
        public int Unknown14;
        public int Unknown15;

        // ContentItemHistory

        public ulong Unknown17; // CreationHistoryTimestamp?
        public ulong Unknown19; // CreationHistoryAuthorId?

        [TagField(Length = 16, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public string Unknown20; // CreationHistoryAuthor?

        public int Unknown21; // CreationHistoryUnknown?

        // ContentItemHistory

        public ulong Unknown23; // ModificationHistoryTimestamp?
        public ulong Unknown24; // ModificationHistoryAuthorId?

        [TagField(Length = 16, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public string Unknown26; // ModificationHistoryAuthor?

        public int Unknown27; // ModificationHistoryUnknown?



        [TagField(Length = 128, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        public string Name;

        [TagField(Length = 128, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        public string Description;

        public int Unknown28;
        public int Unknown29;
        public int Unknown30;
        public int Unknown31;
        public int Unknown32;
        public int Unknown33;
        public int Unknown34;
        public int Unknown35;
        public int Unknown36;
        public int Unknown37;
        public int Unknown38;
        public int Unknown39;
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
