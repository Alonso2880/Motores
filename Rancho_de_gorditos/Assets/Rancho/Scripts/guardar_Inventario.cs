using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class guardar_Inventario : MonoBehaviour
{
    GameObject player, objeto, colisionado;
    List<InventoryItemData> inventario = new List<InventoryItemData>();
    Gallina gallina;
    

    void Start()

    {
        player = this.gameObject;
        objeto = GameObject.FindGameObjectWithTag("objeto");
        gallina = GameObject.Find("Gallina").GetComponent<Gallina>();

    }


    void Update()
    {
        
        if (colisionado != null && Input.GetKeyDown(KeyCode.E))
        {
            ItemCount itemData = colisionado.GetComponent<ItemCount>();

            if(itemData != null )
            {
                //Esto controla en bucle. Si ambas condiciones son verdaderas el return termina la ejecución del bloque donde está (el forech sigue funcionando).
                //Como tenemos el collider activo, esto evita que el jugador pueda guardar huevos cuando no los hay.
                if(itemData.nombre == "Huevo" && gallina.huevo <= 0)
                {
                    return;
                }
                
                AgregarItem(itemData.nombre, itemData.prefab);
                if(colisionado.name == "Huevo")
                {
                    colisionado = null;

                }
                else
                {
                    Destroy(colisionado);
                    colisionado = null;
                }
                
            }
        }


       foreach(InventoryItemData item in inventario)
        {
            Debug.Log(item.nombre + " x" + item.count);
        }
    }

    private void AgregarItem(string nombre, GameObject prefab)
    {
        InventoryItemData itemExiste = inventario.Find(item => item.nombre == nombre);
        

        if (itemExiste != null)
        {
            
            //Si es un huevo
            if (itemExiste.nombre == "Huevo")
            {
                itemExiste.count += gallina.huevo;
                gallina.ResetHuevos();
                
            }
            else
            {
                itemExiste.count++;
            }
            
        }
        else
        {
           //Si es un huevo
            if(nombre == "Huevo")
            {
                InventoryItemData nuevoItem = new InventoryItemData();
                nuevoItem.nombre = nombre;
                nuevoItem.count = gallina.huevo;
                nuevoItem.prefab = prefab;
                inventario.Add(nuevoItem);
                gallina.ResetHuevos();
                
            }
            else
            {
                InventoryItemData nuevoItem = new InventoryItemData();
                nuevoItem.nombre = nombre;
                nuevoItem.count = 1;
                nuevoItem.prefab = prefab;
                inventario.Add(nuevoItem);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("objeto"))
        {
            colisionado = collision.gameObject;
        }
    }
}
