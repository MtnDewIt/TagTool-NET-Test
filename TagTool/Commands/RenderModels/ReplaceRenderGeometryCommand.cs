using Assimp;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Commands.Common;
using TagTool.Geometry;
using TagTool.Tags.Definitions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TagTool.Commands.RenderModels
{
    class ReplaceRenderGeometryCommand : Command
    {
        private GameCache Cache { get; }
        private CachedTag Tag { get; }
        private RenderModel Definition { get; }

        public ReplaceRenderGeometryCommand(GameCache cache, CachedTag tag, RenderModel definition) :
            base(false,

                name:
                "ReplaceRenderGeometry",

                description:
                "Replaces the render_geometry of the current render_model tag.",

                usage:
                "ReplaceRenderGeometry <COLLADA or FBX Scene> [IndexBufferFormat]",

                examples:
                "ReplaceRenderGeometry d:\\model.dae trianglestrip\nReplaceRenderGeometry d:\\model.fbx trianglestrip",

                helpMessage:
                "- Replaces the render_geometry of the current render_model tag with geometry compiled from a COLLADA (.DAE) or FBX (.FBX) scene file.\n" +
                "- Your DAE or FBX file must contain a single mesh for every permutation.\n" +
                "- Name your meshes as {region}:{permutation} (e.g. hull:base).\n" +
                "- IndexBufferFormat is TriangleList unless TriangleStrip specified.")
        {
            Cache = cache;
            Tag = tag;
            Definition = definition;
        }

        public override object Execute(List<string> args)
        {
            Console.WriteLine();

            if (args.Count < 1 || args.Count > 2)
                return new TagToolError(CommandError.ArgCount);

            if (!Cache.TagCache.TryGetTag<Shader>(@"shaders\invalid", out var defaultShaderTag))
            {
                new TagToolWarning("shaders\\invalid.shader' not found!\n"
                    + "You will have to assign material shaders manually.");
            }

            var stringIdCount = Cache.StringTable.Count;

            var sceneFile = new FileInfo(args[0]);

            var indexBufferFormat = args.Count > 1 && args[1].ToLower() == "trianglestrip" ? IndexBufferFormat.TriangleStrip : IndexBufferFormat.TriangleList;

            if (!sceneFile.Exists)
                return new TagToolError(CommandError.FileNotFound);

            string extension = sceneFile.Extension.ToLower();
            if (extension != ".dae" && extension != ".fbx")
                return new TagToolError(CommandError.FileType, $"\"{sceneFile.FullName}\"");

            // Call ExecuteInternal with the appropriate parameters
            return ExecuteInternal(Cache, Tag, Definition, stringIdCount, sceneFile, indexBufferFormat);
        }

        public static object ExecuteInternal(GameCache Cache, CachedTag Tag, RenderModel Definition, int InitialStringIdCount, FileInfo SceneFile, IndexBufferFormat IndexBufferFormat)
        {
            Console.WriteLine();

            Scene scene;
            bool ShowTriangleStripWarning = false;

            if (!Cache.TagCache.TryGetTag<Shader>(@"shaders\invalid", out CachedTag defaultShaderTag))
            {
                new TagToolWarning("shaders\\invalid.shader' not found!\nYou will have to assign material shaders manually.");
            }

            using (AssimpContext importer = new AssimpContext())
            {
                importer.SetConfig(new Assimp.Configs.IntegerPropertyConfig("AI_CONFIG_PP_SLM_VERTEX_LIMIT", 131072));
                scene = importer.ImportFile(SceneFile.FullName,
                    PostProcessSteps.CalculateTangentSpace |
                    PostProcessSteps.GenerateNormals |
                    PostProcessSteps.SortByPrimitiveType |
                    PostProcessSteps.Triangulate |
                    PostProcessSteps.JoinIdenticalVertices);
            }

            RenderModelBuilder builder = new RenderModelBuilder(Cache);
            Dictionary<string, sbyte> nodes = new Dictionary<string, sbyte>();
            Dictionary<string, short> materialIndices = new Dictionary<string, short>();
            Dictionary<string, RenderMaterial> originalMaterialMap = new Dictionary<string, RenderMaterial>();
            bool usePerMeshNodeMapping = true;

            // Helper method to clean material names
            string CleanMaterialName(string name)
            {
                // Remove any suffix consisting of ) % = at the end of the string for H3EK shader naming support
                var suffixRegex = new Regex(@"[)%=]+$");
                name = suffixRegex.Replace(name, "");

                // Remove the first occurrence of _shaders_ and anything before it for extracted dae shader naming support
                var shaderRegex = new Regex(@".*?_shaders_");
                return shaderRegex.Replace(name, "").ToLower();
            }

            // Helper method to clean mesh names
            string CleanMeshName(string name)
            {
                var parts = name.Split(':');
                if (parts.Length > 2)
                {
                    return $"{parts[0]}:{parts[1]}";
                }
                return name;
            }

            // Map original materials
            foreach (var material in Definition.Materials)
            {
                var shaderTag = material.RenderMethod != null ? Cache.TagCache.GetTag(material.RenderMethod.Index) : null; // Ensure 'Index' is the correct property
                if (shaderTag != null)
                {
                    var shaderPath = shaderTag.Name;
                    var materialName = Path.GetFileNameWithoutExtension(shaderPath);
                    materialName = CleanMaterialName(materialName); // Clean the material name
                    if (!originalMaterialMap.ContainsKey(materialName))
                    {
                        originalMaterialMap[materialName] = material;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Warning: One of the shaders was is invalid or does not exist");
                    Console.ResetColor();
                }
            }

            foreach (var oldNode in Definition.Nodes)
            {
                var name = Cache.StringTable.GetString(oldNode.Name).Replace('.', '_').ToLower(); // Prevent issues in edge cases where nodes have "." in their names
                nodes.Add(name, builder.AddNode(oldNode));
            }

            // Track used meshes
            var usedMeshes = new HashSet<string>();

            foreach (var region in Definition.Regions)
            {
                builder.BeginRegion(region.Name);

                var regionName = Cache.StringTable.GetString(region.Name).ToLower();

                foreach (var permutation in region.Permutations)
                {
                    if (permutation.MeshCount > 1)
                        throw new NotSupportedException("multiple permutation meshes");

                    var permName = Cache.StringTable.GetString(permutation.Name).ToLower();

                    var permMeshes = scene.Meshes
                        .Where(i => CleanMeshName(i.Name).ToLower() == $"{regionName}:{permName}")
                        .ToList();

                    if (permMeshes.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"   No mesh found for [{regionName}:{permName}], we will try to prevent issues!");
                        Console.ResetColor();
                        // Set MeshIndex to -1 to prevent issues but continue with the process
                        builder.BeginPermutationNone(permutation.Name);
                        builder.EndPermutation();
                        continue;
                    }

                    permMeshes.Sort((a, b) => a.MaterialIndex.CompareTo(b.MaterialIndex));

                    var assignedNodes = new HashSet<string>();

                    foreach (var part in permMeshes)
                    {
                        foreach (var bone in part.Bones)
                        {
                            assignedNodes.Add(FixBoneName(bone.Name));
                        }
                    }

                    if (assignedNodes.Count > 70)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"   [{regionName}:{permName}] exceeds 70 nodes, expect render issues!");
                        Console.ResetColor();
                    }

                    ushort partStartVertex = 0;
                    ushort partStartIndex = 0;

                    var rigidVertices = new List<RigidVertex>();
                    var skinnedVertices = new List<SkinnedVertex>();

                    var indices = new List<ushort>();
                    var meshNodeIndices = new List<byte>();

                    // Check if the mesh index is invalid or -1, assume it's a skinned mesh type
                    VertexType vertexType;
                    sbyte rigidNode;
                    if (permutation.MeshIndex < 0 || permutation.MeshIndex >= Definition.Geometry.Meshes.Count)
                    {
                        vertexType = VertexType.Skinned;
                        rigidNode = -1;
                    }
                    else
                    {
                        vertexType = Definition.Geometry.Meshes[permutation.MeshIndex].Type;
                        rigidNode = (sbyte)Definition.Geometry.Meshes[permutation.MeshIndex].RigidNodeIndex;
                    }

                    builder.BeginPermutation(permutation.Name);
                    builder.BeginMesh();

                    var MeshIndexCountOG = 0;
                    var MeshIndexCountNew = 0;
                    Console.Write($"   [{regionName}:{permName}]({permMeshes.Count}) ");
                    foreach (var part in permMeshes)
                    {
                        usedMeshes.Add(part.Name.ToLower());

                        for (var i = 0; i < part.VertexCount; i++)
                        {
                            var position = part.Vertices[i];
                            var normal = part.Normals[i];

                            Vector3D uv;

                            try
                            {
                                uv = part.TextureCoordinateChannels[0][i];
                            }
                            catch
                            {
                                new TagToolWarning($"Missing texture coordinate for vertex {i} in '{regionName}:{permName}'");
                                uv = new Vector3D();
                            }

                            var tangent = part.Tangents.Count != 0 ? part.Tangents[i] : new Vector3D();
                            var bitangent = part.BiTangents.Count != 0 ? part.BiTangents[i] : new Vector3D();

                            if (usePerMeshNodeMapping)
                            {
                                foreach (var bone in part.Bones)
                                {
                                    string bonefix = FixBoneName(bone.Name);

                                    if (!nodes.ContainsKey(bonefix))
                                    {
                                        new TagToolWarning($"There is no node {bonefix} to match bone {bone.Name}");
                                    }
                                    else
                                    {
                                        sbyte nodeIndex = nodes[bonefix];
                                        int meshNodeIndex = meshNodeIndices.IndexOf((byte)nodeIndex);  // Convert sbyte to byte for IndexOf method
                                        if (meshNodeIndex == -1)
                                        {
                                            meshNodeIndex = meshNodeIndices.Count;
                                            meshNodeIndices.Add((byte)nodeIndex);  // Convert sbyte to byte for Add method
                                        }
                                    }
                                }
                            }

                            if (vertexType == VertexType.Skinned)
                            {
                                var blendIndicesList = new List<byte>();
                                var blendWeightsList = new List<float>();

                                foreach (var bone in part.Bones)
                                {
                                    foreach (var vertexInfo in bone.VertexWeights)
                                    {
                                        if (vertexInfo.VertexID == i)
                                        {
                                            string bonefix = FixBoneName(bone.Name);

                                            if (!nodes.ContainsKey(bonefix))
                                            {
                                                new TagToolError(CommandError.CustomError, $"There is no node {bonefix} to match bone {bone.Name}");
                                                return false;
                                            }

                                            sbyte nodeIndex = nodes[bonefix];

                                            if (usePerMeshNodeMapping)
                                                blendIndicesList.Add((byte)meshNodeIndices.IndexOf((byte)nodeIndex));
                                            else
                                                blendIndicesList.Add((byte)nodeIndex);

                                            blendWeightsList.Add(vertexInfo.Weight);
                                        }
                                    }
                                }

                                var blendIndices = new byte[4];
                                var blendWeights = new float[4];

                                for (int j = 0; j < blendIndicesList.Count; j++)
                                {
                                    if (j < 4)
                                        blendIndices[j] = blendIndicesList[j];
                                }

                                for (int j = 0; j < blendWeightsList.Count; j++)
                                {
                                    if (j < 4)
                                        blendWeights[j] = blendWeightsList[j];
                                }

                                skinnedVertices.Add(new SkinnedVertex
                                {
                                    Position = new RealQuaternion(position.X * 0.01f, position.Y * 0.01f, position.Z * 0.01f, 1),
                                    Texcoord = new RealVector2d(uv.X, 1.0f - uv.Y),
                                    Normal = new RealVector3d(normal.X, normal.Y, normal.Z),
                                    Tangent = new RealQuaternion(tangent.X, tangent.Y, tangent.Z, 1),
                                    Binormal = new RealVector3d(bitangent.X, bitangent.Y, bitangent.Z),
                                    BlendIndices = blendIndices,
                                    BlendWeights = blendWeights
                                });
                            }
                            else
                            {
                                rigidVertices.Add(new RigidVertex
                                {
                                    Position = new RealQuaternion(position.X * 0.01f, position.Y * 0.01f, position.Z * 0.01f, 1),
                                    Texcoord = new RealVector2d(uv.X, 1.0f - uv.Y),
                                    Normal = new RealVector3d(normal.X, normal.Y, normal.Z),
                                    Tangent = new RealQuaternion(tangent.X, tangent.Y, tangent.Z, 1),
                                    Binormal = new RealVector3d(bitangent.X, bitangent.Y, bitangent.Z),
                                });
                            }
                        }

                        ushort[] meshIndices = part.GetIndices().Select(i => (ushort)(i + partStartVertex)).ToArray();
                        MeshIndexCountOG += meshIndices.Count();
                        if (IndexBufferFormat == IndexBufferFormat.TriangleList)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write($"{meshIndices.Count()} ");
                            Console.ResetColor();
                        }
                        else
                        {
                            var indicesUint = meshIndices.Select(i => (uint)i).ToArray();
                            var indicesOptimized = new uint[indicesUint.Length];
                            MeshOptimizer.OptimizeVertexCacheStrip(indicesOptimized, indicesUint, indicesUint.Count(), 65536);
                            var indicesStripped = new uint[MeshOptimizer.StripifyBound(indicesOptimized.Length)];
                            uint indicesStrippedCount = MeshOptimizer.Stripify(indicesStripped, indicesOptimized, indicesOptimized.Length, 65536, 0);
                            meshIndices = indicesStripped.Take((int)indicesStrippedCount).Select(i => (ushort)i).ToArray();

                            bool badResult = indicesStrippedCount > indicesUint.Count();

                            Console.ForegroundColor = badResult ? ConsoleColor.DarkYellow : ConsoleColor.DarkGray;
                            Console.Write($"{indicesStrippedCount} ");
                            Console.ResetColor();

                            if (badResult) ShowTriangleStripWarning = true;
                        }
                        indices.AddRange(meshIndices);
                        MeshIndexCountNew += meshIndices.Count();

                        var meshMaterial = scene.Materials[part.MaterialIndex];

                        short materialIndex = 0;

                        var shaderName = Path.GetFileNameWithoutExtension(meshMaterial.Name);
                        shaderName = CleanMaterialName(shaderName);

                        Console.WriteLine($" ");
                        Console.WriteLine($"   Processing material: {meshMaterial.Name}, extracted shader name: {shaderName}");

                        if (originalMaterialMap.TryGetValue(shaderName, out var originalMaterial))
                        {
                            Console.WriteLine($"   Found original material for shader: {shaderName}");
                            if (!materialIndices.TryGetValue(shaderName, out materialIndex))
                            {
                                materialIndex = builder.AddMaterial(originalMaterial);
                                materialIndices[shaderName] = materialIndex;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"   Shader not found: {shaderName}, using default shader");
                            Console.ResetColor();
                            materialIndex = builder.AddMaterial(new RenderMaterial
                            {
                                RenderMethod = defaultShaderTag,
                            });
                        }

                        builder.BeginPart(materialIndex, partStartIndex, (ushort)meshIndices.Length, (ushort)part.VertexCount);
                        builder.DefineSubPart(partStartIndex, (ushort)meshIndices.Length, (ushort)part.VertexCount);
                        builder.EndPart();

                        partStartVertex += (ushort)part.VertexCount;
                        partStartIndex += (ushort)meshIndices.Length;
                    }

                    if (vertexType == VertexType.Skinned)
                        builder.BindSkinnedVertexBuffer(skinnedVertices);
                    else
                        builder.BindRigidVertexBuffer(rigidVertices, rigidNode);

                    if (MeshIndexCountNew > ushort.MaxValue) Console.ForegroundColor = ConsoleColor.Red;
                    else if (MeshIndexCountNew > MeshIndexCountOG) Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(IndexBufferFormat == IndexBufferFormat.TriangleList ?
                        MeshIndexCountOG.ToString() : $"     Mesh Index Count: {MeshIndexCountOG} > {MeshIndexCountNew}");
                    Console.ResetColor();

                    builder.BindIndexBuffer(indices, IndexBufferFormat);

                    if (usePerMeshNodeMapping)
                        builder.MapNodes(meshNodeIndices.Count == 0 ? new byte[] { 0 } : meshNodeIndices.ToArray());

                    builder.EndMesh();
                    builder.EndPermutation();
                }
                builder.EndRegion();
            }

            // Check for unused meshes
            var allMeshes = scene.Meshes.Select(m => m.Name.ToLower()).ToHashSet();
            var unusedMeshes = allMeshes.Except(usedMeshes);
            if (unusedMeshes.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning!: There are unused meshes in the file!");
                foreach (var mesh in unusedMeshes)
                {
                    Console.WriteLine($"Unused mesh: {mesh}");
                }
                Console.ResetColor();
            }

            foreach (var mesh in builder.Meshes)
            {
                switch (mesh.VertexFormat)
                {
                    case VertexBufferFormat.Skinned:
                        if (mesh.SkinnedVertices != null && mesh.SkinnedVertices.Length > 400000)
                        {
                            return new TagToolError(CommandError.OperationFailed, $"Number of skinned vertices ({mesh.SkinnedVertices.Length}) exceeded the new limit! (400000)");
                        }
                        break;
                    case VertexBufferFormat.Rigid:
                        if (mesh.RigidVertices != null && mesh.RigidVertices.Length > 400000)
                        {
                            return new TagToolError(CommandError.OperationFailed, $"Number of rigid vertices ({mesh.RigidVertices.Length}) exceeded the new limit! (400000)");
                        }
                        break;
                }
                if (mesh.Indices != null && mesh.Indices.Length > 400000)
                {
                    return new TagToolError(CommandError.OperationFailed, $"Number of vertex indices ({mesh.Indices.Length}) exceeded the new limit! (400000)");
                }
            }

            Console.Write("\n   Building render_geometry...");

            var newDefinition = builder.Build(Cache.Serializer);
            Definition.Regions = newDefinition.Regions;
            Definition.Geometry = newDefinition.Geometry;
            Definition.Nodes = newDefinition.Nodes;
            Definition.Materials = newDefinition.Materials;

            Console.WriteLine("done.");

            Console.Write("   Writing render_model tag data...");

            using (var cacheStream = Cache.OpenCacheReadWrite())
                Cache.Serialize(cacheStream, Tag, Definition);

            Console.WriteLine("done.");

            if (InitialStringIdCount != Cache.StringTable.Count)
            {
                Console.Write("Saving string ids...");

                Cache.SaveStrings();

                Console.WriteLine("done");
            }

            Console.WriteLine("   Replaced render_geometry successfully.\n");

            if (ShowTriangleStripWarning)
                return new TagToolWarning($"One or more meshes using TriangleStrips produced more indices than TriangleList would have.");

            return true;
        }

        private static string FixBoneName(string name)
        {
            if (Regex.IsMatch(name, @"Armature_\d\d\d_.*"))
            {
                return Regex.Match(name, @"Armature_\d\d\d_(.*)").Groups[1].Value.ToLower();
            }
            else if (Regex.IsMatch(name, @"Armature_.*"))
            {
                return Regex.Match(name, @"Armature_(.*)").Groups[1].Value.ToLower();
            }
            return name.ToLower();
        }
    }
}