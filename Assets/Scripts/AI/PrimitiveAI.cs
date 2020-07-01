using FightingGame.Core;
using FightingGame.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.AI
{
    public class PrimitiveAI : MonoBehaviour
    {
        PlayerSelect PS;
        GeneralPlayerController PC;
        //FrameTest FT;
        [SerializeField] GameObject opponent;
        [SerializeField] float defaultSpeed = 0f;
        float speed;
        SpriteRenderer renderer;
        private void Start()
        {
            PC = GetComponent<GeneralPlayerController>();
            PS = FindObjectOfType<PlayerSelect>();
            //FT = FindObjectOfType<FrameTest>();
            opponent = PS.GetOtherPlayer(gameObject);
            renderer = gameObject.GetComponent<SpriteRenderer>();
            speed = defaultSpeed;
        }
        private void Update()
        {
            Move();
        }

        private void Move()
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(opponent.transform.position.x, transform.position.y, transform.position.z),
                step);
            if(PC.AveHorizSpeed <= Mathf.Epsilon)
            {
                PC.PlayerAnimator.SetBool("isRunning", false);
            }
            else
            {
                PC.PlayerAnimator.SetBool("isRunning", true);
            }
        }
        public void ToggleAI()
        {
            if(speed == defaultSpeed)
            {
                speed = 1000f;
                renderer.enabled = false;
            }
            else
            {
                speed = defaultSpeed;
                renderer.enabled = true;
            }
        }
    }
}
