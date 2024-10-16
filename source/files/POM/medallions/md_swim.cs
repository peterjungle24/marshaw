using CWT;
using DevInterface;
using welp;
using MoreSlugcats;
using RWCustom;
using UnityEngine;
using static Pom.Pom;

namespace p.medallion
{
    //------------------------- Swim -----------------------------------

    public class AquaMedallion_manageData : ManagedData
    {
        public AquaMedallion_manageData(PlacedObject own) : base(own, null)
        {
        }
    }
    public class AquaMedallion_UAD : MBase_UAD, IDrawable
    {
        public static SlugcatStats.Name marshaw { get => Plugin.Marshaw; }    //name of my slugcat

        public AquaMedallion_UAD(Room room, PlacedObject placed_object) : base(room, placed_object)
        {
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
            if (self.slugcatStats.name != MoreSlugcatsEnums.SlugcatStatsName.Rivulet)
            {
                self.Skill().HasAquaMedallion = true;
                Debug.Log($"{self.slugcatStats.name} Collected a Swim Medallion");
            }
            else
            {
                room.PlaySound(sounded.DeathSounds.acataelinodorokiabla, self.mainBodyChunk.pos);
                self.Die();
            }

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
            sLeaser.sprites[0] = medallion_sprite_FS = new FSprite(Medallion.aqua_medallion_file.name, true);

            sLeaser.sprites[0].scale = 2.2f;

            AddToContainer(sLeaser, rCam, null);
        }
        public void DrawSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float Float, Vector2 camPos)
        {
            sLeaser.sprites[0].x = obj.pos.x - rCam.pos.x;
            sLeaser.sprites[0].y = obj.pos.y - rCam.pos.y;
        }
        public void ApplyPalette(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, RoomPalette pal)
        {
        }
        public void AddToContainer(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, FContainer fContainer)
        {
            fContainer ??= rCam.ReturnFContainer("Items");

            foreach (FSprite fsprite in sLeaser.sprites)
            {
                fContainer.AddChild(fsprite);
            }
        }
    }
    public class AquaMedallion_repr : ManagedRepresentation
    {
        public AquaMedallion_repr(PlacedObject.Type type, ObjectsPage object_page, PlacedObject placed_object) : base(type, object_page, placed_object)
        {
            Debug.Log("Repr created");
            placed_object.pos = this.pos;
        }
    }

}