using FightingGame.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.AI
{
    public class AIBehavior : MonoBehaviour
    {
        PrimitiveAI PA;
        GeneralPlayerController PC, OPC;
        [SerializeField] int horizontalMoveLockoutMin = 5; // Min frames the CPU will move in one direction
        [SerializeField] int horizontalMoveLockoutMax = 20; // Max frames the CPU will move in one direction
        int horizontalMoveLockout;
        int horizontalMoveFrame = 0;

        private void Start()
        {
            PA = GetComponent<PrimitiveAI>();
            PC = GetComponent<GeneralPlayerController>();
            OPC = PA.Opponent.GetComponent<GeneralPlayerController>();
        }
        private void Update()
        {
            Act();
        }

        private void Act()
        {
            if (!PA.IsActive)
            {
                PA.StandNeutral();
                return;
            }
            NeutralHandbook();
            /*if (PA.EmoState == "Neutral") NeutralHandbook();
            else if (PA.EmoState == "Aggressive") AggressiveHandbook();
            else if (PA.EmoState == "Defensive") DefensiveHandbook();*/
        }
        private void NeutralHandbook()
        {
            HorizontalMove(65);
            if (CheckProbability(50)) NeutralAttack();
        }

        private void NeutralAttack()
        {
            float dist = PA.DistFromOpp;
            if (dist <= 1.5f && !PC.IsInLag)
            {
                if (OPC.IsFalling && PC.IsGrounded && CheckProbability(50)) PA.HeavyAttack();
                if (OPC.IsGrounded)
                {
                    if (PC.IsGrounded) PA.LightAttack();
                    else PA.LightAerial();
                }
            }
            else if (dist <= 2.5f && !PC.IsInLag)
            {
                if (!OPC.IsGrounded && OPC.IsInLag) PA.HeavyAerial();
                if (OPC.IsGrounded || OPC.IsFalling) PA.MediumAttack();
            }
            else if (dist <= 5f && !PC.IsInLag)
            {
                if (CheckProbability(50)) PA.DashForward();
            }
            else if (dist <= 8f && !PC.IsInLag)
            {
                if (CheckProbability(30)) PA.MediumAerial();
            }
        }

        private void AggressiveHandbook()
        {
            HorizontalMove(85);
        }
        private void DefensiveHandbook()
        {
            HorizontalMove(50);
        }
        private void HorizontalMove(int prob)
        {
            horizontalMoveFrame++;
            if (horizontalMoveFrame >= horizontalMoveLockout)
            {
                if (CheckProbability(prob)) PA.Forward();
                else PA.Backward();
                horizontalMoveFrame = 0;
                horizontalMoveLockout = Random.Range(horizontalMoveLockoutMin, horizontalMoveLockoutMax);
            }
            
        }
        private bool CheckProbability(int probability)
        {
            if (RandInt() <= probability) return true;
            else return false;
        }
        private int RandInt()
        {
            return Random.Range(1, 100);
        }
    }
}
