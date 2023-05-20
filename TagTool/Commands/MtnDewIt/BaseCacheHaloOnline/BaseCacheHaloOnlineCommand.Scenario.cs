using TagTool.Tags.Definitions;

namespace TagTool.Commands.Tags 
{
    partial class BaseCacheHaloOnlineCommand : Command 
    {
        public void ScenarioPatches() 
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    if (tag.IsInGroup("scnr") && tag.Name == $@"levels\ui\mainmenu\mainmenu") 
                    {
                        var scnr = CacheContext.Deserialize<Scenario>(stream, tag);
                        scnr.MapId = 270735729;
                        scnr.MapType = ScenarioMapType.MainMenu;
                        CacheContext.Serialize(stream, tag, scnr);
                    }
                }
            }
        }
    }
}