using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player
{
    public class InputReader : MonoBehaviour
    {
        public void Update()
        {
            DetectButton();
        }
        public void DetectButton()
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(vKey))
                {
                    Debug.Log(vKey);
                }
            }
        }
    }
}

