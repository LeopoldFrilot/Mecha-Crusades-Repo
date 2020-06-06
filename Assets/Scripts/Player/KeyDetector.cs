using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player
{
    public class KeyDetector : MonoBehaviour
    {
        public void Update()
        {
            DetectKey();
        }
        public void DetectKey()
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

