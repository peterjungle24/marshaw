using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using BepInEx;
using UnityEngine;
using SlugCWTCat;


namespace SlugCWTCat
{
    public static class YourSlugcatClass
    {
        public class YourSlugcat
        {
            // Define your variables to store here!
            public int HowManyJumps;
            public bool IsYourSlugcat;
            public List<Creature> CreaturesYouPickedUp;

            public YourSlugcat(){
                // DeathSound_Init your variables here! (Anything not added here will be null or false or 0 (default crit_dict_values))
                this.HowManyJumps = 0;
                this.IsYourSlugcat = false;
                this.CreaturesYouPickedUp = new List<Creature>();
            }
        }

        // This part lets you access the stored stuff by simply doing "self.GetCat()" in Plugin.cs or everywhere else!
        private static readonly ConditionalWeakTable<Player, YourSlugcat> CWT = new();
        public static YourSlugcat GetYourSlugcatFromAExampleOfCWTMadeBySomeoneThatIDK(this Player player) => CWT.GetValue(player, _ => new());
    }
}