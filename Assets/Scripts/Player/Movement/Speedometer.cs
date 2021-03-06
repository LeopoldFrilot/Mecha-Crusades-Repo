﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.Movement
{
    public class Speedometer : MonoBehaviour
    {
        GeneralPlayerController PC;
        [SerializeField] int framesNeeded = 3;    // In order to find the average apeed we will take the average of speeds over this frame period
        List<float> speedList = new List<float>();  // Tracks the speeds found in an array
        Vector3 prevPosition;   // Keeps a record of the object's previous position one frame ago
        private Vector3 curPosition;    // Keeps a record of the objects current position
        [SerializeField] float aveHorizSpeed;   // The average speed. Its the whole purpose of this script. Serialized for viewing purposes.

        // Start is called before the first frame update
        void Start()
        {
            PC = GetComponent<GeneralPlayerController>();
            // Initializing
            curPosition = Vector3.zero;
            speedList.Clear();
        }

        // Update is called once per frame
        void Update()
        {
            prevPosition = curPosition;
            curPosition = transform.position;
            PopulateHorizSpeedList();
            aveHorizSpeed = CalculateAveSpeed();
            if (PC) PC.AveHorizSpeed = aveHorizSpeed;
        }

        private void PopulateHorizSpeedList()
        {
            if (Time.deltaTime != 0)   //if(frameT.CurFrameTime != 0)
            {
                float horizSpeed = (curPosition.x - prevPosition.x) / Time.deltaTime;   //frameT.CurFrameTime
                if (speedList.Count == framesNeeded)
                {
                    speedList.RemoveRange(0, 1);
                }
                speedList.Add(horizSpeed);
            }
        }

        private float CalculateAveSpeed()
        {
            if(speedList.Count < 1)
            {
                return 0;
            }
            float sum = 0;
            for (int i = 0; i < speedList.Count; i++)
            {
                sum += speedList[i];
            }
            //ShowList(speedList);
            return sum / speedList.Count;
        }

        /* ShowList is for debugging purposes only */
        private void ShowList(List<float> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Debug.Log(list[i]);
            }
        }
    }
}

