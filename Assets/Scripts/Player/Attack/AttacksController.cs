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

        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
        }
        public void Update()
        {
            if (PC.IsInLag == false)
            {
                /*if (PC.IsGrounded)
                {
                    if(Input.GetAxis("Horizontal") == 0)
                    {
                        CheckInput();
                    }
                }
                else
                {
                    CheckInput();
                }*/
                CheckInput();
            }
        }

        private void CheckInput()
        {
            // Turn into switch case one day
            // Light Attack
            if (PC.IsGrounded && Input.GetButtonDown("Light Attack"))
            {
                PC.PlayerAnimator.SetTrigger("LIGHTATTACK");
                PC.Lag(6);
            }
            // Medium Attack
            else if (PC.IsGrounded && Input.GetButtonDown("Medium Attack"))
            {
                PC.PlayerAnimator.SetTrigger("MEDIUMATTACK");
                PC.Lag(25);
            }
            // Heavy Attack
            else if (PC.IsGrounded && Input.GetButtonDown("Heavy Attack"))
            {
                PC.PlayerAnimator.SetTrigger("HEAVYATTACK");
                PC.Lag(35);
            }
            // Light Attack Aerial
            else if (PC.IsGrounded == false && Input.GetButtonDown("Light Attack"))
            {
                PC.PlayerAnimator.SetTrigger("LIGHTAERIAL");
                PC.Lag(7);
            }
            // Medium Attack Aerial
            else if (PC.IsGrounded == false && Input.GetButtonDown("Medium Attack"))
            {
                PC.PlayerAnimator.SetTrigger("MEDIUMAERIAL");
                PC.Lag(11);
            }
            // Heavy Attack Aerial
            else if (PC.IsGrounded == false && Input.GetButtonDown("Heavy Attack"))
            {
                PC.PlayerAnimator.SetTrigger("HEAVYAERIAL");
                PC.Lag(40);
            }
        }
        public void ActivateAttack(int index)
        {
            attack = gameObject.transform.GetChild(index).gameObject;
            Activate(attack);
        }
        private void Activate(GameObject attack)
        {
            hitbox = attack.GetComponent<PolygonCollider2D>();
            Attack attackRef = attack.GetComponent<Attack>();
            Debug.Log(attackRef);
            hitbox.enabled = !hitbox.enabled;
            if (attackRef.CA.HasProjectile == true && hitbox.enabled)
            {
                Instantiate(attackRef.CA.Projectile, PC.ProjectileLocation.position, Quaternion.identity);
            }
        }
    }
}

