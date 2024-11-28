using System;
using UnityEngine;

namespace Objects
{
    internal class FireBall : PlayerCarryableItem, IDrawable
    {
        private Vector2 rotation;
        private Vector2 lastRotation;
        private Vector2? setRotation;

        public Vector2? GetSetRotation() => setRotation;
        public void SetSetRotation(Vector2? value) => setRotation = value;
        public Vector2 GetLastRotation() => lastRotation;
        public void SetLastRotation(Vector2 value) => lastRotation = value;
        public Vector2 GetRotation() => rotation;
        public void SetRotation(Vector2 value) => rotation = value;
        public float LastDarkness { get; set; }
        public float Darkness { get; set; }
        public Vector2 position { get => obj_pos; set => obj_pos = value; }
        public float radius { get => rad; set => rad = value; }

        public static Vector2 obj_pos;
        public static PlayerCarryableItem self;
        public static float rad;

        public FireBall(AbstractPhysicalObject abstractPhysicalObject, Vector2 lastRotation = default, Vector2 rotation = default, Vector2? setRotation = null) : base(abstractPhysicalObject)
        {
            bodyChunks = new BodyChunk[1];
            bodyChunks[0] = new BodyChunk(this, 0, new Vector2(0f, 0f), 8f, 0.2f);
            bodyChunkConnections = new BodyChunkConnection[0];
            airFriction = 0.999f;
            gravity = 0.50f;
            bounce = 0.50f;
            surfaceFriction = 0.4f;
            collisionLayer = 2;
            waterFriction = 0.98f;
            buoyancy = 0.4f;
            firstChunk.loudness = 7f;

            SetLastRotation(lastRotation);
            SetRotation(rotation);
            SetSetRotation(setRotation);
        }

        public static void OnHooks()
        {
            On.SandboxGameSession.SpawnItems += spawn_fireball;     //bruh
            On.Player.Grabability += grab_fireball;                 //you will burn yourself
        }
        public void ThrowByPlayer()
        {
            Debug.Log("throwed");
        }
        public override void PlaceInRoom(Room placeRoom)
        {
            base.PlaceInRoom(placeRoom);

            Vector2 center = placeRoom.MiddleOfTile(abstractPhysicalObject.pos);

            int i = 0;
            bodyChunks[i].HardSetPosition(new Vector2(1, 1) * 20f + center);
        }
        public override void Update(bool eu)
        {
            base.Update(eu);

            Debug.Log($"radius: { radius }");
            Debug.Log($"object pos: { position }");
        }
        //hooks
        private static void spawn_fireball(On.SandboxGameSession.orig_SpawnItems orig, SandboxGameSession self, IconSymbol.IconSymbolData data, WorldCoordinate pos, EntityID entityID)
        {
            var absol = abs_FireBall.obj_fireball;           //variable for the abstract object

            if (data.itemType == absol)
            {
                var abs_object = new abs_FireBall(self.game.world, pos, entityID);
                self.game.world.GetAbstractRoom(0).AddEntity(abs_object);
            }
            orig(self, data, pos, entityID);
        }
        private static Player.ObjectGrabability grab_fireball(On.Player.orig_Grabability orig, Player self, PhysicalObject obj)
        {
            if (obj is FireBall)
            {
                if (self.input[0].thrw && self.input[1].thrw)
                {
                    self.forceBurst = true;
                }
                return Player.ObjectGrabability.OneHand;
            }
            return orig(self, obj);
        }

        //IDrawable methods
        public void InitiateSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam)
        {
            sLeaser.sprites = new FSprite[1];
            sLeaser.sprites[0] = new FSprite("Futile_White", true);
            AddToContainer(sLeaser, rCam, null);    //why, bro
        }
        public void DrawSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            Vector2 vector = Vector2.Lerp(firstChunk.lastPos, firstChunk.pos, timeStacker);
            Vector2 v = Vector3.Slerp(GetLastRotation(), GetRotation(), timeStacker);

            int colorWiggle = -39;  // color lerp clock
            if (colorWiggle < 40)
            {
                colorWiggle++;
            }
            else
            {
                colorWiggle = -39;
            }

            Color c = Color.Lerp(Color.cyan, Color.white, Mathf.InverseLerp(0, 40, Mathf.Abs(colorWiggle)));

            color = c;

            LastDarkness = Darkness;
            Darkness = rCam.room.Darkness(vector) * (1f - rCam.room.LightSourceExposure(vector));

            var x = vector.x - camPos.x;
            var y = vector.y - camPos.y;

            if (Darkness != LastDarkness)
            {
                ApplyPalette(sLeaser, rCam, rCam.currentPalette);
            }

            for (int i = 0; i < Math.Min(4, sLeaser.sprites.Length); i++)
            {
                sLeaser.sprites[i].x = x;
                sLeaser.sprites[i].y = y;
                sLeaser.sprites[i].rotation = RWCustom.Custom.VecToDeg(v);
                sLeaser.sprites[i].shader = rCam.room.game.rainWorld.Shaders["VectorCircle"];
                sLeaser.sprites[i].scale = 2f;

                obj_pos = new Vector2(x, y);
                rad = sLeaser.sprites[i].width / 2;
            }

            if (blink > 0 && UnityEngine.Random.value < 0.5f)
            {
                sLeaser.sprites[0].color = blinkColor;
            }
            else
            {
                sLeaser.sprites[0].color = color;
            }

            if (slatedForDeletetion || room != rCam.room)
            {
                sLeaser.CleanSpritesAndRemove();
            }
        }
        public void ApplyPalette(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, RoomPalette palette)
        {
            color = UnityEngine.Color.Lerp(new Color(255, 255, 255), palette.blackColor, Darkness);

            sLeaser.sprites[0].color = color;
        }
        public void AddToContainer(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, FContainer newContatiner)
        {
            newContatiner ??= rCam.ReturnFContainer("Items");

            foreach (FSprite fsprite in sLeaser.sprites)
            {
                newContatiner.AddChild(fsprite);
            }
        }
    }
    internal class abs_FireBall : AbstractPhysicalObject
    {
        public static readonly AbstractObjectType obj_fireball = new("un_fireball", true);

        public abs_FireBall(World world, WorldCoordinate pos, EntityID ID) : base(world, obj_fireball, null, pos, ID)
        {
        }
        public override void Realize()
        {
            base.Realize();     //??
            realizedObject = new FireBall(this);    //create the circle
        }
        public class absT_FireBall
        {
            public static AbstractPhysicalObject.AbstractObjectType absT_circle = new("absT_fireball", true);
        }
    }
}