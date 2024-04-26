using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gurkan;

public class GameManager : MonoBehaviour
{
    public GameObject VarisNoktasi;
    public static int AnlikKarakterSayisi = 1;

    public List<GameObject> Karakterler;
    public List<GameObject> OlusmaEfektleri;
    public List<GameObject> YokOlmaEfektleri;
    public List<GameObject> AdamLekesiEfektleri;

    [Header("Level Verileri")]
    public List<GameObject> Dusmanlar;

    public int DusmanSayisi;

    void Start()
    {
        DusmanlariOlustur();   
    }

    

    void Update()
    {


        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    //OBJECT POOL
        //    foreach(var item in Karakterler)
        //    {
        //        if(!item.activeInHierarchy)
        //        {
        //            item.transform.position = DogmaNoktasi.transform.position;
        //            item.SetActive(true);
        //            AnlikKarakterSayisi++;
        //            break;
        //        }
        //    }
        //}
    }

    public void AdamYonetimi(string islemTuru, int GelenSayi, Transform Pozisyon)
    {
        switch(islemTuru)
        {
            case "Carpma":
                Matematiksel_Islemler.Carpma(GelenSayi, Karakterler, Pozisyon, OlusmaEfektleri);
                break;
            case "Toplama":
                Matematiksel_Islemler.Toplama(GelenSayi, Karakterler, Pozisyon, OlusmaEfektleri);
                break;
            case "Cikarma":
                Matematiksel_Islemler.Cikarma(GelenSayi, Karakterler, YokOlmaEfektleri);
                break;
            case "Bolme":
                Matematiksel_Islemler.Bolme(GelenSayi, Karakterler, YokOlmaEfektleri);
                break;
        }
    }

    public void YokOlmaEfektiOlustur(Vector3 Pozisyon)
    {
        foreach(var item in YokOlmaEfektleri)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = Pozisyon;
                item.GetComponent<ParticleSystem>().Play();
                AnlikKarakterSayisi--;
                break;
            }
        }
    }

    public void AdamLekesiOlustur(Vector3 Pozisyon)
    {
        foreach (var item in AdamLekesiEfektleri)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = Pozisyon;
                break;
            }
        }
    }

    public void DusmanlariOlustur()
    {
        for (int i = 0; i < DusmanSayisi; i++)
        {
            Dusmanlar[i].SetActive(true);
        }
    }

    public void DusmanlariTetikle()
    {
        foreach (var item in Dusmanlar)
        {
            if (item.activeInHierarchy)
            {
                item.GetComponent<Dusman>().AnimasyonTetikle();
            }
        }
    }
}
