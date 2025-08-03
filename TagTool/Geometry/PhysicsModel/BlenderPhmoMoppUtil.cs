using TagTool.Cache;
using TagTool.Common;
using TagTool.Havok;
using TagTool.IO;
using TagTool.Tags;
using JsonMoppNet;
using System.IO;
using TagTool.Serialization;

namespace TagTool.Geometry
{

    /// <summary>
    /// Utilities for generating moppcode from jsonPhmoExporter json data.
    /// </summary>
    class BlenderPhmoMoppUtil
    {

        /// <summary>
        /// GenerateForBlenderPhmoJsonFile
        /// </summary>
        /// <param name="jsonFPath">Path to the JSON file containing blender exported using the jsonPhmoExporter plugin.</param>
        /// <returns>A memory stream with Havok 6.5.0 moppcode block</returns>
        public static MemoryStream GenerateForBlenderPhmoJsonFile(string jsonFPath)
        {
            StreamReader sr = new StreamReader(jsonFPath);
            string jsonString = sr.ReadToEnd();
            return GenerateForBlenderPhmoJson(jsonString);
        }

        /// <summary>
        /// GenerateForBlenderPhmoJson
        /// </summary>
        /// <param name="jsonString">String containing blender exported JSON using the jsonPhmoExporter plugin.</param>
        /// <returns>A memory stream with Havok 6.5.0 moppcode block</returns>
        public static MemoryStream GenerateForBlenderPhmoJson(string jsonString)
        {
            JsonToMopp jtm = new JsonToMopp();
            MemoryStream moppStream = jtm.CreateMopp(jsonString);
            moppStream.Position = 0;
            TagHkpMoppCode resource = SynthesizeMoppBlock(moppStream);

            MemoryStream outStream = null;

        #if !DEBUG
            try
            {
        #endif
                var resourceWriter = new EndianWriter(new MemoryStream(), EndianFormat.LittleEndian);
                var dataContext = new DataSerializationContext(null, resourceWriter);
                var block = dataContext.CreateBlock();
                var info = TagStructure.GetTagStructureInfo(resource.GetType(), CacheVersion.HaloOnline235640, CachePlatform.Original);

                new TagSerializer(CacheVersion.HaloOnline235640, CachePlatform.Original).Serialize(dataContext, resource);

                block.Stream.Position = 0;
                outStream = block.Stream;
        #if !DEBUG
            }
            catch
            {
                return null;
            }
        #endif

            outStream.Position = 48; //position of Data member. Data will be inlined
            moppStream.CopyTo(outStream); //remainder of moppStream is mopp program
            outStream.Position = 0;
            return outStream; //this is the one with serialized data in it
        }

        /// <summary>
        /// Creates a CollisionMoppCode instance using data from the moppstream
        /// </summary>
        /// <param name="moppStream">A havok 6.5.0 moppcode block</param>
        /// <returns></returns>
        private static TagHkpMoppCode SynthesizeMoppBlock(MemoryStream moppStream)
        {
            BinaryReader binaryReader = new BinaryReader(moppStream);
            TagHkpMoppCode resource = new TagHkpMoppCode()
            {
                ReferencedObject = new HkpReferencedObject { ReferenceCount = 0x80 },
                Info = new CodeInfo { Offset = new RealVector4d(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle())},
                ArrayBase = new HkArrayBase { CapacityAndFlags = binaryReader.ReadUInt32() },
            };

            resource.ArrayBase.Size = resource.ArrayBase.CapacityAndFlags;

            return resource;
        }
    }
}
