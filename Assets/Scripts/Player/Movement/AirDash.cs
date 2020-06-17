using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.Movement
{
    public class AirDash : MonoBehaviour
    {
        GeneralPlayerController PC;
        int dashTimeLength = 3; // in frames
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
            if (PC.MidairOptionsCount < PC.CD.MaxMidairOptions && PC.CurHorizDir != 0)
            {
                ChooseDirection();
                PC.PlayerAnimator.SetTrigger("AIRDASH");
                Vector3 curPos = PC.Player.transform.position;
                Vector3 finalPos = PC.Player.transform.position + PC.CurHorizDir * new Vector3(PC.CD.AirDashDist * PC.Momentum, 0, 0);
                float step = Mathf.Abs(curPos.x - finalPos.x) / dashTimeLength;
                while (curPos != finalPos)
                {
                    PC.Player.transform.position = Vector3.MoveTowards(curPos, finalPos, step);
                    curPos = PC.Player.transform.position;
                }
                PC.MidairOptionsCount++;
                PC.Lag(PC.CD.LagAirDash);
            }
        }
        private void ChooseDirection()
        {
            if(PC.CurHorizDir > 0)
            {
                PC.Player.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                PC.Player.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
}

