using System;
using UnityEngine;
using BepInEx;
using System.Runtime.CompilerServices;
using Helpers;
using System.Collections.Generic;

namespace CWT
{
    public static class GetSkills
    {
        public class skill   ///skill
        {
            ///GENERAL

            ///  DOUBLE JUMP
            public bool HasDoubleJumpMedallion; //if this scug have the [DOUBLE JUMP] medallion
            public bool playerAlreadyJumped;    //if this scug already jumped

            ///  SWIM SKILL
            public bool HasAquaMedallion;   //if this scug have the [SWIM] medallion
            public float AppliedLungFactor; //how many lung Svalue it can have after obtaining the medallion

            ///  STUN SKILL
            public bool HasStunMedallion;   //if this scug have the [STUN] medallion

            ///  STEALTH SKILL
            public bool HasStealthMedallion;    //if this scug have the [STEALTH] medallion
            public Timer stealthTimer;  //a timer for the Stealth
            public Timer stealthCooldown;  //a cooldown timer for Stealth
            public bool stealthTimerReady => !stealthCooldown.is_running && !stealthTimer.is_running;  //Indicates when the stealth ability may be activated by the player
        }

        public static readonly ConditionalWeakTable<Player, skill> CWT = new();          //????
        public static skill Skill(this Player self) => CWT.GetValue(self, _ => new()); ////????

    }
    public static class SluggSkillIssue
    {
        public class skill_issue   ///skill
        {
            ///GENERAL

            /// COSMETIC ONE
            public bool CustomDeathSound;
        }

        public static readonly ConditionalWeakTable<Player, skill_issue> CWT = new();          //????
        public static skill_issue YourIssue(this Player self) => CWT.GetValue(self, _ => new()); ////????
    }
}