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
        public void Update()
        {
            CheckJump();
        }
        /* CheckJump is a function which manages what happens when the player activates teh jump command
         * which will be different depending on the player's controller and controller config */
        private void CheckJump()
        {
            if (Input.GetButtonDown("Jump") && PC.IsInLag == false)
            {
                if (PC.IsGrounded)
                {
                    rb.velocity = new Vector2((float)PC.CurHorizDir * PC.Momentum, PC.CD.FullHopHeight);    // For now, we will always jump at fullhopheight
                    //Debug.Log(PC.CD.FullHopHeight);
                    PC.Lag(PC.CD.LagJump, "recovery");
                }
                else
                {
                    if (PC.DoubleJumpCount < PC.CD.MaxDoubleJumps && PC.MidairOptionsCount < PC.CD.MaxMidairOptions)
                    {
                        //Debug.Log("DJ");
                        rb.velocity = new Vector2((float)PC.CurHorizDir * PC.Momentum, PC.CD.MidAirJumpHeight); // Will midAirJump if airborne and have enough midair jumps left
                        PC.DoubleJumpCount++;
                        PC.MidairOptionsCount++;
                        PC.Lag(PC.CD.LagDoubleJump, "recovery");
                    }
                }
            }
        }
    }
}

