using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FightingGame.Player.State;

namespace FightingGame.Player.Movement
{
    public class Jump : MonoBehaviour
    {
        LagManager lagMan;
        GeneralPlayerController PC;
        GroundedChecker groundCheck;
        Rigidbody2D rb;
        public void Start()
        {
            lagMan = FindObjectOfType<LagManager>();
            PC = FindObjectOfType<GeneralPlayerController>();
            groundCheck = FindObjectOfType<GroundedChecker>();
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
            if (Input.GetButtonDown("Jump") && lagMan.IsInLag() == false)
            {
                if (groundCheck.GetGroundedState())
                {
                    rb.velocity = new Vector2(0, PC.FullHopHeight);    // For now, we will always jump at fullhopheight
                    lagMan.LagForFrames(PC.LagJump);
                }
                else
                {
                    if (PC.DoubleJumpCount < PC.MaxDoubleJumps && PC.MidairOptionsCount < PC.MaxMidairOptions)
                    {
                        //Debug.Log("DJ");
                        rb.velocity = new Vector2(0, PC.MidAirJumpHeight); // Will midAirJump if airborne and have enough midair jumps left
                        PC.DoubleJumpCount++;
                        PC.MidairOptionsCount++;
                        lagMan.LagForFrames(PC.LagDoubleJump);
                    }
                }
            }
        }
    }
}

