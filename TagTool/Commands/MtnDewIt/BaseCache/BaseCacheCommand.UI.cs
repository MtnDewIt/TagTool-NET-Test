using System.Collections.Generic;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Tags
{
    partial class BaseCacheCommand : Command
    {
        public void applyUIPatches() 
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    if (tag.IsInGroup("dsrc") && tag.Name == $@"ui\halox\main_menu\main_menu_list")
                    {
                        var dsrc = CacheContext.Deserialize<GuiDatasourceDefinition>(stream, tag);
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
                        CacheContext.Serialize(stream, tag, dsrc);
                    }
                }
            }
        }
    }
}