using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.Movement
{
    public class FastFall : MonoBehaviour
    {
        [SerializeField] float gravityIncreaseScalar = 2f;
        GeneralPlayerController PC;
        Rigidbody2D rb;
        public void Start()
        {
            PC = GetComponent<GeneralPlayerController>();
            rb = GetComponent<Rigidbody2D>();
        }

        public void SetFastFall()
        {
            if (PC.IsFastFalling == true) return;
            rb.velocity = rb.velocity - new Vector2(0, PC.CD.FastFallPush);
            rb.gravityScale = PC.CD.GravityScalar * gravityIncreaseScalar;
            PC.IsFastFalling = true;
        }
    }
}

