using BepInEx.Logging;
using Music;
using Helpers;
using System;
using System.Collections.Generic;
using thing_storage;
using UnityEngine;

namespace sanity
{

    ///class for the sanity bar.
    public static class sanity_bar
    {

        public static SlugcatStats.Name marshaw { get => Plugin.Marshaw; }    //name of my slugcat
        public static ManualLogSource Logger { get => Plugin.Logger; }
        public static Dictionary<CreatureTemplate.Type, float> crit_dict { get => dict_storage.crit_dict; }
        public static List<CreatureTemplate.Type> friendly_creature_types { get => list_storage.friendly_creature_types; }

        public static float lastThreat = 0f;  //last threat;

        #region SanityActive

        public static void add_sanityBar(Player self)
        {
            if (self.slugcatStats.name == marshaw)                                              //check if the slugcat its Marshwawwww
            {
                shader_manage.sanity_bar.sanityBar_add(self.room.game.cameras[0], self);        //draw the bar and the circles
                float alphaFactor = 0.02f;                                                      //the float consumes/desconsumes

                if (Input.GetKey(KeyCode.W))                                                    //increase
                {
                    shader_manage.sanity_bar.sanity_fSprite.alpha += alphaFactor;
                    shader_manage.no_idea_bar.no_idea_FSprite.alpha -= alphaFactor;
                }
                if (Input.GetKey(KeyCode.S))                                                    //decrease
                {
                    shader_manage.sanity_bar.sanity_fSprite.alpha -= alphaFactor;
                    shader_manage.no_idea_bar.no_idea_FSprite.alpha += alphaFactor;
                }
            }
        }

        #endregion

        #region crit_dict_values

        /// <summary>
        /// Dictionary crit_dict_values.
        /// </summary>
        public static void crit_dict_values()
        {

            //hmmmm
            /// - check the dictionary to get a valid value from it.
            /// - otherwise you check if it's in the friendly list.
            /// - any other situation, you apply the default


            // Dict

            crit_dict[CreatureTemplate.Type.Scavenger] = 0.0035f;
            crit_dict[CreatureTemplate.Type.LizardTemplate] = 0.0022f;
            crit_dict[CreatureTemplate.Type.Vulture] = 0.0025f;
            crit_dict[CreatureTemplate.Type.Centipede] = 0.0040f;
            crit_dict[CreatureTemplate.Type.PoleMimic] = 0.0015f;
            crit_dict[CreatureTemplate.Type.Centiwing] = 0.0045f;
            crit_dict[CreatureTemplate.Type.SmallCentipede] = 0.0020f;
            crit_dict[CreatureTemplate.Type.RedCentipede] = 0.0050f;

            // List

            friendly_creature_types.Add(CreatureTemplate.Type.Fly);
            friendly_creature_types.Add(CreatureTemplate.Type.CicadaA);
            friendly_creature_types.Add(CreatureTemplate.Type.CicadaB);

        }

        #endregion
        #region sanity_calc

        /// <summary>
        /// Calculate the Sanity distance. wow
        /// </summary>
        /// <param name="self"></param>
        public static void sanity_calc(Player self)
        {

            //shader_manage.sanity_bar.f_dessanity.alpha += num;
            float accumulative = 0f;    //amout of accumulative value.
            Room room = self.room;

            foreach (var list in self.room.physicalObjects)
            {
                foreach (PhysicalObject obj in list)
                {
                    if (obj != self && obj is Creature creature)
                    {

                        var template = creature.Template.type;  //template.
                        var ancestor = creature.Template.ancestor;  //ancestor

                        var dist = (creature.mainBodyChunk.pos - self.mainBodyChunk.pos).magnitude; //Calculates the distance between a creature and the _player

                        if (dist <= 120f)   //if the distance its below than 120f
                        {

                            accumulative += Def_values.get_sanity_value(creature.Template);  //Get the sanity value for this creature

                        }

                    }

                }

            }

            ///------------------------------------------------------
            ////END OF THE FOREACH LOOP
            ///------------------------------------------------------

            bool threat = accumulative > 0;    //if creature its in the distance, will have the [ threat ] flag
            float idwtwton = 0.0015f;
            float timer = 100f;

            shader_manage.sanity_bar.sanity_fSprite.alpha -= accumulative;
            if (!threat)
            {

                if (lastThreat >= timer)
                {

                    shader_manage.sanity_bar.sanity_fSprite.alpha += idwtwton;

                }

                lastThreat += 1f;

            }
            else
            {

                lastThreat = 0f;

            }

            if (shader_manage.sanity_bar.sanity_fSprite.alpha == 0f)
            {

                self.Blink(5);
                self.SaintStagger(5);

            }

        }

        #endregion
        #region reset_sanityBar

        /// <summary>
        /// Resets the sanity bar when the cycle pass..
        /// </summary>
        /// <param name="orig"></param>
        /// <param name="self"></param>
        /// <param name="game"></param>
        /// <param name="survived"></param>
        /// <param name="newMalnourished"></param>
        public static void reset_sanityBar(On.SaveState.orig_SessionEnded orig, SaveState self, RainWorldGame game, bool survived, bool newMalnourished)
        {

            lastThreat = 0f;
            shader_manage.sanity_bar.sanity_fSprite.alpha = 1f;

            orig(self, game, survived, newMalnourished);

        }

        #endregion

    }

}