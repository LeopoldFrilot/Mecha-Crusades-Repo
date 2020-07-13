using FightingGame.Player.Attack;
using FightingGame.Player.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        public void Left()
        {
            MC.SetMovingHoriz(-1);
        }
        public void Right()
        {
            MC.SetMovingHoriz(1);
        }
        public void Up()
        {
            MC.SetMovingVert(1);
        }
        public void Down()
        {
            MC.SetMovingVert(-1);
            if (!PC.IsGrounded && PC.IsFalling && PC.LagType != "hit") GetComponent<FastFall>().SetFastFall();
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
            GetComponent<Jump>().StartJump();
        }
        public void Dash()
        {
            if (!PC.IsGrounded) GetComponent<AirDash>().SetAirDash();
        }
        public void LightAttack()
        {
            if (PC.IsInLag) return;
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
            if (PC.IsInLag) return;
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
            if (PC.IsInLag) return;
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
    }
}

