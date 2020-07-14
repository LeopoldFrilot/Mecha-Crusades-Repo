using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FightingGame.Scene
{
    public class SceneSwitcher : MonoBehaviour
    {
        public void LoadFirstScene()
        {
            SceneManager.LoadScene(0);
        }
        public void LoadNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        public void LoadWinScene()
        {
            LoadNextScene();    // Temporary
        }
        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void Quit()
        {
            Application.Quit();
        }
    }
}

