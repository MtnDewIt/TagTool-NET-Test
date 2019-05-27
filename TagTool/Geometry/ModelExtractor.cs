﻿using TagTool.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assimp;
using TagTool.Tags.Definitions;
using TagTool.Cache;
using TagTool.Serialization;
using TagTool.Tags.Resources;

namespace TagTool.Geometry
{
    // TODO: Add multi vertex stream support, mainly for water vertices
    public class ModelExtractor
    {
        private readonly Scene Scene;
        private readonly HaloOnlineCacheContext CacheContext;
        private Dictionary<int, int> MeshMapping;   //key is the absolute subMesh index, value is the Scene.Meshes index

        private readonly RenderModel RenderModel;
        private readonly ModelAnimationGraph ModelAnimationGraph;
        private readonly CollisionModel CollisionModel;
        private readonly PhysicsModel PhysicsModel;

        private readonly RenderGeometryApiResourceDefinition RenderModelResourceDefinition;
        private Stream RenderModelResourceStream;

        public ModelExtractor(HaloOnlineCacheContext cacheContext, RenderModel renderModel, ModelAnimationGraph animationGraph, CollisionModel collisionModel, PhysicsModel physicsModel)
        {
            Scene = new Scene();
            CacheContext = cacheContext;
            MeshMapping = new Dictionary<int, int>();
            RenderModel = renderModel;
            ModelAnimationGraph = animationGraph;
            CollisionModel = collisionModel;
            PhysicsModel = physicsModel;

            // Deserialize the render_model resource
            var resourceContext = new ResourceSerializationContext(CacheContext, RenderModel.Geometry.Resource);
            RenderModelResourceDefinition = CacheContext.Deserializer.Deserialize<RenderGeometryApiResourceDefinition>(resourceContext);
            RenderModelResourceStream = new MemoryStream();
            CacheContext.ExtractResource(RenderModel.Geometry.Resource, RenderModelResourceStream);
            // Add more deserialization as required here
        }

        ~ModelExtractor()
        {
            RenderModelResourceStream.Close();
        }

        public bool ExportCollada(FileInfo file)
        {
            // temp hack to allow export to collada: add a single unused bone. Once skeletons are added remove hack.
            Scene.Meshes[0].Bones.Add(new Bone("test", new Matrix3x3(), new VertexWeight[Scene.Meshes[0].VertexCount]));

            using (var exporter = new AssimpContext())
            {
                return exporter.ExportFile(Scene, file.FullName, "collada", PostProcessSteps.ValidateDataStructure);    //collada or obj
            }
        }

        public bool ExportObject(FileInfo file)
        {
            using (var exporter = new AssimpContext())
            {
                return exporter.ExportFile(Scene, file.FullName, "obj", PostProcessSteps.ValidateDataStructure);
            }
        }

        /// <summary>
        /// Build a node structure and mesh from the render model.
        /// </summary>
        /// <returns></returns>
        public void ExtractRenderModel()
        {
            Scene.RootNode = new Node(CacheContext.GetString(RenderModel.Name));
            foreach (var region in RenderModel.Regions)
            {
                Scene.RootNode.Children.Add(ExtractRegion(region));
            }

            // add empty materials
            for (int i = 0; i < RenderModel.Materials.Count(); i++)
            {
                Scene.Materials.Add(new Material());
            }
        }

        /// <summary>
        /// Build a node structure from a single region of the render model
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        private Node ExtractRegion(RenderModel.Region region)
        {
            Node node = new Node(CacheContext.GetString(region.Name));
            foreach(var permutation in region.Permutations)
            {
                node.Children.Add(ExtractPermutation(permutation));
            }
            return node;
        }

        /// <summary>
        /// Build a node/add mesh from a single permutation of the render model.
        /// </summary>
        /// <param name="permutation"></param>
        /// <returns></returns>
        private Node ExtractPermutation(RenderModel.Region.Permutation permutation)
        {
            Node node = new Node(CacheContext.GetString(permutation.Name));

            /* Disabled until assimpNet / assimp is fixed 
            // No need to add another layer of nodes since there is only one mesh
            if(permutation.MeshCount == 1)
            {
                var mesh = RenderModel.Geometry.Meshes[permutation.MeshIndex];
                for(int i =0; i< mesh.Parts.Count; i++)
                {
                    int absSubMeshIndex = GetAbsoluteIndexSubMesh(permutation.MeshIndex) + i;
                    if (MeshMapping.ContainsKey(absSubMeshIndex))
                    {
                        MeshMapping.TryGetValue(absSubMeshIndex, out int mesh_index);
                        node.MeshIndices.Add(mesh_index);
                    }
                    else
                    {
                        int value = ExtractMeshPart(permutation.MeshIndex, i);
                        MeshMapping.Add(absSubMeshIndex, value);
                        node.MeshIndices.Add(value);
                    }
                }
            }
            // build a layer of nodes for each mesh
            else
            {
                
            }*/

            for (int i = 0; i < permutation.MeshCount; i++)
            {
                node.Children.Add(ExtractMesh(i + permutation.MeshIndex));
            }
            return node;
        }

        /// <summary>
        /// Create a node for multi mesh permutation
        /// </summary>
        /// <param name="mesh_index"></param>
        /// <returns></returns>
        private Node ExtractMesh(int mesh_index)
        {
            Node node = new Node($"mesh_{mesh_index}");
            var mesh = RenderModel.Geometry.Meshes[mesh_index];
            for (int i = 0; i < mesh.Parts.Count; i++)
            {
                Node newNode = new Node($"part_{i}");
                int absSubMeshIndex = GetAbsoluteIndexSubMesh(mesh_index) + i;
                if (MeshMapping.ContainsKey(absSubMeshIndex))
                {
                    MeshMapping.TryGetValue(absSubMeshIndex, out int sceneMeshIndex);
                    newNode.MeshIndices.Add(sceneMeshIndex);
                }
                else
                {
                    int sceneMeshIndex = ExtractMeshPart(mesh_index, i);
                    MeshMapping.Add(absSubMeshIndex, sceneMeshIndex);
                    newNode.MeshIndices.Add(sceneMeshIndex);
                }
                node.Children.Add(newNode);
            }
            return node;
        }

        /// <summary>
        /// Create a mesh and return index in scene mesh list
        /// </summary>
        /// <param name="meshIndex"></param>
        /// <param name="subMeshIndex"></param>
        /// <returns></returns>
        private int ExtractMeshPart(int meshIndex, int subMeshIndex)
        {
            int index = Scene.MeshCount;
            var mesh = ExtractMeshPartGeometry(meshIndex, subMeshIndex);
            mesh.Name = $"part_{index}";
            Scene.Meshes.Add(mesh);
            return index;
        }

        // TODO: There is a bug with faces, some clipping and mission sections
        private Assimp.Mesh ExtractMeshPartGeometry(int meshIndex, int partIndex)
        {
            // create new assimp mesh

            Assimp.Mesh mesh = new Assimp.Mesh();

            // Add support for multiple UV layers
            var textureCoordinateIndex = 0;
            mesh.UVComponentCount[textureCoordinateIndex] = 2;
           
            // prepare vertex extraction
            var meshReader = new MeshReader(CacheContext.Version, RenderModel.Geometry.Meshes[meshIndex], RenderModelResourceDefinition);
            var vertexCompressor = new VertexCompressor(RenderModel.Geometry.Compression[0]);

            var geometryMesh = RenderModel.Geometry.Meshes[meshIndex];
            var geometryPart = geometryMesh.Parts[partIndex];

            mesh.MaterialIndex = geometryPart.MaterialIndex;

            // optimize this part to not load and decompress all mesh vertices everytime
            var vertices = ReadVertices(meshReader, RenderModelResourceStream);
            DecompressVertices(vertices, vertexCompressor);
            // get offset in the list of all vertices for the mesh
            var vertexOffset = GetPartVertexOffset(meshIndex, partIndex);

            //vertices = vertices.GetRange(vertexOffset, geometryPart.VertexCount);

            var indices = ReadIndices(meshReader, geometryPart, RenderModelResourceStream);

            var int_indices = indices.Select(b => (int)b).ToArray();

            var indexCount = indices.Length;

            if (indexCount == 0)
            {
                Console.WriteLine($"Failed to extract mesh, no indices.");
                return null;
            }

            // set index list, maybe require adjustment for vertex buffer offset
            
            mesh.SetIndices(int_indices, 3);

            for(int i = vertexOffset; i<vertexOffset + geometryPart.VertexCount; i++)
            {
                var vertex = vertices[i];
                mesh.Vertices.Add(vertex.Position);

                if (vertex.Normal != null)
                    mesh.Normals.Add(vertex.Normal);

                if (vertex.TexCoords != null)
                    mesh.TextureCoordinateChannels[textureCoordinateIndex].Add(vertex.TexCoords);

                if (vertex.Tangents != null)
                    mesh.Tangents.Add(vertex.Tangents);

                if (vertex.Binormals != null)
                    mesh.BiTangents.Add(vertex.Binormals);

                // Add skinned mesh support and more
            }
            
            // create faces

            mesh.Faces.AddRange(GenerateFaces(int_indices));

            return mesh;
        }

        private List<Face> GenerateFaces(int[] indices)
        {
            List<Face> faces = new List<Face>();
            for (int i = 0; i < indices.Length; i += 3)
            {
                var a = indices[i];
                var b = indices[i + 1];
                var c = indices[i + 2];
                if (a == b || b == c || a == c) // remove 2 vertex faces
                    continue;
                else
                    faces.Add(new Face(new int[] { a, b, c }));
            }
            return faces;
        }

        private int GetPartVertexOffset(int meshIndex, int partIndex)
        {
            var mesh = RenderModel.Geometry.Meshes[meshIndex];
            int vertexOffset = 0;
            for(int i =0; i< partIndex; i++)
            {
                vertexOffset += mesh.Parts[i].VertexCount;
            }
            return vertexOffset;
        }

        /// <summary>
        /// Get the absolute sub_mesh index from the flattened part list list.
        /// </summary>
        /// <param name="meshIndex"></param>
        /// <returns></returns>
        private int GetAbsoluteIndexSubMesh(int meshIndex)
        {
            int absIndex = 0;
            for (int i = 0; i < meshIndex; i++)
            {
                absIndex += RenderModel.Geometry.Meshes[i].Parts.Count;
            }
            return absIndex;
        }

        private static List<GenericVertex> ReadVertices(MeshReader reader, Stream resourceStream)
        {
            // Open a vertex reader on stream 0 (main vertex data)
            var mainBuffer = reader.VertexStreams[0];
            if (mainBuffer == null)
                return new List<GenericVertex>();

            var vertexReader = reader.OpenVertexStream(mainBuffer, resourceStream);

            switch (reader.Mesh.Type)
            {
                case VertexType.Rigid:
                    return ReadRigidVertices(vertexReader, mainBuffer.Count);
                case VertexType.Skinned:
                    return ReadSkinnedVertices(vertexReader, mainBuffer.Count);
                case VertexType.DualQuat:
                    return ReadDualQuatVertices(vertexReader, mainBuffer.Count);
                case VertexType.World:
                    return ReadWorldVertices(vertexReader, mainBuffer.Count);
                default:
                    throw new InvalidOperationException("Only Rigid, Skinned, DualQuat and World meshes are supported");
            }
        }

        /// <summary>
        /// Reads rigid vertices.
        /// </summary>
        /// <param name="reader">The vertex reader to read from.</param>
        /// <param name="count">The number of vertices to read.</param>
        /// <returns>The vertices that were read.</returns>
        private static List<GenericVertex> ReadRigidVertices(IVertexStream reader, int count)
        {
            var result = new List<GenericVertex>();
            for (var i = 0; i < count; i++)
            {
                var rigid = reader.ReadRigidVertex();
                result.Add(new GenericVertex
                {
                    Position = ToVector3D(rigid.Position),
                    Normal = ToVector3D(rigid.Normal),
                    TexCoords = ToVector3D(rigid.Texcoord),
                    Tangents = ToVector3D(rigid.Tangent),
                    Binormals = ToVector3D(rigid.Binormal)
                });
            }
            return result;
        }

        /// <summary>
        /// Reads skinned vertices.
        /// </summary>
        /// <param name="reader">The vertex reader to read from.</param>
        /// <param name="count">The number of vertices to read.</param>
        /// <returns>The vertices that were read.</returns>
        private static List<GenericVertex> ReadSkinnedVertices(IVertexStream reader, int count)
        {
            var result = new List<GenericVertex>();
            for (var i = 0; i < count; i++)
            {
                var skinned = reader.ReadSkinnedVertex();
                result.Add(new GenericVertex
                {
                    Position = ToVector3D(skinned.Position),
                    Normal = ToVector3D(skinned.Normal),
                    TexCoords = ToVector3D(skinned.Texcoord),
                    Weights = skinned.BlendWeights,
                    Indices = skinned.BlendIndices
                });
            }
            return result;
        }

        /// <summary>
        /// Reads dualquat vertices.
        /// </summary>
        /// <param name="reader">The vertex reader to read from.</param>
        /// <param name="count">The number of vertices to read.</param>
        /// <returns>The vertices that were read.</returns>
        private static List<GenericVertex> ReadDualQuatVertices(IVertexStream reader, int count)
        {
            var result = new List<GenericVertex>();
            for (var i = 0; i < count; i++)
            {
                var dualQuat = reader.ReadDualQuatVertex();
                result.Add(new GenericVertex
                {
                    Position = ToVector3D(dualQuat.Position),
                    Normal = ToVector3D(dualQuat.Normal),
                    TexCoords = ToVector3D(dualQuat.Texcoord),
                    Tangents = ToVector3D(dualQuat.Tangent),
                    Binormals = ToVector3D(dualQuat.Binormal)
                });
            }
            return result;
        }

        /// <summary>
        /// Reads world vertices.
        /// </summary>
        /// <param name="reader">The vertex reader to read from.</param>
        /// <param name="count">The number of vertices to read.</param>
        /// <returns>The vertices that were read.</returns>
        private static List<GenericVertex> ReadWorldVertices(IVertexStream reader, int count)
        {
            var result = new List<GenericVertex>();
            for (var i = 0; i < count; i++)
            {
                var world = reader.ReadWorldVertex();
                result.Add(new GenericVertex
                {
                    Position = ToVector3D(world.Position),
                    Normal = ToVector3D(world.Normal),
                    TexCoords = ToVector3D(world.Texcoord),
                    Tangents = ToVector3D(world.Tangent),
                    Binormals = ToVector3D(world.Binormal)
                });
            }
            return result;
        }

        /// <summary>
        /// Decompresses vertex data in-place.
        /// </summary>
        /// <param name="vertices">The vertices to decompress in-place.</param>
        /// <param name="compressor">The compressor to use.</param>
        private static void DecompressVertices(IEnumerable<GenericVertex> vertices, VertexCompressor compressor)
        {
            if (compressor == null)
                return;

            foreach (var vertex in vertices)
            {
                vertex.Position = ToVector3D(compressor.DecompressPosition(new RealQuaternion(vertex.Position.X, vertex.Position.Y, vertex.Position.Z, 1)));
                vertex.TexCoords = ToVector3D(compressor.DecompressUv(new RealVector2d(vertex.TexCoords.X, vertex.TexCoords.Y)));
            }
        }

        /// <summary>
        /// Reads the index buffer data and converts it into a triangle list if necessary.
        /// </summary>
        /// <param name="reader">The mesh reader to use.</param>
        /// <param name="part">The mesh part to read.</param>
        /// <param name="resourceStream">A stream open on the resource data.</param>
        /// <returns>The index buffer converted into a triangle list.</returns>
        private static ushort[] ReadIndices(MeshReader reader, Mesh.Part part, Stream resourceStream)
        {
            // Use index buffer 0
            var indexBuffer = reader.IndexBuffers[0];
            if (indexBuffer == null)
                throw new InvalidOperationException("Index buffer 0 is null");

            // Read the indices
            var indexStream = reader.OpenIndexBufferStream(indexBuffer, resourceStream);
            indexStream.Position = part.FirstIndexOld;
            switch (indexBuffer.Format)
            {
                case IndexBufferFormat.TriangleList:
                    return indexStream.ReadIndices(part.IndexCountOld);
                case IndexBufferFormat.TriangleStrip:
                    return indexStream.ReadTriangleStrip(part.IndexCountOld);
                default:
                    throw new InvalidOperationException("Unsupported index buffer type: " + indexBuffer.Format);
            }
        }

        private static Vector3D ToVector3D(RealVector3d v)
        {
            return new Vector3D(v.I, v.J, v.K);
        }

        private static Vector3D ToVector3D(RealQuaternion q)
        {
            return new Vector3D(q.I, q.J, q.K);
        }

        private static Vector3D ToVector3D(RealVector2d u)
        {
            return new Vector3D(u.I, u.J, 0);
        }

        private static Vector2D ToVector2D(RealVector2d u)
        {
            return new Vector2D(u.I, u.J);
        }

        /// <summary>
        /// Generic vertex class that contains all the possible information to generate meshes
        /// </summary>
        private class GenericVertex
        {
            public Vector3D Position { get; set; }
            public Vector3D Normal { get; set; }
            public Vector3D TexCoords { get; set; }
            public Vector3D Tangents { get; set; }
            public Vector3D Binormals { get; set; }
            public byte[] Indices { get; set; }
            public float[] Weights { get; set; }
        }
    }
}
