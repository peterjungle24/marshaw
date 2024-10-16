using BepInEx.Logging;

namespace slg_features
{
    internal class ft_2spear
    {
        public static ManualLogSource Logger { get => welp.Plugin.Logger; }
        public static SlugcatStats.Name Slugg { get => welp.Plugin.slugg; }

        public static void spear_hooks()
        {
            On.Player.Grabability += spears;    // [ SPEAR ] allows Slugg to pick 2 spears in both of hands.
        }

        #region slugg_spearDealer

        public static Player.ObjectGrabability spears(On.Player.orig_Grabability orig, Player self, PhysicalObject obj)
        {
            // allows Slugg to get 2 spears with 2 hands
            if (self.SlugCatClass == Slugg)
            {
                if (obj is Spear)
                {
                    return (Player.ObjectGrabability)1;
                }
            }
            return orig(self, obj);
        }

        #endregion
    }
}