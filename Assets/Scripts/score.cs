using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    public static int puntaje;
    public GameObject texto;
    
    void Start()
    {
        puntaje = 0;
        guardar.mostrar();
        texto.GetComponent<TextMeshProUGUI>().text = "Score : 0";
    }

    void FixedUpdate()
    {
        texto.GetComponent<TextMeshProUGUI>().text = "Score : " + puntaje;
    }
}
