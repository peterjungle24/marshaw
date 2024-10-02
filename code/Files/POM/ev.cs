using BepInEx.Logging;
using CWT;
using DevInterface;
using Helpers;
using Sprites;
using System;
using UnityEngine;
using static Pom.Pom;

namespace ev
{
    public class trigger_enums
    {
        public enum trigger_options
        { 
            once, update
        }
    }
    public class Trigger_data : ManagedData
    {
        //add atributes
        //set the ATRIBUTE and then the FIELD
        [StringField("ID", "A", "Trigger ID")]
        public string ID;

        [BooleanField("AcceptPlayer", false, ManagedFieldWithPanel.ControlType.button, "Accept Players")]
        public bool AcceptPlayer;
        [BooleanField("AcceptCreature", false, ManagedFieldWithPanel.ControlType.button, "Accept Creatures")]
        public bool AcceptCreature;
        [BooleanField("AcceptItem", false, ManagedFieldWithPanel.ControlType.button, "Accept Items")]
        public bool AcceptItem;
        [BooleanField("SlugpupDispenser", false, ManagedFieldWithPanel.ControlType.button, "Slugpup")]
        public bool SlugpupDispenser;

        [EnumField<trigger_enums.trigger_options>("Options", trigger_enums.trigger_options.once, null, ManagedFieldWithPanel.ControlType.arrows, "Options")]
        public trigger_enums.trigger_options options;

        [FloatField("Width", 0f, 500f, 10f, 0.5f)]
        public float Width;
        [FloatField("Heigth", 0f, 500f, 10f, 0.5f)]
        public float Heigth;

        //the custom fields are added as a parameter for the base class
        public Trigger_data(PlacedObject own) : base(own, null)
        {
            this.owner = own;
        }
    }
    public class Trigger : UpdatableAndDeletable, IDrawable
    {
        bool accept_player;
        bool accept_creature;
        bool accept_item;
        delegate void update (Room room, string id, Trigger trigger);
        delegate void once (Room room, string id, Trigger trigger);
        event update Updat;
        event once Once;

        PlacedObject self;
        ColoredRect rect;
        FSprite sprite;
        CollisionBox collider;
        VisualizerRect visual;
        Rect r;

        float x;
        float y;
        float width;
        float heigth;

        ManualLogSource logger { get => Plugin.Logger; }

        public Trigger(Room room, PlacedObject obj)
        {
            this.room = room;
            this.self = obj;

            var data = (Trigger_data)self.data;
            rect = ColoredRect.Create(new Vector2(x, y), width, heigth);

            sprite = rect.Sprite;
            collider = rect.Collision;
        }
        public Trigger()
        {
            rect = new ColoredRect(new Vector2(x, y), width, heigth);
            sprite = rect.Sprite;
        }

        // --------- METHODS
        public void Collide()
        {
            var cwt = room.issue();
            var rcam = this.room.game.cameras[0];

            // the fields are assigned here, more easier and i dont wanna to get they working only one time
            // update is really best place for almost everything.... except creating instances
            accept_player = ((Trigger_data)self.data).GetValue<bool>("AcceptPlayer");
            accept_item = ((Trigger_data)self.data).GetValue<bool>("AcceptItem");
            accept_creature = ((Trigger_data)self.data).GetValue<bool>("AcceptCreature");
            var options = ((Trigger_data)self.data).GetValue<trigger_enums.trigger_options>("Options");

            // room.AddObject(new Explosion.ExplosionLight(players.bodyChunks[1].pos, 120f, 40, 10, Color.green));

            // foreach for everything
            foreach (var all in this.room.physicalObjects)
            {
                foreach (var items in all)
                {
                    #region filter

                    // if it accepts the player
                    if (accept_player)
                    {
                        if (items is Player player)
                        {
                            // if is touching or inside of the ev
                            if (rect.Collision.IntersectsChunk(player.mainBodyChunk, rcam.pos))
                            {
                                if (options == trigger_enums.trigger_options.update)
                                {
                                    Updat?.Invoke(this.room, ( (Trigger_data) self.data ).GetValue<string>("ID"), this);
                                    if (Updat == null)
                                    {
                                        Updat += test;
                                    }
                                }
                            }
                        }
                    }

                    // if it accepts the creature
                    if (accept_creature)
                    {
                        if (items is not Player && items is Creature creature)
                        {
                            if (rect.Collision.IntersectsChunk(creature.mainBodyChunk, rcam.pos))
                            {
                            }
                        }
                    }

                    // if it aceppts the item
                    if (accept_item)
                    {
                        if (items is Weapon || items is PlayerCarryableItem)
                        {
                            if (rect.Collision.IntersectsChunk(items.bodyChunks[0], rcam.pos))
                            {
                            }
                        }
                    }

                    #endregion
                }
            }
        }

        private void test(Room room, string id, Trigger trigger)
        {
            if (id == "id")
            {
                Debug.Log("i dont know.");
            }
        }

        public override void Update(bool eu)
        {
            // calls the update
            base.Update(eu);

            Collide();
        }

        // --------- IDRAWABLE
        public void InitiateSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam)
        {
            // called only once (when initialized)

            sLeaser.sprites = new [] 
            {
                rect.Sprite,
            };
            sLeaser.sprites[0] = rect.Sprite;

            AddToContainer(sLeaser, rCam, null);
        }
        public void DrawSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float Float, Vector2 camPos)
        {
            // called in every frame (update)
            rect = new ColoredRect(new Vector2(sLeaser.sprites[0].x, sLeaser.sprites[0].y), sLeaser.sprites[0].width, sLeaser.sprites[0].height);

            x = self.pos.x - rCam.pos.x;
            y = self.pos.y - rCam.pos.y;

            sLeaser.sprites[0].x = x;
            sLeaser.sprites[0].y = y;
            sLeaser.sprites[0].width = ( (Trigger_data) self.data).GetValue<float>("Width");
            sLeaser.sprites[0].height = ( (Trigger_data) self.data).GetValue<float>("Heigth");
            sLeaser.sprites[0].color = Color.blue;
        }
        public void ApplyPalette(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, RoomPalette pal)
        {

        }
        public void AddToContainer(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, FContainer fContainer)
        {
            fContainer ??= rCam.ReturnFContainer("Foreground");

            foreach (FSprite fsprite in sLeaser.sprites)
            {
                fContainer.AddChild(fsprite);
            }
        }
    }
    public class Trigger_REPR : ManagedRepresentation
    {
        public Trigger_REPR(PlacedObject.Type type, ObjectsPage object_page, PlacedObject placed_object) : base(type, object_page, placed_object)
        {
        }
    }
}