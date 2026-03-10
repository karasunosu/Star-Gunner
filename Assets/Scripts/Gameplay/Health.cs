using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

// Dat trong cac nhan vat co mau (player, enemy)

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int hp;

    // UI
    [SerializeField] ParticleSystem hitParticle;
    [SerializeField] bool applyCamShake;
    CameraShake cam;
    AudioManager audioManager;

    // Score 
    ScoreValue scoreValue;
    ScoreKeeper scoreKeeper;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraShake>();
        audioManager = FindFirstObjectByType<AudioManager>();
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        scoreValue = GetComponent<ScoreValue>();
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
        if (isPlayer)
        {
            print("game over");
        }
        else
        {
            scoreKeeper.AddScore(scoreValue.GetScoreValue());
        }
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
