using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparolobo : MonoBehaviour
{
    public float Velocity = 5f;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject Lobos = GameObject.Find("LobosCombate");
        bool direcciodreta = Lobos.GetComponent<PantallaCombateLobo>();
        if (direcciodreta)
        {
            Velocity = 5f;

        }
        else if (!direcciodreta)
        {
            Velocity = -5f;
            spriteRenderer.flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 novaPos = transform.position;
        novaPos.x += Velocity * Time.deltaTime;
        transform.position = novaPos;

        //Lo que hace este codigo es cuando la bala llegue al limite se borre directamente
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();//tenemos toda la informacion del componente
        float costado = spriteRenderer.bounds.size.x / 2;
        Vector2 costatInferiorEsquerra = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 limitcostatX = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        transform.position = novaPos;
        if (transform.position.x >= limitcostatX.x)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x <= costatInferiorEsquerra.x)
        {
            Destroy(gameObject);
        }
    }
}
