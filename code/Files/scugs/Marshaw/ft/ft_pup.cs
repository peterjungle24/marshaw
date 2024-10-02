using BepInEx.Logging;

namespace mw_features
{
    internal class ft_pup
    {
        public static SlugcatStats.Name marshaw { get => Helpers.Plugin.Marshaw; }    //name of my slugcat
        public static ManualLogSource Logger { get => Helpers.Plugin.Logger; }

        // Base Settings for Marshaw
        public static void pup_hooks()
        {
            On.Player.ctor += pupify;  // [ PUP ] pup
        }

        #region pupify

        public static void pupify(On.Player.orig_ctor orig, Player self, AbstractCreature abstractCreature, World world)
        {
            orig(self, abstractCreature, world);

            if (self.slugcatStats.name == marshaw)      //check the slugcar is marshaw
            {
                self.playerState.forceFullGrown = false;    //makes the mess stop forcing the growth of vegetarian vegetation that grows in your favor as nature does 
                self.playerState.isPup = true;              //is pup. Only this
            }
        }

        #endregion
    }
}