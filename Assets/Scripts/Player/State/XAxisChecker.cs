using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.State
{
    public class XAxisChecker : MonoBehaviour
    {
        GeneralPlayerController PC;
        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
        }
        public void Update()
        {
            CheckStickState();
        }
        /* CheckState is a function which manages the grounded and aerial state */
        private void CheckStickState()
        {
            if(Input.GetAxis("Horizontal") > 0)
            {
                if (PC.IsInLag) return;
                GoRight();
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                if (PC.IsInLag) return;
                GoLeft();
            }
            else
            {
                PC.CurHorizDir = 0;
                PC.PlayerAnimator.SetBool("isRunning", false);
            }
        }

        public void GoRight()
        {
            PC.CurHorizDir = 1;
            if (PC.IsGrounded)
            {
                PC.Player.transform.localScale = new Vector2(PC.PlayerXScale * -1, PC.Player.transform.localScale.y);
                PC.DirFacing = 1;
            }
            PC.PlayerAnimator.SetBool("isRunning", true);
        }

        public void GoLeft()
        {
            PC.CurHorizDir = -1;
            if (PC.IsGrounded)
            {
                PC.Player.transform.localScale = new Vector2(PC.PlayerXScale * 1, PC.Player.transform.localScale.y);
                PC.DirFacing = -1;
            }
            PC.PlayerAnimator.SetBool("isRunning", true);
        }
    }
}

