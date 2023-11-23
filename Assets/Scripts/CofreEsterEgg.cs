using System.Collections;
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

    // Referencia al script Vida para acceder a las variables de vida
    public Vida scriptVida;

    void Start()
    {
        estaDentro = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && estaDentro)
        {
            CuadroRespuesta.SetActive(true);
            Canvas.SetActive(true);
            cofre.SetActive(true);

            if (InputText.text == respuesta.ToString())
            {
                // Incrementar la vida en uno
                scriptVida.vidas++;
                cofre.SetActive(false);
                CuadroRespuesta.SetActive(false);
                Canvas.SetActive(false);
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
