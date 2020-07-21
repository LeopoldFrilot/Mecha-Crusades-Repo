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
        [SerializeField] bool FPSToggleButton;
        public void ToggleButton()
        {
            isOn = !isOn;
            if (isOn)
            {
                if (FPSToggleButton) SceneStatics.ShowFPS = true;
                GetComponent<Image>().color = onColor;
            }
            else
            {
                if (FPSToggleButton) SceneStatics.ShowFPS = false;
                GetComponent<Image>().color = Color.white;
            }
        }
    }
}

