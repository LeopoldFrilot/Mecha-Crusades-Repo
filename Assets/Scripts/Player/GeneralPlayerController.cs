using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace FightingGame.Player
{
    public class GeneralPlayerController : MonoBehaviour
    {

        // variables that will change
        public int doubleJumpCount;    // stores the current number of midair jumps used since the last time the player left the grounded state
        public int midairOptionsCount; // stores the current number of midair options used since the last time the player left the grounded state
        //public int health;

        // Start is called before the first frame update
        void Start()
        {
            GroundedReset();
        }

        // Update is called once per frame
        void Update()
        {
             /*
             ManageBuffer();
             CheckDirection();
             CheckHitboxes();
             */
        }

        /* GroundedReset sets certain variables to their original values as needed */
        public void GroundedReset()
        {
            doubleJumpCount = 0;
            midairOptionsCount = 0;
        }
    }
}

