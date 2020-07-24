using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FightingGame.Scene
{
    public class SceneSwitcher : MonoBehaviour
    {
        [SerializeField] GameSounds gS;

        public GameSounds GS { get => gS; set => gS = value; }

        public void LoadFirstScene()
        {
            SceneManager.LoadScene(0);
        }
        public void LoadNextScene()
        {
            if (SceneManager.GetActiveScene().buildIndex != 0) StartCoroutine(LoadNextSceneWithAudio(GS.NextSceneTransitionSound));
            else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        public void LoadWinScene()
        {
            StartCoroutine(LoadWinSceneWithAudio(GS.WinScreenTransitionSound));
        }
        public void ReloadScene()
        {
            StartCoroutine(ReloadSceneWithAudio(GS.ResetSceneTransitionSound));
        }
        public void Quit()
        {
            Application.Quit();
        }
        IEnumerator LoadNextSceneWithAudio(AudioClip clip)
        {
            PlayClip(clip, 1f);
            yield return new WaitForSeconds(.7f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        IEnumerator LoadWinSceneWithAudio(AudioClip clip)
        {
            PlayClip(clip, 1f);
            yield return new WaitForSeconds(.9f);
            Destroy(GameObject.Find("MusicPlayer"));
            SceneManager.LoadScene("Winner");
        }
        IEnumerator ReloadSceneWithAudio(AudioClip clip)
        {
            PlayClip(clip, 1f);
            yield return new WaitForSeconds(.7f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void PlayClip(AudioClip clip, float volume)
        {
            FindObjectOfType<AudioSource>().PlayOneShot(clip, volume);
        }
    }
}

