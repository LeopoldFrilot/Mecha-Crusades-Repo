using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.Movement
{
    public class FastFall : MonoBehaviour
    {
        [SerializeField] float gravity = 2f;
        GeneralPlayerController PC;
        Rigidbody2D rb;
        bool isFFState;
        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
            rb = PC.Player.GetComponent<Rigidbody2D>();
        }
        public void Update()
        {
            FastFallCheck();
        }

        /* AirDashCheck is a function which moves the character completely horizontally
        * and lag for a few frames */
        private void FastFallCheck()
        {
            if (PC.IsGrounded == false && isFFState == false)
            {
                if (Input.GetAxis("Vertical") < 0 && PC.IsInLag == false && PC.IsFalling)
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
            rb.velocity = rb.velocity - new Vector2(0, PC.CD.FastFallPush);
            rb.gravityScale = PC.CD.GravityScalar * gravity;
            isFFState = true;
        }
    }
}

