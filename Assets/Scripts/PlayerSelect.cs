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
    }
}

