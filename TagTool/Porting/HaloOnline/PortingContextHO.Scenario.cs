using System;
using System.IO;
using TagTool.Cache;
using TagTool.Scripting;
using TagTool.Tags.Definitions;

namespace TagTool.Porting.HaloOnline
{
    public partial class PortingContextHO
    {
        private Scenario ConvertScenario(Stream cacheStream, Stream blamCacheStream, Scenario scnr)
        {
            // Fixup script tag references
            foreach (HsSyntaxNode node in scnr.ScriptExpressions)
            {
                if (node.Flags.HasFlag(HsSyntaxNodeFlags.Primitive)
                    && node.ValueType.HaloOnline >= HsType.HaloOnlineValue.Sound
                    && node.ValueType.HaloOnline <= HsType.HaloOnlineValue.AnyTagNotResolving)
                {
                    int srcTagIndex = BitConverter.ToInt32(node.Data, 0);
                    int destTagIndex = -1;
                    if (srcTagIndex != -1)
                    {
                        CachedTag srcTag = BlamCacheHO.TagCacheGenHO.Tags[srcTagIndex];
                        CachedTag destTag = ConvertTag(cacheStream, blamCacheStream, srcTag);
                        if (destTag != null)
                            destTagIndex = destTag.Index;
                    }
                    node.Data = BitConverter.GetBytes(destTagIndex);
                }
            }

            return scnr;
        }
    }
}
