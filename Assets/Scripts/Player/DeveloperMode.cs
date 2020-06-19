using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player
{
    public class DeveloperMode : MonoBehaviour
    {
        bool devMode = true;
        GeneralPlayerController PC;
        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
        }
        public void Update()
        {
            if (devMode)
            {
                DevMode();
            }
        }
        private void DevMode()
        {
            ShowLag();
        }
        private void ShowLag()
        {
            if (PC.IsInLag)
            {
                PC.Player.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            else
            {
                PC.Player.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        public void ToggleDevMode()
        {
            devMode = !devMode;
        }
    }
}

