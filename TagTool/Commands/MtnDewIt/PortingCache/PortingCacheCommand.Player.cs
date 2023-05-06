using TagTool.Tags.Definitions;

namespace TagTool.Commands.Tags
{
    partial class PortingCacheCommand : Command
    {
        // Applies tag patches specific to each playable biped
        public void applyPlayerPatches() 
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    // The shield impact tags need to be manually assigned, as Halo Online makes use of the halo reach shield impact system, which is not replicated when porting halo 3 and odst bipeds

                    // Assigns shield impact tags to multiplayer spartan model
                    if (tag.IsInGroup("hlmt") && tag.Name == $@"objects\characters\masterchief\mp_masterchief\mp_masterchief")
                    {
                        var hlmt = CacheContext.Deserialize<Model>(stream, tag);
                        hlmt.ShieldImpactThirdPerson = CacheContext.TagCache.GetTag<ShieldImpact>($@"globals\masterchief_3p_shield_impact");
                        hlmt.ShieldImpactFirstPerson = CacheContext.TagCache.GetTag<ShieldImpact>($@"globals\masterchief_fp_shield_impact");
                        hlmt.OvershieldFirstPerson = CacheContext.TagCache.GetTag<ShieldImpact>($@"fx\shield_impacts\overshield_1p");
                        hlmt.OvershieldThirdPerson = CacheContext.TagCache.GetTag<ShieldImpact>($@"fx\shield_impacts\overshield_3p");
                        CacheContext.Serialize(stream, tag, hlmt);
                    }

                    // Assigns shield impact tags to masterchief model
                    if (tag.IsInGroup("hlmt") && tag.Name == $@"objects\characters\masterchief\masterchief")
                    {
                        var hlmt = CacheContext.Deserialize<Model>(stream, tag);
                        hlmt.ShieldImpactThirdPerson = CacheContext.TagCache.GetTag<ShieldImpact>($@"globals\masterchief_3p_shield_impact");
                        hlmt.ShieldImpactFirstPerson = CacheContext.TagCache.GetTag<ShieldImpact>($@"globals\masterchief_fp_shield_impact");
                        hlmt.OvershieldFirstPerson = CacheContext.TagCache.GetTag<ShieldImpact>($@"fx\shield_impacts\overshield_1p");
                        hlmt.OvershieldThirdPerson = CacheContext.TagCache.GetTag<ShieldImpact>($@"fx\shield_impacts\overshield_3p");
                        CacheContext.Serialize(stream, tag, hlmt);
                    }

                    // Assigns shield impact tags to multiplayer elite model
                    if (tag.IsInGroup("hlmt") && tag.Name == $@"objects\characters\elite\mp_elite\mp_elite")
                    {
                        var hlmt = CacheContext.Deserialize<Model>(stream, tag);
                        hlmt.ShieldImpactThirdPerson = CacheContext.TagCache.GetTag<ShieldImpact>($@"globals\elite_3p_shield_impact");
                        hlmt.ShieldImpactFirstPerson = CacheContext.TagCache.GetTag<ShieldImpact>($@"globals\elite_fp_shield_impact");
                        hlmt.OvershieldFirstPerson = CacheContext.TagCache.GetTag<ShieldImpact>($@"fx\shield_impacts\overshield_1p");
                        hlmt.OvershieldThirdPerson = CacheContext.TagCache.GetTag<ShieldImpact>($@"fx\shield_impacts\overshield_3p");
                        CacheContext.Serialize(stream, tag, hlmt);
                    }

                    // Assigns shield impact tags to campaign elite model
                    if (tag.IsInGroup("hlmt") && tag.Name == $@"objects\characters\elite\elite_sp")
                    {
                        var hlmt = CacheContext.Deserialize<Model>(stream, tag);
                        hlmt.ShieldImpactThirdPerson = CacheContext.TagCache.GetTag<ShieldImpact>($@"globals\elite_3p_shield_impact");
                        hlmt.ShieldImpactFirstPerson = CacheContext.TagCache.GetTag<ShieldImpact>($@"globals\elite_fp_shield_impact");
                        hlmt.OvershieldFirstPerson = CacheContext.TagCache.GetTag<ShieldImpact>($@"fx\shield_impacts\overshield_1p");
                        hlmt.OvershieldThirdPerson = CacheContext.TagCache.GetTag<ShieldImpact>($@"fx\shield_impacts\overshield_3p");
                        CacheContext.Serialize(stream, tag, hlmt);
                    }

                    // Assigns shield impact tags to arbiter model
                    if (tag.IsInGroup("hlmt") && tag.Name == $@"objects\characters\dervish\dervish")
                    {
                        var hlmt = CacheContext.Deserialize<Model>(stream, tag);
                        hlmt.ShieldImpactThirdPerson = CacheContext.TagCache.GetTag<ShieldImpact>($@"globals\elite_3p_shield_impact");
                        hlmt.ShieldImpactFirstPerson = CacheContext.TagCache.GetTag<ShieldImpact>($@"globals\elite_fp_shield_impact");
                        hlmt.OvershieldFirstPerson = CacheContext.TagCache.GetTag<ShieldImpact>($@"fx\shield_impacts\overshield_1p");
                        hlmt.OvershieldThirdPerson = CacheContext.TagCache.GetTag<ShieldImpact>($@"fx\shield_impacts\overshield_3p");
                        CacheContext.Serialize(stream, tag, hlmt);
                    }
                }
            }
        }
    }
}