﻿using TagTool.Tags;
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
        [TagField(Flags = Padding, Length = 3)]
        public byte[] Padding1 = new byte[3];
        public ulong AuthorId;
        public ulong ContentSize;
        public ulong Timestamp;
        public int FilmDuration;
        public int CampaignId = -1;
        public int MapId = -1;
        public GameEngineType GameEngineType;
        public int CampaignDifficulty = -1;
        public sbyte CampaignInsertionPoint = -1;
        public bool SurvivalEnabled;
        [TagField(Flags = Padding, Length = 2)]
        public byte[] Padding2 = new byte[2];
        public ulong GameId;
    }

    public enum ContentItemType : int
    {
        None = -1,
        GameState,
        CtfVariant,
        SlayerVariant,
        OddballVariant,
        KingOfTheHillVariant,
        JuggernautVariant,
        TerritoriesVariant,
        AssaultVariant,
        InfectionVariant,
        VipVariant,
        SandboxMap,
        Film,
        FilmClip,
        ScreenShot
    }
}
