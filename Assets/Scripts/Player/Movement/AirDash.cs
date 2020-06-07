using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FightingGame.Player.Character;
using FightingGame.Player.State;
using FightingGame.Core;

namespace FightingGame.Player.Movement
{
    public class AirDash : MonoBehaviour
    {
        private CharStatTracker character;
        private LagManager lagMan;
        private GroundedChecker groundCheck;
        private FrameTest frameT;
        private Rigidbody2D rb;
        private GeneralPlayerController PC;
        public void Start()
        {
            character = FindObjectOfType<CharStatTracker>();
            lagMan = FindObjectOfType<LagManager>();
            groundCheck = FindObjectOfType<GroundedChecker>();
            frameT = FindObjectOfType<FrameTest>();
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
            // Should AirDash cancel lag? currently: yes
            if (lagMan.IsInLag())
            {
                lagMan.LagForFrames(0);
            }
            
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
            if (PC.midairOptionsCount < character.maxMidairOptions)
            {
                gameObject.transform.position = gameObject.transform.position + dir * new Vector3(character.airDashDist, 0, 0);
                rb.velocity = Vector2.zero;
                lagMan.LagForFrames(character.lagAirDash);
                PC.midairOptionsCount++;
            }
        }
    }
}

