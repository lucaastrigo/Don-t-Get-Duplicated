using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planta : MonoBehaviour
{
    public CapsuleCollider2D coll;

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
            anim.SetTrigger("Come");

        }
    }

    public void ComeCome()
    {
        FindObjectOfType<ScriptAudioManager>().Play("carnivorous_plant");

    }
}
