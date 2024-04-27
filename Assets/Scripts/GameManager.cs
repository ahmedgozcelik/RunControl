using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gurkan;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    public static int AnlikKarakterSayisi = 1;

    public List<GameObject> Karakterler;
    public List<GameObject> OlusmaEfektleri;
    public List<GameObject> YokOlmaEfektleri;
    public List<GameObject> AdamLekesiEfektleri;

    [Header("Level Verileri")]
    public List<GameObject> Dusmanlar;
    public int DusmanSayisi;
    public GameObject AnaKarakter;
    public bool OyunBittiMi;

    bool SonaGelindiMi;

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

    //public void AdamYonetimi(string islemTuru, int GelenSayi, Transform Pozisyon)
    //{
    //    switch (islemTuru)
    //    {
    //        case "Carpma":
    //            Matematiksel_Islemler.Carpma(GelenSayi, Karakterler, Pozisyon, OlusmaEfektleri);
    //            break;
    //        case "Toplama":
    //            Matematiksel_Islemler.Toplama(GelenSayi, Karakterler, Pozisyon, OlusmaEfektleri);
    //            break;
    //        case "Cikarma":
    //            Matematiksel_Islemler.Cikarma(GelenSayi, Karakterler, YokOlmaEfektleri);
    //            break;
    //        case "Bolme":
    //            Matematiksel_Islemler.Bolme(GelenSayi, Karakterler, YokOlmaEfektleri);
    //            break;
    //    }
    //}


    public void SavasDurumu()
    {
        if (SonaGelindiMi == true)
        {
            if (AnlikKarakterSayisi == 1 || DusmanSayisi == 0) //Karakter sayýmýzýn durumuna göre kaybetme veya düþman sayýsýna göre kazanma durumlarýný kontrol et
            {
                OyunBittiMi = true;
                foreach (var item in Dusmanlar)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Saldir", false);
                    }
                }
                foreach (var item in Karakterler)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Saldir", false);
                    }
                }
                AnaKarakter.GetComponent<Animator>().SetBool("Saldir", false);

                if (AnlikKarakterSayisi <= DusmanSayisi)
                {
                    Debug.Log("Kaybettin");
                }
                else
                {
                    Debug.Log("Kazandýn");
                }
            }
        }
    }

    public void YokOlmaEfektiOlustur(Vector3 Pozisyon, bool KarakterDurum = false) // Buradaki karakterDurum deðiþkeni düþmandan mý azaltacaðýz yoksa altkarakterden mi azaltacaðýz ona karar veriyor --> false = altkarakter, true = dusman
    {
        foreach (var item in YokOlmaEfektleri)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = Pozisyon;
                item.GetComponent<ParticleSystem>().Play();
                item.GetComponent<AudioSource>().Play();
                if (KarakterDurum == false)
                {
                    AnlikKarakterSayisi--;
                }
                else
                {
                    DusmanSayisi--;
                }
                break;
            }
        }

        if (OyunBittiMi == false)
        {
            SavasDurumu();
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
        SonaGelindiMi = true;
    }
}
