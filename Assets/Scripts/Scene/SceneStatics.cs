using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FightingGame.Scene
{
    static public class SceneStatics
    {
        private static int round = 1;
        public static int Round { get => round; set => round = value; }
    }
}

