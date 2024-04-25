#region using

using BepInEx;
using UnityEngine;
using BepInEx.Logging;
using System.Collections.Generic;
using RWCustom;
using objType = AbstractPhysicalObject.AbstractObjectType;
using objPhy = AbstractPhysicalObject;
using MoreSlugcats;
using m_skill;
using PedroGrey;
using RewiredConsts;
using SPR;
using ExtensionHelp;
using m_s;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using m_smth;

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