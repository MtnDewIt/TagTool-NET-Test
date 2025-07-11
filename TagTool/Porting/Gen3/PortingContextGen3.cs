using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Audio;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Commands.Porting;
using TagTool.Commands.ScenarioStructureBSPs;
using TagTool.Common;
using TagTool.Damage;
using TagTool.Geometry;
using TagTool.Geometry.BspCollisionGeometry;
using TagTool.Havok;
using TagTool.IO;
using TagTool.Shaders;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using TagTool.Tags.Definitions.Common;

namespace TagTool.Porting.Gen3
{
    public partial class PortingContextGen3 : PortingContext
    {
        private readonly RenderGeometryConverter GeometryConverter;

        public PortingContextGen3(GameCacheHaloOnlineBase cacheContext, GameCache blamCache) : base(cacheContext, blamCache)
        {
            GeometryConverter = new RenderGeometryConverter(cacheContext, blamCache);   
        }

        public override void Finish(Stream cacheStream, Stream blamCacheStream)
        {
            base.Finish(cacheStream, blamCacheStream);

            FinalizeRenderMethods(cacheStream, blamCacheStream);
        }

        protected override void Reset()
        {
            base.Reset();

            DeferredRenderMethods.Clear();
            Matcher.DeInit();
        }

        protected override bool TagIsValid(CachedTag blamTag, Stream cacheStream, Stream blamCacheStream, out CachedTag resultTag)
        {
            resultTag = null;

            Tag groupTag = blamTag.Group.Tag;
            switch (groupTag.ToString())
            {
                case "snd!":
                    if (!FlagIsSet(PortingFlags.Audio))
                    {
                        PortingConstants.DefaultTagNames.TryGetValue(groupTag, out string defaultSoundName);
                        CacheContext.TagCache.TryGetTag($"{defaultSoundName}.{groupTag}", out resultTag);
                        return false;
                    }
                    break;

                case "udlg":
                    if (!FlagIsSet(PortingFlags.Dialogue))
                    {
                        PortingConstants.DefaultTagNames.TryGetValue(groupTag, out string defaultUdlgName);
                        CacheContext.TagCache.TryGetTag($"{defaultUdlgName}.{groupTag}", out resultTag);
                        return false;
                    }
                    break;

                case "bipd":
                    if (!FlagIsSet(PortingFlags.Elites) && (blamTag.Name.Contains("elite") || blamTag.Name.Contains("dervish")))
                        return false;
                    break;
                case "char" when BlamCache.Version >= CacheVersion.HaloReach:
                    return false;

                case "sncl" when BlamCache.Version > CacheVersion.HaloOnline700123:
                    resultTag = CacheContext.TagCache.GetTag<SoundClasses>(@"sound\sound_classes");
                    return false;

                // these tags will be generated in the template generation code
                case "rmdf":
                case "glvs":
                case "glps":
                    return false;
                case "rmt2":
                    // match rmt2 with current ones available, else return null
                    resultTag = FindClosestRmt2(cacheStream, blamCacheStream, blamTag);
                    return false;
            }

            if (PortingConstants.ResourceTagGroups.Contains(blamTag.Group.Tag))
            {
                // there is only a few cases here -- if geometry\animation references a null resource its tag is still valid

                if (blamTag.Group.Tag == "snd!")
                {
                    if (!FlagIsSet(PortingFlags.Audio))
                    {
                        PortingConstants.DefaultTagNames.TryGetValue(blamTag.Group.Tag, out string defaultSoundName);
                        CacheContext.TagCache.TryGetTag($"{defaultSoundName}.{blamTag.Group.Tag}", out resultTag);
                        return false;
                    }

                    Sound sound = BlamCache.Deserialize<Sound>(blamCacheStream, blamTag);

                    if (BlamSoundGestalt == null)
                        BlamSoundGestalt = PortingContextFactory.LoadSoundGestalt(BlamCache, blamCacheStream);

                    if (BlamCache.Platform != CachePlatform.MCC)
                    {
                        if (sound.SoundReference != null)
                        {
                            var xmaFileSize = BlamSoundGestalt.GetFileSize(sound.SoundReference.PitchRangeIndex, sound.SoundReference.PitchRangeCount, BlamCache.Platform);
                            if (xmaFileSize < 0)
                                return false;
                        }

                        var soundResource = BlamCache.ResourceCache.GetSoundResourceDefinition(sound.GetResource(BlamCache.Version, BlamCache.Platform));
                        if (soundResource == null)
                            return false;

                        var xmaData = soundResource.Data.Data;
                        if (xmaData == null)
                            return false;
                    }
                    else
                    {
                        if (sound.Resource.Gen3ResourceID == DatumHandle.None)
                        {
                            new TagToolWarning($"Invalid resource for sound {blamTag.Name}");
                            return false;
                        }
                    }
                }
                else if (blamTag.Group.Tag == "bitm")
                {
                    Bitmap bitmap = BlamCache.Deserialize<Bitmap>(blamCacheStream, blamTag);

                    for (int i = 0; i < bitmap.Images.Count; i++)
                    {
                        var image = bitmap.Images[i];

                        // need to assign resource reference to an object here -- otherwise it compiles strangely??
                        object bitmapResourceDefinition;

                        if (image.XboxFlags.HasFlag(TagTool.Bitmaps.BitmapFlagsXbox.Xbox360UseInterleavedTextures))
                            bitmapResourceDefinition = BlamCache.ResourceCache.GetBitmapTextureInterleavedInteropResource(bitmap.InterleavedHardwareTextures[image.InterleavedInterop]);
                        else
                            bitmapResourceDefinition = BlamCache.ResourceCache.GetBitmapTextureInteropResource(bitmap.HardwareTextures[i]);

                        if (bitmapResourceDefinition == null)
                        {
                            new TagToolWarning($"Invalid resource for bitm {blamTag.Name}");
                            return false;
                        }
                    }
                }
                else if (blamTag.Group.Tag == "Lbsp")
                {
                    ScenarioLightmapBspData Lbsp = BlamCache.Deserialize<ScenarioLightmapBspData>(blamCacheStream, blamTag);

                    if (BlamCache.ResourceCache.GetRenderGeometryApiResourceDefinition(Lbsp.Geometry.Resource) == null)
                        return false;
                }
            }
            else if (PortingConstants.RenderMethodGroups.Contains(blamTag.Group.Tag))
            {
                RenderMethod renderMethod = BlamCache.Deserialize<RenderMethod>(blamCacheStream, blamTag);

                if (BlamCache.Version >= CacheVersion.HaloReach)
                {
                    switch (blamTag.Group.Tag.ToString())
                    {
                        case "rmcs":
                            resultTag = GetDefaultShader(blamTag.Group.Tag);
                            return false;
                    }
                }

                string templateName = renderMethod.ShaderProperties[0].Template.Name;
                if (TagTool.Shaders.ShaderMatching.ShaderMatcherNew.Rmt2Descriptor.TryParse(templateName, out var rmt2Descriptor))
                {
                    foreach (var tag in CacheContext.TagCacheGenHO.TagTable)
                        if (tag != null && tag.Group.Tag == "rmt2" && (tag.Name.Contains(rmt2Descriptor.Type) || FlagIsSet(PortingFlags.GenerateShaders)))
                        {
                            if ((FlagIsSet(PortingFlags.Ms30) && tag.Name.StartsWith("ms30\\")) || (!FlagIsSet(PortingFlags.Ms30) && !tag.Name.StartsWith("ms30\\")))
                                return true;

                            else if (tag.Name.StartsWith("ms30\\"))
                                continue;
                        }
                };
                // TODO: add code for "!MatchShaders" -- if a perfect match isnt found a null tag will be left in the cache

                // "ConvertTagInternal" isnt called so the default shader needs to be set here
                resultTag = GetDefaultShader(blamTag.Group.Tag);
                return false;
            }

            return true;
        }


        protected override object ConvertDefinition(Stream cacheStream, Stream blamCacheStream, CachedTag blamTag, CachedTag edTag, object blamDefinition, out CachedTag resultTag, out bool isDeferred)
        {
            resultTag = null;

            //
            // Perform pre-conversion fixups to the Blam tag definition
            //

            if (BlamCache.Version >= CacheVersion.HaloReach)
            {
                PreConvertReachDefinition(blamDefinition, blamCacheStream);
            }

            switch (blamDefinition)
            {
                case RenderModel mode when BlamCache.Version < CacheVersion.Halo3Retail:
                    foreach (var material in mode.Materials)
                        material.RenderMethod = null;
                    break;

                case Scenario scenario when !FlagIsSet(PortingFlags.Squads):
                    scenario.Squads = new List<Scenario.Squad>();
                    break;

                case Scenario scenario when !FlagIsSet(PortingFlags.ForgePalette):
                    scenario.SandboxEquipment.Clear();
                    scenario.SandboxGoalObjects.Clear();
                    scenario.SandboxScenery.Clear();
                    scenario.SandboxSpawning.Clear();
                    scenario.SandboxTeleporters.Clear();
                    scenario.SandboxVehicles.Clear();
                    scenario.SandboxWeapons.Clear();
                    break;

                case ShieldImpact shit when BlamCache.Version < CacheVersion.HaloOnlineED:
                    shit = PreConvertShieldImpact(shit, BlamCache.Version, CacheContext);
                    // These won't convert automatically due to versioning
                    shit.Plasma.PlasmaNoiseBitmap1 = (CachedTag)ConvertData(cacheStream, blamCacheStream, shit.Plasma.PlasmaNoiseBitmap1, null, shit.Plasma.PlasmaNoiseBitmap1.Name);
                    shit.Plasma.PlasmaNoiseBitmap2 = (CachedTag)ConvertData(cacheStream, blamCacheStream, shit.Plasma.PlasmaNoiseBitmap2, null, shit.Plasma.PlasmaNoiseBitmap2.Name);
                    shit.ExtrusionOscillation.OscillationBitmap1 = shit.Plasma.PlasmaNoiseBitmap1;
                    shit.ExtrusionOscillation.OscillationBitmap2 = shit.Plasma.PlasmaNoiseBitmap2;
                    blamDefinition = shit;
                    break;
            }

            ((TagStructure)blamDefinition).PreConvert(BlamCache.Version, CacheContext.Version);

            if (BlamCache.Version >= CacheVersion.HaloReach)
            {
                if (blamDefinition is Scenario scnr)
                {
                    var lightmap = BlamCache.Deserialize<ScenarioLightmap>(blamCacheStream, scnr.Lightmap);
                    ConvertReachLightmap(cacheStream, blamCacheStream, scnr.Lightmap.Name, lightmap);
                }
            }


            //
            // Perform automatic conversion on the Blam tag definition
            //

            blamDefinition = ConvertData(cacheStream, blamCacheStream, blamDefinition, blamDefinition, blamTag.Name);

            //
            // Perform post-conversion fixups to Blam data
            //

            ((TagStructure)blamDefinition).PostConvert(BlamCache.Version, CacheContext.Version);

            isDeferred = false;
            switch (blamDefinition)
            {
                case AreaScreenEffect sefc:
                    if (BlamCache.Version < CacheVersion.Halo3ODST)
                    {
                        sefc.GlobalHiddenFlags = AreaScreenEffect.HiddenFlagBits.UpdateThread | AreaScreenEffect.HiddenFlagBits.RenderThread;

                        foreach (var screenEffect in sefc.ScreenEffects)
                            screenEffect.HiddenFlags = AreaScreenEffect.HiddenFlagBits.UpdateThread | AreaScreenEffect.HiddenFlagBits.RenderThread;
                    }
                    foreach (var screenEffect in sefc.ScreenEffects)
                    {
                        //convert flags
                        if (BlamCache.Version == CacheVersion.Halo3Retail)
                            Enum.TryParse(screenEffect.Flags_H3.ToString(), out screenEffect.Flags_ODST);
                        else if (BlamCache.Version >= CacheVersion.HaloOnline106708 && BlamCache.Version <= CacheVersion.HaloOnline700123)
                            Enum.TryParse(screenEffect.Flags.ToString(), out screenEffect.Flags_ODST);

                        if (CacheContext.StringTable.GetString(screenEffect.InputVariable) == "saved_film_vision_mode_intensity")
                            screenEffect.Flags_ODST |= AreaScreenEffect.ScreenEffectBlock.SefcFlagBits_ODST.DebugDisable; // prevents spawning and rendering

                        if (screenEffect.ObjectFalloff.Data.Length == 0)
                            screenEffect.ObjectFalloff = TagFunction.DefaultConstant;
                    }

                    break;

                case Bitmap bitm:
                    //support bitmap conversion for HO generation caches
                    if (CacheVersionDetection.IsInGen(CacheGeneration.HaloOnline, BlamCache.Version))
                    {
                        for (var tex = 0; tex < bitm.HardwareTextures.Count; tex++)
                        {
                            var blamResourceDefinition = BlamCache.ResourceCache.GetBitmapTextureInteropResource(bitm.HardwareTextures[tex]);
                            bitm.HardwareTextures[tex] = CacheContext.ResourceCache.CreateBitmapResource(blamResourceDefinition);
                        }
                        blamDefinition = bitm;
                        break;
                    }
                    isDeferred = true;
                    blamDefinition = ConvertBitmapAsync(cacheStream, edTag, blamTag, bitm);
                    break;

                case CameraFxSettings cfxs:
                    blamDefinition = ConvertCameraFxSettings(cfxs, blamTag.Name);
                    break;

                case Character character:
                    blamDefinition = ConvertCharacter(cacheStream, character);
                    break;

                case ChudDefinition chdt:
                    blamDefinition = ConvertChudDefinition(chdt);
                    break;

                case ChudGlobalsDefinition chudGlobals:
                    blamDefinition = ConvertChudGlobalsDefinition(cacheStream, blamCacheStream, chudGlobals);
                    break;

                case ChudAnimationDefinition chudAnimation:
                    {
                        if (BlamCache.Version >= CacheVersion.HaloReach)
                        {
                            Enum.TryParse(chudAnimation.ReachFlags.ToString(), out chudAnimation.Flags);
                        }
                    }
                    break;

                case CinematicScene cisc when BlamCache.Version == CacheVersion.Halo3ODST:
                    foreach (var shot in cisc.Shots)
                    {
                        foreach (var frame in shot.CameraFrames)
                        {
                            frame.FocalLength *= 0.65535f; // fov change in ODST affected cisc too it seems
                        }
                    }
                    break;
                case CortanaEffectDefinition crte:
                    foreach (var gravemindblock in crte.Gravemind)
                    {
                        foreach (var vignetteblock in gravemindblock.Vignette)
                        {
                            foreach (var dynamicvaluesblock in vignetteblock.DynamicValues)
                            {
                                foreach (var framesblock in dynamicvaluesblock.Frames)
                                {
                                    // scale (since this is chud)
                                    framesblock.Dynamicvalue1 *= 1.5f;
                                    framesblock.Dynamicvalue2 *= 1.5f;
                                }
                            }
                        }
                    }
                    break;

                case DamageEffect damageEffect:
                    blamDefinition = ConvertDamageEffect(damageEffect);
                    break;
                case DamageResponseDefinition damageResponse:
                    blamDefinition = ConvertDamageResponseDefinition(blamCacheStream, damageResponse);
                    break;

                case DecoratorSet decoratorSet when BlamCache.Version >= CacheVersion.HaloReach:
                    blamDefinition = ConvertDecoratorSetReach(decoratorSet);
                    break;

                case Dialogue udlg:
                    blamDefinition = ConvertDialogue(cacheStream, udlg);
                    break;

                case Effect effe:
                    blamDefinition = ConvertEffect(cacheStream, effe, blamTag.Name);
                    break;

                case Equipment eqip:
                    Enum.TryParse(eqip.EquipmentFlagsH3.ToString(), out eqip.EquipmentFlags);
                    break;

                case GameObject gameobject:
                    //fix AI object avoidance
                    if (gameobject.Model != null)
                    {
                        var childmodeltag = CacheContext.TagCache.GetTag(gameobject.Model.Index);
                        if (childmodeltag.DefinitionOffset > 0) //sometimes a tag that isn't ported yet can be referenced here, which causes a crash
                        {
                            var childmodel = CacheContext.Deserialize<Model>(cacheStream, childmodeltag);
                            if (childmodel.CollisionModel != null)
                            {
                                var childcollisionmodel = CacheContext.Deserialize<CollisionModel>(cacheStream, childmodel.CollisionModel);
                                if (childcollisionmodel.PathfindingSpheres.Count > 0)
                                {
                                    gameobject.PathfindingSpheres = new List<GameObject.PathfindingSphere>();
                                    for (var i = 0; i < childcollisionmodel.PathfindingSpheres.Count; i++)
                                    {
                                        gameobject.PathfindingSpheres.Add(new GameObject.PathfindingSphere
                                        {
                                            Node = childcollisionmodel.PathfindingSpheres[i].Node,
                                            Flags = (GameObject.PathfindingSphereFlags)childcollisionmodel.PathfindingSpheres[i].Flags,
                                            Center = childcollisionmodel.PathfindingSpheres[i].Center,
                                            Radius = childcollisionmodel.PathfindingSpheres[i].Radius
                                        });
                                    }
                                }

                                // fix rare instances of coll with bsp physics lacking required model reference
                                bool collFixed = false;
                                foreach (var region in childcollisionmodel.Regions)
                                    foreach (var permutation in region.Permutations.Where(x => x.BspPhysics.Any()))
                                        foreach (var bspphysics in permutation.BspPhysics)
                                        {
                                            if (bspphysics.GeometryShape.Model == null)
                                            {
                                                bspphysics.GeometryShape.Model = childmodeltag;
                                                collFixed = true;
                                            }
                                        }

                                if (collFixed)
                                    CacheContext.Serialize(cacheStream, childmodel.CollisionModel, childcollisionmodel);
                            }
                        }
                    };

                    //all gameobjects are handled within this subswitch now
                    switch (gameobject)
                    {
                        case Weapon weapon:
                            //fix weapon target tracking
                            if (weapon.Tracking > 0 || weapon.WeaponType == Weapon.WeaponTypeValue.Needler)
                            {
                                weapon.TargetTracking = new List<Unit.TargetTrackingBlock>{
                                    new Unit.TargetTrackingBlock{
                                        AcquireTime = (weapon.Tracking == Weapon.TrackingType.HumanTracking ? 1.0f : 0.0f),
                                        GraceTime = (weapon.WeaponType == Weapon.WeaponTypeValue.Needler ? 0.2f : 0.1f),
                                        DecayTime = (weapon.WeaponType == Weapon.WeaponTypeValue.Needler ? 0.0f : 0.2f),
                                        TrackingTypes = (weapon.Tracking == Weapon.TrackingType.HumanTracking ?
                                            new List<Unit.TargetTrackingBlock.TrackingType> {
                                                new Unit.TargetTrackingBlock.TrackingType{
                                                    TrackingType2 = CacheContext.StringTable.GetStringId("ground_vehicles")
                                                },
                                                new Unit.TargetTrackingBlock.TrackingType{
                                                    TrackingType2 = CacheContext.StringTable.GetStringId("flying_vehicles")
                                                },
                                            }
                                            :
                                            new List<Unit.TargetTrackingBlock.TrackingType> {
                                                new Unit.TargetTrackingBlock.TrackingType{
                                                    TrackingType2 = CacheContext.StringTable.GetStringId("bipeds")
                                                },
                                        })
                                    }
                                };
                                if (weapon.Tracking == Weapon.TrackingType.HumanTracking)
                                {
                                    weapon.TargetTracking[0].TrackingSound = ConvertTag(cacheStream, blamCacheStream, BlamCache.TagCache.GetTag(@"sound\weapons\missile_launcher\tracking_locking\tracking_locking.sound_looping"));
                                    weapon.TargetTracking[0].LockedSound = ConvertTag(cacheStream, blamCacheStream, BlamCache.TagCache.GetTag(@"sound\weapons\missile_launcher\tracking_locked\tracking_locked.sound_looping"));
                                }
                            }
                            weapon.ZoomProtection = Weapon.WeaponMagnificationFlags.Enabled;
                            break;
                        /*case Vehicle vehicle:
                            //fix vehicle weapon target tracking
                            if (vehicle.TargetTracking == null)
                                vehicle.TargetTracking = new List<Unit.TargetTrackingBlock>();
                            foreach (var weaponBlock in vehicle.Weapons)
                            {
                                if (weaponBlock.Weapon2 != null)
                                {
                                    var vehicleWeap = CacheContext.Deserialize<Weapon>(cacheStream, weaponBlock.Weapon2);
                                    if (vehicleWeap.Tracking > 0 && vehicleWeap.TargetTracking.Count > 0)
                                    {
                                        vehicle.TargetTracking.AddRange(vehicleWeap.TargetTracking);
                                    }
                                }
                            }
                            break;*/
                        case Biped biped:
                            // add bipeds filter to "target_main" (fixes needler tracking)
                            if (biped.Model != null)
                            {
                                var hlmt = CacheContext.Deserialize<Model>(cacheStream, biped.Model);

                                foreach (var target in hlmt.Targets)
                                {
                                    if (target.LockOnData.TrackingType == StringId.Invalid && CacheContext.StringTable.GetString(target.MarkerName) == "target_main")
                                    {
                                        target.LockOnData.TrackingType = CacheContext.StringTable.GetStringId("bipeds");
                                    }
                                }

                                CacheContext.Serialize(cacheStream, biped.Model, hlmt);
                            }
                            break;
                        default:
                            break;
                    };
                    break;

                case Globals matg:
                    blamDefinition = ConvertGlobals(matg, cacheStream);
                    break;

                case LensFlare lens:
                    blamDefinition = ConvertLensFlare(lens, cacheStream, blamCacheStream);
                    break;

                case Light ligh when BlamCache.Version >= CacheVersion.HaloReach:
                    {
                        Enum.TryParse(ligh.ReachFlags.ToString(), out ligh.Flags);

                        if (ligh.DistanceDiffusionReach == 0)
                            ligh.DistanceDiffusion = 10f;
                        else
                            ligh.DistanceDiffusion = ligh.DistanceDiffusionReach;

                        ligh.AngularSmoothness = ligh.AngularFalloffSpeed;

                        if (ligh.GelBitmap != null)
                        {
                            ligh.Flags |= Light.LightFlags.AllowShadowsAndGels;
                            ligh.FrustumHeightScale = 1;
                            ligh.DistanceDiffusion = 0.0001f;
                            ligh.AngularSmoothness = 0;
                        }
                    }
                    break;

                case Model hlmt:
                    foreach (var target in hlmt.Targets)
                    {
                        if (BlamCache.Version <= CacheVersion.Halo3ODST)
                        {
                            if (target.LockOnData.FlagsOld.HasFlag(Model.TargetLockOnData.FlagsValueOld.LockedByHumanTracking))
                                target.LockOnData.TrackingType = CacheContext.StringTable.GetStringId("flying_vehicles");
                            else if (target.LockOnData.FlagsOld.HasFlag(Model.TargetLockOnData.FlagsValueOld.LockedByPlasmaTracking))
                                target.LockOnData.TrackingType = CacheContext.StringTable.GetStringId("bipeds");
                        }
                    }
                    break;

                case ModelAnimationGraph jmad:
                    blamDefinition = ConvertModelAnimationGraph(cacheStream, blamCacheStream, jmad);
                    break;

                case MultilingualUnicodeStringList unic:
                    blamDefinition = ConvertMultilingualUnicodeStringList(cacheStream, blamCacheStream, unic);
                    break;

                case Particle particle:
                    if (BlamCache.Version == CacheVersion.Halo3Retail) // Shift all flags above 5 by 1.
                    {
                        int flagsH3 = (int)particle.FlagsH3;
                        particle.Flags = (Particle.FlagsValue)((flagsH3 & 0x1F) + ((int)(flagsH3 & 0xFFFFFFE0) << 1));
                        //particle.Flags &= ~Particle.FlagsValue.DiesInWater; // h3 particles in odst seem to have this flag unset - does it behave differently?
                    }
                    else if (BlamCache.Version >= CacheVersion.HaloReach) // Shift all flags above 11 by 2
                    {
                        int flagsReach = (int)particle.AppearanceFlagsReach;
                        particle.AppearanceFlags = (Particle.AppearanceFlagsValue)((flagsReach & 0xFF) + ((flagsReach & 0x3F000) >> 2));
                    }
                    // temp prevent odst prt3 using cheap shader as we dont have the entry point shader
                    if (particle.Flags.HasFlag(Particle.FlagsValue.UseCheapShader))
                        particle.Flags &= ~Particle.FlagsValue.UseCheapShader;
                    break;

                case ParticleModel particleModel:
                    blamDefinition = ConvertParticleModel(edTag, blamTag, particleModel);
                    break;

                case PhysicsModel phmo:
                    blamDefinition = ConvertPhysicsModel(edTag, phmo);
                    break;

                case RasterizerGlobals rasg:
                    blamDefinition = ConvertRasterizerGlobals(rasg);
                    break;

                case RenderMethodOption rmop when BlamCache.Version == CacheVersion.Halo3ODST || BlamCache.Version >= CacheVersion.HaloReach:
                    foreach (var block in rmop.Parameters)
                    {
                        if (BlamCache.Version == CacheVersion.Halo3ODST && block.RenderMethodExtern >= RenderMethodExtern.emblem_player_shoulder_texture)
                            block.RenderMethodExtern = (RenderMethodExtern)((int)block.RenderMethodExtern + 2);
                        if (BlamCache.Version >= CacheVersion.HaloReach)
                        {
                            // TODO
                        }
                    }
                    break;

                case RenderModel mode:
                    blamDefinition = ConvertGen3RenderModel(edTag, blamTag, mode);
                    break;

                case Scenario scnr:
                    {
                        blamDefinition = ConvertScenario(cacheStream, blamCacheStream, scnr, blamTag.Name);
                        if (PortingOptions.Current.RegenerateStructureSurfaces)
                        {
                            foreach (var block in scnr.StructureBsps)
                            {
                                if (block.StructureBsp == null)
                                    continue;

                                CachedTag sbspTag = block.StructureBsp;
                                var sbsp = CacheContext.Deserialize<ScenarioStructureBsp>(cacheStream, sbspTag);
                                new GenerateStructureSurfacesCommand(CacheContext, sbspTag, sbsp, cacheStream, scnr).Execute(new List<string> { });
                                CacheContext.Serialize(cacheStream, sbspTag, sbsp);
                            }
                        }

                        if (BlamCache.Version >= CacheVersion.HaloReach)
                        {
                            foreach (var block in scnr.StructureBsps)
                            {
                                block.Flags = block.FlagsReach.ConvertLexical<Scenario.StructureBspBlock.StructureBspFlags>();
                            }

                            // remove unsupported healthpack controls
                            if (CacheContext.TagCache.TryGetCachedTag("objects\\levels\\shared\\device_controls\\health_station\\health_station.ctrl", out CachedTag healthCtrl))
                            {
                                var paletteIndex = (short)scnr.ControlPalette.FindIndex(e => e.Object == healthCtrl);

                                // substitute with health pack equipment
                                if (CacheContext.TagCache.TryGetCachedTag("objects\\powerups\\health_pack\\health_pack_large.eqip", out CachedTag healthEqip))
                                {
                                    scnr.EquipmentPalette.Add(new Scenario.ScenarioPaletteEntry()
                                    {
                                        Object = healthEqip
                                    });

                                    var eqipPaletteIndex = (short)(scnr.EquipmentPalette.Count - 1);

                                    foreach (var controlInstance in scnr.Controls)
                                    {
                                        if (controlInstance.PaletteIndex == paletteIndex)
                                        {
                                            scnr.Equipment.Add(new Scenario.EquipmentInstance()
                                            {
                                                PaletteIndex = eqipPaletteIndex,
                                                NameIndex = controlInstance.NameIndex,
                                                PlacementFlags = controlInstance.PlacementFlags,
                                                Position = controlInstance.Position,
                                                Rotation = controlInstance.Rotation,
                                                Scale = controlInstance.Scale,
                                                NodeOrientations = controlInstance.NodeOrientations,
                                                TransformFlags = controlInstance.TransformFlags,
                                                ManualBspFlags = controlInstance.ManualBspFlags,
                                                LightAirprobeName = controlInstance.LightAirprobeName,
                                                ObjectId = new ObjectIdentifier
                                                {
                                                    UniqueId = controlInstance.ObjectId.UniqueId,
                                                    OriginBspIndex = controlInstance.ObjectId.OriginBspIndex,
                                                    Type = new GameObjectType8() { Halo3ODST = GameObjectTypeHalo3ODST.Equipment },
                                                    Source = controlInstance.ObjectId.Source,
                                                },
                                                BspPolicy = controlInstance.BspPolicy,
                                                EditingBoundToBsp = controlInstance.EditingBoundToBsp,
                                                EditorFolder = controlInstance.EditorFolder,
                                                ParentId = controlInstance.ParentId,
                                                CanAttachToBspFlags = controlInstance.CanAttachToBspFlags,
                                                Multiplayer = controlInstance.Multiplayer,
                                            });
                                        }

                                        if (controlInstance.NameIndex != -1)
                                            scnr.ObjectNames[controlInstance.NameIndex].ObjectType = new GameObjectType16() { Halo3ODST = GameObjectTypeHalo3ODST.Equipment };
                                    }
                                }

                                if (paletteIndex != -1)
                                    scnr.ControlPalette[paletteIndex].Object = null;

                                RemoveNullPlacements(scnr.ControlPalette, scnr.Controls);
                            }
                        }
                    }
                    break;

                case ScenarioLightmap sLdT:
                    if (BlamCache.Version < CacheVersion.HaloReach)
                        blamDefinition = ConvertScenarioLightmap(cacheStream, blamCacheStream, blamTag.Name, sLdT);
                    //fixup lightmap bsp references
                    if (BlamCache.Version >= CacheVersion.HaloReach)
                    {
                        for (short i = 0; i < sLdT.PerPixelLightmapDataReferences.Count; i++)
                        {
                            if (sLdT.PerPixelLightmapDataReferences[i].LightmapBspData != null)
                            {
                                var lbsp = CacheContext.Deserialize<ScenarioLightmapBspData>(cacheStream, sLdT.PerPixelLightmapDataReferences[i].LightmapBspData);
                                lbsp.BspIndex = i;
                                CacheContext.Serialize(cacheStream, sLdT.PerPixelLightmapDataReferences[i].LightmapBspData, lbsp);
                            }
                        }
                    }
                    break;

                case ScenarioLightmapBspData Lbsp:
                    if (BlamCache.Version < CacheVersion.HaloReach)
                        blamDefinition = ConvertScenarioLightmapBspData(Lbsp);
                    break;

                case ScenarioStructureBsp sbsp:
                    blamDefinition = ConvertScenarioStructureBsp(sbsp, edTag);
                    break;

                case Sound sound:
                    //support sound conversion for HO generation caches
                    if (CacheVersionDetection.IsInGen(CacheGeneration.HaloOnline, BlamCache.Version))
                    {
                        var blamResourceDefinition = BlamCache.ResourceCache.GetSoundResourceDefinition(sound.Resource);
                        sound.Resource = CacheContext.ResourceCache.CreateSoundResource(blamResourceDefinition);
                        blamDefinition = sound;
                        break;
                    }
                    isDeferred = true;
                    blamDefinition = ConvertSound(cacheStream, blamCacheStream, sound, edTag, blamTag.Name);
                    break;
                case SoundClasses sncl:
                    blamDefinition = ConvertSoundClasses(sncl, BlamCache.Version);
                    break;

                case SoundLooping lsnd:
                    blamDefinition = ConvertSoundLooping(lsnd);
                    break;

                case SoundMix snmx:
                    blamDefinition = ConvertSoundMix(snmx);
                    break;

                case Style style:
                    blamDefinition = ConvertStyle(style);
                    break;

                case TextValuePairDefinition sily:
                    Enum.TryParse(sily.ParameterH3.ToString(), out sily.Parameter);
                    break;

                case UserInterfaceSharedGlobalsDefinition wigl:
                    if (BlamCache.Version == CacheVersion.Halo3Retail)
                    {
                        wigl.UiWidgetBipeds = new List<UserInterfaceSharedGlobalsDefinition.UiWidgetBiped>
                        {
                            new UserInterfaceSharedGlobalsDefinition.UiWidgetBiped
                            {
                                AppearanceBipedName = "chief",
                                RosterPlayer1BipedName = "elite",
                            }
                        };
                    }
                    break;
            }

            //
            // Shader conversion
            //

            switch (blamDefinition)
            {
                case ShaderFoliage rmfl:
                case ShaderBlack rmbk:
                case ShaderTerrain rmtr:
                case ShaderCustom rmcs:
                case ShaderDecal rmd:
                case ShaderHalogram rmhg:
                case ShaderGlass rmgl:
                case Shader rmsh:
                case ShaderScreen rmss:
                case ShaderWater rmw:
                case ShaderZonly rmzo:
                case ContrailSystem cntl:
                case Particle prt3:
                case LightVolumeSystem ltvl:
                case DecalSystem decs:
                case BeamSystem beam:
                case ShaderCortana rmct:
                    if (!FlagIsSet(PortingFlags.MatchShaders))
                    {
                        resultTag = GetDefaultShader(blamTag.Group.Tag);
                        return null;
                    }
                    else
                    {
                        // Verify that the ShaderMatcher is ready to use
                        if (!Matcher.IsInitialized)
                            Matcher.Init(CacheContext, BlamCache, cacheStream, blamCacheStream, this, FlagIsSet(PortingFlags.Ms30), FlagIsSet(PortingFlags.PefectShaderMatchOnly));

                        blamDefinition = ConvertShader(cacheStream, blamCacheStream, blamDefinition, blamTag, BlamCache.Deserialize(blamCacheStream, blamTag), edTag, out isDeferred);
                        if (blamDefinition == null) // convert shader failed
                        {
                            resultTag = GetDefaultShader(blamTag.Group.Tag);
                            return null;
                        }
                    }
                    break;
            }

            return blamDefinition;
        }


        public override object ConvertData(Stream cacheStream, Stream blamCacheStream, object data, object definition, string blamTagName)
        {
            switch (data)
            {
                case TagResourceReference:
                    return data;

                case TagFunction tagFunction:
                    return ConvertTagFunction(tagFunction);

                case TagHkpMoppCode hkpMoppCode:
                    //Structure design mopp codes are NOT converted
                    if (definition is StructureDesign)
                        return hkpMoppCode;
                    hkpMoppCode.Data.Elements = HavokConverter.ConvertMoppCodes(BlamCache.Version, BlamCache.Platform, CacheContext.Version, hkpMoppCode.Data.Elements);
                    return hkpMoppCode;

                case PhysicsModel.PhantomTypeFlags phantomTypeFlags:
                    return ConvertPhantomTypeFlags(blamTagName, phantomTypeFlags);

                case PhysicsModel.Shape shape:
                    shape = ConvertStructure(cacheStream, blamCacheStream, shape, definition, blamTagName);
                    // might be from 3, had no reference
                    shape.ProxyCollisionGroup = shape.ProxyCollisionGroup > 2 ? (sbyte)(shape.ProxyCollisionGroup + 1) : shape.ProxyCollisionGroup;
                    return shape;

                case DamageReportingType damageReportingType:
                    return ConvertDamageReportingType(damageReportingType);

                case GameObjectType8 gameObjectType:
                    gameObjectType.SetValue(CacheContext.Version, gameObjectType.GetValue(BlamCache.Version));
                    return gameObjectType;
                case GameObjectType16 gameObjectType:
                    gameObjectType.SetValue(CacheContext.Version, gameObjectType.GetValue(BlamCache.Version));
                    return gameObjectType;
                case GameObjectType32 gameObjectType:
                    gameObjectType.SetValue(CacheContext.Version, gameObjectType.GetValue(BlamCache.Version));
                    return gameObjectType;

                case ObjectTypeFlags objectTypeFlags:
                    return ConvertObjectTypeFlags(objectTypeFlags);

                case VersionedFlags versionedFlags:
                    versionedFlags.ConvertFlags(BlamCache.Version, BlamCache.Platform, CacheContext.Version, CacheContext.Platform);
                    return versionedFlags;

                case GameObject.MultiplayerObjectBlock multiplayer when BlamCache.Version >= CacheVersion.HaloReach:
                    {
                        multiplayer.Type = multiplayer.TypeReach.ConvertLexical<MultiplayerObjectType>();
                        multiplayer.Flags = multiplayer.FlagsReach.ConvertLexical<GameObject.MultiplayerObjectBlock.MultiplayerObjectFlags>();
                        multiplayer.DefaultSpawnTime = multiplayer.SpawnTimeReach;
                        multiplayer.DefaultAbandonTime = multiplayer.AbandonTimeReach;
                        if (multiplayer.DefaultSpawnTime == 0) multiplayer.DefaultSpawnTime = 30;
                        if (multiplayer.DefaultAbandonTime == 0) multiplayer.DefaultAbandonTime = 30;
                        multiplayer.BoundaryShape = multiplayer.ReachBoundaryShape;
                        multiplayer.SpawnTimerType = multiplayer.SpawnTimerTypeReach.ConvertLexical<MultiplayerObjectSpawnTimerType>();
                        foreach (var boundary in multiplayer.BoundaryShaders)
                        {
                            boundary.StandardShader = (CachedTag)ConvertData(cacheStream, blamCacheStream, boundary.StandardShader, definition, blamTagName);
                            boundary.OpaqueShader = (CachedTag)ConvertData(cacheStream, blamCacheStream, boundary.OpaqueShader, definition, blamTagName);
                        }
                        return multiplayer;
                    }

                case BipedPhysicsFlags bipedPhysicsFlags:
                    return ConvertBipedPhysicsFlags(bipedPhysicsFlags);

                case WeaponFlags weaponFlags:
                    return ConvertWeaponFlags(weaponFlags);

                case Weapon.Trigger trigger:
                    trigger = ConvertStructure(cacheStream, blamCacheStream, trigger, definition, blamTagName);
                    return ConvertWeaponTrigger(trigger);

                case BarrelFlags barrelflags:
                    return ConvertBarrelFlags(barrelflags);

                case Model.TargetLockOnData lockOnData:
                    return ConvertTargetLockOnData(lockOnData);

                case RenderMethod renderMethod:
                    return ConvertStructure(cacheStream, blamCacheStream, renderMethod, definition, blamTagName);

                case Scenario.MultiplayerObjectProperties scnrObj when BlamCache.Version >= CacheVersion.HaloReach:
                    {
                        scnrObj = ConvertStructure(cacheStream, blamCacheStream, scnrObj, definition, blamTagName);
                        scnrObj.BoundaryWidthRadius = scnrObj.BoundaryWidthRadiusReach;
                        scnrObj.BoundaryBoxLength = scnrObj.BoundaryBoxLengthReach;
                        scnrObj.BoundaryPositiveHeight = scnrObj.BoundaryPositiveHeightReach;
                        scnrObj.BoundaryNegativeHeight = scnrObj.BoundaryNegativeHeightReach;
                        scnrObj.RemappingPolicy = scnrObj.RemappingPolicyReach;

                        switch (scnrObj.MegaloLabel)
                        {
                            case "ctf_res_zone_away":
                            case "ctf_res_zone":
                            case "ctf_flag_return":
                            case "ctf":
                                scnrObj.EngineFlags |= GameEngineSubTypeFlags.CaptureTheFlag;
                                break;
                            case "slayer":
                                scnrObj.EngineFlags |= GameEngineSubTypeFlags.Slayer;
                                break;
                            case "oddball_ball":
                                scnrObj.EngineFlags |= GameEngineSubTypeFlags.Oddball;
                                break;
                            case "koth_hill":
                                scnrObj.EngineFlags |= GameEngineSubTypeFlags.KingOfTheHill;
                                break;
                            case "terr_object":
                                scnrObj.EngineFlags |= GameEngineSubTypeFlags.Territories;
                                break;
                            case "as_goal": // assault plant point
                            case "as_bomb": // assault bomb spawn
                            case "assault":
                                scnrObj.EngineFlags |= GameEngineSubTypeFlags.Assault;
                                break;
                            case "inf_spawn":
                            case "inf_haven":
                                scnrObj.EngineFlags |= GameEngineSubTypeFlags.Infection;
                                break;
                            case "stp_goal": // use these for juggernaut points
                                scnrObj.EngineFlags |= GameEngineSubTypeFlags.Juggernaut;
                                break;
                            case "stp_flag": // use these for VIP points
                            case "stockpile":
                                scnrObj.EngineFlags |= GameEngineSubTypeFlags.Vip;
                                break;
                            //case "ffa_only":
                            //case "team_only":
                            //case "hh_drop_point":
                            //case "rally":
                            //case "rally_flag":
                            //case "race_flag":
                            //case "race_spawn":
                            //case "as_spawn":
                            //case "none":
                            //    break;
                            default:
                                break;
                        }

                        return data;
                    }

                case SoundClass soundClass:
                    return soundClass.ConvertSoundClass(BlamCache.Version);

                case GuiTextWidgetDefinition guiTextWidget:
                    guiTextWidget = ConvertStructure(cacheStream, blamCacheStream, guiTextWidget, definition, blamTagName);
                    switch (BlamCache.Version)
                    {
                        case CacheVersion.Halo3Retail when BlamCache.Platform == CachePlatform.Original:
                            guiTextWidget.CustomFont = GetEquivalentValue(guiTextWidget.CustomFont, guiTextWidget.CustomFont_H3);
                            break;
                        case CacheVersion.Halo3Retail when BlamCache.Platform == CachePlatform.MCC:
                            guiTextWidget.CustomFont = GetEquivalentValue(guiTextWidget.CustomFont, guiTextWidget.CustomFont_H3MCC);
                            break;
                        case CacheVersion.Halo3ODST:
                            guiTextWidget.CustomFont = GetEquivalentValue(guiTextWidget.CustomFont, guiTextWidget.CustomFont_ODST);
                            break;
                    }
                    return guiTextWidget;
                case GuiDefinition guidefinition:
                    guidefinition = ConvertStructure(cacheStream, blamCacheStream, guidefinition, definition, blamTagName);
                    if (FlagIsSet(PortingFlags.AutoRescaleGui))
                        RescaleGUIDef(guidefinition, 1.3125f);
                    break;

                case RuntimeGpuData runMGpu when BlamCache.Platform == CachePlatform.MCC:
                    if (BlamCache.Version >= CacheVersion.Halo3ODST)
                    {
                        if (runMGpu.RuntimeGpuBlocks?.Count > 0)
                        {
                            runMGpu.Properties = runMGpu.RuntimeGpuBlocks[0].Properties;
                            runMGpu.Functions = runMGpu.RuntimeGpuBlocks[0].Functions;
                            runMGpu.Colors = runMGpu.RuntimeGpuBlocks[0].Colors;
                        }
                    }
                    return runMGpu;

                case CollisionGeometry collisionGeometry:
                    return ConvertCollisionBsp(collisionGeometry);

                case CollisionBspPhysicsDefinition collisionBspPhysics when BlamCache.Version >= CacheVersion.HaloReach:
                    collisionBspPhysics = ConvertStructure(cacheStream, blamCacheStream, collisionBspPhysics, definition, blamTagName);
                    return ConvertCollisionBspPhysicsReach(collisionBspPhysics);

                case RenderGeometry renderGeometry when BlamCache.Version >= CacheVersion.Halo3Retail:
                    renderGeometry = ConvertStructure(cacheStream, blamCacheStream, renderGeometry, definition, blamTagName);
                    return renderGeometry;

                case Part part when BlamCache.Version < CacheVersion.Halo3Retail:
                    part = ConvertStructure(cacheStream, blamCacheStream, part, definition, blamTagName);
                    if (!Enum.TryParse(part.TypeOld.ToString(), out part.TypeNew))
                        throw new NotSupportedException(part.TypeOld.ToString());
                    return part;

                case RenderMaterial.Property property when BlamCache.Version < CacheVersion.Halo3Retail:
                    property = ConvertStructure(cacheStream, blamCacheStream, property, definition, blamTagName);
                    property.IntValue = property.ShortValue;
                    return property;

                case PixelShaderReference _:
                case VertexShaderReference _:
                    return null;
            }

            return base.ConvertData(cacheStream, blamCacheStream, data, definition, blamTagName);
        }

        private TagFunction ConvertTagFunction(TagFunction function)
        {
            return TagFunction.ConvertTagFunction(CacheVersionDetection.IsLittleEndian(BlamCache.Version, BlamCache.Platform) ? EndianFormat.LittleEndian : EndianFormat.BigEndian, function);
        }

        protected override object ConvertFieldvalue(Stream cacheStream, Stream blamCacheStream, TagFieldInfo tagFieldInfo, object value, object definition, string blamTagName)
        {
            value = base.ConvertFieldvalue(cacheStream, blamCacheStream, tagFieldInfo, value, definition, blamTagName);

            if (tagFieldInfo.Attribute.Flags.HasFlag(TagFieldFlags.GlobalMaterial))
            {
                value = ConvertGlobalMaterialTypeField(cacheStream, blamCacheStream, tagFieldInfo, value);
            }

            return value;
        }

        protected override void MergeTags(Stream cacheStream, Stream blamCacheStream, CachedTag blamTag, CachedTag edTag)
        {
            switch (blamTag.Group.Tag.ToString())
            {
                case "char":
                    MergeCharacter(cacheStream, blamCacheStream, edTag, blamTag);
                    break;

                case "mulg":
                    MergeMultiplayerGlobals(cacheStream, blamCacheStream, edTag, blamTag);
                    break;

                case "unic":
                    MergeMultilingualUnicodeStringList(cacheStream, blamCacheStream, edTag, blamTag);
                    break;
            }
        }
    }
}
