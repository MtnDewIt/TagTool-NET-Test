namespace TagTool.Common
{
    public enum GamePrimarySkull : short
    {
        Iron,
        BlackEye,
        ToughLuck,
        Catch,
        Fog,
        Famine,
        Thunderstorm,
        Tilt,
        Mythic
    }

    public enum GamePrimarySkullFlags : short
    {
        None = 0,
        Iron = 1 << 0,
        BlackEye = 1 << 1,
        ToughLuck = 1 << 2,
        Catch = 1 << 3,
        Fog = 1 << 4,
        Famine = 1 << 5,
        Thunderstorm = 1 << 6,
        Tilt = 1 << 7,
        Mythic = 1 << 8
    }
}