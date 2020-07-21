﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.Attack
{
    public class Attack : MonoBehaviour
    {
        GeneralPlayerController PC;
        [SerializeField] CharacterAttack cA;
        [SerializeField] bool isAerial;
        [SerializeField] List<AudioClip> hitSounds = new List<AudioClip>();
        int hit = 0;

        public void Start()
        {
            PC = transform.parent.parent.GetComponent<GeneralPlayerController>();
        }
        public void LateUpdate()
        {
            if(isAerial && PC.IsGrounded && GetComponent<Collider2D>().enabled)
            {
                GetComponent<Collider2D>().enabled = false;
                Hit = 0;
            }
        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (Hit > 0) return;
            GameObject collidedObject = collision.gameObject;
            if (collidedObject != PC.Player)
            {
                var OtherPC = collidedObject.GetComponent<GeneralPlayerController>();
                //Debug.Log(gameObject.name + " hit: " + collision.gameObject.name);
                collidedObject.GetComponent<Rigidbody2D>().velocity = new Vector2(CA.Knockback.x * PC.DirFacing, CA.Knockback.y);
                OtherPC.Lag(CA.Hitstun, "hit");
                OtherPC.DamagePlayer(CA.Damage);
                if (hitSounds.Count > 0) PickRandomSound();
                OtherPC.DeactivateAllAttacks();
                Hit++;
            }
        }
        private void PickRandomSound()
        {
            var randInt = (int)Random.Range(0, hitSounds.Count - Mathf.Epsilon);
            FindObjectOfType<AudioSource>().PlayOneShot(hitSounds[randInt], .7f);
        }
        public CharacterAttack CA { get => cA; set => cA = value; }
        public int Hit { get => hit; set => hit = value; }
    }
}

