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
        public void Update()
        {
            if (PC.IsInLag == false)
            {
                CheckInput();
            }
        }

        private void CheckInput()
        {
            if (PC.IsGrounded)
            {
                if (hitbox != null && hitbox.enabled) // Turns off hitboxes that might have gotten stuck on after falling
                {
                    ActivateAttack();
                }
                // Light Attack
                if (Input.GetButtonDown("Light Attack"))
                {
                    PC.PlayerAnimator.SetTrigger("LIGHTATTACK");
                }
                // Medium Attack
                else if (Input.GetButtonDown("Medium Attack"))
                {
                    PC.PlayerAnimator.SetTrigger("MEDIUMATTACK");
                }
                // Heavy Attack
                else if (Input.GetButtonDown("Heavy Attack"))
                {
                    PC.PlayerAnimator.SetTrigger("HEAVYATTACK");
                }
            }
            else
            {
                // Light Attack Aerial
                if (PC.IsGrounded == false && Input.GetButtonDown("Light Attack"))
                {
                    PC.PlayerAnimator.SetTrigger("LIGHTAERIAL");
                }
                // Medium Attack Aerial
                else if (PC.IsGrounded == false && Input.GetButtonDown("Medium Attack"))
                {
                    PC.PlayerAnimator.SetTrigger("MEDIUMAERIAL");
                }
                // Heavy Attack Aerial
                else if (PC.IsGrounded == false && Input.GetButtonDown("Heavy Attack"))
                {
                    PC.PlayerAnimator.SetTrigger("HEAVYAERIAL");
                }
            }
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
            //Debug.Log(attackRef);
            hitbox.enabled = !hitbox.enabled;
            if (attackRef.CA.HasProjectile == true && hitbox.enabled)
            {
                var projectile = Instantiate(attackRef.CA.Projectile, PC.ProjectileLocation.transform.position, Quaternion.identity);
                projectile.transform.parent = PC.Player.transform;
            }
        }
        
    }
}

