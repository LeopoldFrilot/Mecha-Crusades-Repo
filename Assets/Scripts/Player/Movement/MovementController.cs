using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FightingGame.Player.State;
using FightingGame.Core;
using FightingGame.Level;

namespace FightingGame.Player.Movement
{
    public class MovementController : MonoBehaviour
    {
        GeneralPlayerController PC;
        LagManager lagMan;
        GroundedChecker groundCheck;
        FrameTest frameT;
        Rigidbody2D rb;
        PlayerFollow PF;

        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
            lagMan = FindObjectOfType<LagManager>();
            groundCheck = FindObjectOfType<GroundedChecker>();
            frameT = FindObjectOfType<FrameTest>();
            rb = gameObject.GetComponent<Rigidbody2D>();
            PF = FindObjectOfType<PlayerFollow>();
        }
        public void Update()
        {
            MoveCheck();
            ClampHorizontalMovement();
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
                movement = Input.GetAxis("Horizontal") * PC.Speed * frameT.CurFrameTime * PC.Momentum;    // Framerate-independednt horizontal movement
                gameObject.transform.Translate(movement, 0, 0);
            }
            else
            {
                if (Mathf.Abs(rb.velocity.x) <= PC.MaxAirSpeed)
                {
                    rb.velocity = rb.velocity + new Vector2(Input.GetAxis("Horizontal") * PC.AerialSpeed * frameT.CurFrameTime * PC.Momentum,0);
                }
                else
                {
                    if(Input.GetAxis("Horizontal") < 0)
                    {
                        rb.velocity = new Vector2(-PC.MaxAirSpeed * PC.Momentum, rb.velocity.y);
                    }
                    else if(Input.GetAxis("Horizontal") > 0)
                    {
                        rb.velocity = new Vector2(PC.MaxAirSpeed * PC.Momentum, rb.velocity.y);
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
        private void ClampHorizontalMovement()
        {
            float xClamped = Mathf.Clamp(transform.position.x, PF.Middle - PF.MaxCameraWidth / 2f, PF.Middle + PF.MaxCameraWidth / 2f);
            transform.position = new Vector3(xClamped, transform.position.y, transform.position.z);
        }
    }
}

