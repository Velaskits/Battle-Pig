using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofrePantalla2 : MonoBehaviour
{
    private GameObject Respuesta;
    private bool cofretocado;
    int respuesatcorrecta = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && cofretocado)
        {
            Respuesta.SetActive(true);
            if (Respuesta == respuesatcorrecta)
            {
                Debug.Log("Respuesta correcta");
            }
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
