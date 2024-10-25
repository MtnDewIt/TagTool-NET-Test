using Newtonsoft.Json;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.BlamFile.MCC
{
    public class MapInfoBuilder 
    {
        private GameCache Cache;

        public MapInfoBuilder(GameCache cache)
        {
            Cache = cache;
        }

        public void GetMapInfo(object mapInfo, BlfScenario scenario, Scenario scnr)
        {
            switch (mapInfo)
            {
                case CampaignMapInfo campaignMapInfo:
                    campaignMapInfo.ConvertCampaignMapInfo(scenario, scnr);
                    break;

                case MultiplayerMapInfo multiplayerMapInfo:
                    multiplayerMapInfo.ConvertMultiplayerMapInfo(scenario, scnr);
                    break;

                case FirefightMapInfo firefightMapInfo:
                    firefightMapInfo.ConvertFirefightMapInfo(scenario, scnr);
                    break;
            }
        }

        public Blf GenerateMapInfo(Stream stream, CachedTag scenario, string mapInfoPath, string modInfoPath)
        {
            var jsonData = File.ReadAllText(modInfoPath);
            var modInfo = JsonConvert.DeserializeObject<ModInfo>(jsonData);
            var mapInfoList = modInfo.GetMapInfoList(mapInfoPath);

            foreach (var mapInfo in mapInfoList)
            {
                if (scenario.Name.EndsWith(mapInfo.Key))
                {
                    var scnr = Cache.Deserialize<Scenario>(stream, scenario);

                    var mapBlf = new Blf(Cache.Version, Cache.Platform)
                    {
                        ContentFlags = BlfFileContentFlags.StartOfFile | BlfFileContentFlags.EndOfFile | BlfFileContentFlags.Scenario,

                        StartOfFile = new BlfChunkStartOfFile
                        {
                            Signature = "_blf",
                            Length = (int)TagStructure.GetStructureSize(typeof(BlfChunkStartOfFile), Cache.Version, Cache.Platform),
                            MajorVersion = 1,
                            MinorVersion = 2,
                            ByteOrderMarker = -2,
                        },

                        EndOfFile = new BlfChunkEndOfFile
                        {
                            Signature = "_eof",
                            Length = (int)TagStructure.GetStructureSize(typeof(BlfChunkEndOfFile), Cache.Version, Cache.Platform),
                            MajorVersion = 1,
                            MinorVersion = 2
                        },

                        Scenario = new BlfScenario
                        {
                            Signature = "levl",
                            Length = (int)TagStructure.GetStructureSize(typeof(BlfScenario), Cache.Version, Cache.Platform),
                            MajorVersion = 3,
                            MinorVersion = 1,
                            Names = Enumerable.Repeat(new NameUnicode32 { Name = "" }, 12).ToArray(),
                            Descriptions = Enumerable.Repeat(new NameUnicode128 { Name = "" }, 12).ToArray(),
                            Insertions = Enumerable.Repeat(new BlfScenarioInsertion { Names = Enumerable.Repeat(new NameUnicode32 { Name = "" }, 12).ToArray(), Descriptions = Enumerable.Repeat(new NameUnicode128 { Name = "" }, 12).ToArray() }, 9).ToArray(),
                        },
                    };

                    GetMapInfo(mapInfo.Value, mapBlf.Scenario, scnr);

                    return mapBlf;
                }
            }

            return null;
        }
    }
}
