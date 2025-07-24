﻿using System;
using System.Collections;
using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Common.Logging;
using TagTool.Tags;

namespace TagTool.Commands.Editing
{
    class SwapBlockElementsCommand : Command
    {
        private CommandContextStack ContextStack { get; }
        private GameCache Cache { get; }
        private CachedTag Tag { get; }
        private TagStructureInfo Structure { get; set; }
        private object Owner { get; set; }

        public SwapBlockElementsCommand(CommandContextStack contextStack, GameCache cache, CachedTag tag, TagStructureInfo structure, object owner)
            : base(true,

                  "SwapBlockElements",
                  $"Swaps a block element from a specified index of a specific tag block in the current {structure.Types[0].Name} definition.",

                  "SwapBlockElements <block name> <Element index> <Element index>",
                  $"Swaps a block element from a specified index of a specific tag block in the current {structure.Types[0].Name} definition.")
        {
            ContextStack = contextStack;
            Cache = cache;
            Tag = tag;
            Structure = structure;
            Owner = owner;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count != 3)
                return new TagToolError(CommandError.ArgCount);

            var fieldName = args[0];
            var fieldNameLow = fieldName.ToLower();

            var previousContext = ContextStack.Context;
            var previousOwner = Owner;
            var previousStructure = Structure;

            if (fieldName.Contains("."))
            {
                var lastIndex = fieldName.LastIndexOf('.');
                var blockName = fieldName.Substring(0, lastIndex);
                fieldName = fieldName.Substring(lastIndex + 1, (fieldName.Length - lastIndex) - 1);
                fieldNameLow = fieldName.ToLower();

                var command = new EditBlockCommand(ContextStack, Cache, Tag, Owner);

                if (command.Execute(new List<string> { blockName }).Equals(false))
                {
                    ContextReturn(previousContext, previousOwner, previousStructure);
                    return new TagToolError(CommandError.ArgInvalid, $"TagBlock \"{blockName}\" does not exist in the specified context");
                }

                command = (ContextStack.Context.GetCommand("EditBlock") as EditBlockCommand);

                Owner = command.Owner;
                Structure = command.Structure;

                if (Owner == null)
                {
                    ContextReturn(previousContext, previousOwner, previousStructure);
                    return new TagToolError(CommandError.OperationFailed, "Command context owner was null");
                }
            }

			var field = TagStructure.GetTagFieldEnumerable(Structure)
				.Find(f => f.Name == fieldName || f.Name.ToLower() == fieldNameLow);

            if ((field == null) || (!field.FieldType.IsGenericType) || (field.FieldType.GetInterface("IList") == null))
            {
                ContextReturn(previousContext, previousOwner, previousStructure);
                return new TagToolError(CommandError.ArgInvalid, $"\"{Structure.Types[0].Name}\" does not contain a tag block named \"{args[0]}\".");
            }

            var fieldType = field.FieldType;

            var blockValue = field.GetValue(Owner) as IList;

            if (blockValue == null)
            {
                blockValue = Activator.CreateInstance(field.FieldType) as IList;
                field.SetValue(Owner, blockValue);
            }

            var elementType = field.FieldType.GenericTypeArguments[0];

            var index = -1;
            var newIndex = -1;

            if (blockValue.Count - 1 < 0)
            {
                Log.Error("TagBlock is null!");
                ContextReturn(previousContext, previousOwner, previousStructure);
                return true;
            }

            if (!int.TryParse(args[1], out index) || index < 0 || index >= blockValue.Count)
                return new TagToolError(CommandError.ArgInvalid, $"Invalid index specified: {args[1]}");

            if (!int.TryParse(args[2], out newIndex) || newIndex < 0 || newIndex >= blockValue.Count)
                return new TagToolError(CommandError.ArgInvalid, $"Invalid index specified: {args[2]}");

            if (index == newIndex)
                return new TagToolError(CommandError.OperationFailed, "Cannot move to the same index");

            if (index == -1 || newIndex == -1)
                return new TagToolError(CommandError.OperationFailed);

            var cachedElement = blockValue[newIndex];

            //swap Elements
            blockValue[newIndex] = blockValue[index];
            blockValue[index] = cachedElement;

            field.SetValue(Owner, blockValue);

            var valueString =
                ((IList)blockValue).Count != 0 ?
                    $"{{...}}[{((IList)blockValue).Count}]" :
                "null";

            Console.WriteLine($"\n\tSuccessfully swapped elements {index} and {newIndex} of {field.Name}{valueString}");

            ContextReturn(previousContext, previousOwner, previousStructure);

            return true;
        }

        public void ContextReturn(CommandContext previousContext, object previousOwner, TagStructureInfo previousStructure)
        {
            while (ContextStack.Context != previousContext) ContextStack.Pop();
            Owner = previousOwner;
            Structure = previousStructure;
        }
    }
}
