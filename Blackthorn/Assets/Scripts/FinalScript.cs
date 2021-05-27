using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScript : MonoBehaviour
{
    GameManager gm;
    public bool ultimoultimo;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player") && !ultimoultimo)
        {
            gm.lastCheckpoint = Vector2.zero;
            StartCoroutine(Delay());
        }

        if(other.gameObject.CompareTag("Player") && ultimoultimo)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            gm.lastCheckpoint = Vector2.zero;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
