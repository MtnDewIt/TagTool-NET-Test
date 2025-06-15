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
                   "Updates the model's node list to match the linked render_model's nodes and hierarchy.",
                   "UpdateModelNodes",
                   "Synchronizes Model.Nodes and RuntimeNodeListChecksum from the render_model.")
        {
            CacheContext = cacheContext;
            ModelTag = model;
            ModelTagDefinition = modelTag;
        }

        public override object Execute(List<string> args)
        {
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

                // build the inverse matrix from the four vectors:
                var inv = new RealMatrix4x3(
                    // row1 = InverseForward
                    (float)rmNode.InverseForward.I, (float)rmNode.InverseForward.J, (float)rmNode.InverseForward.K,
                    // row2 = InverseLeft
                    (float)rmNode.InverseLeft.I, (float)rmNode.InverseLeft.J, (float)rmNode.InverseLeft.K,
                    // row3 = InverseUp
                    (float)rmNode.InverseUp.I, (float)rmNode.InverseUp.J, (float)rmNode.InverseUp.K,
                    // row4 = InversePosition
                    (float)rmNode.InversePosition.X, (float)rmNode.InversePosition.Y, (float)rmNode.InversePosition.Z
                );

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
                    Inverse = inv
                };

                updatedNodes.Add(modelNode);
            }

            ModelTag.Nodes = updatedNodes;
            ModelTag.RuntimeNodeListChecksum = renderModel.NodeListChecksum;

            using (Stream stream = CacheContext.OpenCacheReadWrite())
            {
                CacheContext.Serialize(stream, ModelTagDefinition, ModelTag);
            }

            Console.WriteLine("Done.");
            return true;
        }
    }
}
