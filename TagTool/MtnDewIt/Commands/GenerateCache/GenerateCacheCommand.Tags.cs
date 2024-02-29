using TagTool.MtnDewIt.Commands.GenerateCache.Tags;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command
    {
        public void UpdateTagData()
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                Cache.StringTable.Add($@"thunder_clap");
                Cache.StringTable.Add($@"fresh");
                Cache.StringTable.Add($@"orange_justice");
                Cache.StringTable.Add($@"electro_swing");
                Cache.SaveStrings();


            }
        }
    }
}