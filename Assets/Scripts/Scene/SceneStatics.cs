using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FightingGame.Scene
{
    static public class SceneStatics
    {
        private static int round = 1;
        private static int p1Wins = 0;
        private static int p2Wins = 0;
        private static GameObject setWinner;
        public static int Round { get => round; set => round = value; }
        public static int P1Wins { get => p1Wins; set => p1Wins = value; }
        public static int P2Wins { get => p2Wins; set => p2Wins = value; }
        public static GameObject SetWinner { get => setWinner; set => setWinner = value; }
    }
}

