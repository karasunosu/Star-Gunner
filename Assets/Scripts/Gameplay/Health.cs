using UnityEngine;

// Dat trong cac nhan vat co mau (player, enemy)

public class Health : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] ParticleSystem hitParticle;

    [SerializeField] bool applyCamShake;
    CameraShake cam;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraShake>();
    }

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

    public void ShakeCam()
    {
        if (applyCamShake)
        {
            cam.Play();
        }
    }
}
