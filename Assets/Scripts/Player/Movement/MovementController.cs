using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FightingGame.Core;
using FightingGame.Level;

namespace FightingGame.Player.Movement
{
    public class MovementController : MonoBehaviour
    {
        GeneralPlayerController PC;
        FrameTest FT;
        Rigidbody2D rb;
        PlayerFollow PF;

        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
            FT = FindObjectOfType<FrameTest>();
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
            if (PC.IsInLag)
            {
                /*if(lagMan.GetType() = "hit")
                {
                    DI();
                }*/
                return;
            }
            float movement; // stores this frame's movement based on player input
            if (PC.IsGrounded)
            {
                movement = Input.GetAxis("Horizontal") * PC.Speed * FT.CurFrameTime * PC.Momentum;    // Framerate-independednt horizontal movement
                gameObject.transform.Translate(movement, 0, 0);
            }
            else
            {
                if(Mathf.Abs(PC.AveHorizSpeed) <= PC.MaxAirSpeed * PC.Momentum)
                {
                    movement = Input.GetAxis("Horizontal") * PC.AerialSpeed * FT.CurFrameTime * PC.Momentum;
                    gameObject.transform.Translate(movement, 0, 0);
                }
                /*if (Mathf.Abs(PC.AveHorizSpeed) <= PC.MaxAirSpeed * PC.Momentum)
                {
                    rb.velocity = rb.velocity + new Vector2(Input.GetAxis("Horizontal") * PC.AerialSpeed * FT.CurFrameTime * PC.Momentum,0);
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
                }*/
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

