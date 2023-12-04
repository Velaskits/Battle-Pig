using System.Collections;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CofreEsterEgg : MonoBehaviour
{
    private bool estaDentro;
    public GameObject CuadroRespuesta;
    public TMP_InputField InputText;
    public GameObject Canvas;
    public int respuesta = 3;
    public GameObject cofre;
    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;
    public GameObject vida4;
    private bool estoypreg;

    void Start()
    {
        estaDentro = false;
        estoypreg = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && estaDentro)
        {

            CuadroRespuesta.SetActive(true);
            Canvas.SetActive(true);
            cofre.SetActive(true);
            estoypreg = true;

            if (InputText.text == respuesta.ToString())
            {
                // Incrementar la vida en uno
                vida4.SetActive(true);
                Destroy(gameObject);
                CuadroRespuesta.SetActive(false);
                Canvas.SetActive(false);
            }
            else
            {
                
            }
        }

        if (estoypreg == true){
             if (InputText.text == respuesta.ToString())
            {
                // Incrementar la vida en uno
                vida4.SetActive(true);
                Destroy(gameObject);
                CuadroRespuesta.SetActive(false);
                Canvas.SetActive(false);
            }
            else
            {
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
