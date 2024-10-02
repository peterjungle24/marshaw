using mw_features;
using medals;

namespace marshaw.skill
{
    /// <summary>
    /// public static hooks my beloved
    /// </summary>
    public class marshaw_features
    {
        public static void OnHooks()
        {
            // Features (ft)
            ft_craft.craft_hooks();     // [ CRAFT ] calls the method of the Craft hooks
            ft_pup.pup_hooks();         // [ PUP ] calls the method of the Pupify hooks
            ft_2spear.spear_hooks();    // [ SPEARS ] calls the method of the Spear Dealer hooks
            ft_sanity.sanity_hooks();   // [ SANITY ] calls the method of the Sanity hooks
            ft_gui.gui_hooks();         // [ GUI ] adds the GUI elements to the screen, handled on Player.Update

            // Medallions (md)
            md_wind.wind_hooks();       // [ DOUBLE J ] calls the method of the Double Jump medallion
            md_stun.stun_hooks();       // [ STUN ] calls the method of the Stun medallion
            md_stealth.stealth_hooks(); // [ STEALTH ] calls the method of the Stealth medallion
            md_aqua.aqua_hooks();       // [ AQUA ] calls the method of the Aqua medallion
        }
    }
}