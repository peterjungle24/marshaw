using Helpers;
using UnityEngine;
using static UnityEngine.Random;
using UnityEngine.Scripting;
using System;
using marshaw.gui;
using BepInEx.Logging;
using CWT;

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
        public static FSprite sprite = new FSprite("Futile_White");                           // uses the fucking atlas [ Futile_White ]
        public static ManualLogSource Logger { get => Plugin.Logger; }
        public static bool critical { get => sprite.alpha <= 0.25f; }

        #region agony_of_this_controller

        /// <summary>
        /// for short: controls the effects while the bar decreases/increases. Shitty method. looks like Joar code
        /// </summary>
        /// <param name="s"></param>
        public static void Lerp_in_CSharp_still_weird_beter_in_GMK(RoomCamera s)
        {
            s.effect_desaturation = Mathf.InverseLerp(1f, 0.10f, sprite.alpha);
            s.effect_darkness = (1f - sprite.alpha) * 0.25f;

            sanity_bar_zero_check(s);

            if (sprite.alpha <= 0.25f)
            {
                sprite.color = Color.red;
            }
            else if (sprite.alpha <= 0.5f)
            {
                sprite.color = Color.yellow;
            }
            else
            {
                sprite.color = Color.green;
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
                sprite.isVisible = true;            // makes visible only for MARSHAWWWWWWWWWWW
                Lerp_in_CSharp_still_weird_beter_in_GMK(s);                          // run the method above. takes agony to see that
            }
            else                                        // else if its not Marshaw
            {
                s.ReturnFContainer("HUD").RemoveChild(sprite);         // remove the bar :)
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
                    self.ReturnFContainer("HUD").AddChild(sprite);    //put the sprite in a HUD layer

                    sprite.shader = self.game.rainWorld.Shaders[shaders.HoldButtonCircle];
                    sprite.scaleX = 10f;    //
                    sprite.scaleY = 10f;    //
                    sprite.y = 668f;        //
                    sprite.x = 1234;        //
                    sprite.color = Color.white;
                }
                else
                {
                    self.ReturnFContainer("HUD").RemoveChild(sprite);         // remove the bar :)
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
        #region sanity_bar_zero_check

        public static void sanity_bar_zero_check(RoomCamera room_camera)
        {
            if (critical == true)   //if critical is true
            {
                sprite.x = Range(1234f, 1245f); //randomize 2 values
                sprite.y = Range(668f, 679f);   //randomize 2 values
            }
        }

        #endregion
    }
    public class cooldown_bar
    {
        public static FSprite sprite = new("Futile_White");
        public static ManualLogSource log { get => Plugin.Logger; }

        #region cooldownBar add

        public static void cooldownBar_Add(RoomCamera self, Player player)
        {
            try
            {
                //create circles
                Vector2 campos = self.CamPos(0);
                var cwt = player.Skill();

                if (cwt.HasStealthMedallion)
                {
                    self.ReturnFContainer("HUD").AddChild(sprite);    //put the sprite in a HUD layer
                    sprite.shader = self.game.rainWorld.Shaders[shaders.HoldButtonCircle];  //sets the shader to that circle
                    sprite.scale = 2f;    //
                    sprite.y = player.bodyChunks[0].pos.y - campos.y;        //
                    sprite.x = player.bodyChunks[0].pos.x - campos.x;        //
                    sprite.color = Color.yellow;

                    if (cwt.stealthCooldown.is_equal)
                    {
                        sprite.alpha = 0f;
                    }
                    else
                    {
                        sprite.alpha += 0.010f;
                    }
                }
            }
            catch (Exception ex)
            {
                log.LogError("{ shader_manage/cooldownBar_add() } Some error was occured.");
                log.LogError(ex);
            }
        }

        #endregion
    }
}