using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tienda : MonoBehaviour
{
    GameObject jugador, contMonedas, MenuV;
    int monedasT=0;


    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        contMonedas = GameObject.Find("Canvas");
        MenuV = GameObject.Find("MenuVender");
    }

   
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        Menu_Vender m = MenuV.GetComponent<Menu_Vender>();
        if (collision.gameObject.CompareTag("Player"))
        {
            m.AbrirMenu();
        }
    }

    public void Huevo(int cantidadAVender)
    {
        var inventario = jugador.GetComponent<guardar_Inventario>().inventario;
        var contador = contMonedas.GetComponent<Contador_Moneas>();

        foreach (InventoryItemData item in inventario)
        {
            if (item.nombre != "Huevo" || cantidadAVender <= 0)
                continue;

            // vendemos como máximo los que hay en inventario
            int vendibles = Mathf.Min(cantidadAVender, item.count);

            // restar del inventario
            item.count -= vendibles;
            // sumar monedas
            contador.monedas += vendibles;

            // descontar de lo que aún queda por vender
            cantidadAVender -= vendibles;

            // si ya vendimos todo lo que pedía, salimos
            if (cantidadAVender <= 0)
                break;
        }
    }
}
