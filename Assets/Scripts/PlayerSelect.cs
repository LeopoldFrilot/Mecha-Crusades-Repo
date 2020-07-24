using FightingGame.AI;
using FightingGame.Player;
using FightingGame.Scene;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FightingGame
{
    public class PlayerSelect : MonoBehaviour
    {
        public GameObject Player1 { get => GetComponent<GameSetup>().Player1; }
        public GameObject Player2 { get => GetComponent<GameSetup>().Player2; }
        public GameObject GetOtherPlayer(GameObject player)
        {
            if(player == Player1)
            {
                return Player2;
            }
            if (player == Player2)
            {
                return Player1;
            }
            Debug.Log("No player found");
            return null;
        }
    }
}

