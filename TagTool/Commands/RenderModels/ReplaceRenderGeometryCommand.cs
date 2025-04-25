using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Assimp;
using AssimpMesh = Assimp.Mesh;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Commands.Common;
using TagTool.Geometry;
using TagTool.Tags.Definitions;
using static TagTool.Tags.Definitions.RenderModel;

namespace TagTool.Commands.RenderModels
{
    class ReplaceRenderGeometryCommand : Command
    {
        private GameCache Cache { get; }
        private CachedTag Tag { get; }
        private RenderModel Definition { get; }

        public ReplaceRenderGeometryCommand(GameCache cache, CachedTag tag, RenderModel definition) :
            base(false,
        name: "ReplaceRenderGeometry",
        description: "Replaces the render_geometry of the current render_model tag.",
        usage: "ReplaceRenderGeometry <COLLADA or FBX Scene> [IndexBufferFormat] [updatenodes] [markers]",
        examples: "ReplaceRenderGeometry d:\\model.dae trianglestrip updatenodes markers\nReplaceRenderGeometry d:\\model.fbx updatenodes markers",
        helpMessage: "- Replaces the render_geometry of the current render_model tag with geometry compiled from a COLLADA (.DAE) or FBX (.FBX) scene file.\n" +
                     "- Name your meshes as {region}:{permutation} (e.g. hull:base).\n" +
                     "- IndexBufferFormat is TriangleStrip unless TriangleList specified.\n" +
                     "- When the optional flag 'updatenodes' is specified the tool will update the transform values for all Nodes and Runtime Node Orientations.\n" +
                     "- When the optional flag 'markers' is specified the tool will remove all existing markers and generate new marker groups by reading nodes whose names begin with '#' from the source file.\n" +
                     "Note: FBX is only supported for updating nodes and markers")
        {
            Cache = cache;
            Tag = tag;
            Definition = definition;
        }

        public override object Execute(List<string> args)
        {
            Console.WriteLine();
            if (args.Count < 1 || args.Count > 4)
                return new TagToolError(CommandError.ArgCount);
            bool updateNodes = args.Any(a => a.ToLower() == "updatenodes");
            bool updateMarkers = args.Any(a => a.ToLower() == "markers");
            string sceneFilePath = args[0];
            string indexBufferFormatArg = args.FirstOrDefault(a => a.ToLower() != "updatenodes" && a.ToLower() != "markers" && a != sceneFilePath);
            if (!Cache.TagCache.TryGetTag<Shader>(@"shaders\invalid", out var defaultShaderTag))
            {
                new TagToolWarning("shaders\\invalid.shader' not found!\n"
                    + "You will have to assign material shaders manually.");
            }

            var stringIdCount = Cache.StringTable.Count;

            var sceneFile = new FileInfo(args[0]);

            var indexBufferFormat = args.Count > 1 && args[1].ToLower() == "trianglelist" ? IndexBufferFormat.TriangleList : IndexBufferFormat.TriangleStrip;


            if (!sceneFile.Exists)
                return new TagToolError(CommandError.FileNotFound);

            string extension = sceneFile.Extension.ToLower();
            if (extension != ".dae" && extension != ".fbx")
                return new TagToolError(CommandError.FileType, $"\"{sceneFile.FullName}\"");
            return ExecuteInternal(Cache, Tag, Definition, stringIdCount, sceneFile, indexBufferFormat, updateNodes, updateMarkers);
        }

        public static object ExecuteInternal(GameCache Cache, CachedTag Tag, RenderModel Definition, int InitialStringIdCount, FileInfo SceneFile, IndexBufferFormat IndexBufferFormat, bool updateNodes = false, bool updateMarkers = false)
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
            if (updateNodes)
            {
                Console.WriteLine("Updating node transforms from scene hierarchy...");

                var sceneNodesMap = new Dictionary<string, Assimp.Node>();
                var worldTransforms = new Dictionary<string, Matrix4x4>();

                void ProcessNode(Assimp.Node node, Matrix4x4 parentWorld)
                {
                    var local = node.Transform;
                    var world = parentWorld * local;
                    var key = node.Name.Replace('.', '_').ToLower();

                    sceneNodesMap[key] = node;
                    worldTransforms[key] = world;

                    foreach (var child in node.Children)
                        ProcessNode(child, world);
                }
                ProcessNode(scene.RootNode, Matrix4x4.Identity);

                foreach (var haloNode in Definition.Nodes)
                {
                    var nodeName = Cache.StringTable.GetString(haloNode.Name)
                        .Replace('.', '_')
                        .ToLower();

                    if (!sceneNodesMap.TryGetValue(nodeName, out var fbxNode) ||
                        !worldTransforms.TryGetValue(nodeName, out var worldMatrix))
                    {
                        Console.WriteLine($"Warning: Missing node {nodeName}");
                        continue;
                    }

                    fbxNode.Transform.Decompose(out var scale, out var rotation, out var translation);
                    haloNode.DefaultTranslation = new RealPoint3d(
                        translation.X * 0.01f,
                        translation.Y * 0.01f,
                        translation.Z * 0.01f
                    );
                    haloNode.DefaultRotation = new RealQuaternion(
                        rotation.X,
                        rotation.Y,
                        rotation.Z,
                        rotation.W
                    );
                    haloNode.DefaultScale = scale.X;

                    var inverseWorld = worldMatrix;
                    inverseWorld.Inverse();

                    haloNode.InverseForward = new RealVector3d(
                        inverseWorld.A1,      
                        inverseWorld.A3,      
                        -inverseWorld.A2  
                    );

                    haloNode.InverseLeft = new RealVector3d(
                        -inverseWorld.B1,     
                        -inverseWorld.B3,    
                        -inverseWorld.B2     
                    );

                    haloNode.InverseUp = new RealVector3d(
                        inverseWorld.C1,  
                        inverseWorld.C3,  
                        inverseWorld.C2       
                    );

                    haloNode.InversePosition = new RealPoint3d(
                        inverseWorld.A4 * 0.01f,  
                        inverseWorld.C4 * 0.01f, 
                        -inverseWorld.B4 * 0.01f  
                    );

                    if (haloNode.ParentNode >= 0 && haloNode.ParentNode < Definition.Nodes.Count)
                    {
                        fbxNode.Transform.Decompose(out _, out _, out Vector3D localTranslation);

                        var localTranslationMeters = new RealPoint3d(
                            localTranslation.X * 0.01f,
                            localTranslation.Y * 0.01f,
                            localTranslation.Z * 0.01f
                        );

                        haloNode.DistanceFromParent = (float)Math.Sqrt(
                            localTranslationMeters.X * localTranslationMeters.X +
                            localTranslationMeters.Y * localTranslationMeters.Y +
                            localTranslationMeters.Z * localTranslationMeters.Z
                        );
                    }
                    else
                    {
                        haloNode.DistanceFromParent = 0f;
                    }
                }

                    if (Definition.RuntimeNodeOrientations?.Count == Definition.Nodes.Count)
                {
                    for (int i = 0; i < Definition.Nodes.Count; i++)
                    {
                        Definition.RuntimeNodeOrientations[i] = new RuntimeNodeOrientation
                        {
                            Translation = Definition.Nodes[i].DefaultTranslation,
                            Rotation = Definition.Nodes[i].DefaultRotation,
                            Scale = Definition.Nodes[i].DefaultScale
                        };
                    }
                }
                Console.WriteLine("Node update complete.\n");
            }
            RenderModelBuilder builder = new RenderModelBuilder(Cache);
            Dictionary<string, sbyte> nodes = new Dictionary<string, sbyte>();
            Dictionary<string, short> materialIndices = new Dictionary<string, short>();
            Dictionary<string, RenderMaterial> originalMaterialMap = new Dictionary<string, RenderMaterial>();
            bool usePerMeshNodeMapping = true;

            string CleanMaterialName(string name)
            {
                var suffixRegex = new Regex(@"[)%=]+$");
                name = suffixRegex.Replace(name, "");
                var shaderRegex = new Regex(@".*?_shaders_");
                return shaderRegex.Replace(name, "").ToLower();
            }

            string CleanMeshName(string name)
            {
                var parts = name.Split(':');
                if (parts.Length > 2)
                    return $"{parts[0]}:{parts[1]}";
                return name;
            }

            foreach (var material in Definition.Materials)
            {
                var shaderTag = material.RenderMethod != null ? Cache.TagCache.GetTag(material.RenderMethod.Index) : null;
                if (shaderTag != null)
                {
                    var shaderPath = shaderTag.Name;
                    var materialName = Path.GetFileNameWithoutExtension(shaderPath);
                    materialName = CleanMaterialName(materialName);
                    if (!originalMaterialMap.ContainsKey(materialName))
                        originalMaterialMap[materialName] = material;
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
                var name = Cache.StringTable.GetString(oldNode.Name).Replace('.', '_').ToLower();
                nodes.Add(name, builder.AddNode(oldNode));
            }

            var sceneMeshGroups = new Dictionary<string, Dictionary<string, List<AssimpMesh>>>();
            foreach (var mesh in scene.Meshes)
            {
                string cleanName = CleanMeshName(mesh.Name).ToLower();
                string[] parts = cleanName.Split(':');
                if (parts.Length < 2)
                    continue;
                string regionName = parts[0];
                string permName = parts[1];
                if (!sceneMeshGroups.ContainsKey(regionName))
                    sceneMeshGroups[regionName] = new Dictionary<string, List<AssimpMesh>>();
                if (!sceneMeshGroups[regionName].ContainsKey(permName))
                    sceneMeshGroups[regionName][permName] = new List<AssimpMesh>();
                sceneMeshGroups[regionName][permName].Add(mesh);
            }

            List<string> existingRegionNamesOrdered = Definition.Regions.Select(r => Cache.StringTable.GetString(r.Name).ToLower()).ToList();
            List<string> newRegionNames = sceneMeshGroups.Keys.Where(rn => !existingRegionNamesOrdered.Contains(rn)).ToList();
            List<string> regionNamesToProcess = existingRegionNamesOrdered.Concat(newRegionNames).Take(16).ToList();

            var usedMeshes = new HashSet<string>();

            foreach (var regionName in regionNamesToProcess)
            {
                RenderModel.Region existingRegion = Definition.Regions.FirstOrDefault(r => Cache.StringTable.GetString(r.Name).ToLower() == regionName);
                StringId regionId = existingRegion != null ? existingRegion.Name : Cache.StringTable.GetOrAddString(regionName);

                builder.BeginRegion(regionId);

                List<string> existingPermsOrdered = new List<string>();
                if (existingRegion != null)
                    existingPermsOrdered = existingRegion.Permutations.Select(p => Cache.StringTable.GetString(p.Name).ToLower()).ToList();
                List<string> scenePerms = new List<string>();
                if (sceneMeshGroups.ContainsKey(regionName))
                    scenePerms = sceneMeshGroups[regionName].Keys.ToList();
                List<string> newPerms = scenePerms.Where(pn => !existingPermsOrdered.Contains(pn)).ToList();
                List<string> permNamesToProcess = existingPermsOrdered.Concat(newPerms).Take(128).ToList();

                foreach (var permName in permNamesToProcess)
                {
                    StringId permId;
                    bool isNewPermutation = false;
                    if (existingRegion != null && existingRegion.Permutations.Any(p => Cache.StringTable.GetString(p.Name).ToLower() == permName))
                        permId = existingRegion.Permutations.First(p => Cache.StringTable.GetString(p.Name).ToLower() == permName).Name;
                    else
                    {
                        permId = Cache.StringTable.GetOrAddString(permName);
                        isNewPermutation = true;
                    }

                    if (isNewPermutation)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"   Added new permutation: {regionName}:{permName}");
                        Console.ResetColor();
                    }

                    List<AssimpMesh> permMeshes = new List<AssimpMesh>();
                    if (sceneMeshGroups.ContainsKey(regionName) && sceneMeshGroups[regionName].ContainsKey(permName))
                        permMeshes = sceneMeshGroups[regionName][permName];

                    if (permMeshes.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"   No mesh found for [{regionName}:{permName}], we will try to prevent issues!");
                        Console.ResetColor();
                        builder.BeginPermutationNone(permId);
                        builder.EndPermutation();
                        continue;
                    }

                    permMeshes.Sort((a, b) => a.MaterialIndex.CompareTo(b.MaterialIndex));

                    var assignedNodes = new HashSet<string>();
                    foreach (var part in permMeshes)
                    {
                        foreach (var bone in part.Bones)
                        {
                            if (bone.VertexWeights.Any(vw => vw.Weight > 0.0f))
                                assignedNodes.Add(FixBoneName(bone.Name));
                        }
                    }

                    if (assignedNodes.Count > 70)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"   [{regionName}:{permName}] exceeds 70 nodes, expect render issues!");
                        Console.ResetColor();
                    }

                    int partStartVertex = 0;
                    int partStartIndex = 0;
                    var rigidVertices = new List<RigidVertex>();
                    var skinnedVertices = new List<SkinnedVertex>();
                    var indices = new List<ushort>();
                    List<byte> meshNodeIndices = new List<byte>();

                    VertexType vertexType;
                    sbyte rigidNode;
                    {
                        bool isRigidPermutation = true;
                        sbyte permutationRigidNode = -1;

                        foreach (var part in permMeshes)
                        {
                            bool partIsRigid = true;
                            sbyte partRigidBone = -1;
                            for (int i = 0; i < part.VertexCount; i++)
                            {
                                int influenceCount = 0;
                                sbyte currentBone = -1;
                                foreach (var bone in part.Bones)
                                {
                                    foreach (var vw in bone.VertexWeights)
                                    {
                                        if (vw.VertexID == i && vw.Weight > 0.0f)
                                        {
                                            influenceCount++;
                                            if (nodes.TryGetValue(FixBoneName(bone.Name), out sbyte boneNode))
                                                currentBone = boneNode;
                                            else
                                            {
                                                new TagToolWarning($"Bone {bone.Name} not found for permutation {regionName}:{permName}");
                                                partIsRigid = false;
                                                break;
                                            }
                                        }
                                    }
                                    if (!partIsRigid)
                                        break;
                                }

                                if (!partIsRigid)
                                    break;

                                if (influenceCount > 1)
                                {
                                    partIsRigid = false;
                                    break;
                                }
                                else if (influenceCount == 1)
                                {
                                    if (partRigidBone == -1)
                                        partRigidBone = currentBone;
                                    else if (partRigidBone != currentBone)
                                        partIsRigid = false;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"   No bone info found for vertex {i} in [{regionName}:{permName}], parenting to root bone.");
                                    Console.ResetColor();
                                    if (partRigidBone == -1)
                                        partRigidBone = 0;
                                    else if (partRigidBone != 0)
                                        partIsRigid = false;
                                }
                            }

                            if (!partIsRigid)
                            {
                                isRigidPermutation = false;
                                break;
                            }
                            else
                            {
                                if (permutationRigidNode == -1)
                                    permutationRigidNode = partRigidBone;
                                else if (permutationRigidNode != partRigidBone)
                                {
                                    isRigidPermutation = false;
                                    break;
                                }
                            }
                        }

                        if (isRigidPermutation)
                        {
                            vertexType = VertexType.Rigid;
                            rigidNode = permutationRigidNode;
                        }
                        else
                        {
                            vertexType = VertexType.Skinned;
                            rigidNode = -1;
                        }
                    }

                    List<byte> skinnedBoneMapping = null;
                    if (vertexType == VertexType.Skinned)
                    {
                        List<byte> combinedBoneOrder = new List<byte>();
                        Dictionary<byte, int> boneUsage = new Dictionary<byte, int>();

                        foreach (var part in permMeshes)
                        {
                            foreach (var bone in part.Bones)
                            {
                                string bonefix = FixBoneName(bone.Name);
                                if (nodes.TryGetValue(bonefix, out sbyte nodeIndex))
                                {
                                    byte b = (byte)nodeIndex;
                                    if (!combinedBoneOrder.Contains(b))
                                        combinedBoneOrder.Add(b);
                                    int count = bone.VertexWeights.Count(vw => vw.Weight > 0.0f);
                                    if (boneUsage.ContainsKey(b))
                                        boneUsage[b] += count;
                                    else
                                        boneUsage[b] = count;
                                }
                            }
                        }
                        var usedBones = combinedBoneOrder.Where(b => boneUsage.ContainsKey(b) && boneUsage[b] > 0).ToList();
                        skinnedBoneMapping = usedBones;
                    }

                    builder.BeginPermutation(permId);
                    builder.BeginMesh();

                    var MeshIndexCountOG = 0;
                    var MeshIndexCountNew = 0;
                    Console.Write($"   [{regionName}:{permName}]({permMeshes.Count}) ");
                    foreach (var part in permMeshes)
                    {
                        usedMeshes.Add(part.Name.ToLower());

                        if (vertexType == VertexType.Rigid && usePerMeshNodeMapping)
                        {
                            foreach (var bone in part.Bones)
                            {
                                string bonefix = FixBoneName(bone.Name);
                                if (!nodes.ContainsKey(bonefix))
                                    new TagToolWarning($"There is no node {bonefix} to match bone {bone.Name}");
                                else
                                {
                                    sbyte nodeIndex = nodes[bonefix];
                                    int meshNodeIndex = meshNodeIndices.IndexOf((byte)nodeIndex);
                                    if (meshNodeIndex == -1)
                                        meshNodeIndices.Add((byte)nodeIndex);
                                }
                            }
                        }

                        for (var i = 0; i < part.VertexCount; i++)
                        {
                            var position = part.Vertices[i];
                            var normal = part.Normals[i];
                            Vector3D uv;
                            try { uv = part.TextureCoordinateChannels[0][i]; }
                            catch { uv = new Vector3D(); }

                            var tangent = part.Tangents.Count != 0 ? part.Tangents[i] : new Vector3D();
                            var bitangent = part.BiTangents.Count != 0 ? part.BiTangents[i] : new Vector3D();

                            if (vertexType == VertexType.Skinned)
                            {
                                var blendIndicesList = new List<byte>();
                                var blendWeightsList = new List<float>();
                                foreach (var bone in part.Bones)
                                {
                                    foreach (var vertexInfo in bone.VertexWeights)
                                    {
                                        if (vertexInfo.VertexID == i && vertexInfo.Weight > 0.0f)
                                        {
                                            string bonefix = FixBoneName(bone.Name);
                                            if (!nodes.ContainsKey(bonefix))
                                                return new TagToolError(CommandError.CustomError, $"There is no node {bonefix} to match bone {bone.Name}");
                                            sbyte nodeIndex = nodes[bonefix];
                                            blendIndicesList.Add((byte)skinnedBoneMapping.IndexOf((byte)nodeIndex));
                                            blendWeightsList.Add(vertexInfo.Weight);
                                        }
                                    }
                                }

                                var blendIndices = new byte[4];
                                var blendWeights = new float[4];
                                for (int j = 0; j < blendIndicesList.Count; j++)
                                    if (j < 4) blendIndices[j] = blendIndicesList[j];
                                for (int j = 0; j < blendWeightsList.Count; j++)
                                    if (j < 4) blendWeights[j] = blendWeightsList[j];

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
                        if (IndexBufferFormat != IndexBufferFormat.TriangleList)
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
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write($"{meshIndices.Count()} ");
                            Console.ResetColor();
                        }
                        indices.AddRange(meshIndices);
                        MeshIndexCountNew += meshIndices.Count();

                        var meshMaterial = scene.Materials[part.MaterialIndex];
                        short materialIndex = 0;
                        string originalMatName = meshMaterial.Name;
                        var shaderName = Path.GetFileNameWithoutExtension(originalMatName);
                        shaderName = CleanMaterialName(shaderName);

                        if (originalMaterialMap.TryGetValue(shaderName, out var originalMaterial))
                        {
                            if (!materialIndices.TryGetValue(shaderName, out materialIndex))
                            {
                                materialIndex = builder.AddMaterial(originalMaterial);
                                materialIndices[shaderName] = materialIndex;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            materialIndex = builder.AddMaterial(new RenderMaterial { RenderMethod = defaultShaderTag });
                        }

                        bool preventBackfaceCulling = false;
                        var suffixMatch = Regex.Match(originalMatName, @"([)%=]+)$");
                        if (suffixMatch.Success && suffixMatch.Groups[1].Value.Contains("%"))
                            preventBackfaceCulling = true;

                            if (partStartIndex > uint.MaxValue || meshIndices.Length > uint.MaxValue)
                            throw new InvalidOperationException($"sub-part too large: index range {partStartIndex}…{partStartIndex + meshIndices.Length - 1}");
                        int absoluteFirstIndex = partStartIndex;
                        builder.BeginPart(materialIndex, absoluteFirstIndex, meshIndices.Length, (ushort)part.VertexCount);

                        int remaining = meshIndices.Length;
                        int relativeOffset = 0;
                        while (remaining > 0)
                        {
                            int chunk = Math.Min(remaining, ushort.MaxValue);
                            builder.DefineSubPart(
                                absoluteFirstIndex,  // absolute first index
                                (ushort)chunk,
                                (ushort)part.VertexCount
                            );
                            relativeOffset += chunk;
                            remaining -= chunk;
                        }
                        builder.EndPart();



                        partStartVertex += part.VertexCount;
                        partStartIndex += meshIndices.Length;
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

                    if (vertexType == VertexType.Skinned)
                        builder.MapNodes(skinnedBoneMapping.ToArray());
                    else
                        builder.MapNodes(new byte[] { (byte)rigidNode });

                    builder.EndMesh();
                    builder.EndPermutation();
                }
                builder.EndRegion();
            }

            var allMeshes = scene.Meshes.Select(m => m.Name.ToLower()).ToHashSet();
            var unusedMeshes = allMeshes.Except(usedMeshes);
            if (unusedMeshes.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                foreach (var mesh in unusedMeshes)
                    Console.WriteLine($"Unused mesh: {mesh}");
                Console.ResetColor();
            }

            foreach (var mesh in builder.Meshes)
            {
                switch (mesh.VertexFormat)
                {
                    case VertexBufferFormat.Skinned:
                        if (mesh.SkinnedVertices != null && mesh.SkinnedVertices.Length > 400000)
                            return new TagToolError(CommandError.OperationFailed, $"Skinned vertices limit exceeded: {mesh.SkinnedVertices.Length}");
                        break;
                    case VertexBufferFormat.Rigid:
                        if (mesh.RigidVertices != null && mesh.RigidVertices.Length > 400000)
                            return new TagToolError(CommandError.OperationFailed, $"Rigid vertices limit exceeded: {mesh.RigidVertices.Length}");
                        break;
                }
                if (mesh.Indices != null && mesh.Indices.Length > 400000)
                    return new TagToolError(CommandError.OperationFailed, $"Index limit exceeded: {mesh.Indices.Length}");
            }

            Console.Write("\n   Building render_geometry...");
            var newDefinition = builder.Build(Cache.Serializer);

            if (updateMarkers)
            {
                var markerGroups = new Dictionary<string, RenderModel.MarkerGroup>();
                void ProcessMarkerNode(Assimp.Node node)
                {
                    if (node.Name.StartsWith("#"))
                    {
                        string markerText = node.Name.Substring(1);
                        string groupName = "";
                        int regionIndex = -1;
                        int permutationIndex = -1;
                        if (markerText.StartsWith("("))
                        {
                            int endParen = markerText.IndexOf(")");
                            if (endParen > 0)
                            {
                                string inside = markerText.Substring(1, endParen - 1);
                                var tokens = inside.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                if (tokens.Length >= 2)
                                {
                                    string permName = tokens[0].ToLower();
                                    string regionName = tokens[1].ToLower();
                                    for (int r = 0; r < newDefinition.Regions.Count; r++)
                                    {
                                        string rName = Cache.StringTable.GetString(newDefinition.Regions[r].Name).ToLower();
                                        if (rName == regionName)
                                        {
                                            regionIndex = r;
                                            for (int p = 0; p < newDefinition.Regions[r].Permutations.Count; p++)
                                            {
                                                string pName = Cache.StringTable.GetString(newDefinition.Regions[r].Permutations[p].Name).ToLower();
                                                if (pName == permName)
                                                {
                                                    permutationIndex = p;
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    }
                                }
                                groupName = markerText.Substring(endParen + 1);
                            }
                            else
                                groupName = markerText;
                        }
                        else
                            groupName = markerText;

                        int dotIndex = groupName.IndexOf(".");
                        if (dotIndex >= 0)
                            groupName = groupName.Substring(0, dotIndex);
                        groupName = groupName.Trim();
                        if (string.IsNullOrEmpty(groupName))
                            groupName = "marker";

                        node.Transform.Decompose(out Vector3D mScale, out Assimp.Quaternion mRot, out Vector3D mTrans);
                        RealPoint3d mTranslation = new RealPoint3d(mTrans.X * 0.01f, mTrans.Y * 0.01f, mTrans.Z * 0.01f);
                        RealQuaternion mRotation = new RealQuaternion(mRot.X, mRot.Y, mRot.Z, mRot.W);
                        float markerScale = mScale.X;

                        var marker = new RenderModel.MarkerGroup.Marker();
                        marker.RegionIndex = (sbyte)regionIndex;
                        marker.PermutationIndex = (sbyte)permutationIndex;
                        marker.Translation = mTranslation;
                        marker.Rotation = mRotation;
                        marker.Scale = markerScale;

                        sbyte parentNodeIndex = -1;
                        if (node.Parent != null)
                        {
                            string parentName = FixBoneName(node.Parent.Name);
                            if (nodes.TryGetValue(parentName, out sbyte index))
                                parentNodeIndex = index;
                        }
                        marker.NodeIndex = parentNodeIndex;

                        if (!markerGroups.ContainsKey(groupName))
                        {
                            var mg = new RenderModel.MarkerGroup();
                            mg.Name = Cache.StringTable.GetOrAddString(groupName);
                            mg.Markers = new List<RenderModel.MarkerGroup.Marker>();
                            markerGroups[groupName] = mg;
                        }
                        markerGroups[groupName].Markers.Add(marker);
                    }
                    foreach (var child in node.Children)
                        ProcessMarkerNode(child);
                }
                ProcessMarkerNode(scene.RootNode);
                newDefinition.MarkerGroups = markerGroups.Values.ToList();
            }
            else
                newDefinition.MarkerGroups = Definition.MarkerGroups;

            Definition.Regions = newDefinition.Regions;
            Definition.Geometry = newDefinition.Geometry;
            Definition.Nodes = newDefinition.Nodes;
            Definition.Materials = newDefinition.Materials;
            Definition.MarkerGroups = newDefinition.MarkerGroups;
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
                return Regex.Match(name, @"Armature_\d\d\d_(.*)").Groups[1].Value.ToLower();
            else if (Regex.IsMatch(name, @"Armature_.*"))
                return Regex.Match(name, @"Armature_(.*)").Groups[1].Value.ToLower();
            return name.ToLower();
        }
    }
}