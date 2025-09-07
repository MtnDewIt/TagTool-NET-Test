using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Tags.Definitions.Common;
using System.Runtime.InteropServices;

namespace TagTool.BlamFile.Chunks.Metadata
{
    [TagStructure(Size = 0xF8, MaxVersion = CacheVersion.HaloOnline700123)]
    public class ContentItemMetadata : TagStructure
    {
        public ulong UniqueId;

        [TagField(CharSet = CharSet.Unicode, Length = 16)]
        public string Name = string.Empty;

        [TagField(CharSet = CharSet.Ansi, Length = 128)]
        public string Description = string.Empty;

        [TagField(CharSet = CharSet.Ansi, Length = 16)]
        public string Author = string.Empty;

        public ContentItemType ContentType;
        public bool AuthorIsOnline;

        [TagField(Length = 3, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;

        public ulong AuthorId;
        public ulong ContentSize;
        public ulong Timestamp;
        public int FilmDuration;
        public int CampaignId = -1;
        public int MapId = -1;
        public GameEngineType GameEngineType;
        public int CampaignDifficulty = -1;

        [TagField(MinVersion = CacheVersion.Halo3ODST)]
        public sbyte CampaignInsertionPoint = -1;

        [TagField(MinVersion = CacheVersion.Halo3ODST)]
        public bool SurvivalEnabled;

        [TagField(MaxVersion = CacheVersion.Halo3Retail)]
        public short HopperId;

        [TagField(Length = 2, Flags = TagFieldFlags.Padding)]
        public byte[] Padding2;

        public ulong GameId;

        public enum ContentItemType : int
        {
            None = -1,
            Personal,
            CTF,
            Slayer,
            Oddball,
            King,
            Juggernaut,
            Territories,
            Assault,
            Infection,
            VIP,
            Usermap,
            Film,
            Clip,
            Screenshot,
        }

        public static ContentItemMetadata Decode(BitStreamReader stream)
        {
            var metadata = new ContentItemMetadata();

            metadata.UniqueId = stream.ReadUnsigned64(64);
            metadata.Name = stream.ReadStringWchar(16);
            metadata.Description = stream.ReadStringUtf8(128);
            metadata.Author = stream.ReadStringUtf8(16);
            metadata.ContentType = (ContentItemType)(stream.ReadSignedInteger(5) - 1);
            metadata.AuthorIsOnline = stream.ReadBool();
            metadata.AuthorId = stream.ReadUnsigned64(64);
            metadata.ContentSize = stream.ReadUnsigned64(64);
            metadata.Timestamp = stream.ReadUnsigned64(64);
            metadata.FilmDuration = (int)stream.ReadUnsigned(32);
            metadata.CampaignId = stream.ReadSignedInteger(32);
            metadata.MapId = stream.ReadSignedInteger(32);
            metadata.GameEngineType = (GameEngineType)stream.ReadUnsigned(4);
            metadata.CampaignDifficulty = stream.ReadSignedInteger(3) - 1;
            metadata.HopperId = (short)stream.ReadUnsigned(16);
            metadata.GameId = stream.ReadUnsigned64(64);

            return metadata;
        }

        public static void Encode(BitStreamWriter stream, ContentItemMetadata metadata)
        {
            // TODO: Implement
        }
    }
}
