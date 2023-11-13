using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControladorDePuntos : MonoBehaviour
{
    public static ControladorDePuntos Instance;
    [SerializeField] private float CantidadPuntos;
    private void Awake(){
        if(ControladorDePuntos.Instance == null){
            ControladorDePuntos.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void SumarPuntos(float puntos){
        CantidadPuntos += puntos;
    }
}
