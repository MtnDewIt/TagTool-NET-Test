using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public class ModIdentifierInfo
        {
            public Guid ModGuid;
            public HostedModInfo HostedModIds;
        }

        public class HostedModInfo 
        {
            public long SteamWorkshopId;
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

        public Dictionary<string, object> GetMapInfoList(string path) 
        {
            var mapInfoTable = new Dictionary<string, object>();

            if (GameModContents.HasCampaign) 
            {
                var jsonData = File.ReadAllText(Path.Combine(path, "CampaignInfo.json"));
                var campaignInfo = JsonConvert.DeserializeObject<CampaignInfo>(jsonData);

                var campaignInfoTable = campaignInfo.GetCampaignMapInfo(path);

                foreach (var campaignMapInfo in campaignInfoTable)
                    mapInfoTable.Add(campaignMapInfo.Key, campaignMapInfo.Value);
            }

            if (GameModContents.MultiplayerMaps != null) 
            {
                var multiplayerInfoTable = GetMultiplayerMapInfo(path);

                foreach (var multiplayerMapInfo in multiplayerInfoTable)
                    mapInfoTable.Add(multiplayerMapInfo.Key, multiplayerMapInfo.Value);
            }

            if (GameModContents.FirefightMaps != null) 
            {
                var firefightInfoTable = GetFirefightMapInfo(path);

                foreach (var firefightMapInfo in firefightInfoTable)
                    mapInfoTable.Add(firefightMapInfo.Key, firefightMapInfo.Value);
            }

            return mapInfoTable;
        }

        public Dictionary<string, object> GetMultiplayerMapInfo(string path) 
        {
            var mapInfoTable = new Dictionary<string, object>();

            foreach (var map in GameModContents.MultiplayerMaps)
            {
                var mapInfo = File.ReadAllText(Path.Combine(path, map));
                var multiplayerMapInfo = JsonConvert.DeserializeObject<MultiplayerMapInfo>(mapInfo);
                var multiplayerMapName = multiplayerMapInfo.ScenarioFile.Split("/").Last();

                mapInfoTable.Add(multiplayerMapName, multiplayerMapInfo);
            }

            return mapInfoTable;
        }

        public Dictionary<string, object> GetFirefightMapInfo(string path) 
        {
            var mapInfoTable = new Dictionary<string, object>();

            foreach (var map in GameModContents.FirefightMaps)
            {
                var mapInfo = File.ReadAllText(Path.Combine(path, map));
                var firefightMapInfo = JsonConvert.DeserializeObject<FirefightMapInfo>(mapInfo);
                var firefightMapName = firefightMapInfo.ScenarioFile.Split("/").Last();

                mapInfoTable.Add(firefightMapName, firefightMapInfo);
            }

            return mapInfoTable;
        }
    }
}