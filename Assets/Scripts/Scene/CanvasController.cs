using FightingGame.Player;
using FightingGame.Player.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FightingGame.Scene
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField] GameObject aerialOptionsCounter;
        private GeneralPlayerController PC;
        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
        }
        public void Update()
        {
            aerialOptionsCounter.GetComponent<Text>().text = (PC.MaxMidairOptions - PC.MidairOptionsCount).ToString();
        }
    }
}

