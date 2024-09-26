using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.IO;
using TagTool.JSON.Objects;
using TagTool.JSON.Handlers;
using System;

namespace TagTool.Commands.JSON
{
    public class GenerateBlfObjectCommand : Command
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;
        private string ExportPath = $@"maps\info";

        public GenerateBlfObjectCommand(GameCache cache, GameCacheHaloOnline cacheContext) : base
        (
            false,
            "GenerateBlfObject",
            "Generates a JSON blf object file based on the specified blf file",

            "GenerateBlfObject <File_Path>",
            "Generates a JSON blf object file based on the specified blf file"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override object Execute(List<string> args)
        {
            var file = new FileInfo(args[0]);
            var blfData = new Blf(Cache.Version, Cache.Platform);

            var fileName = Path.GetFileNameWithoutExtension(file.Name);
            var fileExtension = file.Extension.TrimStart('.');

            // Wrapping the whole thing in a using statement probably isn't the best idea
            using (var stream = file.OpenRead())
            {
                var reader = new EndianReader(stream);

                var format = GetEndianFormat(reader);

                switch (file.Extension) 
                {
                    case ".mapinfo":
                        switch (reader.Length)
                        {
                            case 0x4E91:
                                blfData = new Blf(CacheVersion.Halo3Retail, Cache.Platform);
                                break;
                            case 0x9A01:
                                blfData = new Blf(CacheVersion.Halo3ODST, Cache.Platform);
                                break;
                            case 0xCDD9:
                                blfData = new Blf(CacheVersion.HaloReach, Cache.Platform);
                                break;
                            default:
                                blfData = new Blf(Cache.Version, Cache.Platform);
                                break;
                        }
                        break;
                    case ".map":
                        switch (format)
                        {
                            case EndianFormat.BigEndian:
                                switch (reader.Length)
                                {
                                    // May need to add extra cases as the EOF chunk size differs slightly for some reason
                                    case 0xE1E9:
                                    case 0xE1F0:
                                        blfData = new Blf(CacheVersion.Halo3Retail, Cache.Platform);
                                        break;
                                    default:
                                        blfData = new Blf(Cache.Version, Cache.Platform);
                                        break;
                                }
                                break;
                            case EndianFormat.LittleEndian:
                                blfData = new Blf(CacheVersion.HaloOnlineED, Cache.Platform);
                                break;
                            default:
                                blfData = new Blf(Cache.Version, Cache.Platform);
                                break;
                        }
                        break;
                    case ".campaign":
                        ExportPath = $@"data\levels";
                        break;
                    default:
                        switch (format)
                        {
                            case EndianFormat.BigEndian:
                                blfData = new Blf(CacheVersion.Halo3Retail, Cache.Platform);
                                break;
                            case EndianFormat.LittleEndian:
                                blfData = new Blf(CacheVersion.HaloOnlineED, Cache.Platform);
                                break;
                            default:
                                blfData = new Blf(Cache.Version, Cache.Platform);
                                break;
                        }
                        break;
                }

                blfData.Read(reader);

                var blfObject = new BlfObject()
                {
                    FileName = fileName,
                    FileType = fileExtension,
                    Blf = blfData,
                };

                var handler = new BlfObjectHandler(blfData.Version, blfData.CachePlatform);

                var jsonData = handler.Serialize(blfObject);

                var fileInfo = new FileInfo(Path.Combine(ExportPath, $"{fileName}.json"));

                if (!fileInfo.Directory.Exists)
                {
                    fileInfo.Directory.Create();
                }

                File.WriteAllText(Path.Combine(ExportPath, $"{fileName}.json"), jsonData);
            }

            return true;
        }

        public EndianFormat GetEndianFormat(EndianReader reader)
        {
            reader.Format = EndianFormat.LittleEndian;
            var startOfFile = reader.Position;
            reader.SeekTo(startOfFile + 0xC);
            if (reader.ReadInt16() == -2)
            {
                reader.SeekTo(startOfFile);
                return EndianFormat.LittleEndian;
            }
            else
            {
                reader.SeekTo(startOfFile + 0xC);
                reader.Format = EndianFormat.BigEndian;
                if (reader.ReadInt16() == -2)
                {
                    reader.SeekTo(startOfFile);
                    return EndianFormat.BigEndian;
                }
                else
                {
                    reader.SeekTo(startOfFile);
                    throw new Exception("Invalid BOM found in BLF start of file chunk");
                }
            }
        }
    }
}