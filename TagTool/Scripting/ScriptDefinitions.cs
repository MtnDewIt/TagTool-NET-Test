using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Common.Logging;

namespace TagTool.Scripting
{
    public interface IScriptDefinitions
    {
        IReadOnlyDictionary<int, string> ValueTypes { get; }
        IReadOnlyDictionary<int, string> Globals { get; }
        IReadOnlyDictionary<int, ScriptInfo> Scripts { get; }
    }

    public class ScriptDefinitionsFactory
    {
        private static readonly ConcurrentDictionary<(CacheVersion, CachePlatform), IScriptDefinitions> _cache = [];

        public static IScriptDefinitions Create(CacheVersion version, CachePlatform platform)
        {
            if (_cache.TryGetValue((version, platform), out IScriptDefinitions definitions))
                return definitions;

            string fileName = GetFileNameForVersion(version, platform);
            if (fileName == null)
                return null;

            string xmlFilePath = Path.Combine(DirectoryPaths.Data, $"hs\\definitions\\{fileName}.xml");
            if (!File.Exists(xmlFilePath))
            {
                Log.Warning($"Script definitions file not found \"{xmlFilePath}\"");
                return null;
            }

            definitions = new ScriptDefinitionsXml(xmlFilePath);
            _cache.TryAdd((version, platform), definitions);
            return definitions;
        }

        private static string GetFileNameForVersion(CacheVersion version, CachePlatform platform)
        {
            switch (version)
            {
                case CacheVersion.Halo2PC when platform == CachePlatform.MCC:
                    return "halo2_mcc";

                case CacheVersion.Halo3Retail when platform == CachePlatform.MCC:
                    return "halo3_mcc";

                case CacheVersion.Halo3ODST when platform == CachePlatform.MCC:
                    return "halo3_odst_mcc";

                case CacheVersion.HaloReach when platform == CachePlatform.MCC:
                    return "halo_reach_mcc";

                case CacheVersion.Halo2PC:
                    return "halo2_vista";

                case CacheVersion.Halo3Retail:
                    return "halo3";

                case CacheVersion.Halo3ODST:
                    return "halo3_odst";

                case CacheVersion.HaloReach:
                    return "halo_reach";

                case CacheVersion.Eldorado106708:
                case CacheVersion.EldoradoED:
                    return "halo_online_ed";
            }

            return null;
        }
    }
}
