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
        private CharStatTracker character;
        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
            character = FindObjectOfType<CharStatTracker>();
        }
        public void Update()
        {
            aerialOptionsCounter.GetComponent<Text>().text = (character.maxMidairOptions - PC.midairOptionsCount).ToString();
        }
    }
}

