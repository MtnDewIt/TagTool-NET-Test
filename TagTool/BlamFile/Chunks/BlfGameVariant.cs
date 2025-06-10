using System.IO;
using TagTool.BlamFile.GameVariants;
using TagTool.Cache;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;
using TagTool.Tags.Definitions.Common;

namespace TagTool.BlamFile.Chunks
{

    [TagStructure(Size = 0x264, Align = 0x1)]
    public class BlfGameVariant : BlfChunkHeader
    {
        public GameEngineType GameVariantType;

        public uint VTablePointer;

        public uint VariantChecksum;

        [TagField(Length = 32, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public string VariantName;

        public ContentItemMetadata Metadata;

        public GameVariantBase Variant;

        public static BlfGameVariant Decode(EndianReader reader, TagDeserializer deserializer, DataSerializationContext dataContext) 
        {
            var gameVariant = new BlfGameVariant();

            gameVariant.Signature = reader.ReadTag();
            gameVariant.Length = reader.ReadInt32();
            gameVariant.MajorVersion = reader.ReadInt16();
            gameVariant.MinorVersion = reader.ReadInt16();
            gameVariant.GameVariantType = (GameEngineType)reader.ReadInt32();
            gameVariant.VTablePointer = reader.ReadUInt32();
            gameVariant.VariantChecksum = reader.ReadUInt32();
            gameVariant.VariantName = reader.ReadString(32);
            gameVariant.Metadata = deserializer.Deserialize<ContentItemMetadata>(dataContext);

            switch (gameVariant.GameVariantType)
            {
                case GameEngineType.CaptureTheFlag:
                    gameVariant.Variant = deserializer.Deserialize<GameVariantCtf>(dataContext);
                    break;
                case GameEngineType.Slayer:
                    gameVariant.Variant = deserializer.Deserialize<GameVariantSlayer>(dataContext);
                    break;
                case GameEngineType.Oddball:
                    gameVariant.Variant = deserializer.Deserialize<GameVariantOddball>(dataContext);
                    break;
                case GameEngineType.KingOfTheHill:
                    gameVariant.Variant = deserializer.Deserialize<GameVariantKing>(dataContext);
                    break;
                case GameEngineType.Sandbox:
                    gameVariant.Variant = deserializer.Deserialize<GameVariantSandbox>(dataContext);
                    break;
                case GameEngineType.Vip:
                    gameVariant.Variant = deserializer.Deserialize<GameVariantVip>(dataContext);
                    break;
                case GameEngineType.Juggernaut:
                    gameVariant.Variant = deserializer.Deserialize<GameVariantJuggernaut>(dataContext);
                    break;
                case GameEngineType.Territories:
                    gameVariant.Variant = deserializer.Deserialize<GameVariantTerritories>(dataContext);
                    break;
                case GameEngineType.Assault:
                    gameVariant.Variant = deserializer.Deserialize<GameVariantAssault>(dataContext);
                    break;
                case GameEngineType.Infection:
                    gameVariant.Variant = deserializer.Deserialize<GameVariantInfection>(dataContext);
                    break;
            }

            return gameVariant;
        }

        public static void Encode(EndianWriter writer, TagSerializer serializer, DataSerializationContext dataContext, BlfGameVariant gameVariant) 
        {
            switch (gameVariant.GameVariantType)
            {
                case GameEngineType.CaptureTheFlag:
                    gameVariant.Variant = gameVariant.Variant as GameVariantCtf;
                    break;
                case GameEngineType.Slayer:
                    gameVariant.Variant = gameVariant.Variant as GameVariantSlayer;
                    break;
                case GameEngineType.Oddball:
                    gameVariant.Variant = gameVariant.Variant as GameVariantOddball;
                    break;
                case GameEngineType.KingOfTheHill:
                    gameVariant.Variant = gameVariant.Variant as GameVariantKing;
                    break;
                case GameEngineType.Sandbox:
                    gameVariant.Variant = gameVariant.Variant as GameVariantSandbox;
                    break;
                case GameEngineType.Vip:
                    gameVariant.Variant = gameVariant.Variant as GameVariantVip;
                    break;
                case GameEngineType.Juggernaut:
                    gameVariant.Variant = gameVariant.Variant as GameVariantJuggernaut;
                    break;
                case GameEngineType.Territories:
                    gameVariant.Variant = gameVariant.Variant as GameVariantTerritories;
                    break;
                case GameEngineType.Assault:
                    gameVariant.Variant = gameVariant.Variant as GameVariantAssault;
                    break;
                case GameEngineType.Infection:
                    gameVariant.Variant = gameVariant.Variant as GameVariantInfection;
                    break;
            }

            serializer.Serialize(dataContext, gameVariant);
        }
    }
}
