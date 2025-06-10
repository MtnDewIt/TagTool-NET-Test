namespace TagTool.Common
{
    public enum GameSecondarySkull : short
    {
        Assassin,
        Blind,
        Superman,
        BirthdayParty,
        Daddy,
        ThirdPerson,
        DirectorsCut
    }

    public enum GameSecondarySkullFlags : short
    {
        None = 0,
        Assassin = 1 << 0,
        Blind = 1 << 1,
        Superman = 1 << 2,
        BirthdayParty = 1 << 3,
        Daddy = 1 << 4,
        ThirdPerson = 1 << 5,
        DirectorsCut = 1 << 6
    }
}