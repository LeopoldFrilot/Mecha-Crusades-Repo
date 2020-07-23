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
        [SerializeField] GameObject WinnerDisplay;
        GeneralPlayerController PCP1;
        GeneralPlayerController PCP2;
        SceneSwitcher SS;
        
        public void Start()
        {
            if (GetComponent<PlayerSelect>())
            {
                PCP1 = GetComponent<PlayerSelect>().Player1.GetComponent<GeneralPlayerController>();
                PCP2 = GetComponent<PlayerSelect>().Player2.GetComponent<GeneralPlayerController>();
            }
            if(FPSTracker)StartCoroutine(ShowFPS());
            ShowWin();
            SS = FindObjectOfType<SceneSwitcher>(); // Used to manage Audioclips
        }
        public void Update()
        {
            UpdateMomentum();
            UpdateHealth();
            
        }
        private void ShowWin()
        {
            if (!WinnerDisplay) return;
            WinnerDisplay.GetComponent<Text>().text = SceneStatics.SetWinner + " Wins!";
        }

        private void UpdateMomentum()
        {
            if (!momentumSliderP1 || !momentumSliderP2) return;
            momentumSliderP1.GetComponent<Slider>().value = (PCP1.Momentum - 1f) / (PCP1.CD.MaxMomentum - 1f);
            momentumSliderP2.GetComponent<Slider>().value = (PCP2.Momentum - 1f) / (PCP2.CD.MaxMomentum - 1f);
        }
        private void UpdateHealth()
        {
            if (!healthSliderP1 || !healthSliderP2) return;
            healthSliderP1.GetComponent<Slider>().value = (float)PCP1.Health / (float)PCP1.CD.MaxHealth;
            healthSliderP2.GetComponent<Slider>().value = (float)PCP2.Health / (float)PCP2.CD.MaxHealth;
        }

        IEnumerator ShowFPS()
        {
            while (SceneStatics.ShowFPS)
            {
                FPSTracker.GetComponent<Text>().text = "FPS: " + (Mathf.RoundToInt(1f / Time.deltaTime)).ToString();
                yield return new WaitForSeconds(.2f);
            }
        }
        public void UpdateRound(int num)
        {
            if (!roundDisplay) return;
            roundDisplay.GetComponent<TextMeshProUGUI>().text = "ROUND " + num;
        }
        public void UpdateWins(int p1Wins, int p2Wins)
        {
            if (!p1WinCounter || !p2WinCounter) return;
            p1WinCounter.GetComponent<Slider>().value = p1Wins;
            p2WinCounter.GetComponent<Slider>().value = p2Wins;
        }
        public void PauseScreen()
        {
            SS.PlayClip(SS.GS.PauseSound, 1f);
            if (gameScreen) gameScreen.SetActive(false);
            if (pauseMenu) pauseMenu.SetActive(true);
            if (PCP1) TurnOffPlayer(PCP1.gameObject);
            if (PCP2) TurnOffPlayer(PCP2.gameObject);
        }
        public void ResumeScreen()
        {
            SS.PlayClip(SS.GS.ResumeSound, 1f);
            if (gameScreen) gameScreen.SetActive(true);
            if (pauseMenu) pauseMenu.SetActive(false);
            if (PCP1) TurnOnPlayer(PCP1.gameObject);
            if (PCP2) TurnOnPlayer(PCP2.gameObject);
        }
        
        public void TurnOffPlayer(GameObject player)
        {
            player.GetComponent<InputReader>().enabled = false;
            if (player.GetComponent<PrimitiveAI>())
            {
                player.GetComponent<PrimitiveAI>().TurnOffAI();
            }
        }
        public void TurnOnPlayer(GameObject player)
        {
            player.GetComponent<InputReader>().enabled = true;
            if (player.GetComponent<PrimitiveAI>() && SceneStatics.IsCPUActive)
            {
                player.GetComponent<PrimitiveAI>().TurnOnAI();
            }
        }
        public void ToggleCPUs()
        {
            var AIs = FindObjectsOfType<PrimitiveAI>();
            if (AIs.Length > 0)
            {
                SceneStatics.IsCPUActive = !SceneStatics.IsCPUActive;
            }
        }
        public void ToggleDevMode()
        {
            if (!FindObjectOfType<DeveloperMode>()) return;
            foreach (DeveloperMode devMode in FindObjectsOfType<DeveloperMode>())
            {
                devMode.ToggleDevMode();
            }
        }
    }
}

