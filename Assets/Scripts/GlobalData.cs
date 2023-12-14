using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData
{
    // Start is called before the first frame update
    public static int monedas = 0;//contador
    public static bool VidaLobo=false;//Lobo
    public static bool monedasP=false;//monedas del juego
    public static bool[] monedasCogidas = new bool[20];
    public static bool[] cofreAbierto=new bool[20];
    public static bool cuervoVisto = false;//Cuervo
}
