using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gota : MonoBehaviour
{

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Gota") || other.gameObject.CompareTag("Gota2"))
        {
            FindObjectOfType<ScriptAudioManager>().Play("acid_drip");

            anim.SetTrigger("Caiu");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;           
        }

    }

    public void CaiuMuito()
    {
        Destroy(gameObject);
    }
}
