using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaDeChiclete : MonoBehaviour
{
    public float timerSpawn;
    private float saveSpawn;

    public Transform pos;
    public GameObject chic1;
    public GameObject chic2;
    public GameObject chic3;

    void Start()
    {
        saveSpawn = timerSpawn;
    }

    void Update()
    {
        timerSpawn -= Time.deltaTime;

        if (timerSpawn <= 0)
        {
            int inteira = Random.Range(1, 4);
            if(inteira == 1)
            {
                Instantiate(chic1, pos.transform.position, Quaternion.identity);
            }else if(inteira == 2)
            {
                Instantiate(chic2, pos.transform.position, Quaternion.identity);
            }else if(inteira == 3)
            {
                Instantiate(chic3, pos.transform.position, Quaternion.identity);
            }

            timerSpawn = saveSpawn;
        }
    }
}
