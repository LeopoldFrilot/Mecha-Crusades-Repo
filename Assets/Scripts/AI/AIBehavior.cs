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
        float seed;
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
            seed = Random.Range(0, 1f);
            NeutralHandbook();
            /*if (PA.EmoState == "Neutral") NeutralHandbook();
            else if (PA.EmoState == "Aggressive") AggressiveHandbook();
            else if (PA.EmoState == "Defensive") DefensiveHandbook();*/
        }
        private void NeutralHandbook()
        {
            HorizontalMove(.5f);
            float dist = PA.DistFromOpp;
            if (dist <= 1f)
            {
                if (OPC.IsGrounded && !OPC.IsInLag && PC.IsGrounded && CheckProbability(.8f))
                {
                    PA.LightAttack();
                }
                else if(OPC.IsFalling && OPC.IsInLag && CheckProbability(.9f))
                {
                    PA.LightAerial();
                }
            }
            else if(dist <= 3f)
            {
                if (CheckProbability(.2f))
                {
                    PA.MediumAttack();
                }
            }
            else if(dist <= 8.5f)
            {
                if (CheckProbability(.3f))
                {
                    PA.MediumAerial();
                }
            }
            else
            {

            }
        }
        private void AggressiveHandbook()
        {
            HorizontalMove(.65f);
        }
        private void DefensiveHandbook()
        {
            HorizontalMove(.3f);
        }
        private void HorizontalMove(float prob)
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
        private bool CheckProbability(float probability)
        {
            if (seed <= probability) return true; // Succes! The metric should change though
            else return false;
        }
    }
}
