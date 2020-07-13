using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.Attack
{
    public class Attack : MonoBehaviour
    {
        GeneralPlayerController PC;
        [SerializeField] CharacterAttack cA;

        public void Start()
        {
            PC = transform.parent.parent.GetComponent<GeneralPlayerController>();
        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject collidedObject = collision.gameObject;
            if (collidedObject != PC.Player)
            {
                var OtherPC = collidedObject.GetComponent<GeneralPlayerController>();
                //Debug.Log(gameObject.name + " hit: " + collision.gameObject.name);
                collidedObject.GetComponent<Rigidbody2D>().velocity = new Vector2(CA.Knockback.x * PC.DirFacing, CA.Knockback.y);
                OtherPC.Lag(CA.Hitstun, "hit");
                OtherPC.DamagePlayer(CA.Damage);
            }
        }
        public CharacterAttack CA { get => cA; set => cA = value; }
    }
}

