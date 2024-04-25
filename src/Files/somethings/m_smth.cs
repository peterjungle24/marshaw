#region using

using System;
using UnityEngine;
using System.Collections.Generic;
using RWCustom;
using Vector2 = UnityEngine.Vector2;
using objType = AbstractPhysicalObject.AbstractObjectType;
using objPhy = AbstractPhysicalObject;
using System.Runtime.CompilerServices;
using BepInEx.Logging;
using BepInEx;
using System.Security.Permissions;
using System.Security;
using MonoMod.RuntimeDetour;
using PedroGrey;
using System.IO;
using UnityEngine.Rendering;
using HUD;
using On;
using Loggers;

#endregion

namespace m_smth
{

    #region Sanity

    //class for the sanity bar.
    public static class Sanity
    {

        public static readonly SlugcatStats.Name marshaw = new SlugcatStats.Name("marshaw");    //name of my slugcat

        #region SanityActive

        public static void SanityActive(On.Player.orig_Update orig, Player self, bool eu)
        {

            if (self.slugcatStats.name == marshaw)                                              //check if the slugcat its Marshwawwww
            {

                m_s.shader_col.s_literally_circles(self.room.game.cameras[0], self);            //draw the bar and the circles

                float alphaFactor = 0.02f;                                                      //the float consumes/desconsumes

                if (Input.GetKey(KeyCode.W))                                                    //increase
                {

                    m_s.shader_col.f_sprite.alpha += alphaFactor;

                }
                if (Input.GetKey(KeyCode.S))                                                    //decrease
                {

                    m_s.shader_col.f_sprite.alpha -= alphaFactor;

                }

            }

            orig(self, eu);

        }

        #endregion

    }

    #endregion

}