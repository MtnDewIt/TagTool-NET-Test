using TagTool.Cache;
using TagTool.Tags;
using TagTool.Tags.Definitions.Common;
using static System.Runtime.InteropServices.CharSet;
using static TagTool.Tags.TagFieldFlags;

namespace TagTool.BlamFile
{
    [TagStructure(Size = 0xF8)]
    public class ContentItemMetadata : TagStructure
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

        [TagField(Length = 3, Flags = Padding)]
        public byte[] Padding1 = new byte[3];

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

        [TagField(Length = 2, Flags = Padding)]
        public byte[] Padding2 = new byte[2];

        public ulong GameId;
    }

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
}
