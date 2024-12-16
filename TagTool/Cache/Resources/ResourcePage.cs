using System;
using TagTool.Tags;

namespace TagTool.Cache.Resources
{
    [TagStructure(Size = 0x58, Align = 0x8, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0x58, Align = 0x8, MinVersion = CacheVersion.HaloReach)]
    [TagStructure(Size = 0x24, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline106708)]
    [TagStructure(Size = 0x28, MinVersion = CacheVersion.HaloOnline235640, MaxVersion = CacheVersion.HaloOnline700123)]
    public class ResourcePage : TagStructure
	{
        public short Salt;

        [TagField(Gen = CacheGeneration.Third)]
        public XboxPageFlags XboxFlags;

        /// <summary>
        /// Gets or sets flags containing information about where the resource is located.
        /// </summary>
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline106708)]
        public OldRawPageFlags OldFlags;

        /// <summary>
        /// Gets or sets flags containing information about where the resource is located.
        /// </summary>
        [TagField(MinVersion = CacheVersion.HaloOnline235640, MaxVersion = CacheVersion.HaloOnline700123)]
        public NewRawPageFlags NewFlags;

        public sbyte CompressionCodecIndex;

        [TagField(Gen = CacheGeneration.Third)]
        public short SharedCacheIndex;

        [TagField(Gen = CacheGeneration.Third)]
        public short SharedCacheLocationIndex;

        [TagField(MinVersion = CacheVersion.HaloOnline235640, MaxVersion = CacheVersion.HaloOnline700123)]
        public int Unknown1;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public int Index;

        [TagField(Gen = CacheGeneration.Third)]
        public int BlockIndex;

        public uint CompressedBlockSize;
        public uint UncompressedBlockSize;
        public int CrcChecksum;

        [TagField(Length = 20, Gen = CacheGeneration.Third)]
        public byte[] EntireBufferHash;

        [TagField(Length = 20, Gen = CacheGeneration.Third)]
        public byte[] FirstChunkHash;

        [TagField(Length = 20, Gen = CacheGeneration.Third)]
        public byte[] LastChunkHash;

        public short ResourceReferenceCount;
        public short SubpageTableIndex;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public uint Unknown2;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public uint Unknown3;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public uint Unknown4;

        [Flags]
        public enum XboxPageFlags : byte 
        {
            None = 0,
            ValidChecksum = 1 << 0,
            SharedAndRequired = 1 << 1,
            DVDOnlySharedAndRequired = 1 << 2,
            DVDOnlyAndRequired = 1 << 3,
            ReferencedByCacheFileHeader = 1 << 4,
            OnlyFullValidChecksum = 1 << 5,
            SharedAndPreOptimized = 1 << 6,
        }
    }

    /// <summary>
    /// Flags related to the location and storage of the resource data.
    /// Only for 1.106708.
    /// </summary>
    [Flags]
    public enum OldRawPageFlags : byte
    {
        /// <summary>
        /// Indicates that the resource's checksum should be validated.
        /// </summary>
        UseChecksum = 1 << 0,

        /// <summary>
        /// Indicates that the resource is in resources.dat.
        /// </summary>
        InResources = 1 << 1,

        /// <summary>
        /// Indicates that the resource is in textures.dat.
        /// </summary>
        InTextures = 1 << 2,

        /// <summary>
        /// Indicates that the resource is in textures_b.dat.
        /// </summary>
        InTexturesB = 1 << 3,

        /// <summary>
        /// Indicates that the resource is in audio.dat.
        /// </summary>
        InAudio = 1 << 4,

        /// <summary>
        /// Indicates that the resource is in resources_b.dat.
        /// </summary>
        InResourcesB = 1 << 5,

        /// <summary>
        /// Indicates that the resource is in mods.dat.
        /// </summary>
        InMods = 1 << 6,

        /// <summary>
        /// Indicates that the resource's checksum should be validated.
        /// Alternate flag for <see cref="UseChecksum"/>.
        /// </summary>
        UseChecksum2 = 1 << 7,

        /// <summary>
        /// Mask for the location part of the flags.
        /// </summary>
        LocationMask = 0x3E,
    }

    /// <summary>
    /// Flags related to the location and storage of the resource data.
    /// Only for versions 1.235640 and newer.
    /// </summary>
    [Flags]
    public enum NewRawPageFlags : byte
    {
        /// <summary>
        /// Indicates that the resource's checksum should be validated.
        /// </summary>
        UseChecksum = 1 << 0,

        /// <summary>
        /// Indicates that the resource is in resources.dat.
        /// </summary>
        InResources = 1 << 1,

        /// <summary>
        /// Indicates that the resource is in textures.dat.
        /// </summary>
        InTextures = 1 << 2,

        /// <summary>
        /// Indicates that the resource is in textures_b.dat.
        /// </summary>
        InTexturesB = 1 << 3,

        /// <summary>
        /// Indicates that the resource is in audio.dat.
        /// </summary>
        InAudio = 1 << 4,

        /// <summary>
        /// Indicates that the resource is in resources_b.dat.
        /// </summary>
        InResourcesB = 1 << 5,

        /// <summary>
        /// Indicates that the resource is in render_models.dat.
        /// </summary>
        InRenderModels = 1 << 6,

        /// <summary>
        /// Indicates that the resource is in lightmaps.dat.
        /// </summary>
        InLightmaps = 1 << 7,

        /// <summary>
        /// Mask for the location part of the flags.
        /// </summary>
        LocationMask = 0xFE,
    }
}
