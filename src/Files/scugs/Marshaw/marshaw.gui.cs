using BepInEx.Logging;
using System;
using UnityEngine;
using Helpers;
using sanity;

namespace marshaw.gui
{

    public class MarshawGUI
    {

        public static SlugcatStats.Name marshaw { get => Plugin.Marshaw; }

        public static void add_gui_MARSHAW(On.Player.orig_Update orig, Player self, bool eu)
        {
            if (self.slugcatStats.name == marshaw)
            {
                sanity_bar.add_sanityBar(self);
            }
            orig(self, eu);
        }

    }

}