using FightingGame.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Level
{
    public class PlayerFollow : MonoBehaviour
    {
        PlayerSelect PS;
        FrameTest FT;
        [Header("Camera")]
        [SerializeField] float cameraMoveSpeed = 5f;
        [SerializeField] float maxCameraWidth = 15f;
        [Header("Ground")]
        [SerializeField] GameObject ground;
        [SerializeField] float groundSpeedScalar = .062f; // .062 for exact, .07 for some depth perception
        [Header("Background")]
        [SerializeField] GameObject sky;
        [SerializeField] GameObject backgroundBack;
        [SerializeField] GameObject backgroundMid;
        [SerializeField] GameObject backgroundFront;
        [SerializeField] float skyScalar = .003f;
        [SerializeField] float backgroundBackScalar = .007f;
        [SerializeField] float backgroundMidScalar = .03f;
        [SerializeField] float backgroundFrontScalar = .05f;
        float middle;
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
            if (Mathf.Abs(PS.Player1.transform.position.x - PS.Player2.transform.position.x) <= MaxCameraWidth)
            {
                Middle = (PS.Player1.transform.position.x + PS.Player2.transform.position.x) / 2f;
                step = cameraMoveSpeed * FT.CurFrameTime;
                MoveCamera();
                MoveGround();
                MoveBackground();
            }
        }

        private void MoveCamera()
        {
            Move(Camera.main.transform);
        }
        private void MoveBackground()
        {
            MoveWithOffset(sky.transform, skyScalar);
            MoveWithOffset(backgroundBack.transform, backgroundBackScalar);
            MoveWithOffset(backgroundMid.transform, backgroundMidScalar);
            MoveWithOffset(backgroundFront.transform, backgroundFrontScalar);
        }
        private void MoveGround()
        {
            MoveWithOffset(ground.transform, groundSpeedScalar);
        }
        private void MoveWithOffset(Transform transform, float scalar)
        {
            float prevPos = transform.position.x;
            Move(transform);
            float curPos = transform.position.x;
            float distMoved = curPos - prevPos;
            Renderer renderer = transform.gameObject.GetComponent<Renderer>();
            float offset = renderer.material.mainTextureOffset.x + (distMoved * scalar);
            renderer.material.mainTextureOffset = new Vector2(offset, renderer.material.mainTextureOffset.y);
        }

        private void Move(Transform transform)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(Middle, transform.position.y, transform.position.z), 
                step);
        }
        public float MaxCameraWidth { get => maxCameraWidth; private set => maxCameraWidth = value; }
        public float Middle { get => middle; private set => middle = value; }

    }
}

