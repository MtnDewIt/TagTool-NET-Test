﻿using TagTool.Cache;
using TagTool.Tags;
using static TagTool.Tags.TagFieldFlags;

namespace TagTool.Geometry
{
    /// <summary>
    /// Defines an index buffer in model data.
    /// </summary>
    [TagStructure(Size = 0x18, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0x1C, MinVersion = CacheVersion.HaloReach)]
    [TagStructure(Size = 0x20, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
    public class IndexBufferDefinition : TagStructure
    {
        /// <summary>
        /// The primitive type to use for the index buffer.
        /// </summary>
        public IndexBufferFormat Format;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public int Unknown;

        /// <summary>
        /// The reference to the data for the index buffer.
        /// </summary>
        [TagField(DataAlign = 0x4)]
        public TagData Data;

        [TagField(Flags = Padding, Length = 8, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
        public byte[] Unused;
    }
}
