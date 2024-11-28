using BepInEx;
using BepInEx.Logging;
using CWT;
using ev;
using marshaw.skill;
using Objects;
using p.medallion;
using remix_menu;
using slugg.skills;
using sounded;
using UnityEngine;
using static Pom.Pom;
using System.IO;

//self.room.game.cameras[0]
namespace welp // @sl_objects of the space init
{
    [BepInPlugin(PLUGIN_ID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public const string PLUGIN_ID       = "grey.grey.grey.grey";        //the ID for the my mod in [ modinfo.json]
        public const string PLUGIN_NAME     = "Marshawwwwwwwwwwwww";        //mthe @sl_objects for my mod in [ modinfo.json]
        public const string PLUGIN_VERSION  = "0.1.1";                      //the version for my mod in [ modinfo.json]

        public static readonly SlugcatStats.Name Marshaw = new SlugcatStats.Name("marshaw");    //@sl_objects of the Marshaw
        public static readonly SlugcatStats.Name slugg = new SlugcatStats.Name("slugg_the_scug");    //@sl_objects of the Slugg
        public static new ManualLogSource Logger { get; private set; }                          //for logs
        private OptionInterface options;            //options for the remix menu ones LESS GOOOOOOO
        public static slugg_options FUCK;           //options for the remix menu ones LESS GOOOOOOO

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
            On.Player.Update += ClimbTheFuckingWall;
            On.RainWorld.Update += fish;
        }

        void fish(On.RainWorld.orig_Update orig, RainWorld self)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                var file = Path.Combine("html", "fish.html");
                File.Open(file, FileMode.Open);
            }

            orig(self);
        }
        void ClimbTheFuckingWall(On.Player.orig_Update orig, Player self, bool eu)
        {
            //self.wallSlideCounter = 5;

            Debug.Log(self.wallSlideCounter);

            orig(self, eu);
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
        void pom_objects()
        {
            string others = "Slugg others";
            string misc = "Slugg misc";

            // triggers

            //register the sl_objects.
            RegisterManagedObject<Trigger, Trigger_data, Trigger_REPR>("Thing Trigger", others, true);

            //register the medals
            Medallion.medal_POM();

            //register the misc
            RegisterManagedObject<UpsideDown, UpsideDown_Data, UpsideDown_REPR>("Upside Down gravity", misc, true);
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

                //MEDALLIONS
                Medallion.medal_init();

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