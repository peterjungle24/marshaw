using UnityEngine;

namespace marshaw.gui
{

    #region Sanity

    //class for the sanity bar.
    public static class sanity_bar
    {

        public static readonly SlugcatStats.Name marshaw = new SlugcatStats.Name("marshaw");    //name of my slugcat

        #region SanityActive

        public static void SanityActive(On.Player.orig_Update orig, Player self, bool eu)
        {

            if (self.slugcatStats.name == marshaw)                                              //check if the slugcat its Marshwawwww
            {

                shader_manage.shader_col.s_literally_circles(self.room.game.cameras[0], self);            //draw the bar and the circles

                float alphaFactor = 0.02f;                                                      //the float consumes/desconsumes

                if (Input.GetKey(KeyCode.W))                                                    //increase
                {

                    shader_manage.shader_col.f_sprite.alpha += alphaFactor;

                }
                if (Input.GetKey(KeyCode.S))                                                    //decrease
                {

                    shader_manage.shader_col.f_sprite.alpha -= alphaFactor;

                }

            }

            orig(self, eu);

        }

        #endregion

    }

    #endregion

}