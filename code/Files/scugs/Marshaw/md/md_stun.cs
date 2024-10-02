using CWT;
using Helpers;

namespace medals
{
    internal class md_stun
    {
        public static void stun_hooks()
        {
            On.Player.Update += stun_skill;     // [ STUN ] stuns all the creatures in a specific radius
        }

        #region stun_skill

        public static void stun_skill(On.Player.orig_Update orig, Player self, bool eu)
        {
            var room = self.room;
            var cwt = self.Skill();
            var i = self.input;

            if (cwt.HasStunMedallion == true)   //if the scug have medallion
            {
                foreach (Creature c in room.FindObjectsNearby<Creature>(self.mainBodyChunk.pos, 200f))  //checks for the distance
                {
                    if (i[0].thrw && i[1].thrw && i[0].y == 1)  //if its pressing some inputs
                    {
                        c.Stun(100);  //stuns
                    }
                }
            }

            orig(self, eu);
        }

        #endregion
    }
}