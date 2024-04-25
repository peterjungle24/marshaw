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

namespace regions
{

    public static class regionReg
    {

        //literally register all the regions. for now its useless lol
        public static void regionName(Player self)
        {

            Room room = self.room;                      //add the variable [ room ]

            // Vanilla ones

            string CC = room.abstractRoom.name = "CC";  //chimney canopy
            string DS = room.abstractRoom.name = "DS";  //drainage system
            string GW = room.abstractRoom.name = "GW";  //garbage wastes
            string HI = room.abstractRoom.name = "HI";  //industrial complex
            string SB = room.abstractRoom.name = "SB";  //subterranean
            string SI = room.abstractRoom.name = "SI";  //sky islands
            string SH = room.abstractRoom.name = "SH";  //shaded citadel
            string SL = room.abstractRoom.name = "SL";  //shoreline
            string SS = room.abstractRoom.name = "SS";  //five pebbles
            string SU = room.abstractRoom.name = "SU";  //outskirs
            string UW = room.abstractRoom.name = "UW";  //exterior

            // Downpour ones

            string VS = room.abstractRoom.name = "VS";  //pipeyard
            string OE = room.abstractRoom.name = "OE";  //outer expanse
            string MS = room.abstractRoom.name = "MS";  //submerged structure
            string LM = room.abstractRoom.name = "LM";  //waterfront facility
            string LC = room.abstractRoom.name = "LC";  //metropolis
            string RM = room.abstractRoom.name = "RM";  //the rot
            string DM = room.abstractRoom.name = "DM";  //looks to the moon
            string HR = room.abstractRoom.name = "HR";  //rubicon

        }

    }

}