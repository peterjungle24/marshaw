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
using System.Collections.Generic;
using MoreSlugcats;
using Collectables_Misc;
using static Pom.Pom;
using System.IO;
using image;

namespace Helpers // name of the space init
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

        #endregion

        //Add hooks to the hooks for the mod work bc the codes mod can't run without hooks
        public void OnEnable()
        {
            Logger = base.Logger;                                                   //for the log base
            pom_objects();

            //please, dont enter on this site, you will see my favourite cyan lizard ;-;
            //https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQTK8R7tsGQsYuwrsrv6VRIbSgcOI9rr1OZ0w&s

            //////// Marshaw
            On.Player.CraftingResults += MarshawSkills.MarshawCraft.Marshaw_CResults;       // [ CRAFT ] Craft: the results of Crafting.
            On.Player.GraspsCanBeCrafted += MarshawSkills.MarshawCraft.Marshaw_Gapes;       // [ CRAFT ] hand.
            On.RainWorld.PostModsInit += MarshawSkills.MarshawCraft.MarshawCraft_PostMod;   // [ CRAFT ] affter the mods initialize.
            On.Player.MovementUpdate += MarshawSkills.DoubleJumpHooks.movement_upd;         // [ DOUBLE JUMP ] update for the movement check.
            On.Player.Jump += MarshawSkills.DoubleJumpHooks.jump_state;                     // [ DOUBLE JUMP ] when you jump. Manage the boolean
            On.Player.TerrainImpact += MarshawSkills.DoubleJumpHooks.jump_ground;           // [ DOUBLE JUMP ] sets the boolean to False when you are on the ground
            On.Player.Update += MarshawGUI.add_gui_MARSHAW;                                 // [ GUI ] add gui elements when is Marshaw
            On.RainWorld.OnModsInit += init;                                                // [ INIT ] do action when the mod is initialized
            On.Player.Update += marshaw_effect.mushroom_effect_lol;                         // [ PARTICLE ] makes idk.
            On.Player.ctor += MarshawSkills.Pupfy.Marshaw_Pup;                              // [ PLAYER ] pup.
            On.Player.Grabability += MarshawSkills.SpearDeal.SpearDealer;                   // [ PLAYER ] double spear init.
            On.Player.UpdateAnimation += marshaw_effect.FLipEffect;                         // [ PLAYER ] the flip effect init.
            On.Player.Update += MarshawSkills.distance;                                     // [ SANITY ] makes the distance work, in Player Collect.
            On.SaveState.SessionEnded += sanity_bar.reset_sanityBar;                        // [ SANITY ] resets the bar when you pass the cycle.

            //////// Marshaw -  MEDALLION HOOKS
            On.Room.AddObject += add;                                                       // [ MEDALLION ] add to the 'Room.Loaded'

            //////// slugg
            On.Player.Die += slugg_dies_illa;                                               // [ COSMETIC ] plays the random sound everytime in your death.
            On.Player.Grabability += SluggSkills.slugg_spearDealer;                         // [ SKILL ] allows Slugg to pick 2 spears in both of hands.

            //////// test

        }

        #region add

        private void add(On.Room.orig_AddObject orig, Room self, UpdatableAndDeletable obj)
        {
            if (self.game != null)
            {
                if (self.game.IsStorySession && self.game.StoryCharacter != Marshaw && obj is medallion_UAD)
                {
                    return; //Return early as this collectable should not be drawn for this campaign
                }
            }

            orig(self, obj);
        }

        #endregion
        #region RANDOM DEATH SOUNDS

        /// <summary>
        /// Every time if Slugg dies, will play a random sound. Cool, right?
        /// </summary>
        /// <param name="orig"></param>
        /// <param name="self"></param>
        private void slugg_dies_illa(On.Player.orig_Die orig, Player self)
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
        #region POM objects

        /// <summary>
        /// add POM objects
        /// </summary>
        private void pom_objects()
        {

            RegisterManagedObject<medallion_UAD, medallion_managedData, medallion_repr>("Medallion", "slugg objects", false);
            //RegisterEmptyObjectType<medallion_managedData, medallion_repr>("Medallion test", "slugg objects");

            Debug.Log($"Registering POM objects... sad ('slugg' mod)");

        }

        #endregion
        #region init

        /// <summary>
        /// log this text every time when the mod initialize. Requires 10 or 20 QI in Modding for understand
        /// </summary>
        /// <param name="orig"> original code </param>
        /// <param name="self"> _player </param>
        private void init(On.RainWorld.orig_OnModsInit orig, RainWorld self)
        {
            orig(self);

            try
            {
                Logger.LogInfo("Marshaw says: (he said nothing)");
                shader_manage.no_idea_bar.no_idea_FSprite.alpha = 0f;

                //REGISTER
                sanity_bar.crit_dict_values();
                
                //SOUNDS
                DeathSounds.DeathSound_Init();
                CustomSFX.CustomSFX_Init();

                //LOAD IMAGES
                ImageFiles.MedallionPath = Path.Combine("sprites", "colletables", "medallion");
                ImageFiles.MedallionFile = Futile.atlasManager.LoadImage(ImageFiles.MedallionPath);
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

// FluffBall
// Nuclear Pasta
// Thalber
// BensoneWhite
// NaCio
// Magica
// Alduris
// luna ☾fallen/endspeaker☽
// Pocky(Burnout/Forager/Siren)
// Elliot (Solace's creator)
// IWannaPresents
// Rose
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
// AT
// GreatestGrasshopper
// StormTheCat (Slugpup Safari Dev)

#endregion