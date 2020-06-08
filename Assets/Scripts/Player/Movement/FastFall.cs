using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FightingGame.Player.State;

namespace FightingGame.Player.Movement
{
    public class FastFall : MonoBehaviour
    {
        [SerializeField] float gravityScalar = 2f;
        GeneralPlayerController PC;
        LagManager lagMan;
        GroundedChecker groundCheck;
        Rigidbody2D rb;
        bool isFFState;
        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
            lagMan = FindObjectOfType<LagManager>();
            groundCheck = FindObjectOfType<GroundedChecker>();
            rb = gameObject.GetComponent<Rigidbody2D>();
        }
        public void Update()
        {
            FastFallCheck();
        }

        /* AirDashCheck is a function which moves the character completely horizontally
        * and lag for a few frames */
        private void FastFallCheck()
        {
            if (groundCheck.GetGroundedState() == false && isFFState == false)
            {
                if (Input.GetAxis("Vertical") < 0 && lagMan.IsInLag() == false)
                {
                    FFall();
                }
            }
            else
            {
                isFFState = false;
            }
        }
        // This needs WORK but it works for now. We don't want the dash to be so instant
        private void FFall()
        {
            rb.velocity = rb.velocity - new Vector2(0, PC.FastFallPush);
            rb.gravityScale = PC.GravityScalar * gravityScalar;
            isFFState = true;
        }
    }
}

