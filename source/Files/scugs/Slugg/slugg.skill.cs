using BepInEx;
using BepInEx.Logging;
using CWT;
using Helpers;
using remix_menu;
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
                Room room = self.room;
                var cwt = self.YourIssue();

                Debug.Log(slugg_options.cb_deathNoises.Value);

                //i just coded it

                if (slugg_options.cb_deathNoises.Value == true)
                {
                    room.PlaySound(DeathSounds.random_sound[UnityEngine.Random.Range(1, DeathSounds.random_sound.Length)], self.mainBodyChunk.pos);
                    room.AddObject(new ShockWave(self.mainBodyChunk.pos, 130f, 50f, 10, true));
                }
                else
                {
                    Debug.Log("");
                }

                orig(self);
            }
            catch (Exception ex)
            {
                Logger.LogError("player was slain by ExcreptionError. " + ex);
            }
        }

        #endregion

    }

}
