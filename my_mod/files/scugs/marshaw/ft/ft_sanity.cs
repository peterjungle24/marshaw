using BepInEx.Logging;
using sanity;

namespace mw_features
{
    internal class ft_sanity
    {
        public static SlugcatStats.Name marshaw { get => welp.Plugin.Marshaw; }    //name of my slugcat
        public static ManualLogSource Logger { get => welp.Plugin.Logger; }

        // Base Settings for Marshaw
        public static void sanity_hooks()
        {
            On.Player.Update += distance;                                       // [ SANITY ] makes the distance work, in player ev.
            On.SaveState.SessionEnded += sanity.sanity_bar.reset_sanityBar;     // [ SANITY ] resets the bar when you pass the cycle.
        }

        #region distance

        public static void distance(On.Player.orig_Update orig, Player self, bool eu)
        {
            // if the scug is Marshaw
            if (self.slugcatStats.name == marshaw)
            {
                // calls the method that makes everything work
                sanity_bar.sanity_calc(self);
            }

            orig(self, eu);
        }

        #endregion
    }
}
