using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Tags;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_characters_monitor_monitor_editor_biped : TagFile
    {
        public objects_characters_monitor_monitor_editor_biped(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Biped>($@"objects\characters\monitor\monitor_editor");
            var bipd = CacheContext.Deserialize<Biped>(Stream, tag);
            bipd.Functions = new List<GameObject.Function> 
            {
                new GameObject.Function
                {
                    Flags = GameObject.Function.ObjectFunctionFlags.None,
                    ImportName = CacheContext.StringTable.GetStringId($@"mouth_aperture"),
                    ExportName = CacheContext.StringTable.GetStringId($@"talking"),
                    DefaultFunction = new TagFunction
                    {
                        Data = new byte[]
                        {
                            0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x48, 0xE1, 0xFA, 0x3E, 0x00, 0x00, 0x00, 0x3F, 0x14, 0x00,
                            0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                            0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                            0x00, 0x00,
                        },
                    },
                },
                new GameObject.Function
                {
                    Flags = GameObject.Function.ObjectFunctionFlags.AlwaysActive,
                    ImportName = CacheContext.StringTable.GetStringId($@"flying_speed"),
                    ExportName = CacheContext.StringTable.GetStringId($@"audio_move"),
                    DefaultFunction = new TagFunction
                    {
                        Data = new byte[]
                        {
                            0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x48, 0xE1, 0xFA, 0x3E, 0x00, 0x00, 0x00, 0x3F, 0x14, 0x00,
                            0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                            0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                            0x00, 0x00,
                        },
                    },
                },
                new GameObject.Function
                {
                    Flags = GameObject.Function.ObjectFunctionFlags.AlwaysActive,
                    ImportName = CacheContext.StringTable.GetStringId($@"flying_speed"),
                    ExportName = CacheContext.StringTable.GetStringId($@"audio_amb"),
                    DefaultFunction = new TagFunction
                    {
                        Data = new byte[]
                        {
                            0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x48, 0xE1, 0xFA, 0x3E, 0x00, 0x00, 0x00, 0x3F, 0x14, 0x00,
                            0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                            0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                            0x00, 0x00,
                        },
                    },
                },
            };
            bipd.CrouchingCameraFunction = new TagFunction
            {
                Data = new byte[] 
                {
                    0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14, 0x00,
                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                    0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                    0x00, 0x00,
                }
            };
            CacheContext.Serialize(Stream, tag, bipd);
        }
    }
}
