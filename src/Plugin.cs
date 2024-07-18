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
using RWCustom;
using remix_menu;
using shader_manage;
using CWT;

namespace Helpers // name of the space init
{

    /// <summary>
    /// Player 
    /// self.abstractCreature.Room.world.game.cameras[0]
    /// </summary>

    [BepInPlugin(PLUGIN_ID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {

        public const string PLUGIN_ID       = "grey.grey.grey.grey";        //the ID for the my mod in [ modinfo.json]
        public const string PLUGIN_NAME     = "Marshawwwwwwwwwwwww";        //mthe name for my mod in [ modinfo.json]
        public const string PLUGIN_VERSION  = "0.1.1";                      //the version for my mod in [ modinfo.json]

        #region Fields

        public static readonly SlugcatStats.Name Marshaw = new SlugcatStats.Name("marshaw");    //name of the Marshaw
        public static readonly SlugcatStats.Name slugg = new SlugcatStats.Name("slugg_the_scug");    //name of the Slugg
        public static new ManualLogSource Logger { get; private set; }                          //for logs
        private OptionInterface options;    //options for the remix menu ones LESS GOOOOOOO

        #endregion

        public Plugin()
        {
            options = new Remix();
        }

        //Add hooks to the hooks for the mod work bc the codes mod can't run without hooks
        public void OnEnable()
        {
            Logger = base.Logger;   //for the log base
            pom_objects();  //register POM objects
            On.RainWorld.Update += UpdateTimerFrames;

            //please, dont enter on this site, you will see my favourite cyan lizard ;-;
            //https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQTK8R7tsGQsYuwrsrv6VRIbSgcOI9rr1OZ0w&s

            //////// Marshaw
            On.Player.CraftingResults += MarshawSkills.MarshawCraft.Marshaw_CResults;       // [ CRAFT ] Craft: the results of Crafting.
            On.Player.GraspsCanBeCrafted += MarshawSkills.MarshawCraft.Marshaw_Gapes;       // [ CRAFT ] hand.
            On.RainWorld.PostModsInit += MarshawSkills.MarshawCraft.MarshawCraft_PostMod;   // [ CRAFT ] affter the mods initialize.
            On.Player.Update += MarshawGUI.add_gui_MARSHAW;                                 // [ GUI ] add gui elements when is Marshaw
            On.RainWorld.OnModsInit += init;                                                // [ INIT ] do action when the mod is initialized
            On.Player.Update += marshaw_effect.mushroom_effect_lol;                         // [ PARTICLE ] makes stun)skill.
            On.Player.ctor += MarshawSkills.Pupfy.Marshaw_Pup;                              // [ PLAYER ] pup.
            On.Player.Grabability += MarshawSkills.SpearDeal.SpearDealer;                   // [ PLAYER ] double spear init.
            On.Player.UpdateAnimation += marshaw_effect.FLipEffect;                         // [ PLAYER ] the flip effect init.
            On.Player.Update += MarshawSkills.distance;                                     // [ SANITY ] makes the distance work, in Player Collect.
            On.SaveState.SessionEnded += sanity.sanity_bar.reset_sanityBar;                 // [ SANITY ] resets the bar when you pass the cycle.

            //////// Marshaw -  MEDALLION HOOKS
            On.Room.AddObject += Medallion.add;                                             // [ MEDALLION ] add the meddallions to the 'Room.Loaded'

            On.Player.MovementUpdate += MarshawSkills.DoubleJumpHooks.movement_upd;         // [ DOUBLE JUMP ] update for the movement check.
            On.Player.Jump += MarshawSkills.DoubleJumpHooks.jump_state;                     // [ DOUBLE JUMP ] when you jump. Manage the boolean
            On.Player.TerrainImpact += MarshawSkills.DoubleJumpHooks.jump_ground;           // [ DOUBLE JUMP ] sets the boolean to False when you are on the ground
            On.Player.Update += MarshawSkills.StunHooks.StunSkill;                          // [ STUN ] stuns all the creatures in a specific radius

            //////// slugg
            On.Player.Die += SluggSkills.slugg_dies_illa;                                   // [ COSMETIC ] plays the random sound everytime in your death.
            On.Player.Grabability += SluggSkills.slugg_spearDealer;                         // [ SKILL ] allows Slugg to pick 2 spears in both of hands.

            //////// test
            On.PlayerGraphics.DrawSprites += stealthAlphaModify;
            On.Player.Update += AbilityCost.deal_with_fucking_structs;
        }

        

        #region UpdateTimerFrames

        public bool test_bool;
        private void UpdateTimerFrames(On.RainWorld.orig_Update orig, RainWorld self)
        {
            foreach (var timer in timer_manage.TimerRegistered)
            {
                timer.Advance();

                //if the current value is same as value_wanted, it restart
                if (timer.current_value >= timer.value_wanted)
                {
                    test_bool = true;
                }
            }

            orig(self);
            timer_manage.TimerRegistered.RemoveAll(t => t.value_reached); //Cleanup
        }
        #endregion
        #region stealthAlphaModify

        private void stealthAlphaModify(On.PlayerGraphics.orig_DrawSprites orig, PlayerGraphics self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            var player = self.player;    //easier for use the Player variable
            var cwt = player.Skill();    //CWT local variable
            var stat = player.slugcatStats; //stats of the player
            
            if (cwt.HasStealthMedallion)    //if they have a medallion
            {
                //logic below:
                if (cwt.stealthTimer == null)  //if its null
                {
                    cwt.stealthTimer = new(151);   //creates a instance with the [float counter] defined
                    cwt.stealthCooldown = new(151); //creates a instance for the cooldown
                }

                Debug.Log($"stealth: {cwt.stealthTimer.current_value}");
                Debug.Log($"stealth cooldown: {cwt.stealthCooldown.current_value}");

                if (!cwt.stealthTimer.is_running && cwt.stealthTimerReady && player.input[1].thrw && player.input[0].thrw)   //if this input
                {
                    cwt.stealthTimer.Start();  //start the stealthTimer
                }

                if (cwt.stealthTimer.is_running)
                {
                    for (var i = 0; i < sLeaser.sprites.Length; i++)
                    {
                        sLeaser.sprites[i].alpha -= 0.10f;
                    }
                }
                else
                {
                    for (var i = 0; i < sLeaser.sprites.Length; i++)
                    {
                        sLeaser.sprites[i].alpha += 0.10f;
                    }
                }

                if (cwt.stealthTimer.value_reached)
                {
                    cwt.stealthTimer.Stop();
                    cwt.stealthCooldown.Start();
                }
            }

            orig(self, sLeaser, rCam, timeStacker, camPos);
        }

        #endregion
        #region POM objects

        /// <summary>
        /// add POM objects
        /// </summary>
        private void pom_objects()
        {
            string name = "Slugg object";

            RegisterManagedObject<DoubleJ_Medallion_UAD, DoubleJ_Medallion_managedData, DoubleJ_Medallion_repr>("Double Jump Medallion", name, false);
            RegisterManagedObject<StunMedallion_UAD,    StunMedallion_manageData, StunMedallion_repr>("Stun Medallion", name, false);
            RegisterManagedObject<SwimMedallion_UAD,    SwimMedallion_manageData, SwimMedallion_repr>("Swim Medallion", name, false);
            RegisterManagedObject<StealthMedallion_UAD, StealthMedallion_manageData, StealthMedallion_repr>("Stealth Medallion", name, false);

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

                //INIT REMIX MENU INTERFACES
                MachineConnector.SetRegisteredOI(PLUGIN_ID, options);

                //REGISTER
                sanity.sanity_bar.crit_dict_values();
                
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