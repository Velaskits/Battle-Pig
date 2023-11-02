using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargaJabali : MonoBehaviour
{
    public Transform carga; // La referencia al objeto de la carga
    public float velocidad = 5f; // Velocidad de movimiento del personaje
    public float distanciaMovimiento = 1.2f; // Distancia que se mover� el personaje y la carga

    void Start()
    {

        // Invoca la funci�n MiFuncion() cada 2 segundos
        InvokeRepeating("MiFuncion", 0f, 2f);

        // Invoca la funci�n DetenerRepeticion() despu�s de 5 segundos
        Invoke("DetenerRepeticion", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Mueve la carga junto con el personaje
            if (carga != null)
            {
                carga.position = transform.position; // La posici�n de la carga se iguala a la del personaje
                Destroy(carga.gameObject);// Destruye el objeto de carga despu�s de usarlo
            }
            GameObject Jabali = GameObject.Find("jabali");
            // Multiplica el desplazamiento actual por 2 (0.6f * 2)
            float desplazamiento = 0.6f * 2;
            if (Jabali.GetComponent<MovimientoJabali>().getmiradreta())
            {
                InvokeRepeating("dash", 0f, 0.1f);

            }
            else if (!Jabali.GetComponent<MovimientoJabali>().getmiradreta())
            {
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                transform.position = new Vector2(Jabali.transform.position.x - desplazamiento, 0);
                spriteRenderer.flipX = true;
            }
        }

        // Obt�n la entrada del jugador para mover el personaje
        

        
        //Acabar de ahcer el dash 

       

    }
    // La funci�n que queremos repetir
    void MiFuncion()
    {
        Debug.Log("Esta funci�n se repite cada 2 segundos.");
    }

    void DetenerRepeticion()
    {
        // Cancela la repetici�n de MiFuncion()
        CancelInvoke("MiFuncion");
        Debug.Log("La repetici�n se ha detenido despu�s de 5 segundos.");
    }
    private void stopDash() {
        
    }

    void dash() {
        this.transform.position = new Vector2(this.transform.position.x + 0.1f, this.transform.position.y);
    }
   
}
