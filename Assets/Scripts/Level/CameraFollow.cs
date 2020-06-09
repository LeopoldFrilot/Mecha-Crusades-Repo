using FightingGame.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Level
{
    public class CameraFollow : MonoBehaviour
    {
        PlayerSelect PS;
        FrameTest FT;
        [SerializeField] float cameraMoveSpeed = 5f;
        float step;
        public void Start()
        {
            PS = FindObjectOfType<PlayerSelect>();
            FT = FindObjectOfType<FrameTest>();
        }
        public void Update()
        {
            HorizontalFollow();
        }

        private void HorizontalFollow()
        {
            float middle = (PS.Player1.transform.position.x + PS.Player2.transform.position.x) / 2f;
            step = cameraMoveSpeed * FT.CurFrameTime;
            Camera.main.transform.position = Vector3.MoveTowards(
                Camera.main.transform.position,
                new Vector3(middle, Camera.main.transform.position.y, Camera.main.transform.position.z),
                step);
        }
    }
}

