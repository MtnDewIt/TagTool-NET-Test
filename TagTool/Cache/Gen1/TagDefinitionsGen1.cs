using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Tags.Definitions.Gen1;

namespace TagTool.Cache.Gen1
{
    public class TagDefinitionsGen1 : TagDefinitions
    {
        public static FrozenDictionary<TagGroup, Type> Gen1Types => Gen1Definitions.TagGroupToTypeLookup;
        private static readonly CachedDefinitions Gen1Definitions = GetCachedDefinitions(new Dictionary<TagGroup, Type>
        {
            { new TagGroupGen1("actr", "actor"), typeof(Actor) },
            { new TagGroupGen1("actv", "actor_variant"), typeof(ActorVariant) },
            { new TagGroupGen1("ant!", "antenna"), typeof(Antenna) },
            { new TagGroupGen1("antr", "model_animations"), typeof(ModelAnimations) },
            { new TagGroupGen1("bipd", "unit", "obje", "biped"), typeof(Biped) },
            { new TagGroupGen1("bitm", "bitmap"), typeof(Bitmap) },
            { new TagGroupGen1("boom", "spheroid"), typeof(Spheroid) },
            { new TagGroupGen1("cdmg", "continuous_damage_effect"), typeof(ContinuousDamageEffect) },
            { new TagGroupGen1("coll", "model_collision_geometry"), typeof(ModelCollisionGeometry) },
            { new TagGroupGen1("colo", "color_table"), typeof(ColorTable) },
            { new TagGroupGen1("cont", "contrail"), typeof(Contrail) },
            { new TagGroupGen1("ctrl", "devi", "obje", "device_control"), typeof(DeviceControl) },
            { new TagGroupGen1("deca", "decal"), typeof(Decal) },
            { new TagGroupGen1("DeLa", "ui_widget_definition"), typeof(UiWidgetDefinition) },
            { new TagGroupGen1("devc", "input_device_defaults"), typeof(InputDeviceDefaults) },
            { new TagGroupGen1("devi", "device"), null /*typeof(Device)*/ },
            { new TagGroupGen1("dobc", "detail_object_collection"), typeof(DetailObjectCollection) },
            { new TagGroupGen1("effe", "effect"), typeof(Effect) },
            { new TagGroupGen1("elec", "lightning"), typeof(Lightning) },
            { new TagGroupGen1("eqip", "item", "obje", "equipment"), typeof(Equipment) },
            { new TagGroupGen1("flag", "flag"), typeof(Flag) },
            { new TagGroupGen1("fog ", "fog"), typeof(Fog) },
            { new TagGroupGen1("font", "font"), typeof(Font) },
            { new TagGroupGen1("foot", "material_effects"), typeof(MaterialEffects) },
            { new TagGroupGen1("garb", "item", "obje", "garbage"), typeof(Garbage) },
            { new TagGroupGen1("glw!", "glow"), typeof(Glow) },
            { new TagGroupGen1("grhi", "grenade_hud_interface"), typeof(GrenadeHudInterface) },
            { new TagGroupGen1("hmt ", "hud_message_text"), typeof(HudMessageText) },
            { new TagGroupGen1("hud#", "hud_number"), typeof(HudNumber) },
            { new TagGroupGen1("hudg", "hud_globals"), typeof(HudGlobals) },
            { new TagGroupGen1("item", "item"), null /*typeof(Item)*/ },
            { new TagGroupGen1("itmc", "item_collection"), typeof(ItemCollection) },
            { new TagGroupGen1("jpt!", "damage_effect"), typeof(DamageEffect) },
            { new TagGroupGen1("lens", "lens_flare"), typeof(LensFlare) },
            { new TagGroupGen1("lifi", "devi", "obje", "device_light_fixture"), typeof(DeviceLightFixture) },
            { new TagGroupGen1("ligh", "light"), typeof(Light) },
            { new TagGroupGen1("lsnd", "sound_looping"), typeof(SoundLooping) },
            { new TagGroupGen1("mach", "devi", "obje", "device_machine"), typeof(DeviceMachine) },
            { new TagGroupGen1("matg", "globals"), typeof(Globals) },
            { new TagGroupGen1("metr", "meter"), typeof(Meter) },
            { new TagGroupGen1("mgs2", "light_volume"), typeof(LightVolume) },
            { new TagGroupGen1("mod2", "gbxmodel"), typeof(Gbxmodel) },
            { new TagGroupGen1("mode", "model"), typeof(Model) },
            { new TagGroupGen1("mply", "multiplayer_scenario_description"), typeof(MultiplayerScenarioDescription) },
            { new TagGroupGen1("ngpr", "preferences_network_game"), typeof(PreferencesNetworkGame) },
            { new TagGroupGen1("obje", "object"), null /*typeof(GameObject)*/ },
            { new TagGroupGen1("part", "particle"), typeof(Particle) },
            { new TagGroupGen1("pctl", "particle_system"), typeof(ParticleSystem) },
            { new TagGroupGen1("phys", "physics"), typeof(Physics) },
            { new TagGroupGen1("plac", "obje", "placeholder"), typeof(Placeholder) },
            { new TagGroupGen1("pphy", "point_physics"), typeof(PointPhysics) },
            { new TagGroupGen1("proj", "obje", "projectile"), typeof(Projectile) },
            { new TagGroupGen1("rain", "weather_particle_system"), typeof(WeatherParticleSystem) },
            { new TagGroupGen1("sbsp", "scenario_structure_bsp"), typeof(ScenarioStructureBsp) },
            { new TagGroupGen1("scen", "obje", "scenery"), typeof(Scenery) },
            { new TagGroupGen1("scex", "shdr", "shader_transparent_chicago_extended"), typeof(ShaderTransparentChicagoExtended) },
            { new TagGroupGen1("schi", "shdr", "shader_transparent_chicago"), typeof(ShaderTransparentChicago) },
            { new TagGroupGen1("scnr", "scenario"), typeof(Scenario) },
            { new TagGroupGen1("senv", "shdr", "shader_environment"), typeof(ShaderEnvironment) },
            { new TagGroupGen1("sgla", "shdr", "shader_transparent_glass"), typeof(ShaderTransparentGlass) },
            { new TagGroupGen1("shdr", "shader"), null /*typeof(Shader)*/ },
            { new TagGroupGen1("sky ", "sky"), typeof(Sky) },
            { new TagGroupGen1("smet", "shdr", "shader_transparent_meter"), typeof(ShaderTransparentMeter) },
            { new TagGroupGen1("snd!", "sound"), typeof(Sound) },
            { new TagGroupGen1("snde", "sound_environment"), typeof(SoundEnvironment) },
            { new TagGroupGen1("soso", "shdr", "shader_model"), typeof(ShaderModel) },
            { new TagGroupGen1("sotr", "shdr", "shader_transparent_generic"), typeof(ShaderTransparentGeneric) },
            { new TagGroupGen1("Soul", "ui_widget_collection"), typeof(UiWidgetCollection) },
            { new TagGroupGen1("spla", "shdr", "shader_transparent_plasma"), typeof(ShaderTransparentPlasma) },
            { new TagGroupGen1("ssce", "sound_scenery"), typeof(SoundScenery) },
            { new TagGroupGen1("str#", "string_list"), typeof(StringList) },
            { new TagGroupGen1("swat", "shdr", "shader_transparent_water"), typeof(ShaderTransparentWater) },
            { new TagGroupGen1("tagc", "tag_collection"), typeof(TagCollection) },
            { new TagGroupGen1("trak", "camera_track"), typeof(CameraTrack) },
            { new TagGroupGen1("udlg", "dialogue"), typeof(Dialogue) },
            { new TagGroupGen1("unhi", "unit_hud_interface"), typeof(UnitHudInterface) },
            { new TagGroupGen1("unit", "unit"), null /*typeof(Unit)*/ },
            { new TagGroupGen1("ustr", "unicode_string_list"), typeof(UnicodeStringList) },
            { new TagGroupGen1("vcky", "virtual_keyboard"), typeof(VirtualKeyboard) },
            { new TagGroupGen1("vehi", "unit", "obje", "vehicle"), typeof(Vehicle) },
            { new TagGroupGen1("weap", "item", "obje", "weapon"), typeof(Weapon) },
            { new TagGroupGen1("wind", "wind"), typeof(Wind) },
            { new TagGroupGen1("wphi", "weapon_hud_interface"), typeof(WeaponHudInterface) },

            // OpenSauce
            { new TagGroupGen1("avtc", "actor_variant_transform_collection"), null /*typeof(ActorVariantTransformCollection)*/ },
            { new TagGroupGen1("avti", "actor_variant_transform_in"), null /*typeof(ActorVariantTransformIn)*/ },
            { new TagGroupGen1("avto", "actor_variant_transform_out"), null /*typeof(ActorVariantTransformOut)*/ },
            { new TagGroupGen1("efpc", "effect_postprocess_collection"), null /*typeof(EffectPostprocessCollection)*/ },
            { new TagGroupGen1("efpg", "effect_postprocess_generic"), null /*typeof(EffectPostprocessGeneric)*/ },
            { new TagGroupGen1("efpp", "effect_postprocess"), null /*typeof(EffectPostprocess)*/ },
            { new TagGroupGen1("eqhi", "equipment_hud_interface"), null /*typeof(EquipmentHudInterface)*/ },
            { new TagGroupGen1("gelc", "project_yellow_globals_cv"), null /*typeof(ProjectYellowGlobalsCv)*/ },
            { new TagGroupGen1("gelo", "project_yellow_globals"), null /*typeof(ProjectYellowGlobals)*/ },
            { new TagGroupGen1("magy", "model_animations_yelo"), null /*typeof(ModelAnimationsYelo)*/ },
            { new TagGroupGen1("shpg", "shader_postprocess_generic"), null /*typeof(ShaderPostprocessGeneric)*/ },
            { new TagGroupGen1("shpp", "shader_postprocess"), null /*typeof(ShaderPostprocess)*/ },
            { new TagGroupGen1("sidy", "string_id_yelo"), null /*typeof(StringIdYelo)*/ },
            { new TagGroupGen1("sily", "text_value_pair_definition"), null /*typeof(TextValuePairDefinition)*/ },
            { new TagGroupGen1("sppg", "shader_postprocess_globals"), null /*typeof(ShaderPostprocessGlobals)*/ },
            { new TagGroupGen1("tag+", "tag_database"), null /*typeof(TagDatabase)*/ },
            { new TagGroupGen1("unic", "multilingual_unicode_string_list"), null /*typeof(MultilingualUnicodeStringList)*/ },
            { new TagGroupGen1("yelo", "project_yellow"), null /*typeof(ProjectYellow)*/ },

            // TODO: VALIDATE THESE TAG GROUPS

            // Stubbs The Zombie
            { new TagGroupGen1("imef", "image_effect"), null /*ImageEffect)*/ },
            { new TagGroupGen1("vege", "vegetation"), null /*Vegetation)*/ },
            
            // Hail To The Chimp
            { new TagGroupGen1("coin", "coin"), null /*Coin)*/ },
            { new TagGroupGen1("muhi", "multiplayer_unit_hud_interface"), null /*MultiplayerUnitHudInterface)*/ },
            { new TagGroupGen1("muls", "multiplayer_sound"), null /*MultiplayerSound)*/ },
            { new TagGroupGen1("pash", "paper_shader"), null /*PaperShader)*/ },
            { new TagGroupGen1("teem", "teamup"), null /*Teamup)*/ },
            
            // Shadowrun
            { new TagGroupGen1("buym", "buy_menu"), null /*BuyMenu)*/ },
            { new TagGroupGen1("m1ed", "magic_definition1"), null /*MagicDefinition1)*/ },
            { new TagGroupGen1("m2ed", "magic_definition2"), null /*MagicDefinition2)*/ },
            { new TagGroupGen1("m3ed", "magic_definition3"), null /*MagicDefinition3)*/ },
            { new TagGroupGen1("srac", "shadowrun_actor"), null /*ShadowrunActor)*/ },
            { new TagGroupGen1("srud", "shadowrun_unit_data"), null /*ShadowrunUnitData)*/ },
            { new TagGroupGen1("srwd", "shadowrun_weapon_data"), null /*ShadowrunWeaponData)*/ },
            { new TagGroupGen1("t1ed", "tech_definition1"), null /*TechDefinition1)*/ },
            { new TagGroupGen1("t2ed", "tech_definition2"), null /*TechDefinition2)*/ },
            { new TagGroupGen1("t3ed", "tech_definition3"), null /*TechDefinition3)*/ },
        });
        public TagDefinitionsGen1() : base(Gen1Definitions) { }

        private static readonly FrozenDictionary<string, Tag> NameToTagLookup = NameToTagLookupValue();
        private static FrozenDictionary<string, Tag> NameToTagLookupValue()
        {
            var result = new Dictionary<string, Tag>();
            foreach (var (key, _) in Gen1Definitions.TagGroupToTypeLookup)
            {
                result.Add(((TagGroupGen1)key).Name, key.Tag);
            }
            return result.ToFrozenDictionary();
        }

        public bool TryGetTagFromName(string name, out Tag tag)
        {
            return NameToTagLookup.TryGetValue(name, out tag);
        }
    }
}
