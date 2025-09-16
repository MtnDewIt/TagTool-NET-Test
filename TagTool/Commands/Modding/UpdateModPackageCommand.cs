﻿using TagTool.Cache;
using System.Collections.Generic;
using TagTool.Cache.Eldorado;
using System;
using TagTool.Commands.Common;
using TagTool.Commands.Tags;
using System.IO;
using TagTool.Cache.Gen3;
using TagTool.IO;
using System.Threading;
using System.Collections;
using TagTool.Common;
using TagTool.Tags;
using System.Linq;
using static System.Net.WebRequestMethods;
using static TagTool.Tags.Definitions.Model.Variant;
using Assimp.Unmanaged;
using TagTool.Cache.Resources;
using TagTool.Cache.ModPackages;
using TagTool.Common.Logging;

namespace TagTool.Commands.Modding
{
    class UpdateModPackageCommand : Command
    {
        private readonly GameCacheEldorado Cache;
        private CommandContextStack ContextStack { get; }
        private GameCacheModPackage oldMod { get; set; }
        private GameCacheModPackage newMod { get; set; }
        private bool hasError = false;

        public UpdateModPackageCommand(CommandContextStack contextStack, GameCacheEldorado cache) :
            base(true,

                "UpdateModPackage",
                "Update a mod package to match the current base cache. Optionally use unmanaged streams for 2gb + resources.",

                "UpdateModPackage [large] <input path> <output path>")
        {
            ContextStack = contextStack;
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {

            if (args.Count < 2)
                return new TagToolError(CommandError.ArgCount);

            if (!args[0].EndsWith(".pak"))
                args[0] += ".pak";

            if (!args[1].EndsWith(".pak"))
                args[1] += ".pak";

            var infile = new FileInfo(args[0]);
            var outfile = new FileInfo(args[1]);

            if (!infile.Exists)
                return new TagToolError(CommandError.FileNotFound, $"\"{args[0]}\"");

            Console.WriteLine("Initializing cache...");
            oldMod = new GameCacheModPackage(Cache, infile);
            newMod = new GameCacheModPackage(Cache, InitializeModPackage());

            Console.WriteLine("Transferring modded tags...");
            TransferModdedTags();
            if (hasError)
            {
                Console.WriteLine("Failed to update mod package!");
                return false;
            }
            newMod.SaveTagNames();
            newMod.SaveStrings();

            if (newMod.BaseModPackage.Header.ModifierFlags == ModifierFlags.None)
            {
                newMod.BaseModPackage.Header.ModifierFlags |= ModifierFlags.multiplayer;
                newMod.BaseModPackage.Header.ModifierFlags |= ModifierFlags.SignedBit;
            }

            if (!newMod.SaveModPackage(outfile))
                return new TagToolError(CommandError.OperationFailed, "Failed to save mod package.");
            else
                Console.WriteLine("Done!");

            return true;

        }

        private void TransferModdedTags()
        {
            for (var i = 0; i < oldMod.BaseModPackage.GetTagCacheCount(); i++)
            {
                oldMod.SetActiveTagCache(i);
                newMod.SetActiveTagCache(i);
                var oldStream = oldMod.OpenCacheRead();
                var newStream = newMod.OpenCacheReadWrite();
                List<CachedTag> moddedTags = new List<CachedTag>();
                List<CachedTag> newTags = new List<CachedTag>();
                //allocate modded tags in new mod package
                foreach (var tag in oldMod.TagCacheEldorado.Tags)
                {
                    var modCachedTag = oldMod.TagCache.GetTag(tag.Index) as CachedTagEldorado;
                    if (modCachedTag.IsEmpty())
                        continue;
                    if (newMod.TagCache.TryGetCachedTag($"{modCachedTag.Name}.{modCachedTag.Group}", out CachedTag newTag))
                        newTags.Add(newTag);
                    else
                        newTags.Add((CachedTagEldorado)newMod.TagCache.AllocateTag(modCachedTag.Group, modCachedTag.Name));
                    moddedTags.Add(modCachedTag);
                }
                //now fixup and copy over
                for(var j = 0; j < moddedTags.Count; j++)
                {
                    object definition = oldMod.Deserialize(oldStream, moddedTags[j]);
                    object newDef = definition;
                    FixTagData(definition);
                    newMod.Serialize(newStream, newTags[j], newDef);
                }
            }
        }

        private object FixTagData(object data)
        {
            switch (data)
            {
                case CachedTag tagRef:
                    CachedTag newRef;
                    bool foundReference = newMod.TagCache.TryGetCachedTag($"{tagRef.Name}.{tagRef.Group}", out newRef);
                    if (!foundReference)
                    {
                        string fixedName = tagRef.Name;
                        switch (tagRef.Group.ToString())
                        {
                            case "render_method_template":
                                {
                                    if (tagRef.Name.Contains("halogram_templates"))
                                        fixedName += "_0_0";
                                    else
                                        fixedName += "_0";
                                }
                                break;
                            case "bitmap":
                                fixedName = "ms23\\" + fixedName;
                                break;
                            case "equipment":
                                if (tagRef.Name == "objects\\equipment\\instantcover_equipment\\instantcover_equipment")
                                    fixedName = "objects\\equipment\\instantcover_equipment\\instantcover_equipment_mp";
                                break;
                            case "sound_looping":
                                if (tagRef.Name == "sound\\levels\\s3d_edge\\s3d_edge_main\\s3d_edge_main")
                                    fixedName = "sound\\levels\\multi\\s3d_edge\\amb_tech_room\\amb_tech_room";
                                break;
                        }
                        foundReference = newMod.TagCache.TryGetCachedTag($"{fixedName}.{tagRef.Group}", out newRef);
                    }
                    if (foundReference)
                        return newRef;
                    else
                    {
                        Log.Error($"Referenced tag {tagRef.Name}.{tagRef.Group} not found in current base cache!");
                        hasError = true;
                    }
                    return null;
                case StringId stringId:
                    string oldString = oldMod.StringTable.GetString(stringId);
                    string newString = newMod.StringTable.GetString(stringId);
                    if (newString != oldString)
                    {
                        StringId newID = newMod.StringTable.AddString(oldString);
                        return newID;
                    }
                    return stringId;
                case TagResourceReference resource:
                    if (resource.EldoradoPageableResource == null)
                        return resource;
                    var resourceDef = oldMod.ResourceCaches.GetResourceDefinition(resource, resource.EldoradoPageableResource.GetDefinitionType());
                    newMod.ResourceCaches.ReplaceResource(resource.EldoradoPageableResource, resourceDef);
                    return resource;
                case TagStructure tagStruct:
                    foreach (var field in tagStruct.GetTagFieldEnumerable(Cache.Version, Cache.Platform))
                        field.SetValue(data, FixTagData(field.GetValue(tagStruct)));
                    break;
                case IList collection:
                    for (var i = 0; i < collection.Count; i++)
                        collection[i] = FixTagData(collection[i]);
                    break;
            }
            return data;
        }

        private ModPackage InitializeModPackage()
        {
            var builder = new ModPackageBuilder(Cache);
            foreach (string name in oldMod.BaseModPackage.CacheNames)
                builder.AddTagCache(name);

            ModPackage modPackage = builder.Build();

            //copy over metadata
            modPackage.Metadata = oldMod.BaseModPackage.Metadata;

            //copy over header
            modPackage.Header = oldMod.BaseModPackage.Header;
    
            //copy over other fields
            modPackage.MapIds = oldMod.BaseModPackage.MapIds;
            modPackage.CampaignFileStream = oldMod.BaseModPackage.CampaignFileStream;
            modPackage.MapFileStreams = oldMod.BaseModPackage.MapFileStreams;
            modPackage.Files = oldMod.BaseModPackage.Files;
            modPackage.FontPackage = oldMod.BaseModPackage.FontPackage;
            modPackage.MapToCacheMapping = oldMod.BaseModPackage.MapToCacheMapping;

            return modPackage;
        }
    }
}