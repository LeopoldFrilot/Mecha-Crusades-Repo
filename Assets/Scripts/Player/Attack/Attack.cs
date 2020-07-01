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
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject != PC.Player)
            {
                Debug.Log(gameObject.name + " hit: " + collision.gameObject.name);
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(CA.Knockback.x * PC.DirFacing, CA.Knockback.y);
            }
        }
        public CharacterAttack CA { get => cA; set => cA = value; }
    }
}

