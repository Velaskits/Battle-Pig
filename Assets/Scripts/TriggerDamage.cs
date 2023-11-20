using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    public Vida heart; 
    private void OnCollisionEnter2D(Collision2D colision)
    {
        if(colision.gameObject.tag == "javali"){
            heart.vidamaxima--;
        }
    }
}
