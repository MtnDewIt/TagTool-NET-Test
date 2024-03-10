using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Tags 
{
    public class ui_halox_main_menu_main_menu_gui_screen_widget_definition : TagFile
    {
        public ui_halox_main_menu_main_menu_gui_screen_widget_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\main_menu\main_menu");
            var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(Stream, tag);
            scn3.OnLoadScriptName = "mainmenu_cam";
            scn3.ScriptIndex = 5;
            CacheContext.Serialize(Stream, tag, scn3);
        }
    }
}
