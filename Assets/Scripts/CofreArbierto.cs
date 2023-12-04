using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofreArbierto : MonoBehaviour
{
    public int idCofres;
    // Start is called before the first frame update
    void Start()
    {
        if (GlobalData.cofreAbierto[idCofres])
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
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "jabali")
        {
            estaDentro = false;
        }
    }
}
