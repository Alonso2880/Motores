using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Contador_Moneas : MonoBehaviour
{
    public TextMeshProUGUI Cont_monedas;
    private int monedas = 0;
    void Start()
    {
        ActualizarMonedas();
    }

    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            monedas++;
            ActualizarMonedas();
        }
    }
    private void ActualizarMonedas()
    {
        Cont_monedas.text = monedas.ToString();
    }
}
