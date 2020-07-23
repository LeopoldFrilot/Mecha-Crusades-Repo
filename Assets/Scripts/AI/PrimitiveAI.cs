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
        [SerializeField] bool isActive = true;
        string[] emoStates = { "Aggressive", "Defensive", "Neutral" };
        [SerializeField] string emoState;
        [SerializeField] int neutralThreshold = 50;
        [SerializeField] float distFromOpp;

        private void Start()
        {
            PC = GetComponent<GeneralPlayerController>();
            PS = FindObjectOfType<PlayerSelect>();
            IM = GetComponent<InputManager>();
            GetComponent<InputReader>().enabled = false;
            Opponent = PS.GetOtherPlayer(gameObject);
            OPC = Opponent.GetComponent<GeneralPlayerController>();
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
        public void StandNeutral()
        {
            IM.Neutral("Horizontal");
            IM.Neutral("Vertical");
        }
        public void Forward()
        {
            if ((Opponent.transform.position.x - transform.position.x) >= Mathf.Epsilon)
            {
                IM.Right();
            }
            else
            {
                IM.Left();
            }
        }
        public void Backward()
        {
            if ((Opponent.transform.position.x - transform.position.x) >= Mathf.Epsilon)
            {
                IM.Left();
            }
            else
            {
                IM.Right();
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
            Jump();
            IM.LightAttack();
        }
        public void MediumAttack()
        {
            Forward();
            IM.MediumAttack();
        }
        public void MediumAerial()
        {
            Jump();
            IM.MediumAttack();
        }
        public void HeavyAttack()
        {
            Forward();
            IM.HeavyAttack();
        }
        public void HeavyAerial()
        {
            Jump();
            IM.HeavyAttack();
        }
        public void TurnOffAI()
        {
            IsActive = false;
        }
        public void TurnOnAI()
        {
            IsActive = true;
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
