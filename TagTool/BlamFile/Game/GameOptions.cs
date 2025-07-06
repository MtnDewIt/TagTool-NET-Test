using System.Runtime.InteropServices;
using TagTool.BlamFile.Chunks.GameVariants;
using TagTool.BlamFile.Chunks.MapVariants;
using TagTool.BlamFile.Chunks.Metadata;
using TagTool.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;
using TagTool.Tags.Definitions.Common;

namespace TagTool.BlamFile.Game
{
    [TagStructure(Size = 0xF810)]
    public class GameOptions : TagStructure
    {
        public GameModeType GameMode;
        public GameSimulationType GameSimulation;
        public GameNetworkType GameNetworkType;
        public ushort GameTickRate;
        public ulong GameInstance;
        public int RandomSeed;
        public GameLanguage Language;
        public int DeterminismValue;
        public int CampaignId;
        public int MapId;

        [TagField(Length = 0x104, CharSet = CharSet.Ansi)]
        public string ScenarioPath;

        public short InitialZoneSetIndex;
        public bool LoadLevelOnly;
        public byte DumpMachineIndex;
        public bool DumpObjectLog;
        public bool DumpRandomSeeds;
        public bool PlaytestMode;

        [TagField(Length = 0x1, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;

        public GamePlaybackType GamePlayback;
        public bool RecordSavedFilm;

        [TagField(Length = 0x1, Flags = TagFieldFlags.Padding)]
        public byte[] Padding2;

        public int PlaybackStartTick;
        public int PlaybackLengthInTicks;
        public GameEngineDifficulty CampaignDifficulty;
        public short CampaignInsertionPoint;
        public GameMetagameScoring CampaignMetagameScoring;
        public bool CampaignMetagameEnabled;
        public bool CampaignAllowPersistentStorage;
        public GamePrimarySkullFlags32 CampaignActivePrimarySkulls;
        public GameSecondarySkullFlags32 CampaignActiveSecondarySkulls;
        public CampaignArmaments CampaignArmaments;
        public bool MatchmadeGame;

        [TagField(Length = 0x7, Flags = TagFieldFlags.Padding)]
        public byte[] Padding3;

        public GameMatchmakingOptions GameMatchmakingOptions;

        public GameEngineType GameVariantType;
        public uint VTablePointer;
        public uint VariantChecksum;
        public ContentItemMetadata Metadata;
        public GameVariantBase MultiplayerVariant;

        [TagField(Length = 0x4, Flags = TagFieldFlags.Padding)]
        public byte[] Padding4;

        public MapVariant MapVariant;
        public GameMachineOptions Machines;

        [TagField(Length = 0x4, Flags = TagFieldFlags.Padding)]
        public byte[] Padding5;

        [TagField(Length = 0x10)]
        public GamePlayerOptions[] Players;

        public static GameOptions Decode(EndianReader reader, TagDeserializer deserializer, DataSerializationContext dataContext) 
        {
            var options = new GameOptions();

            options.GameMode = (GameModeType)reader.ReadInt32();
            options.GameSimulation = (GameSimulationType)reader.ReadByte();
            options.GameNetworkType = (GameNetworkType)reader.ReadByte();
            options.GameTickRate = reader.ReadUInt16();
            options.GameInstance = reader.ReadUInt64();
            options.RandomSeed = reader.ReadInt32();
            options.Language = (GameLanguage)reader.ReadInt32();
            options.DeterminismValue = reader.ReadInt32();
            options.CampaignId = reader.ReadInt32();
            options.MapId = reader.ReadInt32();
            options.ScenarioPath = reader.ReadString(0x104);
            options.InitialZoneSetIndex = reader.ReadInt16();
            options.LoadLevelOnly = reader.ReadBoolean();
            options.DumpMachineIndex = reader.ReadByte();
            options.DumpObjectLog = reader.ReadBoolean();
            options.DumpRandomSeeds = reader.ReadBoolean();
            options.PlaytestMode = reader.ReadBoolean();
            options.Padding1 = reader.ReadBytes(0x1);
            options.GamePlayback = (GamePlaybackType)reader.ReadInt16();
            options.RecordSavedFilm = reader.ReadBoolean();
            options.Padding2 = reader.ReadBytes(0x1);
            options.PlaybackStartTick = reader.ReadInt32();
            options.PlaybackLengthInTicks = reader.ReadInt32();
            options.CampaignDifficulty = (GameEngineDifficulty)reader.ReadInt16();
            options.CampaignInsertionPoint = reader.ReadInt16();
            options.CampaignMetagameScoring = (GameMetagameScoring)reader.ReadInt16();
            options.CampaignMetagameEnabled = reader.ReadBoolean();
            options.CampaignAllowPersistentStorage = reader.ReadBoolean();
            options.CampaignActivePrimarySkulls = (GamePrimarySkullFlags32)reader.ReadInt32();
            options.CampaignActiveSecondarySkulls = (GameSecondarySkullFlags32)reader.ReadInt32();
            options.CampaignArmaments = deserializer.Deserialize<CampaignArmaments>(dataContext);
            options.MatchmadeGame = reader.ReadBoolean();
            options.Padding3 = reader.ReadBytes(0x7);
            options.GameMatchmakingOptions = deserializer.Deserialize<GameMatchmakingOptions>(dataContext);

            options.GameVariantType = (GameEngineType)reader.ReadInt32();
            options.VTablePointer = reader.ReadUInt32();
            options.VariantChecksum = reader.ReadUInt32();
            options.Metadata = deserializer.Deserialize<ContentItemMetadata>(dataContext);

            switch (options.GameVariantType)
            {
                case GameEngineType.CaptureTheFlag:
                    options.MultiplayerVariant = deserializer.Deserialize<GameVariantCtf>(dataContext);
                    break;
                case GameEngineType.Slayer:
                    options.MultiplayerVariant = deserializer.Deserialize<GameVariantSlayer>(dataContext);
                    break;
                case GameEngineType.Oddball:
                    options.MultiplayerVariant = deserializer.Deserialize<GameVariantOddball>(dataContext);
                    break;
                case GameEngineType.KingOfTheHill:
                    options.MultiplayerVariant = deserializer.Deserialize<GameVariantKing>(dataContext);
                    break;
                case GameEngineType.Sandbox:
                    options.MultiplayerVariant = deserializer.Deserialize<GameVariantSandbox>(dataContext);
                    break;
                case GameEngineType.Vip:
                    options.MultiplayerVariant = deserializer.Deserialize<GameVariantVip>(dataContext);
                    break;
                case GameEngineType.Juggernaut:
                    options.MultiplayerVariant = deserializer.Deserialize<GameVariantJuggernaut>(dataContext);
                    break;
                case GameEngineType.Territories:
                    options.MultiplayerVariant = deserializer.Deserialize<GameVariantTerritories>(dataContext);
                    break;
                case GameEngineType.Assault:
                    options.MultiplayerVariant = deserializer.Deserialize<GameVariantAssault>(dataContext);
                    break;
                case GameEngineType.Infection:
                    options.MultiplayerVariant = deserializer.Deserialize<GameVariantInfection>(dataContext);
                    break;
            }

            options.Padding4 = reader.ReadBytes(0x4);
            options.MapVariant = deserializer.Deserialize<MapVariant>(dataContext);
            options.Machines = deserializer.Deserialize<GameMachineOptions>(dataContext);
            options.Padding5 = reader.ReadBytes(0x4);

            options.Players = new GamePlayerOptions[0x10];
            for (int i = 0; i < 0x10; i++)
            {
                options.Players[i] = deserializer.Deserialize<GamePlayerOptions>(dataContext);
            }

            return options;
        }

        public static void Encode(GameOptions options) 
        {
            switch (options.GameVariantType)
            {
                case GameEngineType.CaptureTheFlag:
                    options.MultiplayerVariant = options.MultiplayerVariant as GameVariantCtf;
                    break;
                case GameEngineType.Slayer:
                    options.MultiplayerVariant = options.MultiplayerVariant as GameVariantSlayer;
                    break;
                case GameEngineType.Oddball:
                    options.MultiplayerVariant = options.MultiplayerVariant as GameVariantOddball;
                    break;
                case GameEngineType.KingOfTheHill:
                    options.MultiplayerVariant = options.MultiplayerVariant as GameVariantKing;
                    break;
                case GameEngineType.Sandbox:
                    options.MultiplayerVariant = options.MultiplayerVariant as GameVariantSandbox;
                    break;
                case GameEngineType.Vip:
                    options.MultiplayerVariant = options.MultiplayerVariant as GameVariantVip;
                    break;
                case GameEngineType.Juggernaut:
                    options.MultiplayerVariant = options.MultiplayerVariant as GameVariantJuggernaut;
                    break;
                case GameEngineType.Territories:
                    options.MultiplayerVariant = options.MultiplayerVariant as GameVariantTerritories;
                    break;
                case GameEngineType.Assault:
                    options.MultiplayerVariant = options.MultiplayerVariant as GameVariantAssault;
                    break;
                case GameEngineType.Infection:
                    options.MultiplayerVariant = options.MultiplayerVariant as GameVariantInfection;
                    break;
            }
        }
    }
}
