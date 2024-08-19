using BepInEx;
using BepInEx.Logging;
using UnityEngine;
using objType = AbstractPhysicalObject.AbstractObjectType;
using objPhy = AbstractPhysicalObject;
using Helpers;
using System;
using sanity;
using particle_manager;
using sounded;
using CWT;
using System.Runtime.InteropServices;
using MoreSlugcats;

namespace marshaw.skill
{
    /// <summary>
    /// public static hooks my beloved
    /// </summary>
    public class MarshawSkills
    {
        public static SlugcatStats.Name marshaw { get => Plugin.Marshaw; }    //name of my slugcat
        public static ManualLogSource Logger { get => Plugin.Logger; }

        #region Puppied
        public static class Pupfy
        {

            //turn the Marshaw a Pup!
            public static void Marshaw_Pup(On.Player.orig_ctor orig, Player self, AbstractCreature abstractCreature, World world)
            {
                orig(self, abstractCreature, world);

                if (self.slugcatStats.name == marshaw)           //check the slugcar is marshaw
                {
                    self.playerState.forceFullGrown = false;        //makes the mess stop forcing the growth of vegetarian vegetation that grows in your favor as nature does 
                    self.playerState.isPup = true;                  //is pup. Only this
                }
            }

        }
        #endregion
        #region Crafted
        public static class MarshawCraft
        {
            //a lot of things. A horror for see in Github i imagine

            #region MarshawCraft_PostMod - PostModsInit

            /// <summary>
            /// create the hooks for let the craft works
            /// </summary>
            /// <param name="orig"></param>
            /// <param name="self"></param>
            public static void MarshawCraft_PostMod(On.RainWorld.orig_PostModsInit orig, RainWorld self)
            {
                // On.RainWorld.PostModsinit hook
                try
                {
                    //Create the hook for [ GourmandCombos.CraftingResults ]
                    On.MoreSlugcats.GourmandCombos.CraftingResults += Marshaw_GCombos;

                    //Call the orig
                    orig(self);
                }
                catch (Exception ex)    //if gets the error instead
                {
                    //log the error. Shrimple
                    Logger.LogError(ex);
                }
            }

            #endregion
            #region Marshaw_Gapes - GraspsCanBeCrafted

            public static bool Marshaw_Gapes(On.Player.orig_GraspsCanBeCrafted orig, Player self)
            {
                //On.player.GraspsCanBeCrafted hook

                //if the player its Marshaw
                if (self.SlugCatClass == marshaw)
                {
                    //return this input for up and method is not null
                    return self.input[0].y == 1 && self.CraftingResults() != null;
                }
                //return (call) the orig
                return orig(self);
            }

            #endregion
            #region Player_CraftingResults

            public static objType Marshaw_CResults(On.Player.orig_CraftingResults orig, Player self)
            {
                //On.player.CraftingResults hook

                //if the grasps length is less than 2 and the class is not Marshaw
                if (self.grasps.Length < 2 || self.SlugCatClass != marshaw)
                {
                    //call orig
                    return orig(self);
                }

                //craft results for the hands and the craft results and i dont remember anymore sorry
                var craftingResult = Marshaw_CraftFinally(self, self.grasps[0], self.grasps[1]);           //variable for the hands full already for craft
                //these [ ? ] syntax just confuse me in the most of time.
                return craftingResult?.type;
            }

            #endregion
            #region GourmandCombos_CraftingResults

            public static objPhy Marshaw_GCombos(On.MoreSlugcats.GourmandCombos.orig_CraftingResults orig, PhysicalObject crafter, Creature.Grasp graspA, Creature.Grasp graspB)
            {
                //On.MoreSlugcats.GourmandCombos.CraftingResults hook

                /// THIS CODE BELOW IS OPTIONAL

                //If the player is Marshaw
                if ((crafter as Player).SlugCatClass == marshaw)
                {
                    //Make a sound :3 this is optionalcraft
                    crafter.room.PlaySound(SoundID.SS_AI_Give_The_Mark_Boom, crafter.firstChunk.pos);
                 
                    /// THIS CODE BELOW IS TOTALLY OBRIGATORY FOR WORK

                    return Marshaw_CraftFinally(crafter as Player, graspA, graspB); //return the method that allows you to make the spears
                }

                //return (call) orig
                return orig(crafter, graspA, graspB);
            }

            #endregion
            #region Marshaw_CraftFinally (recipes here)

            /// <summary>
            /// Finally, you can make your recipe here BRUHHHHH
            /// </summary>
            /// <param name="player"></param>
            /// <param name="graspA"></param>
            /// <param name="graspB"></param>
            /// <returns></returns>
            public static AbstractPhysicalObject Marshaw_CraftFinally(Player player, Creature.Grasp graspA, Creature.Grasp graspB)
            {
                var spear = new AbstractSpear(player.room.world, null, player.abstractCreature.pos, player.room.game.GetNewID(), false);            //normal spear
                var spear_ex = new AbstractSpear(player.room.world, null, player.abstractCreature.pos, player.room.game.GetNewID(), true);          //explosive spear
                var spear_el = new AbstractSpear(player.room.world, null, player.abstractCreature.pos, player.room.game.GetNewID(), false, true);   //electric spear

                //if have nothing
                if (player == null || graspA?.grabbed == null || graspB?.grabbed == null)
                {
                    return null;          //return null if have nothing to do
                }

                //if this scug is Marshaw (if not check it will affect EVERY SCUG)
                if (player.slugcatStats.name == marshaw)                
                {
                    objType grabbedObjTypeA = graspA.grabbed.abstractPhysicalObject.type;          //hand A
                    objType grabbedObjTypeB = graspB.grabbed.abstractPhysicalObject.type;          //hand B

                    // Rock + Rock = Spear
                    if (grabbedObjTypeA == objType.Rock && grabbedObjTypeB == objType.Rock)
                    {
                        return spear;   //craft Spear
                    }

                    // Spear + Bomb = Explosion Spear
                    if (grabbedObjTypeA == objType.Spear && grabbedObjTypeB == objType.ScavengerBomb || 
                        grabbedObjTypeB == objType.Spear && grabbedObjTypeA == objType.ScavengerBomb)
                    {
                        return spear_ex;
                    }

                    // Spear + Flashbang = Electric Spear (charged)
                    if (grabbedObjTypeA == objType.Spear && grabbedObjTypeB == objType.FlareBomb || grabbedObjTypeA == objType.Spear && grabbedObjTypeB == objType.FlareBomb)
                    {
                        return spear_el;
                    }
                }
                return null;    //nothing to do. Is the final of the code
            }

            #endregion
        }

        #endregion
        #region SpearDealer

        public static class SpearDeal
        {
            public static Player.ObjectGrabability SpearDealer(On.Player.orig_Grabability orig, Player self, PhysicalObject obj)
            {
                if (self.SlugCatClass == marshaw)
                {
                    if (obj is Spear)
                    {
                        return (Player.ObjectGrabability)1;
                    }
                }
                return orig(self, obj);
            }
        }

        #endregion
        #region distance

        public static void distance(On.Player.orig_Update orig, Player self, bool eu)
        {
            if (self.slugcatStats.name == marshaw)
            {
                sanity_bar.sanity_calc(self);
            }

            orig(self, eu);
        }

        #endregion

        // Obtainable Skills/Abilities (you obtain them when you get some collectable)
        #region double_jump

        public class DoubleJumpHooks
        {
            #region jump_ground

            public static void jump_ground(On.Player.orig_TerrainImpact orig, Player self, int chunk, RWCustom.IntVector2 direction, float speed, bool firstContact)
            {
                var cwt_skill = self.Skill();

                if (cwt_skill.HasDoubleJumpMedallion == true)
                {
                    cwt_skill.playerAlreadyJumped = false;
                }

                orig(self, chunk, direction, speed, firstContact);
            }

            #endregion
            #region movement_upd

            public static void movement_upd(On.Player.orig_MovementUpdate orig, Player self, bool eu)
            {
                Room room = self.room;
                var cwt_skill = self.Skill(); ;

                if (self.Skill().playerAlreadyJumped == true && cwt_skill.HasDoubleJumpMedallion == true && !self.input[1].jmp && self.input[0].jmp)
                {
                    room.PlaySound(CustomSFX.EFF_doubleJump, self.mainBodyChunk.pos);
                    room.AddObject(new PlayerBubbles(self, 3f, 0f, 1f, self.ShortCutColor()));
                    self.canJump = 1;
                    self.wantToJump++;
                }

                orig(self, eu); //call Orig

                if (self.Skill().HasDoubleJumpMedallion == true && self.Skill().playerAlreadyJumped == true)
                {
                    if (!self.Consious ||
                    self.Stunned || self.animation == Player.AnimationIndex.HangFromBeam ||
                    self.animation == Player.AnimationIndex.ClimbOnBeam || self.animation == Player.AnimationIndex.AntlerClimb ||
                    self.animation == Player.AnimationIndex.VineGrab || self.animation == Player.AnimationIndex.ZeroGPoleGrab ||
                    self.bodyMode == Player.BodyModeIndex.WallClimb || self.bodyMode == Player.BodyModeIndex.Swimming ||
                    (self.bodyMode == Player.BodyModeIndex.ZeroG || self.room.gravity <= 0.5f) && (self.wantToJump > 0))
                    {
                        self.Skill().playerAlreadyJumped = false;
                    }
                }
            }

            #endregion
            #region jump_state

            public static void jump_state(On.Player.orig_Jump orig, Player self)
            {
                orig(self);

                var cwt_skill = self.Skill(); ;

                if (cwt_skill.HasDoubleJumpMedallion == true)
                {
                    if (self.Skill().playerAlreadyJumped == true)
                    {
                        self.Skill().playerAlreadyJumped = false;
                    }
                    else
                    {
                        self.Skill().playerAlreadyJumped = true;
                        self.canJump = 1;
                    }
                }
            }

            #endregion
        }

        #endregion
        #region stun
        
        public class StunHooks
        {
            public static void StunSkill(On.Player.orig_Update orig, Player self, bool eu)
            {
                var room = self.room;
                var cwt = self.Skill();
                var i = self.input;

                if (cwt.HasStunMedallion == true )   //if the scug have medallion
                {
                    foreach (Creature c in room.FindObjectsNearby<Creature>(self.mainBodyChunk.pos, 200f))  //checks for the distance
                    {
                        if (i[0].thrw && i[1].thrw && i[0].y == 1)  //if its pressing some inputs
                        {
                            c.Stun(100);  //stuns
                        }
                    }
                }

                orig(self, eu);
            }
        }

        #endregion
        #region stealth

        public class StealthHooks
        {
            #region stealthValues

            public static void stealthValues(On.PlayerGraphics.orig_DrawSprites orig, PlayerGraphics self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
            {
                var player = self.player;    //easier for use the player variable
                var cwt = player.Skill();    //CWT local variable

                if (cwt.HasStealthMedallion == true)    //if they have a medallion
                {
                    //logic below:
                    if (cwt.stealthTimer == null)  //if its null
                    {
                        cwt.stealthTimer = new(151);   //creates a instance with the [float counter] defined
                        cwt.stealthCooldown = new(151); //creates a instance for the cooldown
                        cwt.stealthCooldown.Start();
                    }

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
        }

        #endregion
        #region aqua

        public class AquaSkill
        {
            public static SlugcatStats.Name Marshaw { get => Plugin.Marshaw; }
            public static SlugcatStats.Name slugg { get => Plugin.slugg; }

            public static void AquaUpdate(On.Player.orig_Update orig, Player self, bool eu)
            {
                ///TO DO: breathe more in the water
                var cwt = self.Skill();

                if (cwt.HasAquaMedallion)
                {
                    /// VANILLA
                    if (self.slugcatStats.name == SlugcatStats.Name.Yellow ||
                        self.slugcatStats.name == SlugcatStats.Name.White ||
                        self.slugcatStats.name == SlugcatStats.Name.Red)
                    {
                        cwt.AppliedLungFactor = 0.50f;
                    }

                    /// MSC (i can't use a switch here bc it needs to be a constant Svalue and is imcompatible)
                    else if (self.slugcatStats.name == MoreSlugcatsEnums.SlugcatStatsName.Spear ||
                        self.slugcatStats.name == MoreSlugcatsEnums.SlugcatStatsName.Gourmand)
                    {
                        cwt.AppliedLungFactor = 0.75f;
                    }

                    else if (self.slugcatStats.name == MoreSlugcatsEnums.SlugcatStatsName.Saint ||
                        self.slugcatStats.name == MoreSlugcatsEnums.SlugcatStatsName.Sofanthiel ||
                        self.slugcatStats.name == MoreSlugcatsEnums.SlugcatStatsName.Slugpup)
                    {
                        cwt.AppliedLungFactor = 0.60f;
                    }

                    /// MY MODDED ONES
                    else if (self.slugcatStats.name == Marshaw)
                    {
                        cwt.AppliedLungFactor = 0.90f;
                    }
                    else if (self.slugcatStats.name == slugg)
                    {
                        cwt.AppliedLungFactor = 0.70f;
                    }

                    self.slugcatStats.lungsFac = cwt.AppliedLungFactor;
                }

                orig(self, eu);
            }
        }

        #endregion
    }
}