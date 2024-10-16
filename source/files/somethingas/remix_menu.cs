using System;
using System.Collections.Generic;
using RWCustom;
using BepInEx;
using UnityEngine;
using welp;
using Menu.Remix.MixedUI;
using Menu;

namespace remix_menu
{
    public class slugg_options : OptionInterface
    {
        public static Configurable<bool> cb_deathNoises;   //IS STATIC
        public static bool initialized; //if was initialized

        public slugg_options()
        {
            //checkbox
            cb_deathNoises = config.Bind("cb_deathNoises", true, new ConfigurableInfo(Translate("disable/enable the death sounds for all the slugcats"), null, "", new object[] { }));
        }

        public override void Initialize()
        {
            try
            {
                base.Initialize();
                
                Debug.Log($"--------- {this} is initialized now. --------- ");

                Tabs = new OpTab[]
                {
                    new OpTab(this, Translate("Slugg"))
                    {
                        colorCanvas = Color.yellow
                    }
                };

                UIelement[] Tab0_Array = new UIelement[]        //array of elements
                {
                    new OpLabel(10f, 550f, Translate("Cosmetic ones"), true),       //creates a big text
                    new OpCheckBox(cb_deathNoises, new Vector2(10f, 480))                      //creates a checkbox....
                    {
                        description = cb_deathNoises.info.description,
                        colorEdge = Color.yellow,
                    },
                    new OpLabel(60f, 480f, Translate("Enable the Death Random Sounds for all the slugcats")),   //creats a text
                };

                Tabs[0].AddItems(Tab0_Array); //adds the elements to the tab [ SLUGG ]
            }
            catch (Exception eu)
            {
                Debug.Log($">: Marshaw/SluggOptions/Initialize :<");
                Debug.Log(eu);

                //nah
                //i remember i deleted somethings about
                //none of excreption
            }
        }
    }
    
    public static class Static
    {
        public static void Method(bool nonstatic_variable_in_a_static_way)
        {
        }
    }
}