using FightingGame.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.AI
{
    public class PrimitiveAI : MonoBehaviour
    {
        PlayerSelect PS;
        //FrameTest FT;
        [SerializeField] GameObject opponent;
        [SerializeField] float defSpeed = 0f;
        float speed;
        SpriteRenderer renderer;
        private void Start()
        {
            PS = FindObjectOfType<PlayerSelect>();
            //FT = FindObjectOfType<FrameTest>();
            opponent = PS.GetOtherPlayer(gameObject);
            renderer = gameObject.GetComponent<SpriteRenderer>();
            speed = defSpeed;
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
        }
        public void ToggleAI()
        {
            if(speed == defSpeed)
            {
                speed = 1000f;
                renderer.enabled = false;
            }
            else
            {
                speed = defSpeed;
                renderer.enabled = true;
            }
        }
    }
}
