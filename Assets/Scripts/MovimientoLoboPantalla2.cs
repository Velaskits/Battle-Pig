using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoLoboPantalla2 : MonoBehaviour
{
    public float _lobo;
    // Start is called before the first frame update
    void Start()
    {
        if (GlobalData.VidaLobo) {
            this.enabled = false;
            Destroy(gameObject);
        }
        _lobo = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        loboM();
    }
    void loboM()
    {
        if (GameObject.Find("jabali") != null)
        {
            Vector2 direccionlobo = (GameObject.Find("jabali").transform.position - transform.position).normalized;
            Vector2 novaPos = transform.position;
            novaPos += direccionlobo * _lobo * Time.deltaTime;
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
