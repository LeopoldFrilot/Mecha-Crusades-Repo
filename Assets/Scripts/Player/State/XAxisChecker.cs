using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.State
{
    public class XAxisChecker : MonoBehaviour
    {
        private GeneralPlayerController PC;
        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
        }
        public void Update()
        {
            CheckState();
        }
        /* CheckState is a function which manages the grounded and aerial state */
        private void CheckState()
        {
            if(Input.GetAxis("Horizontal") > 0)
            {
                PC.CurHorizDir = 1;
                if (PC.IsGrounded)
                {
                    PC.Player.GetComponent<SpriteRenderer>().flipX = true;
                }
                PC.PlayerAnimator.SetBool("isRunning", true);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                PC.CurHorizDir = -1;
                if (PC.IsGrounded)
                {
                    PC.Player.GetComponent<SpriteRenderer>().flipX = false;
                }
                PC.PlayerAnimator.SetBool("isRunning", true);
            }
            else
            {
                PC.CurHorizDir = 0;
                PC.PlayerAnimator.SetBool("isRunning", false);
            }
        }
    }
}

