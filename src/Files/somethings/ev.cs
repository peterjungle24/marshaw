using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx;
using DevInterface;
using JetBrains.Annotations;
using UnityEngine;
using RWCustom;
using static Pom.Pom;

namespace ev
{
    public class ev_trigger : UpdatableAndDeletable, IDrawable
    {
        public Vector2 pos;
        public delegate void del();
        public del what;

        public ev_trigger(Room room)
        {
            this.room = room;
        }

        [Flags]
        //you know, i know NOTHING about Binaries
        public enum TriggerWays
        {
            None = 0,
            Creature = 1,
            Player = 2,
            Item = 4,
        }

        public override void Update(bool eu)
        {
            float radius = 18f; //radius
            var players = room.game.session.Players;
            var position = this.pos;

            //get the players
            for (int player_count = 0; player_count < players.Count; player_count++)
            {
                //if this distance is true
                if (Custom.DistLess(players[player_count].realizedCreature.mainBodyChunk.pos, pos, radius))
                {
                    //triggers when touch
                    Trigger(players[player_count].realizedCreature as Player);
                    break;
                }
            }
        }
        public void Trigger(Player self)
        {
            Debug.Log("check the trigger work");
        }

        /*---------------------------------------------------------
         |                       IDRAWABLE                        |
         --------------------------------------------------------*/

        public void InitiateSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam)
        {
        
        }
        public void DrawSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float Float, Vector2 camPos)
        {
        
        }
        public void ApplyPalette(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, RoomPalette pal)
        { }
        public void AddToContainer(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, FContainer fContainer)
        { }

    }
}