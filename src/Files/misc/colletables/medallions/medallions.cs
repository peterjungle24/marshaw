using System;
using System.IO;
using UnityEngine;
using BepInEx;
using DevInterface;
using static Pom.Pom;
using Helpers;
using BepInEx.Logging;
using System.Collections.Generic;
using image;
using RWCustom;
using marshaw.skill;

namespace Collectables_Misc
{
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
        public PlacedObject obj;  //placed object
        public Vector2 hoverPos;
        public float glitch;
        public float radius;
        public FSprite medallion_sprite_FS;

        public static SlugcatStats.Name marshaw { get => Plugin.Marshaw; }    //name of my slugcat
        public medallion_UAD (Room room, PlacedObject placed_object)
        {
            this.room = room;
            this.obj = placed_object;
        }

        ///...
        public override void Update(bool eu)
        {
            float num5 = 140f;
            float num4 = float.MaxValue;
            bool flag = RainWorld.lockGameTimer;

            radius = 18f;

            if (!flag)
            {
                for (int player_count = 0; player_count < room.game.session.Players.Count; player_count++)
                {
                    if (room.game.session.Players[player_count].realizedCreature != null && room.game.session.Players[player_count].realizedCreature.Consious && (room.game.session.Players[player_count].realizedCreature as Player).dangerGrasp == null && room.game.session.Players[player_count].realizedCreature.room == room)
                    {
                        num4 = Mathf.Min(num4, Vector2.Distance(room.game.session.Players[player_count].realizedCreature.mainBodyChunk.pos, obj.pos));
                        
                        if (Custom.DistLess(room.game.session.Players[player_count].realizedCreature.mainBodyChunk.pos, obj.pos, radius))
                        {
                            Collect(room.game.session.Players[player_count].realizedCreature as Player);
                            break;
                        }
                        if (Custom.DistLess(room.game.session.Players[player_count].realizedCreature.mainBodyChunk.pos, obj.pos, num5))
                        {
                            if (Custom.DistLess(obj.pos, hoverPos, 80f))
                            {
                                obj.pos += Custom.DirVec(obj.pos, room.game.session.Players[player_count].realizedCreature.mainBodyChunk.pos) * Custom.LerpMap(Vector2.Distance(obj.pos, room.game.session.Players[player_count].realizedCreature.mainBodyChunk.pos), 40f, num5, 2.2f, 0f, 0.5f) * UnityEngine.Random.value;
                            }
                            if (UnityEngine.Random.value < 0.05f && UnityEngine.Random.value < Mathf.InverseLerp(num5, 40f, Vector2.Distance(obj.pos, room.game.session.Players[player_count].realizedCreature.mainBodyChunk.pos)))
                            {
                                glitch = Mathf.Max(glitch, UnityEngine.Random.value * 0.5f);
                            }
                        }
                        
                    }
                }
            }
        }

        public override void Destroy()
        {
            medallion_sprite_FS.RemoveFromContainer();
            base.Destroy();
        }

        public void Collect(Player self)
        {
            self.CanSkill().HasDoubleJumpMedallion = true;
            room.PlaySound(SoundID.Token_Collect, obj.pos);
            room.AddObject(new Explosion.ExplosionLight(obj.pos, 120f, 20f, 20, Color.blue));
            room.AddObject(new Explosion.ExplosionLight(obj.pos, 120f, 20f, 20, Color.green));

            Destroy();
        }

        ///IDRAWABLE

        public void InitiateSprites (RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam)
        {
            sLeaser.sprites = new FSprite[1];
            sLeaser.sprites[0] = medallion_sprite_FS = new FSprite(ImageFiles.MedallionPath, true);

            sLeaser.sprites[0].scale = 2.2f;
            sLeaser.sprites[0].color = Color.cyan;

            AddToContainer(sLeaser, rCam, null);
        }
        public void DrawSprites     (RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float Float, Vector2 camPos)
        {
            sLeaser.sprites[0].x = obj.pos.x - rCam.pos.x;
            sLeaser.sprites[0].y = obj.pos.y - rCam.pos.y;
        }
        public void ApplyPalette    (RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, RoomPalette pal)
        {
            Debug.Log("apply palette");
        }
        public void AddToContainer  (RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, FContainer fContainer)
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