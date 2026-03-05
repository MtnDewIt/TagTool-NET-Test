using TagTool.Cache;

namespace TagTool.Scripting
{
    public struct GlobalInfo
    {
        public HsType Type;
        public string Name;

        public GlobalInfo(HsType type, string name)
        {
            Type = type;
            Name = name;
        }


    }
}
