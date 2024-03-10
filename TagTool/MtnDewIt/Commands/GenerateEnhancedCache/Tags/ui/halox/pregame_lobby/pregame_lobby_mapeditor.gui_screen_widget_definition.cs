using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Tags 
{
    public class ui_halox_pregame_lobby_pregame_lobby_mapeditor_gui_screen_widget_definition : TagFile
    {
        public ui_halox_pregame_lobby_pregame_lobby_mapeditor_gui_screen_widget_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
        (
            cache,
            cacheContext,
            stream
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
            TagData();
        }

        public override void TagData()
        {
            var tag = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_mapeditor");
            var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(Stream, tag);
            scn3.OnLoadScriptName = "editor_cam";
            scn3.ScriptIndex = 7;
            CacheContext.Serialize(Stream, tag, scn3);
        }
    }
}
