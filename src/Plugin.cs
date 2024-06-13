using BepInEx;
using BepInEx.Logging;
using marshaw.skill;
using marshaw.effect;
using slugg.skills;
using sanity;
using UnityEngine;
using System;
using sounded;
using particle_manager;
using marshaw.gui;

namespace Helpers // name of the space init_the_mod
{

    /// <summary>
    /// Player 
    /// self.abstractCreature.Room.world.game.cameras[0]
    /// </summary>

    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {

        #region Fields

        public const string PLUGIN_GUID = "grey.grey.grey.grey";                                //the ID for the my mod in [ modinfo.json]
        public const string PLUGIN_NAME = "Marshawwwwwwwwwwwww";                                //mthe name for my mod in [ modinfo.json]
        public const string PLUGIN_VERSION = "0.1.1";                                           //the version for my mod in [ modinfo.json]

        public static readonly SlugcatStats.Name Marshaw = new SlugcatStats.Name("marshaw");    //name of the Marshaw
        public static readonly SlugcatStats.Name slugg = new SlugcatStats.Name("slugg_the_scug");    //name of the Marshaw

        public static new ManualLogSource Logger { get; private set; }                          //for logs
        public static RoomCamera c;
        public static Player p;

        #endregion

        //Add hooks to the hooks for the mod work bc the codes mod can't run without hooks
        public void OnEnable()
        {

            Logger = base.Logger;                                                   //for the log base
            On.RainWorld.Awake += register_sound;

            //please, dont enter on this site, you will see my favourite cyan lizard ;-;
            //https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQTK8R7tsGQsYuwrsrv6VRIbSgcOI9rr1OZ0w&s

            // Marshaw

            On.Player.CraftingResults += Hookeds.MarshawCraft.Marshaw_CResults;     // [ CRAFT ] Craft: the results of Crafting.
            On.Player.GraspsCanBeCrafted += Hookeds.MarshawCraft.Marshaw_Gapes;     // [ CRAFT ] hand.
            On.RainWorld.PostModsInit += Hookeds.MarshawCraft.MarshawCraft_PostMod; // [ CRAFT ] affter the mods initialize.

            On.RainWorld.OnModsInit += init_the_mod;                                // [ INIT ] Log always when its enabled and initialize the mod

            On.Player.Update += marshaw_effect.mushroom_effect_lol;                 // [ PARTICLE ] testing

            On.Player.ctor += Hookeds.Pupfy.Marshaw_Pup;                            // [ PLAYER ] pup.
            On.Player.Grabability += Hookeds.SpearDeal.SpearDealer;                 // [ PLAYER ] double spear init_the_mod.
            On.Player.UpdateAnimation += marshaw_effect.FLipEffect;                 // [ PLAYER ] the flip effect init_the_mod.

            On.Player.Update += sanity_bar.sanity_active;                           // [ SANITY ] actives the sanity bar if its Marshaw.
            On.Player.Update += Hookeds.distance;                                   // [ SANITY ] makes the distance work, in Player Update.
            On.SaveState.SessionEnded += sanity_bar.reset_sanityBar;                // [ SANITY ] resets the bar when you pass the cycle.

            // slugg

            On.Player.Die += slugg_dies_illa;                                       // [ COSMETIC ] plays the random sound everytime in your death
            On.Player.Grabability += Skills.slugg_spearDealer;                      // [ SKILL ] allows Slugg to pick 2 spears in both of hands.

            // slugg - Graphics


        }


        #region slugg_dies_illa

        /// <summary>
        /// Every time if Slugg dies, will play a random sound. Cool, right?
        /// </summary>
        /// <param name="orig"></param>
        /// <param name="self"></param>
        private void slugg_dies_illa(On.Player.orig_Die orig, Player self)
        {
            try
            {

                //Reference for a Deepwoken OST init_the_mod
                Room room = self.room;

                room.PlaySound(Sounded.random_sound[UnityEngine.Random.Range(1, 19)], self.mainBodyChunk.pos);
                room.AddObject(new ShockWave(self.mainBodyChunk.pos, 130f, 50f, 10, true));

                orig(self);

            }
            catch (Exception ex)
            {

                Logger.LogError("An error ocurred. Please run to the montains!! " + ex);

            }

        }

        #endregion

        #region register sound

        /// <summary>
        /// It registers the sound. 
        /// </summary>
        /// <param name="orig"></param>
        /// <param name="self"></param>
        private void register_sound(On.RainWorld.orig_Awake orig, RainWorld self)
        {

            Sounded.sound_init();   //register. Bruh

            orig(self);

        }


        #endregion
        #region lol

        /// <summary>
        /// log this text every time when the mod initialize. Requires 10 or 20 QI in Modding for understand
        /// </summary>
        /// <param name="orig"> original code </param>
        /// <param name="self"> _player </param>
        private void init_the_mod(On.RainWorld.orig_OnModsInit orig, RainWorld self)
        {
            orig(self);

            try
            {
                Logger.LogInfo("Marshaw says: \'he said nothing\'");

                sanity_bar.crit_dict_values();
            }
            catch (Exception ex)
            {
                Logger.LogError("crashed lol");
                Logger.LogError(ex);
            }
        }

        #endregion
         
    }

}

#region Credits

// Thalber
// NaCio
// luna ☾fallen/endspeaker☽
// Pocky(Burnout/Forager/Siren)
// Elliot (Solace's creator)
// IWannaPresents
// Magica
// Alduris
// FluffBall
// Rose
// Nuclear Pasta
// doppelkeks
// Tat011
// Human Resource
// @verityoffaith
// dogcat
// hootis (always ping pls)
// Tuko (bc for my region in first time)
// Ethan Barron
// Bro
// Orinaari (kiki the Scugs)
// Nope
// BensoneWhite
// AT
// GreatestGrasshopper
// StormTheCat (Slugpup Safari Dev)
// Santiny

#endregion
