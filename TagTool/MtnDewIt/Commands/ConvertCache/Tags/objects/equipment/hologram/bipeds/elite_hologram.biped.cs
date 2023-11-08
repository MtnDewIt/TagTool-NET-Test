using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using TagTool.Tags;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_equipment_hologram_bipeds_elite_hologram_biped : TagFile
    {
        public objects_equipment_hologram_bipeds_elite_hologram_biped(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Biped>($@"objects\equipment\hologram\bipeds\elite_hologram");
            var bipd = CacheContext.Deserialize<Biped>(Stream, tag);
            bipd.ObjectFlags = ObjectDefinitionFlags.DoesNotCastShadow;
            bipd.Model = GetCachedTag<Model>($@"objects\equipment\hologram\bipeds\elite_hologram");
            bipd.CollisionDamage = null;
            bipd.MaterialEffects = null;
            bipd.ArmorSounds = null;
            bipd.MeleeImpactSound = null;
            bipd.AiProperties = null;
            bipd.Functions = null;
            bipd.Attachments = null;
            bipd.UnitFlags = Unit.UnitFlagBits.ShieldSapping;
            bipd.DefaultTeam = Unit.DefaultTeamValue.Player;
            bipd.EvictionMeleeResponse = GetCachedTag<DamageEffect>($@"objects\characters\masterchief\damage_effects\masterchief_ejection_melee_response");
            bipd.UnitCamera = new Unit.UnitCameraBlock 
            {
                CameraTracks = null,
                CameraAcceleration = null,
            };
            bipd.SyncActionCamera = new Unit.UnitCameraBlock 
            {
                PitchRange = new Bounds<Angle>(Angle.FromRadians(0), Angle.FromRadians(0)),
                CameraTracks = null,
            };
            bipd.Assassination = new Unit.UnitAssassination 
            {
                Response = null,
                Weapon = null,
                ToolStowAnchor = StringId.Invalid,
                ToolHandMarker = StringId.Invalid,
                ToolMarker = StringId.Invalid,
            };
            bipd.BoardingMeleeDamage = null;
            bipd.BoardingMeleeResponse = null;
            bipd.EvictionMeleeDamage = null;
            bipd.EvictionMeleeResponse = null;
            bipd.ShieldPopDamage = null;
            bipd.AssassinationDamage = null;
            bipd.HudInterfaces = null;
            bipd.CrouchingCameraFunction = new TagFunction
            {
                Data = new byte[]
                {
                    0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                    0xE0, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1C, 0x00, 
                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD, 
                    0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x80, 0xC0, 0x00, 0x00, 0x80, 0x40, 0x00, 0x00, 0x00, 0x00,
                }
            };
            bipd.CameraHeights = null;
            bipd.AreaDamageEffect = null;
            bipd.PhysicsFlags.Halo3ODST = Havok.BipedPhysicsFlags.Halo3OdstBits.UsePlayerPhysics;
            bipd.LivingMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo");
            bipd.DeadMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo");
            bipd.LivingGlobalMaterialIndex = 157;
            bipd.DeadGlobalMaterialIndex = 157;
            CacheContext.Serialize(Stream, tag, bipd);
        }
    }
}
