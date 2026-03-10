using UnityEngine;

// Dat trong cac nhan vat co mau (player, enemy)

public class Health : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] ParticleSystem hitParticle;

    [SerializeField] bool applyCamShake;
    CameraShake cam;

    AudioManager audioManager;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraShake>();
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        PlayHitParticle();
        ShakeCam();
        audioManager.PlayDamagedSFX();

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

    void PlayHitParticle()
    {
        if(hitParticle != null)
        {
            ParticleSystem particle = Instantiate(hitParticle, transform.position, Quaternion.identity);
            Destroy(particle, particle.main.duration + particle.main.startLifetime.constantMax);
        }
    }

    void ShakeCam()
    {
        if (applyCamShake)
        {
            cam.Play();
        }
    }
}
