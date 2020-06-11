using FightingGame.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame
{
    public class Template : MonoBehaviour
    {
        GeneralPlayerController PC;
        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
        }
        public void Update()
        {
            
        }
    }
}

