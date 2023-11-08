using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_halox_start_menu_panes_settings_display_spinner_display_subtitles_gui_datasource_definition : TagFile
    {
        public ui_halox_start_menu_panes_settings_display_spinner_display_subtitles_gui_datasource_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<GuiDatasourceDefinition>($@"ui\halox\start_menu\panes\settings_display\spinner_display_subtitles");
            var dsrc = CacheContext.Deserialize<GuiDatasourceDefinition>(Stream, tag);
            dsrc.Name = CacheContext.StringTable.GetStringId($@"display_subtitles");
            dsrc.Elements = new List<GuiDatasourceDefinition.DatasourceElementBlock>
            {
                new GuiDatasourceDefinition.DatasourceElementBlock
                {
                    IntegerValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.IntegerValue>
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.IntegerValue
                        {
                            Name = CacheContext.StringTable.GetStringId($@"value"),
                            Value = 0,
                        },
                    },
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetStringId($@"name"),
                            Value = CacheContext.StringTable.GetStringId($@"display_subtitles_on"),
                        },
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetStringId($@"description"),
                            Value = CacheContext.StringTable.GetStringId($@"display_subtitles_on_help"),
                        },
                    },
                },
                new GuiDatasourceDefinition.DatasourceElementBlock
                {
                    IntegerValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.IntegerValue>
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.IntegerValue
                        {
                            Name = CacheContext.StringTable.GetStringId($@"value"),
                            Value = 1,
                        },
                    },
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetStringId($@"name"),
                            Value = CacheContext.StringTable.GetStringId($@"display_subtitles_off"),
                        },
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetStringId($@"description"),
                            Value = CacheContext.StringTable.GetStringId($@"display_subtitles_off_help"),
                        },
                    },
                },
            };
            CacheContext.Serialize(Stream, tag, dsrc);
        }
    }
}
