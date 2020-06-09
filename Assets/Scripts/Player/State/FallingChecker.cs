using FightingGame.Player.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.State
{
    public class FallingChecker : MonoBehaviour
    {
        private GeneralPlayerController PC;
        float prevHeight;
        float curHeight;
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
            prevHeight = curHeight;
            curHeight = transform.position.y;
            if(curHeight < prevHeight)
            {
                PC.IsFalling = true;
            }
            else
            {
                PC.IsFalling = false;
            }
        }
    }
}

