using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    public int idMoneda;
    private void Start()
    {
        if (GlobalData.monedasCogidas[idMoneda])
        {
            this.enabled = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "jabali") {
            GlobalData.monedasCogidas[idMoneda] = true;
            Destroy(gameObject);
        }
        
    }
}
