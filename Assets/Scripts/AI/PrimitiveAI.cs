using FightingGame.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.AI
{
    public class PrimitiveAI : MonoBehaviour
    {
        PlayerSelect PS;
        FrameTest FT;
        [SerializeField] GameObject opponent;
        [SerializeField] float speed = 1f;
        private void Start()
        {
            PS = FindObjectOfType<PlayerSelect>();
            FT = FindObjectOfType<FrameTest>();
            opponent = PS.GetOtherPlayer(gameObject);
        }
        private void Update()
        {
            Move();
        }

        private void Move()
        {
            float step = speed * FT.CurFrameTime;
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(opponent.transform.position.x, transform.position.y, transform.position.z),
                step);
        }
    }
}
