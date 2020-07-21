using FightingGame.AI;
using FightingGame.Player.Attack;
using FightingGame.Player.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player
{
    public class InputManager : MonoBehaviour
    {
        GeneralPlayerController PC;
        MovementController MC;
        [SerializeField] AttacksController AC;
        public void Start()
        {
            PC = GetComponent<GeneralPlayerController>();
            MC = GetComponent<MovementController>();
        }
        public void Update()
        {
            if (DefaultCheck())
            {
                Neutral("Horizontal");
                Neutral("Vertical");
            }
        }
        public void Left()
        {
            if (DefaultCheck()) return;
            MC.SetMovingHoriz(-1);
        }
        public void Right()
        {
            if (DefaultCheck()) return;
            MC.SetMovingHoriz(1);
        }
        public void Up()
        {
            if (DefaultCheck()) return;
            if (PC.LagType == "hit" && !PC.IsGrounded) MC.SetMovingVert(1);
        }
        public void Down()
        {
            if (DefaultCheck()) return;
            if (PC.LagType == "hit" && !PC.IsGrounded) MC.SetMovingVert(-1);
            if (!PC.IsGrounded && PC.LagType != "hit") GetComponent<FastFall>().SetFastFall();  // Testing not having to reach max height to fast fall
        }
        public void Neutral(string direction)
        {
            if (direction == "Horizontal")
            {
                MC.SetMovingHoriz(0);
            }
            else
            {
                MC.SetMovingVert(0);
            }
        }
        public void Jump()
        {
            if (PC.IsInLag || DefaultCheck()) return;
            GetComponent<Jump>().StartJump();
        }
        public void Dash()
        {
            if (PC.LagType == "hit" || DefaultCheck()) return;
            if (!PC.IsGrounded) GetComponent<AirDash>().SetAirDash();
        }
        public void LightAttack()
        {
            if (PC.IsInLag || DefaultCheck()) return;
            if (PC.IsGrounded)
            {
                PC.PlayerAnimator.SetTrigger("LIGHTATTACK");
                AC.StartMove("Light Attack");
            }
            else
            {
                PC.PlayerAnimator.SetTrigger("LIGHTAERIAL");
                AC.StartMove("Light Aerial");
            }
        }
        public void MediumAttack()
        {
            if (PC.IsInLag || DefaultCheck()) return;
            if (PC.IsGrounded)
            {
                PC.PlayerAnimator.SetTrigger("MEDIUMATTACK");
                AC.StartMove("Medium Attack");
            }
            else
            {
                PC.PlayerAnimator.SetTrigger("MEDIUMAERIAL");
                AC.StartMove("Medium Aerial");
            }
        }
        public void HeavyAttack()
        {
            if (PC.IsInLag || DefaultCheck()) return;
            if (PC.IsGrounded)
            {
                PC.PlayerAnimator.SetTrigger("HEAVYATTACK");
                AC.StartMove("Heavy Attack");
            }
            else
            {
                PC.PlayerAnimator.SetTrigger("HEAVYAERIAL");
                AC.StartMove("Heavy Aerial");
            }

        }
        public void ActivateAttackHitbox()
        {
            AC.ActivateAttack();
        }
        private bool DefaultCheck()
        {
            if (!GetComponent<PrimitiveAI>() && !GetComponent<InputReader>().enabled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

