using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    

    public int numMilkShakes;

    public GameObject playerPrincipal;
    static GameManager instance;
    public Vector2 lastCheckpoint;


    private void Awake()
    {
        //instanciar o numero de slimes que eu tinha antes 

        //for (int quantClones = 0; quantClones < slimes; quantClones++)
        //{
        //    Instantiate(prefabClone, playerPrincipal.transform.position, Quaternion.identity);
        //    print("a");
        //}

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
    

    }

    private void Update()
    {
        playerPrincipal = GameObject.FindGameObjectWithTag("Player");
        numMilkShakes = Coletaveis.numMilkShake;




    }

    
}
