using UnityEngine;

public class Tienda_Comprar : MonoBehaviour
{
    GameObject jugador, contMonedas;
    
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        contMonedas = GameObject.Find("Canvas");
    }

   
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        guardar_Inventario jscript = jugador.GetComponent<guardar_Inventario>();
        Contador_Moneas cont = contMonedas.GetComponent<Contador_Moneas>();

        if (collision.gameObject.CompareTag("Player") && !jscript.tieneGallina)
        {
            if(cont.monedas < 4)
            {
                Debug.Log("Monedas insuficientes");
            }
            else
            {
                Debug.Log("Comprado una gallina por 4 monedas");
                cont.monedas -= 4;
                jscript.ObtenerGallina();
            }
        }

    }
}
