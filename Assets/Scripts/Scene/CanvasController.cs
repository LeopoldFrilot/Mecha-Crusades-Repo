using FightingGame.AI;
using FightingGame.Player;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

namespace FightingGame.Scene
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField] GameObject FPSTracker;
        [SerializeField] GameObject momentumSliderP1;
        [SerializeField] GameObject healthSliderP1;
        [SerializeField] GameObject p1WinCounter;
        [SerializeField] GameObject momentumSliderP2;
        [SerializeField] GameObject healthSliderP2;
        [SerializeField] GameObject p2WinCounter;
        [SerializeField] GameObject roundDisplay;
        [SerializeField] GameObject pauseMenu;
        [SerializeField] GameObject gameScreen;
        GeneralPlayerController PCP1;
        GeneralPlayerController PCP2;
        
        public void Start()
        {
            PCP1 = GetComponent<PlayerSelect>().Player1.GetComponent<GeneralPlayerController>();
            PCP2 = GetComponent<PlayerSelect>().Player2.GetComponent<GeneralPlayerController>();
            StartCoroutine(ShowFPS());
        }
        public void Update()
        {
            UpdateMomentum();
            UpdateHealth();
        }

        private void UpdateMomentum()
        {
            momentumSliderP1.GetComponent<Slider>().value = PCP1.Momentum / PCP1.CD.MaxMomentum;
            momentumSliderP2.GetComponent<Slider>().value = PCP2.Momentum / PCP2.CD.MaxMomentum;
        }
        private void UpdateHealth()
        {
            healthSliderP1.GetComponent<Slider>().value = (float)PCP1.Health / (float)PCP1.CD.MaxHealth;
            healthSliderP2.GetComponent<Slider>().value = (float)PCP2.Health / (float)PCP2.CD.MaxHealth;
        }

        IEnumerator ShowFPS()
        {
            while (true)
            {
                FPSTracker.GetComponent<Text>().text = "FPS: " + (Mathf.RoundToInt(1f / Time.deltaTime)).ToString();
                yield return new WaitForSeconds(.2f);
            }
        }
        public void UpdateRound(int num)
        {
            roundDisplay.GetComponent<TextMeshProUGUI>().text = "ROUND " + num;
        }
        public void UpdateWins(int p1Wins, int p2Wins)
        {
            p1WinCounter.GetComponent<Slider>().value = p1Wins;
            p2WinCounter.GetComponent<Slider>().value = p2Wins;
        }
        public void TogglePause()
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            gameScreen.SetActive(!gameScreen.activeSelf);
            ToggleInputsAndCPU(PCP1.gameObject);
            ToggleInputsAndCPU(PCP2.gameObject);
        }
        public void ToggleDevMode()
        {
            FindObjectOfType<DeveloperMode>().ToggleDevMode();
        }
        public void ToggleAI()
        {
            FindObjectOfType<PrimitiveAI>().ToggleAI();
        }
        public void ToggleInputsAndCPU(GameObject player)
        {
            if (player.GetComponent<PrimitiveAI>())
            {
                player.GetComponent<PrimitiveAI>().ToggleAI();
            }
            else
            {
                player.GetComponent<InputReader>().enabled = !player.GetComponent<InputReader>().enabled;
            }
        }
    }
}

