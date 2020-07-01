using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.State
{
    public class GroundedChecker : MonoBehaviour
    {
        GeneralPlayerController PC;
        public void Start()
        {
            PC = GetComponent<GeneralPlayerController>();
        }

        private void SetGrounded()
        {
            if (PC.IsGrounded == false)
            {
                PC.GroundedReset();
                if (PC.IsInLag)
                {
                    PC.Lag(PC.CD.LagHardLand);
                }
                else
                {
                    PC.Lag(PC.CD.LagNormalLand);
                }
            }
            PC.IsGrounded = true;
            PC.PlayerAnimator.SetBool("isAirborne", false);
            //Debug.Log("Grounded");
        }
        private void SetAirborne()
        {
            PC.IsGrounded = false;
            PC.PlayerAnimator.SetBool("isAirborne", true);
            //Debug.Log("State: Aerial");
        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Ground")
            {
                SetGrounded();
            }
        }
        public void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Ground")
            {
                SetAirborne();
            }
        }
    }
}

