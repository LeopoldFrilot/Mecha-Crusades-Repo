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

        Coroutine test;
        
        public void Start()
        {
            PC = FindObjectOfType<GeneralPlayerController>();
        }
        public void Update()
        {
            aerialOptionsCounter.GetComponent<Text>().text = (PC.MaxMidairOptions - PC.MidairOptionsCount).ToString();
            FPSUpdate();
        }
        private void FPSUpdate()
        {
            StartCoroutine(ShowFPS());
        }
        IEnumerator ShowFPS()
        {
            while (true)
            {
                FPSTracker.GetComponent<Text>().text = "FPS: " + ((int)(1f / Time.deltaTime)).ToString();
                yield return new WaitForSeconds(1f);
            }
        }
    }
}

