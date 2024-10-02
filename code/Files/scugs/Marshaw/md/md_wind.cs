using CWT;
using particle_manager;
using sounded;

namespace medals
{
    internal class md_wind
    {
        public static void wind_hooks()
        {
            On.Player.MovementUpdate += movement_upd;   // [ DOUBLE JUMP ] update for the movement check.
            On.Player.Jump += jump_state;               // [ DOUBLE JUMP ] when you jump. Manage the boolean
            On.Player.TerrainImpact += jump_ground;     // [ DOUBLE JUMP ] sets the boolean to False when you are on the ground
        }

        #region jump_ground

        public static void jump_ground(On.Player.orig_TerrainImpact orig, Player self, int chunk, RWCustom.IntVector2 direction, float speed, bool firstContact)
        {
            var cwt_skill = self.Skill();

            if (cwt_skill.HasDoubleJumpMedallion == true)
            {
                cwt_skill.playerAlreadyJumped = false;
            }

            orig(self, chunk, direction, speed, firstContact);
        }

        #endregion
        #region movement_upd

        public static void movement_upd(On.Player.orig_MovementUpdate orig, Player self, bool eu)
        {
            Room room = self.room;
            var cwt_skill = self.Skill(); ;

            if (self.Skill().playerAlreadyJumped == true && cwt_skill.HasDoubleJumpMedallion == true && !self.input[1].jmp && self.input[0].jmp)
            {
                room.PlaySound(CustomSFX.EFF_doubleJump, self.mainBodyChunk.pos);
                room.AddObject(new PlayerBubbles(self, 3f, 0f, 1f, self.ShortCutColor()));
                self.canJump = 1;
                self.wantToJump++;
            }

            orig(self, eu); //call Orig

            if (self.Skill().HasDoubleJumpMedallion == true && self.Skill().playerAlreadyJumped == true)
            {
                if (!self.Consious ||
                self.Stunned || self.animation == Player.AnimationIndex.HangFromBeam ||
                self.animation == Player.AnimationIndex.ClimbOnBeam || self.animation == Player.AnimationIndex.AntlerClimb ||
                self.animation == Player.AnimationIndex.VineGrab || self.animation == Player.AnimationIndex.ZeroGPoleGrab ||
                self.bodyMode == Player.BodyModeIndex.WallClimb || self.bodyMode == Player.BodyModeIndex.Swimming ||
                (self.bodyMode == Player.BodyModeIndex.ZeroG || self.room.gravity <= 0.5f) && (self.wantToJump > 0))
                {
                    self.Skill().playerAlreadyJumped = false;
                }
            }
        }

        #endregion
        #region jump_state

        public static void jump_state(On.Player.orig_Jump orig, Player self)
        {
            orig(self);

            var cwt_skill = self.Skill(); ;

            if (cwt_skill.HasDoubleJumpMedallion == true)
            {
                if (self.Skill().playerAlreadyJumped == true)
                {
                    self.Skill().playerAlreadyJumped = false;
                }
                else
                {
                    self.Skill().playerAlreadyJumped = true;
                    self.canJump = 1;
                }
            }
        }

        #endregion
    }
}