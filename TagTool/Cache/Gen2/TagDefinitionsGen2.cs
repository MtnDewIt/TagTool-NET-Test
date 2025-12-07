using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Tags.Definitions.Gen2;

namespace TagTool.Cache.Gen2
{
    public class TagDefinitionsGen2 : TagDefinitions
    {
        public static FrozenDictionary<TagGroup, Type> Gen2Types => Gen2Definitions.TagGroupToTypeLookup;
        private static readonly CachedDefinitions Gen2Definitions = GetCachedDefinitions(new Dictionary<TagGroup, Type>
        {
            { new TagGroupGen2("$#!+", "cache_file_sound"), typeof(CacheFileSound) },
            { new TagGroupGen2("*cen", "scenario_scenery_resource"), typeof(ScenarioSceneryResource) },
            { new TagGroupGen2("*eap", "scenario_weapons_resource"), typeof(ScenarioWeaponsResource) },
            { new TagGroupGen2("*ehi", "scenario_vehicles_resource"), typeof(ScenarioVehiclesResource) },
            { new TagGroupGen2("*igh", "scenario_lights_resource"), typeof(ScenarioLightsResource) },
            { new TagGroupGen2("*ipd", "scenario_bipeds_resource"), typeof(ScenarioBipedsResource) },
            { new TagGroupGen2("*qip", "scenario_equipment_resource"), typeof(ScenarioEquipmentResource) },
            { new TagGroupGen2("*rea", "scenario_creature_resource"), typeof(ScenarioCreatureResource) },
            { new TagGroupGen2("*sce", "scenario_sound_scenery_resource"), typeof(ScenarioSoundSceneryResource) },
            { new TagGroupGen2("/**/", "scenario_comments_resource"), typeof(ScenarioCommentsResource) },
            { new TagGroupGen2("<fx>", "sound_effect_template"), typeof(SoundEffectTemplate) },
            { new TagGroupGen2("adlg", "ai_dialogue_globals"), typeof(AiDialogueGlobals) },
            { new TagGroupGen2("ai**", "scenario_ai_resource"), typeof(ScenarioAiResource) },
            { new TagGroupGen2("ant!", "antenna"), typeof(Antenna) },
            { new TagGroupGen2("bipd", "unit", "obje", "biped"), typeof(Biped) },
            { new TagGroupGen2("bitm", "bitmap"), typeof(Bitmap) },
            { new TagGroupGen2("bloc", "obje", "crate"), typeof(Crate) },
            { new TagGroupGen2("BooM", "stereo_system"), typeof(StereoSystem) },
            { new TagGroupGen2("bsdt", "breakable_surface"), typeof(BreakableSurface) },
            { new TagGroupGen2("char", "character"), typeof(Character) },
            { new TagGroupGen2("cin*", "scenario_cinematics_resource"), typeof(ScenarioCinematicsResource) },
            { new TagGroupGen2("clu*", "scenario_cluster_data_resource"), typeof(ScenarioClusterDataResource) },
            { new TagGroupGen2("clwd", "cloth"), typeof(Cloth) },
            { new TagGroupGen2("coll", "collision_model"), typeof(CollisionModel) },
            { new TagGroupGen2("coln", "colony"), typeof(Colony) },
            { new TagGroupGen2("colo", "color_table"), typeof(ColorTable) },
            { new TagGroupGen2("cont", "contrail"), typeof(Contrail) },
            { new TagGroupGen2("crea", "obje", "creature"), typeof(Creature) },
            { new TagGroupGen2("ctrl", "devi", "obje", "device_control"), typeof(DeviceControl) },
            { new TagGroupGen2("dc*s", "scenario_decorators_resource"), typeof(ScenarioDecoratorsResource) },
            { new TagGroupGen2("dec*", "scenario_decals_resource"), typeof(ScenarioDecalsResource) },
            { new TagGroupGen2("deca", "decal"), typeof(Decal) },
            { new TagGroupGen2("DECP", "decorators"), typeof(Decorators) },
            { new TagGroupGen2("DECR", "decorator_set"), typeof(DecoratorSet) },
            { new TagGroupGen2("devi", "obje", "device"), typeof(Device)},
            { new TagGroupGen2("devo", "cellular_automata"), typeof(CellularAutomata) },
            { new TagGroupGen2("dgr*", "scenario_devices_resource"), typeof(ScenarioDevicesResource) },
            { new TagGroupGen2("dobc", "detail_object_collection"), typeof(DetailObjectCollection) },
            { new TagGroupGen2("effe", "effect"), typeof(Effect) },
            { new TagGroupGen2("egor", "screen_effect"), typeof(ScreenEffect) },
            { new TagGroupGen2("eqip", "item", "obje", "equipment"), typeof(Equipment) },
            { new TagGroupGen2("fog ", "planar_fog"), typeof(PlanarFog) },
            { new TagGroupGen2("foot", "material_effects"), typeof(MaterialEffects) },
            { new TagGroupGen2("fpch", "patchy_fog"), typeof(PatchyFog) },
            { new TagGroupGen2("garb", "item", "obje", "garbage"), typeof(Garbage) },
            { new TagGroupGen2("gldf", "chocolate_mountain"), typeof(ChocolateMountain) },
            { new TagGroupGen2("goof", "multiplayer_variant_settings_interface_definition"), typeof(MultiplayerVariantSettingsInterfaceDefinition) },
            { new TagGroupGen2("grhi", "grenade_hud_interface"), typeof(GrenadeHudInterface) },
            { new TagGroupGen2("hlmt", "model"), typeof(Model) },
            { new TagGroupGen2("hmt ", "hud_message_text"), typeof(HudMessageText) },
            { new TagGroupGen2("hsc*", "scenario_hs_source_file"), typeof(ScenarioHsSourceFile) },
            { new TagGroupGen2("hud#", "hud_number"), typeof(HudNumber) },
            { new TagGroupGen2("hudg", "hud_globals"), typeof(HudGlobals) },
            { new TagGroupGen2("item", "obje", "item"), typeof(Item)},
            { new TagGroupGen2("itmc", "item_collection"), typeof(ItemCollection) },
            { new TagGroupGen2("jmad", "model_animation_graph"), typeof(ModelAnimationGraph) },
            { new TagGroupGen2("jpt!", "damage_effect"), typeof(DamageEffect) },
            { new TagGroupGen2("lens", "lens_flare"), typeof(LensFlare) },
            { new TagGroupGen2("lifi", "devi", "obje", "device_light_fixture"), typeof(DeviceLightFixture) },
            { new TagGroupGen2("ligh", "light"), typeof(Light) },
            { new TagGroupGen2("lsnd", "sound_looping"), typeof(SoundLooping) },
            { new TagGroupGen2("ltmp", "scenario_structure_lightmap"), typeof(ScenarioStructureLightmap) },
            { new TagGroupGen2("mach", "devi", "obje", "device_machine"), typeof(DeviceMachine) },
            { new TagGroupGen2("matg", "globals"), typeof(Globals) },
            { new TagGroupGen2("mcsr", "mouse_cursor_definition"), typeof(MouseCursorDefinition) },
            { new TagGroupGen2("mdlg", "ai_mission_dialogue"), typeof(AiMissionDialogue) },
            { new TagGroupGen2("metr", "meter"), typeof(Meter) },
            { new TagGroupGen2("MGS2", "light_volume"), typeof(LightVolume) },
            { new TagGroupGen2("mode", "render_model"), typeof(RenderModel) },
            { new TagGroupGen2("mpdt", "material_physics"), typeof(MaterialPhysics) },
            { new TagGroupGen2("mply", "multiplayer_scenario_description"), typeof(MultiplayerScenarioDescription) },
            { new TagGroupGen2("mulg", "multiplayer_globals"), typeof(MultiplayerGlobals) },
            { new TagGroupGen2("nhdt", "new_hud_definition"), typeof(NewHudDefinition) },
            { new TagGroupGen2("obje", "object"), typeof(GameObject)},
            { new TagGroupGen2("part", "particle_old"), typeof(ParticleOld) },
            { new TagGroupGen2("pctl", "particle_system"), typeof(ParticleSystem) },
            { new TagGroupGen2("phmo", "physics_model"), typeof(PhysicsModel) },
            { new TagGroupGen2("phys", "physics"), typeof(Physics) },
            { new TagGroupGen2("pixl", "pixel_shader"), typeof(PixelShader) },
            { new TagGroupGen2("pmov", "particle_physics"), typeof(ParticlePhysics) },
            { new TagGroupGen2("pphy", "point_physics"), typeof(PointPhysics) },
            { new TagGroupGen2("proj", "obje", "projectile"), typeof(Projectile) },
            { new TagGroupGen2("prt3", "particle"), typeof(Particle) },
            { new TagGroupGen2("PRTM", "particle_model"), typeof(ParticleModel) },
            { new TagGroupGen2("sbsp", "scenario_structure_bsp"), typeof(ScenarioStructureBsp) },
            { new TagGroupGen2("scen", "obje", "scenery"), typeof(Scenery) },
            { new TagGroupGen2("scnr", "scenario"), typeof(Scenario) },
            { new TagGroupGen2("sfx+", "sound_effect_collection"), typeof(SoundEffectCollection) },
            { new TagGroupGen2("shad", "shader"), typeof(Shader) },
            { new TagGroupGen2("sily", "text_value_pair_definition"), typeof(TextValuePairDefinition) },
            { new TagGroupGen2("skin", "user_interface_list_skin_definition"), typeof(UserInterfaceListSkinDefinition) },
            { new TagGroupGen2("sky ", "sky"), typeof(Sky) },
            { new TagGroupGen2("slit", "shader_light_response"), typeof(ShaderLightResponse) },
            { new TagGroupGen2("sncl", "sound_classes"), typeof(SoundClasses) },
            { new TagGroupGen2("snd!", "sound"), typeof(Sound) },
            { new TagGroupGen2("snde", "sound_environment"), typeof(SoundEnvironment) },
            { new TagGroupGen2("snmx", "sound_mix"), typeof(SoundMix) },
            { new TagGroupGen2("spas", "shader_pass"), typeof(ShaderPass) },
            { new TagGroupGen2("spk!", "sound_dialogue_constants"), typeof(SoundDialogueConstants) },
            { new TagGroupGen2("ssce", "obje", "sound_scenery"), typeof(SoundScenery) },
            { new TagGroupGen2("sslt", "scenario_structure_lighting_resource"), typeof(ScenarioStructureLightingResource) },
            { new TagGroupGen2("stem", "shader_template"), typeof(ShaderTemplate) },
            { new TagGroupGen2("styl", "style"), typeof(Style) },
            { new TagGroupGen2("tdtl", "liquid"), typeof(Liquid) },
            { new TagGroupGen2("trak", "camera_track"), typeof(CameraTrack) },
            { new TagGroupGen2("trg*", "scenario_trigger_volumes_resource"), typeof(ScenarioTriggerVolumesResource) },
            { new TagGroupGen2("udlg", "dialogue"), typeof(Dialogue) },
            { new TagGroupGen2("ugh!", "sound_cache_file_gestalt"), typeof(SoundCacheFileGestalt) },
            { new TagGroupGen2("unhi", "unit_hud_interface"), typeof(UnitHudInterface) },
            { new TagGroupGen2("unic", "multilingual_unicode_string_list"), typeof(MultilingualUnicodeStringList) },
            { new TagGroupGen2("unit", "obje", "unit"), typeof(Unit)},
            { new TagGroupGen2("vehc", "vehicle_collection"), typeof(VehicleCollection) },
            { new TagGroupGen2("vehi", "unit", "obje", "vehicle"), typeof(Vehicle) },
            { new TagGroupGen2("vrtx", "vertex_shader"), typeof(VertexShader) },
            { new TagGroupGen2("weap", "item", "obje", "weapon"), typeof(Weapon) },
            { new TagGroupGen2("weat", "weather_system"), typeof(WeatherSystem) },
            { new TagGroupGen2("wgit", "user_interface_screen_widget_definition"), typeof(UserInterfaceScreenWidgetDefinition) },
            { new TagGroupGen2("wgtz", "user_interface_globals_definition"), typeof(UserInterfaceGlobalsDefinition) },
            { new TagGroupGen2("whip", "cellular_automata2d"), typeof(CellularAutomata2d) },
            { new TagGroupGen2("wigl", "user_interface_shared_globals_definition"), typeof(UserInterfaceSharedGlobalsDefinition) },
            { new TagGroupGen2("wind", "wind"), typeof(Wind) },
            { new TagGroupGen2("wphi", "weapon_hud_interface"), typeof(WeaponHudInterface) },
        });
        public TagDefinitionsGen2() : base(Gen2Definitions) { }

        private static readonly FrozenDictionary<string, Tag> NameToTagLookup = NameToTagLookupValue();
        private static FrozenDictionary<string, Tag> NameToTagLookupValue()
        {
            var result = new Dictionary<string, Tag>();
            foreach (var (key, _) in Gen2Definitions.TagGroupToTypeLookup)
            {
                result.Add(((TagGroupGen2)key).Name, key.Tag);
            }
            return result.ToFrozenDictionary();
        }

        public bool TryGetTagFromName(string name, out Tag tag)
        {
            return NameToTagLookup.TryGetValue(name, out tag);
        }
    }
}
