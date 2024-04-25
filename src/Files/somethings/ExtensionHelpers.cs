#region using

using System;
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

#endregion

namespace ExtensionHelp
{

    #region ResourceHelper

    //add a extension file...? idk but Fluffball gave this for me.
    public static class ResourceHelper
    {

        public static FAtlas LoadImage(string path)
        {

            //strips file extension from path, Futile will add one for us
            string pathModified = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path));
            AssetManager.ResolveFilePath(null);

            return Futile.atlasManager.LoadImage(pathModified); //return

        }


    }

    #endregion
    #region ??

    //BRO WHAT IS MY PROBLEM?? SO FAR I HAVE NOT USED ANY HELPER (subject to change lmao)

    #endregion

}