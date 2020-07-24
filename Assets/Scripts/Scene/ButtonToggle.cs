using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FightingGame.Scene
{
    public class ButtonToggle : MonoBehaviour
    {
        bool isOn = true;
        [SerializeField] Color onColor;
        [SerializeField] bool fpsToggleButton;
        [SerializeField] bool enableCPUButton;
        public void ToggleButton()
        {
            isOn = !isOn;
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
    }
}

