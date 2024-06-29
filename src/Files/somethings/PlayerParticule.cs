using System;
using UnityEngine;
using RWCustom;
using System.Drawing;

namespace particle_manager
{

    /// <summary>
    /// Hmmm bubbles hmm i see mmm good yes i see hmm
    /// </summary>
    public class PlayerBubbles : CosmeticSprite
    {

        public Player _player;
        public float life;
        private float lastLife;
        public int lifeTime;
        private float hollowNess;
        public bool hollow;
        public Vector2 originPoint;
        public bool stuckToOrigin;
        public bool freeFloating;
        public Vector2 liberatedOrigin;
        public Vector2 liberatedOriginVel;
        public Vector2 lastLiberatedOrigin;
        public float lifeTimeWhenFree;
        public float stickiness;
        public static UnityEngine.Color colorOverride;
        private string[] playerBubbleNames = new string[]
        {
        "LizardBubble0",
        "LizardBubble1",
        "LizardBubble2",
        "LizardBubble3",
        "LizardBubble4",
        "LizardBubble5",
        "LizardBubble6",
        "LizardBubble7"
        };

        public float Stickiness { get { return Mathf.Max(this.stickiness, Mathf.InverseLerp(4f, 14f, this._player.bodyChunks[0].vel.magnitude)); } }

        /// <summary>
        /// ctor that have their Behaviour
        /// </summary>
        /// <param name="player"></param>
        /// <param name="intensity"></param>
        /// <param name="stickiness"></param>
        /// <param name="extraSpeed"></param>
        public PlayerBubbles(Player player, float intensity, float stickiness, float extraSpeed, UnityEngine.Color color)
        {

            var player_head = player.bodyChunks[0];
            var player_body = player.bodyChunks[1];

            this._player = player;
            this.stickiness = stickiness;
            this.pos = Vector2.Lerp(player_body.pos, player_head.pos, UnityEngine.Random.value) + Custom.DegToVec(UnityEngine.Random.value * 360f) * 5f * UnityEngine.Random.value;
            this.originPoint = Custom.RotateAroundOrigo(this.pos - player_head.pos, -player_head.rad);
            this.lastPos = this.pos;
            this.life = 1f;
            this.lifeTime = 10 + UnityEngine.Random.Range(0, UnityEngine.Random.Range(0, UnityEngine.Random.Range(0, UnityEngine.Random.Range(0, 200))));
            this.vel = player.bodyChunks[0].vel + Custom.DegToVec(UnityEngine.Random.value * 360f) * (UnityEngine.Random.value * UnityEngine.Random.value * 12f * Mathf.Pow(intensity, 1.5f) + extraSpeed);
            this.hollowNess = Mathf.Lerp(0.5f, 1.5f, UnityEngine.Random.value);

            this.freeFloating = true;

            this.liberatedOrigin = this.pos;
            this.lastLiberatedOrigin = this.pos;

            colorOverride = color;

        }

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="eu"></param>
        public override void Update(bool eu)
        {

            var player_head = _player.bodyChunks[0];
            var player_body = _player.bodyChunks[1];

            this.vel = Vector3.Slerp(this.vel, Custom.DegToVec(UnityEngine.Random.value * 360f), 0.2f);
            
            if (this._player != null)
            {

                this.vel += Custom.DirVec(player_head.pos, this.pos) * Mathf.Lerp(-0.5f, 3f, 4f);
            
            }
            
            this.lastLife = this.life;
            this.life -= 1f / (float)this.lifeTime;
            
            if (this.life <= 0f)
            {

                this.Destroy();
            
            }
            if (this.freeFloating && UnityEngine.Random.value < 0.5f)
            {

                this.hollow = (UnityEngine.Random.value < 0.5f);
            
            }

            bool flag;
            
            if (ModManager.MSC)
            {

                flag = this.room.PointSubmerged(this.pos);
            
            }
            else
            {

                flag = (this.pos.y < this.room.FloatWaterLevel(this.pos.x));
            
            }
            if (flag)
            {

                this.vel *= 0.9f;
                this.vel.y = this.vel.y + 4f;
            
            }
            if (this.stuckToOrigin)
            {

                Vector2 vector = player_head.pos + Custom.RotateAroundOrigo(this.originPoint, player_head.rad);
                this.liberatedOriginVel = vector - this.liberatedOrigin;
                this.liberatedOrigin = vector;
                this.lastLiberatedOrigin = vector;
                
                if (this.life < 0.5f || UnityEngine.Random.value < 1f / (10f + this.Stickiness * 80f) || !Custom.DistLess(this.pos, vector, 10f + 90f * this.Stickiness))
                {

                    this.stuckToOrigin = false;
                
                }
            
            }
            else if (!this.freeFloating)
            {
                
                this.lastLiberatedOrigin = this.liberatedOrigin;
                this.liberatedOriginVel = Vector2.Lerp(this.liberatedOriginVel, Custom.DirVec(this.liberatedOrigin, this.pos) * Mathf.Lerp(Vector2.Distance(this.liberatedOrigin, this.pos), 10f, 0.5f), 0.7f);
                this.liberatedOrigin += this.liberatedOriginVel;
                
                if (Custom.DistLess(this.liberatedOrigin, this.pos, 5f))
                {
                 
                    this.vel = Vector2.Lerp(this.vel, this.liberatedOriginVel, 0.3f);
                    this.lifeTimeWhenFree = this.life;
                    this.freeFloating = true;
             
                }
            
            }

            base.Update(eu);
        }

        /// <summary>
        /// Initiate the sprites fot use.
        /// </summary>
        /// <param name="sLeaser"></param>
        /// <param name="rCam"></param>
        public override void InitiateSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam)
        {
         
            sLeaser.sprites = new FSprite[1];
            sLeaser.sprites[0] = new FSprite("LizardBubble0", true);
            
            this.AddToContainer(sLeaser, rCam, null);
        
        }

        /// <summary>
        /// Draw the sprites
        /// </summary>
        /// <param name="sLeaser"></param>
        /// <param name="rCam"></param>
        /// <param name="timeStacker"></param>
        /// <param name="camPos"></param>
        public override void DrawSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos) 
        {

            var player_head = _player.bodyChunks[0];

            float num = 0.625f * Mathf.Lerp(Mathf.Lerp(Mathf.Sin(3.1415927f * this.lastLife), this.lastLife, 0.5f), Mathf.Lerp(Mathf.Sin(3.1415927f * this.life), this.life, 0.5f), timeStacker);
            sLeaser.sprites[0].x = Mathf.Lerp(this.lastPos.x, this.pos.x, timeStacker) - camPos.x;
            sLeaser.sprites[0].y = Mathf.Lerp(this.lastPos.y, this.pos.y, timeStacker) - camPos.y;
            sLeaser.sprites[0].color = UnityEngine.Color.Lerp(colorOverride, UnityEngine.Color.black, 1f - Mathf.Clamp(Mathf.Lerp(this.lastLife, this.life, timeStacker) * 2f, 0f, 1f));

            int num2 = 0;

            if (this.hollow)
            {

                num2 = Custom.IntClamp((int)(Mathf.Pow(Mathf.InverseLerp(this.lifeTimeWhenFree, 0f, this.life), this.hollowNess) * 7f), 1, 7);
            
            }

            sLeaser.sprites[0].element = Futile.atlasManager.GetElementWithName(this.playerBubbleNames[num2]);

            if (this.stuckToOrigin || !this.freeFloating)
            {

                Vector2 vector;
                if (this.stuckToOrigin)
                {

                    vector = Vector2.Lerp(player_head.lastPos, player_head.pos, timeStacker) + Custom.RotateAroundOrigo(this.originPoint, player_head.rad);
                
                }
                else
                {

                    vector = Vector2.Lerp(this.lastLiberatedOrigin, this.liberatedOrigin, timeStacker);
                
                }

                float num3 = Vector2.Distance(Vector2.Lerp(this.lastPos, this.pos, timeStacker), vector) / 16f;
                sLeaser.sprites[0].scaleX = Mathf.Min(num, num / Mathf.Lerp(num3, 1f, 0.35f));
                sLeaser.sprites[0].scaleY = Mathf.Max(num, num3 - 0.3125f);
                sLeaser.sprites[0].rotation = Custom.AimFromOneVectorToAnother(Vector2.Lerp(this.lastPos, this.pos, timeStacker), vector);
                sLeaser.sprites[0].anchorY = Mathf.InverseLerp(1.25f, 0.3125f, num3) * 0.5f;

            }
            else
            {

                sLeaser.sprites[0].scaleX = num;
                sLeaser.sprites[0].scaleY = num;
                sLeaser.sprites[0].rotation = 0f;
                sLeaser.sprites[0].anchorY = 0.5f;

            }

            base.DrawSprites(sLeaser, rCam, timeStacker, camPos);
        }

        /// <summary>
        /// Apply palette. Empty
        /// </summary>
        /// <param name="sLeaser"></param>
        /// <param name="rCam"></param>
        /// <param name="palette"></param>
        public override void ApplyPalette(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, RoomPalette palette)
        {
        }

        /// <summary>
        /// Add the particule to the fuckin container
        /// </summary>
        /// <param name="sLeaser"></param>
        /// <param name="rCam"></param>
        /// <param name="newContatiner"></param>
        public override void AddToContainer(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, FContainer newContatiner)
        {

            if (newContatiner == null)
            {

                newContatiner = rCam.ReturnFContainer("Midground");
            
            }
            foreach (FSprite fsprite in sLeaser.sprites)
            {

                fsprite.RemoveFromContainer();
                newContatiner.AddChild(fsprite);
            
            }
        
        }

    }

}