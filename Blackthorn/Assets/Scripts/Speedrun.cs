using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Speedrun : MonoBehaviour
{
    public float timer;
    public float speed = 1;

    public bool isPlaying = true;

    public TextMeshProUGUI text;


    void Awake()
    {

    }
    void Start()
    { 
    
    }

    void Update()
    {
        if (isPlaying)
        {
            timer += Time.deltaTime * speed;
            string hours = Mathf.Floor((timer % 216000) / 3600).ToString("00");
            string minutes = Mathf.Floor((timer % 3600) / 60).ToString("00");
            string seconds = (timer % 60).ToString("00");
            text.text = " " + hours + ":" + minutes + ":" + seconds;
        }
    }

    void Play()
    {
        isPlaying = true;
    }

    void Stop()
    {
        isPlaying = false;
    }
}
