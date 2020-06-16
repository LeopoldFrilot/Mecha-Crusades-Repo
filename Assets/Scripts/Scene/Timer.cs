using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FightingGame.Scene
{
    public class Timer : MonoBehaviour
    {
        float time = 0f;
        [SerializeField] float timeBeforeSceneSwitch;
        SceneSwitcher SS;
        public void Start()
        {
            SS = FindObjectOfType<SceneSwitcher>();
        }
        public void Update()
        {
            ManageTime();
        }
        private void ManageTime()
        {
            time += Time.deltaTime;
            if(time > timeBeforeSceneSwitch)
            {
                SS.LoadNextScene();
            }
        }
    }
}

