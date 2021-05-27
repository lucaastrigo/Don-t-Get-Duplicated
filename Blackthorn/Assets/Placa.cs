using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Placa : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Vector3 Offset;

    void Start()
    {
        text.enabled = false;
    }

    void Update()
    {
        text.transform.position = Camera.main.WorldToScreenPoint(transform.position + Offset);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.enabled = false;
        }
    }
}
