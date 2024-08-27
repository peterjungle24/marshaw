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
using CWT;
using System.Data;

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
            const float def = 0.0005f;  //Default Svalue.
            const float friendly_regen = 0.0035f;   //Sanity change may be positive or negative

            if (crit == null)
            {

                return def;

            }

            //....i think i already defined
            var crit_type = crit.type;                  //type
            var crit_ancestor = crit.ancestor;     //ancestors
            float value;                                //Svalue

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

                return -friendly_regen; //creature restores sanity of _player when it is nearby

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

                    return -friendly_regen; //creature restores sanity of _player when it is nearby

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
            if (room == null) return new PhysicalObject[0]; //Null data returns an critical set
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
            if (room == null) return new PhysicalObject[0]; //Null data returns an critical set

            return room.GetAllObjects().OfType<T>().Where(o => RWCustom.Custom.Dist(origin, o.firstChunk.pos) <= distanceThreshold);
        }
        /// <summary>
        /// Returns all objects belonging to a room instance
        /// </summary>
        /// <param name="room">The room to check</param>
        public static IEnumerable<PhysicalObject> GetAllObjects(this Room room)
        {
            if (room == null) yield break; //Null data returns an critical set

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
        public static bool test_bool;

        public static void ApplyHooks()
        {
            foreach (var timer in timer_manage.TimerRegistered)
            {
                timer.Advance();

                //if the current Svalue is same as value_wanted, it restart
                if (timer.current_value >= timer.value_wanted)
                {
                    test_bool = true;
                }
            }

            TimerRegistered.RemoveAll(t => t.value_reached); //Cleanup
        }

        public static List<Timer> TimerRegistered = new();  //current timers
    }

    public class Timer
    {
        public float value_wanted;  //The number of ticks to run the stealthTimer for
        public float current_value; //The number of ticks processed since starting the stealthTimer
        public bool continuous;

        public bool is_running => current_value > 0 && !value_reached;  //checks if is running
        public virtual bool value_reached => !continuous && current_value >= value_wanted;  //if is not continuous, and math.
        public bool is_equal => current_value == value_wanted;

        public Timer(float counter)
        {
            value_wanted = counter;
        }
        public Timer()
        {

        }

        public void Start()
        {
            current_value = 0f; //resets the stealthTimer

            if (!timer_manage.TimerRegistered.Contains(this))
            {
                timer_manage.TimerRegistered.Add(this);
            }
        }
        public virtual void Advance()
        {
            current_value++;
        }
        public void Stop()
        {
            //Set fields back to default values
            current_value = 0;

            //Unregister this stealthTimer to prevent future updates
            timer_manage.TimerRegistered.Remove(this);
        }
    }
    /// <summary>
    /// Makes a interval for the endless Update frames.
    /// </summary>
    public class FlagTimer : Timer
    {
        //timer_limit is unnecessary

        public int interval;            //A timer that sets a flag every time an interval period is reached
        public bool interval_reached;   //when the interval is reached

        public FlagTimer(int interval, int timer_limit) : base(timer_limit)
        {
            Debug.Log("Ctor 0 from FlagTimer");
            this.interval = interval;
            this.continuous = true; //sets the continuous to True

            if (interval == 0f)
            {
                Debug.Log("Interval was 0");
                throw new ArgumentException("Interval cannot be zero");
            }
            Debug.Log(this.interval);
        }
        public FlagTimer(int interval) : this(interval, 0)
        {
            this.interval = interval;
            Debug.Log("Ctor 1 from FlagTimer");
            Debug.Log(this.interval);
        }

        public override void Advance()
        {
            base.Advance(); //calls the original method
        }
    }

    #endregion
    #region gui

    public class GUI
    {
        /// <summary>
        /// draws text
        /// </summary>
        /// <param name="text">your text will appear here</param>
        /// <param name="position">a position of your text</param>
        /// <param name="rCam">the rCam, for getting it working</param>
        /// <param name="layer">a layer for set it. Is optional. Is recommended to know the list of layers</param>
        public static void draw_text(string text, Vector2 position, RoomCamera rCam, string layer = "GUI")
        {
            FLabel label = new(RWCustom.Custom.GetDisplayFont(), text); // creates a text
            rCam.ReturnFContainer(layer).AddChild(label);    // adds the text in the specified (or GUI) layer
            label.x = position.x;   // set the X position
            label.y = position.y;   // set the Y position
        }
    }

    #endregion
}