using BepInEx.Logging;
using slg_features;

namespace slugg.skills
{
    public class SluggSkills
    {
        public static ManualLogSource Logger { get => welp.Plugin.Logger; }
        public static SlugcatStats.Name Slugg { get => welp.Plugin.slugg; }

        public static void OnHooks()
        {
            ft_2spear.spear_hooks();        // [ SPEAR ] calls the Spear hooks
            ft_deathSounds.death_hooks();   // [ DEATH ] calls the Death hooks
        }
    }
}