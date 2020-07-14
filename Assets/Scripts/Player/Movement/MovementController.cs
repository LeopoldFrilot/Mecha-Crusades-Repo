using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.Movement
{
    public class MovementController : MonoBehaviour
    {
        GeneralPlayerController PC;
        int horizMovement;
        int vertMovement;
        float DIMultiplier = .1f;

        public void Start()
        {
            PC = GetComponent<GeneralPlayerController>();
        }
        public void Update()
        {
            if (horizMovement != 0) MoveHorizontal();
            if (vertMovement != 0) DI();
        }

        private void MoveHorizontal()
        {
            
            // Player cannot move when in lag
            if (PC.IsInLag && PC.LagType != "recovery")
            {
                return;
            }
            float movement; // stores this frame's movement based on player input
            if (PC.IsGrounded)
            {
                if (PC.LagType == "recovery") return;
                movement = horizMovement * PC.CD.Speed * Time.deltaTime * PC.Momentum;    // Framerate-independednt horizontal movement
                transform.Translate(movement, 0, 0);
            }
            else
            {
                if(Mathf.Abs(PC.AveHorizSpeed) <= PC.CD.MaxAirSpeed * PC.Momentum)
                {
                    movement = horizMovement * PC.CD.AerialSpeed * Time.deltaTime * PC.Momentum;
                    transform.Translate(movement, 0, 0);
                }
            }
        }
        // DI is only called if the player is in hitlag
        private void DI()
        {
            float alteration = vertMovement * PC.CD.AerialSpeed * Time.deltaTime * DIMultiplier;
            GetComponent<Rigidbody2D>().velocity += new Vector2(0, alteration);
        }
        public void SetMovingHoriz(int num)
        {
            horizMovement = num;
            PC.CurHorizInput = num;
        }
        public void SetMovingVert(int num) 
        {
            vertMovement = num;
        }
    }
}

