using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.Attack
{
    public class AttacksController : MonoBehaviour
    {
        GeneralPlayerController PC;
        BoxCollider2D hitbox;
        GameObject attack;

        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
        }
        public void Update()
        {
            CheckInput();
        }

        private void CheckInput()
        {
            // Turn into switch case one day
            // Light Attack
            if (PC.IsGrounded && Input.GetButtonDown("Light Attack"))
            {
                PC.PlayerAnimator.SetTrigger("LIGHTATTACK");
                PC.Lag(35);
            }
            // Medium Attack
            else if (PC.IsGrounded && Input.GetButtonDown("Medium Attack"))
            {
                PC.PlayerAnimator.SetTrigger("MEDIUMATTACK");
                PC.Lag(35);
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
                PC.PlayerAnimator.SetTrigger("LIGHTATTACKAERIAL");
                PC.Lag(35);
            }
            // Medium Attack Aerial
            else if (PC.IsGrounded == false && Input.GetButtonDown("Medium Attack"))
            {
                PC.PlayerAnimator.SetTrigger("MEDIUMATTACKAERIAL");
                PC.Lag(35);
            }
            // Heavy Attack Aerial
            else if (PC.IsGrounded == false && Input.GetButtonDown("Heavy Attack"))
            {
                PC.PlayerAnimator.SetTrigger("HEAVYATTACKAERIAL");
                PC.Lag(35);
            }
        }
        public void ActivateAttack(int index)
        {
            attack = gameObject.transform.GetChild(index).gameObject;
            Activate(attack);
        }
        private void Activate(GameObject attack)
        {
            hitbox = attack.GetComponent<BoxCollider2D>();
            hitbox.enabled = !hitbox.enabled;
        }
    }
}

