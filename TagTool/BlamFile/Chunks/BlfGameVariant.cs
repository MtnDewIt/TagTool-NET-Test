using System;
using System.IO;
using TagTool.BlamFile.Chunks.GameVariants;
using TagTool.BlamFile.Chunks.Metadata;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;
using TagTool.Tags.Definitions.Common;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0x264, Align = 0x1)]
    public class BlfGameVariant : BlfChunkHeader
    {
        [TagField(Length = 0x14, MinVersion = CacheVersion.HaloReach)]
        public byte[] Hash;

        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public GameEngineType GameVariantType;

        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public uint VTablePointer;

        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public uint VariantChecksum;

        [TagField(Length = 32, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public string VariantName;

        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public ContentItemMetadata Metadata;

        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public GameVariantBase Variant;

        public static BlfGameVariant Decode(EndianReader reader, TagDeserializer deserializer, DataSerializationContext dataContext, bool packed) 
        {
            var gameVariant = new BlfGameVariant();

            gameVariant.Signature = reader.ReadTag();
            gameVariant.Length = reader.ReadInt32();
            gameVariant.MajorVersion = reader.ReadInt16();
            gameVariant.MinorVersion = reader.ReadInt16();

            if (deserializer.Version == CacheVersion.HaloReach)
            {
                // TODO: Figure out reach game variant structs
                gameVariant.Hash = reader.ReadBytes(0x14);

                var variantSize = gameVariant.Length - 0x20;

                var buffer = new byte[variantSize];

                for (int i = 0; i < variantSize; i++)
                {
                    buffer[i] = reader.ReadByte();
                }

                new TagToolWarning("Reach Game Variants Not Supported. Skipping...");
            }
            else if (deserializer.Version == CacheVersion.Halo4 || deserializer.Version == CacheVersion.Halo2AMP)
            {
                // TODO: Figure out gen 4 game variant structs
                gameVariant.Hash = reader.ReadBytes(0x14);

                var variantSize = gameVariant.Length - 0x20;

                var buffer = new byte[variantSize];

                for (int i = 0; i < variantSize; i++)
                {
                    buffer[i] = reader.ReadByte();
                }

                new TagToolWarning("Gen 4 Game Variants Not Supported. Skipping...");
            }
            else if (deserializer.Version >= CacheVersion.Halo3Retail && deserializer.Version <= CacheVersion.HaloOnline700123)
            {
                if (!packed)
                {
                    gameVariant.GameVariantType = (GameEngineType)reader.ReadInt32();
                    gameVariant.VTablePointer = reader.ReadUInt32();
                    gameVariant.VariantChecksum = reader.ReadUInt32();

                    if (CacheVersionDetection.IsBetween(deserializer.Version, CacheVersion.HaloOnlineED, CacheVersion.HaloOnline700123))
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
                }
                else
                {
                    var variantSize = gameVariant.Length - 0xC;

                    var buffer = new byte[variantSize];

                    for (int i = 0; i < variantSize; i++)
                    {
                        buffer[i] = reader.ReadByte();
                    }

                    var stream = new MemoryStream(buffer);
                    var bitStream = new BitStream(stream);

                    gameVariant.GameVariantType = (GameEngineType)bitStream.ReadUnsigned(4);
                    gameVariant.Metadata = ContentItemMetadata.Decode(bitStream);

                    switch (gameVariant.GameVariantType) 
                    {
                        case GameEngineType.CaptureTheFlag:
                            gameVariant.Variant = GameVariantCtf.Decode(bitStream);
                            break;
                        case GameEngineType.Slayer:
                            gameVariant.Variant = GameVariantSlayer.Decode(bitStream);
                            break;
                        case GameEngineType.Oddball:
                            gameVariant.Variant = GameVariantOddball.Decode(bitStream);
                            break;
                        case GameEngineType.KingOfTheHill:
                            gameVariant.Variant = GameVariantKing.Decode(bitStream);
                            break;
                        case GameEngineType.Sandbox:
                            gameVariant.Variant = GameVariantSandbox.Decode(bitStream);
                            break;
                        case GameEngineType.Vip:
                            gameVariant.Variant = GameVariantVip.Decode(bitStream);
                            break;
                        case GameEngineType.Juggernaut:
                            gameVariant.Variant = GameVariantJuggernaut.Decode(bitStream);
                            break;
                        case GameEngineType.Territories:
                            gameVariant.Variant = GameVariantTerritories.Decode(bitStream);
                            break;
                        case GameEngineType.Assault:
                            gameVariant.Variant = GameVariantAssault.Decode(bitStream);
                            break;
                        case GameEngineType.Infection:
                            gameVariant.Variant = GameVariantInfection.Decode(bitStream);
                            break;
                    }
                }
            }

            return gameVariant;
        }

        public static void Encode(EndianWriter writer, TagSerializer serializer, DataSerializationContext dataContext, BlfGameVariant gameVariant, bool packed) 
        {
            if (!packed) 
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
                return;
            }

            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}
