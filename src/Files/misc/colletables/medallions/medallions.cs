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
using System.Runtime.InteropServices;
using CWT;

namespace Collectables_Misc
{
    public static class Medallion
    {
        public static SlugcatStats.Name Marshaw { get => Plugin.Marshaw; }

        public static void add(On.Room.orig_AddObject orig, Room self, UpdatableAndDeletable obj)
        {
            if (self.game != null)
            {
                if (self.game.IsStorySession && self.game.StoryCharacter != Marshaw && obj is DoubleJ_Medallion_UAD)
                {
                    return; //Return early as this collectable should not be drawn for this campaign
                }
            }

            orig(self, obj);
        }
    }

    public class MBase_managedData : ManagedData
    {
        public float glitch;
        public Vector2 hoverPos;
        public FSprite medallion_sprite_FS;
        public PlacedObject obj;  //placed object
        public float radius;
        
        public MBase_managedData(PlacedObject own) : base(own, null)
        {
            Debug.Log("MedallionBase_managedData here");
        }
    }
    public class MBase_UAD : UpdatableAndDeletable
    {
        public float glitch;
        public Vector2 hoverPos;
        public FSprite medallion_sprite_FS;
        public PlacedObject obj;  //placed object
        public float radius;

        public MBase_UAD(Room room, PlacedObject obj)
        {
            this.room = room;
            this.obj = obj;
        }

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
        public virtual void destroy()
        {
            //i can customize the destroy thing
            medallion_sprite_FS.RemoveFromContainer();
            base.Destroy();
        }
        public virtual void Collect(Player self)
        {
            //override it for customize it for each medallion
            destroy();
        }
    }
    public class MBase_REPR : ManagedRepresentation
    {
        public PlacedObject obj;  //placed object

        public MBase_REPR(PlacedObject.Type type, ObjectsPage object_page, PlacedObject placed_object) : base(type, object_page, placed_object)
        {
            placed_object.pos = pos;
        }
    }

    //----------------------Double Jump-------------------------------------
    public class DoubleJ_Medallion_managedData : ManagedData
    {
        public DoubleJ_Medallion_managedData(PlacedObject own) : base(own, null)
        {
        }
    }
    public class DoubleJ_Medallion_UAD : MBase_UAD, IDrawable
    {
        public DoubleJ_Medallion_UAD(Room room, PlacedObject obj) : base(room, obj) { }

        public override void Collect(Player self)
        {
            self.Skill().HasDoubleJumpMedallion = true;
            Room room = self.room;

            room.PlaySound(SoundID.Token_Collect, self.mainBodyChunk.pos);
            room.AddObject(new Explosion.ExplosionLight(self.mainBodyChunk.pos, 30f, 30f, 30, Color.yellow));

            destroy();
        }

        ///IDRAWABLE
        public void InitiateSprites (RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam)
        {
            sLeaser.sprites = new FSprite[1];
            sLeaser.sprites[0] = medallion_sprite_FS = new FSprite(ImageFiles.MedallionPath, true);

            sLeaser.sprites[0].scale = 2.2f;
            sLeaser.sprites[0].color = Color.white;

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
    public class DoubleJ_Medallion_repr : ManagedRepresentation
    {
        public DoubleJ_Medallion_repr(PlacedObject.Type type, ObjectsPage object_page, PlacedObject placed_object) : base(type, object_page, placed_object)
        {
            Debug.Log("Repr created");
            placed_object.pos = this.pos;
        }
    }
    

    //------------------------ Stun ------------------------------------
    public class StunMedallion_manageData : ManagedData
    {
        public StunMedallion_manageData(PlacedObject own) : base(own, null)
        {
        }
    }
    public class StunMedallion_UAD : UpdatableAndDeletable, IDrawable
    {
        public PlacedObject obj;  //placed object
        public Vector2 hoverPos;
        public float glitch;
        public float radius;
        public FSprite medallion_sprite_FS;

        public static SlugcatStats.Name marshaw { get => Plugin.Marshaw; }    //name of my slugcat
        public StunMedallion_UAD(Room room, PlacedObject placed_object)
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
            self.Skill().HasStunMedallion = true;
            room.PlaySound(SoundID.Token_Collect, obj.pos);
            room.AddObject(new Explosion.ExplosionLight(obj.pos, 120f, 20f, 20, Color.blue));
            room.AddObject(new Explosion.ExplosionLight(obj.pos, 120f, 20f, 20, Color.magenta));

            Destroy();
        }

        ///IDRAWABLE

        public static float alpha;

        public void InitiateSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam)
        {
            sLeaser.sprites = new FSprite[1];
            sLeaser.sprites[0] = medallion_sprite_FS = new FSprite(ImageFiles.MedallionPath, true);

            sLeaser.sprites[0].scale = 2.2f;
            sLeaser.sprites[0].color = new Color(0, 150, 255);

            AddToContainer(sLeaser, rCam, null);
        }
        public void DrawSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float Float, Vector2 camPos)
        {
            sLeaser.sprites[0].x = obj.pos.x - rCam.pos.x;
            sLeaser.sprites[0].y = obj.pos.y - rCam.pos.y;
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
    public class StunMedallion_repr : ManagedRepresentation
    {
        public StunMedallion_repr(PlacedObject.Type type, ObjectsPage object_page, PlacedObject placed_object) : base(type, object_page, placed_object)
        {
            Debug.Log("Repr created");
            placed_object.pos = this.pos;
        }
    }

    //------------------------- Swim -----------------------------------

    public class SwimMedallion_manageData : ManagedData
    {
        public SwimMedallion_manageData(PlacedObject own) : base(own, null)
        {
        }
    }
    public class SwimMedallion_UAD : UpdatableAndDeletable, IDrawable
    {
        public PlacedObject obj;  //placed object
        public Vector2 hoverPos;
        public float glitch;
        public float radius;
        public FSprite medallion_sprite_FS;

        public static SlugcatStats.Name marshaw { get => Plugin.Marshaw; }    //name of my slugcat
        public SwimMedallion_UAD(Room room, PlacedObject placed_object)
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
            self.Skill().HasSwimMedallion = true;    //set the SWIM for true
            room.PlaySound(SoundID.Token_Collect, obj.pos); //play the collect sound
            room.AddObject(new Explosion.ExplosionLight(obj.pos, 120f, 20f, 20, Color.blue));
            room.AddObject(new Explosion.ExplosionLight(obj.pos, 120f, 20f, 20, Color.magenta));

            Destroy();  //destroy the object
        }

        ///IDRAWABLE

        public static float alpha;

        public void InitiateSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam)
        {
            sLeaser.sprites = new FSprite[1];
            sLeaser.sprites[0] = medallion_sprite_FS = new FSprite(ImageFiles.MedallionPath, true);

            sLeaser.sprites[0].scale = 2.2f;
            sLeaser.sprites[0].color = Color.blue;

            AddToContainer(sLeaser, rCam, null);
        }
        public void DrawSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float Float, Vector2 camPos)
        {
            sLeaser.sprites[0].x = obj.pos.x - rCam.pos.x;
            sLeaser.sprites[0].y = obj.pos.y - rCam.pos.y;
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
    public class SwimMedallion_repr : ManagedRepresentation
    {
        public SwimMedallion_repr(PlacedObject.Type type, ObjectsPage object_page, PlacedObject placed_object) : base(type, object_page, placed_object)
        {
            Debug.Log("Repr created");
            placed_object.pos = this.pos;
        }
    }

    //-------------------------- Stealth ----------------------------------

    public class StealthMedallion_manageData : ManagedData
    {
        public StealthMedallion_manageData(PlacedObject own) : base(own, null)
        {
        }
    }
    public class StealthMedallion_UAD : UpdatableAndDeletable, IDrawable
    {
        public PlacedObject obj;  //placed object
        public Vector2 hoverPos;
        public float glitch;
        public float radius;
        public FSprite medallion_sprite_FS;

        public static SlugcatStats.Name marshaw { get => Plugin.Marshaw; }    //name of my slugcat
        public StealthMedallion_UAD(Room room, PlacedObject placed_object)
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
            self.Skill().HasStealthMedallion = true;    //set the SWIM for true
            room.PlaySound(SoundID.Token_Collect, obj.pos); //play the collect sound
            room.AddObject(new Explosion.ExplosionLight(obj.pos, 120f, 20f, 20, Color.blue));
            room.AddObject(new Explosion.ExplosionLight(obj.pos, 120f, 20f, 20, Color.magenta));

            Destroy();  //destroy the object
        }

        ///IDRAWABLE

        public static float alpha;

        public void InitiateSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam)
        {
            sLeaser.sprites = new FSprite[1];
            sLeaser.sprites[0] = medallion_sprite_FS = new FSprite(ImageFiles.MedallionPath, true);

            sLeaser.sprites[0].scale = 2.2f;
            sLeaser.sprites[0].color = new Color(40, 40, 40);

            AddToContainer(sLeaser, rCam, null);
        }
        public void DrawSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float Float, Vector2 camPos)
        {
            sLeaser.sprites[0].x = obj.pos.x - rCam.pos.x;
            sLeaser.sprites[0].y = obj.pos.y - rCam.pos.y;
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
    public class StealthMedallion_repr : ManagedRepresentation
    {
        public StealthMedallion_repr(PlacedObject.Type type, ObjectsPage object_page, PlacedObject placed_object) : base(type, object_page, placed_object)
        {
            Debug.Log("Repr created");
            placed_object.pos = this.pos;
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

public class DoubleJ_Medallion_managedData : ManagedData
{

    public string stun)skill;

    public DoubleJ_Medallion_managedData(PlacedObject own) : base(own, null)
    {

    }
}

public class DoubleJ_Medallion_UAD : UpdatableAndDeletable
{
    public DoubleJ_Medallion_UAD(Room room, PlacedObject placed_object)
    {
    }
}

public class DoubleJ_Medallion_repr : ManagedRepresentation
{
    public DoubleJ_Medallion_repr(PlacedObject.MedalType type, ObjectsPage object_page, PlacedObject placed_object) : base(type, object_page, placed_object)
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