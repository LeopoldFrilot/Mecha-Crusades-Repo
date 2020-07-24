using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FightingGame.Scene
{
    public class BackgroundNoise : MonoBehaviour
    {
        [SerializeField] AudioClip audioClip;
        [SerializeField] AudioSource audioSource;
        public void Awake()
        {
            audioSource = FindObjectOfType<AudioSource>();
        }

        public void PlayClip(float volume)
        {
            FindObjectOfType<SceneSwitcher>().PlayClip(audioClip, volume);
        }
        public void StopAudio()
        {
            audioSource.Stop();
        }
        public void LoadIntro()
        {
            FindObjectOfType<SceneSwitcher>().LoadNextScene();
        }
    }
}

