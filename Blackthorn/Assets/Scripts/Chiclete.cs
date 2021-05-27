using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chiclete : MonoBehaviour
{
    public bool left;
    public float speed;
    public GameObject hitFX;

    void Start()
    {
        //
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(hitFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
