using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player
{
    public class DeveloperMode : MonoBehaviour
    {
        bool devMode = false;
        GeneralPlayerController PC;
        Color defaultColor;
        [SerializeField] Color normalLagColor;
        [SerializeField] Color hitLagColor;
        public void Start()
        {
            PC = GetComponent<GeneralPlayerController>();
            defaultColor = GetComponent<SpriteRenderer>().color;
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
                if (PC.LagType == "hit") GetComponent<SpriteRenderer>().color = hitLagColor;
                else GetComponent<SpriteRenderer>().color = normalLagColor;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = defaultColor;
            }
        }
        public void ToggleDevMode()
        {
            devMode = !devMode;
        }
    }
}

