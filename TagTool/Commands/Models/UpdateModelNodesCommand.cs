using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.Tags.Definitions;
using TagTool.Geometry;   // <-- for RealMatrix4x3

namespace TagTool.Commands.Models
{
    public class UpdateModelNodesCommand : Command
    {
        private GameCache CacheContext { get; }
        private Model ModelTag { get; }
        private CachedTag ModelTagDefinition { get; }

        public UpdateModelNodesCommand(GameCache cacheContext, Model model, CachedTag modelTag)
            : base(false,
                   "UpdateModelNodes",
                   "Updates the model's node list to match the linked render_model's nodes and hierarchy. Optionally updates linked collision, physics, or animation graph nodes.",
                   "UpdateModelNodes [coll] [phmo] [jmad]",
                   "Synchronizes Model.Nodes and RuntimeNodeListChecksum from the render_model.\n" +
                   "With optional arguments:\n" +
                   "- coll: Updates the linked collision_model nodes.\n" +
                   "- phmo: Updates the linked physics_model nodes.\n" +
                   "- jmad: Updates the linked model_animation_graph skeleton nodes.")
        {
            CacheContext = cacheContext;
            ModelTag = model;
            ModelTagDefinition = modelTag;
        }

        public override object Execute(List<string> args)
        {
            // Validate arguments
            foreach (var arg in args)
            {
                if (arg != "coll" && arg != "phmo" && arg != "jmad")
                {
                    return new TagToolError(CommandError.ArgInvalid, $"\"{arg}\"");
                }
            }

            // Deserialize the linked render_model
            RenderModel renderModel;
            using (Stream rmStream = CacheContext.OpenCacheRead())
            {
                renderModel = CacheContext.Deserialize<RenderModel>(rmStream, ModelTag.RenderModel);
            }
            if (renderModel?.Nodes == null)
            {
                Console.WriteLine("Render model or its nodes not found.");
                return false;
            }

            var updatedNodes = new List<Model.Node>(renderModel.Nodes.Count);
            for (int i = 0; i < renderModel.Nodes.Count; i++)
            {
                var rmNode = renderModel.Nodes[i];

                var modelNode = new Model.Node
                {
                    Name = rmNode.Name,
                    ParentNode = rmNode.ParentNode,
                    FirstChildNode = rmNode.FirstChildNode,
                    NextSiblingNode = rmNode.NextSiblingNode,
                    ImportNodeIndex = (short)i,
                    DefaultTranslation = rmNode.DefaultTranslation,
                    DefaultRotation = rmNode.DefaultRotation,
                    DefaultScale = rmNode.DefaultScale,
                    Inverse = rmNode.Inverse,
                };

                updatedNodes.Add(modelNode);
            }

            ModelTag.Nodes = updatedNodes;
            ModelTag.RuntimeNodeListChecksum = renderModel.NodeListChecksum;

            bool updateColl = args.Contains("coll");
            bool updatePhmo = args.Contains("phmo");
            bool updateJmad = args.Contains("jmad");

            using (Stream stream = CacheContext.OpenCacheReadWrite())
            {
                CacheContext.Serialize(stream, ModelTagDefinition, ModelTag);

                if (updateColl && ModelTag.CollisionModel != null)
                {
                    var coll = CacheContext.Deserialize<CollisionModel>(stream, ModelTag.CollisionModel);
                    coll.Nodes = new List<CollisionModel.Node>(renderModel.Nodes.Count);
                    for (int i = 0; i < renderModel.Nodes.Count; i++)
                    {
                        var rmNode = renderModel.Nodes[i];
                        coll.Nodes.Add(new CollisionModel.Node
                        {
                            Name = rmNode.Name,
                            Flags = 0, // Default flags
                            ParentNode = rmNode.ParentNode,
                            NextSiblingNode = rmNode.NextSiblingNode,
                            FirstChildNode = rmNode.FirstChildNode
                        });
                    }
                    CacheContext.Serialize(stream, ModelTag.CollisionModel, coll);
                    Console.WriteLine("Updated collision model nodes.");
                }
                else if (updateColl)
                {
                    Console.WriteLine("No collision model linked.");
                }
                if (updatePhmo && ModelTag.PhysicsModel != null)
                {
                    var phmo = CacheContext.Deserialize<PhysicsModel>(stream, ModelTag.PhysicsModel);
                    Dictionary<StringId, PhysicsModel.Node> oldPhmoByName = new Dictionary<StringId, PhysicsModel.Node>();
                    if (phmo.Nodes != null)
                    {
                        foreach (var oldNode in phmo.Nodes)
                        {
                            if (!oldPhmoByName.ContainsKey(oldNode.Name))
                            {
                                oldPhmoByName.Add(oldNode.Name, oldNode);
                            }
                        }
                    }

                    phmo.Nodes = new List<PhysicsModel.Node>(renderModel.Nodes.Count);
                    for (int i = 0; i < renderModel.Nodes.Count; i++)
                    {
                        var rmNode = renderModel.Nodes[i];
                        var newPhNode = new PhysicsModel.Node();
                        if (oldPhmoByName.TryGetValue(rmNode.Name, out var oldPhNode))
                        {
                            newPhNode.Flags = oldPhNode.Flags;
                        }
                        else
                        {
                            newPhNode.Flags = 0;
                        }

                        newPhNode.Name = rmNode.Name;
                        newPhNode.Parent = rmNode.ParentNode;
                        newPhNode.Sibling = rmNode.NextSiblingNode;
                        newPhNode.Child = rmNode.FirstChildNode;

                        phmo.Nodes.Add(newPhNode);
                    }
                    CacheContext.Serialize(stream, ModelTag.PhysicsModel, phmo);
                    Console.WriteLine("Updated physics model nodes.");
                }
                else if (updatePhmo)
                {
                    Console.WriteLine("No physics model linked.");
                }

                if (updateJmad && ModelTag.Animation != null)
                {
                    var jmad = CacheContext.Deserialize<ModelAnimationGraph>(stream, ModelTag.Animation);
                    Dictionary<StringId, ModelAnimationGraph.SkeletonNode> oldSkeletonByName = new Dictionary<StringId, ModelAnimationGraph.SkeletonNode>();
                    if (jmad.SkeletonNodes != null)
                    {
                        foreach (var oldSk in jmad.SkeletonNodes)
                        {
                            if (!oldSkeletonByName.ContainsKey(oldSk.Name))
                            {
                                oldSkeletonByName.Add(oldSk.Name, oldSk);
                            }
                        }
                    }
                    jmad.SkeletonNodes = new List<ModelAnimationGraph.SkeletonNode>(renderModel.Nodes.Count);
                    for (int i = 0; i < renderModel.Nodes.Count; i++)
                    {
                        var rmNode = renderModel.Nodes[i];
                        var skNode = new ModelAnimationGraph.SkeletonNode
                        {
                            Name = rmNode.Name,
                            ParentNodeIndex = rmNode.ParentNode,
                            FirstChildNodeIndex = rmNode.FirstChildNode,
                            NextSiblingNodeIndex = rmNode.NextSiblingNode,
                            ModelFlags = ModelAnimationGraph.SkeletonNode.SkeletonModelFlags.None,
                            NodeJointFlags = ModelAnimationGraph.SkeletonNode.SkeletonNodeJointFlags.None,
                            BaseVector = new RealVector3d(0, 0, 0),
                            VectorRange = 0,
                            ZPosition = rmNode.DefaultTranslation.Z,
                        };

                        if (oldSkeletonByName.TryGetValue(rmNode.Name, out var oldSkNode))
                        {
                            skNode.ModelFlags = oldSkNode.ModelFlags | ModelAnimationGraph.SkeletonNode.SkeletonModelFlags.PrimaryModel;
                            skNode.NodeJointFlags = oldSkNode.NodeJointFlags;

                            skNode.BaseVector = oldSkNode.BaseVector;
                            skNode.VectorRange = oldSkNode.VectorRange;

                            skNode.ZPosition = oldSkNode.ZPosition;

                            if (CacheContext.Version >= CacheVersion.HaloReach)
                            {
                                skNode.AdditionalFlags = oldSkNode.AdditionalFlags;
                                skNode.FrameID1 = oldSkNode.FrameID1;
                                skNode.FrameID2 = oldSkNode.FrameID2;
                            }
                        }
                        else
                        {
                            skNode.ModelFlags = ModelAnimationGraph.SkeletonNode.SkeletonModelFlags.PrimaryModel;
                            if (CacheContext.Version >= CacheVersion.HaloReach)
                            {
                                skNode.AdditionalFlags = 0;
                                skNode.FrameID1 = 0;
                                skNode.FrameID2 = 0;
                            }
                        }

                        jmad.SkeletonNodes.Add(skNode);
                    }
                    CacheContext.Serialize(stream, ModelTag.Animation, jmad);
                    Console.WriteLine("Updated model animation graph skeleton nodes.");
                }
                else if (updateJmad)
                {
                    Console.WriteLine("No model animation graph linked.");
                }
            }

            Console.WriteLine("Done.");
            return true;
        }
    }
}
