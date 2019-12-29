using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeFrequency;
    public bool startShake;
    float shakeTimer;
    public void BeginShake()
    {
        startShake = !startShake;      
        if (!startShake)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    public void ShakeCamera()
    {
        transform.rotation = Quaternion.Euler(Random.Range(-150, 150) * Time.deltaTime , Random.Range(-150, 150) * Time.deltaTime, 0) ;
    }
    private void Update()
    {
        if (startShake)
        {
            if (Time.time - shakeTimer > shakeFrequency)
            {
                ShakeCamera();
                shakeTimer = Time.time;
                
            }
        }
    }
}
