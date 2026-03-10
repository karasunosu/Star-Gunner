using UnityEngine;

// Dat trong cac nhan vat co mau (player, enemy)

public class Health : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] ParticleSystem hitParticle;

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public int GetHealth()
    {
        return hp;
    }

    public void PlayHitParticle()
    {
        if(hitParticle != null)
        {
            ParticleSystem particle = Instantiate(hitParticle, transform.position, Quaternion.identity);
            Destroy(particle, particle.main.duration + particle.main.startLifetime.constantMax);
        }
    }
}
