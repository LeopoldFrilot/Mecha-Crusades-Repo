using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "New Character")] // Allows for a right-click in the asset folder to create a new one
public class CharacterData : ScriptableObject
{
    [Header("Character")]
    [SerializeField] string charName;
    [SerializeField] string charDescription;
    [Header("General")]
    [SerializeField] float maxHealth;  // Initializing for later
    [SerializeField] float maxMomentum; // Holds the maximum momentum values a character can reach
    [Header("Grounded")]
    [SerializeField] float speed;   // Horizontal speed of movement while grounded
    [SerializeField] float shortHopHeight;  // velocity multiplier for shorthop
    [SerializeField] float fullHopMultiplier;   // Multiplier to compine with shorthopheight to get fullhopheight, will usually be 2
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

    public string CharName { get => charName; }
    public string CharDescription { get => charDescription; }
    public float MaxHealth { get => maxHealth; }
    public float MaxMomentum { get => maxMomentum; }
    public float Speed { get => speed; }
    public float ShortHopHeight { get => shortHopHeight; }
    public float FullHopMultiplier { get => fullHopMultiplier; }
    public float FullHopHeight { get => shortHopHeight * fullHopMultiplier; }
    public float AerialSpeed { get => aerialSpeed; }
    public int MaxMidairOptions { get => maxMidairOptions; }
    public int MaxDoubleJumps { get => maxDoubleJumps; }
    public float MidAirJumpHeight { get => midAirJumpHeight; }
    public float MaxAirSpeed { get => maxAirSpeed; }
    public float AirDashDist { get => airDashDist; }
    public float GravityScalar { get => gravityScalar; }
    public float FastFallPush { get => fastFallPush; }
    public int LagJump { get => lagJump; }
    public int LagDoubleJump { get => lagDoubleJump; }
    public int LagNormalLand { get => lagNormalLand; }
    public int LagHardLand { get => lagHardLand; }
    public int LagAirDash { get => lagAirDash; }
}
