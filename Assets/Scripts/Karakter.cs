using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Karakter : MonoBehaviour
{
    public GameManager _GameManager;
    public Kamera _Kamera;
    public Slider _Slider;

    public GameObject KarakterYeniPoz;
    public GameObject GecisNoktasi;

    public bool SonaGelindiMiKarakter;

    private void Start()
    {
        //Karakterin sona olan uzakl���n� slider'�n max value de�eri yap.
        float fark = Vector3.Distance(transform.position, GecisNoktasi.transform.position);
        _Slider.maxValue = fark;
    }
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

            //Slider'da kalan minik bo�lu�u doldurma i�lemi
            if (_Slider.value != 0)
            {
                _Slider.value -= .004f;
            }
        }
        else
        {
            //Karakter ile son aras�ndaki fark� s�rekli g�ncelle ve slider valuesine e�itle  
            float fark = Vector3.Distance(transform.position, GecisNoktasi.transform.position);
            _Slider.value = fark;

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
        if (other.CompareTag("SonTetikleyici")) // Oyun sonu i�in trigger koydu�um nokta
        {
            _Kamera.SonaGelindiMiKamera = true;
            _GameManager.DusmanlariTetikle();
            SonaGelindiMiKarakter = true;
        }
        else if (other.CompareTag("BosKarakter")) 
        {
            _GameManager.Karakterler.Add(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Direk") || collision.gameObject.CompareTag("IgneliKutu") || collision.gameObject.CompareTag("PervaneIgneler"))
        {
            //Karakterin direklere tak�lma durumunun �n�ne ge�mek i�in soldakine tak�lmaya �al���rsa sa�a, sa�dakilere tak�lmaya �al���rsa sola atma i�levi..
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
