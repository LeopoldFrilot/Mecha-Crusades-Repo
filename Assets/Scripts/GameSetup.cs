using FightingGame.AI;
using FightingGame.Player;
using FightingGame.Scene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame
{
    public class GameSetup : MonoBehaviour
    {
        [SerializeField] GameObject player1;
        [SerializeField] GameObject player2;

        float time = 0;
        [SerializeField] int index = 0;
        SceneSwitcher SS;

        public void Awake()
        {
            Application.targetFrameRate = 60;
            SS = FindObjectOfType<SceneSwitcher>();

            if (SceneStatics.Player1 && SceneStatics.Player2)
            {
                Debug.Log("Building new characters");
                DestroyCharacters();
                BuildCharacters();
            }
            else
            {
                Debug.Log("Started from versus");
            }
        }
        public void Start()
        {
            FindObjectOfType<CanvasController>().TurnOffPlayer(player1);
            FindObjectOfType<CanvasController>().TurnOffPlayer(player2);
        }
        public void Update()
        {
            StartSequence();
        }
        private void DestroyCharacters()
        {
            var characters = FindObjectsOfType<GeneralPlayerController>();
            if (characters.Length > 0)
            {
                foreach (GeneralPlayerController character in characters)
                {
                    Destroy(character.gameObject);
                }
            }
        }
        private void BuildCharacters()
        {
            Player1 = Instantiate(SceneStatics.Player1, new Vector3(-7, -3), Quaternion.identity) as GameObject;
            Player1.name = Player1.GetComponent<GeneralPlayerController>().CD.CharName;
            Player2 = Instantiate(SceneStatics.Player2, new Vector3(7, -3), Quaternion.identity) as GameObject;
            Player2.name = Player2.GetComponent<GeneralPlayerController>().CD.CharName;
            if (Player1.name == Player2.name)
            {
                Player2.GetComponent<SpriteRenderer>().color = Color.red;
            }
            if (SceneStatics.IsP1CPU)
            {
                Player1.AddComponent<PrimitiveAI>();
                Player1.AddComponent<AIBehavior>();
                Player1.name += " CPU";
            }
            if (SceneStatics.IsP2CPU)
            {
                Player2.AddComponent<PrimitiveAI>();
                Player2.AddComponent<AIBehavior>();
                Player2.name += " CPU";
            }
            Player1.name += " (P1)";
            Player2.name += " (P2)";
        }
        private void StartSequence()
        {
            if (index >= SS.GS.StartSequence.Length) return;
            float timeStep = 1.5f / 2.15f;
            GetIntoPosition(timeStep);
            if (time >= timeStep)
            {
                SS.PlayClip(SS.GS.StartSequence[index], 1f);
                index++;
                time = 0;
            }
            time += Time.deltaTime;
            if (index >= SS.GS.StartSequence.Length - 1 && time >= .3f)
            {
                FindObjectOfType<CanvasController>().ResumeMovement();
            }
        }

        private void GetIntoPosition(float timeStep)
        {
            if (index == 0 && time > timeStep - .2f)
            {
                Player1.GetComponent<InputManager>().Right();
                Player2.GetComponent<InputManager>().Left();
            }
            else if (index == 1)
            {
                Player1.GetComponent<InputManager>().Neutral("Horizontal");
                Player2.GetComponent<InputManager>().Neutral("Horizontal");
            }
        }

        public GameObject Player1 { get => player1; set => player1 = value; }
        public GameObject Player2 { get => player2; set => player2 = value; }
    }
}

