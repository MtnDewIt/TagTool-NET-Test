using TagTool.Tags.Definitions;

namespace TagTool.Commands.Tags 
{
    partial class BaseCacheHaloOnlineCommand : Command
    {
        public void PatchEquipment()
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                foreach (var tag in CacheContext.TagCache.NonNull())
                {
                    if (tag.IsInGroup("eqip") && tag.Name == $@"objects\equipment\concussiveblast_equipment\concussiveblast_equipment")
                    {
                        var eqip = CacheContext.Deserialize<Equipment>(stream, tag);
                        eqip.EnterAnimation = CacheContext.StringTable.GetStringId($@"con_blast_enter");
                        eqip.ExitAnimation = CacheContext.StringTable.GetStringId($@"con_blast_exit");
                        CacheContext.Serialize(stream, tag, eqip);
                    }
                }
            }
        }
    }
}