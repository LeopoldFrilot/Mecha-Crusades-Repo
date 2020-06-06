﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FightingGame.Core;

namespace FightingGame.Player.Movement
{
    public class Speedometer : MonoBehaviour
    {
        [SerializeField] int framesNeeded = 3;    // In order to find the average apeed we will take the average of speeds over this frame period
        private List<float> speedList = new List<float>();  // Tracks the speeds found in an array
        private Vector3 prevPosition;   // Keeps a record of the object's previous position one frame ago
        private Vector3 curPosition;    // Keeps a record of the objects current position
        [SerializeField] private float aveHorizSpeed;   // The average speed. Its the whole purpose of this script. Serialized for viewing purposes.
        private FrameTest frameT;
        // Start is called before the first frame update
        void Start()
        {
            frameT = FindObjectOfType<FrameTest>();
            // Initializing
            curPosition = Vector3.zero;
            speedList.Clear();
        }

        // Update is called once per frame
        void Update()
        {
            prevPosition = curPosition;
            curPosition = gameObject.transform.position;
            PopulateHorizSpeedList();
            aveHorizSpeed = CalculateAveSpeed();
        }

        private void PopulateHorizSpeedList()
        {
            float horizSpeed = (curPosition.x - prevPosition.x) / frameT.GetCurFrameTime();
            if (speedList.Count == framesNeeded)
            {
                speedList.RemoveRange(0, 1);
            }
            speedList.Add(horizSpeed);
        }

        private float CalculateAveSpeed()
        {
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
        public float GetAveHorizSpeed()
        {
            return aveHorizSpeed;
        }
    }
}

