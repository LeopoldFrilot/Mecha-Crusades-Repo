﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.Movement
{
    public class MomentumTracker : MonoBehaviour
    {
        GeneralPlayerController PC;
        [SerializeField] float momentum;
        [SerializeField] float momentumGrowthSpeed = .01f;
        [SerializeField] int maxStrikes = 5;
        [SerializeField] int strikes;
        [SerializeField] float count;   // Serialized for viewing
        [SerializeField] float baseMomentumCount = -1.5f;
        enum State {positive, neutral, negative} // Holds the direction the player is travelling generally
        State direction;
        State state;


        public void Start()
        {
            PC = GetComponent<GeneralPlayerController>();
            ResetMomentum();
        }
        public void Update()
        {
            // Detect Direction
            DetectDirectionOfMovement();
            ManageMomentum();
            SubmitMomentum();
        }
        private void DetectDirectionOfMovement()
        {
            if (PC.AveHorizSpeed < 0)
            {
                direction = State.negative;
            }
            else if (PC.AveHorizSpeed > 0)
            {
                direction = State.positive;
            }
            else
            {
                direction = State.neutral;
            }
        }
        private void ManageMomentum()
        {
            // If direction continues... 
            if (direction != State.neutral && direction == state && PC.LagType != "hit")
            {
                if (momentum <= PC.CD.MaxMomentum) 
                { 
                    IncrementMomentum();    // increment Momentum exponentially as long as it's less than max momentum
                }
                else
                {
                    PC.PlayerAnimator.SetBool("isMaxMomentum", true);
                }
            }
            // else put a strike on momentum
            else
            {
                if (direction != State.neutral || PC.CurHorizDir == 0 || PC.LagType == "hit")
                {
                    strikes++;
                }
                if (strikes > maxStrikes)    // if x strikes momentum ends
                {
                    ResetMomentum(); 
                    PC.PlayerAnimator.SetBool("isMaxMomentum", false);
                    state = direction;  // start new direction
                }
            }
        }


        private void IncrementMomentum()
        {
            momentum = Mathf.Exp(count);
            count += momentumGrowthSpeed;
        }
        private void ResetMomentum()
        {
            momentum = 0f;
            strikes = 0;
            count = baseMomentumCount;
        }
        private void SubmitMomentum()
        {
            if (momentum < 1f) PC.Momentum = 1f;
            else PC.Momentum = momentum;
        }
    }
}

