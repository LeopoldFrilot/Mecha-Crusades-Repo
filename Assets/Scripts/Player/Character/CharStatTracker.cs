using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.Character
{
    public class CharStatTracker : MonoBehaviour
    {
        // Serialized just to verify in editor. Should not be actually edited by editor
        [Header("General")]
        [SerializeField] public float maxHealth;  // Initializing for later
        [Header("Grounded")]
        [SerializeField] public float speed;   // Horizontal speed of movement while grounded
        [SerializeField] public float shortHopHeight;  // velocity multiplier for shorthop
        [SerializeField] public float fullHopMultiplier;   // Multiplier to compine with shorthopheight to get fullhopheight, will usually be 2
        [SerializeField] public float fullHopHeight;   // velocity multiplier for fullhop
        [Header("Aerial")]
        [SerializeField] public float aerialSpeed;   // Horizontal speed of movement while airborne
        [SerializeField] public int maxMidairOptions;  // Denotes the amount of options a player has for midair movement before falling to the ground
        [SerializeField] public int maxDoubleJumps;  // max number of midair jumps a character is allowed
        [SerializeField] public float midAirJumpHeight;    // velocity multiplier for when a player jumps midair
        [SerializeField] public float maxAirSpeed;  // Max speed the player can go while airborne, barring momentum
        [SerializeField] public float airDashDist;  // Distance the player will travel when the air-dash has been triggered
        [SerializeField] public float gravityScalar;    // How fast characters fall
        [Header("Lag")]
        [SerializeField] public int lagJump;
        [SerializeField] public int lagDoubleJump;
        [SerializeField] public int lagNormalLand;
        [SerializeField] public int lagHardLand;
        [SerializeField] public int lagAirDash;

        //[SerializeField] CharConfig configFile; 
        public void Start()
        {
            LoadDefaultStats();
            //LoadSpecifics();
            
        }
        public void Update()
        {
            
        }
        /* ImportDefaultStats is a function which sets initial default stats for each character
         * some of which will get overridden by the character's config file */
        private void LoadDefaultStats()
        {
            // General
            maxHealth = 100f;

            // Grounded
            speed = 4f;
            shortHopHeight = 4f;
            fullHopMultiplier = 2f;
            fullHopHeight = fullHopMultiplier * shortHopHeight;

            // Aerial
            aerialSpeed = 20f;
            maxMidairOptions = 2;
            maxDoubleJumps = 1;
            midAirJumpHeight = 7f;
            maxAirSpeed = 5f;
            airDashDist = 2f;
            gravityScalar = 2f;

            // Lag
            lagJump = 5;
            lagDoubleJump = 5;
            lagNormalLand = 3;
            lagHardLand = 12;
            lagAirDash = 10;
        }
        private void LoadSpecifics()
        {
            // WIP
        }
        /*public float GetSpeed()
        {
            return speed;
        }
        public float GetAirSpeed()
        {
            return aerialSpeed;
        }
        public float GetMaxAirSpeed()
        {
            return maxAirSpeed;
        }
        public int GetJumpLag()
        {
            return lagJump;
        }
        public int GetDoubleJumpLag()
        {
            return lagDoubleJump;
        }*/
    }
}

