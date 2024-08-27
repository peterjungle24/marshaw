using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx;
using DevInterface;
using JetBrains.Annotations;
using UnityEngine;
using RWCustom;
using static Pom.Pom;
using System.Diagnostics;
using Helpers;

namespace ev
{
    public class ev_trigger_managedData : ManagedData
    {
        public ev_trigger_managedData(PlacedObject own) : base(own, null)
        {
        }
    }
    public class ev_trigger : UpdatableAndDeletable, IDrawable
    {
        public delegate void del();                 //a FUCKING delegate for events.
        public del what;                            //a event for subscribe
        public trigger_ways trigger_way;            //for compare the other enum thingas (trigger ways)
        public trigger_options trigger_condition;   //for compare the other enum thingas (trigger options)

        public static PlacedObject _self;           //its literally this self of this class
        public static float DISTANCE;               //Done! This FUCKING RIGHT TERM THAT DOEsNT CONFUSES NOBODY its here for save us
        public static float scale;                  //scale
        public static float width;                  //width
        public static float heigth;                 //height

        public static Timer continuous_timer;

        public PlacedObject self { get => _self; set => _self = value; }    //a non static "self" for use it from a static "_self" 
        public float SCALE { get => scale; set => scale = value; }

        public ev_trigger(Room room, PlacedObject obj)
        {
            this.room = room;   //set the room to room
            this.self = obj;    //set the placed object to placed object
            this.SCALE = 10f;   //sets the default scale.... for now

            UnityEngine.Debug.Log("the 'ctor' has been instantied");
        }
        public ev_trigger()
        {
            //i just made that for instantiate it :)
        }

        [Flags]
        public enum trigger_ways
        {
            none = 0,       //when is none.
            creature = 1,   //when will affect only creatures
            player = 2,     //when will affect only players
            item = 4,       //when will affect only items
        }
        public enum trigger_options
        {
            none,       //if is None, throws a excreption, bc it WONT be "none"
            single,     //when the trigger will be triggered only once
            continuous, //called ALMOST each frame, similar to "Update"
        }

        public bool active;

        public override void Update(bool eu)
        {
            if (is_colliding == true)
            {
                active = true;

                if (trigger_condition == trigger_options.none)
                {
                    
                }
                else if (trigger_condition == trigger_options.continuous)
                {
                    //continuous_timer = new(0);
                }
                else if (trigger_condition == trigger_options.single)
                {

                }

                trigger_condition = trigger_options.single;
            }
            active = false;
        }
        /// <summary>
        /// a event for when you touchs on the trigger  
        /// here will be the events
        /// </summary>
        public static void trigger()
        {
        }

        public static bool is_colliding;

        public void collider(object obj)
        {
            if (obj is Player)
            {
                trigger_way = trigger_ways.player;
            }
            else if (obj is Creature)
            {
                trigger_way = trigger_ways.creature;
            }
            else if (obj is PhysicalObject)
            {
                trigger_way = trigger_ways.item;
            }
            else
            {
                trigger_way = trigger_ways.none;
            }
        }

        /*--------------------------------------------------------\
        |                        IDRAWABLE                        |
        \--------------------------------------------------------*/

        public void InitiateSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam)
        {
            sLeaser.sprites = new FSprite[1];
            sLeaser.sprites[0] = new FSprite("Futile_White", true);

            sLeaser.sprites[0].color = Color.grey;
            sLeaser.sprites[0].shader = rCam.game.rainWorld.Shaders["Basic"];

            AddToContainer(sLeaser, rCam, null);
        }
        public void DrawSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float Float, Vector2 camPos)
        {
            sLeaser.sprites[0].x = self.pos.x - rCam.pos.x;     //X position
            sLeaser.sprites[0].y = self.pos.y - rCam.pos.y;     //Y position
            sLeaser.sprites[0].scale = scale;

            //sLeaser.sprites[0].width = width;
            //sLeaser.sprites[0].height = heigth;

            DISTANCE = sLeaser.sprites[0].width / 2;
        }
        public void ApplyPalette(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, RoomPalette pal)
        {

        }
        public void AddToContainer(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, FContainer fContainer)
        {
            fContainer ??= rCam.ReturnFContainer("HUD");

            foreach (FSprite fsprite in sLeaser.sprites)
            {
                fContainer.AddChild(fsprite);
            }
        }
    }

    public class ev_trigger_REPR : ManagedRepresentation
    {
        public ev_trigger_REPR(PlacedObject.Type type, ObjectsPage object_page, PlacedObject placed_object) : base(type, object_page, placed_object)
        {
        }
    }
}