using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoteiraToxica : MonoBehaviour
{
    public float timerSpawn;
    private float saveSpawn;

    public Transform pos;
    public GameObject gotaPrefab;

    void Start()
    {
        saveSpawn = timerSpawn;
    }

    void Update()
    {
        timerSpawn -= Time.deltaTime;

        if(timerSpawn <= 0)
        {
            Instantiate(gotaPrefab, pos.transform.position, Quaternion.identity);
            timerSpawn = saveSpawn;
        }
    }
}
