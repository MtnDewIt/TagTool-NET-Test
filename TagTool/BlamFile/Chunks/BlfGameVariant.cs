using System;
using System.IO;
using TagTool.BlamFile.Chunks.GameVariants;
using TagTool.BlamFile.Chunks.Metadata;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Common.Logging;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;
using TagTool.Tags.Definitions.Common;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0x264)]
    public class BlfGameVariant : BlfChunkHeader
    {
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public NetworkRequestHash Hash;

        [TagField(MaxVersion = CacheVersion.Eldorado700123)]
        public GameEngineType GameVariantType;

        [TagField(MaxVersion = CacheVersion.Eldorado700123)]
        public uint VTablePointer;

        [TagField(MaxVersion = CacheVersion.Eldorado700123)]
        public uint VariantChecksum;

        [TagField(Length = 32, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
        public string VariantName;

        [TagField(MaxVersion = CacheVersion.Eldorado700123)]
        public ContentItemMetadata Metadata;

        [TagField(MaxVersion = CacheVersion.Eldorado700123)]
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
                gameVariant.Hash = deserializer.Deserialize<NetworkRequestHash>(dataContext);

                var buffer = reader.ReadBytes(gameVariant.Length - 0x20);

                Log.Warning("Reach Game Variants Not Supported. Skipping...");
            }
            else if (deserializer.Version == CacheVersion.Halo4 || deserializer.Version == CacheVersion.Halo2AMP)
            {
                // TODO: Figure out gen 4 game variant structs
                gameVariant.Hash = deserializer.Deserialize<NetworkRequestHash>(dataContext);

                var buffer = reader.ReadBytes(gameVariant.Length - 0x20);

                Log.Warning("Gen 4 Game Variants Not Supported. Skipping...");
            }
            else if (CacheVersionDetection.IsBetween(deserializer.Version, CacheVersion.Halo3Retail, CacheVersion.Eldorado700123))
            {
                if (!packed)
                {
                    gameVariant.GameVariantType = (GameEngineType)reader.ReadInt32();
                    gameVariant.VTablePointer = reader.ReadUInt32();
                    gameVariant.VariantChecksum = reader.ReadUInt32();

                    if (CacheVersionDetection.IsBetween(deserializer.Version, CacheVersion.EldoradoED, CacheVersion.Eldorado700123))
                        gameVariant.VariantName = reader.ReadString(32);

                    gameVariant.Metadata = deserializer.Deserialize<ContentItemMetadata>(dataContext);

                    gameVariant.Variant = gameVariant.GameVariantType switch
                    {
                        GameEngineType.CaptureTheFlag => deserializer.Deserialize<GameVariantCtf>(dataContext),
                        GameEngineType.Slayer => deserializer.Deserialize<GameVariantSlayer>(dataContext),
                        GameEngineType.Oddball => deserializer.Deserialize<GameVariantOddball>(dataContext),
                        GameEngineType.KingOfTheHill => deserializer.Deserialize<GameVariantKing>(dataContext),
                        GameEngineType.Sandbox => deserializer.Deserialize<GameVariantSandbox>(dataContext),
                        GameEngineType.Vip => deserializer.Deserialize<GameVariantVip>(dataContext),
                        GameEngineType.Juggernaut => deserializer.Deserialize<GameVariantJuggernaut>(dataContext),
                        GameEngineType.Territories => deserializer.Deserialize<GameVariantTerritories>(dataContext),
                        GameEngineType.Assault => deserializer.Deserialize<GameVariantAssault>(dataContext),
                        GameEngineType.Infection => deserializer.Deserialize<GameVariantInfection>(dataContext),
                        _ => deserializer.Deserialize<GameVariantNone>(dataContext),
                    };
                }
                else
                {
                    var buffer = reader.ReadBytes(gameVariant.Length - 0xC);

                    var stream = new MemoryStream(buffer);
                    var bitStream = new BitStreamReader(stream);

                    gameVariant.GameVariantType = (GameEngineType)bitStream.ReadUnsigned(4);
                    gameVariant.Metadata = ContentItemMetadata.Decode(bitStream);

                    gameVariant.Variant = gameVariant.GameVariantType switch 
                    {
                        GameEngineType.CaptureTheFlag => GameVariantCtf.Decode(bitStream),
                        GameEngineType.Slayer => GameVariantSlayer.Decode(bitStream),
                        GameEngineType.Oddball => GameVariantOddball.Decode(bitStream),
                        GameEngineType.KingOfTheHill => GameVariantKing.Decode(bitStream),
                        GameEngineType.Sandbox => GameVariantSandbox.Decode(bitStream),
                        GameEngineType.Vip => GameVariantVip.Decode(bitStream),
                        GameEngineType.Juggernaut => GameVariantJuggernaut.Decode(bitStream),
                        GameEngineType.Territories => GameVariantTerritories.Decode(bitStream),
                        GameEngineType.Assault => GameVariantAssault.Decode(bitStream),
                        GameEngineType.Infection => GameVariantInfection.Decode(bitStream),
                        _ => deserializer.Deserialize<GameVariantNone>(dataContext),
                    };
                }
            }

            return gameVariant;
        }

        public static void Encode(EndianWriter writer, TagSerializer serializer, DataSerializationContext dataContext, BlfGameVariant gameVariant, bool packed) 
        {
            if (!packed && CacheVersionDetection.IsBetween(serializer.Version, CacheVersion.Halo3Retail, CacheVersion.Eldorado700123)) 
            {
                gameVariant.Variant = gameVariant.GameVariantType switch
                {
                    GameEngineType.CaptureTheFlag => gameVariant.Variant as GameVariantCtf,
                    GameEngineType.Slayer => gameVariant.Variant as GameVariantSlayer,
                    GameEngineType.Oddball => gameVariant.Variant as GameVariantOddball,
                    GameEngineType.KingOfTheHill => gameVariant.Variant as GameVariantKing,
                    GameEngineType.Sandbox => gameVariant.Variant as GameVariantSandbox,
                    GameEngineType.Vip => gameVariant.Variant as GameVariantVip,
                    GameEngineType.Juggernaut => gameVariant.Variant as GameVariantJuggernaut,
                    GameEngineType.Territories => gameVariant.Variant as GameVariantTerritories,
                    GameEngineType.Assault => gameVariant.Variant as GameVariantAssault,
                    GameEngineType.Infection => gameVariant.Variant as GameVariantInfection,
                    _ => gameVariant.Variant as GameVariantNone,
                };

                serializer.Serialize(dataContext, gameVariant);

                return;
            }

            writer.Write(gameVariant.Signature.Value);
            writer.Write(gameVariant.Length);
            writer.Write(gameVariant.MajorVersion);
            writer.Write(gameVariant.MinorVersion);

            if (serializer.Version == CacheVersion.HaloReach)
            {
                serializer.Serialize(dataContext, gameVariant.Hash);

                var buffer = new byte[gameVariant.Length - 0x20];

                var bitStream = new MemoryStream(buffer);
                var bitWriter = new BitStreamWriter(bitStream);

                Log.Warning("Reach Game Variants Not Supported. Skipping...");

                writer.Write(buffer);
            }
            else if (serializer.Version == CacheVersion.Halo4 || serializer.Version == CacheVersion.Halo2AMP)
            {
                serializer.Serialize(dataContext, gameVariant.Hash);

                var buffer = new byte[gameVariant.Length - 0x20];

                var bitStream = new MemoryStream(buffer);
                var bitWriter = new BitStreamWriter(bitStream);

                Log.Warning("Gen 4 Game Variants Not Supported. Skipping...");

                writer.Write(buffer);
            }
            else if (CacheVersionDetection.IsBetween(serializer.Version, CacheVersion.Halo3Retail, CacheVersion.Eldorado700123)) 
            {
                var buffer = new byte[gameVariant.Length - 0xC];

                var bitStream = new MemoryStream(buffer);
                var bitWriter = new BitStreamWriter(bitStream);

                writer.Write(buffer);
            }
        }
    }
}
