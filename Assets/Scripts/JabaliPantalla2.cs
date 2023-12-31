using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class JabaliPantalla2 : MonoBehaviour
{
    public float _velJab;
    public GameObject chuletas_0;
    public bool finJuego;
    //private int contador = 0;
    public TMPro.TextMeshProUGUI ContadorDeMonedas;
    public GameObject bolabarroprefabs;
    public bool miradreta;
    public GameObject carga_Jabaliprefabs;
    private Rigidbody2D rb;
    public TilemapCollider2D tilemapCollider;
    // Start is called before the first frame update
    void Start()
    {
        if(GlobalData.cuervoVisto == true){
            GameObject cuervo = Instantiate(Resources.Load("Prefabs/cuervo1"), transform.position, transform.rotation) as GameObject;
        }
        rb = GetComponent<Rigidbody2D>();
        miradreta = true;
        _velJab = 4;
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoJab();
        
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
    
    /*public void carga()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject carga = Instantiate(carga_Jabaliprefabs);//indicamos de que tipo es el objeto
            Vector2 newPos = transform.position;
            newPos.x = newPos.x + 2f;
            carga.transform.position = this.transform.position;

            if (getmiradreta())
            {
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.flipX = false;
                InvokeRepeating("dash", 0f, 0.005f);
                Invoke("stopDash", 0.15f);
            }
            else if (!getmiradreta())
            {
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.flipX = true;
                InvokeRepeating("dash", 0f, 0.005f);
                Invoke("stopDash", 0.15f);
            }
        }
    }*/

    //Cuando el Jabali es tocado por el Lobo saltara una pantalla de combate
 void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Lobo_Pantalla2")
        {
            gameObject.SetActive(false);
            //llamar gamemanager hacer funcion para llamr al Combate lobo que sera una pantalla.
            Invoke("CambiarEscena", 1f);


        }
    }
    void CambiarEscena()
    {
        // Carga la nueva escena (reemplaza "NombreDeTuEscena" con el nombre real de tu escena)
        SceneManager.LoadScene("CombateLobo");
    }
}
