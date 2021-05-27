using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FilaMorte : MonoBehaviour
{
    [SerializeField] public static int mortes;
    public static int quantClones;

    [SerializeField]public static GameObject playerPrincipal;
    public static GameObject prefabClone;
    public GameObject[] fila;

    public static float tempoMorte = 2f;
    public static float saveTempo;
    public static bool podeSpawnar;
    
    private void Awake()
    {
      
    }

    void Start()
    {
        mortes = 0;
        quantClones = 0;
        podeSpawnar = true;
        SegundoPlayer.controleDistance = SegundoPlayer.followDistance;
        fila[0] = playerPrincipal;
        saveTempo = tempoMorte;
    }

    void Update()
    {

        playerPrincipal = GameObject.FindGameObjectWithTag("Player");
        fila = GameObject.FindGameObjectsWithTag("SegundoPlayer");
        prefabClone = GameObject.FindGameObjectWithTag("SegundoPlayer");

        tempoMorte -= Time.deltaTime;

        for (quantClones = 0; quantClones < mortes; quantClones++)
        {
            if (quantClones != 0)
            {
                fila[quantClones].gameObject.GetComponent<SegundoPlayer>().player = fila[quantClones - 1].gameObject.GetComponent<SegundoPlayer>().propriaPos;       
            }
            else
            {

                fila[quantClones].gameObject.GetComponent<SegundoPlayer>().player = playerPrincipal.gameObject;
            }
        }

        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    if (tempoMorte < 0)
        //    {
        //        StartCoroutine(morte());
        //        tempoMorte = saveTempo;
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    mortes--;
        //    Destroy(fila[quantClones - 1].gameObject);
        //}

    }

    public static IEnumerator morte()
    { 
        if (mortes < 8)
        {
            if (mortes > 0)
            {
                    
                mortes++;
                Instantiate(prefabClone, playerPrincipal.transform.position, Quaternion.identity);
                podeSpawnar = true;
            }
            if (mortes == 0)
            {
                mortes++;
                podeSpawnar = true;
            
            }
            yield return new WaitForSeconds(0f);

            
        }
    }
}
