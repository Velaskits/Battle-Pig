using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoCronometro;
    private float tiempo;

    private int tiempoMinutos, tiempoSegundos, TiempoDecimasDeSegundos;

    void FuncionCronometro()
    {
        tiempo += Time.deltaTime;

        tiempoMinutos = Mathf.FloorToInt(tiempo / 60);
        tiempoSegundos = Mathf.FloorToInt(tiempo % 60);
        TiempoDecimasDeSegundos = Mathf.FloorToInt((tiempo % 1) * 100);

        textoCronometro.text = string.Format("{0:00}:{1:00}:{2:00}", tiempoMinutos, tiempoSegundos, TiempoDecimasDeSegundos);
    }

    // Guardar tiempo al cambiar de escena
    void OnDestroy()
    {
        PlayerPrefs.SetFloat("TiempoGuardado", tiempo);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        FuncionCronometro();
    }
}
