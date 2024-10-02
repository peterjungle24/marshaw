using BepInEx;
using BepInEx.Logging;
using CWT;
using LizardCosmetics;
using marshaw.skill;
using Objects;
using p;
using remix_menu;
using slugg.skills;
using sounded;
using System;
using System.IO;
using ev;
using UnityEngine;
using static Pom.Pom;

//self.room.game.cameras[0]
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

        public static Trigger oop;

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
            marshaw_features.OnHooks();         //call Marsahaw hooks
            On.RainWorld.OnModsInit += init;    //[ INIT ] do Updat when the mod is initialized

            //////// Marshaw - MEDALLION HOOKS
            marshaw_features.OnHooks();         //call Skills hooks

            //////// slugg
            SluggSkills.OnHooks();              //call Slugg hooks

            //////// objects
            FireBall.OnHooks();

            //////// test
            On.Player.Update += fireball_collision;
            On.Room.AddObject += i_added_this_hook;
            On.Player.Update += shake_off;
            On.LizardGraphics.DrawSprites += LizardGraphics_DrawSprites;
        }

        void LizardGraphics_DrawSprites(On.LizardGraphics.orig_DrawSprites orig, LizardGraphics self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            var lerp = Mathf.Lerp(0f, 1f, shader_manage.sanity_bar.sprite.alpha);

            for (var i = 0; i < sLeaser.sprites.Length; i++)
            {
                sLeaser.sprites[i].color = Color.Lerp(new(0f, 0f, 0f), new(255f, 255f, 255f), shader_manage.sanity_bar.sprite.alpha);
            }

            orig(self, sLeaser, rCam, timeStacker, camPos);
        }
        void shake_off(On.Player.orig_Update orig, Player self, bool eu)
        {
            if (shader_manage.sanity_bar.sprite.alpha <= 0.50f)
            {
                self.deaf = 1;

                if (self.adrenalineEffect == null)
                {
                    self.adrenalineEffect = new AdrenalineEffect(self);
                    self.room.AddObject(self.adrenalineEffect);
                }
                else if (self.adrenalineEffect.slatedForDeletetion)
                {
                    self.adrenalineEffect = null;
                }
            }

            orig(self, eu);
        }
        void i_added_this_hook(On.Room.orig_AddObject orig, Room self, UpdatableAndDeletable obj)
        {
            var cwt = self.issue();
            var tr = obj as Trigger;

            if (tr != null)
            {
                cwt.triggers.Add(tr);
            }

            orig(self, obj);
        }
        void fireball_collision(On.Player.orig_Update orig, Player self, bool eu)
        {
            // Fuckin To Do: tries to get a Rect or Circle or idk what shape, checks if player is touching on it, and THEN
            // do something when touchs.
            // is for Fireball code, so, i need create it from a specific key meanwhile the fire medallion is on
            // Adding one more comment line for 4 TO DO comments instead of 3
            Room room = self.room;
            Vector2 position = self.mainBodyChunk.pos;

            foreach (FireBall ball in room.FindObjectsNearby<FireBall>(position, 120f))  //checks for the distance
            {
                // Radius is 16.... i guess
                // like, its literally [ width / 2 ], so, it would be 32 originally i guess

                var distance = (ball.position - self.mainBodyChunk.pos).magnitude;

                // if the player is touching on the distance
                if ( distance <= 120f )
                {
                    //room.AddObject(new Explosion.ExplosionLight(self.mainBodyChunk.pos, 20f, 1f, 30, Color.white));
                }
            }

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
            RegisterManagedObject<FireMedallion_UAD, FireMedallion_manageData, FireMedallion_repr>("Fire Medallion", @object, false);

            // triggers

            //register the object.
            RegisterManagedObject<Trigger, Trigger_data, Trigger_REPR>("Thing Trigger", others, true);


            Debug.Log($"Registering POM objects... sad ('marshaw' mod)");
        }

        #endregion
        #region init

        /// <summary>
        /// log this text every time when the mod initialize. Requires 10 or 20 QI in Modding for understand
        /// </summary>
        /// <param @object="orig"> original code </param>
        /// <param @object="self"> _player </param>
        void init(On.RainWorld.orig_OnModsInit orig, RainWorld self)
        {
            orig(self);

            try
            {
                Logger.LogInfo("Marshaw says: 'Delegates are a fascinating subject and I can't wait to use them'");

                //ASSIGN FIELDS / CREATE VARIABLES

                //CREATE INSTANCES
                FUCK = new slugg_options();

                //REGISTER
                sanity.sanity_bar.crit_dict_values();
                
                //SOUNDS
                DeathSounds.DeathSound_Init();
                CustomSFX.CustomSFX_Init();

                //LOAD IMAGES

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