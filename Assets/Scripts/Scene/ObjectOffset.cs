using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Scene
{
    public class ObjectOffset : MonoBehaviour
    {
        [SerializeField] float speed = -.1f;
        public void Update()
        {
            MoveOffset();
        }
        private void MoveOffset()
        {
            var renderer = GetComponent<Renderer>();
            renderer.material.mainTextureOffset += new Vector2(Time.deltaTime * speed, 0);
        }
    }
}

