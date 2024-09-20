using System;
using System.Collections.Generic;
using TagTool.Tags;

namespace TagTool.BlamFile.MCC
{
    public class ModInfo : TagStructure
    {
        public ModIdentifierInfo ModIdentifier;
        public VersionInfo ModVersion;
        public VersionInfo MinAppVersion;
        public VersionInfo MaxAppVersion;
        public GameEngine Engine;
        public LocalizedString Title;
        public LocalizedString Description;
        public InheritanceSource InheritSharedFiles;
        public ModContentInfo ModContents;
        public GameModContentInfo GameModContents;
    }

    public class ModIdentifierInfo
    {
        public Guid ModGuid;
    }

    public class VersionInfo
    {
        public int Major;
        public int Minor;
        public int Patch;
    }

    public enum GameEngine
    {
        Invalid = -1,
        Halo1 = 0,
        Halo2 = 1,
        Halo3 = 2,
        Halo4 = 3,
        Halo2A = 4,
        Halo3ODST = 5,
        HaloReach = 6,
        Count = 7,
    }

    public enum InheritanceSource
    {
        FromMCC = 0,
        FromExternalMod = 1,
        Disabled = 2,
        Count = 3,
    }

    public class ModContentInfo
    {
        public bool HasBackgroundVideos;
        public bool HasNameplates;
    }

    public class GameModContentInfo
    {
        public bool HasSharedFiles;
        public bool HasCampaign;
        public bool HasSpartanOps;
        public bool HasController;
        public List<string> MultiplayerMaps;
        public List<string> FirefightMaps;
    }
}