using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FightingGame.Scene
{
    static public class SceneStatics
    {
        private static GameObject player1;
        private static bool isP1CPU;
        private static GameObject player2;
        private static bool isP2CPU;
        private static int round = 1;
        private static int p1Wins = 0;
        private static int p2Wins = 0;
        private static string setWinner;
        private static bool showFPS;
        public static int Round { get => round; set => round = value; }
        public static int P1Wins { get => p1Wins; set => p1Wins = value; }
        public static int P2Wins { get => p2Wins; set => p2Wins = value; }
        public static string SetWinner { get => setWinner; set => setWinner = value; }
        public static GameObject Player1 { get => player1; set => player1 = value; }
        public static GameObject Player2 { get => player2; set => player2 = value; }
        public static bool IsP1CPU { get => isP1CPU; set => isP1CPU = value; }
        public static bool IsP2CPU { get => isP2CPU; set => isP2CPU = value; }
        public static bool ShowFPS { get => showFPS; set => showFPS = value; }
    }
}

