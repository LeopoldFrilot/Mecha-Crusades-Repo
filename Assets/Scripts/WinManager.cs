using FightingGame.Player;
using FightingGame.Scene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame
{
    public class WinManager : MonoBehaviour
    {
        [SerializeField] int maxWins = 3;
        bool win = false;
        public void Start()
        {
            FindObjectOfType<CanvasController>().UpdateRound(SceneStatics.Round);
        }
        public void ManageWin(GameObject winner, GameObject loser)
        {
            ManageWinner(winner);
            ManageLoser(loser);
            
            SceneStatics.Round++;
            
            if (win == true)
            {
                GameOver(winner);
            }
            else
            {
                FindObjectOfType<SceneSwitcher>().ReloadScene();
            }

        }

        private void ManageWinner(GameObject winner)
        {
            var PC = winner.GetComponent<GeneralPlayerController>();
            Debug.Log("The winner is " + winner.name);
            //PC.PlayerAnimator.SetTrigger("win");
            PC.Wins++;
            if (SceneStatics.Round >= maxWins)
            {
                win = true;
            }
        }
        private static void ManageLoser(GameObject loser)
        {
            var PC = loser.GetComponent<GeneralPlayerController>();
            Debug.Log("The loser is " + loser.name);
            //PC.PlayerAnimator.SetTrigger("lose");
        }
        public void ResetRoundCounter()
        {
            SceneStatics.Round = 1;
            FindObjectOfType<CanvasController>().UpdateRound(SceneStatics.Round);
        }
        private void GameOver(GameObject winner)
        {
            ResetRoundCounter();
            Debug.Log("Loading Win");
            Destroy(GameObject.Find("MusicPlayer"));
            FindObjectOfType<SceneSwitcher>().LoadWinScene(winner.name);
        }
    }
}