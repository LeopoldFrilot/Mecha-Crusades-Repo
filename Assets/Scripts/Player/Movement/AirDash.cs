using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.Movement
{
    public class AirDash : MonoBehaviour
    {
        Rigidbody2D rb;
        GeneralPlayerController PC;
        public void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            PC = gameObject.GetComponent<GeneralPlayerController>();
        }
        public void Update()
        {
            AirDashCheck();
        }

        /* AirDashCheck is a function which moves the character completely horizontally
        * and lag for a few frames */
        private void AirDashCheck()
        {
            if (PC.IsGrounded == false)
            {
                if (Input.GetButtonDown("Dash"))
                {
                    Dash();
                }
            }
        }
        // This needs WORK but it works for now. We don't want the dash to be so instant
        private void Dash()
        {
            // Should AirDash cancel lag? currently: yes
            if (PC.IsInLag)
            {
                PC.Lag(0);
            }
            if (PC.MidairOptionsCount < PC.MaxMidairOptions)
            {
                Vector3 prevVelocity = rb.velocity;
                gameObject.transform.position = gameObject.transform.position + PC.CurHorizDir * new Vector3(PC.AirDashDist * PC.Momentum, 0, 0);
                rb.velocity = prevVelocity;
                PC.Lag(PC.LagAirDash);
                PC.MidairOptionsCount++;
            }
        }
    }
}

