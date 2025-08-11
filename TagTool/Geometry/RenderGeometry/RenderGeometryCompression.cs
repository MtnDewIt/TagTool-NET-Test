﻿using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;
using static TagTool.Tags.TagFieldFlags;

namespace TagTool.Geometry
{
    /// <summary>
    /// Contains information about how geometry is compressed.
    /// </summary>
    [TagStructure(Size = 0x38, MaxVersion = CacheVersion.Halo2PC)]
    [TagStructure(Size = 0x2C, MinVersion = CacheVersion.Halo3Beta, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Size = 0x34, MinVersion = CacheVersion.HaloReach)]
    public class RenderGeometryCompression : TagStructure
	{
        /// <summary>
        /// The flags of the geometry compression.
        /// </summary>
        [TagField(MinVersion = CacheVersion.Halo3Beta)]
        public RenderGeometryCompressionFlags Flags;

        [TagField(Flags = Padding, Length = 0x2, MinVersion = CacheVersion.Halo3Beta)]
        public byte[] Unused = new byte[2];

        /// <summary>
        /// The minimum X value in the uncompressed geometry.
        /// </summary>
        public Bounds<float> X;

        /// <summary>
        /// The minimum Y value in the uncompressed geometry.
        /// </summary>
        public Bounds<float> Y;

        /// <summary>
        /// The minimum Z value in the uncompressed geometry.
        /// </summary>
        public Bounds<float> Z;

        /// <summary>
        /// The minimum U value in the uncompressed geometry.
        /// </summary>
        public Bounds<float> U;

        /// <summary>
        /// The minimum V value in the uncompressed geometry.
        /// </summary>
        public Bounds<float> V;

        /// <summary>
        /// The minimum U value in the uncompressed geometry.
        /// </summary>
        [TagField(MaxVersion = CacheVersion.Halo2PC)]
        public Bounds<float> U2;

        /// <summary>
        /// The minimum V value in the uncompressed geometry.
        /// </summary>
        [TagField(MaxVersion = CacheVersion.Halo2PC)]
        public Bounds<float> V2;

        [TagField(Flags = Padding, Length = 0x8, MinVersion = CacheVersion.HaloReach)]
        public byte[] Unused0;
    }
}