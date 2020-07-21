using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Level
{
    public class PlayerFollow : MonoBehaviour
    {
        PlayerSelect PS;
        [Header("Camera")]
        [SerializeField] float cameraMoveSpeed = 5f;
        [SerializeField] float maxCameraWidth = 15f;
        [Header("Ground")]
        [SerializeField] GameObject ground;
        [SerializeField] float groundSpeedScalar; // .062 for exact, .07 for some depth perception
        [Header("Level")]
        [SerializeField] GameObject sky;
        [SerializeField] float skyScalar;
        [SerializeField] GameObject backgroundBack;
        [SerializeField] float backgroundBackScalar;
        [SerializeField] GameObject backgroundMid;
        [SerializeField] float backgroundMidScalar;
        [SerializeField] GameObject backgroundFront;
        [SerializeField] float backgroundFrontScalar;
        [SerializeField] GameObject stillBackground;
        float middle; 
        float step;

        public void Start()
        {
            PS = FindObjectOfType<PlayerSelect>();
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
                step = cameraMoveSpeed * Time.deltaTime;
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
            MoveWithOffset(stillBackground.transform, 0);
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

