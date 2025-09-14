﻿using System;
using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Cache.Eldorado;

namespace TagTool.Commands.Tags
{
    class GetTagInfoCommand : Command
    {
        private GameCacheEldoradoBase Cache { get; }

        public GetTagInfoCommand(GameCacheEldoradoBase cache)
            : base(true,

            "GetTagInfo",
            "Displays detailed information about a tag.",

            "GetTagInfo <tag>",

            "Displays detailed information about a tag.")
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count != 1)
                return new TagToolError(CommandError.ArgCount);
            if (!Cache.TagCache.TryGetTag(args[0], out var tag))
                return new TagToolError(CommandError.TagInvalid);

            var hoTag = (CachedTagEldorado)tag;

            Console.WriteLine("Information for tag {0:X8}:", tag.Index);
            Console.Write("- Groups:        {0}", tag.Group.Tag);

            if (tag.Group.ParentTag.Value != -1)
                Console.Write(" -> {0}", tag.Group.ParentTag);
            if (tag.Group.GrandParentTag.Value != -1)
                Console.Write(" -> {0}", tag.Group.GrandParentTag);

            Console.WriteLine();
            Console.WriteLine("- Header Cache offset: 0x{0:X}", hoTag.HeaderOffset);
            Console.WriteLine("- Total size:    0x{0:X}", hoTag.TotalSize);
            Console.WriteLine("- Header size:    0x{0:X}", hoTag.CalculateHeaderSize());
            Console.WriteLine("- Dependency Count:    0x{0:X}", hoTag.Dependencies.Count);
            Console.WriteLine("- Definition offset (relative to header offset): 0x{0:X}", tag.DefinitionOffset);
            Console.WriteLine();
            Console.WriteLine("Use \"TagDependency List {0:X}\" to list this tag's dependencies.", tag.Index);

            return true;
        }
    }
}
