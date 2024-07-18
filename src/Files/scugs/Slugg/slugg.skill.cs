using BepInEx;
using BepInEx.Logging;
using Helpers;
using sounded;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace slugg.skills
{

    public class SluggSkills
    {

        public static ManualLogSource Logger { get => Plugin.Logger; }
        public static SlugcatStats.Name Slugg { get => Plugin.slugg; }

        #region slugg_spearDealer

        /// <summary>
        /// Allow the slugg to get 2 spears in their hands at same time.
        /// </summary>
        /// <param name="orig"></param>
        /// <param name="self"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Player.ObjectGrabability slugg_spearDealer(On.Player.orig_Grabability orig, Player self, PhysicalObject obj)
        {

            if (self.SlugCatClass == Slugg)
            {

                if (obj is Spear)
                {

                    return (Player.ObjectGrabability)1;

                }

            }

            return orig(self, obj);

        }

        #endregion
        #region RANDOM DEATH SOUNDS

        /// <summary>
        /// Every time if Slugg dies, will play a random sound. Cool, right?
        /// </summary>
        /// <param name="orig"></param>
        /// <param name="self"></param>
        public static void slugg_dies_illa(On.Player.orig_Die orig, Player self)
        {
            try
            {
                //Reference for a Deepwoken OST init
                Room room = self.room;

                room.PlaySound(DeathSounds.random_sound[UnityEngine.Random.Range(1, 19)], self.mainBodyChunk.pos);
                room.AddObject(new ShockWave(self.mainBodyChunk.pos, 130f, 50f, 10, true));

                orig(self);

            }
            catch (Exception ex)
            {
                Logger.LogError("An error ocurred. Please run to the montains!! " + ex);
            }

        }

        #endregion

    }

    #region double jump CWT

    public static class cwt_slugg
    {
        public class cwt_doubleJ
        {

            //insert data here. i guess
            public int Jumped;
            public float JumpHeigth;

            public cwt_doubleJ()
            {



            }

        }

        public static readonly ConditionalWeakTable<Player, cwt_doubleJ> CWT = new();
        public static cwt_doubleJ double_jump(this Player self) => CWT.GetValue(self, _ => new());

    }
    #endregion

}