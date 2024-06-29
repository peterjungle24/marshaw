using BepInEx;
using BepInEx.Logging;
using Helpers;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace slugg.skills
{

    public class SluggSkills
    {

        public static ManualLogSource Logger { get => Plugin.Logger; }
        public static SlugcatStats.Name Slugg { get => Plugin.slugg; }

        #region slugg_spearDealer

        /// <summary>
        /// Allow the slugg to get 2 spears in their hands at same time.
        /// </summary>
        /// <param name="orig"></param>
        /// <param name="self"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Player.ObjectGrabability slugg_spearDealer(On.Player.orig_Grabability orig, Player self, PhysicalObject obj)
        {

            if (self.SlugCatClass == Slugg)
            {

                if (obj is Spear)
                {

                    return (Player.ObjectGrabability)1;

                }

            }

            return orig(self, obj);

        }

        #endregion

    }

    #region double jump CWT

    public static class cwt_slugg
    {
        public class cwt_doubleJ
        {

            //insert data here. i guess
            public int Jumped;
            public float JumpHeigth;

            public cwt_doubleJ()
            {



            }

        }

        public static readonly ConditionalWeakTable<Player, cwt_doubleJ> CWT = new();
        public static cwt_doubleJ double_jump(this Player self) => CWT.GetValue(self, _ => new());

    }
    #endregion

}