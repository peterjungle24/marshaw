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

namespace ExtensionHelp
{

    #region ResourceHelper

    /*

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

    */

    #endregion

}