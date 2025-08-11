using TagTool.Cache;
using TagTool.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static TagTool.Tags.TagFieldFlags;

namespace TagTool.Tags.Definitions.Gen2
{
    [TagStructure(Name = "vertex_shader", Tag = "vrtx", Size = 0x10, Platform = CachePlatform.Original)]
    [TagStructure(Name = "vertex_shader", Tag = "vrtx", Size = 0x24, Platform = CachePlatform.MCC)]
    public class VertexShader : TagStructure
    {
        [TagField(Platform = CachePlatform.Original)]
        public PlatformValue Platform;
        [TagField(Length = 0x2, Flags = TagFieldFlags.Padding, Platform = CachePlatform.Original)]
        public byte[] Padding;
        [TagField(Platform = CachePlatform.MCC)]
        public List<VertexShaderClassificationBlock> GeometryClassificationsDX11;
        public List<VertexShaderClassificationBlock> GeometryClassifications;
        [TagField(Platform = CachePlatform.MCC)]
        public List<VertexShaderClassificationBlock> GeometryClassificationsXbox1;
        [TagField(Platform = CachePlatform.MCC)]
        public int OutputSwizzlesDX11;
        public int OutputSwizzles;
        [TagField(Platform = CachePlatform.MCC)]
        public int OutputSwizzlesXbox1;

        public enum PlatformValue : short
        {
            Pc,
            Xbox
        }
        
        [TagStructure(Size = 0x14, Platform = CachePlatform.Original)]
        [TagStructure(Size = 0x18, Platform = CachePlatform.MCC)]
        public class VertexShaderClassificationBlock : TagStructure
        {
            public PlatformUnsignedValue Pointer;
            public byte[] CompiledShader;
            public byte[] Code;
        }
    }
}

