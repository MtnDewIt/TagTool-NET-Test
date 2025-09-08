using TagTool.Cache;
using static TagTool.Tags.TagFieldFlags;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "armor", Tag = "armr", Size = 0x30, MinVersion = CacheVersion.HaloOnline430475, MaxVersion = CacheVersion.HaloOnline700123)]
    public class Armor : GameObject
    {
        public CachedTag ParentModel;
        public CachedTag FirstPersonModel;
        public CachedTag ThirdPersonModel;
    }
}