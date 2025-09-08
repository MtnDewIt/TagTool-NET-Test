using System.IO;

namespace TagTool
{
    public static class DirectoryPaths
    {
        public static readonly string Base = Path.GetDirectoryName(typeof(DirectoryPaths).Assembly.Location);
        public static readonly string Tools = Path.Combine(Base, "tools");
        public static readonly string Data = Path.Combine(Base, "data");
    }
}
