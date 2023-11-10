using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarDePantallaCueva2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)    {

        if (collision.CompareTag("jabali"))
        {

            SceneManager.LoadScene("Pantalla2");
        }
    }
    
}
