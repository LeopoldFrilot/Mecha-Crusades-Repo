using FightingGame.Player;
using FightingGame.Scene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame
{
    public class WinManager : MonoBehaviour
    {
        CanvasController CC;
        [SerializeField] int maxWins = 3;
        bool win = false;
        bool roundOver = false;
        public void Start()
        {
            CC = FindObjectOfType<CanvasController>();
            CC.UpdateRound(SceneStatics.Round);
            CC.UpdateWins(SceneStatics.P1Wins, SceneStatics.P2Wins);
        }
        public void ManageRoundOver(GameObject winner, GameObject loser)
        {
            if (roundOver) return;
            roundOver = true;
            ManageWinner(winner);
            ManageLoser(loser);
            SceneStatics.Round++;
            CC.TurnOffPlayer(winner);
            CC.TurnOffPlayer(loser);
            StartCoroutine(Transition());

        }
        private void ManageWinner(GameObject winner)
        {
            var PC = winner.GetComponent<GeneralPlayerController>();
            //PC.PlayerAnimator.SetTrigger("win");
            if(GetComponent<PlayerSelect>().Player1 == winner)
            {
                SceneStatics.P1Wins++;
            }
            else
            {
                SceneStatics.P2Wins++;
            }
            if (SceneStatics.P1Wins >= maxWins || SceneStatics.P2Wins >= maxWins)
            {
                win = true;
                SceneStatics.SetWinner = winner.name;
            }
        }
        private static void ManageLoser(GameObject loser)
        {
            var PC = loser.GetComponent<GeneralPlayerController>();
            //PC.PlayerAnimator.SetTrigger("lose");
        }
        IEnumerator Transition()
        {
            CC.UpdateWins(SceneStatics.P1Wins, SceneStatics.P2Wins);
            yield return new WaitForSeconds(2f);
            if (win == true)
            {
                GameOver();
            }
            else
            {
                FindObjectOfType<SceneSwitcher>().ReloadScene();
            }
        }
        public void ResetGame()
        {
            SceneStatics.Round = 1;
            SceneStatics.P1Wins = 0;
            SceneStatics.P2Wins = 0;
        }
        private void GameOver()
        {
            ResetGame();
            FindObjectOfType<SceneSwitcher>().LoadWinScene();
        }
    }
}