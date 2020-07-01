using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player
{
    public class LagManager : MonoBehaviour
    {
        GeneralPlayerController PC;
        private int lag;  // stores the amount of frames the player will beput in lag
        private int lagTrack; // stores the current amount of frames the player has been in lag since the most recent lag started

        public void Start()
        {
            PC = GetComponent<GeneralPlayerController>();
            lagTrack = 0;
        }
        public void Update()
        {
            if (PC.IsInLag)
            {
                ManageLag();
            }
        }
        /* LagForSeconds starts the lag counter by setting inLag to true.
         * The input is the amount of seconds a move should lag for */
        public void LagForFrames(int num)
        {
            lag = num;
            PC.IsInLag = true;
            lagTrack = 0;
        }

        /* ManageLag holds the inLag variable at true until the lag timer "lagtrack" 
         * runs out */
        private void ManageLag()
        {
            if (lagTrack < lag-1 && lag > 0)
            {
                lagTrack++;
            }
            else
            {
                //Debug.Log("Reset");
                Reset();
            }
        }

        private void Reset()
        {
            PC.IsInLag = false;
            lagTrack = 0;
            lag = 0;
            PC.LagType = "none";
            //PC.PlayerAnimator.StopPlayback();
        }

        public void SetLagType(string name)
        {
            PC.LagType = name;
        }
    }
}

