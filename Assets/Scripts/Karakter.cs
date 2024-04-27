using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter : MonoBehaviour
{
    public GameManager _GameManager;
    public Kamera _Kamera;
    public GameObject KarakterYeniPoz;

    public bool SonaGelindiMiKarakter;
    private void FixedUpdate()
    {
        if (SonaGelindiMiKarakter == false)
        {
            transform.Translate(Vector3.forward * 0.5f * Time.deltaTime);
        }
    }

    void Update()
    {
        if (SonaGelindiMiKarakter == true)
        {
            transform.position = Vector3.Lerp(transform.position, KarakterYeniPoz.transform.position, .015f);
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (Input.GetAxis("Mouse X") < 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z), 0.3f);
                }
                if (Input.GetAxis("Mouse X") > 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z), 0.3f);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Carpma") || other.CompareTag("Toplama") || other.CompareTag("Cikarma") || other.CompareTag("Bolme"))
        //{
        //    int sayi = int.Parse(other.name);
        //    _GameManager.AdamYonetimi(other.tag, sayi, other.transform);
        //}

        //if (other.CompareTag("Kapi"))
        //{
        //    kapi.KapiTuruBelirle(other.transform);
        //}
        if (other.CompareTag("SonTetikleyici")) // Oyun sonu için trigger koyduðum nokta
        {
            _Kamera.SonaGelindiMiKamera = true;
            _GameManager.DusmanlariTetikle();
            SonaGelindiMiKarakter = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Direk") || collision.gameObject.CompareTag("IgneliKutu") || collision.gameObject.CompareTag("PervaneIgneler"))
        {
            //Karakterin direklere takýlma durumunun önüne geçmek için soldakine takýlmaya çalýþýrsa saða, saðdakilere takýlmaya çalýþýrsa sola atma iþlevi..
            if (transform.position.x > 0)
            {
                transform.position = new Vector3(transform.position.x - .2f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x + .2f, transform.position.y, transform.position.z);
            }
        }
    }
}
