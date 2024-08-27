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
using BepInEx.Logging;

namespace ev
{
    /*

    Ok so:
        - How to get code to support multiple triggers

    maybe if i create options for it?

    */

    public class ev_trigger_managedData : ManagedData
    {
        //set the ATRIBUTE and then the FIELD
        [StringField("Pedro", "A", "test")]
        public string Pedro;

        [FloatField("Width", 0f, 200f, 1f, 0.5f)]
        public float Width;

        //add fields here
        //you need acess the keys FROM HERE for get the acess
        private static ManagedField[] customFields = new ManagedField[]
        {
            new StringField("pedro", "A", "Pedro"),
            new FloatField("width", 0f, 200f, 1f, 0.5f)
        };

        //the custom fields are added as a parameter for the base class
        public ev_trigger_managedData(PlacedObject own) : base(own, customFields)
        {
            this.owner = own;
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
        public static Rect rect;               //rectangle

        public static Timer continuous_timer;

        public PlacedObject self { get => _self; set => _self = value; }    //a non static "self" for use it from a static "_self" 
        public float SCALE { get => scale; set => scale = value; }
        public static ManualLogSource logger { get => Plugin.Logger; }

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
            logger.LogInfo("ev_trigger initialized");
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
            // fucking TO DO: checks if is colliding for trigger the event, according with the options

            UnityEngine.Debug.Log($"field: {((ManagedData)self.data).GetValue<string>("pedro")}");

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
            sLeaser.sprites[0].width = ((ManagedData)self.data).GetValue<float>("width");

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