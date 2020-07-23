using FightingGame.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Level
{
    public class BlastZone : MonoBehaviour
    {
        [SerializeField] AudioClip explosionClip;
        public void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.GetComponent<Rigidbody2D>().velocity.x);
            FindObjectOfType<AudioSource>().PlayOneShot(explosionClip);
            collision.GetComponent<GeneralPlayerController>().DamagePlayer(999999999);
        }
    }
}

