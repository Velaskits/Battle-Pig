using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)    {

        if (collision.CompareTag("jabali"))
        {

            SceneManager.LoadScene("Pantalla3");
        }
    }
    
}
