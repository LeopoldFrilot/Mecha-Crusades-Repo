using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "New Character Attack")] // Allows for a right-click in the asset folder to create a new one
public class CharacterAttack : ScriptableObject
{
    [SerializeField] float damage;
    [SerializeField] Vector2 knockback;
    [SerializeField] int hitstun;
    [SerializeField] int blockstun;
    [Header("Projectile?")]
    [SerializeField] bool hasProjectile;
    [SerializeField] GameObject projectile;


    public float Damage { get => damage; set => damage = value; }
    public Vector2 Knockback { get => knockback; set => knockback = value; }
    public int Hitstun { get => hitstun; set => hitstun = value; }
    public int Blockstun { get => blockstun; set => blockstun = value; }
    public bool HasProjectile { get => hasProjectile; set => hasProjectile = value; }
    public GameObject Projectile { get => projectile; set => projectile = value; }
}
