using TagTool.Tags;

namespace TagTool.MtnDewIt.BlamFiles
{
    public enum GameEngineType : int
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
        public GameEngineType GameVariantType;

        // Takes the union of the following values:
        //public GameVariantBase BaseVariant;
        //public GameVariantCtf CtfVariant;
        //public GameVariantSlayer SlayerVariant;
        //public GameVariantOddball OddballVariant;
        //public GameVariantKing KingVariant;
        //public GameVariantSandbox SandboxVariant;
        //public GameVariantVip VipVariant;
        //public GameVariantJuggernaut JuggernautVariant;
        //public GameVariantTerritories TerritoriesVariant;
        //public GameVariantAssault AssaultVariant;
        //public GameVariantInfection InfectionVariant;
    }
}