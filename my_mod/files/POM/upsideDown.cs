using BepInEx.Logging;
using CWT;
using DevInterface;
using welp;
using Sprites;
using System;
using UnityEngine;
using static Pom.Pom;

namespace ev
{
    public class UpsideDown_Data : ManagedData
    {
        [BooleanField("inverts", false, ManagedFieldWithPanel.ControlType.button, "Slugpup")]
        public bool inverts;

        //the custom fields are added as a parameter for the base class
        public UpsideDown_Data(PlacedObject own) : base(own, null)
        {
            this.owner = own;
        }
    }
    public class UpsideDown : UpdatableAndDeletable
    {
        PlacedObject self;
        ManualLogSource logger { get => Plugin.Logger; }

        public UpsideDown(Room room, PlacedObject obj)
        {
            this.room = room;
            this.self = obj;
        }

        public override void Update(bool eu)
        {
            InvertGravity();

            base.Update(eu);
        }

        void InvertGravity()
        {
            var t = ((UpsideDown_Data)self.data).GetValue<bool>("inverts");

            if (t == true)
            {
                this.room.gravity = -1f;
            }
            else
            {
                this.room.gravity = 1f;
            }
        }
    }
    public class UpsideDown_REPR : ManagedRepresentation
    {
        public UpsideDown_REPR(PlacedObject.Type type, ObjectsPage object_page, PlacedObject placed_object) : base(type, object_page, placed_object)
        {
        }
    }
}