using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Bos_Karakter : MonoBehaviour
{
    public GameManager _GameManager;

    public SkinnedMeshRenderer _Renderer;
    public Material _MaviMat;
    public NavMeshAgent _NavMesh;
    public Animator _Animator;
    public GameObject _Target;

    bool TemasVarMi;

    private void LateUpdate()
    {
        if (TemasVarMi == true)
        {
            _NavMesh.SetDestination(_Target.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Karakter") || other.CompareTag("AltKarakter"))
        {
            if (gameObject.CompareTag("BosKarakter"))
            {
                MaterialDegistirVeAnimasyonTetikle();
                TemasVarMi = true;
                gameObject.GetComponent<AudioSource>().Play();
                Debug.Log(GameManager.AnlikKarakterSayisi);
            }
        }
        else if (other.CompareTag("IgneliKutu"))
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
        }
    }

    void MaterialDegistirVeAnimasyonTetikle()
    {
        // Material deðiþtir
        Material[] mats = _Renderer.materials;
        mats[0] = _MaviMat;
        _Renderer.materials = mats;

        _Animator.SetBool("Saldir", true);

        gameObject.tag = "AltKarakter";
        _GameManager.Karakterler.Add(gameObject);
        GameManager.AnlikKarakterSayisi += 1;
        Debug.Log(GameManager.AnlikKarakterSayisi);
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
