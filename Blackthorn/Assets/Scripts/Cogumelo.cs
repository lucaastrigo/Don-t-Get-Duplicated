using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cogumelo : MonoBehaviour
{

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("SegundoPlayer"))
        {
            FindObjectOfType<ScriptAudioManager>().Play("cogumelo");
            anim.SetTrigger("Pular");
        }
    }
}
