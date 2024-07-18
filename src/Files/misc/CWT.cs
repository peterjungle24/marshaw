using System;
using UnityEngine;
using BepInEx;
using System.Runtime.CompilerServices;
using Helpers;
using skl;
using System.Collections.Generic;
using static skl.Ability;

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
            public bool HasSwimMedallion;   //if this scug have the [SWIM] medallion
            public float AppliedLungFactor; //how many lung value it can have after obtaining the medallion

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
    public static class AbilityManage
    {
        public class AbilityInfo   ///BRO I HAVE TO DEAL WITH THE VERY COMPLEX SIDE OF THE C# WHAT THE FUCK I CAN'T THINK PROPERLY AND I'M SO CONFUSED BRO WTF
        {
            //Get skills
            Ability ab_DoubleJump => GetAbility(AbilityType.DoubleJump);
            Ability ab_Stun => GetAbility(AbilityType.Stun);
            Ability ab_Stealth => GetAbility(AbilityType.Stealth);

            //The player's abilities are stored here
            public List<Ability> Abilities = new List<Ability>();

            public bool HasAbility(AbilityType parameter)
            {
                return Abilities.Exists(a => a.MedalType == parameter);
            }
            public Ability GetAbility(AbilityType parameter)
            {
                return Abilities.Find(a => a.MedalType == parameter);
            }
            public void GiveAbility(AbilityType parameter)
            {
                //Avoid creating duplicate abilities
                if (HasAbility(parameter))
                {
                    return; 
                }

                switch (parameter)
                {
                    case AbilityType.DoubleJump:
                        Abilities.Add(new Ability(parameter));
                    break;
                }
            }
        }

        public static readonly ConditionalWeakTable<Player, AbilityInfo> CWT = new();          //????
        public static AbilityInfo ability(this Player self) => CWT.GetValue(self, _ => new()); ////????

    }
}