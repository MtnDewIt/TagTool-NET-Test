using System;
using System.IO;

namespace TagTool
{
    public static class DirectoryPaths
    {
        public static readonly string Base = AppContext.BaseDirectory;
        public static readonly string Tools = Path.Combine(Base, "tools");
        public static readonly string Data = Path.Combine(Base, "data");
    }
}
