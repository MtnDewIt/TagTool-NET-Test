using System;
using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "device_terminal", Tag = "term", Size = 0x140, MaxVersion = CacheVersion.Eldorado700123)]
    [TagStructure(Name = "device_terminal", Tag = "term", Size = 0x48, MinVersion = CacheVersion.HaloReach)]
    public class Terminal : Device
    {
        [TagField(MaxVersion = CacheVersion.Eldorado700123)]
        public int BahBah;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public int TerminalNumber;

        public StringId ActionString;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public StringId Name;

        [TagField(MaxVersion = CacheVersion.Eldorado700123)]
        public short TerminalIndex;
        [TagField(Flags = TagFieldFlags.Padding, Length = 0x2, MaxVersion = CacheVersion.Eldorado700123)]
        public byte[] Unused2;

        [TagField(MaxVersion = CacheVersion.Eldorado700123)]
        public float TerminalExposure;

        public CachedTag ActivationSound;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public CachedTag IllustrationBitmap;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public CachedTag TerminalStrings;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<TerminalPage> Pages;

        [TagField(MaxVersion = CacheVersion.Eldorado700123)]
        public CachedTag DeactivationSound;
        [TagField(MaxVersion = CacheVersion.Eldorado700123)]
        public CachedTag TranslateSound1;
        [TagField(MaxVersion = CacheVersion.Eldorado700123)]
        public CachedTag TranslateSound2;
        [TagField(MaxVersion = CacheVersion.Eldorado700123)]
        public CachedTag ErrorSound;
        [TagField(MaxVersion = CacheVersion.Eldorado700123)]
        public TerminalScreen EasyScreen;
        [TagField(MaxVersion = CacheVersion.Eldorado700123)]
        public TerminalScreen NormalScreen;
        [TagField(MaxVersion = CacheVersion.Eldorado700123)]
        public TerminalScreen HeroicScreen;
        [TagField(MaxVersion = CacheVersion.Eldorado700123)]
        public TerminalScreen LegendaryScreen;

        [TagStructure(Size = 0x38)]
        public class TerminalScreen : TagStructure
        {
            public CachedTag DummyStrings;
            public CachedTag StoryStrings;
            public DialectTypeFlags DummyDialectTypes;
            public DialectTypeFlags StoryDialectTypes;
            public TerminalImage DummyBlfImage;
            public TerminalImage StoryBlfImage;
            public CachedTag ErrorStrings;

            [Flags]
            public enum DialectTypeFlags : short
            {
                None = 0,
                Military = 1 << 0,
                Public = 1 << 1,
                Private = 1 << 2,
                Librarian = 1 << 3,
                Didact = 1 << 4,
                Mendicant = 1 << 5,
                Offensive = 1 << 6,
                Gravemind = 1 << 7,
                Fleet = 1 << 8,
                Spark = 1 << 9
            }

            public enum TerminalImage : short
            {
                None = -1,
                Image1,
                Image2,
                Image3,
                Image4,
                Image5,
                Image6,
                Image7,
                Image8
            }
        }

        [TagStructure(Size = 0x8)]
        public class TerminalPage : TagStructure
        {
            public short BitmapSequenceIndex;
            public short BitmapSpriteIndex;
            public StringId Text;
        }
    }
}