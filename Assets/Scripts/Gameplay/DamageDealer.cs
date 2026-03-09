using Unity.VisualScripting;
using UnityEngine;

// dat o nhung noi gay sat thuong (projectile, enemy, player (va cham voi enemy))

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Health hp = collision.GetComponent<Health>();

        if(hp != null)
        {
            hp.TakeDamage(damage);
            Destroy(gameObject); // projectile (cai nao khong co hp)
        }
    }
}
