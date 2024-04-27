using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Alt_Karakter : MonoBehaviour
{
    NavMeshAgent _Navmesh;

    public GameManager _GameManager;
    public GameObject _Target;
    void Start()
    {
        _Navmesh = GetComponent<NavMeshAgent>();
    }

    private void LateUpdate()
    {
        _Navmesh.SetDestination(_Target.transform.position); //yapay zekada pozisyon vermek için bu yöntemi kullanýyoruz.
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IgneliKutu"))
        {
            YokOlmaEfekti(YPozisyonVer(.23f));
            ObjeyiKapat();
        }
        else if (other.CompareTag("Testere"))
        {
            YokOlmaEfekti(YPozisyonVer(.23f));
            ObjeyiKapat();
        }
        else if (other.CompareTag("PervaneIgneler"))
        {
            YokOlmaEfekti(YPozisyonVer(.23f));
            ObjeyiKapat();
        }
        else if (other.CompareTag("Balyoz"))
        {
            YokOlmaEfekti(YPozisyonVer(.005f));
            AdamLekesi(YPozisyonVer(.005f));
            ObjeyiKapat();
        }
        else if (other.CompareTag("Dusman"))
        {
            YokOlmaEfekti(YPozisyonVer(.23f));
            ObjeyiKapat();
            Debug.Log(GameManager.AnlikKarakterSayisi);
        }
        else if (other.CompareTag("BosKarakter"))
        {
            _GameManager.Karakterler.Add(other.gameObject);
        }
    }

    Vector3 YPozisyonVer(float yDegeri)
    {
        return new Vector3(transform.position.x, yDegeri, transform.position.z);
    }

    void YokOlmaEfekti(Vector3 Pozisyon)
    {
        _GameManager.YokOlmaEfektiOlustur(Pozisyon);
    }

    void AdamLekesi(Vector3 Pozisyon)
    {
        _GameManager.AdamLekesiOlustur(Pozisyon);
    }

    void ObjeyiKapat()
    {
        gameObject.SetActive(false);
    }
}
