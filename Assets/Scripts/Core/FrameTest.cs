using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Core
{
    public class FrameTest : MonoBehaviour
    {
        [SerializeField] float percentageFrameDifAllowed = 10f; // Tries to make sure the frames are consistent when calculating speed
        private float prevFrameTime;    // Keeps a record of the previous frame's duration in real-time
        private float curFrameTime;     // Keeps a record of the last frame's duration in real-time
        private const float targetFrameLength = 1f / 60f; // The goal is to stay at 60 FPS

        public void Awake()
        {
            CurFrameTime = 0f;
        }
        public void Update()
        {
            prevFrameTime = CurFrameTime;
            CurFrameTime = Time.deltaTime;
            if (prevFrameTime != 0)
            {
                float percChange = Mathf.Abs((CurFrameTime - prevFrameTime) / prevFrameTime) * 100;
                if (percChange >= (percentageFrameDifAllowed)) // Checks if percent difference of the previous frame is less than
                {
                    //Debug.Log("Frame length changed by " + (int)percChange + "%");
                    float percError = Mathf.Abs((CurFrameTime - targetFrameLength) / targetFrameLength) * 100;
                    if (percError >= percentageFrameDifAllowed)
                    {
                        Debug.Log("Frame dropped from calculation because it differed from target framerate by " + (int)percError + "%");
                        CurFrameTime = prevFrameTime;
                    }
                }
            }
        }
        public float CurFrameTime { get => curFrameTime; set => curFrameTime = value; }
    }
}

