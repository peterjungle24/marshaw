using BepInEx.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Sprites
{
    public static class CollisionTest
    {
        public static VisualizerRect spriteRect = VisualizerRect.Create(new Vector2(300, 300), 100, 250);
        public static VisualizerRect spriteRectB = VisualizerRect.Create(new Vector2(450, 200), 80, 80);

        public static void TestRectTriggers(RoomCamera self, Player player)
        {
            Vector2 camOffset = self.pos; //Camera offset adjustment appears to be required for accurate collision detection

            BodyChunk mainChunk = player.mainBodyChunk;
            Vector2 pos = mainChunk.pos - camOffset;

            spriteRectB.BaseColor = Color.red;

            spriteRect.AddSpritesToCamera(self);
            spriteRectB.AddSpritesToCamera(self);

            //A list is easier to work with when you have multiple collisions to check
            List<CollisionBox> collisionAreas = new List<CollisionBox>()
            {
                spriteRect.Collision,
                spriteRectB.Collision
            };

            foreach (var area in collisionAreas)
            {
                if (area.IntersectsChunk(mainChunk, camOffset))
                {
                    //Debug.Log("CHUNK POS: " + pos + " CHUNK RADIUS: " + mainChunk.rad);

                    // creates the effect when inside the rect
                    player.room.AddObject(new Explosion.ExplosionLight(player.bodyChunks[1].pos, 120f, 40, 10, Color.green));
                }

                //Debug.Log("RECT: " + area);
            }
        }
    }
}
