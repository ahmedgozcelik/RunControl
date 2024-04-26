using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Dusman : MonoBehaviour
{
    public GameObject Saldiri_Hedefi;

    private NavMeshAgent _NavMesh;
    private Animator Animator;

    bool SaldiriBasladiMi;
    void Start()
    {
        _NavMesh = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();
    }

    public void AnimasyonTetikle()
    {
        Animator.SetBool("Saldir", true);
        SaldiriBasladiMi = true;
    }

    void LateUpdate()
    {
        if(SaldiriBasladiMi == true)
        {
            _NavMesh.SetDestination(Saldiri_Hedefi.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AltKarakter"))
        {
            Vector3 yeniPoz = new Vector3(transform.position.x, .005f, transform.position.z);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokOlmaEfektiOlustur(yeniPoz, true);
            gameObject.SetActive(false);
        }
    }
}
