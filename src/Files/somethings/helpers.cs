using BepInEx;
using System.Collections.Generic;
using UnityEngine;
using thing_storage;
using IL.MoreSlugcats;

namespace Helpers
{

    #region ResourceHelper

    /*

    //add a extension file...? bool_something, i got confused. Btw, thanks Fluffball
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

    public class Def_values
    {

        public static float get_sanity_value(CreatureTemplate crit)
        {

            //Constants variables CAN'T BE CHANGED.
            const float def = 0.0005f;  //Default value.
            const float friendly_regen = 0.0035f;   //Sanity change may be positive or negative

            if (crit == null)
            {

                return def;

            }

            //....i think i already defined
            var crit_type = crit.type;                  //type
            var crit_ancestor = crit.ancestor;     //ancestors
            float value;                                //value

            ///_______________________________________________________
            ///             Type
            ///_______________________________________________________

            //check the crit_type
            if (dict_storage.crit_dict.TryGetValue(crit_type, out value))
            {

                return value;
                
            }

            //check the List
            if (list_storage.friendly_creature_types.Contains(crit_type))
            {

                return -friendly_regen; //Creature restores sanity of _player when it is nearby

            }

            ///_______________________________________________________
            ///             Ancestor
            ///_______________________________________________________


            if (crit_ancestor != null && crit_ancestor.type != null)      //if ancestor its NOT null
            {

                //  ancestors

                //check the ancestor
                if (dict_storage.crit_dict.TryGetValue(crit_ancestor.type, out value))
                {

                    return value;

                }

                if (list_storage.friendly_creature_types.Contains(crit_ancestor.type))
                {

                    return -friendly_regen; //Creature restores sanity of _player when it is nearby

                }

            }

            return def;

        }

    }

}