using BepInEx.Logging;
using System;
using objPhy = AbstractPhysicalObject;
using objType = AbstractPhysicalObject.AbstractObjectType;

namespace mw_features
{
    internal class ft_craft
    {
        public static SlugcatStats.Name marshaw { get => welp.Plugin.Marshaw; }    //name of my slugcat
        public static ManualLogSource Logger { get => welp.Plugin.Logger; }

        // Base Settings for Marshaw
        public static void craft_hooks()
        {
            On.Player.CraftingResults += marshaw_cResults;      // [ CRAFT ] Craft: the results of Crafting.
            On.Player.GraspsCanBeCrafted += marshaw_gapes;      // [ CRAFT ] hand.
            On.RainWorld.PostModsInit += marshaw_postmod;       // [ CRAFT ] affter the mods initialize.
        }

        #region MarshawCraft_PostMod - PostModsInit

        /// <summary>
        /// create the hooks for let the craft works
        /// </summary>
        /// <param name="orig"></param>
        /// <param name="self"></param>
        public static void marshaw_postmod(On.RainWorld.orig_PostModsInit orig, RainWorld self)
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

        public static bool marshaw_gapes(On.Player.orig_GraspsCanBeCrafted orig, Player self)
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

        public static objType marshaw_cResults(On.Player.orig_CraftingResults orig, Player self)
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
                //Make a sound :3 this is optional for craft
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
        public static objPhy Marshaw_CraftFinally(Player player, Creature.Grasp graspA, Creature.Grasp graspB)
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
                objType grabbedObjTypeA = graspA.grabbed.abstractPhysicalObject.type;          //hand sprite
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
}
