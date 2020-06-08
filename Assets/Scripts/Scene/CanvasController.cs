using FightingGame.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FightingGame.Scene
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField] GameObject aerialOptionsCounter;
        [SerializeField] GameObject FPSTracker;
        GeneralPlayerController PC;
        
        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
            StartCoroutine(ShowFPS());
        }
        public void Update()
        {
            aerialOptionsCounter.GetComponent<Text>().text = (PC.MaxMidairOptions - PC.MidairOptionsCount).ToString();
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

