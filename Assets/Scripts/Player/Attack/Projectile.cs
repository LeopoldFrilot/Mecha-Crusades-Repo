using FightingGame.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.Attack
{
    public class Projectile : MonoBehaviour
    {
        GeneralPlayerController PC;
        //FrameTest FT;
        [SerializeField] ProjectileAttack pA;
        float time;
        int dir;
        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
            //FT = FindObjectOfType<FrameTest>();
            time = 0;
            dir = PC.DirFacing;
            if(dir > 0)
            {
                transform.localScale = new Vector2(PC.PlayerXScale * -1, transform.localScale.y);
            }
            else
            {
                transform.localScale = new Vector2(PC.PlayerXScale * 1, transform.localScale.y);
            }
        }
        public void Update()
        {
            ManageDistance();
            time += Time.deltaTime;
            if (time >= PA.MaxLifespan)
            {
                Destroy(gameObject);
            }
        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject != PC.Player)
            {
                Debug.Log(gameObject.name + " hit: " + collision.gameObject.name);
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(PA.ProjKnockback.x * PC.DirFacing, PA.ProjKnockback.y);
                Destroy(gameObject);
            }
        }
        private void ManageDistance()
        {
            transform.position += new Vector3(dir * PA.Speed * PC.Momentum * Time.deltaTime, 0, 0);
        }
        public ProjectileAttack PA { get => pA; set => pA = value; }
    }
}

