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
using RWCustom;
using AssetBundles;
using marshaw.skill;

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
            ///             MedalType
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
    #region file_manager

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

    #endregion
    #region GML_input
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

    #endregion
    #region crits

    public static class Crits
    {

        /// <summary>
        /// Finds all objects belonging to a room instance at or within a given distance from an origin point
        /// </summary>
        /// <param name="room">The room to check</param>
        /// <param name="origin">The point to compare the distance to</param>
        /// <param name="distanceThreshold">The desired distance to the origin point</param>
        /// <returns>All results that match the specified conditions</returns>
        public static IEnumerable<PhysicalObject> FindObjectsNearby(this Room room, Vector2 origin, float distanceThreshold)
        {
            if (room == null) return new PhysicalObject[0]; //Null data returns an empty set
            return room.GetAllObjects().Where(o => Custom.Dist(origin, o.firstChunk.pos) <= distanceThreshold);
        }

        /// <summary>
        /// Finds all objects belonging to a room instance at or within a given distance from an origin point that are of the type T
        /// </summary>
        /// <param name="room">The room to check</param>
        /// <param name="origin">The point to compare the distance to</param>
        /// <param name="distanceThreshold">The desired distance to the origin point</param>
        /// <returns>All results that match the specified conditions</returns>
        public static IEnumerable<PhysicalObject> FindObjectsNearby<T>(this Room room, Vector2 origin, float distanceThreshold) where T : PhysicalObject
        {
            if (room == null) return new PhysicalObject[0]; //Null data returns an empty set

            return room.GetAllObjects().OfType<T>().Where(o => RWCustom.Custom.Dist(origin, o.firstChunk.pos) <= distanceThreshold);
        }

        /// <summary>
        /// Returns all objects belonging to a room instance
        /// </summary>
        /// <param name="room">The room to check</param>
        public static IEnumerable<PhysicalObject> GetAllObjects(this Room room)
        {
            if (room == null) yield break; //Null data returns an empty set

            for (int m = 0; m < room.physicalObjects.Length; m++)
            {
                for (int n = 0; n < room.physicalObjects[m].Count; n++)
                {
                    yield return room.physicalObjects[m][n]; //Returns the objects one at a time
                }
            }
        }

    }

    #endregion
    #region timer

    public static class timer_manage
    {
        public static List<Timer> TimerRegistered = new();  //current timers
    }

    public class Timer
    {
        public float value_wanted; //The number of ticks to run the stealthTimer for
        public float current_value; //The number of ticks processed since starting the stealthTimer
        public bool is_running => current_value > 0 && !value_reached;  //GET -- Returns.... that
        public bool value_reached => current_value >= value_wanted;     //GET -- Returns.... that

        public bool Shit(bool what)
        {
            return what = value_reached;
        }

        public Timer(float counter)
        {
            value_wanted = counter;
        }

        /// <summary>
        /// start the counter
        /// </summary>
        public void Start()
        {
            current_value = 0f; //resets the stealthTimer

            if (!timer_manage.TimerRegistered.Contains(this))
            {
                timer_manage.TimerRegistered.Add(this);
            }
        }

        /// <summary>
        /// update the stealthTimer numbers
        /// </summary>
        public void Advance()
        {
            current_value++;

            Debug.Log($"Current value:  {current_value}");
        }
        public void Stop()
        {
            //Set fields back to default values
            current_value = 0;

            //Unregister this stealthTimer to prevent future updates
            timer_manage.TimerRegistered.Remove(this);
        }
    }

    #endregion
    #region cost

    public class AbilityCost
    {
        public FSprite sanity_spr { get => sanity_bar.spr_sanity; }
        public SlugcatStats.Name Marshaw { get => Plugin.Marshaw; }

        public static void deal_with_fucking_structs(On.Player.orig_Update orig, Player self, bool eu)
        {
            orig(self, eu);
        }
    }

    #endregion
}