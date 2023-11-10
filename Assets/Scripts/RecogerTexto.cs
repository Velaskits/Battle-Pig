using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CapturarTextoInput : MonoBehaviour
{
    private TMP_InputField inputField;

    void Start()
    {
        inputField = gameObject.GetComponent<TMP_InputField>();

        inputField.onValueChanged.AddListener(ActualizarTexto);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("Texto ingresado: " + inputField.text);

            inputField.text = "";
        }
    }

    void ActualizarTexto(string nuevoTexto)
    {
        Debug.Log("Texto actualizado: " + nuevoTexto);
    }
}

