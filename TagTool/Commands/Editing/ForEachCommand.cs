﻿using TagTool.Cache;
using TagTool.Tags;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TagTool.Common;
using TagTool.Commands.Common;
using TagTool.Tags.Definitions;
using static TagTool.Tags.TagFieldFlags;

namespace TagTool.Commands.Editing
{
    class ForEachCommand : Command
    {
        private CommandContextStack ContextStack { get; }
        private GameCache Cache { get; }
        private CacheVersion Version { get; }
        private CachePlatform Platform { get; }
        private object ObjectFile { get; }

        public TagStructureInfo Structure { get; set; }
        public object Owner { get; set; }

        public ForEachCommand(CommandContextStack contextStack, GameCache cache, CacheVersion version, CachePlatform platform, object objectFile, TagStructureInfo structure, object owner)
            : base(true,

                  "ForEach",
                  "Executes a command for each element in the specified tag block.",

                  "ForEach <Tag Block> [From: *] [To: *] <Command>",

                  "Executes a command for each element in the specified tag block.")
        {
            ContextStack = contextStack;
            Cache = cache;
            Version = version;
            Platform = platform;
            ObjectFile = objectFile;
            Structure = structure;
            Owner = owner;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count < 1)
                return new TagToolError(CommandError.ArgCount);

            var fieldName = args[0];
            var fieldNameLow = fieldName.ToLower();
            var fieldNameSnake = fieldName.ToSnakeCase();

            var previousContext = ContextStack.Context;
            var previousOwner = Owner;
            var previousStructure = Structure;

            var blockName = "";

            if (fieldName.Contains("."))
            {
                var lastIndex = fieldName.LastIndexOf('.');
                blockName = fieldName.Substring(0, lastIndex);
                fieldName = fieldName.Substring(lastIndex + 1, (fieldName.Length - lastIndex) - 1);
                fieldNameLow = fieldName.ToLower();
                fieldNameSnake = fieldName.ToSnakeCase();

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

            var field = TagStructure.GetTagFieldEnumerable(Structure)
                .Find(f =>
                    f.Name == fieldName ||
                    f.Name.ToLower() == fieldNameLow ||
                    f.Name.ToSnakeCase() == fieldNameSnake);

            var ownerType = Owner.GetType();

            if (field == null)
                return new TagToolError(CommandError.ArgInvalid, $"\"{ownerType.Name}\" does not contain a tag block named \"{fieldName}\".");

            IList fieldValue = null;
            var structureAttribute = field.FieldType.CustomAttributes.ToList().Find(a => a.AttributeType == typeof(TagStructureAttribute));

            if ((field.FieldType.GetInterface("IList") == null || (fieldValue = (IList)field.GetValue(Owner)) == null) && structureAttribute == null)
                return new TagToolError(CommandError.ArgInvalid, $"\"{ownerType.Name}\" does not contain a tag block named \"{fieldName}\".");

            string fromName = null;
            int? from = null;

            string toName = null;
            int? to = null;

            while (args.Count > 1)
            {
                var found = false;

                switch (args[1].ToLower())
                {
                    case "from:":
                        if (char.IsNumber(args[2][0]))
                            from = int.Parse(args[2]);
                        else
                        {
                            fromName = args[2];
                            from = FindLabelIndex(fieldValue, fromName);

                            if (from == -1)
                                return new TagToolError(CommandError.OperationFailed, "Label index returned -1");
                        }
                        args.RemoveRange(1, 2);
                        found = true;
                        break;

                    case "to:":
                        if (char.IsNumber(args[2][0]))
                            to = int.Parse(args[2]);
                        else
                        {
                            toName = args[2];
                            to = FindLabelIndex(fieldValue, toName);

                            if (to == -1)
                                return new TagToolError(CommandError.OperationFailed, "Label index returned -1");
                        }
                        args.RemoveRange(1, 2);
                        found = true;
                        break;
                }

                if (!found)
                    break;
            }

            blockName = args[0];
            args.RemoveRange(0, 1);

            var commandsToExecute = new List<List<string>>();

            // if no command is given, keep reading commands from stdin until an empty line encountered
            if (args.Count < 1)
            {
                string line;
                while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
                {
                    var commandsArgs = ArgumentParser.ParseCommand(line, out string redirectFile);
                    commandsToExecute.Add(commandsArgs);
                }
            }
            else
            {
                commandsToExecute.Add(args);
            }

            if (structureAttribute == null)
            {
                for (var i = (from ?? 0); i < (to.HasValue ? to.Value + 1 : fieldValue.Count); i++)
                {
                    ContextReturn(previousContext, previousOwner, previousStructure);

                    if (blockName != "" && new EditBlockCommand(ContextStack, Cache, Version, Platform, ObjectFile, Owner)
                            .Execute(new List<string> { $"{blockName}[{i}]" })
                            .Equals(false))
                        return new TagToolError(CommandError.ArgInvalid, $"Invalid tag block name: {blockName}");

                    var label = GetLabel(fieldValue, i);

                    Console.Write(label == null ? $"[{i}] " : $"[{label} ({i})] ");
                    foreach (var command in commandsToExecute)
                    {
                        var cmd = ContextStack.Context.GetCommand(command[0]);
                        if (cmd != null)
                            cmd.Execute(command.Skip(1).ToList());
                        else
                        {
                            ContextReturn(previousContext, previousOwner, previousStructure);
                            return new TagToolError(CommandError.ArgInvalid);
                        }
                    }
                }
            }
            else
            {
                ContextReturn(previousContext, previousOwner, previousStructure);

                if (blockName != "" && new EditBlockCommand(ContextStack, Cache, Version, Platform, ObjectFile, Owner)
                    .Execute(new List<string> { $"{blockName}" })
                    .Equals(false))
                    return new TagToolError(CommandError.ArgInvalid, $"Invalid tag structure name: {blockName}");

                foreach (var command in commandsToExecute)
                    ContextStack.Context.GetCommand(command[0]).Execute(command.Skip(1).ToList());
            }

            ContextReturn(previousContext, previousOwner, previousStructure);

            return true;
        }

        private string GetLabel(IList elements, int index)
        {
            if (index < 0 || index >= elements.Count || elements.GetType().GetGenericArguments().Count() == 0)
                return null;

            foreach (var info in TagStructure.GetTagFieldEnumerable(elements.GetType().GetGenericArguments()[0], Version, Platform))
            {
                if (info.Attribute == null || !info.Attribute.Flags.HasFlag(Label))
                    continue;

                var value = info.FieldInfo.GetValue(elements[index]);

                if (info.FieldType == typeof(string))
                    return (string)value;
                else if (info.FieldType == typeof(StringId))
                    return Cache.StringTable.GetString((StringId)value);
                else if (info.FieldType.IsPrimitive) 
                {
                    if (ObjectFile.GetType() == typeof(CachedTag)) 
                    {
                        var tag = ObjectFile as CachedTag;

                        if (tag.IsInGroup("scnr")) 
                        {
                            return GetLabel((IList)typeof(Scenario).GetField(nameof(Scenario.ObjectNames)).GetValue(Owner), Convert.ToInt32(value));
                        }
                    }
                }
                else if (info.FieldType == typeof(CachedTag))
                    return value != null ? value.ToString() : "Null";
                else
                    return value.ToString();
            }

            return null;
        }

        private int FindLabelIndex(IList elements, string displayName)
        {
            for (var i = 0; i < elements.Count; i++)
            {
                var label = GetLabel(elements, i);

                if (label == null)
                    continue;

                if (displayName == label)
                    return i;
            }

            return -1;
        }

        public void ContextReturn(CommandContext previousContext, object previousOwner, TagStructureInfo previousStructure)
        {
            while (ContextStack.Context != previousContext) ContextStack.Pop();
            Owner = previousOwner;
            Structure = previousStructure;
        }
    }
}
