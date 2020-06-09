using FightingGame.Player.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.State
{
    public class GroundedChecker : MonoBehaviour
    {
        private GeneralPlayerController PC;
        private Rigidbody2D rb;
        [SerializeField] private Transform ground;
        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
            rb = gameObject.GetComponent<Rigidbody2D>();
        }
        public void Update()
        {
            CheckState();
        }
        /* CheckState is a function which manages the grounded and aerial state */
        private void CheckState()
        {
            //Debug.Log("Player Height: " + gameObject.transform.position.y);
            //Debug.Log("Ground Height: " + ground.position.y);
            if (ground.position.y >= gameObject.transform.position.y)
            {
                if(PC.IsGrounded == false)
                {
                    PC.GroundedReset();
                    rb.velocity = Vector2.zero;
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
                //Debug.Log("State: Grounded");
            }
            else
            {
                PC.IsGrounded = false;
                //Debug.Log("State: Aerial");
            }
        }
    }
}

