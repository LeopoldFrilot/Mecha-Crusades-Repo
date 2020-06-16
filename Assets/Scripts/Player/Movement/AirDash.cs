using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.Movement
{
    public class AirDash : MonoBehaviour
    {
        GeneralPlayerController PC;
        public void Start()
        {
            PC = GetComponent<GeneralPlayerController>();
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
            // Should AirDash cancel lag? currently: no
            if (PC.IsInLag)
            {
                //return;
                PC.Lag(0);
            }
            if (PC.MidairOptionsCount < PC.CD.MaxMidairOptions)
            {
                PC.Player.transform.position = PC.Player.transform.position + PC.CurHorizDir * new Vector3(PC.CD.AirDashDist * PC.Momentum, 0, 0);
                PC.MidairOptionsCount++;
                PC.Lag(PC.CD.LagAirDash);
            }
        }
    }
}

