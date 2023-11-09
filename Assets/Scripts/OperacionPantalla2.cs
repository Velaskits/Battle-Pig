using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OperacionPantalla2 : MonoBehaviour
{
    public Text preguntaText;
    public InputField respuestaInput;

    private int numero1;
    private int respuesta;

    public delegate void OperacionResueltaHandler();
    public event OperacionResueltaHandler OnOperacionResuelta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DefinirOperacion();
        ComprobarRespuesta();
    }
    public void DefinirOperacion()
    {
        Debug.Log("Cuanto es 7 + ? =15");
        numero1 = Random.Range(1, 11);
        respuesta = 8;

        preguntaText.text = "Resuelve: " + "7" + " + " + numero1 + " = 15";
    }
    public void ComprobarRespuesta()
    {
        int respuestaUsuario;
        if (int.TryParse(respuestaInput.text, out respuestaUsuario))
        {
            if (respuestaUsuario == respuesta)
            {
                // Respuesta correcta
                Debug.Log("¡Respuesta correcta!");
                OnOperacionResuelta?.Invoke();
                Destroy(gameObject);
            }
            else
            {
                // Respuesta incorrecta, podrías mostrar un mensaje al jugador
                Debug.Log("Respuesta incorrecta. Inténtalo de nuevo.");
                // Recargar la escena actual
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
