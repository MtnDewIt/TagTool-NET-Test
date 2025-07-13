using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Scripting.Definitions;

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
        public static IScriptDefinitions Create(CacheVersion version, CachePlatform platform)
        {
            switch (version)
            {
                case CacheVersion.Halo3Retail when platform == CachePlatform.Original:
                    return new HS_Halo3Retail();

                case CacheVersion.Halo3Retail when platform == CachePlatform.MCC:
                    return new HS_Halo3Retail_MCC();

                case CacheVersion.Halo3ODST:
                    return new HS_Halo3ODST();

                case CacheVersion.HaloOnline106708:
                case CacheVersion.HaloOnlineED:
                    return new HS_HaloOnlineED();
            }

            return null;
        }
    }
}
