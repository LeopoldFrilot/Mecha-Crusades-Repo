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
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                PC.CurHorizDir = -1;
            }
            else
            {
                PC.CurHorizDir = 0;
            }
        }
    }
}

