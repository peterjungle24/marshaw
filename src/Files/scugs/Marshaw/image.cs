using System;
using UnityEngine;
using System.IO;
using Helpers;

namespace image
{

    //get ready for a lot of lines :3
    // [ init ]  means the #region that have a hook for initialize the Sprite
    // [ usage ] means the #region that have a hook for use the Sprite


    /// <summary>
    /// class for load and put this image to Background
    /// </summary>
    public static class mBack_spr
    {

        public static string mBack;                     //[ field ] contains the path of a file_check.

        #region int

        //the REAL start of the image...
        public static void spr_mBack_int(On.RainWorld.orig_OnModsInit orig, RainWorld self)
        {
            orig(self);     //call the orig before of all
            mBack = Path.Combine("sprites","test", "spr_mBack");
        }
        #endregion
        #region usage
        
        //the start of the image...
        public static void mBack_bk(On.RoomCamera.orig_ChangeMainPalette orig, RoomCamera self, int palA)
        {

            FSprite FS_mBack = new FSprite(mBack);   //variable for the FSprite. i hate Atlas for real

            self.ReturnFContainer("Shadows").AddChild(FS_mBack);    //çet you add this element to the container
            self.currentPalette.skyColor = Color.yellow;    //initialize_mod_hook_when_the_mod_is_initialized_nice
            self.FadeToPalette(10, true, 10);   //put here
            FS_mBack.y = 386;   // X
            FS_mBack.x = 683;   // Y
            
            //if you doesnt uderstood what X or Y means, go learn 2D Coordinates

            orig(self, palA);

        }

        #endregion

    }
    
}