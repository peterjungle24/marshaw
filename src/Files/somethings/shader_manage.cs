using Helpers;
using System.Runtime.InteropServices;
using UnityEngine;

namespace shader_manage
{

    public static class shaders
    {

        public static string HoldButtonCircle = "HoldButtonCircle";

    }

    public class sanity_bar
    {

        public static SlugcatStats.Name marshaw { get => Plugin.Marshaw; }    //name of my slugcat
        public static FSprite f_sprite = new FSprite("Futile_White");                           // uses the fucking atlas [ Futile_White ]

        // please hide this fuck bc takes agony if you see this

        /// <summary>
        /// for short: controls the effects while the bar decreases/increases. Shitty method. looks like Joar code
        /// </summary>
        /// <param name="s"></param>
        public static void bar_controller(RoomCamera s)
        {

            if (shader_manage.sanity_bar.f_sprite.alpha <= 0.75f)
            {

                s.effect_desaturation = 0.25f;

            }
            if (shader_manage.sanity_bar.f_sprite.alpha <= 0.50f)
            {

                s.effect_desaturation = 0.50f;
                shader_manage.sanity_bar.f_sprite.color = Color.yellow;
                s.effect_darkness = 0.10f;

            }
            if (shader_manage.sanity_bar.f_sprite.alpha <= 0.25f)
            {

                s.effect_desaturation = 0.75f;
                shader_manage.sanity_bar.f_sprite.color = Color.red;
                s.effect_darkness = 0.15f;

            }
            if (shader_manage.sanity_bar.f_sprite.alpha <= 0.10f)
            {

                s.effect_desaturation = 1f;
                s.effect_darkness = 0.20f;

            }

        }

        /// <summary>
        /// when the bar can be able for appear, only for Marshaw
        /// </summary>
        /// <param name="s"></param>
        /// <param name="self"></param>
        public static void bar_effect_desaturation(RoomCamera s, Player self)
        {

            if (self.slugcatStats.name == marshaw)                                      //if the slugcat is the MARSHAW
            {

                sanity_bar.f_sprite.isVisible = true;                               // makes visible only for MARSHAWWWWWWWWWWW


                bar_controller(s);                                                            // run the method above. takes agony to see that
                

            }
            else                                                                        // else if its not Marshaw
            {

                s.ReturnFContainer("HUD").RemoveChild(shader_manage.sanity_bar.f_sprite);         // remove the bar :)

            }

        }

        /// <summary>
        /// create circles for the Bar....
        /// </summary>
        /// <param name="self"></param>
        /// <param name="player"></param>
        public static void s_literally_circles(RoomCamera self, Player player)
        {

            //create circles.

            #region  Circle 0

            f_sprite.shader = self.game.rainWorld.Shaders["HoldButtonCircle"];  // cria o círculo
            self.ReturnFContainer("HUD").AddChild(f_sprite);    // coloca o sprite na camada dos Menus

            f_sprite.scaleX = 5f;    // controla o tamanho X
            f_sprite.scaleY = 5f;    // controla o tamamnho Y
            f_sprite.y = 668f;       // controla a posição X
            f_sprite.x = 1234;       // controla a posição X

            #endregion
            #region  Circle 1

            f_sprite.shader = self.game.rainWorld.Shaders["HoldButtonCircle"];  // cria o círculo
            self.ReturnFContainer("HUD").AddChild(f_sprite);    // coloca o sprite na camada dos Menus

            f_sprite.scaleX = 6f;     // controla o tamanho X
            f_sprite.scaleY = 6f;     // controla o tamamnho Y
            f_sprite.y = 668f;           // controla a posição X
            f_sprite.x = 1234;            // controla a posição X

            #endregion
            #region  Circle 2

            f_sprite.shader = self.game.rainWorld.Shaders["HoldButtonCircle"];  // cria o círculo
            self.ReturnFContainer("HUD").AddChild(f_sprite);    // coloca o sprite na camada dos Menus

            f_sprite.scaleX = 7f;     // controla o tamanho X
            f_sprite.scaleY = 7f;     // controla o tamamnho Y
            f_sprite.y = 668f;           // controla a posição X
            f_sprite.x = 1234;            // controla a posição X

            #endregion
            #region  Circle 3

            f_sprite.shader = self.game.rainWorld.Shaders["HoldButtonCircle"];  // cria o círculo
            self.ReturnFContainer("HUD").AddChild(f_sprite);    // coloca o sprite na camada dos Menus

            f_sprite.scaleX = 8f;     // controla o tamanho X
            f_sprite.scaleY = 8f;     // controla o tamamnho Y
            f_sprite.y = 668f;           // controla a posição X
            f_sprite.x = 1234;            // controla a posição X

            #endregion
            #region  Circle 4

            f_sprite.shader = self.game.rainWorld.Shaders["HoldButtonCircle"];  // cria o círculo
            self.ReturnFContainer("HUD").AddChild(f_sprite);    // coloca o sprite na camada dos Menus

            f_sprite.scaleX = 8f;     // controla o tamanho X
            f_sprite.scaleY = 8f;     // controla o tamamnho Y
            f_sprite.y = 668f;           // controla a posição X
            f_sprite.x = 1234;            // controla a posição X

            #endregion
            #region  Circle 5

            f_sprite.shader = self.game.rainWorld.Shaders["HoldButtonCircle"];  // cria o círculo
            self.ReturnFContainer("HUD").AddChild(f_sprite);    // coloca o sprite na camada dos Menus

            f_sprite.scaleX = 8f;     // controla o tamanho X
            f_sprite.scaleY = 8f;     // controla o tamamnho Y
            f_sprite.y = 668f;           // controla a posição X
            f_sprite.x = 1234;            // controla a posição X

            #endregion
            #region  Circle 6

            f_sprite.shader = self.game.rainWorld.Shaders["HoldButtonCircle"];  // cria o círculo
            self.ReturnFContainer("HUD").AddChild(f_sprite);    // coloca o sprite na camada dos Menus

            f_sprite.scaleX = 9f;     // controla o tamanho X
            f_sprite.scaleY = 9f;     // controla o tamamnho Y
            f_sprite.y = 668f;           // controla a posição X
            f_sprite.x = 1234;            // controla a posição X

            #endregion

            f_sprite.color = Color.white;
            self.effect_desaturation = 0f;                                      // set the desaturation for default.
            self.effect_darkness = 0f;                                          // set the darkness to default

            bar_effect_desaturation(player.room.game.cameras[0], player);                       // runs the code above.

        }

    }

    public class des_sanity
    {

        public static FSprite f_dessanity = new("Futile_white");

        public static void des_sanityCircle(RoomCamera self, Player player)
        {

            f_dessanity.shader = self.game.rainWorld.Shaders[shaders.HoldButtonCircle];  // cria o círculo
            self.ReturnFContainer("HUD").AddChild(f_dessanity);    // coloca o sprite na camada dos Menus

            f_dessanity.scaleX = 5f;    // size Y
            f_dessanity.scaleY = 5f;    // size X
            f_dessanity.y = 668f;       // Pos Y
            f_dessanity.x = 1234;       // Pos X

        }

    }

}