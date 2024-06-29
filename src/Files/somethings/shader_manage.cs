using Helpers;
using System.Runtime.InteropServices;
using UnityEngine;

namespace shader_manage
{

    public static class shaders
    {

        public static string HoldButtonCircle = "HoldButtonCircle";
        public static string VectorCircle = "VectorCircle";
        public static string GhostDisto = "GhostDisto";

    }

    public class no_idea_bar
    {

        public static SlugcatStats.Name marshaw { get => Plugin.Marshaw; }    //name of my slugcat
        public static FSprite no_idea_FSprite = new FSprite("Futile_White");           // uses the fucking atlas [ Futile_White ]

        #region noIdea_add

        /// <summary>
        /// create circles for the Bar....
        /// </summary>
        /// <param name="self"></param>
        /// <param name="player"></param>
        public static void noIdea_add(RoomCamera self)
        {

            //create circles

            no_idea_FSprite.shader = self.game.rainWorld.Shaders[shaders.VectorCircle];  // cria o círculo
            self.ReturnFContainer("HUD").AddChild(no_idea_FSprite);    //put the sprite in a HUD layer

            no_idea_FSprite.scale = 7.50f;
            no_idea_FSprite.y = 526f;       // controla a posição Y
            no_idea_FSprite.x = 1234;       // controla a posição X

            no_idea_FSprite.color = Color.grey;

        }

        #endregion


    }

    public class sanity_bar
    {

        public static SlugcatStats.Name marshaw { get => Plugin.Marshaw; }    //name of my slugcat
        public static FSprite sanity_fSprite = new FSprite("Futile_White");                           // uses the fucking atlas [ Futile_White ]

        #region agony_of_this_controller

        /// <summary>
        /// for short: controls the effects while the bar decreases/increases. Shitty method. looks like Joar code
        /// </summary>
        /// <param name="s"></param>
        public static void agony_of_this_controller(RoomCamera s)
        {
            switch ( sanity_fSprite.alpha )
            {
                case 0.75f:
                    s.effect_desaturation = 0.25f;
                break;
                case 0.50f:
                    s.effect_desaturation = 0.50f;
                    sanity_fSprite.color = Color.yellow;
                    s.effect_darkness = 0.10f;
                break;
                case 0.25f:
                    s.effect_desaturation = 0.75f;
                    shader_manage.sanity_bar.sanity_fSprite.color = Color.red;
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
                sanity_fSprite.isVisible = true;            // makes visible only for MARSHAWWWWWWWWWWW
                agony_of_this_controller(s);                          // run the method above. takes agony to see that
            }
            else                                        // else if its not Marshaw
            {
                s.ReturnFContainer("HUD").RemoveChild(sanity_fSprite);         // remove the bar :)
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

            if (player.slugcatStats.name == marshaw)
            {
                //create circles

                sanity_fSprite.shader = self.game.rainWorld.Shaders[shaders.HoldButtonCircle];  //create the circle
                self.ReturnFContainer("HUD").AddChild(sanity_fSprite);    //put the sprite in a HUD layer

                sanity_fSprite.scaleX = 10f;    //
                sanity_fSprite.scaleY = 10f;    //
                sanity_fSprite.y = 668f;        //
                sanity_fSprite.x = 1234;        //
                sanity_fSprite.color = Color.white;
                
            }
            else
            {
                self.ReturnFContainer("HUD").RemoveChild(sanity_fSprite);         // remove the bar :)
            }

            sanityBar_effect(player.room.game.cameras[0], player);                       // runs the code above.

        }

        #endregion

    }

}