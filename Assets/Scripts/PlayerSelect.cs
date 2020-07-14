using FightingGame.AI;
using FightingGame.Player;
using FightingGame.Scene;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FightingGame
{
    public class PlayerSelect : MonoBehaviour
    {
        [SerializeField] GameObject player1;
        [SerializeField] GameObject player2;
        
        public void Awake()
        {
            if(SceneStatics.Player1 && SceneStatics.Player2)
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
        private void DestroyCharacters()
        {
            var characters = FindObjectsOfType<GeneralPlayerController>();
            if(characters.Count() > 0)
            {
                foreach (GeneralPlayerController character in characters)
                {
                    Destroy(character.gameObject);
                }
            }
        }
        private void BuildCharacters()
        {
            player1 = Instantiate(SceneStatics.Player1, new Vector3(-7, -3), Quaternion.identity) as GameObject;
            player1.name = player1.GetComponent<GeneralPlayerController>().CD.CharName;
            player2 = Instantiate(SceneStatics.Player2, new Vector3(7, -3), Quaternion.identity) as GameObject;
            player2.name = player2.GetComponent<GeneralPlayerController>().CD.CharName;
            if(player1.name == player2.name)
            {
                player2.GetComponent<SpriteRenderer>().color = Color.red;
            }
            if (SceneStatics.IsP1CPU)
            {
                player1.AddComponent<PrimitiveAI>();
                player1.AddComponent<AIBehavior>();
                player1.name += " CPU";
            }
            if (SceneStatics.IsP2CPU)
            {
                player2.AddComponent<PrimitiveAI>();
                player2.AddComponent<AIBehavior>();
                player2.name += " CPU";
            }
        }
        public GameObject Player1 { get => player1; private set => player1 = value; }
        public GameObject Player2 { get => player2; private set => player2 = value; }
        public GameObject GetOtherPlayer(GameObject player)
        {
            if(player == Player1)
            {
                return Player2;
            }
            if (player == Player2)
            {
                return Player1;
            }
            Debug.Log("No player found");
            return null;
        }
    }
}

