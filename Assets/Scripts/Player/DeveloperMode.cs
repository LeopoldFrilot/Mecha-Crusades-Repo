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
            PC = GetComponent<GeneralPlayerController>();
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
                GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        public void ToggleDevMode()
        {
            devMode = !devMode;
        }
    }
}

