using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletaveis : MonoBehaviour
{
    public static int numMilkShake;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<ScriptAudioManager>().Play("collectable");
            numMilkShake++;
            Destroy(gameObject);
        }
    }
}
