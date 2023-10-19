using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //variables de las instucciones.
    public GameObject TextoInstrucciones1;
    public GameObject TextoInstrucciones2;

    private int contador = 0;
    //variables de la historia.
    public GameObject PetterHistoria1;
    public GameObject PetterHistoria2;
    public GameObject PetterHistoria3;
    public GameObject PetterHistoria4;
    public GameObject PetterHistoria5;

    //Lista de casos de la historia.
    public enum EstatsGameManagerHistoria
    {
        escena1,
        escena2,
        escena3,
        escena4,
        escena5
    }

    //Lista de casos de las instrucciones
    public enum EstatsGameManager
    {
        Texto1,
        Texto2
    }

    private EstatsGameManager _estatGameManager;

    public EstatsGameManagerHistoria _estatGameManagerHistoria;

    // Start is called before the first frame update
    void Start()
    {
        //Esto es el estado de las instrucciones.
        _estatGameManager = EstatsGameManager.Texto1;

        //Esto es el estado de las escenas de la historia.
        _estatGameManagerHistoria = EstatsGameManagerHistoria.escena1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Actualiza los cambios de las instrucciones.
    private void ActualitzaEstatGameManagerInsrucciones()
    {
        switch (_estatGameManager)
        {
            case EstatsGameManager.Texto1:
                TextoInstrucciones1.SetActive(true);
                TextoInstrucciones2.SetActive(false);
                break;

            case EstatsGameManager.Texto2:
                TextoInstrucciones1.SetActive(false);
                TextoInstrucciones2.SetActive(true);
                break;
        }
    }


    //Actualiza los cambios de la historia.
    public void CambiarEscenaHistoria()
    {
        switch (_estatGameManagerHistoria)
        {
            case EstatsGameManagerHistoria.escena1:
                PetterHistoria1.SetActive(true);
                PetterHistoria2.SetActive(false);
                PetterHistoria3.SetActive(false);
                PetterHistoria4.SetActive(false);
                PetterHistoria5.SetActive(false);
                break;

            case EstatsGameManagerHistoria.escena2:
                PetterHistoria1.SetActive(false);
                PetterHistoria2.SetActive(true);
                PetterHistoria3.SetActive(false);
                PetterHistoria4.SetActive(false);
                PetterHistoria5.SetActive(false);
                break;

            case EstatsGameManagerHistoria.escena3:
                PetterHistoria1.SetActive(false);
                PetterHistoria2.SetActive(false);
                PetterHistoria3.SetActive(true);
                PetterHistoria4.SetActive(false);
                PetterHistoria5.SetActive(false);
                break;

            case EstatsGameManagerHistoria.escena4:
                PetterHistoria1.SetActive(false);
                PetterHistoria2.SetActive(false);
                PetterHistoria3.SetActive(false);
                PetterHistoria4.SetActive(true);
                PetterHistoria5.SetActive(false);
                break;

            case EstatsGameManagerHistoria.escena5:
                PetterHistoria1.SetActive(false);
                PetterHistoria2.SetActive(false);
                PetterHistoria3.SetActive(false);
                PetterHistoria4.SetActive(false);
                PetterHistoria5.SetActive(true);
                break;
        }
        contador++;

    }

    public void PassarATexto2()
    {
        _estatGameManager = EstatsGameManager.Texto2;
        ActualitzaEstatGameManagerInsrucciones();
    }

    public void PassarAEscena2()
    {
        if (contador == 1)
        {
            _estatGameManagerHistoria = EstatsGameManagerHistoria.escena2;
            CambiarEscenaHistoria();
        }
        else if(contador == 2){
             _estatGameManagerHistoria = EstatsGameManagerHistoria.escena3;
            CambiarEscenaHistoria();
        }
        else if(contador == 3){
             _estatGameManagerHistoria = EstatsGameManagerHistoria.escena4;
            CambiarEscenaHistoria();
        }
        else if(contador == 4){
             _estatGameManagerHistoria = EstatsGameManagerHistoria.escena5;
            CambiarEscenaHistoria();
        }

    }
}
