using FightingGame.Player.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace FightingGame.Player
{
    public class GeneralPlayerController : MonoBehaviour
    {
        Rigidbody2D rb;

        // private character statistics that won't change
        [Header("General")]
        [SerializeField] float maxHealth;  // Initializing for later
        [SerializeField] float maxMomentum; // Holds the maximum momentum values a character can reach
        [Header("Grounded")]
        [SerializeField] float speed;   // Horizontal speed of movement while grounded
        [SerializeField] float shortHopHeight;  // velocity multiplier for shorthop
        [SerializeField] float fullHopMultiplier;   // Multiplier to compine with shorthopheight to get fullhopheight, will usually be 2
        [SerializeField] float fullHopHeight;   // velocity multiplier for fullhop
        [Header("Aerial")]
        [SerializeField] float aerialSpeed;   // Horizontal speed of movement while airborne
        [SerializeField] int maxMidairOptions;  // Denotes the amount of options a player has for midair movement before falling to the ground
        [SerializeField] int maxDoubleJumps;  // max number of midair jumps a character is allowed
        [SerializeField] float midAirJumpHeight;    // velocity multiplier for when a player jumps midair
        [SerializeField] float maxAirSpeed;  // Max speed the player can go while airborne, barring momentum
        [SerializeField] float airDashDist;  // Distance the player will travel when the air-dash has been triggered
        [SerializeField] float gravityScalar;    // How fast characters fall
        [SerializeField] float fastFallPush;    // Holds the initial velocity increase for when you fastfall
        [Header("Lag")]
        [SerializeField] int lagJump;
        [SerializeField] int lagDoubleJump;
        [SerializeField] int lagNormalLand;
        [SerializeField] int lagHardLand;
        [SerializeField] int lagAirDash;

        // variables that will change
        [SerializeField] int _doubleJumpCount;  // stores the current number of midair jumps used since the last time the player left the grounded state
        [SerializeField] int _midairOptionsCount;   // stores the current number of midair options used since the last time the player left the grounded state
        [SerializeField] float _momentum;
        //[SerializeField] int _health;

        // Start is called before the first frame update
        void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            LoadDefaultStats();
        }
        private void LoadDefaultStats()
        {
            // General
            MaxHealth = 100f;
            MaxMomentum = 100f;

            // Grounded
            Speed = 6f;
            ShortHopHeight = 3.75f;
            FullHopMultiplier = 2f;
            FullHopHeight = FullHopMultiplier * ShortHopHeight;

            // Aerial
            AerialSpeed = 50f;
            MaxMidairOptions = 2;
            MaxDoubleJumps = 1;
            MidAirJumpHeight = 7f;
            MaxAirSpeed = 7.5f;
            AirDashDist = 2f;
            GravityScalar = 2f;
            FastFallPush = 3f;

            // Lag
            LagJump = 1;
            LagDoubleJump = 1;
            LagNormalLand = 0;
            LagHardLand = 8;
            LagAirDash = 10;
        }
        /* GroundedReset sets certain variables to their original values as needed */
        public void GroundedReset()
        {
            DoubleJumpCount = 0;
            MidairOptionsCount = 0;
            rb.gravityScale = GravityScalar;
        }
        public int DoubleJumpCount { get => _doubleJumpCount; set => _doubleJumpCount = value; }
        public int MidairOptionsCount { get => _midairOptionsCount; set => _midairOptionsCount = value; }
        public float Momentum { get => _momentum; set => _momentum = value; }

        public float MaxHealth { get => maxHealth; set => maxHealth = value; }
        public float MaxMomentum { get => maxMomentum; set => maxMomentum = value; }
        public float Speed { get => speed; set => speed = value; }
        public float ShortHopHeight { get => shortHopHeight; set => shortHopHeight = value; }
        public float FullHopMultiplier { get => fullHopMultiplier; set => fullHopMultiplier = value; }
        public float FullHopHeight { get => fullHopHeight; set => fullHopHeight = value; }
        public float AerialSpeed { get => aerialSpeed; set => aerialSpeed = value; }
        public int MaxMidairOptions { get => maxMidairOptions; set => maxMidairOptions = value; }
        public int MaxDoubleJumps { get => maxDoubleJumps; set => maxDoubleJumps = value; }
        public float MidAirJumpHeight { get => midAirJumpHeight; set => midAirJumpHeight = value; }
        public float MaxAirSpeed { get => maxAirSpeed; set => maxAirSpeed = value; }
        public float AirDashDist { get => airDashDist; set => airDashDist = value; }
        public float GravityScalar { get => gravityScalar; set => gravityScalar = value; }
        public float FastFallPush { get => fastFallPush; set => fastFallPush = value; }
        public int LagJump { get => lagJump; set => lagJump = value; }
        public int LagDoubleJump { get => lagDoubleJump; set => lagDoubleJump = value; }
        public int LagNormalLand { get => lagNormalLand; set => lagNormalLand = value; }
        public int LagHardLand { get => lagHardLand; set => lagHardLand = value; }
        public int LagAirDash { get => lagAirDash; set => lagAirDash = value; }
    }
}

