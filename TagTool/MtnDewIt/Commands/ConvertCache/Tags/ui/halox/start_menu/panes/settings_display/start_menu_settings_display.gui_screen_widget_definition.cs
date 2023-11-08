using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_halox_start_menu_panes_settings_display_start_menu_settings_display_gui_screen_widget_definition : TagFile
    {
        public ui_halox_start_menu_panes_settings_display_start_menu_settings_display_gui_screen_widget_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_display\start_menu_settings_display");
            var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(Stream, tag);
            scn3.GroupWidgets[1].Definition.TextWidgets[0].Definition.GuiRenderBlock.Bounds720p = new Rectangle2d(147, 65, 422, 603);
            CacheContext.Serialize(Stream, tag, scn3);
        }
    }
}
