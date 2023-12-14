using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CofrePantalla3 : MonoBehaviour
{
    private bool estaDentro;
    public GameObject monedaCofre;
    public GameObject CuadroRespuesta;
    public TMP_InputField InputText;
    public GameObject Canvas;
    public int respuesta = 25;
    public GameObject cofre;
    public int idCofre;
    // Start is called before the first frame update
    void Start()
    {
        estaDentro = false;
        if (GlobalData.monedasCogidas[idCofre])
        {
            this.enabled = false;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && estaDentro)
        {
            CuadroRespuesta.SetActive(true);
            Canvas.SetActive(true);
            cofre.SetActive(true);
            
            if (InputText.GetComponent<TMP_InputField>().text == "8")
            {
                cofre.SetActive(false);
                monedaCofre = Instantiate(Resources.Load("Prefabs/Contador"), transform.position, transform.rotation) as GameObject;
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
        if (col.tag == "jabali")
        {
            GlobalData.monedasCogidas[idCofre] = true;
            Destroy(gameObject);
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
