using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "New Character Attack")] // Allows for a right-click in the asset folder to create a new one
public class CharacterAttack : ScriptableObject
{
    [SerializeField] string triggerWord;
    [SerializeField] int damage;
    [SerializeField] Vector2 knockback;
    [SerializeField] int startupFrames;
    [SerializeField] int activeFrames;
    [SerializeField] int recoveryFrames;
    [SerializeField] int hitstun;
    [SerializeField] int blockstun;
    [Header("Projectile?")]
    [SerializeField] bool hasProjectile;
    [SerializeField] GameObject projectile;

    public int GetMoveLength()
    {
        return startupFrames + activeFrames + recoveryFrames;
    }
    public int Damage { get => damage; set => damage = value; }
    public Vector2 Knockback { get => knockback; set => knockback = value; }
    public int StartupFrames { get => startupFrames; set => startupFrames = value; }
    public int ActiveFrames { get => activeFrames; set => activeFrames = value; }
    public int RecoveryFrames { get => recoveryFrames; set => recoveryFrames = value; }
    public int Hitstun { get => hitstun; set => hitstun = value; }
    public int Blockstun { get => blockstun; set => blockstun = value; }
    public bool HasProjectile { get => hasProjectile; set => hasProjectile = value; }
    public GameObject Projectile { get => projectile; set => projectile = value; }
}
