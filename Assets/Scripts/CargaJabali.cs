using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargaJabali : MonoBehaviour
{
    public Transform carga; // La referencia al objeto de la carga
    public float velocidad = 5f; // Velocidad de movimiento del personaje
    public float distanciaMovimiento = 1.2f; // Distancia que se mover� el personaje y la carga
    //private bool miraDretra;
    void Start()
    {
        //miraDretra = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Mueve la carga junto con el personaje
            if (carga != null)
            {
                carga.position = transform.position; // La posici�n de la carga se iguala a la del personaje
                Destroy(carga.gameObject);// Destruye el objeto de carga despu�s de usarlo
            }
            GameObject Jabali = GameObject.Find("jabali");
            // Multiplica el desplazamiento actual por 2 (0.6f * 2)
            //float desplazamiento = 0.6f * 2;
           
        }
    }
  
 
   
}
