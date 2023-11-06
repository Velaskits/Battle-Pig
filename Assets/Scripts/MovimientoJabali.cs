using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class MovimientoJabali : MonoBehaviour
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
        _velJab = 7;
        // Encuentra el TilemapCollider2D en tu escena
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoJab();
        DispararBola();
        carga();
    }
    // Aqui lo que hacemos es cuando el jabali es tocado por el cazador se destruye
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "cazador")
        {
            gameObject.SetActive(false);

            //GameObject carne = Instantiate(chuletas_0);
            GameObject carne = Instantiate(Resources.Load("Prefabs/chuletas_0") as GameObject);
            carne.transform.position = transform.position;
            carne.SetActive(true);
            //llamar gamemanager hacer funcion para llamr al Game Over que sera una pantalla.
            Invoke("CambiarEscena", 5f);


        }

        if (other.tag == "monedas")
        {
            contador++;
            ContadorDeMonedas.text = contador.ToString();
        }


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
        }
        else if (direccioHoritzontal < 0)
        {
            spriteRenderer.flipX = true;
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

    void CambiarEscena()
    {
        // Carga la nueva escena (reemplaza "NombreDeTuEscena" con el nombre real de tu escena)
        SceneManager.LoadScene("GameOver");
    }
    void CambiarEscena1()
    {
        // Carga la nueva escena (reemplaza "NombreDeTuEscena" con el nombre real de tu escena)
        SceneManager.LoadScene("Win");
    }

    private void DispararBola()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Dispara
            GameObject bala = Instantiate(bolabarroprefabs);//indicamos de que tipo es el objeto
            Vector2 newPos = transform.position;
            newPos.x = newPos.x + 2f;
            bala.transform.position = this.transform.position;
        }
    }

    public void carga()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject carga = Instantiate(carga_Jabaliprefabs);//indicamos de que tipo es el objeto
            Vector2 newPos = transform.position;
            newPos.x = newPos.x + 2f;
            carga.transform.position = this.transform.position;
        }
    }
}
