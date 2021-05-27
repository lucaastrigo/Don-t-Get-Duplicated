using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject tela;
    private Animator anim;
    void Start()
    {
        anim = tela.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void Back()
    {
        anim.SetTrigger("Descer");
        StartCoroutine(EventoTroca());
    }

    IEnumerator EventoTroca()
    {
        yield return new WaitForSeconds(1.25f);
        tela.SetActive(false);
    }
}
