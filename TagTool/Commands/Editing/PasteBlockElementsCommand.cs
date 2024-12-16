﻿using System;
using System.Collections;
using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags;

namespace TagTool.Commands.Editing
{
    class PasteBlockElementsCommand : Command
    {
        private CommandContextStack ContextStack { get; }
        private GameCache Cache { get; }
        private CacheVersion Version { get; }
        private CachePlatform Platform { get; }
        private object ObjectFile { get; }
        private TagStructureInfo Structure { get; set; }
        private object Owner { get; set; }

        public PasteBlockElementsCommand(CommandContextStack contextStack, GameCache cache, CacheVersion version, CachePlatform platform, object objectFile, TagStructureInfo structure, object owner,
            bool ignoreVars = false, string examples = "")
            : base(true,

                  "PasteBlockElements",
                  $"Pastes block element(s) to a specific tag block in the current {structure.Types[0].Name} definition.",

                  "PasteBlockElements <tag block name> [index = *]",

                  $"Pastes block element(s) to a specific tag block in the current {structure.Types[0].Name} definition.", ignoreVars, examples)
        {
            ContextStack = contextStack;
            Cache = cache;
            Version = version;
            Platform = platform;
            ObjectFile = objectFile;
            Structure = structure;
            Owner = owner;
        }

        private CommandContext previousContext;
        private object previousOwner;
        private TagStructureInfo previousStructure;

        public override object Execute(List<string> args)
        {
            if (args.Count < 1 || args.Count > 2)
                return new TagToolError(CommandError.ArgCount);

            if (CopyBlockElementsCommand.Elements == null)
                return new TagToolError(CommandError.CustomMessage, "You need to copy at least one block element first");

            var fieldName = args[0];
            var fieldNameLow = fieldName.ToLower();

            previousContext = ContextStack.Context;
            previousOwner = Owner;
            previousStructure = Structure;

            if (fieldName.Contains("."))
            {
                var lastIndex = fieldName.LastIndexOf('.');
                var blockName = fieldName.Substring(0, lastIndex);
                fieldName = fieldName.Substring(lastIndex + 1, (fieldName.Length - lastIndex) - 1);
                fieldNameLow = fieldName.ToLower();

                var command = new EditBlockCommand(ContextStack, Cache, Version, Platform, ObjectFile, Owner);

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
            
            var index = -1;

            if (args.Count > 1)
                if (args[1] != "*" && (!int.TryParse(args[1], out index) || index < 0))
                {
                    ContextReturn(previousContext, previousOwner, previousStructure);
                    return new TagToolError(CommandError.ArgInvalid, $"Invalid index specified: {args[1]}");
                }

            var field = TagStructure.GetTagFieldEnumerable(Structure)
				.Find(f => f.Name == fieldName || f.Name.ToLower() == fieldNameLow);

			var fieldType = field?.FieldType;

            if (field == null)
            {
                ContextReturn(previousContext, previousOwner, previousStructure);
                return new TagToolError(CommandError.ArgInvalid, $"\"{Structure.Types[0].Name}\" does not contain a tag block named \"{args[0]}\".");
            }

            if (!fieldType.IsGenericType && field.FieldType.IsArray) 
            {
                var elementType = field.FieldType.GetElementType();

                if (elementType != CopyBlockElementsCommand.ElementType)
                {
                    ContextReturn(previousContext, previousOwner, previousStructure);
                    return new TagToolError(CommandError.CustomError, "Invalid block element type");
                }

                var blockValue = field.GetValue(Owner) as Array;

                if (blockValue == null)
                {
                    blockValue = Activator.CreateInstance(field.FieldType) as Array;
                    field.SetValue(Owner, blockValue);
                }

                if (index > blockValue.Length - 1)
                {
                    ContextReturn(previousContext, previousOwner, previousStructure);
                    return new TagToolError(CommandError.ArgInvalid, $"Invalid index \"{index}\"");
                }

                for (var i = 0; i < CopyBlockElementsCommand.Elements.Count; i++)
                {
                    var element = CopyBlockElementsCommand.Elements[i].DeepCloneV2();

                    var arrayLength = blockValue.Length - 1;

                    if (arrayLength - CopyBlockElementsCommand.Elements.Count < index)
                    {
                        ContextReturn(previousContext, previousOwner, previousStructure);
                        return new TagToolError(CommandError.ArgInvalid, $"Element count is too large: \"{index}\" > \"{arrayLength}\" - \"{CopyBlockElementsCommand.Elements.Count}\"");
                    }

                    if (i < blockValue.Length - 1) 
                    {
                        blockValue.SetValue(element, i);
                    }
                }

                field.SetValue(Owner, blockValue);

                var itemString = CopyBlockElementsCommand.Elements.Count < 2 ? "element" : "elements";

                var valueString =
                    ((Array)blockValue).Length != 0 ?
                        $"{{...}}[{((Array)blockValue).Length}]" :
                    "null";

                Console.WriteLine($"Successfully pasted {CopyBlockElementsCommand.Elements.Count} {itemString} to {field.Name}: {fieldType.Name}");
                Console.WriteLine(valueString);
            }

            if (fieldType.GetInterface("IList") != null && !field.FieldType.IsArray) 
            {
                var elementType = field.FieldType.GenericTypeArguments[0];

                if (elementType != CopyBlockElementsCommand.ElementType)
                {
                    ContextReturn(previousContext, previousOwner, previousStructure);
                    return new TagToolError(CommandError.CustomError, "Invalid block element type");
                }

                var blockValue = field.GetValue(Owner) as IList;

                if (blockValue == null)
                {
                    blockValue = Activator.CreateInstance(field.FieldType) as IList;
                    field.SetValue(Owner, blockValue);
                }

                if (index > blockValue.Count)
                {
                    ContextReturn(previousContext, previousOwner, previousStructure);
                    return new TagToolError(CommandError.ArgInvalid, $"Invalid index \"{index}\"");
                }

                for (var i = 0; i < CopyBlockElementsCommand.Elements.Count; i++)
                {
                    var element = CopyBlockElementsCommand.Elements[i].DeepCloneV2();

                    if (index == -1)
                        blockValue.Add(element);
                    else
                        blockValue.Insert(index + i, element);
                }

                field.SetValue(Owner, blockValue);

                var typeString =
                    fieldType.IsGenericType ?
                        $"{fieldType.Name}<{fieldType.GenericTypeArguments[0].Name}>" :
                    fieldType.Name;

                var itemString = CopyBlockElementsCommand.Elements.Count < 2 ? "element" : "elements";

                var valueString =
                    ((IList)blockValue).Count != 0 ?
                        $"{{...}}[{((IList)blockValue).Count}]" :
                    "null";

                Console.WriteLine($"Successfully pasted {CopyBlockElementsCommand.Elements.Count} {itemString} to {field.Name}: {typeString}");
                Console.WriteLine(valueString);
            }

            if (!field.FieldType.IsGenericType && !field.FieldType.IsArray && field.FieldType.GetInterface("IList") == null) 
            {
                var elementType = field.FieldType.GetElementType();

                if (elementType != CopyBlockElementsCommand.ElementType)
                {
                    ContextReturn(previousContext, previousOwner, previousStructure);
                    return new TagToolError(CommandError.CustomError, "Invalid block element type");
                }

                var blockValue = field.GetValue(Owner);

                if (blockValue == null)
                {
                    blockValue = Activator.CreateInstance(field.FieldType);
                    field.SetValue(Owner, blockValue);
                }

                if (index > 1)
                {
                    ContextReturn(previousContext, previousOwner, previousStructure);
                    return new TagToolError(CommandError.ArgInvalid, $"Invalid index \"{index}\"");
                }

                blockValue = CopyBlockElementsCommand.Elements[0].DeepCloneV2();

                field.SetValue(Owner, blockValue);

                Console.WriteLine($"Successfully pasted {CopyBlockElementsCommand.Elements.Count} element to {field.Name}: {fieldType.Name}");
                Console.WriteLine($"{{...}}[1]");
            }

            ContextReturn(previousContext, previousOwner, previousStructure);

            return true;
        }

        private object CreateElement(Type elementType)
        {
            var element = Activator.CreateInstance(elementType);

            var isTagStructure = Attribute.IsDefined(elementType, typeof(TagStructureAttribute));

            if (isTagStructure)
            {
				foreach (var tagFieldInfo in TagStructure.GetTagFieldEnumerable(elementType, Version, Platform))
					{
						var fieldType = tagFieldInfo.FieldType;

						if (fieldType.IsArray && tagFieldInfo.Attribute.Length > 0)
						{
							var array = (IList)Activator.CreateInstance(tagFieldInfo.FieldType,
								new object[] { tagFieldInfo.Attribute.Length });

							for (var i = 0; i < tagFieldInfo.Attribute.Length; i++)
								array[i] = CreateElement(fieldType.GetElementType());
						}
						else
						{
#if !DEBUG
                        try
                        {
#endif
							tagFieldInfo.SetValue(element, CreateElement(tagFieldInfo.FieldType));
#if !DEBUG
                        }
                        catch
                        {
                            tagFieldInfo.SetValue(element, null);
                        }
#endif
						}
					}
            }

            return element;
        }

        public void ContextReturn(CommandContext previousContext, object previousOwner, TagStructureInfo previousStructure)
        {
            while (ContextStack.Context != previousContext) ContextStack.Pop();
            Owner = previousOwner;
            Structure = previousStructure;
        }
    }
}
