using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.State
{
    public class GroundedChecker : MonoBehaviour
    {
        GeneralPlayerController PC;
        [SerializeField] Transform ground;
        Transform bottomOfCharacter;
        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
            bottomOfCharacter = gameObject.transform.GetChild(0);
        }
        public void Update()
        {
            CheckState();
        }
        /* CheckState is a function which manages the grounded and aerial state 
         * Probably eventually just set up a ground collision check */
        private void CheckState()
        {
            //Debug.Log("Player Height: " + gameObject.transform.position.y);
            //Debug.Log("Ground Height: " + ground.position.y);
            if (ground.position.y >= bottomOfCharacter.position.y)
            {
                if(PC.IsGrounded == false)
                {
                    PC.GroundedReset();
                    if (PC.IsInLag)
                    {
                        PC.Lag(PC.LagHardLand);
                    }
                    else
                    {
                        PC.Lag(PC.LagNormalLand);
                    }
                }
                PC.IsGrounded = true;
                Debug.Log("State: Grounded");
            }
            else
            {
                PC.IsGrounded = false;
                Debug.Log("State: Aerial");
            }
        }
    }
}

