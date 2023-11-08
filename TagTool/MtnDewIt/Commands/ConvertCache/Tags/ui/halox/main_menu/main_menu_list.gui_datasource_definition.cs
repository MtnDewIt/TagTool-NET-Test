using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_halox_main_menu_main_menu_list_gui_datasource_definition : TagFile
    {
        public ui_halox_main_menu_main_menu_list_gui_datasource_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<GuiDatasourceDefinition>($@"ui\halox\main_menu\main_menu_list");
            var dsrc = CacheContext.Deserialize<GuiDatasourceDefinition>(Stream, tag);
            dsrc.Name = CacheContext.StringTable.GetStringId($@"main_menu");
            dsrc.Elements = new List<GuiDatasourceDefinition.DatasourceElementBlock>()
            {
                new GuiDatasourceDefinition.DatasourceElementBlock()
                {
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>()
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue()
                        {
                            Name = CacheContext.StringTable.GetStringId("name"),
                            Value = CacheContext.StringTable.GetStringId("server_browser"),
                        },
                    }
                },
                new GuiDatasourceDefinition.DatasourceElementBlock()
                {
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>()
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue()
                        {
                            Name = CacheContext.StringTable.GetStringId("name"),
                            Value = CacheContext.StringTable.GetStringId("campaign"),
                        },
                    }
                },
                new GuiDatasourceDefinition.DatasourceElementBlock()
                {
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>()
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue()
                        {
                            Name = CacheContext.StringTable.GetStringId("name"),
                            Value = CacheContext.StringTable.GetStringId("multiplayer"),
                        },
                    }
                },
                new GuiDatasourceDefinition.DatasourceElementBlock()
                {
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>()
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue()
                        {
                            Name = CacheContext.StringTable.GetStringId("name"),
                            Value = CacheContext.StringTable.GetStringId("mapeditor"),
                        },
                    }
                },
                new GuiDatasourceDefinition.DatasourceElementBlock()
                {
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>()
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue()
                        {
                            Name = CacheContext.StringTable.GetStringId("name"),
                            Value = CacheContext.StringTable.GetStringId("survival"),
                        },
                    }
                },
                new GuiDatasourceDefinition.DatasourceElementBlock()
                {
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>()
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue()
                        {
                            Name = CacheContext.StringTable.GetStringId("name"),
                            Value = CacheContext.StringTable.GetStringId("customization"),
                        },
                    }
                },
                new GuiDatasourceDefinition.DatasourceElementBlock()
                {
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>()
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue()
                        {
                            Name = CacheContext.StringTable.GetStringId("name"),
                            Value = CacheContext.StringTable.GetStringId("eldewrito_settings"),
                        },
                    }
                },
                new GuiDatasourceDefinition.DatasourceElementBlock()
                {
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>()
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue()
                        {
                            Name = CacheContext.StringTable.GetStringId("name"),
                            Value = CacheContext.StringTable.GetStringId("exit"),
                        },
                    }
                },
            };
            CacheContext.Serialize(Stream, tag, dsrc);
        }
    }
}
