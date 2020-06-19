using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FightingGame.Level;

namespace FightingGame.Player.Movement
{
    public class HorizontalClamp : MonoBehaviour
    {
        GeneralPlayerController PC;
        PlayerFollow PF;
        Rigidbody2D rb;
        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
            rb = PC.Player.GetComponent<Rigidbody2D>();
            PF = FindObjectOfType<PlayerFollow>();
        }
        public void Update()
        {
            ClampHorizontalMovement();
        }
        private void ClampHorizontalMovement()
        {
            float xClamped = Mathf.Clamp(PC.Player.transform.position.x, PF.Middle - PF.MaxCameraWidth / 2f, PF.Middle + PF.MaxCameraWidth / 2f);
            PC.Player.transform.position = new Vector3(xClamped, PC.Player.transform.position.y, PC.Player.transform.position.z);
        }
    }
}

