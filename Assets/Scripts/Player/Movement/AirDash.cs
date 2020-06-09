using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FightingGame.Player.State;
using FightingGame.Core;

namespace FightingGame.Player.Movement
{
    public class AirDash : MonoBehaviour
    {
        LagManager lagMan;
        GroundedChecker groundCheck;
        Rigidbody2D rb;
        GeneralPlayerController PC;
        public void Start()
        {
            lagMan = FindObjectOfType<LagManager>();
            groundCheck = FindObjectOfType<GroundedChecker>();
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
            if (groundCheck.GetGroundedState() == false)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    if (Input.GetButtonDown("Dash"))
                    {
                        Dash(1);
                    }
                }
                else if (Input.GetAxis("Horizontal") < 0)
                {
                    if (Input.GetButtonDown("Dash"))
                    {
                        Dash(-1);
                    }
                }
            }
        }
        // This needs WORK but it works for now. We don't want the dash to be so instant
        private void Dash(int dir)
        {
            // Should AirDash cancel lag? currently: yes
            if (lagMan.IsInLag())
            {
                lagMan.LagForFrames(0);
            }
            if (PC.MidairOptionsCount < PC.MaxMidairOptions)
            {
                gameObject.transform.position = gameObject.transform.position + dir * new Vector3(PC.AirDashDist * PC.Momentum, 0, 0);
                rb.velocity = Vector2.zero;
                lagMan.LagForFrames(PC.LagAirDash);
                PC.MidairOptionsCount++;
            }
        }
    }
}

