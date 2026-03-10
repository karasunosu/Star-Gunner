using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting SFX")]
    [SerializeField] AudioClip shootAudio;
    [SerializeField] [Range(0, 1)] float shootVolume = 1f;

    [Header("Damage SFX")]
    [SerializeField] AudioClip damagedAudio;
    [SerializeField] [Range(0, 1)] float damageVolume = 1f;

    public void PlayShootSFX()
    {
        PlaySFX(shootAudio, shootVolume);
    }

    public void PlayDamagedSFX()
    {
        PlaySFX(damagedAudio, damageVolume);
    }

    void PlaySFX(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }
}
