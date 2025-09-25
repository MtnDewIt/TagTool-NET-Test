namespace TagTool.Cache
{
    public enum SharedResourceDatabaseType : sbyte
    {
        Invalid = -1,
        MainMenu,
        Multiplayer,
        Campaign,

        Count
    }

    public enum SharedResourceDatabaseTypeMCC : sbyte
    {
        Invalid = -1,
        MainMenu,
        Multiplayer,
        Campaign,
        Sounds,

        Count
    }

    public enum SharedResourceDatabaseTypeEDOld : sbyte 
    {
        Invalid = -1,
        Ui,
        Resources,
        Textures,
        TexturesB,
        Audio,
        Video,

        Count
    }

    public enum SharedResourceDatabaseTypeEDNew : sbyte
    {
        None = -1,
        Ui,
        Resources,
        Textures,
        TexturesB,
        Audio,
        Video,
        RenderModels,
        Lightmaps,

        Count
    }
}
