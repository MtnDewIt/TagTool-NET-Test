using TagTool.Cache;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using TagTool.Tags.Resources;
using TagTool.Geometry.BspCollisionGeometry;
using TagTool.Pathfinding;
using TagTool.Pathfinding.Utils;
using TagTool.Common;
using TagTool.Commands.Common;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache.Resources;

namespace TagTool.Commands.ScenarioStructureBSPs
{
    public class EditPathfindingGeometryCommand : Command
    {
        private GameCache Cache { get; }

        private ScenarioStructureBsp Bsp { get; }

        public EditPathfindingGeometryCommand(GameCache cache, ScenarioStructureBsp bsp) :
            base(true,

                "EditPathfindingGeometry",
                "Writes tag pathfinding data to resource pathfinding data",

                "EditPathfindingGeometry",

                "(Goes off of _TAG_ pathfinding blocks in current sbsp tag")
        {
            Cache = cache;
            Bsp = bsp;
        }

        public override object Execute(List<string> args)
        {
            // Grab the curret RESOURCE version of the path finding data and set it to our var
            var resourceDefinition = Cache.ResourceCache.GetStructureBspCacheFileTagResources(Bsp.PathfindingResource);

            // Create our empty path finding RESOURCE, do not modify the SurfacePlanes, Planes, EdgeToSeams
            // data as they are always generated from the map geo and as they should be
            resourceDefinition.PathfindingData = new TagBlock<ResourcePathfinding>(CacheAddressType.Definition);

            // Go through all TAG version of path finding data and convert it to RESOURCE version
            foreach (var pathfinding in Bsp.PathfindingData)
            {
                resourceDefinition.PathfindingData.Add(PathfindingConverter.CreateResourcePathfindingFromTag(pathfinding));
            }

            // Write our new RESOURCE version of pathfinding data, which will create a new resource index (leaving the old one in place if there was one,)
            // which is fine because we are only going to be using this on maps that have no pathfinding data and should only be used one time after we have
            // our data finalized
            Bsp.PathfindingResource = Cache.ResourceCache.CreateStructureBspCacheFileResource(resourceDefinition);

            return true;
        }
    }
}