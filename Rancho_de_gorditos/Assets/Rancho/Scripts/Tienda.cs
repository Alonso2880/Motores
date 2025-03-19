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

    public void Huevo()
    {
        guardar_Inventario jscript = jugador.GetComponent<guardar_Inventario>();
        Contador_Moneas cont = contMonedas.GetComponent<Contador_Moneas>();
            foreach (InventoryItemData item in jscript.inventario)
            {
                if (item.nombre == "Huevo")
                {
                    if (cont.monedas == 0)
                    {
                        monedasT = item.count;
                        item.count = 0;
                        cont.monedas = monedasT;
                        monedasT = 0;
                    }
                    else
                    {
                        monedasT = item.count;
                        item.count = 0;
                        cont.monedas += monedasT;
                        monedasT = 0;
                    }


                }
            }
        
    }
}
