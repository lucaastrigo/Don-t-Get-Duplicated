using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocarSkin : MonoBehaviour
{
    public RuntimeAnimatorController skinPadrao;
    public RuntimeAnimatorController skinVermelha;
    public RuntimeAnimatorController SkinGalaxy;
    public RuntimeAnimatorController SkinAmarela;
    public RuntimeAnimatorController SkinRoxa;
    public RuntimeAnimatorController SkinCinza;
    public RuntimeAnimatorController SkinVinho;

    public static int skins;

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (skins == 1) //Normal
        {
            anim.runtimeAnimatorController = skinPadrao as RuntimeAnimatorController;
        }
        if (skins == 2)  //Vermelho
        {
            anim.runtimeAnimatorController = skinVermelha as RuntimeAnimatorController;
        } 
        if (skins == 3)  //Galaxy
        {
            anim.runtimeAnimatorController = SkinGalaxy as RuntimeAnimatorController;
        }
        if (skins == 4)  //Amarela
        {
            anim.runtimeAnimatorController = SkinAmarela as RuntimeAnimatorController;
        } 
        if (skins == 5)  //Roxo
        {
            anim.runtimeAnimatorController = SkinRoxa as RuntimeAnimatorController;
        }
        if (skins == 6)  //Cinza
        {
            anim.runtimeAnimatorController = SkinCinza as RuntimeAnimatorController;
        } 
        if (skins == 7)  //Vinho
        {
            anim.runtimeAnimatorController = SkinVinho as RuntimeAnimatorController;
        }
    }
}
