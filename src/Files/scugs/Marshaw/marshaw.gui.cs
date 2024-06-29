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
                shader_manage.no_idea_bar.noIdea_add(self.room.game.cameras[0]);  //add a No Idea bar
                sanity_bar.add_sanityBar(self);
            }
            orig(self, eu);
        }

    }

}