using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileAttack", menuName = "New Projectile Attack")] // Allows for a right-click in the asset folder to create a new one
public class ProjectileAttack : ScriptableObject
{
    [SerializeField] float maxLifespan;
    [SerializeField] float pojDamage;
    [SerializeField] Vector2 projKnockback;
    [SerializeField] int projHitstun;
    [SerializeField] int projBlockstun;
    [SerializeField] float speed;

    public float MaxLifespan { get => maxLifespan; set => maxLifespan = value; }
    public float PojDamage { get => pojDamage; set => pojDamage = value; }
    public Vector2 ProjKnockback { get => projKnockback; set => projKnockback = value; }
    public int ProjHitstun { get => projHitstun; set => projHitstun = value; }
    public int ProjBlockstun { get => projBlockstun; set => projBlockstun = value; }
    public float Speed { get => speed; set => speed = value; }
}
