using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterColetaveis : MonoBehaviour
{

    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

    }

    void Update()
    {
        text.text = "" + Coletaveis.numMilkShake + "/5";
    }
}
