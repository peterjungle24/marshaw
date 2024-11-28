using BepInEx.Logging;

namespace mw_features
{
    internal class ft_2spear
    {
        public static SlugcatStats.Name marshaw { get => welp.Plugin.Marshaw; }    //name of my slugcat
        public static ManualLogSource Logger { get => welp.Plugin.Logger; }

        // Base Settings for Marshaw
        public static void spear_hooks()
        {
            On.Player.Grabability += SpearDealer;     // [ PLAYER ] makes Marshaw hold 2 spears with 2 hands
        }

        #region SpearDealer

        public static Player.ObjectGrabability SpearDealer(On.Player.orig_Grabability orig, Player self, PhysicalObject obj)
        {
            // checks if the scug is Marshaw
            if (self.SlugCatClass == marshaw)
            {
                // if object is Spear
                if (obj is Spear)
                {
                    // return the grab ability with 2 hands (1)
                    return (Player.ObjectGrabability) 1;
                }
            }
            // call the orig as return
            return orig(self, obj);
        }

        #endregion
    }
}