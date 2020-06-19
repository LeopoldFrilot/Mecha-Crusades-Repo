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
            PC = FindObjectOfType<GeneralPlayerController>();
        }
        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject != PC.Player)
            {
                Debug.Log("Hit: " + collision.gameObject.name);
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(CA.Knockback.x * PC.DirFacing, CA.Knockback.y);
            }
        }
        public CharacterAttack CA { get => cA; set => cA = value; }
    }
}

