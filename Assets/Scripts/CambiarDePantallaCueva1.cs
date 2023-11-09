using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    // Nombre de la escena a la que quieres cambiar

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisionamos tiene un tag específico (puedes ajustarlo según tus necesidades)
        if (collision.gameObject.CompareTag("jabali"))
        {
            // Cambia a la escena deseada
            SceneManager.LoadScene("Pantalla3");
        }
    }
}
