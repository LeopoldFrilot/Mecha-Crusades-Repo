using FightingGame.Player.Attack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.State
{
    public class GroundedChecker : MonoBehaviour
    {
        GeneralPlayerController PC;
        //AttacksController AC;
        Rigidbody2D rb;
        int bounce = 0;
        int maxBounces = 2;
        Vector2 prevVel;
        Vector2 curVel;
        public void Start()
        {
            PC = GetComponent<GeneralPlayerController>();
            rb = GetComponent<Rigidbody2D>();
            //AC = transform.GetChild(0).GetComponent<AttacksController>();
        }
        public void Update()
        {
            prevVel = curVel;
            curVel = rb.velocity;
        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Ground")
            {
                if(PC.LagType == "hit" && bounce < maxBounces)
                {
                    Bounce();
                    return;
                }
                bounce = 0;
                if (PC.IsInLag)
                {
                    PC.Lag(PC.CD.LagHardLand, "landing");
                }
                else
                {
                    PC.Lag(PC.CD.LagNormalLand, "landing");
                }
                SetGrounded();
            }
        }
        public void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Ground" && !PC.IsGrounded)
            {
                Debug.Log("Fixed the bug");
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
        private void Bounce()
        {
            bounce++;

            Debug.Log("Bounced " + bounce);
            float bounceScalar = .5f / bounce;
            rb.velocity = new Vector2(prevVel.x, prevVel.y * -1 * bounceScalar);
        }
        private void SetGrounded()
        {
            PC.GroundedReset();
            PC.IsGrounded = true;
            PC.PlayerAnimator.SetBool("isAirborne", false);
        }
        private void SetAirborne()
        {
            PC.IsGrounded = false;
            PC.PlayerAnimator.SetBool("isAirborne", true);
        }
    }
}

