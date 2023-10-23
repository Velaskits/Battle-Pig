using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoJabali : MonoBehaviour
{
    public float _velJab;
    public GameObject chuletas_0;
    public bool finJuego;
    
    // Start is called before the first frame update
    void Start()
    {
        _velJab = 7;
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoJab();
    }
    // Aqui lo que hacemos es cuando el jabali es tocado por el cazador se destruye
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "cazador"  )
        {
            gameObject.SetActive(false);

            //GameObject carne = Instantiate(chuletas_0);
            GameObject carne = Instantiate(Resources.Load("Prefabs/chuletas_0") as GameObject);
            carne.transform.position = transform.position;
            carne.SetActive(true);
            //llamar gamemanager hacer funcion para llamr al Game Over que sera una pantalla.
            Invoke("CambiarEscena", 5f);
            

        }else if (other.tag == "arbol")
        {
            gameObject.SetActive(false);
            CambiarEscena1();
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
        Vector2 direccioIndicada = new Vector2(direccioHoritzontal, direccioVertical).normalized;//mover el jabali

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();//tenemos toda la informacion del componente
        float anchura = spriteRenderer.bounds.size.x / 2;
        float Altura = spriteRenderer.bounds.size.y / 2;
        // Este if hace que el jabali cambie de lado es decir que la imagen cambia de sentido
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

        Vector2 novaPos = transform.position; // Ens retorna la posicion actual del Jabali
        novaPos += direccioIndicada * _velJab * Time.deltaTime;


        //Para ponerlimites  y clamp pones el valor que quieras para poner los limites
        novaPos.x = Mathf.Clamp(novaPos.x, limitEsquerraX, limitDretaX);
        novaPos.y = Mathf.Clamp(novaPos.y, limitAbajoY, limitArribaY);



        transform.position = novaPos;
        

  
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


}
