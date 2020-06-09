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
            PC = FindObjectOfType<GeneralPlayerController>();
            rb = gameObject.GetComponent<Rigidbody2D>();
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
                    rb.velocity = new Vector2((float)PC.CurHorizDir * PC.Momentum, PC.FullHopHeight);    // For now, we will always jump at fullhopheight
                    PC.Lag(PC.LagJump);
                }
                else
                {
                    if (PC.DoubleJumpCount < PC.MaxDoubleJumps && PC.MidairOptionsCount < PC.MaxMidairOptions)
                    {
                        //Debug.Log("DJ");
                        rb.velocity = new Vector2((float)PC.CurHorizDir * PC.Momentum, PC.MidAirJumpHeight); // Will midAirJump if airborne and have enough midair jumps left
                        PC.DoubleJumpCount++;
                        PC.MidairOptionsCount++;
                        PC.Lag(PC.LagDoubleJump);
                    }
                }
            }
        }
    }
}

