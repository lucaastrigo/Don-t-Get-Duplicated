using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComprarSlime : MonoBehaviour
{

    Image image;
    void Start()
    {
        


    }

    void Update()
    {
        //Coletaveis.numMilkShake;
        //TrocarSkin.skins;

        //if(numMilkShake == 1)
        //{

        //}
    }

    public void SelecionarSlime(int numSlime)
    {
       

        if(Coletaveis.numMilkShake >= 1)
        {
            if(numSlime == 1 || numSlime == 2 || numSlime == 4) TrocarSkin.skins = numSlime; //1, 2, 4
        }
        if(Coletaveis.numMilkShake >= 3)
        {
            if (numSlime == 5 || numSlime == 6 || numSlime == 7) TrocarSkin.skins = numSlime; //5, 6, 7
        }
        if(Coletaveis.numMilkShake >= 5)
        {
            if (numSlime == 3 ) TrocarSkin.skins = numSlime; TrocarSkin.skins = numSlime; // 3
        }
    } 
}
