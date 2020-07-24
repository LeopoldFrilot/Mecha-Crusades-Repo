using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FightingGame.Scene
{
    public class ButtonToggle : MonoBehaviour
    {
        bool isOn = false;
        [SerializeField] Color onColor;
        [SerializeField] bool fpsToggleButton;
        [SerializeField] bool enableCPUButton;
        
        public void Start()
        {
            InitializeButton();
        }
        public void Update()
        {
            if (isOn)
            {
                if (fpsToggleButton) SceneStatics.ShowFPS = true;
                if (enableCPUButton) SceneStatics.IsCPUActive = true;
                GetComponent<Image>().color = onColor;
            }
            else
            {
                if (fpsToggleButton) SceneStatics.ShowFPS = false;
                if (enableCPUButton) SceneStatics.IsCPUActive = false;
                GetComponent<Image>().color = Color.white;
            }
        }
        private void InitializeButton()
        {
            if (fpsToggleButton)
            {
                if (SceneStatics.ShowFPS)
                {
                    isOn = true;
                }
                else
                {
                    isOn = false;
                }
            }
            if (enableCPUButton)
            {
                if (SceneStatics.IsCPUActive)
                {
                    isOn = true;
                }
                else
                {
                    isOn = false;
                }
            }
        }
        public void ToggleButton()
        {
            isOn = !isOn;
        }

        
    }
}

