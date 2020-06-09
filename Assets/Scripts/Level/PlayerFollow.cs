using FightingGame.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace FightingGame.Level
{
    public class PlayerFollow : MonoBehaviour
    {
        PlayerSelect PS;
        FrameTest FT;
        [SerializeField] float cameraMoveSpeed = 5f;
        [SerializeField] float maxCameraWidth = 15f;
        [SerializeField] GameObject ground;
        [SerializeField] float groundSpeedScalar = .062f; // .062 for exact, .07 for some depth perception
        Renderer groundMaterial;
        float middle;
        float step;

        public void Start()
        {
            PS = FindObjectOfType<PlayerSelect>();
            FT = FindObjectOfType<FrameTest>();
            groundMaterial = ground.GetComponent<Renderer>();
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
                /*Camera.main.transform.position = Vector3.MoveTowards(
                    Camera.main.transform.position,
                    new Vector3(Middle, Camera.main.transform.position.y, Camera.main.transform.position.z),
                    step);*/
                MoveCamera();
                MoveGround();

            }
        }

        private void MoveCamera()
        {
            Move(Camera.main.transform);
        }

        private void MoveGround()
        {
            float prevGround = ground.transform.position.x;
            Move(ground.transform);
            float curGround = ground.transform.position.x;
            float distMoved = curGround - prevGround;
            float offset = groundMaterial.material.mainTextureOffset.x + (distMoved * groundSpeedScalar);
            groundMaterial.material.mainTextureOffset = new Vector2(offset, groundMaterial.material.mainTextureOffset.y);
            //Debug.Log(offset);
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

