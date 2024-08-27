using BepInEx.Logging;
using System;
using UnityEngine;
using Helpers;
using sanity;
using shader_manage;

namespace marshaw.gui
{
    public class MarshawGUI
    {
        public static SlugcatStats.Name marshaw { get => Plugin.Marshaw; }

        public static void add_gui_elements(On.Player.orig_Update orig, Player self, bool eu)
        {

            if (self.slugcatStats.name == marshaw)
            {
                sanity.sanity_bar.sanityBar_add(self);
            }
            cooldown_bar.cooldownBar_Add(self.room.game.cameras[0], self);

            orig(self, eu);
        }

    }

}