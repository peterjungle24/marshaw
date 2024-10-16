using BepInEx.Logging;
using remix_menu;
using sounded;
using System;

namespace slg_features
{
    internal class ft_deathSounds
    {
        public static ManualLogSource Logger { get => welp.Plugin.Logger; }
        public static SlugcatStats.Name Slugg { get => welp.Plugin.slugg; }

        public static void death_hooks()
        {
            On.Player.Die += slugg_dies_illa;   // [ COSMETIC ] plays the random sound everytime in your death.
        }

        #region RANDOM DEATH SOUNDS

        /// <summary>
        /// Every time if some scug dies, will play a random sound. Cool, right?
        /// </summary>
        /// <param name="orig"></param>
        /// <param name="self"></param>
        public static void slugg_dies_illa(On.Player.orig_Die orig, Player self)
        {
            try
            {
                //variables.
                Room room = self.room;

                if (slugg_options.cb_deathNoises.Value == true && self.dead != true)
                {
                    room.PlaySound(DeathSounds.random_sound[UnityEngine.Random.Range(1, DeathSounds.random_sound.Length)], self.mainBodyChunk.pos);
                    room.AddObject(new ShockWave(self.mainBodyChunk.pos, 130f, 50f, 10, true));
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
