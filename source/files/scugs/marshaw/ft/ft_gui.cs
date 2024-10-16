using shader_manage;

namespace mw_features
{
    internal class ft_gui
    {
        public static SlugcatStats.Name marshaw { get => welp.Plugin.Marshaw; }

        public static void gui_hooks()
        {
            On.Player.Update += gui_add;
        }

        #region gui_add

        public static void gui_add(On.Player.orig_Update orig, Player self, bool eu)
        {
            // checks if the scug is Marshaw
            if (self.slugcatStats.name == marshaw)
            {
                // add the Sanity bar thing
                sanity.sanity_bar.sanityBar_add(self);
            }

            // add this cooldown bar
            cooldown_bar.cooldownBar_Add(self.room.game.cameras[0], self);

            orig(self, eu);
        }

        #endregion
    }
}
