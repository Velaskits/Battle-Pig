using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuervo : MonoBehaviour
{
    public float _velCuervo;
    // Start is called before the first frame update
    void Start()
    {
        _velCuervo = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        cuervoM();
    }

    void cuervoM()
    {
        if (GameObject.Find("jabali") != null)
        {
            Vector2 direccionCuervo = (GameObject.Find("jabali").transform.position - transform.position).normalized;
            Vector2 novaPos = transform.position;
            novaPos += direccionCuervo * _velCuervo * Time.deltaTime;
            transform.position = novaPos;

            float direccioHoritzontal = Input.GetAxisRaw("Horizontal");
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            if (direccioHoritzontal < 0)
            {

                spriteRenderer.flipX = true;
            }
            else if (direccioHoritzontal > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
    }

}
