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
    private bool haEntrado;

    void Start()
    {
        estaDentro = false;
        estoypreg = false;
        haEntrado = false;
    }

    void Update()
    {
        Debug.Log(GlobalData.vidas);
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

        if (estoypreg == true)
        {
            if (InputText.text == respuesta.ToString())
            {
                // Incrementar la vida en uno
                GlobalData.vidas++;
                if (GlobalData.vidas == 2)
                {
                    vida2.SetActive(true);
                }
                else if (GlobalData.vidas == 3)
                {
                    vida3.SetActive(true);
                }
                else
                {
                    vida2.SetActive(true);
                    vida3.SetActive(true);
                    vida4.SetActive(true);
                }
                Destroy(gameObject);
                CuadroRespuesta.SetActive(false);
                Canvas.SetActive(false);
            }
            else if (InputText.text != "" && haEntrado == true)
            {
                haEntrado = true;
                CuadroRespuesta.SetActive(false);
                Canvas.SetActive(false);
                GlobalData.vidas--;
                if (GlobalData.vidas == 0)
                {
                    
                }
                else if (GlobalData.vidas == 1)
                {
                    vida2.SetActive(false);
                    vida3.SetActive(false);
                    vida4.SetActive(false);
                }
                else if (GlobalData.vidas == 2)
                {
                    vida3.SetActive(false);
                    vida4.SetActive(false);
                }
                else if (GlobalData.vidas == 3)
                {
                    vida4.SetActive(false);
                }
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
