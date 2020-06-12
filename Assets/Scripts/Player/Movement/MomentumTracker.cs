using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.Movement
{
    public class MomentumTracker : MonoBehaviour
    {
        GeneralPlayerController PC;
        [SerializeField] float momentum;
        [SerializeField] float momentumGrowthSpeed = .1f;
        [SerializeField] int maxStrikes = 5;
        int strikes;
        [SerializeField] float count;   // Serialized for viewing
        enum State {positive, neutral, negative} // Holds the direction the player is travelling generally
        State direction;
        State state;


        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
            ResetMomentum();
        }
        public void Update()
        {
            // Detect Direction
            DetectDirection();
            ManageMomentum();
            SubmitMomentum();
        }

        private void ManageMomentum()
        {
            // If direction continues... 
            if (direction != State.neutral && direction == state)
            {
                if (momentum <= PC.CD.MaxMomentum) 
                { 
                    IncrementMomentum();    // increment Momentum exponentially as long as it's less than max momentum
                }    
            }
            // else put a strike on momentum
            else
            {
                strikes++;
                if (strikes > maxStrikes)    // if x strikes momentum ends
                {
                    ResetMomentum();
                    state = direction;  // start new direction
                }
            }
        }

        private void DetectDirection()
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

        private void IncrementMomentum()
        {
            momentum = Mathf.Exp(count);
            count += momentumGrowthSpeed;
        }
        private void ResetMomentum()
        {
            momentum = 0f;
            strikes = 0;
            count = -2f;
        }
        private void SubmitMomentum()
        {
            if (momentum < 1f) PC.Momentum = 1f;
            else PC.Momentum = momentum;
        }
    }
}

