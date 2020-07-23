using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Player.Attack
{
    public class AttacksController : MonoBehaviour
    {
        GeneralPlayerController PC;
        Collider2D hitbox;
        GameObject attack;
        Attack attackRef;
        string curMove;
        [SerializeField] List<AudioClip> audioClips = new List<AudioClip>();

        public void Start()
        {
            PC = transform.parent.GetComponent<GeneralPlayerController>();
        }

        public void StartMove(string name)
        {
            curMove = name;
            attack = transform.Find(curMove).gameObject;
            attackRef = attack.GetComponent<Attack>();
            PC.Lag(attackRef.CA.GetMoveLength(), "recovery");
        }
        public void ActivateAttack()
        {
            hitbox = attack.GetComponent<Collider2D>();
            if (hitbox.enabled) DeactivateAllAttacks();
            else hitbox.enabled = true;
            if (attackRef.CA.HasProjectile == true && hitbox.enabled)
            {
                var projectile = Instantiate(attackRef.CA.Projectile, PC.ProjectileLocation.transform.position, Quaternion.identity);
                projectile.transform.parent = PC.Player.transform;
            }
        }
        public void DeactivateAllAttacks()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var attack = transform.GetChild(i);
                attack.GetComponent<Attack>().Hit = 0;
                Collider2D collider = attack.GetComponent<Collider2D>();
                if (collider.enabled)
                {
                    collider.enabled = false;
                }
            }
        }
        public void PlayAudioClip(int index)
        {
            if (index >= 0 && index < audioClips.Count)
            {
                FindObjectOfType<AudioSource>().PlayOneShot(audioClips[index], .5f);
            }
        }
    }
}

