using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Tags.Definitions.Common;

namespace TagTool.BlamFile.Chunks.Metadata
{
    [TagStructure(Size = 0x2B0, MinVersion = CacheVersion.HaloReach)]
    public class ReachContentItemMetadata : TagStructure
    {
        public ContentItemTypeReach ContentTypeReach;

        [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
        public byte[] PaddingReach;

        public int FileLength;

        public ulong UniqueId;
        public ulong ParentUniqueId;
        public ulong RootUniqueId;
        public ulong GameId;

        public GameEngineActivity GameActivity = GameEngineActivity.None;
        public GameEngineMode GameMode;
        public GameEngineTypeReach GameEngineType;

        public int MapId = -1;
        public GameEngineCategory EngineCategory = GameEngineCategory.None;

        [TagField(Length = 0x7, Flags = TagFieldFlags.Padding)]
        public byte[] PaddingReach2;

        public ContentItemAuthor CreationHistory;
        public ContentItemAuthor ModificationHistory;

        [TagField(Length = 128, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        public string Name = string.Empty;

        [TagField(Length = 128, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        public string Description = string.Empty;

        public ContentItemGeneric Generic;
        public ContentItemMatchmaking Matchmaking;
        public ContentItemMetagame Metagame;

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

        [TagStructure(Size = 0x24)]
        public class ContentItemAuthor : TagStructure 
        {
            public ulong Timestamp;
            public ulong AuthorId;

            [TagField(Length = 16, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
            public string Author = string.Empty;

            public bool AuthorIsOnline;

            [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;

            public static ContentItemAuthor Decode(BitStream stream, bool packed)
            {
                var author = new ContentItemAuthor();

                author.Timestamp = stream.ReadUnsigned64(64);
                author.AuthorId = stream.ReadUnsigned64(64);
                author.Author = stream.ReadString(16, packed);
                author.AuthorIsOnline = stream.ReadUnsigned(packed ? 1 : 8) != 0;

                if (!packed)
                    stream.ReadBytes(3);

                return author;
            }

            public static void Encode(BitStream stream, ContentItemAuthor author, bool packed) 
            {
                // TODO: Implement
            }
        }

        [TagStructure(Size = 0x10)]
        public class ContentItemGeneric : TagStructure
        {
            public int FilmDuration;
            public GameEngineIcon EngineIcon = GameEngineIcon.None;

            [TagField(Length = 0xB, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;

            public static ContentItemGeneric Decode(BitStream stream, ReachContentItemMetadata metadata, bool packed)
            {
                var generic = new ContentItemGeneric();

                if (metadata.ContentTypeReach == ContentItemTypeReach.Film || metadata.ContentTypeReach == ContentItemTypeReach.FilmClip)
                {
                    generic.FilmDuration = (int)stream.ReadUnsigned(32);

                    if (!packed)
                        stream.ReadBytes(12);
                }
                else if (metadata.ContentTypeReach == ContentItemTypeReach.GameVariant)
                {
                    generic.EngineIcon = (GameEngineIcon)stream.ReadUnsigned(8);

                    if (!packed)
                        stream.ReadBytes(15);
                }
                else 
                {
                    if (!packed)
                        stream.ReadBytes(16);
                }

                return generic;
            }

            public static void Encode(BitStream stream, ContentItemGeneric generic, bool packed)
            {
                // TODO: Implement
            }
        }

        [TagStructure(Size = 0x10)]
        public class ContentItemMatchmaking : TagStructure
        {
            public short HopperId;

            [TagField(Length = 0xE, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;

            public static ContentItemMatchmaking Decode(BitStream stream, ReachContentItemMetadata metadata, bool packed)
            {
                var matchmaking = new ContentItemMatchmaking();

                // TODO: Confirm validity of activities enum
                if (metadata.GameActivity == (GameEngineActivity)2) 
                {
                    matchmaking.HopperId = (short)stream.ReadUnsigned(16);

                    if (!packed)
                        matchmaking.Padding = stream.ReadBytes(14);
                }
                else 
                {
                    if (!packed)
                        stream.ReadBytes(16);
                }

                return matchmaking;
            }

            public static void Encode(BitStream stream, ContentItemMatchmaking metagame, bool packed)
            {
                // TODO: Implement
            }
        }

        [TagStructure(Size = 0x10)]
        public class ContentItemMetagame : TagStructure 
        {
            public int CampaignId;
            public GameEngineDifficulty CampaignDifficulty;
            public GameMetagameScoring CampaignMetagameScoring;
            public int CampaignInsertionPoint;
            public GamePrimarySkullFlags CampaignPrimarySkulls;
            public GameSecondarySkullFlags CampaignSecondarySkulls;

            public static ContentItemMetagame Decode(BitStream stream, ReachContentItemMetadata metadata, bool packed) 
            {
                var metagame = new ContentItemMetagame();

                if (metadata.GameMode == GameEngineMode.Campaign)
                {
                    metagame.CampaignId = (int)stream.ReadUnsigned(packed ? 8 : 32);
                    metagame.CampaignDifficulty = (GameEngineDifficulty)stream.ReadUnsigned(packed ? 2 : 16);
                    metagame.CampaignMetagameScoring = (GameMetagameScoring)stream.ReadUnsigned(packed ? 2 : 16);
                    metagame.CampaignInsertionPoint = (int)stream.ReadUnsigned(packed ? 2 : 32);

                    if (!packed)
                        stream.ReadBytes(4);
                }
                else if (metadata.GameMode == GameEngineMode.Survival)
                {
                    metagame.CampaignDifficulty = (GameEngineDifficulty)stream.ReadUnsigned(packed ? 2 : 16);
                    metagame.CampaignPrimarySkulls = (GamePrimarySkullFlags)stream.ReadUnsigned(16);
                    metagame.CampaignSecondarySkulls = (GameSecondarySkullFlags)stream.ReadUnsigned(16);

                    if (!packed)
                        stream.ReadBytes(10);
                }
                else 
                {
                    if (!packed)
                        stream.ReadBytes(16);
                }

                return metagame;
            }

            public static void Encode(BitStream stream, ContentItemMetagame metagame, bool packed)
            {
                // TODO: Implement
            }
        }

        public static ReachContentItemMetadata Decode(BitStream stream, bool packed) 
        {
            var metadata = new ReachContentItemMetadata();

            metadata.ContentTypeReach = (ContentItemTypeReach)(stream.ReadUnsigned(packed ? 4 : 8) - (packed ? 1 : 0));

            if (!packed)
                stream.ReadBytes(3);

            metadata.FileLength = (int)stream.ReadUnsigned(32);
            metadata.UniqueId = stream.ReadUnsigned64(64);
            metadata.ParentUniqueId = stream.ReadUnsigned64(64);
            metadata.RootUniqueId = stream.ReadUnsigned64(64);
            metadata.GameId = stream.ReadUnsigned64(64);
            metadata.GameActivity = (GameEngineActivity)(stream.ReadUnsigned(packed ? 3 : 8) - (packed ? 1 : 0));
            metadata.GameMode = (GameEngineMode)stream.ReadUnsigned(packed ? 3 : 8);
            metadata.GameEngineType = (GameEngineTypeReach)stream.ReadUnsigned(packed ? 3 : 16);
            metadata.MapId = (int)stream.ReadUnsigned(32);
            metadata.EngineCategory = (GameEngineCategory)stream.ReadUnsigned(8);
            
            if (!packed)
                stream.ReadBytes(7);

            metadata.CreationHistory = ContentItemAuthor.Decode(stream, packed);
            metadata.ModificationHistory = ContentItemAuthor.Decode(stream, packed);

            metadata.Name = stream.ReadUnicodeString(128, packed);
            metadata.Description = stream.ReadUnicodeString(128, packed);

            metadata.Generic = ContentItemGeneric.Decode(stream, metadata, packed);
            metadata.Matchmaking = ContentItemMatchmaking.Decode(stream, metadata, packed);
            metadata.Metagame = ContentItemMetagame.Decode(stream, metadata, packed);

            return metadata;
        }

        public static void Encode(BitStream stream, ReachContentItemMetadata metadata, bool packed)
        {
            // TODO: Implement
        }
    }
}
