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
        int seed;
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
            if (!PA.IsActive) return;
            seed = Random.Range(1, 100);    // This is int so it is easy to map
            NeutralHandbook();
            /*if (PA.EmoState == "Neutral") NeutralHandbook();
            else if (PA.EmoState == "Aggressive") AggressiveHandbook();
            else if (PA.EmoState == "Defensive") DefensiveHandbook();*/
        }
        private void NeutralHandbook()
        {
            HorizontalMove(50);
            NeutralAttack();
        }

        private void NeutralAttack()
        {
            float dist = PA.DistFromOpp;
            if (dist <= 1f)
            {
                if (OPC.IsGrounded && !OPC.IsInLag && PC.IsGrounded && CheckProbability(80))
                {
                    PA.LightAttack();
                }
                else if (OPC.IsFalling && OPC.IsInLag && CheckProbability(90))
                {
                    PA.LightAerial();
                }
                else if (CheckProbability(10))
                {
                    if (PC.IsGrounded) PA.Jump();
                    PA.DashAway();
                    PA.DashAway();
                }
            }
            else if (dist <= 3f)
            {
                if(PC.IsGrounded && !OPC.IsGrounded && CheckProbability(5))
                {
                    PA.HeavyAttack();
                }
                else if(PC.IsFalling && OPC.IsGrounded && CheckProbability(30))
                {
                    PA.LightAerial();
                }
                else if (CheckProbability(20))
                {
                    PA.MediumAttack();
                }
            }
            else if (dist <= 8.5f)
            {
                if (PC.DirFacing != OPC.DirFacing && CheckProbability(3))
                {
                    PA.Jump();
                    PA.MediumAerial();
                }
            }
        }

        private void AggressiveHandbook()
        {
            HorizontalMove(65);
        }
        private void DefensiveHandbook()
        {
            HorizontalMove(30);
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
            if (probability > 50) probability = 50; // Eventually we need to find a way to map larger percentages
            int modular = (int)(100f / (float)probability);
            if (seed % modular == 0) return true; // Succes! The metric should change though
            else return false;
        }
    }
}
