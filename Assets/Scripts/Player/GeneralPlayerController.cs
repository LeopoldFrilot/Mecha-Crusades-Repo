using FightingGame.Player.Attack;
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
        AttacksController AC;
        [SerializeField] CharacterData cD;
        GameObject player;
        GameObject otherPlayer;
        Animator playerAnimator;
        float playerXScale;
        Transform projectileLocation;

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
        [SerializeField] string _lagType;
        [SerializeField] int _health;

        // Start is called before the first frame update
        public void Awake()
        {
            LM = FindObjectOfType<LagManager>();
            AC = FindObjectOfType<AttacksController>();
            Player = gameObject;
            OtherPlayer = FindObjectOfType<PlayerSelect>().GetOtherPlayer(Player);
            rb = Player.GetComponent<Rigidbody2D>();
            PlayerAnimator = Player.GetComponent<Animator>();
            PlayerXScale = playerXScale = Player.transform.localScale.x;
            ProjectileLocation = GameObject.Find("ProjectileLocation").transform;
        }
        public void Lag(int num)
        {
            LM.LagForFrames(num);
        }
        /* GroundedReset sets certain variables to their original values as needed */
        public void GroundedReset()
        {
            DoubleJumpCount = 0;
            MidairOptionsCount = 0;
            rb.gravityScale = CD.GravityScalar;
            rb.velocity = Vector2.zero;
            PlayerAnimator.SetBool("isAirborne", false);
        }
        public void ActivateAttack(int index)
        {
            AC.ActivateAttack(index);
        }
        public CharacterData CD { get => cD; set => cD = value; }
        public GameObject Player { get => player; set => player = value; }
        public GameObject OtherPlayer { get => otherPlayer; set => otherPlayer = value; }
        public Animator PlayerAnimator { get => playerAnimator; set => playerAnimator = value; }


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
        public Transform ProjectileLocation { get => projectileLocation; set => projectileLocation = value; }
    }
}

