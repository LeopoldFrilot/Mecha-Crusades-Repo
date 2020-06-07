using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FightingGame.Player.Character;
using FightingGame.Player.State;

namespace FightingGame.Player.Movement
{
    public class Jump : MonoBehaviour
    {
        private CharStatTracker character;
        private LagManager lagMan;
        private GeneralPlayerController PC;
        private GroundedChecker groundCheck;
        private Rigidbody2D rb;
        public void Start()
        {
            character = FindObjectOfType<CharStatTracker>();
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
                    rb.velocity = new Vector2(0, character.fullHopHeight);    // For now, we will always jump at fullhopheight
                    lagMan.LagForFrames(character.lagJump);
                }
                else
                {
                    if (PC.doubleJumpCount < character.maxDoubleJumps && PC.midairOptionsCount < character.maxMidairOptions)
                    {
                        //Debug.Log("DJ");
                        rb.velocity = new Vector2(0, character.midAirJumpHeight); // Will midAirJump if airborne and have enough midair jumps left
                        PC.doubleJumpCount++;
                        PC.midairOptionsCount++;
                    }
                }
            }
        }
    }
}

