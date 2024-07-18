using System;
using RWCustom;
using BepInEx;
using UnityEngine;
using Helpers;
using Menu.Remix.MixedUI;
using Menu;

namespace remix_menu
{

    public class Remix : OptionInterface
    {
        public override void Initialize()
        {

            Tabs = new OpTab[]
            {
                new(this, Translate("Slugg")),
                new(this, Translate("Marshaw")),
            };

            var wtf = config.Bind("KEY", true, new ConfigurableInfo("disable/enable the death sounds for all the slugcats", null, "", new object[]
            {
                //call function here?
                "tag test"  //and why tags?
            }));

            UIelement[] Tab0_Array = new UIelement[]        //array of elements
            {
                new OpLabel(10f, 550f, "Cosmetic ones", true),      //creates a big text
                new OpCheckBox(wtf, new Vector2(10f, 480))
                {
                    description = wtf.info.description,
                    colorEdge = Color.yellow,
                },
                new OpLabel(60f, 480f, Translate("Enable the Death Random Sounds for all the slugcats")),
            };

            UIelement[] Tab1_Array = new UIelement[]        //array of elements
            {
                new OpLabel(10f, 550f, "Cosmetic ones", true),      //creates a big text
            };

            Tabs[0].AddItems(Tab0_Array); //adds the elemebt to the tab
            Tabs[1].AddItems(Tab1_Array); //adds the elemebt to the tab
        }

    }

}