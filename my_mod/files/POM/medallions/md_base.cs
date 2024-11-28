using CWT;
using DevInterface;
using welp;
using MoreSlugcats;
using RWCustom;
using UnityEngine;
using static Pom.Pom;

namespace p.medallion
{
    public class Medallion
    {
        public static SlugcatStats.Name Marshaw { get => Plugin.Marshaw; }
        public static FAtlas aqua_medallion_file;
        public static FAtlas thunder_medallion_file;
        public static FAtlas fire_medallion_file;
        public static FAtlas stealth_medallion_file;
        public static FAtlas wind_medallion_file;
        public static FAtlas clone_medallion_file;

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
        public static void medal_POM()
        {
            string sl_objects = "Slugg object";

            // medallions
            RegisterManagedObject<DoubleJ_Medallion_UAD, DoubleJ_Medallion_managedData, DoubleJ_Medallion_repr>("Double Jump Medallion", sl_objects, false);
            RegisterManagedObject<ThunderMedallion_UAD, ThunderMedallion_manageData, ThunderMedallion_repr>("Stun Medallion", sl_objects, false);
            RegisterManagedObject<AquaMedallion_UAD, AquaMedallion_manageData, AquaMedallion_repr>("Aqua Medallion", sl_objects, false);
            RegisterManagedObject<StealthMedallion_UAD, StealthMedallion_manageData, StealthMedallion_repr>("Stealth Medallion", sl_objects, false);
            RegisterManagedObject<FireMedallion_UAD, FireMedallion_manageData, FireMedallion_repr>("Fire Medallion", sl_objects, false);
        }
        public static void medal_init()
        {
            //LOAD IMAGES
            aqua_medallion_file     = Futile.atlasManager.LoadImage( PathHelp.GetMedallionFile("aqua_medallion") );
            thunder_medallion_file  = Futile.atlasManager.LoadImage( PathHelp.GetMedallionFile("thunder_medallion") );
            fire_medallion_file     = Futile.atlasManager.LoadImage( PathHelp.GetMedallionFile("fire_medallion") );
            clone_medallion_file    = Futile.atlasManager.LoadImage( PathHelp.GetMedallionFile("clone_medallion") );
            stealth_medallion_file  = Futile.atlasManager.LoadImage( PathHelp.GetMedallionFile("stealth_medallion") );
            wind_medallion_file     = Futile.atlasManager.LoadImage( PathHelp.GetMedallionFile("wind_medallion") );
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
        public float radius;
        public PlacedObject obj;  //placed object

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
        private void Collect(Player self)
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
    sLeaser.sprites[0].field_x = camPos.field_x;
    sLeaser.sprites[0].field_y = camPos.field_y;

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