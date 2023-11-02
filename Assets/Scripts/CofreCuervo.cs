using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CofreCuervo : MonoBehaviour
{

    private bool estaDentro;
    
    // Start is called before the first frame update
    void Start()
    {
        estaDentro = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && estaDentro){
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "jabali") {
            
            estaDentro = true;
        
        }
    }

    void OnTriggerExit2D(Collider2D col) {
         if (col.tag == "jabali") {
            estaDentro = false;
        }
    }

}
