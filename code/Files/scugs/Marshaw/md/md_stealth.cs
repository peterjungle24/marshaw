using CWT;
using UnityEngine;

namespace medals
{
    internal class md_stealth
    {
        public static void stealth_hooks()
        {
            On.PlayerGraphics.DrawSprites += stealth_skill;    // [ STEALTH ] adds a Stealth skill and also makes your stealth stealth like a stealth
        }

        #region stealthValues

        public static void stealth_skill(On.PlayerGraphics.orig_DrawSprites orig, PlayerGraphics self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            var player = self.player;    //easier for use the player variable
            var cwt = player.Skill();    //CWT local variable

            if (cwt.HasStealthMedallion == true)    //if they have a medallion
            {
                //logic below:
                if (cwt.stealthTimer == null)  //if its null
                {
                    cwt.stealthTimer = new(151);   //creates a instance with the [float counter] defined
                    cwt.stealthCooldown = new(151); //creates a instance for the cooldown
                    cwt.stealthCooldown.Start();
                }

                if (!cwt.stealthTimer.is_running && cwt.stealthTimerReady && player.input[1].thrw && player.input[0].thrw)   //if this input
                {
                    cwt.stealthTimer.Start();  //start the stealthTimer
                }

                if (cwt.stealthTimer.is_running)
                {
                    for (var i = 0; i < sLeaser.sprites.Length; i++)
                    {
                        sLeaser.sprites[i].alpha -= 0.10f;
                    }
                }
                else
                {
                    for (var i = 0; i < sLeaser.sprites.Length; i++)
                    {
                        sLeaser.sprites[i].alpha += 0.10f;
                    }
                }

                if (cwt.stealthTimer.value_reached)
                {
                    cwt.stealthTimer.Stop();
                    cwt.stealthCooldown.Start();
                }
            }

            orig(self, sLeaser, rCam, timeStacker, camPos);
        }

        #endregion
    }
}
