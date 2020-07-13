using FightingGame.Player;
using FightingGame.Player.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.AI
{
    public class PrimitiveAI : MonoBehaviour
    {
        PlayerSelect PS;
        GeneralPlayerController PC, OPC;
        InputManager IM;
        [SerializeField] GameObject opponent;
        [SerializeField] bool isActive = false;
        string[] emoStates = { "Aggressive", "Defensive", "Neutral" };
        [SerializeField] string emoState;
        [SerializeField] int neutralThreshold = 50;
        [SerializeField] float distFromOpp;

        private void Awake()
        {
            PC = GetComponent<GeneralPlayerController>();
            PS = FindObjectOfType<PlayerSelect>();
            Opponent = PS.GetOtherPlayer(gameObject);
            OPC = Opponent.GetComponent<GeneralPlayerController>();
            IM = GetComponent<InputManager>();
            ToggleAI();
        }
        private void Update()
        {
            ManageState();
            UpdateDistance();
        }

        private void ManageState()
        {
            if (!IsActive) return;
            if (Mathf.Abs(PC.Health - OPC.Health) <= neutralThreshold)
            {
                EmoState = emoStates[2];
            }
            else if (PC.Health > OPC.Health)
            {
                EmoState = emoStates[1]; // Defensive when winning
            }
            else
            {
                EmoState = emoStates[0];
            }
        }
        public void Forward()
        {
            if (Opponent.transform.position.x < transform.position.x)
            {
                IM.Left();
            }
            else
            {
                IM.Right();
            }
        }
        public void Backward()
        {
            if (Opponent.transform.position.x < transform.position.x)
            {
                IM.Right();
            }
            else
            {
                IM.Left();
            }
        }
        public void Jump()
        {
            Forward();
            IM.Jump();
        }
        public void DashForward()
        {
            Forward();
            IM.Dash();
        }
        public void DashAway()
        {
            Backward();
            IM.Dash();
        }
        public void LightAttack()
        {
            Forward();
            IM.LightAttack();
        }
        public void LightAerial()
        {
            Forward();
            IM.LightAttack();
        }
        public void MediumAttack()
        {
            Forward();
            IM.MediumAttack();
        }
        public void MediumAerial()
        {
            Forward();
            IM.MediumAttack();
        }
        public void HeavyAttack()
        {
            Forward();
            IM.HeavyAttack();
        }
        public void ToggleAI()
        {
            IsActive = !IsActive;
            if (!IsActive)
            {
                GetComponent<InputReader>().enabled = true;
            }
            else
            {
                GetComponent<InputReader>().enabled = false;
            }
        }
        private void UpdateDistance()
        {
            DistFromOpp = Mathf.Abs(transform.position.x - Opponent.transform.position.x);
        }
        public GameObject Opponent { get => opponent; set => opponent = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public string EmoState { get => emoState; set => emoState = value; }
        public float DistFromOpp { get => distFromOpp; set => distFromOpp = value; }
    }
}
