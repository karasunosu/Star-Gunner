using System.Collections;
using UnityEngine;

// dat o camera
// chi shake khi player bi tru mau 

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 0.3f;
    [SerializeField] float shakeMagnitude = 0.3f; // muc do rung

    Vector3 initialPos;

    void Start()
    {
        initialPos = transform.position;
    }

    public void Play()
    {
        StartCoroutine(ShakeCam());   
    }

    IEnumerator ShakeCam()
    {
        float time = 0;

        while(time < shakeDuration)
        {
            time += Time.deltaTime;
            transform.position = initialPos + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            yield return new WaitForEndOfFrame();
        } 

        transform.position = initialPos;
    }
}
