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
        [SerializeField] ProjectileAttack PA;
        float time;
        int dir;
        public void Start()
        {
            PC = transform.parent.GetComponent<GeneralPlayerController>();
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
            transform.parent = null;
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
            GameObject collidedObject = collision.gameObject;
            if (collidedObject != PC.Player)
            {
                var OtherPC = collidedObject.GetComponent<GeneralPlayerController>();
                //Debug.Log(gameObject.name + " hit: " + collision.gameObject.name);
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(PA.ProjKnockback.x * PC.DirFacing, PA.ProjKnockback.y);
                OtherPC.Lag(PA.ProjHitstun, "hit");
                OtherPC.DealDamage(PA.ProjDamage);
                Destroy(gameObject);
            }
        }
        private void ManageDistance()
        {
            transform.position += new Vector3(dir * PA.Speed * PC.Momentum * Time.deltaTime, 0, 0);
        }
    }
}

