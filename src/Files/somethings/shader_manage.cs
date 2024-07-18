using Helpers;
using System.Runtime.InteropServices;
using UnityEngine;
using System;
using IL.Menu;
using BepInEx.Logging;

namespace shader_manage
{

    public static class shaders
    {
        public static string HoldButtonCircle = "HoldButtonCircle";
        public static string VectorCircle = "VectorCircle";
        public static string GhostDisto = "GhostDisto";
    }
    public class sanity_bar
    {

        public static SlugcatStats.Name marshaw { get => Plugin.Marshaw; }    //name of my slugcat
        public static FSprite spr_sanity = new FSprite("Futile_White");                           // uses the fucking atlas [ Futile_White ]
        public static ManualLogSource Logger { get => Plugin.Logger; }

        #region agony_of_this_controller

        /// <summary>
        /// for short: controls the effects while the bar decreases/increases. Shitty method. looks like Joar code
        /// </summary>
        /// <param name="s"></param>
        public static void agony_of_this_controller(RoomCamera s)
        {
            switch ( spr_sanity.alpha )
            {
                case 0.75f:
                    s.effect_desaturation = 0.25f;
                break;
                case 0.50f:
                    s.effect_desaturation = 0.50f;
                    spr_sanity.color = Color.yellow;
                    s.effect_darkness = 0.10f;
                break;
                case 0.25f:
                    s.effect_desaturation = 0.75f;
                    shader_manage.sanity_bar.spr_sanity.color = Color.red;
                    s.effect_darkness = 0.15f;
                break;
                case 0.10f:
                    s.effect_desaturation = 1f;
                    s.effect_darkness = 0.20f;
                break;
            }

        }

        #endregion
        #region sanityBar_effect

        /// <summary>
        /// when the bar can be able for appear, only for Marshaw
        /// </summary>
        /// <param name="s"></param>
        /// <param name="self"></param>
        public static void sanityBar_effect(RoomCamera s, Player self)
        {

            if (self.slugcatStats.name == marshaw)      //if the slugcat is the MARSHAW
            {
                spr_sanity.isVisible = true;            // makes visible only for MARSHAWWWWWWWWWWW
                agony_of_this_controller(s);                          // run the method above. takes agony to see that
            }
            else                                        // else if its not Marshaw
            {
                s.ReturnFContainer("HUD").RemoveChild(spr_sanity);         // remove the bar :)
            }

        }
        
        #endregion
        #region sanityBar_add

        /// <summary>
        /// create circles for the Bar....
        /// </summary>
        /// <param name="self"></param>
        /// <param name="player"></param>
        public static void sanityBar_add(RoomCamera self, Player player)
        {
            try
            {
                if (player.slugcatStats.name == marshaw)
                {
                    //create circles
                    self.ReturnFContainer("HUD").AddChild(spr_sanity);    //put the sprite in a HUD layer

                    spr_sanity.shader = self.game.rainWorld.Shaders[shaders.HoldButtonCircle];
                    spr_sanity.scaleX = 10f;    //
                    spr_sanity.scaleY = 10f;    //
                    spr_sanity.y = 668f;        //
                    spr_sanity.x = 1234;        //
                    spr_sanity.color = Color.white;
                }
                else
                {
                    self.ReturnFContainer("HUD").RemoveChild(spr_sanity);         // remove the bar :)
                }

                sanityBar_effect(player.room.game.cameras[0], player);                       // runs the code above.
            }
            catch (Exception ex)
            {
                Logger.LogError("{ shader_manage/sanityBar_add() } Some error was occured.");
                Logger.LogError(ex);
            }
        }

        #endregion

    }

}