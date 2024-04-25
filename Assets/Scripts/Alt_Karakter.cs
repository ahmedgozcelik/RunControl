using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Alt_Karakter : MonoBehaviour
{
    GameObject Target;
    NavMeshAgent _Navmesh;
    void Start()
    {
        _Navmesh = GetComponent<NavMeshAgent>();
        Target = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().VarisNoktasi;
    }

    private void LateUpdate()
    {
        _Navmesh.SetDestination(Target.transform.position); //yapay zekada pozisyon vermek i�in bu y�ntemi kullan�yoruz.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IgneliKutu"))
        {
            Vector3 yeniPoz = new Vector3(transform.position.x, .23f, transform.position.z);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokOlmaEfektiOlustur(yeniPoz);
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Testere"))
        {
            Vector3 yeniPoz = new Vector3(transform.position.x, .23f, transform.position.z);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokOlmaEfektiOlustur(yeniPoz);
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("PervaneIgneler"))
        {
            Vector3 yeniPoz = new Vector3(transform.position.x, .23f, transform.position.z);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokOlmaEfektiOlustur(yeniPoz);
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Balyoz"))
        {
            Vector3 yeniPoz = new Vector3(transform.position.x, .005f, transform.position.z);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokOlmaEfektiOlustur(yeniPoz);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().AdamLekesiOlustur(yeniPoz);
            gameObject.SetActive(false);
        }
    }
}
