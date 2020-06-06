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
        private CharStatTracker character;
        private Rigidbody2D rb;
        [SerializeField] private Transform ground;
        private bool isGrounded;    // stores whether the player is grounded or not
        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
            lagMan = FindObjectOfType<LagManager>();
            character = FindObjectOfType<CharStatTracker>();
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
            if ((rb.velocity.y == 0) && (ground.position.y >= gameObject.transform.position.y))
            {
                if(isGrounded == false)
                {
                    rb.velocity = Vector2.zero;
                    lagMan.LagForFrames(character.lagNormalLand);
                    PC.GroundedReset();
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

