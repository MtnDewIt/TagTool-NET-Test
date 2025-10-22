using TagTool.Cache;
using static TagTool.Tags.TagFieldFlags;

namespace TagTool.Tags
{
    /// <summary>
    /// Points to a D3D-related object.
    /// </summary>
    [TagStructure(Size = 0xC)]
    public class TagStructureReference<TDefinition> : TagStructure
	{
        /// <summary>
        /// The definition data for the object.
        /// </summary>
        [TagField(Flags = Pointer)]
        public TDefinition Definition;

        /// <summary>
        /// The address of the object in memory.
        /// This should be set to 0 because it will be used at runtime.
        /// </summary>
        public uint RuntimeAddress;

        /// <summary>
        /// The address of the structure definition in memory.
        /// This should be set to 0 because it will be used at runtime.
        /// </summary>
        public uint DefinitionAddress;
    }


    public interface ID3DStructure
    {
        public CacheAddressType AddressType { get; set; }
        public object Definition { get; set; }
    }

    /// <summary>
    /// D3Dstructure, size is 0xC, enforced in the deserializer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [TagStructure(Size = 0xC)]
    public class D3DStructure<T> : TagStructure, ID3DStructure
    {
        public T Definition;
        public CacheAddressType AddressType = CacheAddressType.Definition;

        CacheAddressType ID3DStructure.AddressType { get => AddressType; set => AddressType = value; }
        object ID3DStructure.Definition { get => Definition; set => Definition = (T)value; }
    }
}
