using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "jabali") {
            
            Destroy(gameObject);
        }
    }
}
