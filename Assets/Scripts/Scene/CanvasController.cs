using FightingGame.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

namespace FightingGame.Scene
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField] GameObject aerialOptionsCounter;
        [SerializeField] GameObject FPSTracker;
        [SerializeField] GameObject momentumSlider;
        GeneralPlayerController PC;
        
        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
            StartCoroutine(ShowFPS());
        }
        public void Update()
        {
            aerialOptionsCounter.GetComponent<Text>().text = (PC.CD.MaxMidairOptions - PC.MidairOptionsCount).ToString();
            momentumSlider.GetComponent<Slider>().value = (PC.Momentum) / PC.CD.MaxMomentum;
        }
        IEnumerator ShowFPS()
        {
            while (true)
            {
                FPSTracker.GetComponent<Text>().text = "FPS: " + ((int)(1f / Time.deltaTime)).ToString();
                yield return new WaitForSeconds(.2f);
            }
        }
    }
}

