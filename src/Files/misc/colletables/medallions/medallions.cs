using System;
using System.IO;
using UnityEngine;
using BepInEx;
using DevInterface;
using static Pom.Pom;
using Helpers;
using BepInEx.Logging;
using System.Collections.Generic;

namespace Collectables_Misc
{

    public interface Skills<T>
    {
        public void GetSkills(T skill);
    }


    public class Medallion
    {
        public virtual UnityEngine.Color SpriteColor { get; }
        public virtual FSprite MainSprite { get; }
    }

    public class SwimMedallion : Medallion
    {
    
        public override Color SpriteColor => new(0, 0, 255); 

    }

    //--------------------------------------------------------------
    //                          POM
    //--------------------------------------------------------------

    /// <summary>
    /// ManagedData from POM
    /// </summary>
    public class medallion_managedData : ManagedData
    {
        public static float _x;
        public static float _y;

        public medallion_managedData(PlacedObject own) : base(own, null)
        {
        }
    }

    /// <summary>
    /// UpdatableAndDeletable
    /// </summary>
    public class medallion_UAD : UpdatableAndDeletable, IDrawable
    {
        public static float X { get; set; }
        public static float Y { get; set; }

        public PlacedObject obj;  //placed object
        public static ManualLogSource Logger { get => Plugin.Logger; }

        ///CTOR
        
        public medallion_UAD(Room room, PlacedObject placed_object)
        {
            this.room = room;
            this.obj = placed_object;
        }

        ///IDRAWABLE
        
        public void InitiateSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam)
        {
            sLeaser.sprites = new FSprite[1];
            sLeaser.sprites[0] = new FSprite("Futile_White", true);

            sLeaser.sprites[0].scale = 6f;
            sLeaser.sprites[0].color = Color.green;

            AddToContainer(sLeaser, rCam, null);

            Debug.Log("init sprites");
        }
        public void DrawSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float Float, Vector2 camPos)
        {
            sLeaser.sprites[0].x = obj.pos.x - rCam.pos.x;
            sLeaser.sprites[0].y = obj.pos.y - rCam.pos.y;
            //sLeaser.sprites[0].shader = rCam.game.rainWorld.Shaders["VectorCircle"];
        }
        public void ApplyPalette(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, RoomPalette pal)
        {
            Debug.Log("apply palette");
        }
        public void AddToContainer(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, FContainer fContainer)
        {
            fContainer ??= rCam.ReturnFContainer("Items");

            foreach (FSprite fsprite in sLeaser.sprites)
            {
                fContainer.AddChild(fsprite);
            }
            Debug.Log("add to container");
        }
    }

    /// <summary>
    /// Representation i guess
    /// </summary>
    public class medallion_repr : ManagedRepresentation
    {
        public medallion_repr(PlacedObject.Type type, ObjectsPage object_page, PlacedObject placed_object) : base(type, object_page, placed_object)
        {
            Debug.Log("Repr created");
            placed_object.pos = this.pos;
        }
    }

    /// <summary>
    /// A class for storing PlacedObject data, and associated helper methods
    /// </summary>
    public static class medallion_data
    {
        /// <summary>
        /// PlaceObject.Data objects go here
        /// </summary>
        public static Dictionary<string, PlacedObject.Data> DataObjects = new();

        public static Vector2 pos;

    }


    /// <summary>
    /// a class that inherits the PlacedObject.Data.
    /// </summary>
    public class medallion_placedObjectData : PlacedObject.Data
    {
        public medallion_placedObjectData(PlacedObject own) : base(own)
        {
        }
    }

}

/*  IDrawable


public void InitiateSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam)
{ }
public void DrawSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float Float, Vector2 camPos)
{ }
public void ApplyPalette(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, RoomPalette pal)
{ }
public void AddToContainer(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, FContainer fContainer)
{ }

*/
/*  POM

public class medallion_managedData : ManagedData
{

    public string idk;

    public medallion_managedData(PlacedObject own) : base(own, null)
    {

    }
}

public class medallion_UAD : UpdatableAndDeletable
{
    public medallion_UAD(Room room, PlacedObject placed_object)
    {
    }
}

public class medallion_repr : ManagedRepresentation
{
    public medallion_repr(PlacedObject.Type type, ObjectsPage object_page, PlacedObject placed_object) : base(type, object_page, placed_object)
    {
    }
}

*/
/*  IDrawable - UAD

 ///IDRAWABLE
public void InitiateSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam)
{
    sLeaser.sprites = new FSprite[1];
    sLeaser.sprites[0] = new FSprite("Futile_White", true);

    sLeaser.sprites[0].scale = 10f;

    Debug.Log("init sprites");
    AddToContainer(sLeaser, rCam, null);
}


public void DrawSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float Float, Vector2 camPos)
{
    sLeaser.sprites[0].x = camPos.x;
    sLeaser.sprites[0].y = camPos.y;

    Debug.Log("draw sprites");
}
public void ApplyPalette(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, RoomPalette pal)
{
    Debug.Log("apply palette");
}
public void AddToContainer(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, FContainer fContainer)
{
    fContainer ??= rCam.ReturnFContainer("Items");

    foreach (FSprite fsprite in sLeaser.sprites)
    {
        fContainer.AddChild(fsprite);
    }
    Debug.Log("add to container");
}
  
*/