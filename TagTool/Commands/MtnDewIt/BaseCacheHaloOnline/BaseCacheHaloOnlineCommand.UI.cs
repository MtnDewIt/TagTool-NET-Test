using TagTool.Tags.Definitions;

namespace TagTool.Commands.Tags 
{
    partial class BaseCacheHaloOnlineCommand : Command
    {
        public void applyUIPatches()
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                foreach (var tag in CacheContext.TagCache.NonNull())
                {
                    if (tag.IsInGroup("scn3") && tag.Name == $@"ui\halox\main_menu\main_menu")
                    {
                        var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(stream, tag);
                        scn3.ScriptIndex = 0;
                        CacheContext.Serialize(stream, tag, scn3);
                    }

                    if (tag.IsInGroup("scn3") && tag.Name == $@"ui\halox\pregame_lobby\pregame_lobby_campaign")
                    {
                        var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(stream, tag);
                        scn3.ScriptIndex = -1;
                        CacheContext.Serialize(stream, tag, scn3);
                    }

                    if (tag.IsInGroup("scn3") && tag.Name == $@"ui\halox\pregame_lobby\pregame_lobby_multiplayer")
                    {
                        var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(stream, tag);
                        scn3.ScriptIndex = 3;
                        CacheContext.Serialize(stream, tag, scn3);
                    }

                    if (tag.IsInGroup("scn3") && tag.Name == $@"ui\halox\pregame_lobby\pregame_lobby_mapeditor")
                    {
                        var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(stream, tag);
                        scn3.ScriptIndex = 2;
                        CacheContext.Serialize(stream, tag, scn3);
                    }

                    if (tag.IsInGroup("scn3") && tag.Name == $@"ui\halox\pregame_lobby\pregame_lobby_theater")
                    {
                        var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(stream, tag);
                        scn3.ScriptIndex = -1;
                        CacheContext.Serialize(stream, tag, scn3);
                    }
                }
            }
        }
    }
}