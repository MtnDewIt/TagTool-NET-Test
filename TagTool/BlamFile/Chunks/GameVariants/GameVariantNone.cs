using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks.GameVariants
{
    [TagStructure]
    public class GameVariantNone : GameVariantBase
    {
        [TagField(Flags = TagFieldFlags.Padding, Length = 0xB0, MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(Flags = TagFieldFlags.Padding, Length = 0x90, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
        public byte[] Alignment;
    }
}
