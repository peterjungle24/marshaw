using CWT;
using MoreSlugcats;

namespace medals
{
    internal class md_aqua
    {
        public static SlugcatStats.Name Marshaw { get => welp.Plugin.Marshaw; }
        public static SlugcatStats.Name slugg { get => welp.Plugin.slugg; }

        public static void aqua_hooks()
        {
            On.Player.Update += AquaUpdate;     // [ AQUA ] lets you breath more on the aqua (EXCEPT RIVULET)
        }

        #region aqua
        public static void AquaUpdate(On.Player.orig_Update orig, Player self, bool eu)
        {
            ///TO DO: breathe more in the water
            var cwt = self.Skill();

            if (cwt.HasAquaMedallion)
            {
                /// VANILLA
                if (self.slugcatStats.name == SlugcatStats.Name.Yellow ||
                    self.slugcatStats.name == SlugcatStats.Name.White ||
                    self.slugcatStats.name == SlugcatStats.Name.Red)
                {
                    cwt.AppliedLungFactor = 0.50f;
                }

                /// MSC (i can't use a switch here bc it needs to be a constant Svalue and is imcompatible)
                else if (self.slugcatStats.name == MoreSlugcatsEnums.SlugcatStatsName.Spear ||
                    self.slugcatStats.name == MoreSlugcatsEnums.SlugcatStatsName.Gourmand)
                {
                    cwt.AppliedLungFactor = 0.75f;
                }

                else if (self.slugcatStats.name == MoreSlugcatsEnums.SlugcatStatsName.Saint ||
                    self.slugcatStats.name == MoreSlugcatsEnums.SlugcatStatsName.Sofanthiel ||
                    self.slugcatStats.name == MoreSlugcatsEnums.SlugcatStatsName.Slugpup)
                {
                    cwt.AppliedLungFactor = 0.60f;
                }

                /// MY MODDED ONES
                else if (self.slugcatStats.name == Marshaw)
                {
                    cwt.AppliedLungFactor = 0.90f;
                }
                else if (self.slugcatStats.name == slugg)
                {
                    cwt.AppliedLungFactor = 0.70f;
                }

                self.slugcatStats.lungsFac = cwt.AppliedLungFactor;
            }

            orig(self, eu);
        }
        #endregion
    }
}
