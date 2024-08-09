using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags
{
    public class ui_global_strings_weapon_type_name_strings_multilingual_unicode_string_list : TagFile
    {
        public ui_global_strings_weapon_type_name_strings_multilingual_unicode_string_list(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
        (
            cache,
            cacheContext,
            stream
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
            TagData();
        }

        public override void TagData()
        {
            var tag = GetCachedTag<MultilingualUnicodeStringList>($@"ui\global_strings\weapon_type_name_strings");
            var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(Stream, tag);
            AddString(unic, "offset_assault_rife", "Assault Rifle");
            AddString(unic, "offset_battle_rife", "Battle Rifle");
            AddString(unic, "offset_beam_rifle", "Beam Rifle");
            AddString(unic, "offset_bomb", "Bomb");
            AddString(unic, "offset_bruteshot", "Brute shot");
            AddString(unic, "offset_carbine_rife", "Carbine");
            AddString(unic, "offset_dmr", "DMR");
            AddString(unic, "offset_energy_sword", "Energy Sword");
            AddString(unic, "offset_flag", "Flag");
            AddString(unic, "offset_fuel_rod", "Fuel Rod");
            AddString(unic, "offset_gravity_hammer", "Gravity Hammer");
            AddString(unic, "offset_magnum", "Magnum");
            AddString(unic, "offset_mauler", "Mauler");
            AddString(unic, "offset_needler", "Needler");
            AddString(unic, "offset_plasma_pistol", "Plasma Pistol");
            AddString(unic, "offset_plasma_rife", "Plasma Rifle");
            AddString(unic, "offset_rocket_launcher", "Rocket Launcher");
            AddString(unic, "offset_sentinel_beam", "Sentinel Beam");
            AddString(unic, "offset_shotgun", "Shotgun");
            AddString(unic, "offset_skull", "Skull");
            AddString(unic, "offset_smg", "SMG");
            AddString(unic, "offset_spartan_laser", "Spartan Laser");
            AddString(unic, "offset_spiker", "Spiker");
            AddString(unic, "offset_sniper_rifle", "Sniper Rifle");
            CacheContext.Serialize(Stream, tag, unic);
        }
    }
}
