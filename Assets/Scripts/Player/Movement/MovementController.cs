using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FightingGame.Player.State;
using FightingGame.Core;

namespace FightingGame.Player.Movement
{
    public class MovementController : MonoBehaviour
    {
        private GeneralPlayerController PC;
        private LagManager lagMan;
        private GroundedChecker groundCheck;
        private FrameTest frameT;
        private Rigidbody2D rb;
        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
            lagMan = FindObjectOfType<LagManager>();
            groundCheck = FindObjectOfType<GroundedChecker>();
            frameT = FindObjectOfType<FrameTest>();
            rb = gameObject.GetComponent<Rigidbody2D>();
        }
        public void Update()
        {
            MoveCheck();
        }

        /* Move is a function which allows primitive movement
        * while I work on animation and logistics */
        private void MoveCheck()
        {
            // Player cannot move when in lag
            if (lagMan.IsInLag())
            {
                /*if(lagMan.GetType() = "hit")
                {
                    DI();
                }*/
                return;
            }
            float movement; // stores this frame's movement based on player input
            if (groundCheck.GetGroundedState())
            {
                movement = Input.GetAxis("Horizontal") * PC.Speed * frameT.CurFrameTime;    // Framerate-independednt horizontal movement
                gameObject.transform.Translate(movement, 0, 0);
            }
            else
            {
                if (Mathf.Abs(rb.velocity.x) <= PC.MaxAirSpeed)
                {
                    rb.velocity = rb.velocity + new Vector2(Input.GetAxis("Horizontal") * PC.AerialSpeed * frameT.CurFrameTime,0);
                }
                else
                {
                    if(Input.GetAxis("Horizontal") < 0)
                    {
                        rb.velocity = new Vector2(-PC.MaxAirSpeed, rb.velocity.y);
                    }
                    else if(Input.GetAxis("Horizontal") > 0)
                    {
                        rb.velocity = new Vector2(PC.MaxAirSpeed, rb.velocity.y);
                    }
                    else
                    {
                        rb.velocity = new Vector2(0, rb.velocity.y);
                    }
                }
            }
        }
        private void DI()
        {

        }
    }
}

