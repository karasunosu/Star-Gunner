using System.Collections;
using UnityEngine;

// dat trong cac object co the ban
// player se co 1 khoang thoi gian giua cac vien dan co dinh (khi ban lien tuc - giu nut ban)
// enemy se co cac khoang thoi gian giua cac vien dan ngau nhien

public class Shooter : MonoBehaviour
{
    [Header("Base Variables")]
    [SerializeField] GameObject pjtPrefab;
    [SerializeField] float pjtSpeed = 10f;
    [SerializeField] float pjtLifeTime = 4f;
    [SerializeField] float baseFireRate = 0.2f;

    [Header("AI Variables")] // enemy artificial intelligence
    [SerializeField] bool useEnemyAI; // if the object is player or enemy
    [SerializeField] float minFireRate = 0.1f;
    [SerializeField] float fireRateVariance = 0.3f;

    [HideInInspector] public bool isFiring;
    Coroutine fireCoroutine;

    AudioManager audioManager;

    void Start()
    {
        if (useEnemyAI)
        {
            isFiring = true;
        }

        audioManager = FindFirstObjectByType<AudioManager>();
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinously());
        }
        else if (!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    // ban dan lien tuc (khi giu nut ban)
    IEnumerator FireContinously()
    {
        while (true)
        {
            GameObject projectile = Instantiate(pjtPrefab, transform.position, Quaternion.identity);

            // huong cua vien dan = huong cua object ban no
            projectile.transform.rotation = transform.rotation;

            Rigidbody2D pjtRb = projectile.GetComponent<Rigidbody2D>();
            pjtRb.linearVelocity = transform.up * pjtSpeed; // transform.up se dieu huong theo mui ten xanh la (local) cua object 

            audioManager.PlayShootSFX();

            Destroy(projectile, pjtLifeTime);

            float waitTime = baseFireRate;
            if (useEnemyAI)
            {
                waitTime = Random.Range(baseFireRate - fireRateVariance, baseFireRate + fireRateVariance);
                waitTime = Mathf.Clamp(waitTime, minFireRate, float.MaxValue);
            }

            yield return new WaitForSeconds(waitTime);            
        }
    }
}
