#region using

using BepInEx;
using UnityEngine;
using BepInEx.Logging;
using System.Collections.Generic;
using RWCustom;
using objType = AbstractPhysicalObject.AbstractObjectType;
using objPhy = AbstractPhysicalObject;
using MoreSlugcats;
using m_skill;
using PedroGrey;
using RewiredConsts;
using SPR;
using ExtensionHelp;
using m_s;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using m_smth;

#endregion

namespace PedroGrey // name of the space lol
{

    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {

        #region Fields

        public const string PLUGIN_GUID = "grey.grey.grey.grey";                                //the ID for the my mod in [ modinfo.json]
        public const string PLUGIN_NAME = "Marshawwwwwwwwwwwww";                                //mthe name for my mod in [ modinfo.json]
        public const string PLUGIN_VERSION = "0.1.1";                                           //the version for my mod in [ modinfo.json]
        public static readonly SlugcatStats.Name marshaw = new SlugcatStats.Name("marshaw");    //name of my slugcat
        public static new ManualLogSource Logger { get; private set; }                          //for logs
        public static RoomCamera c;

        #endregion

        //Add hooks to the hooks for the mod work bc the codes mod can't run without hooks
        public void OnEnable()
        {

            Logger = base.Logger;                                                   //for the log base

            //We need hooks below for run the code else this code can't run bc will throw exception bc its not set to a object or something but idk as well bc i've never seen this exception before bc i always prevent that error bc the VS warn about that for me that its not exists in a context or something but ik you dont wanna know that you have a interest of the code, so stop reading this big comment bc this is so looong OMG. but anyways, when you see the code, you are able to see the comments. but i dont wanna a lot of serious comments (but some of them are and some confusing) but i wanna humor of this. so, read the code.

            On.Player.CraftingResults += m_skill.MarshawCraft.Marshaw_CResults;     // for Craft: the results of Crafting.
            On.Player.GraspsCanBeCrafted += m_skill.MarshawCraft.Marshaw_Gapes;     // for Craft: hand.
            On.Player.ctor += Pupfy.Marshaw_Pup;                                    // for Player: pup.
            On.Player.Grabability += m_skill.SpearDeal.SpearDealer;                 // for Player: double spear lol.
            On.Player.UpdateAnimation += m_effects.FlipEffect.FLipEffect;           // for Player: the flip effect lol.
            On.RainWorld.PostModsInit += MarshawCraft.MarshawCraft_PostMod;         // for Mods / Craft: when the mods initialize.
            On.Player.Update += m_smth.Sanity.SanityActive;                         // for Sanity: actives the sanity bar if its Marshaw.
            On.RainWorld.OnModsInit += lol;                                         // Log always when its enabled and initialize the mod
            On.Player.Update += distance_please;                                    // for Sanity: calculates the distance for increase/decrease bar

        }

        #region distance_please

        // calculates the distance for trigger the effects for the sanity bar
        private void distance_please(On.Player.orig_Update orig, Player self, bool eu)
        {

            foreach (var list in self.room.physicalObjects)
            {

                foreach (PhysicalObject obj in list)
                {

                    if (obj != self && obj is Creature creature)
                    {

                        var dist = (creature.mainBodyChunk.pos - self.mainBodyChunk.pos).magnitude;     // variable for the distance. returns Float

                        if (dist <= 120f)                                                               // if [ disst ] its less than [ 120 ]
                        {

                            m_s.shader_col.f_sprite.alpha -= 0.0030f;                                   // decrease

                        }
                        else
                        {

                            m_s.shader_col.f_sprite.alpha = m_s.shader_col.f_sprite.alpha;                                   // increase

                        }

                    }
                    else
                    {

                        m_s.shader_col.f_sprite.alpha += 0.0025f;                                   // increase

                    }

                }

            }

            orig(self, eu);

        }

        #endregion
        #region lol

        // log this text every time when the mod initialize. Requires 0 QI for understand
        private void lol(On.RainWorld.orig_OnModsInit orig, RainWorld self)
        {

            Debug.Log("Enable MARSHAWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW");

            orig(self);

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
