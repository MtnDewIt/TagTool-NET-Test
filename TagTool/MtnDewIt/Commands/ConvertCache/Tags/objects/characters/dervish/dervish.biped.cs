using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_characters_dervish_dervish_biped : TagFile
    {
        public objects_characters_dervish_dervish_biped(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Biped>($@"objects\characters\dervish\dervish");
            var bipd = CacheContext.Deserialize<Biped>(Stream, tag);
            bipd.SyncActionCamera = new Unit.UnitCameraBlock 
            {
                PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85), Angle.FromDegrees(10)),
                CameraTracks = new List<Unit.UnitCameraTrack> 
                {
                    new Unit.UnitCameraTrack 
                    {
                         Track = GetCachedTag<CameraTrack>($@"camera\biped_assassination_camera"),
                    },
                },
            };
            bipd.Assassination = new Unit.UnitAssassination 
            {
                Response = GetCachedTag<DamageResponseDefinition>($@"globals\damage_responses\player_assassination"),
                ToolStowAnchor = CacheContext.StringTable.GetStringId($@"weapon_thigh"),
                ToolHandMarker = CacheContext.StringTable.GetStringId($@"right_hand_elite"),
                ToolMarker = CacheContext.StringTable.GetStringId($@"weapon_thigh"),
            };
            bipd.ShieldPopDamage = GetCachedTag<DamageEffect>($@"globals\damage_effects\shield_pop_melee");
            bipd.AssassinationDamage = GetCachedTag<DamageEffect>($@"globals\damage_effects\assassination");
            CacheContext.Serialize(Stream, tag, bipd);
        }
    }
}
