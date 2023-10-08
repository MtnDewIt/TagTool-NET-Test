using System.Collections.Generic;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Tags 
{
    partial class ConvertCacheCommand : Command
    {
        public void UpdateWeaponAnimations()
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                foreach (var tag in CacheContext.TagCache.NonNull())
                {
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\melee\energy_blade\energy_blade")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\melee\energy_blade\fp_energy_blade\fp_energy_blade"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\melee\fp_energy_blade\fp_energy_blade"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\melee\energy_blade\fp_energy_blade\fp_energy_blade"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\melee\fp_energy_blade\fp_energy_blade"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\melee\energy_blade\energy_blade_useless")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\melee\energy_blade\fp_energy_blade\fp_energy_blade"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\melee\fp_energy_blade\fp_energy_blade"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\melee\energy_blade\fp_energy_blade\fp_energy_blade"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\melee\fp_energy_blade\fp_energy_blade"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\melee\energy_blade\unarmed")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\melee\energy_blade\fp_energy_blade\fp_unarmed"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\melee\fp_energy_blade\fp_energy_blade"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\melee\energy_blade\fp_energy_blade\fp_unarmed"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\melee\fp_energy_blade\fp_energy_blade"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\melee\gravity_hammer\gravity_hammer")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\melee\gravity_hammer\fp_gravity_hammer\fp_gravity_hammer"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\melee\fp_gravity_hammer\fp_gravity_hammer"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\melee\gravity_hammer\fp_gravity_hammer\fp_gravity_hammer"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\melee\fp_gravity_hammer\fp_gravity_hammer"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\multiplayer\assault_bomb\assault_bomb")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\multiplayer\assault_bomb\fp_assault_bomb\fp_assault_bomb"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\multiplayer\fp_assault_bomb\fp_assault_bomb"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\multiplayer\assault_bomb\fp_assault_bomb\fp_assault_bomb"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\multiplayer\fp_assault_bomb\fp_assault_bomb"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\multiplayer\ball\ball")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\multiplayer\ball\fp_ball\fp_ball"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\multiplayer\fp_ball\fp_ball"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\multiplayer\ball\fp_ball\fp_ball"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\multiplayer\fp_ball\fp_ball"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\multiplayer\flag\flag")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\multiplayer\flag\fp_flag\fp_flag"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\multiplayer\fp_flag\fp_flag"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\multiplayer\flag\fp_flag\fp_flag"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\multiplayer\fp_flag\fp_flag"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\pistol\excavator\excavator")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\pistol\excavator\fp_excavator\fp_excavator"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\pistol\fp_excavator\fp_excavator"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\pistol\excavator\fp_excavator\fp_excavator"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\pistol\fp_excavator\fp_excavator"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\pistol\excavator\excavator_v3\excavator_v3")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\pistol\excavator\excavator_v3\fp_excavator\fp_excavator_v3"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\pistol\fp_excavator\fp_excavator"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\pistol\excavator\excavator_v3\fp_excavator\fp_excavator_v3"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\pistol\fp_excavator\fp_excavator"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\pistol\magnum\magnum")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\pistol\magnum\fp_magnum\fp_magnum"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\pistol\fp_magnum\fp_magnum"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\pistol\magnum\fp_magnum\fp_magnum"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\pistol\fp_magnum\fp_magnum"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\pistol\magnum\magnum_v2\magnum_v2")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\pistol\magnum\magnum_v2\fp_magnum\fp_magnum_v2"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\pistol\fp_magnum\fp_magnum"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\pistol\magnum\magnum_v2\fp_magnum\fp_magnum_v2"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\pistol\fp_magnum\fp_magnum"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\pistol\magnum\magnum_v3\magnum_v3")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\pistol\magnum\magnum_v3\fp_magnum\fp_magnum_v3"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\pistol\fp_magnum\fp_magnum"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\pistol\magnum\magnum_v3\fp_magnum\fp_magnum_v3"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\pistol\fp_magnum\fp_magnum"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\pistol\needler\needler")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\pistol\needler\fp_needler\fp_needler"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\pistol\fp_needler\fp_needler"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\pistol\needler\fp_needler\fp_needler"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\pistol\fp_needler\fp_needler"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\pistol\plasma_pistol\plasma_pistol")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\pistol\plasma_pistol\fp_plasma_pistol\fp_plasma_pistol"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\pistol\fp_plasma_pistol\fp_plasma_pistol"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\pistol\plasma_pistol\fp_plasma_pistol\fp_plasma_pistol"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\pistol\fp_plasma_pistol\fp_plasma_pistol"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\pistol\plasma_pistol\plasma_pistol_v3\plasma_pistol_v3")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol_v3\fp_plasma_pistol\fp_plasma_pistol_v3"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\pistol\fp_plasma_pistol\fp_plasma_pistol"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol_v3\fp_plasma_pistol\fp_plasma_pistol_v3"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\pistol\fp_plasma_pistol\fp_plasma_pistol"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\assault_rifle\assault_rifle")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\assault_rifle\fp_assault_rifle\fp_assault_rifle"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_assault_rifle\fp_assault_rifle"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\assault_rifle\fp_assault_rifle\fp_assault_rifle"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_assault_rifle\fp_assault_rifle"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\assault_rifle\assault_rifle_v2\assault_rifle_v2")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\assault_rifle\assault_rifle_v2\fp_assault_rifle\fp_assault_rifle_v2"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_assault_rifle\fp_assault_rifle"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\assault_rifle\assault_rifle_v2\fp_assault_rifle\fp_assault_rifle_v2"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_assault_rifle\fp_assault_rifle"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\assault_rifle\assault_rifle_v3\assault_rifle_v3")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\assault_rifle\assault_rifle_v3\fp_assault_rifle\fp_assault_rifle_v3"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_assault_rifle\fp_assault_rifle"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\assault_rifle\assault_rifle_v3\fp_assault_rifle\fp_assault_rifle_v3"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_assault_rifle\fp_assault_rifle"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\assault_rifle\assault_rifle_v5\assault_rifle_v5")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\assault_rifle\assault_rifle_v5\fp_assault_rifle\fp_assault_rifle_v5"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_assault_rifle\fp_assault_rifle"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\assault_rifle\assault_rifle_v5\fp_assault_rifle\fp_assault_rifle_v5"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_assault_rifle\fp_assault_rifle"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\assault_rifle\assault_rifle_v6\assault_rifle_v6")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\assault_rifle\assault_rifle_v6\fp_assault_rifle\fp_assault_rifle_v6"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_assault_rifle\fp_assault_rifle"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\assault_rifle\assault_rifle_v6\fp_assault_rifle\fp_assault_rifle_v6"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_assault_rifle\fp_assault_rifle"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\battle_rifle\battle_rifle")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\battle_rifle\fp_battle_rifle\fp_battle_rifle"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_battle_rifle\fp_battle_rifle"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\battle_rifle\fp_battle_rifle\fp_battle_rifle"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_battle_rifle\fp_battle_rifle"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\battle_rifle\battle_rifle_v1\battle_rifle_v1")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v1\fp_battle_rifle\fp_battle_rifle_v1"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_battle_rifle\fp_battle_rifle"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v1\fp_battle_rifle\fp_battle_rifle_v1"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_battle_rifle\fp_battle_rifle"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\battle_rifle\battle_rifle_v2\battle_rifle_v2")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v2\fp_battle_rifle\fp_battle_rifle_v2"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_battle_rifle\fp_battle_rifle"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v2\fp_battle_rifle\fp_battle_rifle_v2"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_battle_rifle\fp_battle_rifle"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\battle_rifle\battle_rifle_v3\battle_rifle_v3")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v3\fp_battle_rifle\fp_battle_rifle_v3"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_battle_rifle\fp_battle_rifle"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v3\fp_battle_rifle\fp_battle_rifle_v3"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_battle_rifle\fp_battle_rifle"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\battle_rifle\battle_rifle_v4\battle_rifle_v4")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v4\fp_battle_rifle\fp_battle_rifle_v4"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_battle_rifle\fp_battle_rifle"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v4\fp_battle_rifle\fp_battle_rifle_v4"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_battle_rifle\fp_battle_rifle"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\battle_rifle\battle_rifle_v5\battle_rifle_v5")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v5\fp_battle_rifle\fp_battle_rifle_v5"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_battle_rifle\fp_battle_rifle"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v5\fp_battle_rifle\fp_battle_rifle_v5"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_battle_rifle\fp_battle_rifle"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\battle_rifle\battle_rifle_v6\battle_rifle_v6")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v6\fp_battle_rifle\fp_battle_rifle_v6"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_battle_rifle\fp_battle_rifle"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\battle_rifle\battle_rifle_v6\fp_battle_rifle\fp_battle_rifle_v6"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_battle_rifle\fp_battle_rifle"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\beam_rifle\beam_rifle")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\beam_rifle\fp_beam_rifle\fp_beam_rifle"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_beam_rifle\fp_beam_rifle"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\beam_rifle\fp_beam_rifle\fp_beam_rifle"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_beam_rifle\fp_beam_rifle"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\covenant_carbine\covenant_carbine")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\covenant_carbine\fp_covenant_carbine\fp_covenant_carbine"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_covenant_carbine\fp_covenant_carbine"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\covenant_carbine\fp_covenant_carbine\fp_covenant_carbine"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_covenant_carbine\fp_covenant_carbine"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v1\covenant_carbine_v1")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v1\fp_covenant_carbine\fp_covenant_carbine_v1"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_covenant_carbine\fp_covenant_carbine"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v1\fp_covenant_carbine\fp_covenant_carbine_v1"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_covenant_carbine\fp_covenant_carbine"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v2\covenant_carbine_v2")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v2\fp_covenant_carbine\fp_covenant_carbine_v2"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_covenant_carbine\fp_covenant_carbine"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v2\fp_covenant_carbine\fp_covenant_carbine_v2"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_covenant_carbine\fp_covenant_carbine"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v3\covenant_carbine_v3")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v3\fp_covenant_carbine\fp_covenant_carbine_v3"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_covenant_carbine\fp_covenant_carbine"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v3\fp_covenant_carbine\fp_covenant_carbine_v3"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_covenant_carbine\fp_covenant_carbine"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v4\covenant_carbine_v4")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v4\fp_covenant_carbine\fp_covenant_carbine_v4"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_covenant_carbine\fp_covenant_carbine"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v4\fp_covenant_carbine\fp_covenant_carbine_v4"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_covenant_carbine\fp_covenant_carbine"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v5\covenant_carbine_v5")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v5\fp_covenant_carbine\fp_covenant_carbine_v5"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_covenant_carbine\fp_covenant_carbine"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v5\fp_covenant_carbine\fp_covenant_carbine_v5"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_covenant_carbine\fp_covenant_carbine"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v6\covenant_carbine_v6")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v6\fp_covenant_carbine\fp_covenant_carbine_v6"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_covenant_carbine\fp_covenant_carbine"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine_v6\fp_covenant_carbine\fp_covenant_carbine_v6"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_covenant_carbine\fp_covenant_carbine"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\dmr\dmr")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\dmr\fp_dmr\fp_dmr"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_dmr\fp_dmr"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\dmr\fp_dmr\fp_dmr"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_dmr\fp_dmr"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\dmr\dmr_v1\dmr_v1")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\dmr\dmr_v1\fp_dmr\fp_dmr_v1"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_dmr\fp_dmr"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\dmr\dmr_v1\fp_dmr\fp_dmr_v1"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_dmr\fp_dmr"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\dmr\dmr_v2\dmr_v2")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\dmr\dmr_v2\fp_dmr\fp_dmr_v2"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_dmr\fp_dmr"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\dmr\dmr_v2\fp_dmr\fp_dmr_v2"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_dmr\fp_dmr"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\dmr\dmr_v3\dmr_v3")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\dmr\dmr_v3\fp_dmr\fp_dmr_v3"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_dmr\fp_dmr"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\dmr\dmr_v3\fp_dmr\fp_dmr_v3"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_dmr\fp_dmr"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\dmr\dmr_v4\dmr_v4")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\dmr\dmr_v4\fp_dmr\fp_dmr_v4"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_dmr\fp_dmr"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\dmr\dmr_v4\fp_dmr\fp_dmr_v4"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_dmr\fp_dmr"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\dmr\dmr_v6\dmr_v6")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\dmr\dmr_v6\fp_dmr\fp_dmr_v6"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_dmr\fp_dmr"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\dmr\dmr_v6\fp_dmr\fp_dmr_v6"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_dmr\fp_dmr"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\plasma_rifle\plasma_rifle")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\plasma_rifle\fp_plasma_rifle\fp_plasma_rifle"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_plasma_rifle\fp_plasma_rifle"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\plasma_rifle\fp_plasma_rifle\fp_plasma_rifle"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_plasma_rifle\fp_plasma_rifle"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\plasma_rifle\plasma_rifle_v6\plasma_rifle_v6")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle_v6\fp_plasma_rifle\fp_plasma_rifle_v6"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_plasma_rifle\fp_plasma_rifle"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle_v6\fp_plasma_rifle\fp_plasma_rifle_v6"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_plasma_rifle\fp_plasma_rifle"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\shotgun\shotgun")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\shotgun\fp_shotgun\fp_shotgun"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_shotgun\fp_shotgun"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\shotgun\fp_shotgun\fp_shotgun"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_shotgun\fp_shotgun"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\smg\smg")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\smg\fp_smg\fp_smg"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_smg\fp_smg"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\smg\fp_smg\fp_smg"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_smg\fp_smg"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\smg\smg_v1\smg_v1")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\smg\smg_v1\fp_smg\fp_smg_v1"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_smg\fp_smg"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\smg\smg_v1\fp_smg\fp_smg_v1"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_smg\fp_smg"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\smg\smg_v2\smg_v2")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\smg\smg_v2\fp_smg\fp_smg_v2"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_smg\fp_smg"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\smg\smg_v2\fp_smg\fp_smg_v2"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_smg\fp_smg"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\smg\smg_v4\smg_v4")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\smg\smg_v4\fp_smg\fp_smg_v4"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_smg\fp_smg"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\smg\smg_v4\fp_smg\fp_smg_v4"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_smg\fp_smg"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\smg\smg_v6\smg_v6")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\smg\smg_v6\fp_smg\fp_smg_v6"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_smg\fp_smg"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\smg\smg_v6\fp_smg\fp_smg_v6"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_smg\fp_smg"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\sniper_rifle\sniper_rifle")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\sniper_rifle\fp_sniper_rifle\fp_sniper_rifle"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_sniper_rifle\fp_sniper_rifle"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\sniper_rifle\fp_sniper_rifle\fp_sniper_rifle"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_sniper_rifle\fp_sniper_rifle"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\rifle\spike_rifle\spike_rifle")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\spike_rifle\fp_spike_rifle\fp_spike_rifle"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\rifle\fp_spike_rifle\fp_spike_rifle"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\rifle\spike_rifle\fp_spike_rifle\fp_spike_rifle"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\rifle\fp_spike_rifle\fp_spike_rifle"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\support_high\flak_cannon\flak_cannon")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\support_high\flak_cannon\fp_flak_cannon\fp_flak_cannon"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\support_high\fp_flak_cannon\fp_flak_cannon"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\support_high\flak_cannon\fp_flak_cannon\fp_flak_cannon"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\support_high\fp_flak_cannon\fp_flak_cannon"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\support_high\rocket_launcher\rocket_launcher")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\support_high\rocket_launcher\fp_rocket_launcher\fp_rocket_launcher"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\support_high\fp_rocket_launcher\fp_rocket_launcher"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\support_high\rocket_launcher\fp_rocket_launcher\fp_rocket_launcher"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\support_high\fp_rocket_launcher\fp_rocket_launcher"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\support_high\spartan_laser\spartan_laser")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\support_high\spartan_laser\fp_spartan_laser\fp_spartan_laser"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\support_high\fp_spartan_laser\fp_spartan_laser"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\support_high\spartan_laser\fp_spartan_laser\fp_spartan_laser"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\support_high\fp_spartan_laser\fp_spartan_laser"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\support_low\brute_shot\brute_shot")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\support_low\brute_shot\fp_brute_shot\fp_brute_shot"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\support_low\fp_brute_shot\fp_brute_shot"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\support_low\brute_shot\fp_brute_shot\fp_brute_shot"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\support_low\fp_brute_shot\fp_brute_shot"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                    
                    if (tag.IsInGroup("weap") && tag.Name == $@"objects\weapons\support_low\sentinel_gun\sentinel_gun")
                    {
                        var weap = CacheContext.Deserialize<Weapon>(stream, tag);
                        weap.FirstPerson = new List<Weapon.FirstPersonBlock> 
                        {
                            new Weapon.FirstPersonBlock() 
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\support_low\sentinel_gun\fp_sentinel_gun\fp_sentinel_gun"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\fp\weapons\support_low\fp_sentinel_beam\fp_sentinel_beam"),
                            },
                            new Weapon.FirstPersonBlock()
                            {
                                FirstPersonModel = GetCachedTag<RenderModel>($@"objects\weapons\support_low\sentinel_gun\fp_sentinel_gun\fp_sentinel_gun"),
                                FirstPersonAnimations = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\fp\weapons\support_low\fp_sentinel_beam\fp_sentinel_beam"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, weap);
                    }
                }
            }
        }
    }
}