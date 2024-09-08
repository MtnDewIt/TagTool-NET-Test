using TagTool.Tags;

namespace TagTool.MtnDewIt.BlamFiles
{
    public enum GameVariantEngineType : int
    {
        Base = 0,
        CaptureTheFlag,
        Slayer,
        Oddball,
        KingOfTheHill,
        Sandbox,
        Vip,
        Juggernaut,
        Territories,
        Assault,
        Infection,
    }

    [TagStructure(Size = 0x264)]
    public class GameVariantData : TagStructure 
    {
        public GameVariantEngineType GameVariantType;

        public GameVariantBase Variant;
    }
}