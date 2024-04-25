#region using

using BepInEx;
using UnityEngine;
using System.IO;
using BepInEx.Logging;
using System.Collections.Generic;
using RWCustom;
using Vector2 = UnityEngine.Vector2;
using objType = AbstractPhysicalObject.AbstractObjectType;
using objPhy = AbstractPhysicalObject;
using MoreSlugcats;
using m_skill;
using System.ComponentModel;
using On;
using System.Runtime.CompilerServices;
using IL;
using System.Collections;
using UnityEngine.Experimental.GlobalIllumination;
using PedroGrey;
using static SlugBase.JsonAny;
using RewiredConsts;
using SPR;
using ExtensionHelp;
using m_smth;

#endregion


namespace m_s
{

    public static class shader_col
    {

        public static readonly SlugcatStats.Name marshaw = new SlugcatStats.Name("marshaw");    //name of my slugcat
        public static FSprite f_sprite = new FSprite("Futile_White");                           // uses the fucking atlas [ Futile_White ]

        // please hide this fuck bc takes agony if you see this
        // for short: controls the effects while the bar decreases/increases
        public static void fuck_you(RoomCamera s)
        {

            if (m_s.shader_col.f_sprite.alpha <= 0.75f)
            {

                s.effect_desaturation = 0.25f;

            }
            if (m_s.shader_col.f_sprite.alpha <= 0.50f)
            {

                s.effect_desaturation = 0.50f;
                m_s.shader_col.f_sprite.color = Color.yellow;
                s.effect_darkness = 0.10f;

            }
            if (m_s.shader_col.f_sprite.alpha <= 0.25f)
            {

                s.effect_desaturation = 0.75f;
                m_s.shader_col.f_sprite.color = Color.red;
                s.effect_darkness = 0.15f;

            }
            if (m_s.shader_col.f_sprite.alpha <= 0.10f)
            {

                s.effect_desaturation = 1f;
                s.effect_darkness = 0.20f;

            }

        }

        // when the bar can be able for appear, only for Marshaw
        public static void sh_desaturation(RoomCamera s, Player self)
        {

            if (self.slugcatStats.name == marshaw)                                      //if the slugcat is the MARSHAW
            {

                m_s.shader_col.f_sprite.isVisible = true;                               // makes visible only for MARSHAWWWWWWWWWWW


                fuck_you(s);                                                            // run the method above. takes agony to see that
                

            }
            else                                                                        // else if its not Marshaw
            {

                s.ReturnFContainer("HUD").RemoveChild(m_s.shader_col.f_sprite);         // remove the bar :)

            }

        }

        public static void s_literally_circles(RoomCamera self, Player player)
        {

            #region  Circle 0

            f_sprite.shader = self.game.rainWorld.Shaders["HoldButtonCircle"];  // cria o círculo
            self.ReturnFContainer("HUD").AddChild(f_sprite);    // coloca o sprite na camada dos Menus

            f_sprite.scaleX = 5f;     // controla o tamanho X
            f_sprite.scaleY = 5f;     // controla o tamamnho Y
            f_sprite.y = 668f;           // controla a posição X
            f_sprite.x = 1234;            // controla a posição X

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

            f_sprite.color = Color.white;                                               // set the color to White. so obvious, why you asked?
            self.effect_desaturation = 0f;                                              // set the desaturation for default.
            self.effect_darkness = 0f;                                                  // set the darkness to default

            sh_desaturation(player.room.game.cameras[0], player);                       // runs the code above.

        }

    }

}