using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparos : MonoBehaviour
{
    public float Velocity = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject jabali = GameObject.Find("jabali");
        bool direcciodreta = jabali.GetComponent<MovimientoJabali>().getmiradreta();
        if (direcciodreta)
        {
            Velocity = 5f;
           
        }
        else if ( !direcciodreta)
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
        float limitcostatX = Camera.main.orthographicSize;
        transform.position = novaPos;
        if (novaPos.x >= limitcostatX)
        {
            Destroy(gameObject);
        }
       
       
        
       
    }

    
}
