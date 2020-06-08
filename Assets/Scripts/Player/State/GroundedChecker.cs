using FightingGame.Player.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.State
{
    public class GroundedChecker : MonoBehaviour
    {
        private GeneralPlayerController PC;
        private LagManager lagMan;
        private Rigidbody2D rb;
        [SerializeField] private Transform ground;
        private bool isGrounded;    // stores whether the player is grounded or not
        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
            lagMan = FindObjectOfType<LagManager>();
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
                if(isGrounded == false)
                {
                    PC.GroundedReset();
                    rb.velocity = Vector2.zero;
                    if (lagMan.IsInLag())
                    {
                        lagMan.LagForFrames(PC.LagHardLand);
                    }
                    else
                    {
                        lagMan.LagForFrames(PC.LagNormalLand);
                    }
                }
                isGrounded = true;
                //Debug.Log("State: Grounded");
            }
            else
            {
                isGrounded = false;
                //Debug.Log("State: Aerial");
            }
        }
        public bool GetGroundedState()
        {
            return isGrounded;
        }
    }
}

