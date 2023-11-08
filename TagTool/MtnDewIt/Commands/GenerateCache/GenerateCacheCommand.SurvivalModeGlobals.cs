using TagTool.Tags.Definitions;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command
    {
        public void GenerateSurvivalGlobalsTag()
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                var smdtTag = CacheContext.TagCache.AllocateTag<SurvivalModeGlobals>($@"multiplayer\survival_mode_globals");
                var smdt = new SurvivalModeGlobals();
                CacheContext.Serialize(stream, smdtTag, smdt);
            }
        }
        public void SurvivalGlobalsSetup()
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                foreach (var tag in CacheContext.TagCache.NonNull())
                {
                    if (tag.IsInGroup("smdt") && tag.Name == $@"multiplayer\survival_mode_globals")
                    {
                        var smdt = CacheContext.Deserialize<SurvivalModeGlobals>(stream, tag);
                        smdt.Unknown = 1088421888;
                        smdt.SurvivalModeStrings = GetCachedTag<MultilingualUnicodeStringList>($@"multiplayer\in_game_survival_messages");
                        smdt.CountdownSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\countdown_for_respawn");
                        smdt.RespawnSound = GetCachedTag<Sound>($@"sound\game_sfx\multiplayer\player_respawn");
                        smdt.SurvivalEvents = new System.Collections.Generic.List<SurvivalModeGlobals.SurvivalEvent>() 
                        {
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_welcome"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_welcome"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_new_set"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_new_set"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_end_set"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_end_set"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_new_round"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_new_round"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_end_round"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_end_round"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_new_wave"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_new_wave"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_end_wave"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_end_wave"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_bonus_round"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_bonus_round"),
                                DisplayTime = 5f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_bonus_lives_awarded"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_bonus_lives_awarded"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_awarded_lives"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_awarded_lives"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_awarded_weapon"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_awarded_weapon"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_awarded_equipment"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_awarded_equipment"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_skull_thunderstorm"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_skull_thunderstorm"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_skull_famine"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_skull_famine"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_skull_tilt"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_skull_tilt"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_skull_mythic"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_skull_mythic"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_skull_catch"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_skull_catch"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                               
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_skull_black_eye"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_skull_black_eye"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_skull_tough_luck"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_skull_tough_luck"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_skull_iron"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_skull_iron"),
                                DisplayTime = 3f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_last_man_standing"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_last_man_standing"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                               
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_5_lives_left"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_5_lives_left"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_1_life_left"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_1_life_left"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_0_lives_left"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_0_lives_left"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_game_over"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_game_over"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_double_kill"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_triple_kill"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_overkill"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                               
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_killtacular"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_killtrocity"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_killamanjaro"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_killtastrophe"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_killpocalpyse"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_killionaire"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_killing_spree"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_killing_frenzy"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_running_riot"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_rampage"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_untouchable"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_invincible"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_splatter_spree"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_vehicluar_manslaughter"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_sniper_spree"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_sharpshooter"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                               
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_shotgun_spree"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_open_season"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_stick_spree"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_corrected"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_sword_spree"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_slice_n_dice"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_hammer_spree"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_ball_peen_buster"),
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_hero"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_5_ai_remaining"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_5_ai_remaining"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_2_ai_remaining"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_2_ai_remaining"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_1_ai_remaining"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_1_ai_remaining"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_garbage_trucking"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_garbage_trucking"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_garbage_collected"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_garbage_collected"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_reinforcements"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_reinforcements"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_skull_tilt_famine"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_skull_tilt_famine"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_skull_tilt_famine_mythic"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_skull_tilt_famine_mythic"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_skull_tough_catch"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_skull_tough_catch"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_skull_tough_catch_black"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_skull_tough_catch_black"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_skull_all"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_skull_all"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_incredible_round"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_incredible_round"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_superb_set"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_superb_set"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,      
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_bonus_round_over"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_bonus_round_over"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_total_bonus"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_total_bonus"),
                                DisplayTime = 2f,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_better_luck_next_time"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_better_luck_next_time"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_no_bonus"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_no_bonus"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_bonus_information"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_bonus_information"),
                                DisplayTime = 63f,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_next_round_timer"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_next_round_timer"),
                                DisplayTime = 20f,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_next_set_timer"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_next_set_timer"),
                                DisplayTime = 20f,                                
                            },
                            new SurvivalModeGlobals.SurvivalEvent
                            {
                                Type = SurvivalModeGlobals.SurvivalEvent.TypeValue.Survival,
                                Event = CacheContext.StringTable.GetStringId($@"survival_bonus_skull_all"),
                                Audience = SurvivalModeGlobals.SurvivalEvent.AudienceValue.All,
                                Team = SurvivalModeGlobals.SurvivalEvent.TeamValue.All,
                                DisplayString = CacheContext.StringTable.GetStringId($@"survival_bonus_skull_all"),
                                DisplayTime = 2f,
                                SoundFlags = SurvivalModeGlobals.SurvivalEvent.GameEngineSoundResponseFlagsDefinition.AnnouncerSound,                                
                            },
                        };
                        CacheContext.Serialize(stream, tag, smdt);
                    }
                }
            }
        }
    }
}