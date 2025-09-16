using System;
using System.IO;
using TagTool.Cache;
using TagTool.Scripting;
using TagTool.Tags.Definitions;

namespace TagTool.Porting.Eldorado
{
    public partial class PortingContextEldorado
    {
        private Scenario ConvertScenario(Stream cacheStream, Stream blamCacheStream, Scenario scnr)
        {
            // Fixup script tag references
            foreach (HsSyntaxNode node in scnr.ScriptExpressions)
            {
                if (node.Flags.HasFlag(HsSyntaxNodeFlags.Primitive)
                    && node.ValueType >= HsType.Sound
                    && node.ValueType <= HsType.AnyTagNotResolving)
                {
                    int srcTagIndex = BitConverter.ToInt32(node.Data, 0);
                    int destTagIndex = -1;
                    if (srcTagIndex != -1)
                    {
                        CachedTag srcTag = BlamCacheHO.TagCacheEldorado.Tags[srcTagIndex];
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
