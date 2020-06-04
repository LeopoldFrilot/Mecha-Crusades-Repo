using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GeneralPlayerController : MonoBehaviour
{
    // Serialized just to verify in editor. Should not be actually edited by editor
    [Header("General")]
    [SerializeField] float maxHealth;  // Initializing for later
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
    [SerializeField] float maxAirSpeed; // Max speed the player can go while airborne, barring momentum

    // local variables
    private int doubleJumpCount;    // stores the current number of midair jumps used since the last time the player left the grounded state
    private int midairOptionsCount; // stores the current number of midair options used since the last time the player left the grounded state
    private bool isGrounded;    // stores whether the player is grounded or not
    private Rigidbody2D rb; // Rigidbody of player
    private float horizSpeed;   // stores the average speed of the player
        // Lag related
        private float lag;  // stores the amount of frames the player will beput in lag
        private float lagTrack; // stores the current amount of frames the player has been in lag since the most recent lag started
        private bool inLag; // stores whether the player is stuck in lag or not

    // External objects; these must be connected
    [SerializeField] Transform ground;  // Stores the location of the ground for calculating when the player is grounded
    [SerializeField] Transform groundDetector;  // Stores the location of the bottom of the player for calculating when the player is grounded

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();    // Capturing the rigidbody in a variable
        GroundedReset();
        ImportDefaultStats();
        //ImportStats(string characterName);
        lagTrack = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //DetectKey();
        CheckState();
        TempMove();
        /*
         ManageBuffer();
         CheckGrounded();
         CheckDirection();
         Move();
         CheckHitboxes();
         Result();
         */
        if (inLag)
        {
            ManageLag();
        }
    }

    private void DetectKey()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                Debug.Log(vKey);
            }
        }
    }

    /* TempMove is a function which allows primitive movement
     * while I work on animation and logistics */
    private void TempMove()
    {
        // Player cannot move when in lag
        if (inLag)
        {
            // DI goes here
            return;
        }
        float movement; // stores this frame's movement based on player input
        if (isGrounded) 
        {
            movement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;    // Framerate-independednt horizontal movement
        }
        else
        {
            if(Mathf.Abs(FindObjectOfType<Spedometer>().GetAveHorizSpeed()) <= maxAirSpeed)
            {
                movement = Input.GetAxis("Horizontal") * aerialSpeed * Time.deltaTime;
            }
            else
            {
                movement = 0;
            }
        }
        gameObject.transform.Translate(movement, 0, 0); // moves the character
        horizSpeed = FindObjectOfType<Spedometer>().GetAveHorizSpeed();
        //vertSpeed = (curLoc.y - prevLoc.y) / Time.deltaTime;
        CheckJump(movement);
    }

    /* CheckState is a function which manages the grounded and aerial state */
    private void CheckState()
    {
        if ((rb.velocity.y == 0) && (ground.position.y >= groundDetector.position.y))
        {
            isGrounded = true;
            //Debug.Log("State: Grounded");
            GroundedReset();
        }
        else
        {
            isGrounded = false;
            //Debug.Log("State: Aerial");
        }
    }

    /* CheckJump is a function which manages what happens when the player activates teh jump command
     * which will be different depending on the player's controller and controller config */
    private void CheckJump(float movement)
    {
        if (Input.GetButtonDown("Jump") && !inLag)
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, fullHopHeight);    // For now, we will always jump at fullhopheight
                //LagForSeconds(.3f); // jump has .3 seconds of lag
            }
            else
            {
                if(doubleJumpCount < maxDoubleJumps && midairOptionsCount < maxMidairOptions)
                {
                    //Debug.Log("DJ");
                    rb.velocity = new Vector2(Input.GetAxis("Horizontal") * aerialSpeed, midAirJumpHeight); // Will midAirJump if airborne and have enough midair jumps left
                    doubleJumpCount++;
                    midairOptionsCount++;
                }
            }
        }
    }

    /* ImportDefaultStats is a function which sets initial default stats for each character
     * some of which will get overridden by the character's config file */
    private void ImportDefaultStats()
    {
        // General
        maxHealth = 100f;

        // Grounded
        speed = 4f;
        shortHopHeight = 2.5f;
        fullHopMultiplier = 2f;
        fullHopHeight = fullHopMultiplier * shortHopHeight;

        // Aerial
        aerialSpeed = 3f;
        maxMidairOptions = 2;
        maxDoubleJumps = 1;
        midAirJumpHeight = 5f;
        maxAirSpeed = 4f;
    }

    /* GroundedReset sets certain variables to their original values as needed */
    private void GroundedReset()
    {
        doubleJumpCount = 0;
        midairOptionsCount = 0;
    }

    /* LagForSeconds starts the lag counter by setting inLag to true.
     * The input is the amount of seconds a move should lag for */
    private void LagForSeconds(float num)
    {
        lag = num;
        inLag = true;
    }

    /* ManageLag holds the inLag variable at true until the lag timer "lagtrack" 
     * runs out */
    private void ManageLag()
    {
        if (lagTrack < lag)
        {
            lagTrack += Time.deltaTime;
            //Debug.Log("In lag");
        }
        else
        {
            inLag = false;
            lagTrack = 0f;
            lag = 0f;
        }
    }
}
