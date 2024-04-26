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
}
