using System;
using BepInEx;
using UnityEngine;
using marshaw;
using welp;
using System.Collections.Generic;

namespace thing_storage
{

    public class dict_storage
    {

        public static Dictionary<CreatureTemplate.Type, float> crit_dict = new();

    }

    public class list_storage
    {

        public static List<CreatureTemplate.Type> friendly_creature_types = new();

    }

}