using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.Attack
{
    public class AttacksController : MonoBehaviour
    {
        GeneralPlayerController PC;
        PolygonCollider2D hitbox;
        GameObject attack;
        Attack attackRef;
        string curMove;

        public void Start()
        {
            PC = transform.parent.GetComponent<GeneralPlayerController>();
        }

        public void StartMove(string name)
        {
            curMove = name;
            attack = transform.Find(curMove).gameObject;
            attackRef = attack.GetComponent<Attack>();
            PC.Lag(attackRef.CA.GetMoveLength(), "recovery");
        }
        public void ActivateAttack()
        {
            hitbox = attack.GetComponent<PolygonCollider2D>();
            hitbox.enabled = !hitbox.enabled;
            if (attackRef.CA.HasProjectile == true && hitbox.enabled)
            {
                var projectile = Instantiate(attackRef.CA.Projectile, PC.ProjectileLocation.transform.position, Quaternion.identity);
                projectile.transform.parent = PC.Player.transform;
            }
        }
        public void CorrectAttackForLanding()
        {
            if (hitbox != null && hitbox.enabled && PC.IsGrounded)
            {
                ActivateAttack();
            }
        }
    }
}

