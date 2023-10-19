using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CazadorMovimiento : MonoBehaviour
{
    public float _velCazador;
    // Start is called before the first frame update
    void Start()
    {
        _velCazador = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        cazadorM();
        // Que el cazador y el jabali se resten la posicion y se gaurde en un vector y luego hacer que el cazador siga al jabali
    }
    void cazadorM()
    {
        if (GameObject.Find("jabali") != null) {
            Vector2 direccionCazador = (GameObject.Find("jabali").transform.position - transform.position).normalized;
            Vector2 novaPos = transform.position;
            novaPos += direccionCazador * _velCazador * Time.deltaTime;
            transform.position = novaPos;

            float direccioHoritzontal = Input.GetAxisRaw("Horizontal");
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            if (direccioHoritzontal < 0)
            {

                spriteRenderer.flipX = false;
            }
            else if (direccioHoritzontal > 0)
            {
                spriteRenderer.flipX = true;
            }
        }
     
    }
}
//