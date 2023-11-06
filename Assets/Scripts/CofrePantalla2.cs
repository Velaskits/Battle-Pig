using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofrePantalla2 : MonoBehaviour
{
    private bool cofretocado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && cofretocado)
        {
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "jabali")
        {

            cofretocado = true;

        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "jabali")
        {
            cofretocado = false;
        }
    }
}
