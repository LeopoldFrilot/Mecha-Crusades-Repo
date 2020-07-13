using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.Movement
{
    public class Jump : MonoBehaviour
    {
        GeneralPlayerController PC;
        Rigidbody2D rb;
        public void Start()
        {
            PC = GetComponent<GeneralPlayerController>();
            rb = GetComponent<Rigidbody2D>();
        }
        public void StartJump()
        {
            JumpReset();
            if (PC.IsGrounded)
            {
                rb.velocity = new Vector2((float)PC.CurHorizDir * PC.Momentum, PC.CD.FullHopHeight);    // For now, we will always jump at fullhopheight
                PC.Lag(PC.CD.LagJump, "recovery");
            }
            else
            {
                if (PC.DoubleJumpCount < PC.CD.MaxDoubleJumps && PC.MidairOptionsCount < PC.CD.MaxMidairOptions)
                {
                    rb.velocity = new Vector2((float)PC.CurHorizDir * PC.Momentum, PC.CD.MidAirJumpHeight); // Will midAirJump if airborne and have enough midair jumps left
                    PC.DoubleJumpCount++;
                    PC.MidairOptionsCount++;
                    PC.Lag(PC.CD.LagDoubleJump, "recovery");
                }
            }
        }

        private void JumpReset()
        {
            PC.IsFastFalling = false;
            rb.gravityScale = PC.CD.GravityScalar;
        }
    }
}

