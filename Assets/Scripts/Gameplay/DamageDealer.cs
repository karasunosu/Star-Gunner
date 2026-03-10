using Unity.VisualScripting;
using UnityEngine;

// dat o nhung noi gay sat thuong (projectile, enemy, player (va cham voi enemy))

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage;

    [SerializeField] bool isProjectile;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Health hp = collision.GetComponent<Health>(); // enemy/player

        if(hp != null) // object dang chua file la projectile
        {
            hp.TakeDamage(damage);
            hp.PlayHitParticle();
            hp.ShakeCam();

            if (isProjectile)
            {
                Destroy(gameObject); // projectile (cai nao khong co hp)
            }
        }
    }
}
