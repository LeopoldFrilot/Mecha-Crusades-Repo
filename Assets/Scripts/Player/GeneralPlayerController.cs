using FightingGame.Player.Attack;
using FightingGame.Player.Movement;
using FightingGame.Player.State;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace FightingGame.Player
{
    public class GeneralPlayerController : MonoBehaviour
    {
        Rigidbody2D rb;
        LagManager LM;
        [SerializeField] CharacterData cD;
        GameObject player;
        GameObject otherPlayer;
        Animator playerAnimator;
        float playerXScale;
        [SerializeField] GameObject projectileLocation;

        // variables that will change
        [Header("Variables")]
        [SerializeField] int _doubleJumpCount;  // stores the current number of midair jumps used since the last time the player left the grounded state
        [SerializeField] int _midairOptionsCount;   // stores the current number of midair options used since the last time the player left the grounded state
        [SerializeField] int _curHorizDir;
        [SerializeField] float _momentum;
        [SerializeField] float _aveHorizSpeed;
        [SerializeField] bool _isInLag;
        [SerializeField] bool _isGrounded;
        [SerializeField] bool _isFalling;
        [SerializeField] int _dirFacing;
        [SerializeField] string _lagType;   // Lagtypes: none, recovery, hit, landing
        [SerializeField] int _health;
        [SerializeField] int _curHorizInput;
        [SerializeField] bool _isFastFalling;

        // Start is called before the first frame update
        public void Start()
        {
            Player = gameObject;
            LM = GetComponent<LagManager>();
            OtherPlayer = FindObjectOfType<PlayerSelect>().GetOtherPlayer(gameObject);
            rb = GetComponent<Rigidbody2D>();
            PlayerAnimator = GetComponent<Animator>();
            PlayerXScale = playerXScale = transform.localScale.x;
        }
        public void Lag(int num, string lagType)
        {
            LM.LagForFrames(num);
            LagType = lagType;
        }
        /* GroundedReset sets certain variables to their original values as needed */
        public void GroundedReset()
        {
            DoubleJumpCount = 0;
            MidairOptionsCount = 0;
            rb.gravityScale = CD.GravityScalar;
            rb.velocity = Vector2.zero;
            PlayerAnimator.SetBool("isAirborne", false);
            LagType = "none";
            IsFastFalling = false;
        }
        public void PlayClipDuringAttack(int index)
        {
            transform.GetChild(0).GetComponent<AttacksController>().PlayAudioClip(index);
        }
        public void DamagePlayer(int damage)
        {
            Health -= damage;
            //Debug.Log(Health + " health for " + gameObject.name);
            if(Health <= 0)
            {
                FindObjectOfType<WinManager>().ManageRoundOver(OtherPlayer, Player);
            }
        }
        public void DeactivateAllAttacks()
        {
            transform.GetChild(0).GetComponent<AttacksController>().DeactivateAllAttacks();
        }
        public CharacterData CD { get => cD; set => cD = value; }
        public GameObject OtherPlayer { get => otherPlayer; set => otherPlayer = value; }
        public Animator PlayerAnimator { get => playerAnimator; set => playerAnimator = value; }
        public GameObject Player { get => player; set => player = value; }


        public int DoubleJumpCount { get => _doubleJumpCount; set => _doubleJumpCount = value; }
        public int MidairOptionsCount { get => _midairOptionsCount; set => _midairOptionsCount = value; }
        public int CurHorizDir { get => _curHorizDir; set => _curHorizDir = value; }
        public float Momentum { get => _momentum; set => _momentum = value; }
        public float AveHorizSpeed { get => _aveHorizSpeed; set => _aveHorizSpeed = value; }
        public bool IsInLag { get => _isInLag; set => _isInLag = value; }
        public bool IsGrounded { get => _isGrounded; set => _isGrounded = value; }
        public bool IsFalling { get => _isFalling; set => _isFalling = value; }
        public int DirFacing { get => _dirFacing; set => _dirFacing = value; }
        public string LagType { get => _lagType; set => _lagType = value; }
        public int Health { get => _health; set => _health = value; }
        public float PlayerXScale { get => playerXScale; set => playerXScale = value; }
        public GameObject ProjectileLocation { get => projectileLocation; set => projectileLocation = value; }
        public int CurHorizInput { get => _curHorizInput; set => _curHorizInput = value; }
        public bool IsFastFalling { get => _isFastFalling; set => _isFastFalling = value; }
    }
}

