using TagTool.Commands.Common;
using TagTool.Tags.Definitions;
using System.Collections.Generic;
using TagTool.Common;

namespace TagTool.Commands.Tags
{
    partial class BaseCacheCommand : Command
    {
        public void ImportAnimations() 
        {
            CommandRunner.Current.RunCommand($@"edittag objects\characters\masterchief\masterchief.model_animation_graph");
            CommandRunner.Current.RunCommand($"addanimation basefix \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\combat thunderclap.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation basefix \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\any any dance1test.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation basefix \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\any any dance1.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation basefix \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\any any mixamo.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation basefix \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\any any fingerlay.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation basefix \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\any any fingerstand.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation basefix \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\any any breakdance.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation basefix \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\any any twerk.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation basefix \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\any any hiphop.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation basefix \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\any any ballskick.JMM\"");
            ContextStack.Pop();

            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    if (tag.IsInGroup("jmad") && tag.Name == $@"objects\characters\masterchief\masterchief") 
                    {
                        var jmad = CacheContext.Deserialize<ModelAnimationGraph>(stream, tag);
                        jmad.Modes[0].WeaponClass[1].WeaponType[0].Set.Actions = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry> 
                        {
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"airborne_dead"),
                                GraphIndex = -1,
                                Animation = 88,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"landing_dead"),
                                GraphIndex = -1,
                                Animation = 89,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"armor_lock_enter"),
                                GraphIndex = -1,
                                Animation = 91,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"armor_lock_exit"),
                                GraphIndex = -1,
                                Animation = 92,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"armor_lock_idle"),
                                GraphIndex = -1,
                                Animation = 93,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"con_blast_enter"),
                                GraphIndex = -1,
                                Animation = 123,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"mag_pulse_enter"),
                                GraphIndex = -1,
                                Animation = 238,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"thunder_clap"),
                                GraphIndex = -1,
                                Animation = 1173,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"twerk"),
                                GraphIndex = -1,
                                Animation = 1180,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"dance1test"),
                                GraphIndex = -1,
                                Animation = 1174,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"dance1"),
                                GraphIndex = -1,
                                Animation = 1175,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"mixamo"),
                                GraphIndex = -1,
                                Animation = 1176,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"fingerlay"),
                                GraphIndex = -1,
                                Animation = 1177,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"fingerstand"),
                                GraphIndex = -1,
                                Animation = 1178,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"breakdance"),
                                GraphIndex = -1,
                                Animation = 1179,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"hiphop"),
                                GraphIndex = -1,
                                Animation = 1181,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"ballskick"),
                                GraphIndex = -1,
                                Animation = 1182,
                            },
                        };
                        CacheContext.Serialize(stream, tag, jmad);
                    }
                }
            }
        }

        public void PatchMarkerGroups()
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    if (tag.IsInGroup("mode") && tag.Name == $@"objects\weapons\pistol\excavator\fp_excavator\fp_excavator")
                    {
                        var mode = CacheContext.Deserialize<RenderModel>(stream, tag);
                        mode.MarkerGroups[1] = new RenderModel.MarkerGroup 
                        {
                            Name = CacheContext.StringTable.GetStringId($@"left_hand_cyborg"),
                            Markers = new List<RenderModel.MarkerGroup.Marker>
                            {
                                new RenderModel.MarkerGroup.Marker
                                {
                                    RegionIndex = -1,
                                    PermutationIndex = -1,
                                    Translation = new RealPoint3d(-0.05705916f, -0.005329998f, -0.08671363f),
                                    Rotation = new RealQuaternion(0f, 0f, 0f, 1f),
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, mode);
                    }

                    if (tag.IsInGroup("mode") && tag.Name == $@"objects\weapons\pistol\magnum\fp_magnum\fp_magnum")
                    {
                        var mode = CacheContext.Deserialize<RenderModel>(stream, tag);
                        mode.MarkerGroups[1] = new RenderModel.MarkerGroup 
                        {
                            Name = CacheContext.StringTable.GetStringId($@"left_hand"),
                            Markers = new List<RenderModel.MarkerGroup.Marker>
                            {
                                new RenderModel.MarkerGroup.Marker
                                {
                                    RegionIndex = -1,
                                    PermutationIndex = -1,
                                    Translation = new RealPoint3d(0.003737968f, -0.002770302f, -0.03149237f),
                                    Rotation = new RealQuaternion(-0.4730325f, -0.02672034f, -0.3264062f, 0.8179152f),
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, mode);
                    }

                    if (tag.IsInGroup("mode") && tag.Name == $@"objects\weapons\pistol\needler\fp_needler\fp_needler")
                    {
                        var mode = CacheContext.Deserialize<RenderModel>(stream, tag);
                        mode.MarkerGroups[2] = new RenderModel.MarkerGroup 
                        {
                            Name = CacheContext.StringTable.GetStringId($@"left_hand_cyborg"),
                            Markers = new List<RenderModel.MarkerGroup.Marker>
                            {
                                new RenderModel.MarkerGroup.Marker
                                {
                                    RegionIndex = -1,
                                    PermutationIndex = -1,
                                    Translation = new RealPoint3d(0.006987934f, 0.000949643f, -0.05353097f),
                                    Rotation = new RealQuaternion(-0.4737895f, 0.2369957f, -0.236659f, 0.8144625f),
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, mode);
                    }

                    if (tag.IsInGroup("mode") && tag.Name == $@"objects\weapons\pistol\plasma_pistol\fp_plasma_pistol\fp_plasma_pistol")
                    {
                        var mode = CacheContext.Deserialize<RenderModel>(stream, tag);
                        mode.MarkerGroups[2] = new RenderModel.MarkerGroup 
                        {
                            Name = CacheContext.StringTable.GetStringId($@"left_hand"),
                            Markers = new List<RenderModel.MarkerGroup.Marker>
                            {
                                new RenderModel.MarkerGroup.Marker
                                {
                                    RegionIndex = -1,
                                    PermutationIndex = -1,
                                    Translation = new RealPoint3d(-0.001243122f, -0.001241086f, -0.04597815f),
                                    Rotation = new RealQuaternion(-0.4714611f, 0.07865639f, -0.515889f, 0.7109122f),
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, mode);
                    }

                    if (tag.IsInGroup("mode") && tag.Name == $@"objects\weapons\rifle\assault_rifle\fp_assault_rifle\fp_assault_rifle")
                    {
                        var mode = CacheContext.Deserialize<RenderModel>(stream, tag);
                        mode.MarkerGroups = new List<RenderModel.MarkerGroup>
                        {
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"flashlight"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        Translation = new RealPoint3d(-0.07043599f, 0.04743343f, 0.07755382f),
                                        Rotation = new RealQuaternion(-7.12E-08f, -3.1E-08f, 7.99E-08f, 1f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"left_hand"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        Translation = new RealPoint3d(0.1010085f, -0.002260342f, 0.01560136f),
                                        Rotation = new RealQuaternion(-0.6241202f, 0.1670771f, -0.45504f, 0.6127788f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"muzzle_flash"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        Translation = new RealPoint3d(0.2278362f, -1.08E-10f, 0.04800265f),
                                        Rotation = new RealQuaternion(-1.088E-07f, 0.4617486f, 4.13E-08f, 0.8870109f),
                                    },
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        Translation = new RealPoint3d(0.2278362f, 0.003078642f, 0.05023942f),
                                        Rotation = new RealQuaternion(0.5213719f, 0.3735624f, 0.2714091f, 0.717607f),
                                    },
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        Translation = new RealPoint3d(0.2278362f, 0.001902705f, 0.05385858f),
                                        Rotation = new RealQuaternion(0.8435974f, 0.1426881f, 0.4391491f, 0.2741014f),
                                    },
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        Translation = new RealPoint3d(0.2278362f, -0.001902704f, 0.05385858f),
                                        Rotation = new RealQuaternion(-0.8435975f, 0.1426881f, -0.4391491f, 0.2741011f),
                                    },
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        Translation = new RealPoint3d(0.2278362f, -0.003060716f, 0.05018584f),
                                        Rotation = new RealQuaternion(-0.51509f, 0.3759167f, -0.2681388f, 0.7221291f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"primary_ejection"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        Translation = new RealPoint3d(-0.02918063f, -0.01220895f, 0.05243876f),
                                        Rotation = new RealQuaternion(0.4430407f, -0.2407077f, -0.1604732f, 0.8485418f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"primary_trigger"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        Translation = new RealPoint3d(0.2334275f, 1.0871E-08f, 0.05128551f),
                                        Rotation = new RealQuaternion(-4.95E-08f, -3.96E-08f, 6.29E-08f, 1f),
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, mode);
                    }

                    if (tag.IsInGroup("mode") && tag.Name == $@"objects\weapons\rifle\battle_rifle\fp_battle_rifle\fp_battle_rifle")
                    {
                        var mode = CacheContext.Deserialize<RenderModel>(stream, tag);
                        mode.MarkerGroups[1] = new RenderModel.MarkerGroup 
                        {
                            Name = CacheContext.StringTable.GetStringId($@"left_hand"),
                            Markers = new List<RenderModel.MarkerGroup.Marker>
                            {
                                new RenderModel.MarkerGroup.Marker
                                {
                                    RegionIndex = -1,
                                    PermutationIndex = -1,
                                    Translation = new RealPoint3d(0.1009767f, -0.003126469f, 0.01598142f),
                                    Rotation = new RealQuaternion(-0.6101443f, 0.1782749f, -0.4519773f, 0.6258264f),
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, mode);
                    }

                    if (tag.IsInGroup("mode") && tag.Name == $@"objects\weapons\rifle\covenant_carbine\fp_covenant_carbine\fp_covenant_carbine")
                    {
                        var mode = CacheContext.Deserialize<RenderModel>(stream, tag);
                        mode.MarkerGroups[1] = new RenderModel.MarkerGroup 
                        {
                            Name = CacheContext.StringTable.GetStringId($@"left_hand"),
                            Markers = new List<RenderModel.MarkerGroup.Marker>
                            {
                                new RenderModel.MarkerGroup.Marker
                                {
                                    RegionIndex = -1,
                                    PermutationIndex = -1,
                                    Translation = new RealPoint3d(0.01435027f, -0.002966242f, -0.03943556f),
                                    Rotation = new RealQuaternion(-0.5890878f, 0.1469777f, -0.4838951f, 0.630253f),
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, mode);
                    }

                    if (tag.IsInGroup("mode") && tag.Name == $@"objects\weapons\rifle\plasma_rifle\fp_plasma_rifle\fp_plasma_rifle")
                    {
                        var mode = CacheContext.Deserialize<RenderModel>(stream, tag);
                        mode.MarkerGroups[3] = new RenderModel.MarkerGroup 
                        {
                            Name = CacheContext.StringTable.GetStringId($@"left_hand"),
                            Markers = new List<RenderModel.MarkerGroup.Marker>
                            {
                                new RenderModel.MarkerGroup.Marker
                                {
                                    RegionIndex = -1,
                                    PermutationIndex = -1,
                                    Translation = new RealPoint3d(0.02655599f, 0.004300643f, -0.0528338f),
                                    Rotation = new RealQuaternion(-0.6164548f, 0.1957098f, -0.4600878f, 0.6082766f),
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, mode);
                    }

                    if (tag.IsInGroup("mode") && tag.Name == $@"objects\weapons\rifle\shotgun\fp_shotgun\fp_shotgun")
                    {
                        var mode = CacheContext.Deserialize<RenderModel>(stream, tag);
                        mode.MarkerGroups[1] = new RenderModel.MarkerGroup 
                        {
                            Name = CacheContext.StringTable.GetStringId($@"left_hand"),
                            Markers = new List<RenderModel.MarkerGroup.Marker>
                            {
                                new RenderModel.MarkerGroup.Marker
                                {
                                    RegionIndex = -1,
                                    PermutationIndex = -1,
                                    NodeIndex = 4,
                                    Translation = new RealPoint3d(-0.009387273f, 0.00139097f, -0.01766691f),
                                    Rotation = new RealQuaternion(-0.6016486f, 0.09437592f, -0.3454929f, 0.7139655f),
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, mode);
                    }

                    if (tag.IsInGroup("mode") && tag.Name == $@"objects\weapons\rifle\spike_rifle\fp_spike_rifle\fp_spike_rifle")
                    {
                        var mode = CacheContext.Deserialize<RenderModel>(stream, tag);
                        mode.MarkerGroups[2] = new RenderModel.MarkerGroup 
                        {
                            Name = CacheContext.StringTable.GetStringId($@"left_hand"),
                            Markers = new List<RenderModel.MarkerGroup.Marker>
                            {
                                new RenderModel.MarkerGroup.Marker
                                {
                                    RegionIndex = -1,
                                    PermutationIndex = -1,
                                    Translation = new RealPoint3d(0.02284988f, -0.02398125f, 0.002580142f),
                                    Rotation = new RealQuaternion(-0.4233879f, 0.1495626f, 0.8858865f, 0.116529f),
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, mode);
                    }

                    if (tag.IsInGroup("mode") && tag.Name == $@"objects\weapons\support_high\rocket_launcher\fp_rocket_launcher\fp_rocket_launcher")
                    {
                        var mode = CacheContext.Deserialize<RenderModel>(stream, tag);
                        mode.MarkerGroups[1] = new RenderModel.MarkerGroup 
                        {
                            Name = CacheContext.StringTable.GetStringId($@"left_hand_cyborg"),
                            Markers = new List<RenderModel.MarkerGroup.Marker>
                            {
                                new RenderModel.MarkerGroup.Marker
                                {
                                    RegionIndex = -1,
                                    PermutationIndex = -1,
                                    Translation = new RealPoint3d(0.2643063f, 0.003026339f, -0.01561892f),
                                    Rotation = new RealQuaternion(0.388786f, -0.1373109f, -0.01908897f, 0.9108385f),
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, mode);
                    }

                    if (tag.IsInGroup("mode") && tag.Name == $@"objects\weapons\support_low\brute_shot\fp_brute_shot\fp_brute_shot")
                    {
                        var mode = CacheContext.Deserialize<RenderModel>(stream, tag);
                        mode.MarkerGroups[0] = new RenderModel.MarkerGroup 
                        {
                            Name = CacheContext.StringTable.GetStringId($@"left_hand"),
                            Markers = new List<RenderModel.MarkerGroup.Marker>
                            {
                                new RenderModel.MarkerGroup.Marker
                                {
                                    RegionIndex = -1,
                                    PermutationIndex = -1,
                                    NodeIndex = 1,
                                    Translation = new RealPoint3d(0.0322919f, 0.01706448f, 0.0525696f),
                                    Rotation = new RealQuaternion(0.4885519f, -0.002291647f, -0.2378302f, 0.8394931f),
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, mode);
                    }
                }
            }
        }
    }
}