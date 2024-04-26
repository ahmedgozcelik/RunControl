using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    public Transform target;
    public Vector3 target_offSet; //kamera ile karakter arasý mesafe
    public GameObject KameraYeniPoz;
    public bool SonaGelindiMiKamera;
    void Start()
    {
        target_offSet = transform.position - target.position;
    }

    private void LateUpdate()
    {
        if (SonaGelindiMiKamera == false)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + target_offSet, 0.125f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, KameraYeniPoz.transform.position, 0.015f);
        }
    }
}
