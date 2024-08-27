using System;
using BepInEx;
using Helpers;
using UnityEngine;

namespace sounded
{

    public static class DeathSounds
    {
        //Sounds YAYDAYDAYDADOHSADIAODASODWP

        //part 1
        public static SoundID echoLG { get; private set; }
        public static SoundID rideBike { get; private set; }
        public static SoundID boomSR { get; private set; }
        public static SoundID cheese { get; private set; }
        public static SoundID coca_cola { get; private set; }
        public static SoundID cool_banana { get; private set; }
        public static SoundID you_dissapear { get; private set; }
        public static SoundID friday { get; private set; }
        public static SoundID GLUE { get; private set; }
        public static SoundID half_death { get; private set; }
        public static SoundID slaps { get; private set; }
        public static SoundID robloc { get; private set; }
        public static SoundID MORTIS { get; private set; }
        public static SoundID minceraft { get; private set; }
        public static SoundID plants_vs_noooo { get; private set; }
        public static SoundID slash { get; private set; }
        public static SoundID Travis { get; private set; }
        public static SoundID waa { get; private set; }
        
        //part 2
        public static SoundID acataelinodorokiabla { get; private set; }
        public static SoundID alien { get; private set; }
        public static SoundID bitconeeee { get; private set; }
        public static SoundID golden_scream { get; private set; }
        public static SoundID hard_claps  { get; private set; }
        public static SoundID jumpscared_you  { get; private set; }
        public static SoundID kirb_scream  { get; private set; }
        public static SoundID oh_yeah_mrCrabs  { get; private set; }
        public static SoundID thats_a_bug  { get; private set; }
        public static SoundID who_are_you  { get; private set; }
        public static SoundID why_this_price_is_so_hight_wawa  { get; private set; }
        public static SoundID wii_theme  { get; private set; }

        public static SoundID[] random_sound = new SoundID[]
        {

            //part 1

            echoLG = new ("echolg", true),
            rideBike = new ("rideBike", true),
            boomSR = new("boomSR", true),
            cheese = new("cheese", true),
            coca_cola = new("coca-cola", true),
            cool_banana = new("cool-banana", true),
            you_dissapear = new("you-dissapear", true),
            friday = new("friday", true),
            GLUE = new("GLUE", true),
            half_death = new("half-death", true),
            slaps = new("slaps", true),
            robloc = new("robloc", true),
            MORTIS = new("MORTIS", true),
            minceraft = new("minceraft", true),
            plants_vs_noooo = new("plants-vs-noooo", true),
            slash = new("slash", true),
            Travis = new("Travis", true),
            waa = new("waa", true),

                        //part 2
            
            acataelinodorokiabla = new("acataelinodorokiabla", true),
            alien = new ("alien", true),
            bitconeeee = new ("bitconeeee", true),
            golden_scream = new ("golden-scream", true),
            hard_claps = new ("hard-claps", true),
            jumpscared_you = new ("jumpscared-you", true),
            kirb_scream = new ("kirb-scream", true),
            oh_yeah_mrCrabs = new ("oh-yeah-mrCrabs", true),
            thats_a_bug = new ("thats_a_bug  ", true),
            who_are_you = new ("who-are-you", true),
            why_this_price_is_so_hight_wawa = new ("why-this-price-is-so-hight-wawa", true),
            wii_theme = new ("wii-theme", true)

        };

        /// <summary>
        /// Initialize these fucking sounds in the [ RainWorld.OnModsInit ] hook.
        /// </summary>
        public static void DeathSound_Init()
        {
            //part 1
            echoLG =          new ("echolg", true);
            rideBike =        new ("rideBike", true);
            boomSR =          new ("boomSR", true);
            cheese =          new ("cheese", true);
            coca_cola =       new("coca-cola", true);
            cool_banana =     new("cool-banana", true);
            you_dissapear =   new("you-dissapear", true);
            friday =          new("friday", true);
            GLUE =            new("GLUE", true);
            half_death =      new("half-death", true);
            slaps =           new("slaps", true);
            robloc =          new("robloc", true);
            MORTIS =          new("MORTIS", true);
            minceraft =       new("minceraft", true);
            plants_vs_noooo = new("plants-vs-noooo", true);
            slash =           new("slash", true);
            Travis =          new("Travis", true);
            waa =             new("waa", true);
            
            //part 2
            acataelinodorokiabla =              new("acataelinodorokiabla", true);
            alien =                             new("alien", true);
            bitconeeee =                        new("bitconeeee", true);
            golden_scream =                     new("golden-scream", true);
            hard_claps =                        new("hard-claps", true);
            jumpscared_you =                    new("jumpscared-you", true);
            kirb_scream =                       new("kirb-scream", true);
            oh_yeah_mrCrabs =                   new("oh-yeah-mrCrabs", true);
            thats_a_bug =                       new("thats_a_bug  ", true);
            who_are_you =                       new("who-are-you", true);
            why_this_price_is_so_hight_wawa =   new("why-this-price-is-so-hight-wawa", true);
            wii_theme =                         new("wii-theme", true);

        }

    }
    public static class CustomSFX
    {

        public static SoundID EFF_doubleJump { get; private set; }

        public static void CustomSFX_Init()
        {
            EFF_doubleJump = new("double-jump", true);
        }

    }

}