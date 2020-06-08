using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FightingGame.Player.Character;
using FightingGame.Player.State;

namespace FightingGame.Player.Movement
{
    public class FastFall : MonoBehaviour
    {
        [SerializeField] float FFPush = 1f;
        [SerializeField] float gravityScalar = 2f;
        private CharStatTracker character;
        private LagManager lagMan;
        private GroundedChecker groundCheck;
        private Rigidbody2D rb;
        public void Start()
        {
            character = FindObjectOfType<CharStatTracker>();
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
            if (groundCheck.GetGroundedState() == false)
            {
                if (Input.GetAxis("Vertical") < 0 && lagMan.IsInLag() == false)
                {
                    FFall();
                }
            }
        }
        // This needs WORK but it works for now. We don't want the dash to be so instant
        private void FFall()
        {
            rb.velocity = rb.velocity - new Vector2(0, FFPush);
            rb.gravityScale = character.gravityScalar * gravityScalar;
        }
    }
}

