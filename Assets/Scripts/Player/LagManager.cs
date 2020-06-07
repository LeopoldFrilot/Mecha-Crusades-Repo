using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player
{
    public class LagManager : MonoBehaviour
    {
        private int lag;  // stores the amount of frames the player will beput in lag
        private int lagTrack; // stores the current amount of frames the player has been in lag since the most recent lag started
        private bool inLag; // stores whether the player is stuck in lag or not
        private string lagType;

        public void Start()
        {
            lagTrack = 0;
        }
        public void Update()
        {
            if (inLag)
            {
                ManageLag();
            }
        }
        /* LagForSeconds starts the lag counter by setting inLag to true.
         * The input is the amount of seconds a move should lag for */
        public void LagForFrames(int num)
        {
            lag = num;
            inLag = true;
            lagTrack = 0;
        }

        /* ManageLag holds the inLag variable at true until the lag timer "lagtrack" 
         * runs out */
        private void ManageLag()
        {
            //Debug.Log("lag is: " + lag);
            if (lagTrack < lag)
            {
                lagTrack++;
                //Debug.Log("I've been lagging for " + lagTrack + " frames: " + inLag);
            }
            else
            {
                //Debug.Log("Lag Over: " + lag);
                inLag = false;
                lagTrack = 0;
                lag = 0;
            }

        }
        public bool IsInLag()
        {
            return inLag;
        }
        public void SetLagType(string name)
        {
            lagType = name;
        }
        public string GetLagType()
        {
            return lagType;
        }
    }
}

