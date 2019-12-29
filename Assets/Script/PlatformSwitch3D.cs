using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSwitch3D : MonoBehaviour
{
    public GameObject cameraOff,cameraOn;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        cameraOff.SetActive(false);
        cameraOn.SetActive(true);
    }
}
