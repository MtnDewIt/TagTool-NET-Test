using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.ScenarioStructureBSPs
{
    public class GeneratePathfindingDataCommand : Command
    {
        private GameCache Cache { get; }
        private ScenarioStructureBsp Bsp { get; }
        private CachedTag CollisionTag { get; set; }
        private CollisionModel CollisionDefinition { get; set; }

        public GeneratePathfindingDataCommand(GameCache cache, ScenarioStructureBsp bsp) :
            base(true,

                "GeneratePathfindingData",
                "",

                "GeneratePathfindingData [Object Collision Model] [IncludeBsp]",
                "")
        {
            Cache = cache;
            Bsp = bsp;
        }

        public override object Execute(List<string> args) 
        {
            if (args.Count > 2)
                return new TagToolError(CommandError.ArgCount);

            bool bspPathfinding = false;
            bool includeBsp = false;

            if (args.Count == 0) 
            {
                bspPathfinding = true;
            }

            if (args.Count >= 1) 
            {
                if (!Cache.TagCache.TryGetTag<CollisionModel>(args[0], out CachedTag collisionTag))
                {
                    return new TagToolError(CommandError.TagInvalid);
                }
                else 
                {
                    CollisionTag = collisionTag;
                }
            }

            if (args.Count == 2) 
            {
                if (args[1].ToLower() == "includebsp")
                {
                    includeBsp = true;
                }
            }

            using (Stream cacheStream = Cache.OpenCacheReadWrite()) 
            {
                if (bspPathfinding)
                {
                    GenerateBspPathfinding(cacheStream);
                }
                else 
                {
                    GenerateObjectPathfinding(cacheStream, includeBsp);
                }
            }

            return true;
        }

        public void GenerateBspPathfinding(Stream cacheStream) 
        {
            // Add logic to handle bsp pathfinding data
        }

        public void GenerateObjectPathfinding(Stream cacheStream, bool includeBsp) 
        {
            CollisionDefinition = Cache.Deserialize<CollisionModel>(cacheStream, CollisionTag);

            // Add logic to handle object pathfinding data

            if (includeBsp) 
            {
                // Add logic to handle referencing of bsp collision data
            }
        }
    }
}
