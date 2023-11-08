using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_halox_start_menu_panes_settings_display_sidebar_items_gui_datasource_definition : TagFile
    {
        public ui_halox_start_menu_panes_settings_display_sidebar_items_gui_datasource_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<GuiDatasourceDefinition>($@"ui\halox\start_menu\panes\settings_display\sidebar_items");
            var dsrc = CacheContext.Deserialize<GuiDatasourceDefinition>(Stream, tag);
            dsrc.Name = CacheContext.StringTable.GetStringId($@"sidebar_items");
            dsrc.Elements = new List<GuiDatasourceDefinition.DatasourceElementBlock>
            {
                new GuiDatasourceDefinition.DatasourceElementBlock
                {
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetStringId($@"name"),
                            Value = CacheContext.StringTable.GetStringId($@"display_subtitles"),
                        },
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetStringId($@"display_group"),
                            Value = CacheContext.StringTable.GetStringId($@"display_subtitles"),
                        },
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetStringId($@"spinner"),
                            Value = CacheContext.StringTable.GetStringId($@"display_subtitles"),
                        },
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetStringId($@"description"),
                            Value = CacheContext.StringTable.GetStringId($@"display_setting_description"),
                        },
                    },
                },
            };
            CacheContext.Serialize(Stream, tag, dsrc);
        }
    }
}
