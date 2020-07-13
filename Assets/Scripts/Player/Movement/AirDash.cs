using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.Movement
{
    public class AirDash : MonoBehaviour
    {
        GeneralPlayerController PC;
        Vector3 curPos;
        Vector3 finalPos;
        float step;
        bool isDashing = false;
        public void Start()
        {
            PC = GetComponent<GeneralPlayerController>();
        }
        public void Update()
        {
            if (isDashing)
            {
                Move();
            }
        }
        // This needs WORK but it works for now. We don't want the dash to be so instant
        public void SetAirDash()
        {
            // Should AirDash cancel lag? currently: yes
            if (PC.IsInLag && PC.LagType != "hit")
            {
                //return;
                PC.Lag(0, "none");
            }
            if (PC.MidairOptionsCount < PC.CD.MaxMidairOptions && PC.CurHorizDir != 0)
            {
                PC.Lag(PC.CD.LagAirDash, "recovery");
                ChooseDirection();
                PC.PlayerAnimator.SetTrigger("AIRDASH");
                curPos = transform.position;
                finalPos = transform.position + PC.CurHorizDir * new Vector3(PC.CD.AirDashDist + PC.Momentum - 1, 0, 0);
                step = Mathf.Abs(curPos.x - finalPos.x) / PC.CD.LagAirDash;
                PC.MidairOptionsCount++;
                isDashing = true;
            }
        }
        private void Move()
        {
            transform.position = Vector3.MoveTowards(curPos, finalPos, step);
            curPos = transform.position;

            if (Mathf.Abs(curPos.x - finalPos.x) < Mathf.Epsilon)
            {
                isDashing = false;
            }
        }
        private void ChooseDirection()
        {
            if(PC.CurHorizDir > 0)
            {
                transform.localScale = new Vector2(PC.PlayerXScale * -1, transform.localScale.y);
                PC.DirFacing = 1;
            }
            else
            {
                transform.localScale = new Vector2(PC.PlayerXScale * 1, transform.localScale.y);
                PC.DirFacing = -1;
            }
        }
    }
}

