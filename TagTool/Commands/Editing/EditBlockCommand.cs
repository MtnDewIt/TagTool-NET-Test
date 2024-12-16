﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags;

namespace TagTool.Commands.Editing
{
    class EditBlockCommand : Command
    {
        private CommandContextStack ContextStack { get; }
        private GameCache Cache { get; }
        private CacheVersion Version { get; }
        private CachePlatform Platform { get; }
        private object ObjectFile { get; }

        public TagStructureInfo Structure { get; set; }
        public object Owner { get; set; }

        public EditBlockCommand(CommandContextStack contextStack, GameCache cache, CacheVersion version, CachePlatform platform, object objectFile, object value)
            : base(true,

                  "EditBlock",
                  "Edit the fields of a particular block element.",

                  "EditBlock <name> [element-index (if block)]",

                  "Edit the fields of a particular block element.")
        {
            Cache = cache;
            ContextStack = contextStack;
            Version = version;
            Platform = platform;
            ObjectFile = objectFile;
            Structure = TagStructure.GetTagStructureInfo(value.GetType(), Version, Platform);
            Owner = value;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count < 1 || args.Count > 2)
                return new TagToolError(CommandError.ArgCount);

            var blockName = args[0];
            var ownerType = Owner.GetType();

            var deferredNames = new List<string>();
            var deferredArgs = new List<string>();

            if (blockName.Contains("."))
            {
                deferredNames.AddRange(blockName.Split('.'));
                blockName = deferredNames[0];
                deferredNames = deferredNames.Skip(1).ToList();
                deferredArgs.AddRange(args.Skip(1));
                args = new List<string> { blockName };
            }

            if (blockName.Contains("]"))
            {
                var openBracketIndex = blockName.IndexOf('[');
                var closeBracketIndex = blockName.IndexOf(']');
                var name = blockName.Substring(0, openBracketIndex);
                var index = blockName.Substring(openBracketIndex + 1, (closeBracketIndex - openBracketIndex) - 1);

                blockName = name;
                args = new List<string> { name, index };
            }

            var blockNameLow = blockName.ToLower();
            var blockNameSnake = blockName.ToSnakeCase();

			var field = TagStructure.GetTagFieldEnumerable(Structure)
				.Find(f =>
					f.Name == blockName ||
					f.Name.ToLower() == blockNameLow ||
					f.Name.ToSnakeCase() == blockNameSnake);

			if (field == null)
                return new TagToolError(CommandError.ArgInvalid, $"\"{ownerType.Name}\" does not contain a tag block named \"{blockName}\".");
            
            var contextName = "";
            object blockValue = null;

            var structureAttribute = field.FieldType.CustomAttributes.ToList().Find(a => a.AttributeType == typeof(TagStructureAttribute));

            if (structureAttribute != null)
            {
                if (args.Count != 1)
                    return new TagToolError(CommandError.ArgCount, "");

                blockValue = field.GetValue(Owner);
                contextName = $"{blockName}";
            }
            else
            {
                if (args.Count != 2)
                    return new TagToolError(CommandError.ArgCount);

                IList fieldValue = null;

                if (field.FieldType.GetInterface("IList") == null || (fieldValue = (IList)field.GetValue(Owner)) == null)
                    return new TagToolError(CommandError.ArgInvalid, $"\"{ownerType.Name}\" does not contain a tag block named \"{blockName}\".");

                int blockIndex = 0;

                if (args[1] == "*")
                    blockIndex = fieldValue.Count - 1;
                else if (!int.TryParse(args[1], out blockIndex))
                    return new TagToolError(CommandError.ArgInvalid, $"Invalid index \"{blockIndex}\" requested from block \"{blockName}\"");

                if (blockIndex >= fieldValue.Count || blockIndex < 0)
                    return new TagToolError(CommandError.ArgInvalid, $"Invalid index \"{blockIndex}\" requested from block \"{blockName}\"");

                blockValue = fieldValue[blockIndex];
                contextName = $"{blockName}[{blockIndex}]";
            }

            if (blockValue == null)
                return new TagToolError(CommandError.OperationFailed, $"Block \"{blockName}\" is null");

            var blockStructure = TagStructure.GetTagStructureInfo(blockValue.GetType(), Version, Platform);

            var blockContext = new CommandContext(ContextStack.Context, contextName);
            blockContext.ScriptGlobals.Add(ExecuteCSharpCommand.GlobalElementKey, blockValue);

            blockContext.AddCommand(new ListFieldsCommand(Cache, blockStructure, blockValue));
            blockContext.AddCommand(new SetFieldCommand(ContextStack, Cache, Version, Platform, ObjectFile, blockStructure, blockValue));
            //blockContext.AddCommand(new ExtractResourceCommand(ContextStack, CacheContext, Tag, blockStructure, blockValue));
            blockContext.AddCommand(new EditBlockCommand(ContextStack, Cache, Version, Platform, ObjectFile, blockValue));
            blockContext.AddCommand(new AddBlockElementsCommand(ContextStack, Cache, Version, Platform, ObjectFile, blockStructure, blockValue));
            blockContext.AddCommand(new RemoveBlockElementsCommand(ContextStack, Cache, Version, Platform, ObjectFile, blockStructure, blockValue));
            blockContext.AddCommand(new CopyBlockElementsCommand(ContextStack, Cache, Version, Platform, ObjectFile, blockStructure, blockValue));
            blockContext.AddCommand(new PasteBlockElementsCommand(ContextStack, Cache, Version, Platform, ObjectFile, blockStructure, blockValue));
            blockContext.AddCommand(new MoveBlockElementCommand(ContextStack, Cache, Version, Platform, ObjectFile, blockStructure, blockValue));
            blockContext.AddCommand(new SwapBlockElementsCommand(ContextStack, Cache, Version, Platform, ObjectFile, blockStructure, blockValue));
            blockContext.AddCommand(new ForEachCommand(ContextStack, Cache, Version, Platform, ObjectFile, blockStructure, blockValue));
            blockContext.AddCommand(new ExportCommandsCommand(Cache, Version, Platform, blockValue as TagStructure));
            blockContext.AddCommand(new ExitToCommand(ContextStack));
            blockContext.AddCommand(new ExecuteCSharpCommand(ContextStack));
            ContextStack.Push(blockContext);

            if (deferredNames.Count != 0)
            {
                var name = deferredNames[0];
                deferredNames = deferredNames.Skip(1).ToList();

                foreach (var deferredName in deferredNames)
                    name += '.' + deferredName;

                args = new List<string> { name };
                args.AddRange(deferredArgs);

                var command = new EditBlockCommand(ContextStack, Cache, Version, Platform, ObjectFile, blockValue);
                return command.Execute(args);
            }
            
            return true;
        }
    }
}
