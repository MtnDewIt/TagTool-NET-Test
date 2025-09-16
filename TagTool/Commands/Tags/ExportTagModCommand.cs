﻿using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Commands.Common;
using TagTool.Tags.Definitions;
using TagTool.Cache.Eldorado;
using TagTool.Tags;
using System.Collections;
using TagTool.Cache.Gen3;

namespace TagTool.Commands.Tags
{
    class ExportTagModCommand : Command
    {
        public GameCacheEldoradoBase Cache { get; }

        public ExportTagModCommand(GameCacheEldoradoBase cache) :
            base(false,

                "ExportTagMod",
                "Generates a TagTool script for the specified tag(s). See 'Help ExportTagMod' instructions.",

                "ExportTagMod <Name> <Directory> {Tag1, ..., TagN}",

                "Generates a TagTool script for the specified tag(s).\n" +
                "Any dependencies/resources are dealt with automatically.\n" +
                "\n" +
                "Instructions:\n" +
                "1. Enter the command. Example: 'ExportTagMod MyMod myModFolder\n" +
                "2. You can now specify the tags you want to be used, seperate each tag with a new line.\n" +
                "3. After you have entered all of your tags, press enter while on an empty line to start the process.\n" +
                "\n" +
                "Warning: Tags with a ton of dependencies will cause the command to take a long time to finish.")
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count < 2)
                return new TagToolError(CommandError.ArgCount);

            var name = args[0];
            var directory = new DirectoryInfo(args[1]);

            if (!directory.Exists)
                directory.Create();

            var scriptFile = new FileInfo(Path.Combine(directory.FullName, $"{name}.cmds"));

            using (var cacheStream = Cache.OpenCacheRead())
            using (var scriptWriter = new StreamWriter(scriptFile.Exists ? scriptFile.Open(FileMode.Open, FileAccess.ReadWrite) : scriptFile.Create()))
            {
                var tagIndices = new HashSet<int>();
                var ignoredTagIndicies = new HashSet<int>();

                void LoadTagDependencies(int index)
                {
                    var queue = new List<int> { index };

                    while (queue.Count != 0)
                    {
                        var nextQueue = new List<int>();

                        foreach (var entry in queue)
                        {
                            if (!tagIndices.Contains(entry))
                            {
                                var instance = Cache.TagCacheEldorado.Tags[entry];

                                if (instance == null || instance.IsInGroup("rmt2") || instance.IsInGroup("rmdf") || instance.IsInGroup("vtsh") || instance.IsInGroup("pixl") || instance.IsInGroup("glvs") || instance.IsInGroup("glps"))
                                    continue;

                                tagIndices.Add(entry);

                                foreach (var dependency in instance.Dependencies)
                                {
                                    if (dependency == entry)
                                        continue;

                                    if (!nextQueue.Contains(dependency))
                                        nextQueue.Add(dependency);
                                }
                            }
                        }

                        queue = nextQueue;
                    }
                }

                Console.WriteLine("Please specify the tags to be used:");

                string line;

                while ((line = Console.ReadLine()) != "")
                {
                    if (!Cache.TagCache.TryGetTag(line, out var instance))
                        continue;

                    LoadTagDependencies(instance.Index);
                }

                Console.WriteLine("Please specify the tags to be ignored:");

                string ignoreLine;

                while ((ignoreLine = Console.ReadLine()) != "")
                {
                    if (!Cache.TagCache.TryGetTag(ignoreLine, out var instance))
                        continue;

                    ignoredTagIndicies.Add(instance.Index);
                }


                /*foreach (var index in tagIndices)
                {
                    var instance = CacheContext.GetTag(index);

                    if (instance == null || !instance.IsInGroup("bitm"))
                        continue;

                    var tagName = CacheContext.TagNames.ContainsKey(instance.Index) ?
                        instance.Name :
                        $"0x{instance.Index:X4}";

                    Console.WriteLine($"[Index: 0x{instance.Index:X4}, Offset: 0x{instance.HeaderOffset:X8}, Size: 0x{instance.TotalSize:X4}] {tagName}.{CacheContext.GetString(instance.Group.Name)}");
                }*/

                var importedTags = new HashSet<int>();

                foreach (var index in tagIndices)
                {
                    if (importedTags.Contains(index))
                        continue;

                    var instance = (CachedTagEldorado)Cache.TagCache.GetTag(index);

                    if (instance == null)
                        continue;

                    var tagName = instance.Name ?? $"{name}_0x{instance.Index:X4}";

                    var groupName = instance.Group;

                    if (ignoredTagIndicies.Contains(instance.Index))
                        continue;

                    var file = new FileInfo(Path.Combine(directory.FullName, $"tags\\{tagName}.{groupName}"));
                    var data = Cache.TagCacheEldorado.ExtractTagRaw(cacheStream, instance);

                    var tagDefinition = Cache.Deserialize(cacheStream, instance);

                    if (!file.Directory.Exists)
                        file.Directory.Create();

                    System.IO.TextWriter writeFile = new StreamWriter(file.FullName.ToString() + ".cmds");
                    Console.WriteLine("Exporting " + tagName + "." + groupName);
                    DumpCommands(writeFile, Cache, name, tagDefinition as TagStructure);
                    writeFile.Close();

                    using (var outStream = file.Create())
                        outStream.Write(data, 0, data.Length);

                    importedTags.Add(index);
                }

                scriptWriter.WriteLine($"SetVariable $TagFolderDirectory \"\"");
                scriptWriter.WriteLine();

                var completedTags = new HashSet<int>();

                foreach (var index in tagIndices)
                {
                    if (completedTags.Contains(index))
                        continue;

                    var instance = (CachedTagEldorado)Cache.TagCache.GetTag(index);

                    if (instance == null)
                        continue;

                    var tagName = instance.Name ?? $"{name}_0x{instance.Index:X4}";

                    var groupName = instance.Group;

                    var tagDefinition = Cache.Deserialize(cacheStream, instance);

                    if (ignoredTagIndicies.Contains(instance.Index))
                        continue;

                    FileInfo ExportResource(PageableResource pageable, string resourceGroup, string suffix = "")
                    {
                        if (pageable == null || !pageable.GetLocation(out var location))
                            return null;

                        var outFile = new FileInfo(Path.Combine(directory.FullName, $"tags\\{tagName}{suffix}.{resourceGroup}"));
                        var cache = Cache.ResourceCaches.GetResourceCache(location);

                        if (!outFile.Directory.Exists)
                            outFile.Directory.Create();

                        using (var stream = Cache.ResourceCaches.OpenCacheRead(location))
                        using (var outStream = outFile.Create())
                            cache.Decompress(stream, pageable.Page.Index, pageable.Page.CompressedBlockSize, outStream);

                        return outFile;
                    }

                    scriptWriter.WriteLine($"CreateTag {instance.Group.Tag} {tagName}");
                    scriptWriter.WriteLine($"ImportTag {tagName}.{groupName} \"$TagFolderDirectory\\{tagName}.{groupName}\"");
                    scriptWriter.WriteLine();

                    switch (tagDefinition)
                    {
                        case Bink bink:
                            {
                                scriptWriter.WriteLine($"EditTag {tagName}.{instance.Group.Tag}");

                                var resourceFile = ExportResource(bink.ResourceReference.EldoradoPageableResource, "bink_resource");

                                if (resourceFile == null)
                                {
                                    scriptWriter.WriteLine("SetField Resource null");
                                }
                                else
                                {
                                    scriptWriter.WriteLine($"SetField Resource.Page.Index -1");
                                    scriptWriter.WriteLine($"SetField Resource ResourcesB \"$TagFolderDirectory\\{tagName}.bink_resource\"");
                                }

                                scriptWriter.WriteLine("SaveTagChanges");
                                scriptWriter.WriteLine("Exit");
                                scriptWriter.WriteLine();
                            }
                            break;

                        case Bitmap bitm:
                            {
                                scriptWriter.WriteLine($"EditTag {tagName}.{instance.Group.Tag}");

                                for (var i = 0; i < bitm.HardwareTextures.Count; i++)
                                {
                                    var resourceFile = ExportResource(bitm.HardwareTextures[i].EldoradoPageableResource, "bitmap_texture_interop_resource", bitm.HardwareTextures.Count > 1 ? $"_image_{i}" : "_image");

                                    if (resourceFile == null)
                                    {
                                        scriptWriter.WriteLine($"SetField HardwareTextures[{i}].EldoradoPageableResource null");
                                        continue;
                                    }

                                    scriptWriter.WriteLine($"SetField HardwareTextures[{i}].EldoradoPageableResource.Page.Index -1");
                                    scriptWriter.WriteLine($"SetField HardwareTextures[{i}].EldoradoPageableResource ResourcesB \"$TagFolderDirectory\\{tagName}{(bitm.HardwareTextures.Count > 1 ? $"_image_{i}" : "_image")}.bitmap_texture_interop_resource\"");
                                }

                                scriptWriter.WriteLine("SaveTagChanges");
                                scriptWriter.WriteLine("Exit");
                                scriptWriter.WriteLine();
                            }
                            break;

                        case RenderModel mode:
                            {
                                scriptWriter.WriteLine($"EditTag {tagName}.{instance.Group.Tag}");

                                var resourceFile = ExportResource(mode.Geometry.Resource.EldoradoPageableResource, "render_geometry_api_resource_definition", "_geometry");

                                if (resourceFile == null)
                                {
                                    scriptWriter.WriteLine("SetField Geometry.Resource.EldoradoPageableResource null");
                                }
                                else
                                {
                                    scriptWriter.WriteLine($"SetField Geometry.Resource.EldoradoPageableResource.Page.Index -1");
                                    scriptWriter.WriteLine($"SetField Geometry.Resource.EldoradoPageableResource ResourcesB \"$TagFolderDirectory\\{tagName}_geometry.render_geometry_api_resource_definition\"");
                                }

                                scriptWriter.WriteLine("SaveTagChanges");
                                scriptWriter.WriteLine("Exit");
                                scriptWriter.WriteLine();
                            }
                            break;

                        case ModelAnimationGraph jmad:
                            {
                                scriptWriter.WriteLine($"EditTag {tagName}.{instance.Group.Tag}");

                                for (var i = 0; i < jmad.ResourceGroups.Count; i++)
                                {
                                    var resourceFile = ExportResource(jmad.ResourceGroups[i].ResourceReference.EldoradoPageableResource, "model_animation_tag_resource", jmad.ResourceGroups.Count > 1 ? $"_group_{i}" : "_group");

                                    if (resourceFile == null)
                                    {
                                        scriptWriter.WriteLine($"SetField ResourceGroups[{i}].ResourceReference.EldoradoPageableResource null");
                                        continue;
                                    }

                                    scriptWriter.WriteLine($"SetField ResourceGroups[{i}].ResourceReference.EldoradoPageableResource.Page.Index -1");
                                    scriptWriter.WriteLine($"SetField ResourceGroups[{i}].ResourceReference.EldoradoPageableResource ResourcesB \"$TagFolderDirectory\\{tagName}{(jmad.ResourceGroups.Count > 1 ? $"_group_{i}" : "_group")}.model_animation_tag_resource\"");
                                }

                                scriptWriter.WriteLine("SaveTagChanges");
                                scriptWriter.WriteLine("Exit");
                                scriptWriter.WriteLine();
                            }
                            break;

                        case ScenarioStructureBsp sbsp:
                            {
                                scriptWriter.WriteLine($"EditTag {tagName}.{instance.Group.Tag}");

                                var resourceFile = ExportResource(sbsp.DecoratorGeometry.Resource.EldoradoPageableResource, "render_geometry_api_resource_definition", "_decorator_geometry");

                                if (resourceFile == null)
                                {
                                    scriptWriter.WriteLine("SetField DecoratorGeometry.Resource.EldoradoPageableResource null");
                                }
                                else
                                {
                                    scriptWriter.WriteLine($"SetField DecoratorGeometry.Resource.EldoradoPageableResource.Page.Index -1");
                                    scriptWriter.WriteLine($"SetField DecoratorGeometry.Resource.EldoradoPageableResource ResourcesB \"$TagFolderDirectory\\{tagName}_decorator_geometry.render_geometry_api_resource_definition\"");
                                }

                                resourceFile = ExportResource(sbsp.Geometry.Resource.EldoradoPageableResource, "render_geometry_api_resource_definition", "_bsp_geometry");

                                if (resourceFile == null)
                                {
                                    scriptWriter.WriteLine("SetField Geometry.Resource.EldoradoPageableResource null");
                                }
                                else
                                {
                                    scriptWriter.WriteLine($"SetField Geometry.Resource.EldoradoPageableResource.Page.Index -1");
                                    scriptWriter.WriteLine($"SetField Geometry.Resource.EldoradoPageableResource ResourcesB \"$TagFolderDirectory\\{tagName}_bsp_geometry.render_geometry_api_resource_definition\"");
                                }

                                resourceFile = ExportResource(sbsp.CollisionBspResource.EldoradoPageableResource, "structure_bsp_tag_resources", "_collision");

                                if (resourceFile == null)
                                {
                                    scriptWriter.WriteLine("SetField CollisionBspResource.EldoradoPageableResource null");
                                }
                                else
                                {
                                    scriptWriter.WriteLine($"SetField CollisionBspResource.EldoradoPageableResource.Page.Index -1");
                                    scriptWriter.WriteLine($"SetField CollisionBspResource.EldoradoPageableResource ResourcesB \"$TagFolderDirectory\\{tagName}_collision.structure_bsp_tag_resources\"");
                                }

                                resourceFile = ExportResource(sbsp.PathfindingResource.EldoradoPageableResource, "structure_bsp_cache_file_tag_resources", "_pathfinding");

                                if (resourceFile == null)
                                {
                                    scriptWriter.WriteLine("SetField PathfindingResource.EldoradoPageableResource null");
                                }
                                else
                                {
                                    scriptWriter.WriteLine($"SetField PathfindingResource.EldoradoPageableResource.Page.Index -1");
                                    scriptWriter.WriteLine($"SetField PathfindingResource.EldoradoPageableResource ResourcesB \"$TagFolderDirectory\\{tagName}_pathfinding.structure_bsp_cache_file_tag_resources\"");
                                }

                                scriptWriter.WriteLine("SaveTagChanges");
                                scriptWriter.WriteLine("Exit");
                                scriptWriter.WriteLine();
                            }
                            break;

                        case ScenarioLightmapBspData sLdT:
                            {
                                scriptWriter.WriteLine($"EditTag {tagName}.{instance.Group.Tag}");

                                var resourceFile = ExportResource(sLdT.Geometry.Resource.EldoradoPageableResource, "render_geometry_api_resource_definition", "_lightmap_geometry");

                                if (resourceFile == null)
                                {
                                    scriptWriter.WriteLine("SetField Geometry.Resource.EldoradoPageableResource null");
                                }
                                else
                                {
                                    scriptWriter.WriteLine($"SetField Geometry.Resource.EldoradoPageableResource.Page.Index -1");
                                    scriptWriter.WriteLine($"SetField Geometry.Resource.EldoradoPageableResource ResourcesB \"$TagFolderDirectory\\{tagName}_lightmap_geometry.render_geometry_api_resource_definition\"");
                                }

                                scriptWriter.WriteLine("SaveTagChanges");
                                scriptWriter.WriteLine("Exit");
                                scriptWriter.WriteLine();
                            }
                            break;

                        case ParticleModel pmdf:
                            {
                                scriptWriter.WriteLine($"EditTag {tagName}.{instance.Group.Tag}");

                                var resourceFile = ExportResource(pmdf.Geometry.Resource.EldoradoPageableResource, "render_geometry_api_resource_definition", "_particle_geometry");

                                if (resourceFile == null)
                                {
                                    scriptWriter.WriteLine("SetField Geometry.Resource.EldoradoPageableResource null");
                                }
                                else
                                {
                                    scriptWriter.WriteLine($"SetField Geometry.Resource.EldoradoPageableResource.Page.Index -1");
                                    scriptWriter.WriteLine($"SetField Geometry.Resource.EldoradoPageableResource ResourcesB \"$TagFolderDirectory\\{tagName}_particle_geometry.render_geometry_api_resource_definition\"");
                                }

                                scriptWriter.WriteLine("SaveTagChanges");
                                scriptWriter.WriteLine("Exit");
                                scriptWriter.WriteLine();
                            }
                            break;

                        case Sound snd_:
                            {
                                scriptWriter.WriteLine($"EditTag {tagName}.{instance.Group.Tag}");

                                var resourceFile = ExportResource(snd_.Resource.EldoradoPageableResource, "sound_resource");

                                if (resourceFile == null)
                                {
                                    scriptWriter.WriteLine("SetField Resource.EldoradoPageableResource null");
                                }
                                else
                                {
                                    scriptWriter.WriteLine($"SetField Resource.EldoradoPageableResource.Page.Index -1");
                                    scriptWriter.WriteLine($"SetField Resource.EldoradoPageableResource ResourcesB \"$TagFolderDirectory\\{tagName}.sound_resource\"");
                                }

                                scriptWriter.WriteLine("SaveTagChanges");
                                scriptWriter.WriteLine("Exit");
                                scriptWriter.WriteLine();
                            }
                            break;
                    }

                    completedTags.Add(instance.Index);
                }

                var completedTagReferenecs = new HashSet<int>();

                foreach (var index in tagIndices)
                {
                    if (completedTagReferenecs.Contains(index))
                        continue;

                    var instance = (CachedTagEldorado)Cache.TagCache.GetTag(index);

                    if (instance == null)
                        continue;

                    if (ignoredTagIndicies.Contains(instance.Index))
                        continue;

                    var tagName = instance.Name ?? $"{name}_0x{instance.Index:X4}";
                    var groupName = instance.Group;

                    scriptWriter.WriteLine($"edittag {tagName}.{groupName}");
                    scriptWriter.WriteLine($"runcommands \"$TagFolderDirectory\\{tagName}.{groupName}.cmds\"");
                    scriptWriter.WriteLine($"savetagchanges");
                    scriptWriter.WriteLine($"Exit");
                    scriptWriter.WriteLine();

                    completedTagReferenecs.Add(instance.Index);
                }
            
                scriptWriter.WriteLine();
                scriptWriter.WriteLine("SaveTagNames");
                scriptWriter.WriteLine("UpdateMapFiles");
                scriptWriter.WriteLine("DumpLog");
                scriptWriter.WriteLine("Exit");
                scriptWriter.WriteLine();
            }

            Console.WriteLine("Done.");

            return true;
        }

        private void DumpCommands(TextWriter writer, GameCache cache, string name, object data, string fieldName = null)
        {
            switch (data)
            {
                case TagStructure tagStruct:
                    {
                        foreach (var field in tagStruct.GetTagFieldEnumerable(cache.Version, cache.Platform))
                            DumpCommands(writer, cache, name, field.GetValue(data), fieldName != null ? $"{fieldName}.{field.Name}" : field.Name);
                    }
                    break;
                case IList collection:
                    {
                        if (collection.Count > 0)
                        {
                            if(!fieldName.Contains("Unused") && !fieldName.Contains("].Data") && !fieldName.Contains("Padding") && !fieldName.Contains("Function.Data"))
                            {
                                for (int i = 0; i < collection.Count; i++)
                                    DumpCommands(writer, cache, name, collection[i], $"{fieldName}[{i}]");
                            }
                        }
                    }
                    break;
                case StringId stringId:
                    {
                        writer.WriteLine($"SetField {fieldName} {Cache.StringTable.GetString(stringId)}");
                    }
                    break;
                default:
                    var definitions = new TagDefinitionsGen3();
                    string fieldValue = $"{data}";

                    foreach (KeyValuePair<TagGroup, Type> tagType in definitions.Gen3Types)
                    {
                        if (fieldValue.EndsWith("." + tagType.Key.ToString()))
                        {
                            if (!fieldName.Contains("EldoradoPageableResource"))
                            {
                                if(fieldValue.StartsWith("0x"))
                                {
                                    string index = fieldValue.Substring(6, 4);
                                    string groupType = fieldValue.Split('.')[1];
                                    fieldValue = $"{name}_0x{index}.{groupType}";
                                }

                                writer.WriteLine($"SetField {fieldName} {fieldValue}");
                            }
                        }
                    }
                    break;
            }
        }
    }
}