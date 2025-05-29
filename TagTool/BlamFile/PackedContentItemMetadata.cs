using TagTool.Common;
using TagTool.Tags.Definitions.Common;
using TagTool.Tags;
using static System.Runtime.InteropServices.CharSet;

namespace TagTool.BlamFile
{
    [TagStructure(Size = 0xF3)]
    public class PackedContentItemMetadata : TagStructure
    {
        public ulong UniqueId;

        [TagField(CharSet = Unicode, Length = 16)]
        public string Name = string.Empty;

        [TagField(CharSet = Ansi, Length = 128)]
        public string Description = string.Empty;

        [TagField(CharSet = Ansi, Length = 16)]
        public string Author = string.Empty;

        public ContentItemType ContentType;
        public bool AuthorIsOnline;
        public ulong AuthorId;
        public ulong ContentSize;
        public ulong Timestamp;
        public int FilmDuration;
        public int CampaignId = -1;
        public int MapId = -1;
        public GameEngineType GameEngineType;
        public int CampaignDifficulty = -1;
        public short HopperId;
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

        public static PackedContentItemMetadata Read(BitStream stream) 
        {
            var metadata = new PackedContentItemMetadata();

            metadata.UniqueId = stream.ReadUnsigned64(64);
            metadata.Name = stream.ReadUnicodeString(16);
            metadata.Description = stream.ReadString(128);
            metadata.Author = stream.ReadString(16);
            metadata.ContentType = (ContentItemType)(stream.ReadUnsigned(5) - 1);
            metadata.AuthorIsOnline = stream.ReadBool();
            metadata.AuthorId = stream.ReadUnsigned64(64);
            metadata.ContentSize = stream.ReadUnsigned64(64);
            metadata.Timestamp = stream.ReadUnsigned64(64);
            metadata.FilmDuration = (int)stream.ReadUnsigned(32);
            metadata.CampaignId = (int)stream.ReadUnsigned(32);
            metadata.MapId = (int)stream.ReadUnsigned(32);
            metadata.GameEngineType = (GameEngineType)stream.ReadUnsigned(4);
            metadata.CampaignDifficulty = (int)(stream.ReadUnsigned(3) - 1);
            metadata.HopperId = (short)stream.ReadUnsigned(16);
            metadata.GameId = stream.ReadUnsigned64(64);

            return metadata;
        }

        public static void Write() 
        {
            // TODO: Implement
        }
    }
}
