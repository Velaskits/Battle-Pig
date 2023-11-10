using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarPantallaVolver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)    {

        if (collision.CompareTag("jabali"))
        {

            SceneManager.LoadScene("Jugar");
        }
    }
    
}
