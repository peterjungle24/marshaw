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

        public static string mBack;                     //[ field ] contains the path of a file.

        #region int

        //the REAL start of the image...
        public static void spr_mBack_int(On.RainWorld.orig_OnModsInit orig, RainWorld self)
        {

            orig(self);                                                                                             //call the orig before of all
            mBack = Path.Combine("sprites", "backs", "spr_mback");                                              //a string variable for specify the path. WAS A HELL FOR THIS IMAGE WORK

            try                                                                                                     //if it works
            {


                Futile.atlasManager.LoadImage(mBack);                                                               //ATLAS FUCKING this in image the load [ read in other way ]

                if (Futile.atlasManager.DoesContainElementWithName(mBack))                                          // if was registered
                {

                    Debug.Log("PNG Actived; ------------------------------------------------------------------");   // log

                }

            }
            catch (Exception cu)                                                                                    //if it doesnt work
            {

                string assetPath = AssetManager.ResolveFilePath(mBack + ".png");                                     //string about the image for the Exception

                if (!File.Exists(assetPath))                                                                        //if the file doesnt existe
                {

                    Plugin.Logger.LogError("KarmaBFile could not be found at path " + assetPath);                   //loggers poggers

                }

                Plugin.Logger.LogError(cu);                                                                         //i placed this thing for just prevent problems :3 (useless or no, i will keep)

            }

        }

        #endregion
        #region usage
        
        //the start of the image...
        public static void mBack_bk(On.RoomCamera.orig_ChangeMainPalette orig, RoomCamera self, int palA)
        {

            FSprite FS_mBack = new FSprite(mBack);                                                          //variable for the FSprite. i hate Atlas for real

            FAtlasElement FE_mBack = Futile.atlasManager.GetElementWithName(mBack);                         // just the FE. useless here
           

            Debug.Log("Something related by Palette Issue -----------------");                              // log some problem that bool_something bc i dont remember init_the_mod

            self.currentPalette.skyColor = Color.yellow;                                                    //init_the_mod bool_something why i put that but ok. its useless anyways
            self.FadeToPalette(10, true, 10);                                                               //put here
            self.ReturnFContainer("Shadows").AddChild(FS_mBack);                                            //this really exsit on this hook
            FS_mBack.y = 386;                                                                               // X
            FS_mBack.x = 683;                                                                               // Y
                                                                                                            //if you doesnt uderstood about [ X/Y ] above, go study 2D Coordinates
            FS_mBack.alpha = 0;                                                                             //transparency

            orig(self, palA);

        }

        #endregion

    }
    
}