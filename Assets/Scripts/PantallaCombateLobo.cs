using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PantallaCombateLobo : MonoBehaviour
{
    public GameObject DisparoLoboprefabs; // Prefabricado del proyectil
    public float Tiempo = 1.0f; // Tasa de disparo (disparos por segundo)
    public float _velLobo;
    public TilemapCollider2D tilemapCollider;
    [SerializeField] int vidas;
    [SerializeField] Slider slidervidas;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0.0f, 1.0f / Tiempo);
        _velLobo = 4;
        slidervidas.maxValue = vidas;
        slidervidas.value = slidervidas.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        // Mueve el objeto hacia arriba y hacia abajo en función del tiempo
        float newY = Mathf.Sin(Time.time) * _velLobo;
        // Actualiza la posición del objeto solo en el eje Y
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

    }
    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.gameObject.CompareTag("Boladebarro"))
        {

            vidas--;
            if (slidervidas != null)
            {
                slidervidas.value = vidas;
            }

            if (vidas <= 0)
            {
                
                Debug.Log("hola");
                GlobalData.VidaLobo = true;
                Invoke("CambiarEscena", 1f);

            }
            
          
        }
       

        
    }
    void Shoot()
    {
        // Crea un nuevo proyectil en la posición del jugador
        Instantiate(DisparoLoboprefabs, transform.position, Quaternion.identity);
    }

    void CambiarEscena()
    {
        // Carga la nueva escena (reemplaza "NombreDeTuEscena" con el nombre real de tu escena)
        SceneManager.LoadScene("Pantalla2");
        Destroy(this.gameObject);
    }
}




