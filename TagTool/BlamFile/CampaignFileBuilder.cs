using System.Collections.Generic;
using System.Linq;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.BlamFile
{
    public class CampaignFileBuilder
    {
        public GameCache Cache { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public CampaignFileBuilder(GameCache cache)
        {
            Cache = cache;
        }

        public Blf GenerateCampaignBlf(bool includeMapIds) 
        {
            var campaignBlf = new Blf(Cache.Version, Cache.Platform)
            {
                ContentFlags = BlfFileContentFlags.StartOfFile | BlfFileContentFlags.EndOfFile | BlfFileContentFlags.Campaign,

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

                Campaign = new BlfCampaign
                {
                    Signature = "cmpn",
                    Length = (int)TagStructure.GetStructureSize(typeof(BlfCampaign), Cache.Version, Cache.Platform),
                    MajorVersion = 1,
                    MinorVersion = 1,
                    CampaignId = 1,

                    Names = Enumerable.Repeat(new CampaignNameUnicode32 { Name = Name }, 12).ToArray(),
                    Descriptions = Enumerable.Repeat(new NameUnicode128 { Name = Description }, 12).ToArray(),

                    MapIds = includeMapIds ? GetMapIds() : new int[64],
                },
            };

            return campaignBlf;
        }

        public int[] GetMapIds()
        {
            var singlePlayerMapIds = new List<int>();
            var outputBuffer = new int[64];

            if (Cache is GameCacheHaloOnline)
            {
                foreach (var scenario in Cache.TagCache.FindAllInGroup("scnr"))
                {
                    using (var stream = Cache.OpenCacheRead())
                    {
                        var scnr = Cache.Deserialize<Scenario>(stream, scenario);

                        if (scnr.MapType == ScenarioMapType.SinglePlayer)
                            singlePlayerMapIds.Add(scnr.MapId);
                    }
                }
            }
            else if (Cache is GameCacheModPackage)
            {
                var modCache = Cache as GameCacheModPackage;

                for (int i = 0; i < modCache.BaseModPackage.GetTagCacheCount(); i++)
                {
                    modCache.SetActiveTagCache(i);

                    var tagCacheStream = modCache.OpenCacheRead();

                    foreach (var scenario in modCache.TagCache.FindAllInGroup("scnr"))
                    {
                        var scnr = Cache.Deserialize<Scenario>(tagCacheStream, scenario);

                        if (scnr.MapType == ScenarioMapType.SinglePlayer)
                            singlePlayerMapIds.Add(scnr.MapId);
                    }
                }
            }

            singlePlayerMapIds.CopyTo(outputBuffer);

            return outputBuffer;
        }
    }
}
