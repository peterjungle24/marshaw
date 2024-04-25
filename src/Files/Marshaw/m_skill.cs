#region using

using System;
using UnityEngine;
using System.Collections.Generic;
using RWCustom;
using Vector2 = UnityEngine.Vector2;
using objType = AbstractPhysicalObject.AbstractObjectType;
using objPhy = AbstractPhysicalObject;
using System.Runtime.CompilerServices;
using BepInEx.Logging;
using BepInEx;
using System.Security.Permissions;
using System.Security;
using MonoMod.RuntimeDetour;
using PedroGrey;
using System.IO;
using UnityEngine.Rendering;
using HUD;
using On;
using m_smth;
using IL;
using Mono.Cecil.Cil;
using MonoMod.Cil;

#endregion

namespace m_skill
{

    //ahh the Marshaw Abilities...

    #region Puppied
    public static class Pupfy
    {

        //turn the marshaw a Pup!
        public static void Marshaw_Pup(On.Player.orig_ctor orig, Player self, AbstractCreature abstractCreature, World world)
        {
            orig(self, abstractCreature, world);

            if (self.SlugCatClass.value == "marshaw")           //check the slugcar is Marshawwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww
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

        public static readonly SlugcatStats.Name marshaw = new SlugcatStats.Name("marshaw");    //name of my slugcat

        //a lot of things.

        #region PostMod

        /// <summary>
        /// create the hooks for let the craft works
        /// </summary>
        /// <param name="orig"></param>
        /// <param name="self"></param>
        public static void MarshawCraft_PostMod(On.RainWorld.orig_PostModsInit orig, RainWorld self)
        {

            On.MoreSlugcats.GourmandCombos.CraftingResults += Marshaw_GCombos;           //create the hook called GourmandCombos_CraftingResults;
            orig(self);         //call the orig

        }

        #endregion
        #region GrapesCanBeCrafted

        public static bool Marshaw_Gapes(On.Player.orig_GraspsCanBeCrafted orig, Player self)
        {

            if (self.SlugCatClass == marshaw)           //if self is marshaw
            {

                return self.input[0].y == 1 && self.CraftingResults() != null;          //return the self input for the craft

            }

            return orig(self);          //return the orig

        }

        #endregion
        #region Player_CraftingResults

        public static objType Marshaw_CResults(On.Player.orig_CraftingResults orig, Player self)
        {

            if (self.grasps.Length < 2 || self.SlugCatClass != marshaw)         //if i dont remember now :slagony:
            {

                return orig(self);          //return the orig

            }

            var craftingResult = Marshaw_CraftFinally(self, self.grasps[0], self.grasps[1]);           //variable for the hands full already for craft

            return craftingResult?.type;            //return the type of CraftingResult

        }

        #endregion
        #region GourmandCombos_CraftingResults

        public static objPhy Marshaw_GCombos(On.MoreSlugcats.GourmandCombos.orig_CraftingResults orig, PhysicalObject crafter, Creature.Grasp graspA, Creature.Grasp graspB)
        {

            if ((crafter as Player).SlugCatClass == marshaw)            //if the crafter as player and slugcatstats is Marshaw
            {

                crafter.room.PlaySound(SoundID.SS_AI_Give_The_Mark_Boom, crafter.firstChunk.pos);
                return Marshaw_CraftFinally(crafter as Player, graspA, graspB);            //return the Marshaw_Craft hook

            }


            return orig(crafter, graspA, graspB);           //return the hands

        }


        #endregion
        #region Marshaw_CraftFinally (recipes here)

        public static AbstractPhysicalObject Marshaw_CraftFinally(Player player, Creature.Grasp graspA, Creature.Grasp graspB)
        {

            Room room = player.room;

            AbstractSpear spearExplo = new AbstractSpear(player.room.world, null, player.abstractCreature.pos, player.room.game.GetNewID(), false);
            AbstractSpear spearThunder = new AbstractSpear(player.room.world, null, player.abstractCreature.pos, player.room.game.GetNewID(), false, true);

            if (player == null || graspA?.grabbed == null || graspB?.grabbed == null)
            {

                return null;          //return null if have nothing to do

            }

            //the hands!
            if (player.SlugCatClass == marshaw) //normal spear <-------------------------
            {

                objType grabbedObjTypeA = graspA.grabbed.abstractPhysicalObject.type;          //hand A
                objType grabbedObjTypeB = graspB.grabbed.abstractPhysicalObject.type;          //hand B

                if (grabbedObjTypeA == objType.Rock && grabbedObjTypeB == objType.Rock)
                {

                    //check if is holding these rocks, and craft the Spear
                    return new AbstractSpear(player.room.world, null, player.abstractCreature.pos, player.room.game.GetNewID(), false);

                }

            }

            if (player.SlugCatClass == marshaw) //explosive spear  <-------------------------
            {

                objType grabbedObjTypeA = graspA.grabbed.abstractPhysicalObject.type;          //hand A
                objType grabbedObjTypeB = graspB.grabbed.abstractPhysicalObject.type;          //hand B

                if (grabbedObjTypeA == objType.Spear && grabbedObjTypeB == objType.ScavengerBomb || grabbedObjTypeB == objType.Spear && grabbedObjTypeA == objType.ScavengerBomb)
                {

                    //check if is holding A and B or vice-versa, and craft the Explosive Spear
                    return new AbstractSpear(player.room.world, null, player.abstractCreature.pos, player.room.game.GetNewID(), true);

                }



                objType grabbedObjectTypeA = graspA.grabbed.abstractPhysicalObject.type;          //hand A
                objType grabbedObjectTypeB = graspB.grabbed.abstractPhysicalObject.type;          //hand B

                if (grabbedObjectTypeA == objType.Spear && grabbedObjectTypeB == objType.FlareBomb || grabbedObjectTypeB == objType.Spear && grabbedObjectTypeA == objType.FlareBomb)
                {

                    room.AddObject(new Explosion.ExplosionLight(player.bodyChunks[1].pos, 120f, 40, 10, Color.blue));
                    room.AddObject(new Explosion.ExplosionSmoke(player.bodyChunks[1].pos, player.bodyChunks[1].vel, 1f));
                    //check if is holding A and B or vice-versa, and craft the Electric Spear
                    return new AbstractSpear(player.room.world, null, player.abstractCreature.pos, player.room.game.GetNewID(), false, true);

                }

            }

            return null;

        }

        #endregion

    }

    #endregion
    #region SpearDealer

    public static class SpearDeal
    {

        public static readonly SlugcatStats.Name marshaw = new SlugcatStats.Name("marshaw");    //name of my slugcat

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

}