using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame
{
    public class PlayerSelect : MonoBehaviour
    {
        [SerializeField] GameObject player1;
        [SerializeField] GameObject player2;

        public GameObject Player1 { get => player1; private set => player1 = value; }
        public GameObject Player2 { get => player2; private set => player2 = value; }
        public GameObject GetOtherPlayer(GameObject player)
        {
            if(player == Player1)
            {
                Debug.Log("Called " + Player2.name);
                return Player2;
            }
            if (player == Player2)
            {
                Debug.Log("Called " + Player1.name);
                return Player1;
            }
            Debug.Log("No player found");
            return null;
        }
    }
}

