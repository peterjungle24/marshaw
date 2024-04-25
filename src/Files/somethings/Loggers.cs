#region using

using BepInEx;
using UnityEngine;
using System.IO;
using BepInEx.Logging;
using System.Collections.Generic;
using RWCustom;
using Vector2 = UnityEngine.Vector2;
using objType = AbstractPhysicalObject.AbstractObjectType;
using objPhy = AbstractPhysicalObject;
using MoreSlugcats;
using m_skill;
using System.ComponentModel;
using On;
using System.Runtime.CompilerServices;
using IL;
using System.Collections;
using UnityEngine.Experimental.GlobalIllumination;
using PedroGrey;
using static SlugBase.JsonAny;
using RewiredConsts;
using SPR;
using ExtensionHelp;
using m_s;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System.Runtime.Remoting.Contexts;

#endregion

namespace Loggers
{

    //LOGGERS
    public class logs
    {

        public static void LoggerNull()
        {

            //basically log when there is a null reference.

            Plugin.Logger.LogError("This thing was null! THIS IS A CRIMME");
            Debug.Log("This thing was null! THIS IS A CRIMME");

            //I did this out of laziness, but it was still kind of useless. enjoy

        }

    }

}