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
using System.Collections;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Tags
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

        public class ScenarioObjectTypeDefinition
        {
            public IList Instances;
            public IList Palette;

            public ScenarioObjectTypeDefinition(IList instances, IList palette)
            {
                Instances = instances;
                Palette = palette;
            }
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

        public void UpdateForgeObjects(CachedTag scenario)
        {
            var scnr = CacheContext.Deserialize<Scenario>(Stream, scenario);

            for (int i = 0; i < scnr.SandboxVehicles.Count; i++)
            {
                var sandboxEntry = scnr.SandboxVehicles[i];

                if (sandboxEntry.Object != null)
                {
                    var sandboxObject = CacheContext.Deserialize(Stream, sandboxEntry.Object);

                    if (sandboxObject is GameObject obje)
                    {
                        if (obje.MultiplayerObject.Count == 0 || obje.MultiplayerObject == null)
                        {
                            obje.MultiplayerObject = new List<GameObject.MultiplayerObjectBlock>
                            {
                                new GameObject.MultiplayerObjectBlock
                                {
                                    DefaultSpawnTime = 30,
                                    DefaultAbandonTime = 30,
                                },
                            };
                        }
                    }
                    
                    CacheContext.Serialize(Stream, sandboxEntry.Object, sandboxObject);
                }
            }

            for (int i = 0; i < scnr.SandboxWeapons.Count; i++)
            {
                var sandboxEntry = scnr.SandboxWeapons[i];

                if (sandboxEntry.Object != null)
                {
                    var sandboxObject = CacheContext.Deserialize(Stream, sandboxEntry.Object);

                    if (sandboxObject is GameObject obje)
                    {
                        if (obje.MultiplayerObject.Count == 0 || obje.MultiplayerObject == null)
                        {
                            obje.MultiplayerObject = new List<GameObject.MultiplayerObjectBlock>
                            {
                                new GameObject.MultiplayerObjectBlock
                                {
                                    DefaultSpawnTime = 30,
                                    DefaultAbandonTime = 30,
                                },
                            };
                        }
                    }
                    
                    CacheContext.Serialize(Stream, sandboxEntry.Object, sandboxObject);
                }
            }

            for (int i = 0; i < scnr.SandboxEquipment.Count; i++)
            {
                var sandboxEntry = scnr.SandboxEquipment[i];

                if (sandboxEntry.Object != null)
                {
                    var sandboxObject = CacheContext.Deserialize(Stream, sandboxEntry.Object);

                    if (sandboxObject is GameObject obje)
                    {
                        if (obje.MultiplayerObject.Count == 0 || obje.MultiplayerObject == null)
                        {
                            obje.MultiplayerObject = new List<GameObject.MultiplayerObjectBlock>
                            {
                                new GameObject.MultiplayerObjectBlock
                                {
                                    DefaultSpawnTime = 30,
                                    DefaultAbandonTime = 30,
                                },
                            };
                        }
                    }
                    
                    CacheContext.Serialize(Stream, sandboxEntry.Object, sandboxObject);
                }
            }

            for (int i = 0; i < scnr.SandboxScenery.Count; i++)
            {
                var sandboxEntry = scnr.SandboxScenery[i];

                if (sandboxEntry.Object != null)
                {
                    var sandboxObject = CacheContext.Deserialize(Stream, sandboxEntry.Object);

                    if (sandboxObject is GameObject obje)
                    {
                        if (obje.MultiplayerObject.Count == 0 || obje.MultiplayerObject == null)
                        {
                            obje.MultiplayerObject = new List<GameObject.MultiplayerObjectBlock>
                            {
                                new GameObject.MultiplayerObjectBlock
                                {
                                    DefaultSpawnTime = 30,
                                    DefaultAbandonTime = 30,
                                },
                            };
                        }
                    }
                    
                    CacheContext.Serialize(Stream, sandboxEntry.Object, sandboxObject);
                }
            }

            for (int i = 0; i < scnr.SandboxTeleporters.Count; i++)
            {
                var sandboxEntry = scnr.SandboxTeleporters[i];

                if (sandboxEntry.Object != null)
                {
                    var sandboxObject = CacheContext.Deserialize(Stream, sandboxEntry.Object);

                    if (sandboxObject is GameObject obje)
                    {
                        if (obje.MultiplayerObject.Count == 0 || obje.MultiplayerObject == null)
                        {
                            obje.MultiplayerObject = new List<GameObject.MultiplayerObjectBlock>
                            {
                                new GameObject.MultiplayerObjectBlock
                                {
                                    DefaultSpawnTime = 30,
                                    DefaultAbandonTime = 30,
                                },
                            };
                        }
                    }
                    
                    CacheContext.Serialize(Stream, sandboxEntry.Object, sandboxObject);
                }
            }

            for (int i = 0; i < scnr.SandboxGoalObjects.Count; i++)
            {
                var sandboxEntry = scnr.SandboxGoalObjects[i];

                if (sandboxEntry.Object != null)
                {
                    var sandboxObject = CacheContext.Deserialize(Stream, sandboxEntry.Object);

                    if (sandboxObject is GameObject obje)
                    {
                        if (obje.MultiplayerObject.Count == 0 || obje.MultiplayerObject == null)
                        {
                            obje.MultiplayerObject = new List<GameObject.MultiplayerObjectBlock>
                            {
                                new GameObject.MultiplayerObjectBlock
                                {
                                    DefaultSpawnTime = 30,
                                    DefaultAbandonTime = 30,
                                },
                            };
                        }
                    }
                    
                    CacheContext.Serialize(Stream, sandboxEntry.Object, sandboxObject);
                }
            }

            for (int i = 0; i < scnr.SandboxSpawning.Count; i++)
            {
                var sandboxEntry = scnr.SandboxSpawning[i];

                if (sandboxEntry.Object != null)
                {
                    var sandboxObject = CacheContext.Deserialize(Stream, sandboxEntry.Object);

                    if (sandboxObject is GameObject obje)
                    {
                        if (obje.MultiplayerObject.Count == 0 || obje.MultiplayerObject == null)
                        {
                            obje.MultiplayerObject = new List<GameObject.MultiplayerObjectBlock>
                            {
                                new GameObject.MultiplayerObjectBlock
                                {
                                    DefaultSpawnTime = 30,
                                    DefaultAbandonTime = 30,
                                },
                            };
                        }
                    }
                    
                    CacheContext.Serialize(Stream, sandboxEntry.Object, sandboxObject);
                }
            }
        }

        public void UpdateForgePalette(Scenario scnr)
        {
            scnr.SandboxVehicles = new List<Scenario.SandboxObject>
            {
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\levels\dlc\sidewinder\hornet_lite\hornet_lite"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\levels\multi\shrine\behemoth\behemoth_forge"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\banshee\banshee"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\brute_chopper\brute_chopper"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\ghost\ghost"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\ghost\ghost_snow"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\hornet\hornet"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\mauler\mauler"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\mongoose\mongoose"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\mongoose\mongoose_snow"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\scorpion\scorpion"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\scorpion\scorpion_snow"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\shade\shade"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_gauss"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_gauss_snow"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_no_turret"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_snow"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_snow_gauss"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_snow_no_turret"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_snow_troop"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_snow_wrecked"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_troop"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_wrecked"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_wrecked_turret"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\wraith\wraith"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\vehicles\wraith\wraith_anti_air"),
                },
            };
            scnr.SandboxWeapons = new List<Scenario.SandboxObject>
            {
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\weapons\turret\machinegun_turret\machinegun_turret"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\weapons\turret\missile_pod\missile_pod"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\weapons\turret\plasma_cannon\plasma_cannon"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\levels\dlc\shared\golf_club\golf_club"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\melee\energy_blade\energy_blade"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\melee\gravity_hammer\gravity_hammer"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\excavator\excavator"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\excavator\excavator_v3\excavator_v3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum_v2\magnum_v2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum_v3\magnum_v3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol_v3\plasma_pistol_v3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle_v2\assault_rifle_v2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle_v3\assault_rifle_v3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle_v5\assault_rifle_v5"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle_v6\assault_rifle_v6"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v1\battle_rifle_v1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v2\battle_rifle_v2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v3\battle_rifle_v3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v4\battle_rifle_v4"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v5\battle_rifle_v5"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v6\battle_rifle_v6"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\beam_rifle\beam_rifle"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v1\covenant_carbine_v1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v2\covenant_carbine_v2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v3\covenant_carbine_v3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v4\covenant_carbine_v4"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v5\covenant_carbine_v5"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v6\covenant_carbine_v6"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\dmr\dmr"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\dmr\dmr_v1\dmr_v1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\dmr\dmr_v2\dmr_v2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\dmr\dmr_v3\dmr_v3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\dmr\dmr_v4\dmr_v4"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\dmr\dmr_v6\dmr_v6"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle_v6\plasma_rifle_v6"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\shotgun\shotgun"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\smg\smg"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\smg\smg_v1\smg_v1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\smg\smg_v2\smg_v2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\smg\smg_v4\smg_v4"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\smg\smg_v6\smg_v6"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\sniper_rifle\sniper_rifle"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\support_high\rocket_launcher\rocket_launcher"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\support_high\spartan_laser\spartan_laser"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\support_low\sentinel_gun\sentinel_gun"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\turret\flamethrower\flamethrower"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\turret\machinegun_turret\machinegun_turret"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\turret\missile_pod\missile_pod"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\weapons\turret\plasma_cannon\plasma_cannon"),
                },
            };
            scnr.SandboxEquipment = new List<Scenario.SandboxObject>
            {
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\equipment\autoturret_equipment\autoturret_equipment"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\equipment\bubbleshield_equipment\bubbleshield_equipment"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\equipment\concussiveblast_equipment\concussiveblast_equipment"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\equipment\gravlift_equipment\gravlift_equipment"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\equipment\hologram_equipment\hologram_equipment"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\equipment\instantcover_equipment\instantcover_equipment"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\equipment\instantcover_equipment\instantcover_equipment_mp"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\equipment\invincibility_equipment\invincibility_equipment"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\equipment\invisibility_equipment\invisibility_equipment"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\equipment\invisibility_vehicle_equipment\invisibility_vehicle_equipment"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\equipment\jammer_equipment\jammer_equipment"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\equipment\lightningstrike_equipment\lightningstrike_equipment"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\equipment\powerdrain_equipment\powerdrain_equipment"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\equipment\reactive_armor_equipment\reactive_armor_equipment"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\equipment\regenerator_equipment\regenerator_equipment"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\equipment\superflare_equipment\superflare_equipment"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\equipment\tripmine_equipment\tripmine_equipment"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\equipment\vision_equipment\vision_equipment"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\multi\powerups\powerup_blue\powerup_blue"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\multi\powerups\powerup_red\powerup_red"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\multi\powerups\powerup_yellow\powerup_yellow"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\powerups\ammo_packs\ammo_large\ammo_large"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\powerups\ammo_packs\ammo_small\ammo_small"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\powerups\rocket_launcher_ammo\rocket_launcher_ammo"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\weapons\grenade\claymore_grenade\claymore_grenade"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\weapons\grenade\firebomb_grenade\firebomb_grenade"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\weapons\grenade\frag_grenade\frag_grenade"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\weapons\grenade\plasma_grenade\plasma_grenade"),
                },
            };
            scnr.SandboxScenery = new List<Scenario.SandboxObject>
            {
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"ms30\objects\gear\human\industrial\crate_multi_single\crate_multi_single"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"ms30\objects\levels\dlc\bunkerworld\drum_55gal_bunker\drum_55gal_bunker"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\covenant\military\antennae_comm_mp\antennae_comm_mp"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\covenant\military\battery\battery"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\covenant\military\cov_barrier\cov_barrier"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\covenant\military\cov_camp_stool\cov_camp_stool"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\covenant\military\cov_sword_holder\cov_sword_holder"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\covenant\military\cov_watchtower\cov_watchtower_base\cov_watchtower_base"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\covenant\military\cov_watchtower\cov_watchtower_pod\cov_watchtower_pod"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\covenant\military\cov_watchtower\cov_watchtower_pod\cov_watchtower_pod_turrets"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\covenant\military\crate_space\crate_space"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\covenant\military\crate_space_a\crate_space_a"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\covenant\military\crate_space_b\crate_space_b"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\covenant\military\crate_space_small\crate_space_small"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\forerunner\power_core_for\power_core_for"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\forerunner\power_core_for_stable\power_core_for_stable"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\forerunner\power_module_01\power_module_01"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\box_cardboard_medium_b\box_cardboard_medium_b"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\box_cardboard_small\box_cardboard_small"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\box_metal_small\box_metal_small"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\crate_multi\crate_multi"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\crate_multi_single\crate_multi_single"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\crate_tech\crate_tech"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\crate_tech_giant\crate_tech_giant"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\crate_tech_semi_short\crate_tech_semi_short"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\crate_tech_semi_short_closed\crate_tech_semi_short_closed"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\crowbar\crowbar"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\garbage_can\garbage_can"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\generator_heavy_grill\generator_heavy_grill"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\generator_heavy_kettle\generator_heavy_kettle"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\h_barrel_rusty\h_barrel_rusty"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\h_barrel_rusty_small\h_barrel_rusty_small"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\jersey_barrier\jersey_barrier"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\jersey_barrier_short\jersey_barrier_short"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\pallet\pallet"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\pallet\pallet_broken01\pallet_broken01"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\pallet\pallet_broken03\pallet_broken03"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\pallet_large\pallet_large"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\propane_tank\propane_tank"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\sawhorse\sawhorse"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\sawhorse\sawhorse_light"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\street_cone\street_cone"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\toolbox_large\toolbox_large"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\industrial\toolbox_small\toolbox_small"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\medical\cabinet\cabinet"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\medical\crashcart\crashcart"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\medical\medical_crate\medical_crate"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\medical\medical_tray\medical_tray"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\antennae_mast\antennae_mast"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\barricade_large\barricade_large"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\barricade_small\barricade_small"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\blitzcan\blitzcan"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\camping_stool_mp\camping_stool_mp"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\case\case"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\case_ap_turret\case_ap_turret"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\case_ap_turret_lid\case_ap_turret_lid"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\case_ap_turret_open\case_ap_turret_open"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\comm_phonebox\comm_phonebox"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\crate_packing\crate_packing"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\crate_packing_giant\crate_packing_giant_mp"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\drum_12gal\drum_12gal"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\drum_55gal\drum_55gal"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\fusion_coil\fusion_coil"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\generator\generator"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\generator\generator_off"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\generator_light\generator_flood_no_lights"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\h_ammo_crate_lg\h_ammo_crate_lg"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\h_ammo_crate_sm\h_ammo_crate_sm"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\hu_mil_radio_big\hu_mil_radio_big"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\hu_mil_radio_small\hu_mil_radio_small"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\hu_mil_rucksack\rucksack"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\missle\missle"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\missle_body\missle_body"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\missle_cap\missle_cap"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\propane_burner\propane_burner"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\resupply_capsule_panel\resupply_capsule_panel"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\military\resupply_capsule_unfired\resupply_capsule_unfired"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\residential\h_locker_closed_mp\h_locker_closed_mp"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\residential\office_chair\office_chair"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\residential\office_file_short\office_file_short"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\residential\office_file_tall\office_file_tall"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\residential\office_keyboard\office_keyboard"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\residential\office_monitor\office_monitor"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\residential\office_stand\office_stand"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\gear\human\residential\telephone_wall_box\telephone_wall_box"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\chillout\chill_energy_blocker_small\chill_energy_blocker_small"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\chillout\chill_viewing_area_blocker\chill_viewing_area_blocker"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\chillout\chill_viewing_area_blocker_small\chill_viewing_area_blocker_small"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\descent\base_gravlift_descent\base_gravlift_descent"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\descent\base_gravlift_descent_yellow\base_gravlift_descent_yellow"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\descent\door_blocker\door_blocker"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\descent\egg_shield\egg_shield"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\descent\man_cannon_descent\man_cannon_descent"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\docks\dingy\dingy"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\docks\door_blocker_large\door_blocker_large"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\docks\door_blocker_medium\door_blocker_medium"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\docks\door_blocker_small\door_blocker_small"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\docks\fish_cans_palette\fish_cans_palette"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\docks\fish_tote\fish_tote"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\docks\water_barrels\water_barrels"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\fortress\fort_energy_blocker_small\fort_energy_blocker_small"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\fortress\fort_energy_blocker_small_b\fort_energy_blocker_small_b"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\fortress\fort_forge_crate_blue\fort_forge_crate_blue"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\fortress\fort_forge_crate_red\fort_forge_crate_red"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\ghosttown\ghosttown_block\ghosttown_block"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\ghosttown\ghosttown_bridge\ghosttown_bridge"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\ghosttown\ghosttown_panel\ghosttown_panel"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\ghosttown\ghosttown_platform\ghosttown_platform"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\ghosttown\ghosttown_scaffold\ghosttown_scaffold"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\ghosttown\ghosttown_small_bridge\ghosttown_small_bridge"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\ghosttown\gt_forge_door\gt_forge_door"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\lockout\core_shelf\core_shelf"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\lockout\fence_door\fence_door"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\lockout\lift_interior\lift_interior"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\midship\middle_physics_volume\middle_physics_volume"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_1x1_lilramp\sand_1x1_lilramp"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_2x2_lilramp\sand_2x2_lilramp"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_archtop\sand_archtop"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_block\sand_block"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_block_flat\sand_block_flat"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_block_large\sand_block_large"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_block_ramp\sand_block_ramp"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_block_wittle\sand_block_wittle"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_bridge\sand_bridge"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_column_short\sand_column_short"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_column_short_red\sand_column_short_red"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_column_tt\sand_column_tt"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_cylinder\sand_cylinder"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_cylinder_end\sand_cylinder_end"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_cylinder_lturn\sand_cylinder_lturn"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_cylinder_threeway\sand_cylinder_threeway"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_gatehouse\sand_gatehouse"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_large_cube\sand_large_cube"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_large_cube_pillar\sand_large_cube_pillar"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_large_cubex2\sand_large_cubex2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_large_halfcube\sand_large_halfcube"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_large_halfcubex2\sand_large_halfcubex2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_large_wood_bridge\sand_large_wood_bridge"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_long_cuberamp\sand_long_cuberamp"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_mast_house\sand_mast_house"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_pyr_bridge\sand_pyr_bridge"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_pyr_corner\sand_pyr_corner"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_pyr_corner_extender\sand_pyr_corner_extender"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_ramp\sand_ramp"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_scaffold\sand_scaffold"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_slant_cube\sand_slant_cube"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_slant_cube_corner\sand_slant_cube_corner"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_small_cuberamp\sand_small_cuberamp"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_small_wood_bridge\sand_small_wood_bridge"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_wall\sand_wall"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_wall_forge\sand_wall"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_wall_halfdoor\sand_wall_halfdoor"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_wall_lowdoor\sand_wall_lowdoor"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_wall_lsection\sand_wall_lsection"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_wall_slit\sand_wall_slit"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_wall_tsection\sand_wall_tsection"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sand_wallx2\sand_wallx2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sandbox_light_blue\sandbox_light_blue"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\sandbox_light_red\sandbox_light_red"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\stone_column_damaged\stone_column_damaged"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\stone_column_short\stone_column_short"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\stone_column_tall\stone_column_tall"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\armory_shield_door\armory_shield_door"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\chill_sheild_door\chill_sheild_door"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\crate_tech_semi\crate_tech_semi"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\crate_tech_semi_closed\crate_tech_semi_closed"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\crate_tech_semi_short\crate_tech_semi_short"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\crate_tech_semi_short_closed\crate_tech_semi_short_closed"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\damage_sphere\damage_sphere"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\decent_shield_door_tall\decent_shield_door_tall"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\decent_shield_door_wide\decent_shield_door_wide"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\dlc_box_wooden_small\box_wooden_small"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\docks_large_shield_door\docks_large_shield_door"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\docks_small_shield_door01\docks_small_shield_door01"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\fort_shield_door\fort_shield_door"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\ghosttown_shield_door\ghosttown_shield_door"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\golf_cup\golf_cup"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\large_shield_door\large_shield_door"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\man_cannon_forge\man_cannon_forge"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\midship_sheild_door_large\midship_sheild_door_large"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\midship_shield_door_small\midship_shield_door_small"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\small_shield_door\small_shield_door"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\soccer_ball\soccer_ball"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\water_barrel_single\water_barrel_single"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\shared\water_barrels\water_barrels"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\fore_fightposition\fore_fightposition"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\fore_ramp\fore_ramp"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\fore_wall\fore_wall"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\fore_wall_sheild\fore_wall_sheild"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\fore_wallcorner\fore_wallcorner"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\lift_sidewinder\lift_sidewinder"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_01\man_cannon_sidewinder_01"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_02\man_cannon_sidewinder_02"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_03\man_cannon_sidewinder_03"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_04\man_cannon_sidewinder_04"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_05\man_cannon_sidewinder_05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_06\man_cannon_sidewinder_06"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_07\man_cannon_sidewinder_07"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_08\man_cannon_sidewinder_08"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\sw_forge_door_lg\sw_forge_door_lg"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\sw_forge_door_sm\sw_forge_door_sm"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\tower_of_power\tower_of_power"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\spacecamp\generator\generator"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\spacecamp\h_server_spacecamp\h_server_spacecamp"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\spacecamp\space_crate\space_crate"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\spacecamp\space_door_small\space_door_small"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\spacecamp\space_trashcan\space_trashcan"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\bridge\bridge"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\dlc_wh_crate_large_closed\dlc_wh_crate_large_closed"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\dlc_wh_crate_large_open\dlc_wh_crate_large_open"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\dlc_wh_crate_long_closed\dlc_wh_crate_long_closed"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\dlc_wh_crate_short_closed\dlc_wh_crate_short_closed"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\dlc_wh_crate_small_closed\dlc_wh_crate_small_closed"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\dlc_wh_crate_small_open\dlc_wh_crate_small_open"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\dlc_wh_wire_spool\dlc_wh_wire_spool"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\dlc_wh_wire_spool_large\dlc_wh_wire_spool_large"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\dumpster\dumpster"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\fence_sign_blue\fence_sign_blue"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\fence_sign_red\fence_sign_red"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\fencebox\fencebox"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\fencewall\fencewall"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\rustcorner\rustcorner"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\rustwall\rustwall"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\rustwalldouble\rustwalldouble"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\stairs\stairs"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\truck_cab_large_military\truck_cab_large_military"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\warehouse_door\warehouse_door"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\warehouse\warehouse_window\warehouse_window"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\chill\man_cannon_chill\man_cannon_chill"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\construct\construct_lift_lg\construct_lift_lg"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\construct\construct_lift_sm\construct_lift_sm"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\cyberdyne\cyber_pad\cyber_pad"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\cyberdyne\cyber_pad\cyber_pad_midship"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\deadlock\deadlock_chainlinkgate\deadlock_chainlinkgate"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\deadlock\deadlock_chainlinkgate_ii\deadlock_chainlinkgate_ii"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\deadlock\wall_hatch\wall_hatch"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\guardian\holy_light_guardian\holy_light_guardian_forge"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\guardian\man_cannon_guardian_ii\man_cannon_guardian_ii"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\isolation\isolation_lift_curve\isolation_lift_curve"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\isolation\launch_tube\launch_tube"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\isolation\launch_tube_opp\launch_tube_opp"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\riverworld\man_cannon_river\man_cannon_river"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\s3d_lockout\s3d_lockout_lift\s3d_lockout_lift"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\s3d_sky_bridgenew\man_cannon_bridge\man_cannon_bridge"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\s3d_sky_bridgenew\man_cannon_skybridge\man_cannon_skybridge"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\s3d_sky_bridgenew\man_cannon_skybridge_new\man_cannon_skybridge_new"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\s3d_sky_bridgenew\s3d_sky_bridge_lift\sky_bridge"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\s3d_turf\crate_heavy_tech\crate_heavy_tech"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\s3d_turf\turf_cabinet\turf_cabinet"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\s3d_turf\turf_crate_large\turf_crate_large"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\s3d_turf\turf_dumpster\turf_dumpster"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\s3d_turf\turf_swinging_door\turf_swinging_door"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\s3d_turf\turf_trash_can\turf_trash_can"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\s3d_waterfall\cyber_pad\cyber_pad"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\s3d_waterfall\man_cannon_waterfall_2\man_cannon_waterfall_2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\salvation\grav_platform\grav_platform"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\salvation\holo_panel_01\holo_panel_01"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\salvation\holo_panel_02\holo_panel_02"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\salvation\holo_panel_03\holo_panel_03"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\salvation\holy_jump_pad\holy_jump_pad"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\salvation\holy_light_main\holy_light_main"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\salvation\holy_light_side\holy_light_side"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\salvation\jittery_holo\jittery_holo"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\salvation\jittery_holo_01\jittery_holo_01"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\salvation\jittery_holo_02\jittery_holo_02"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\salvation\jittery_holo_03\jittery_holo_03"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\salvation\jittery_holo_04\jittery_holo_04"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\salvation\jittery_holo_05\jittery_holo_05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\salvation\large_field\large_field"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\salvation\platform_volume\platform_volume"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\salvation\small_field\small_field"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\shrine\sand_jump_pad\sand_jump_pad"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\snowbound\airlock_field\airlock_field"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\snowbound\airlock_field_cave\airlock_field_cave"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\snowbound\airlock_field_lg\airlock_field_lg"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\zanzibar\awning_def\awning_def"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\zanzibar\battle_shield\battle_shield"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\zanzibar\foliage\plant_bush_large_palm\plant_bush_large_palm"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\zanzibar\hinge_light\hinge_light"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\multi\zanzibar\main_crane\main_crane"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\010_jungle\foliage\plant_bush_med_palm\plant_bush_med_palm"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\010_jungle\foliage\plant_bush_small_fern\plant_bush_small_fern"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\010_jungle\foliage\plant_tree_palm\plant_tree_palm"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\010_jungle\foliage\tree_sapling\tree_sapling"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\020_base\computer_briefcase\computer_briefcase"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\020_base\computer_briefcase_small\computer_briefcase_small"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\020_base\computer_briefcase_small\computer_briefcase_small_crashed"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\030_outskirts\foliage\bushc\bushc"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\030_outskirts\foliage\bushlow\bushlow"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\030_outskirts\foliage\small_bush\small_bush"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\040_voi\cart_electric\cart_electric"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\060_floodship\flood_danglers\large_dangler\large_dangler"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\060_floodship\flood_danglers\small_dangler\small_dangler"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\100_citadel\foliage\plant_pine_tree_large\plant_pine_tree_large"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\solo\100_citadel\foliage\plant_tree_pine\plant_tree_pine"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\physics\nutblocker_1x1x2\nutblocker_1x1x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\vehicles\civilian\forklift\forklift"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\vehicles\warthog\garbage\tire\tire"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\equipment\gravlift_permanent\gravlift_permanent"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Equipment>($@"objects\equipment\tripmine\tripmine_forge"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"levels\dlc\descent\sky\scarab_inc\scarab_inc"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"levels\dlc\docks\sky\aircraft_carrier\aircraft_carrier"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"levels\dlc\midship\sky\spacedust"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"levels\solo\070_waste\sky\waterfall\waterfall"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\industrial\crate_tech_semi_short\crate_tech_semi_short"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\industrial\flare\flare"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\industrial\man_cannon_01\man_cannon_01"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\industrial\man_cannon_02\man_cannon_02"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\military\missle_stand\missle_stand"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\military\resupply_capsule_fired\resupply_capsule_fired"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\military\sandbag_detail1\sandbag_detail1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\military\sandbag_detail2\sandbag_detail2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\military\sandbag_wall\sandbag_wall"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\military\sandbag_wall_45corner\sandbag_wall_45corner"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\military\sandbag_wall_90corner\sandbag_wall_90corner"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\military\sandbag_wall_endcap\sandbag_wall_endcap"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\military\sandbag_wall_turret\sandbag_wall_turret"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\residential\central_monitor_bank_01\central_monitor_bank_01"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\residential\office_table\office_table"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\residential\pioneer_whiteboard_a\pioneer_whiteboard_a"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\gear\human\residential\vet_computer\vet_computer"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\armory\bulb_flicker\bulb_flicker"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\armory\industrial_vent_large\industrial_vent_large"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\bunkerworld\sandbag_wall_45corner_bunker\sandbag_wall_45corner_bunker"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\chillout\flood_tank\flood_tank"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\descent\egg_shield\egg_shield"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\descent\holo_panel_script1\holo_panel_script1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\descent\holo_panel_script_yellow\holo_panel_script_yellow"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\docks\decal_holiday_3\decal_holiday_3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\docks\decal_holiday_\decal_holiday_"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\docks\decal_holiday_menu\decal_holiday_menu"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\docks\rusty_barrel\barrel_rusty"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\docks\security_red_light\security_red_light"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\docks\speaker\speaker_sound"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\ghosttown\god_ray_small\god_ray_small"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\ghosttown\tech_control_primary_systems_housing\tech_control_primary_systems_housing"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\ghosttown\tech_control_second_systems_housing\tech_control_second_systems_housing"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\ghosttown\tech_control_substation_relay\tech_control_substation_relay"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\lockout\celltower\celltower"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\lockout\celltower_simple\celltower_simple"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\lockout\core_shelf\core_shelf"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\lockout\h_locker_closed"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\lockout\windcups\windcups"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\lockout\windsock\windsock"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\lockout\z_poop_cover\z_poop_cover"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\midship\base_floor\base_floor"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\midship\base_floor_red\base_floor_red"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\midship\cov_capital_ship\cov_capital_ship"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\midship\cov_cruiser\cov_cruiser"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\midship\jump_pad\jump_pad"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\midship\jump_pad_mirror\jump_pad_mirror"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\sandbox\grid\grid"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\flag_waver_blue\flag_waver_blue"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\flag_waver_red\flag_waver_red"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\space_ad_blue\space_ad_blue"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\space_ad_red\space_ad_red"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\space_door_small\space_door_small"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\space_lamp2\space_lamp2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\space_lamp\space_lamp"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\space_rays\space_rays"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\spacecamp_collision_hall_lower\spacecamp_collision_hall_lower"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\spacecamp_collision_hall_upper\spacecamp_collision_hall_upper"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\spacecamp_collision_lobase_backedge\spacecamp_collision_lobase_backedge"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\spacecamp_collision_ramp\spacecamp_collision_ramp"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\spacecamp_welcome\spacecamp_welcome"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\dlc\warehouse\security_yellow_light\security_yellow_light"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\cyberdyne\cyber_monitor_med\cyber_monitor"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\cyberdyne\cyber_speaker\cyber_speaker"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\isolation\isolation_collision_walls\isolation_collision_walls"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\s3d_lockout\s3d_lockout_lift_visual\s3d_lockout_lift_visual"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\s3d_sky_bridge\man_cannon\man_cannon"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\s3d_sky_bridgenew\crate_tech_semi_2\crate_tech_semi_2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\s3d_sky_bridgenew\crate_tech_semi_2_blue\crate_tech_semi_2_blue"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\s3d_sky_bridgenew\farplane_buildings\farplane_buildings"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\s3d_waterfall\longsword_waterfall\longsword_waterfall"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\salvation\altar_holo\altar_holo"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\salvation\holo_panel_01\holo_panel_01"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\salvation\holo_panel_02\holo_panel_02"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\salvation\holo_panel_03\holo_panel_03"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\shrine\marinebeacon\marinebeacon"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\snowbound\airlock_field\airlock_field"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\snowbound\airlock_field_cave\airlock_field_cave"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\snowbound\airlock_field_lg\airlock_field_lg"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\snowbound\cov_defender_mon\cov_defender_mon"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\snowbound\icicle_06_inch\icicle_06_inch"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\snowbound\icicle_10_inch\icicle_10_inch"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\snowbound\icicle_18_inch\icicle_18_inch"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\multi\snowbound\icicle_24_inch\icicle_24_inch"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\solo\010_jungle\dam_fusebox\dam_fusebox"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\solo\010_jungle\dam_fusebox_guard\dam_fusebox_guard"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\solo\010_jungle\dam_generator_bulky\dam_generator_bulky"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\solo\010_jungle\tech_control_monitor_station\tech_control_monitor_station"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\solo\010_jungle\tech_control_thin_simple\tech_control_thin_simple"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\solo\020_base\armory_shelf\armory_shelf"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\solo\020_base\monitor_sm\monitor_sm"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\solo\020_base\sink\sink"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\solo\040_voi\voi_door_warehouse_door_a\voi_door_warehouse_door_a"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\solo\060_floodship\floodball_pulsing\floodball_pulsing"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\solo\060_floodship\floodball_pulsing\floodball_pulsing_isolation"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\solo\110_hc\god_rays\god_rays"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\solo\110_hc\god_rays_blue\god_rays_blue"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\levels\solo\110_hc\god_rays_long\god_rays_long"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\scenery\human\military\mongoose_drop_palette\mongoose_drop_palette"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\scenery\human\military\warthog_drop_palette\warthog_drop_palette"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\vehicles\hornet\hornet_waterfall"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\vehicles\longsword\longsword"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\vehicles\pelican\pelican_parked\pelican_parked"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\vehicles\pelican\pelican_waterfall"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\vehicles\phantom\phantom_damaged\garbage\phd_backpiece_lg_top\phd_backpiece_lg_top"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\vehicles\phantom\phantom_damaged\garbage\phd_backpiece_md\phd_backpiece_md"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\vehicles\phantom\phantom_damaged\garbage\phd_backpiece_sm\phd_backpiece_sm"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\vehicles\phantom\phantom_damaged\garbage\phd_bottompiece\phd_bottompiece"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\vehicles\phantom\phantom_damaged\garbage\phd_flatpiece_r\phd_flatpiece_r"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\vehicles\phantom\phantom_damaged\garbage\phd_sidepiece_l\phd_sidepiece_l"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\vehicles\phantom\phantom_damaged\garbage\phd_sidepiece_r\phd_sidepiece_r"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\levels\dlc\chillout\monitor\monitor"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\levels\dlc\sandbox\sandbox_defender\sandbox_defender"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\levels\dlc\shared\golf_ball\golf_ball"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\levels\dlc\shared\soccer_ball\soccer_ball"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\levels\multi\cyberdyne\security_camera\security_camera"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\levels\multi\s3d_sky_bridge\hornet_lite\hornet_lite"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Vehicle>($@"objects\levels\multi\snowbound\cov_defender\cov_defender"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Weapon>($@"objects\levels\dlc\shared\forge_ball\forge_ball"),
                },
            };
            scnr.SandboxTeleporters = new List<Scenario.SandboxObject>
            {
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\chillout\teleporter_2way\teleporter_2way"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\chillout\teleporter_reciever\teleporter_reciever"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\chillout\teleporter_sender\teleporter_sender"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\teleporter_2way_sandbox"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_2way\teleporter_2way"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_2way\teleporter_2way_vehicle"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_2way\teleporter_2way_vehicle_only"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_receiver\teleporter_receiver_vehicle"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_receiver\teleporter_receiver_vehicle_only"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_reciever\teleporter_reciever"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_sender\teleporter_sender"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_sender\teleporter_sender_vehicle"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\teleporter_sender\teleporter_sender_vehicle_only"),
                },
            };
            scnr.SandboxGoalObjects = new List<Scenario.SandboxObject>
            {
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\assault\assault_bomb_goal_area"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\assault\assault_bomb_spawn_point"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\boundaries\garbage_collection_volume"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\boundaries\kill_volume"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\ctf\ctf_flag_return_area"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\ctf\ctf_flag_spawn_point"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\infection\infection_haven_static"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\juggernaut\juggernaut_destination_static"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\koth\koth_hill_static"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\oddball\oddball_ball_spawn_point"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\territories\territory_static"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\vip\vip_destination_static"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\eldewrito\forge\map_modifier"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\eldewrito\forge\map_modifier_02"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\assault\assault_initial_spawn_point"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\assault\assault_respawn_zone"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_flag_at_home_respawn_zone"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_flag_away_respawn_zone"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_initial_spawn_point"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_respawn_zone"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\generic\mp_cinematic_camera"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\infection\infection_initial_spawn_point"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\infection\infection_respawn_zone"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\koth\koth_initial_spawn_point"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\koth\koth_respawn_zone"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\oddball\oddball_initial_spawn_point"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\oddball\oddball_respawn_zone"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\slayer\slayer_initial_spawn_point"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\slayer\slayer_respawn_zone"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\spawning\respawn_point"),
                },
                new Scenario.SandboxObject
                {
                   Object = GetCachedTag<Scenery>($@"objects\multi\spawning\respawn_point_invisible"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\territories\territories_initial_spawn_point"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\territories\territories_respawn_zone"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\territories\territory_flag"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\test\player_spawn"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\vip\vip_initial_spawn_point"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Scenery>($@"objects\multi\vip\vip_respawn_zone"),
                },
            };
            scnr.SandboxSpawning = new List<Scenario.SandboxObject>
            {
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\forge\fx_object"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\forge\light_object"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x05x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x10x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x10x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x10x10"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x10x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x10x3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x10x4"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x10x5"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x1x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x1x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x20x20"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x2x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x2x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x2x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x3x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x3x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x3x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x3x3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x4x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x4x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x4x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x4x3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x4x4"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x5x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x5x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x5x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x5x3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x5x4"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x5x5"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x05x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x10x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x10x10"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x10x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x10x3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x10x4"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x10x5"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x1x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x1x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x20x20"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x2x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x2x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x3x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x3x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x3x3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x4x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x4x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x4x3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x4x4"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x5x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x5x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x5x3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x5x4"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_05x5x5"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x10x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x10x10"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x10x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x10x3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x10x4"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x10x5"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x1x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x20x20"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x2x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x2x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x3x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x3x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x3x3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x4x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x4x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x4x3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x4x4"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x5x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x5x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x5x3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x5x4"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_1x5x5"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_05x05x01"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_05x05x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_05x05x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_05x05x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_05x05x4"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_10x10x01"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_10x10x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_10x10x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_10x10x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_10x10x4"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_1x1x01"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_1x1x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_1x1x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_1x1x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_1x1x4"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_2x2x01"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_2x2x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_2x2x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_2x2x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_2x2x4"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_5x5x01"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_5x5x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_5x5x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_5x5x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\cylinder_5x5x4"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\glass_01x05x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\glass_01x10x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\glass_01x10x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\glass_01x10x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\glass_01x1x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\glass_01x2x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_1x01x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_1x10x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_1x1x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_1x3x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_1x4x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_2x01x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_2x10x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_2x1x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_2x3x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_2x4x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_3x01x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_3x10x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_3x1x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_3x3x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\halfcylinder_3x4x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_10x10x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_10x10x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_10x10x5"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_10x20x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_10x20x10"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_10x20x5"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_1x2x01"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_1x2x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_1x2x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_20x20x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_20x20x10"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_20x20x5"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_2x2x01"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_2x2x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_2x2x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_2x5x025"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_2x5x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_2x5x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_5x10x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_5x10x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_5x10x5"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_5x5x025"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_5x5x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\hemisphere_5x5x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_01x05x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_01x10x10"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_01x1x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_01x2x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_01x3x3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_01x4x4"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_01x5x5"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_05x05x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_05x10x10"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_05x1x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_05x2x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_05x3x3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_05x4x4"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_05x5x5"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_1x05x05"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_1x10x10"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_1x1x1"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_1x2x2"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_1x3x3"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_1x4x4"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\triangle_1x5x5"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\trianglee_01x05x043"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\trianglee_01x10x066"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\trianglee_01x1x087"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\trianglee_01x2x073"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\trianglee_01x3x06"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\trianglee_01x4x046"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\eldewrito\reforge\trianglee_01x5x033"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\box_l\box_l"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\box_m\box_m"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\box_xl\box_xl"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\box_xxl\box_xxl"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\box_xxxl\box_xxxl"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\wall_l\wall_l"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\wall_m\wall_m"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\wall_xl\wall_xl"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\wall_xxl\wall_xxl"),
                },
                new Scenario.SandboxObject
                {
                    Object = GetCachedTag<Crate>($@"objects\multi\wall_xxxl\wall_xxxl"),
                },
            };
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