﻿using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Geometry;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.CollisionModels
{
    class CollisionModelTestCommand : Command
    {
        private GameCacheEldoradoBase Cache { get; }

        public CollisionModelTestCommand(GameCacheEldoradoBase cache)
            : base(false,
                  
                  "CollisionModelTest",
                  "Collision geometry import command (Test)",
                  
                  "CollisionModelTest <filepath>|<dirpath> <index>|<new> [force]",
                  
                  "Insert a collision_geometry tag compiled from Halo1 CE Tool.\n" +
                  "A file path can be specified to load from a single Halo 1 coll tag or a directory name " +
                  "for a directory with many coll tags can be loaded as separate BSPs.\n" +
                  "A tag-index can be specified to override an existing tag, or 'new' can be used to create a new tag.\n" +
                  "Tags that are not type- 'coll' will not be overridden unless the third argument is specified- 'force'.")
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            //Arguments needed: filepath, <new>|<tagIndex>
            if (args.Count < 2)
                return new TagToolError(CommandError.ArgCount);

            CachedTag tag;

            // optional argument: forces overwriting of tags that are not type: coll
            var b_force = (args.Count >= 3 && args[2].ToLower().Equals("force"));

            if (args[1].ToLower().Equals("new"))
            {
                tag = Cache.TagCacheEldorado.AllocateTag(Cache.TagCache.TagDefinitions.GetTagDefinitionType("coll"));
            }
            else
            {
                if (!Cache.TagCache.TryGetTag(args[1], out tag))
                    return new TagToolError(CommandError.TagInvalid);
            }

            if (!b_force && !tag.IsInGroup("coll"))
                return new TagToolError(CommandError.ArgInvalid, "Tag to override was not of class- 'coll'. Use third argument- 'force' to inject into this tag.");

            string filepath = args[0];
            string[] fpaths = null;
            CollisionModel coll = null;
            bool b_singleFile = Path.GetExtension(filepath).Equals(".model_collision_geometry")
                && !Directory.Exists(filepath);

            var modelbuilder = new LegacyCollisionGeometryConverter();
            int n_objects = 1;

            if (!b_singleFile)
            {
                fpaths = Directory.GetFiles(filepath, "*.model_collision_geometry");

                if (fpaths.Length == 0)
                    return new TagToolError(CommandError.ArgInvalid, $"No Halo 1 coll tags in directory: \"{filepath}\"");

                filepath = fpaths[0];
                n_objects = fpaths.Length;
            }
            
            Console.WriteLine((n_objects == 1 ? "Loading coll tag..." : "Loading coll tags..."), n_objects);

            if (!modelbuilder.ParseFromFile(filepath))
                return new TagToolError(CommandError.OperationFailed, $"Failed to parse collision file \"{filepath}\"");

            coll = modelbuilder.Build();

            if (coll == null)
                return new TagToolError(CommandError.OperationFailed, "Builder produced null result");

            if (!b_singleFile)
            {
                for (int i = 1; i < fpaths.Length; ++i)
                {
                    if (!modelbuilder.ParseFromFile(fpaths[i]))
                        return new TagToolError(CommandError.OperationFailed, $"Failed to parse collision file \"{filepath}\"");

                    var coll2 = modelbuilder.Build();

                    if (coll2 == null)
                        return new TagToolError(CommandError.OperationFailed, "Builder produced null result");

                    coll.Regions.Add(coll2.Regions[0]);
                }
            }

            using (var stream = Cache.OpenCacheReadWrite())
            {
                Cache.Serialize(stream, tag, coll);
            }

            Console.WriteLine(n_objects == 1 ? "Added 1 collision." : "Added {0} collisions in one tag.", n_objects);
            Console.Write("Successfully imported coll to: ");
            TagPrinter.PrintTagShort(tag);

            return true;
        }
    }
}
