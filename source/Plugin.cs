using BepInEx;
using BepInEx.Logging;
using marshaw.skill;
using marshaw.effect;
using slugg.skills;
using UnityEngine;
using System;
using sounded;
using marshaw.gui;
using System.Collections.Generic;
using Collectables_Misc;
using static Pom.Pom;
using System.IO;
using image;
using RWCustom;
using remix_menu;
using shader_manage;
using CWT;
using MoreSlugcats;
using ev;

namespace Helpers // @object of the space init
{

    [BepInPlugin(PLUGIN_ID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public const string PLUGIN_ID       = "grey.grey.grey.grey";        //the ID for the my mod in [ modinfo.json]
        public const string PLUGIN_NAME     = "Marshawwwwwwwwwwwww";        //mthe @object for my mod in [ modinfo.json]
        public const string PLUGIN_VERSION  = "0.1.1";                      //the version for my mod in [ modinfo.json]

        public static readonly SlugcatStats.Name Marshaw = new SlugcatStats.Name("marshaw");    //@object of the Marshaw
        public static readonly SlugcatStats.Name slugg = new SlugcatStats.Name("slugg_the_scug");    //@object of the Slugg
        public static new ManualLogSource Logger { get; private set; }                          //for logs
        private OptionInterface options;            //options for the remix menu ones LESS GOOOOOOO
        public static slugg_options FUCK;           //options for the remix menu ones LESS GOOOOOOO

        public static FAtlas aqua_medallion_file;
        public static FAtlas thunder_medallion_file;
        public static FAtlas fire_medallion_file;
        public static FAtlas stealth_medallion_file;
        public static FAtlas wind_medallion_file;
        public static FAtlas clone_medallion_file;

        public static string aqua_medallion = Path.Combine("sprites", "colletables", "aqua_medallion");
        public static string thunder_medallion = Path.Combine("sprites", "colletables", "thunder_medallion");
        public static string fire_medallion = Path.Combine("sprites", "colletables", "fire_medallion");
        public static string stealth_medallion = Path.Combine("sprites", "colletables", "stealth_medallion");
        public static string wind_medallion = Path.Combine("sprites", "colletables", "wind_medallion");
        public static string clone_medallion = Path.Combine("sprites", "colletables", "clone_medallion");

        public static ev_trigger oop;

        //Add hooks to the hooks for the mod work bc the codes mod can't run without hooks
        public void OnEnable()
        {
            Logger = base.Logger;                                                           //for the log base
            pom_objects();                                                                  //register POM objects
            On.RainWorld.Update += UpdateTimerFrames;                                       //update the timer frames for the Timer helper
            On.Room.AddObject += Medallion.add;                                             //add the meddallions to the 'Room.Loaded'

            //please, dont enter on this site, you will see my favourite cyan lizard ;-;
            //https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQTK8R7tsGQsYuwrsrv6VRIbSgcOI9rr1OZ0w&s

            //////// Marshaw
            On.Player.CraftingResults += MarshawSkills.MarshawCraft.Marshaw_CResults;       // [ CRAFT ] Craft: the results of Crafting.
            On.Player.GraspsCanBeCrafted += MarshawSkills.MarshawCraft.Marshaw_Gapes;       // [ CRAFT ] hand.
            On.RainWorld.PostModsInit += MarshawSkills.MarshawCraft.MarshawCraft_PostMod;   // [ CRAFT ] affter the mods initialize.
            On.Player.Update += MarshawGUI.add_gui_elements;                                // [ GUI ] add gui elements
            On.RainWorld.OnModsInit += init;                                                // [ INIT ] do action when the mod is initialized
            On.Player.Update += marshaw_effect.mushroom_effect_lol;                         // [ PARTICLE ] makes stun)skill.
            On.Player.ctor += MarshawSkills.Pupfy.Marshaw_Pup;                              // [ PLAYER ] pup.
            On.Player.Grabability += MarshawSkills.SpearDeal.SpearDealer;                   // [ PLAYER ] double spear init.
            On.Player.UpdateAnimation += marshaw_effect.FLipEffect;                         // [ PLAYER ] the flip effect init.
            On.Player.Update += MarshawSkills.distance;                                     // [ SANITY ] makes the distance work, in player trigger.
            On.SaveState.SessionEnded += sanity.sanity_bar.reset_sanityBar;                 // [ SANITY ] resets the bar when you pass the cycle.

            //////// Marshaw - MEDALLION HOOKS
            On.Player.MovementUpdate += MarshawSkills.DoubleJumpHooks.movement_upd;         // [ DOUBLE JUMP ] update for the movement check.
            On.Player.Jump += MarshawSkills.DoubleJumpHooks.jump_state;                     // [ DOUBLE JUMP ] when you jump. Manage the boolean
            On.Player.TerrainImpact += MarshawSkills.DoubleJumpHooks.jump_ground;           // [ DOUBLE JUMP ] sets the boolean to False when you are on the ground
            On.Player.Update += MarshawSkills.StunHooks.StunSkill;                          // [ STUN ] stuns all the creatures in a specific radius
            On.PlayerGraphics.DrawSprites += MarshawSkills.StealthHooks.stealthValues;      // [ STEALTH ] adds a Stealth skill and also makes your stealth stealth like a stealth
            On.Player.Update += MarshawSkills.AquaSkill.AquaUpdate;                         // [ AQUA ] lets you breath more on the aqua (EXCEPT RIVULET)

            //////// slugg
            On.Player.Die += SluggSkills.slugg_dies_illa;                                   // [ COSMETIC ] plays the random sound everytime in your death.
            On.Player.Grabability += SluggSkills.slugg_spearDealer;                         // [ SKILL ] allows Slugg to pick 2 spears in both of hands.

            //////// test
            On.Player.Update += Player_Update;
        }

        private void Player_Update(On.Player.orig_Update orig, Player self, bool eu)
        {
            orig(self, eu);
        }

        #region UpdateTimerFrames

        private void UpdateTimerFrames(On.RainWorld.orig_Update orig, RainWorld self)
        {
            timer_manage.ApplyHooks();
            orig(self);
        }
        #endregion
        #region POM objects

        /// <summary>
        /// add POM objects
        /// </summary>
        private void pom_objects()
        {
            string @object = "Slugg object";
            string others = "Slugg others";

            // medallions

            RegisterManagedObject<DoubleJ_Medallion_UAD, DoubleJ_Medallion_managedData, DoubleJ_Medallion_repr>("Double Jump Medallion", @object, false);
            RegisterManagedObject<ThunderMedallion_UAD,    ThunderMedallion_manageData, ThunderMedallion_repr>("Stun Medallion", @object, false);
            RegisterManagedObject<AquaMedallion_UAD,    AquaMedallion_manageData, AquaMedallion_repr>("Aqua Medallion", @object, false);
            RegisterManagedObject<StealthMedallion_UAD, StealthMedallion_manageData, StealthMedallion_repr>("Stealth Medallion", @object, false);

            // triggers

            //add the fields from ManagedData
            //add the same as the ManagedData fields
            var trigger_fields = new ManagedField[]
            {
                new StringField("pedro", "A", "Pedro"),
                new FloatField("width", 0f, 200f, 1f, 0.5f),
            };

            //register the object.
            RegisterFullyManagedObjectType(trigger_fields, typeof(ev_trigger), "thing trigger", others);

            Debug.Log($"Registering POM objects... sad ('marshaw' mod)");
        }

        #endregion
        #region init

        /// <summary>
        /// log this text every time when the mod initialize. Requires 10 or 20 QI in Modding for understand
        /// </summary>
        /// <param @object="orig"> original code </param>
        /// <param @object="self"> _player </param>
        private void init(On.RainWorld.orig_OnModsInit orig, RainWorld self)
        {
            orig(self);

            try
            {
                Logger.LogInfo("Marshaw says: 'Delegates are a fascinating subject and I can't wait to use them'");

                //CREATE INSTANCES
                oop = new();
                FUCK = new();

                //REGISTER
                sanity.sanity_bar.crit_dict_values();
                
                //SOUNDS
                DeathSounds.DeathSound_Init();
                CustomSFX.CustomSFX_Init();

                //LOAD IMAGES
                ImageFiles.MedallionPath = Path.Combine("sprites", "colletables", "medallion");
                ImageFiles.MedallionFile = Futile.atlasManager.LoadImage(ImageFiles.MedallionPath);

                aqua_medallion_file     = Futile.atlasManager.LoadImage(aqua_medallion);
                thunder_medallion_file  = Futile.atlasManager.LoadImage(thunder_medallion);
                fire_medallion_file     = Futile.atlasManager.LoadImage(fire_medallion);
                clone_medallion_file    = Futile.atlasManager.LoadImage(clone_medallion);
                stealth_medallion_file  = Futile.atlasManager.LoadImage(stealth_medallion);
                wind_medallion_file     = Futile.atlasManager.LoadImage(wind_medallion);

                //INIT REMIX MENU INTERFACES
                MachineConnector.SetRegisteredOI(PLUGIN_ID, FUCK);

                FUCK.Initialize();    //ITS GIVING NULL IF I ENTER ON THE ARENA

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