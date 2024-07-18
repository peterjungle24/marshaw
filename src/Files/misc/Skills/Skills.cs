using System;
using UnityEngine;
using BepInEx;
using CWT;

namespace skl
{
    public class Ability
    {
        public AbilityType MedalType;

        public Ability(AbilityType parameter)
        {
            MedalType = parameter;
        }

        public enum AbilityType
        {
            Clone, DoubleJump,
            Stealth, Stun,
            Swim
        }
    }
    public class AbilityCost
    {

    }
}