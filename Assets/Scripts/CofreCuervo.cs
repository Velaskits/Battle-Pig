using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CofreCuervo : MonoBehaviour
{
    private bool estaDentro;
    public GameObject cuervo;
    public GameObject CuadroRespuesta;
    public TMP_InputField InputText;
    public GameObject Canvas;
    public int respuesta = 25;
    public GameObject cofre;
    // Start is called before the first frame update
    void Start()
    {
        estaDentro = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && estaDentro)
        {
            CuadroRespuesta.SetActive(true);
            Canvas.SetActive(true);
            cofre.SetActive(true);
            
            if (InputText.GetComponent<TMP_InputField>().text == "25")
            {
                cofre.SetActive(false);
                cuervo = Instantiate(Resources.Load("Prefabs/cuervo1"), transform.position, transform.rotation) as GameObject;
                CuadroRespuesta.SetActive(false);
                Canvas.SetActive(false);
                GlobalData.cuervoVisto = true;
            }
            else
            {
                Debug.Log("Fallo");
            }



        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "jabali")
        {

            estaDentro = true;

        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "jabali")
        {
            estaDentro = false;
        }
    }

}
