using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pervane : MonoBehaviour
{
    public Animator _animator;
    public BoxCollider _ruzgar;

    public float beklemeSuresi;

    public void AnimasyonDurum(string durum)
    {
        if(durum == "true")
        {
            _animator.SetBool("Calistir", true);
            _ruzgar.enabled = true;
        }
        else
        {
            _animator.SetBool("Calistir", false);
            _ruzgar.enabled = false;
        }
        StartCoroutine(AnimasyonTetikle());
    }

    IEnumerator AnimasyonTetikle()
    {
        yield return new WaitForSeconds(beklemeSuresi);
        AnimasyonDurum("true");
    }
}
