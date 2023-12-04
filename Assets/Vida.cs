using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Vida : MonoBehaviour
{
    public int vidas;
    public int vidamaxima;
    public Image[] corazon;
    public Sprite maximo;
    public Sprite vacio;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        logicaDeVida();
    }

    void logicaDeVida()
    {

        if (vidas > vidamaxima)
        {
            vidas = vidamaxima;
        }

        for (int i = 0; i < corazon.Length; i++)
        {
            if (i < vidas)
            {
                corazon[i].sprite = maximo;
            }
            else
            {
                corazon[i].sprite = vacio;
            }

            if (i < vidamaxima)
            {
                corazon[i].enabled = true;
            }
            else
            {
                corazon[i].enabled = false;
            }
        }
    }
}
