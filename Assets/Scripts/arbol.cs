using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arbol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D objetotocado)
    {
        if (objetotocado.tag == "arbol")
        {
            Debug.Log("Arbol tocado");
            Destroy(gameObject);

        }
    }
}
