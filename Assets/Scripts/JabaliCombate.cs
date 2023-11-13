using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JabaliCombate : MonoBehaviour
{
    public float _velJab;
    public GameObject chuletas_0;
    public bool finJuego;
    private int contador = 0;
    public TMPro.TextMeshProUGUI ContadorDeMonedas;
    public GameObject bolabarroprefabs;
    public bool miradreta;
    public GameObject carga_Jabaliprefabs;
    private Rigidbody2D rb;
    public TilemapCollider2D tilemapCollider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        miradreta = true;
        _velJab = 4;
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoJab();
        DispararBola();
    }


    private void MovimientoJab()
    {

        float direccioHoritzontal = Input.GetAxisRaw("Horizontal");
        float direccioVertical = Input.GetAxisRaw("Vertical");
        Vector2 direccioIndicada = new Vector2(direccioHoritzontal, direccioVertical).normalized;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float anchura = spriteRenderer.bounds.size.x / 2;
        float Altura = spriteRenderer.bounds.size.y / 2;

        if (direccioHoritzontal > 0)
        {
            spriteRenderer.flipX = false;
            miradreta = true;
        }
        else if (direccioHoritzontal < 0)
        {
            spriteRenderer.flipX = true;
            miradreta = false;
        }

        float limitEsquerraX = -Camera.main.orthographicSize * Camera.main.aspect + anchura;//el aspect se utiliza solamente para la anchura
        float limitDretaX = Camera.main.orthographicSize * Camera.main.aspect - anchura;

        float limitAbajoY = -Camera.main.orthographicSize + Altura;
        float limitArribaY = Camera.main.orthographicSize - Altura;

        Vector2 velocidad = direccioIndicada * _velJab;

        // Aplica las colisiones del Tilemap Collider 2D
        rb.velocity = velocidad;
        tilemapCollider.usedByComposite = true; // Activa el uso del TilemapCollider2D

        Vector2 novaPos = rb.position;
        novaPos.x = Mathf.Clamp(novaPos.x, limitEsquerraX, limitDretaX);
        novaPos.y = Mathf.Clamp(novaPos.y, limitAbajoY, limitArribaY);

    }
    public bool getmiradreta()
    {
        return miradreta;
    }


    private void DispararBola()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Dispara
            GameObject bala = Instantiate(bolabarroprefabs);//indicamos de que tipo es el objeto
            Vector2 newPos = transform.position;
            bala.transform.position = this.transform.position;
        }
    }
}