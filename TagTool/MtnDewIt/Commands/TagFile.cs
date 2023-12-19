using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags;
using System.IO;
using System.Text.RegularExpressions;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.Linq;
using System;
using System.Globalization;
using TagTool.Bitmaps.DDS;
using TagTool.Bitmaps;
using TagTool.IO;
using System.Collections.Generic;
using TagTool.Animations;
using TagTool.Tags.Resources;
using TagTool.Scripting.Compiler;

namespace TagTool.MtnDewIt.Commands 
{
    public abstract class TagFile 
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }

        public Stream Stream { get; set; }

        public TagFile(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) 
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
        }

        public void AddString(MultilingualUnicodeStringList unic, string stringIdName, string stringIdContent)
        {
            var stringIdIndex = Cache.StringTable.IndexOf(stringIdName);

            if (stringIdIndex < 0)
            {
                Cache.StringTable.AddString(stringIdName);
                Cache.SaveStrings();

                stringIdIndex = Cache.StringTable.IndexOf(stringIdName);
            }
            var stringId = Cache.StringTable.GetStringId(stringIdIndex);

            var parsedContent = new Regex(@"\\[uU]([0-9A-F]{4})").Replace(stringIdContent, match => ((char)Int32.Parse(match.Value.Substring(2), NumberStyles.HexNumber)).ToString());

            var localizedStr = unic.Strings.FirstOrDefault(s => s.StringID == stringId);

            if (localizedStr == null)
            {
                localizedStr = new LocalizedString
                {
                    StringID = stringId,
                    StringIDStr = stringIdName
                };

                unic.Strings.Add(localizedStr);
            }

            unic.SetString(localizedStr, GameLanguage.English, parsedContent);
        }

        public void AddBitmap(Bitmap bitmap, int bitmapIndex, string DDS)
        {
            bitmap.Flags = BitmapRuntimeFlags.UsingTagInteropAndTagResource;
            bitmap.Images.Add(new Bitmap.Image { Signature = new Tag("bitm") });
            bitmap.HardwareTextures.Add(new TagResourceReference());

            var imageIndex = bitmapIndex;
            BitmapImageCurve curve = BitmapImageCurve.xRGB;

            DDSFile dds = new DDSFile();

            using (var imageStream = File.OpenRead(DDS))
            using (var reader = new EndianReader(imageStream))
            {
                dds.Read(reader);
            }

            var bitmapTextureInteropDefinition = BitmapInjector.CreateBitmapResourceFromDDS(Cache, dds, curve);
            var reference = Cache.ResourceCache.CreateBitmapResource(bitmapTextureInteropDefinition);

            bitmap.HardwareTextures[imageIndex] = reference;
            bitmap.Images[imageIndex] = BitmapUtils.CreateBitmapImageFromResourceDefinition(bitmapTextureInteropDefinition.Texture.Definition.Bitmap);
        }

        public void AddAnimation(CachedTag tag, string animationFile)
        {
            var jmad = CacheContext.Deserialize<ModelAnimationGraph>(Stream, tag);

            var filepath = new FileInfo(animationFile);

            string file_extension = filepath.Extension;

            var AnimationType = ModelAnimationGraph.FrameType.Base;
            var isWorldRelative = false;
            var FrameInfoType = ModelAnimationTagResource.GroupMemberMovementDataType.None;

            switch (file_extension.ToUpper())
            {
                case ".JMM":
                    break;
                case ".JMW":
                    isWorldRelative = true;
                    break;
                case ".JMO":
                    AnimationType = ModelAnimationGraph.FrameType.Overlay;
                    break;
                case ".JMR":
                    AnimationType = ModelAnimationGraph.FrameType.Replacement;
                    break;
                case ".JMA":
                    FrameInfoType = ModelAnimationTagResource.GroupMemberMovementDataType.dx_dy;
                    break;
                case ".JMT":
                    FrameInfoType = ModelAnimationTagResource.GroupMemberMovementDataType.dx_dy_dyaw;
                    new TagToolWarning("Advanced Movement data not currently supported, animation may not display properly!");
                    break;
                case ".JMZ":
                    FrameInfoType = ModelAnimationTagResource.GroupMemberMovementDataType.dx_dy_dz_dyaw;
                    new TagToolWarning("Advanced Movement data not currently supported, animation may not display properly!");
                    break;
                default:
                    new TagToolError(CommandError.CustomError, $"Filetype {file_extension.ToUpper()} not recognized!");
                    return;
            }

            string file_name = Path.GetFileNameWithoutExtension(filepath.FullName).Replace(' ', ':');
            StringId animation_name = CacheContext.StringTable.GetStringId(file_name);
            if (animation_name == StringId.Invalid)
                animation_name = CacheContext.StringTable.AddString(file_name);

            var importer = new AnimationImporter();

            if (!importer.Import(filepath.FullName)) 
            {
                new TagToolError(CommandError.FileIO);
            }

            if (importer.Version >= 16394)
            {
                new TagToolError(CommandError.CustomError, $@"Invalid Animation Format");
            }

            List<AnimationImporter.AnimationNode> newAnimationNodes = new List<AnimationImporter.AnimationNode>();
            foreach (var skellynode in jmad.SkeletonNodes)
            {
                string nodeName = Cache.StringTable.GetString(skellynode.Name);
                int matching_index = importer.AnimationNodes.FindIndex(x => x.Name.Equals(nodeName));
                if (matching_index == -1)
                {
                    new TagToolWarning($"No node matching '{nodeName}' found in imported file! Will proceed with blank data for missing node");
                    newAnimationNodes.Add(new AnimationImporter.AnimationNode()
                    {
                        Name = nodeName,
                        FirstChildNode = skellynode.FirstChildNodeIndex,
                        NextSiblingNode = skellynode.NextSiblingNodeIndex,
                        ParentNode = skellynode.ParentNodeIndex
                    });
                }
                else
                {
                    AnimationImporter.AnimationNode matching_node = importer.AnimationNodes[matching_index];
                    matching_node.FirstChildNode = skellynode.FirstChildNodeIndex;
                    matching_node.NextSiblingNode = skellynode.NextSiblingNodeIndex;
                    matching_node.ParentNode = skellynode.ParentNodeIndex;
                    newAnimationNodes.Add(matching_node);
                }
            }

            importer.AnimationNodes = newAnimationNodes;

            importer.ProcessNodeFrames(CacheContext, AnimationType, FrameInfoType);

            ModelAnimationTagResource newResource = new ModelAnimationTagResource
            {
                GroupMembers = new TagBlock<ModelAnimationTagResource.GroupMember>()
            };
            newResource.GroupMembers.Add(importer.SerializeAnimationData(CacheContext));
            newResource.GroupMembers.AddressType = CacheAddressType.Definition;

            TagResourceReference resourceref = CacheContext.ResourceCache.CreateModelAnimationGraphResource(newResource);

            jmad.ResourceGroups.Add(new ModelAnimationGraph.ResourceGroup
            {
                ResourceReference = resourceref,
                MemberCount = 1
            });

            var AnimationBlock = new ModelAnimationGraph.Animation
            {
                Name = animation_name,
                AnimationData = new ModelAnimationGraph.Animation.SharedAnimationData
                {
                    AnimationType = AnimationType,
                    FrameInfoType = (FrameInfoType)FrameInfoType,
                    BlendScreen = -1,
                    DesiredCompression = ModelAnimationGraph.Animation.CompressionValue.BestAccuracy,
                    CurrentCompression = ModelAnimationGraph.Animation.CompressionValue.BestAccuracy,
                    FrameCount = (short)importer.frameCount,
                    NodeCount = (sbyte)importer.AnimationNodes.Count,
                    NodeListChecksum = 0,
                    ImporterVersion = 5,
                    CompressorVersion = 6,
                    Heading = new RealVector3d(1, 0, 0),
                    ParentAnimation = -1,
                    NextAnimation = -1,
                    ResourceGroupIndex = (short)(jmad.ResourceGroups.Count - 1),
                    ResourceGroupMemberIndex = 0,
                }
            };

            if (isWorldRelative)
                AnimationBlock.AnimationData.InternalFlags |= ModelAnimationGraph.Animation.InternalFlagsValue.WorldRelative;

            jmad.Animations.Add(AnimationBlock);

            CacheContext.SaveStrings();
            CacheContext.Serialize(Stream, tag, jmad);
        }

        public void CompileScript(CachedTag tag, string scriptFile)
        {
            var scriptData = new FileInfo(scriptFile);

            var scnr = CacheContext.Deserialize<Scenario>(Stream, tag);

            ScriptCompiler scriptCompiler = new ScriptCompiler(Cache, scnr);

            scriptCompiler.CompileFile(scriptData);

            CacheContext.Serialize(Stream, tag, scnr);
        }

        public void SortModes(CachedTag tag)
        {
            var jmad = CacheContext.Deserialize<ModelAnimationGraph>(Stream, tag);

            var resolver = CacheContext.StringTable.Resolver;

            jmad.Modes = jmad.Modes.OrderBy(a => resolver.GetSet(a.Name)).ThenBy(a => resolver.GetIndex(a.Name)).ToList();

            foreach (var mode in jmad.Modes)
            {
                mode.WeaponClass = mode.WeaponClass.OrderBy(a => resolver.GetSet(a.Label)).ThenBy(a => resolver.GetIndex(a.Label)).ToList();

                foreach (var weaponClass in mode.WeaponClass)
                {
                    weaponClass.WeaponType = weaponClass.WeaponType.OrderBy(a => resolver.GetSet(a.Label)).ThenBy(a => resolver.GetIndex(a.Label)).ToList();

                    foreach (var weaponType in weaponClass.WeaponType)
                    {
                        weaponType.Set.Actions = weaponType.Set.Actions.OrderBy(a => resolver.GetSet(a.Label)).ThenBy(a => resolver.GetIndex(a.Label)).ToList();
                        weaponType.Set.Overlays = weaponType.Set.Overlays.OrderBy(a => resolver.GetSet(a.Label)).ThenBy(a => resolver.GetIndex(a.Label)).ToList();
                        weaponType.Set.DeathAndDamage = weaponType.Set.DeathAndDamage.OrderBy(a => resolver.GetSet(a.Label)).ThenBy(a => resolver.GetIndex(a.Label)).ToList();
                        weaponType.Set.Transitions = weaponType.Set.Transitions.OrderBy(a => resolver.GetSet(a.FullName)).ThenBy(a => resolver.GetIndex(a.FullName)).ToList();

                        foreach (var transition in weaponType.Set.Transitions)
                        {
                            transition.Destinations = transition.Destinations.OrderBy(a => resolver.GetSet(a.FullName)).ThenBy(a => resolver.GetIndex(a.FullName)).ToList();
                        }
                    }
                }
            }

            CacheContext.Serialize(Stream, tag, jmad);
        }

        public CachedTag GetCachedTag<T>(string tagName) where T : TagStructure
        {
            var tagAttribute = TagStructure.GetTagStructureAttribute(typeof(T), CacheContext.Version, CacheContext.Platform);
            var typeName = tagAttribute.Tag;

            if (CacheContext.TagCache.TryGetTag<T>(tagName, out var result))
            {
                return result;
            }
            else
            {
                new TagToolWarning($@"Could not find tag: '{tagName}.{typeName}'. Assigning null tag instead");
                return null;
            }
        }

        public abstract void TagData();
    }
}