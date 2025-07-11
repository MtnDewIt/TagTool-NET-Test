using TagTool.Tags.Definitions;

namespace TagTool.Animations
{
    public static class AnimationSorter
    {
        /// <summary>
        /// Sort the animation blocks for runtime (binary search)
        /// </summary>
        public static void Sort(ModelAnimationGraph animationGraph)
        {
            animationGraph.Modes.Sort((a, b) => a.Name.CompareTo(b.Name));
            foreach (var mode in animationGraph.Modes)
            {
                mode.WeaponClass.Sort((a, b) => a.Label.CompareTo(b.Label));
                foreach (var weaponClass in mode.WeaponClass)
                {
                    weaponClass.WeaponType.Sort((a, b) => a.Label.CompareTo(b.Label));
                    foreach (var weaponType in weaponClass.WeaponType)
                    {
                        weaponType.Set.Actions.Sort((a, b) => a.Label.CompareTo(b.Label));
                        weaponType.Set.Overlays.Sort((a, b) => a.Label.CompareTo(b.Label));
                        weaponType.Set.DeathAndDamage.Sort((a, b) => a.Label.CompareTo(b.Label));
                    }
                }
            }
            animationGraph.ObjectOverlays.Sort((a, b) => a.Label.CompareTo(b.Label));
            animationGraph.VehicleSuspension.Sort((a, b) => a.Label.CompareTo(b.Label));
            animationGraph.WeaponList.Sort((a, b) => a.WeaponName.CompareTo(b.WeaponName));
        }
    }
}
