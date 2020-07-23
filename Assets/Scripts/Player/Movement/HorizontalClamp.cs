using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FightingGame.Level;

namespace FightingGame.Player.Movement
{
    public class HorizontalClamp : MonoBehaviour
    {
        PlayerFollow PF;
        GeneralPlayerController PC;
        [SerializeField] float dieThreshold = 40f;
        bool die = false;
        public void Start()
        {
            PF = FindObjectOfType<PlayerFollow>();
        }
        public void Update()
        {
            if (!die) ClampHorizontalMovement();
            if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) >= dieThreshold)
            {
                die = true;
            }
        }
        private void ClampHorizontalMovement()
        {
            float xClamped = Mathf.Clamp(transform.position.x, PF.Middle - PF.MaxCameraWidth / 2f, PF.Middle + PF.MaxCameraWidth / 2f);
            transform.position = new Vector3(xClamped, transform.position.y, transform.position.z);
        }
    }
}

