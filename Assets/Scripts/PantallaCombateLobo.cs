using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PantallaCombateLobo : MonoBehaviour
{
    [SerializeField] int vidas;
    [SerializeField] Slider slidervidas;
    // Start is called before the first frame update
    void Start()
    {
        slidervidas.maxValue = vidas;
        slidervidas.value = slidervidas.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D otro)
    {
        if (otro.gameObject.CompareTag("boladebarro"))
        {
            vidas--;
            slidervidas.value = vidas;
            if (vidas<=0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
