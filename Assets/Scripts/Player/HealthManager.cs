using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player
{
    public class HealthManager : MonoBehaviour
    {
        GeneralPlayerController PC;
        public void Start()
        {
            PC = GetComponent<GeneralPlayerController>();
            PC.Health = PC.CD.MaxHealth;
            //Debug.Log(gameObject.name + " has " + PC.Health + " health");
        }
        
    }
}

