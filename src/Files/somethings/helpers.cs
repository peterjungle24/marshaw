using BepInEx;
using System.Collections.Generic;
using UnityEngine;
using thing_storage;
using shader_manage;
using System.IO;
using System;
using System.Linq;
using BepInEx.Logging;
using Collectables_Misc;

namespace Helpers
{

    #region ResourceHelper

    /*

    //add a extension file_check...? bool_something, i got confused. Btw, thanks Fluffball
    public static class ResourceHelper
    {

        public static FAtlas LoadImage(string path1)
        {

            //strips file_check extension from path1, Futile will add one for us
            string pathModified = image_path.Combine(image_path.GetDirectoryName(path1), image_path.GetFileNameWithoutExtension(path1));
            AssetManager.ResolveFilePath(null);

            return Futile.atlasManager.LoadImage(pathModified); //return

        }

    }

    */

    #endregion
    #region def_values

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
    
    #endregion

    public class help
    {  
        
        public static ManualLogSource Logger { get => Plugin.Logger; }

        /// <summary>
        /// load any sprite with the File path_elements.
        /// </summary>
        /// <param name="element"> element as a String. literally i make them as a 'static string' field </param>
        /// <param name="path_elements"> path_elements. obviously </param>
        public static FAtlas LoadSprite(string file, params string[] path_elements)  //i really hate return methods
        {
            file = Path.Combine(path_elements);  //a string variable for specify the path1.
                
            if (Futile.atlasManager.DoesContainElementWithName(file))  // if was registered
            {
                Logger.LogInfo("the name exists");   // log
            }
            return Futile.atlasManager.LoadImage(file);   //ATLAS FUCKING this in image the load [ read in other way ]
        }

    }
    public class file_manager
    {
        public static readonly string file_name = AssetManager.ResolveFilePath("medallion.txt"); 
        public static ManualLogSource Logger { get => Plugin.Logger; }

        ///Medallion
        
        public static void create_files()
        {
            var file = File.CreateText(file_name);
            file.Close();
        }

        public static string TAG;
        public static string ROOM;
        public static float X;
        public static float Y;

        public static void medallionFile_checklines()
        {

            foreach (string dues in File.ReadLines(file_name))  //find the thing on the file
            {
                dues.Trim();    //trim the white spaces
                if (dues == string.Empty || dues.StartsWith("//"))
                {
                    continue;
                }

                string[] split_string = dues.Split(':', ',');

                TAG = split_string[0];  //TAG is 0
                ROOM = split_string[1]; //ROOM is 1
                X = float.Parse(split_string[2]);  //X is 2
                Y = float.Parse(split_string[3]);  //Y is 3
                if (float.TryParse(split_string[2], out X) || float.TryParse(split_string[3], out Y))
                {
                    Debug.Log($"X = {X}, Y = {Y}");  //Debug the coordinates
                }
            }
        }

    }
    public class GML_input
    {
        /// <summary>
        /// while you holds the button
        /// </summary>
        /// <param name="key"></param>
        public static bool keyboard_check(KeyCode key)
        {
            return Input.GetKey(key);
        }
        /// <summary>
        /// while you press the button
        /// </summary>
        /// <param name="key"></param>
        public static bool keyboard_check_down(KeyCode key)
        {
            return Input.GetKeyDown(key);
        }
        /// <summary>
        /// while you release the button
        /// </summary>
        /// <param name="key"></param>
        public static bool keyboard_check_up(KeyCode key)
        {
            return Input.GetKeyUp(key);
        }
    }
}