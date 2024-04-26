using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gurkan;
using TMPro;

public class Kapi : MonoBehaviour
{
    public GameManager _GameManager;
    public TextMeshProUGUI _KapiText;
    public GameObject _Karakter;

    public int _IslemDegeri;
    public enum KapiTuru
    {
        Toplama,
        Cikarma,
        Carpma,
        Bolme
    }
    public KapiTuru kapiTuru;

    public void Awake()
    {
        VisualGuncelle();
    }
    public void KapiTuruBelirle(Transform Pozisyon)
    {
        switch (kapiTuru)
        {
            case KapiTuru.Toplama:
                Matematiksel_Islemler.Toplama(_IslemDegeri, _GameManager.Karakterler, Pozisyon, _GameManager.OlusmaEfektleri);
                break;
            case KapiTuru.Cikarma:
                Matematiksel_Islemler.Cikarma(_IslemDegeri, _GameManager.Karakterler, _GameManager.YokOlmaEfektleri);
                break;
            case KapiTuru.Carpma:
                Matematiksel_Islemler.Carpma(_IslemDegeri, _GameManager.Karakterler, Pozisyon, _GameManager.OlusmaEfektleri);
                break;
            case KapiTuru.Bolme:
                Matematiksel_Islemler.Bolme(_IslemDegeri, _GameManager.Karakterler, _GameManager.YokOlmaEfektleri);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Karakter"))
        {
            KapiTuruBelirle(gameObject.transform);
        }
    }

    void VisualGuncelle()
    {
        switch (kapiTuru)
        {
            case KapiTuru.Toplama:
                _KapiText.text = "+" + _IslemDegeri;
                break;
            case KapiTuru.Cikarma:
                _KapiText.text = "-" + _IslemDegeri;
                break;
            case KapiTuru.Carpma:
                _KapiText.text = "x" + _IslemDegeri;
                break;
            case KapiTuru.Bolme:
                _KapiText.text = "/" + _IslemDegeri;
                break;
        }
    }
}
