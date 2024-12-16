using TagTool.Commands;

namespace TagTool.JSON 
{
    public class JSONFileTree
    {
        public static readonly string JSONBasePath = $@"{Program.TagToolDirectory}\Tools\JSON";

        public static readonly string JSONBinPath = $@"{Program.TagToolDirectory}\Tools\JSON\bin";
        public static readonly string JSONTagMappingPath = $@"{Program.TagToolDirectory}\Tools\JSON\bin\mappings";
        public static readonly string JSONTagTablePath = $@"{Program.TagToolDirectory}\Tools\JSON\bin\tags";
        public static readonly string JSONStringTablePath = $@"{Program.TagToolDirectory}\Tools\JSON\bin\strings";

        public static readonly string JSONCommandPath = $@"{Program.TagToolDirectory}\Tools\JSON\commands";
        public static readonly string JSONGenerateCachePath = $@"{Program.TagToolDirectory}\Tools\JSON\commands\generatecache";
        public static readonly string JSONGenerateDonkeyCachePath = $@"{Program.TagToolDirectory}\Tools\JSON\commands\generatedonkeycache";
        public static readonly string JSONUpdateShaderDataPath = $@"{Program.TagToolDirectory}\Tools\JSON\commands\updateshaderdata";
    }
}