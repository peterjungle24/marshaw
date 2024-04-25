#region Using

using System;
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

#endregion

namespace m_effects
{

    #region FlipEffect

    //effect when you DO A 360° FLIP OMG OOOOHHHHHH
    public static class FlipEffect
    {

        public static readonly SlugcatStats.Name marshaw = new SlugcatStats.Name("marshaw");    //name of my slugcat

        #region FlipEffect

        //hook this hook for hook your effect
        public static void FLipEffect(On.Player.orig_UpdateAnimation orig, Player self)
        {

            Room room = self.room;                                                                                          //the smae room as [what fate as Slugcat? ]

            if (self.SlugCatClass == marshaw)                                                                               //if its MARSHAW on the room.
            {

                if (self.animation == Player.AnimationIndex.Flip)                                                           //if Marshaw make a FLIP OMAGA OOOOOOHHHH
                {

                    Debug.Log("Bro did a flip :skull::skull::skull::skull:");                                               // bro did a flip :skull::skull::skull::skull:
                    room.AddObject(new Explosion.ExplosionSmoke(self.bodyChunks[1].pos, self.bodyChunks[1].vel, 1f));       //[ smoke everyday *music* ]
                    room.AddObject(new Explosion.ExplosionLight(self.bodyChunks[1].pos, 120f, 40, 10, Color.green));        //[ "You are my sunshine, my only sunshine" ]

                }

            }

            orig(self);

        }

        #endregion
        #region FlipSkill

        //nothing LMAO

        #endregion

    }

    #endregion

}