using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.State
{
    public class FallingChecker : MonoBehaviour
    {
        GeneralPlayerController PC;
        float prevHeight;
        float curHeight;
        public void Start()
        {
            PC = GetComponent<GeneralPlayerController>();
        }
        public void Update()
        {
            CheckState();
        }
        /* CheckState is a function which manages the grounded and aerial state */
        private void CheckState()
        {
            prevHeight = curHeight;
            curHeight = PC.Player.transform.position.y;
            if(curHeight < prevHeight)
            {
                PC.IsFalling = true;
                PC.PlayerAnimator.SetBool("isFalling", true);
            }
            else if(curHeight > prevHeight)
            {
                PC.IsFalling = false;
                PC.PlayerAnimator.SetBool("isFalling", false);
            }
        }
    }
}

