using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FightingGame.Core;

namespace FightingGame.Player.Movement
{
    public class MovementController : MonoBehaviour
    {
        GeneralPlayerController PC;
        //FrameTest FT;

        public void Start()
        {
            PC = GetComponent<GeneralPlayerController>();
            //FT = FindObjectOfType<FrameTest>();
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
            if (PC.IsInLag && PC.LagType != "recovery")
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
                if (PC.LagType == "recovery") return;
                movement = Input.GetAxis("Horizontal") * PC.CD.Speed * Time.deltaTime * PC.Momentum;    // Framerate-independednt horizontal movement
                transform.Translate(movement, 0, 0);
            }
            else
            {
                if(Mathf.Abs(PC.AveHorizSpeed) <= PC.CD.MaxAirSpeed * PC.Momentum)
                {
                    movement = Input.GetAxis("Horizontal") * PC.CD.AerialSpeed * Time.deltaTime * PC.Momentum;
                    PC.Player.transform.Translate(movement, 0, 0);
                }
            }
        }
        private void DI()
        {

        }
    }
}

