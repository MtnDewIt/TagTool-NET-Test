namespace TagTool.Cache
{
    public enum CacheFileSharedFileType : int 
    {
        None = -1,
        Ui,
        Multiplayer,
        Singleplayer,
        Count
    }

    public enum CacheFileSharedFileTypeMS23 : int
    {
        None = -1,
        Ui,
        Resources,
        Textures,
        TexturesB,
        Audio,
        Video,
        Count
    }

    public enum CacheFileSharedFileTypeHO : int
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
