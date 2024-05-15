using UnityEngine;

namespace marshaw.effect
{

    /// <summary>
    /// do the effects for Marshawwwwwwwwwwwwww
    /// </summary>
    public static class marshaw_effect
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

    }

}