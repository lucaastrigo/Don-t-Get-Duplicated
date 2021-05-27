using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public Canvas EscCan;
    public GameObject audio;

    void Start()
    {
    
    }

    private void Update()
    {
        //Find the object you're looking for
        GameObject tempObject = GameObject.FindGameObjectWithTag("Canvas");
        if (tempObject != null)
        {
            Destroy(tempObject);
            EscCan = tempObject.GetComponent<Canvas>();
            if (EscCan == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject.name);
            }
        }

        //Find the object you're looking for
        audio = GameObject.FindGameObjectWithTag("AudioSource");
        if (audio != null)
        {
            Destroy(audio);
            if (audio == null)
            {
                Debug.Log("Could not locate Canvas component on " + audio.name);
            }
        }
    }
}
