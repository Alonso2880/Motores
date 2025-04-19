using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Guardar_Inventario_Bosque : MonoBehaviour
{

    GameObject player, objeto, colisionado;
    [HideInInspector] public List<InventoryItemData> inventario = new List<InventoryItemData>();
    

    void Start()

    {
        player = this.gameObject;
        objeto = GameObject.FindGameObjectWithTag("objeto");

    }


    void Update()
    {

        //Agregar item al inventario
        if (colisionado != null && Input.GetKeyDown(KeyCode.E))
        {

            if (colisionado.name == "Recogida de huevos")
            {
                
                Debug.Log("Hola");
            }
            else
            {
                ItemCount itemData = colisionado.GetComponent<ItemCount>();
                if (itemData != null)
                {
                    //Esto controla en bucle. Si ambas condiciones son verdaderas el return termina la ejecución del bloque donde está (el forech sigue funcionando).
                    //Como tenemos el collider activo, esto evita que el jugador pueda guardar huevos cuando no los hay.
                    /* if (itemData.nombre == "Huevo(Clone)" && gallina.huevo <= 0)
                     {
                         return;
                     }*/

                    AgregarItem(itemData.nombre, itemData.prefab);
                    Destroy(colisionado);


                }
            }



        }


        /*foreach(InventoryItemData item in inventario)
         {
             Debug.Log(item.nombre + " x" + item.count);
         }*/
    }

    //Agregar item al inventario
    public void AgregarItem(string nombre, GameObject prefab)
    {
        InventoryItemData itemExiste = inventario.Find(item => item.nombre == nombre);
        InventoryUI inventoryUI = Object.FindAnyObjectByType<InventoryUI>();

        if (itemExiste != null)
        {
            itemExiste.count++;
            inventoryUI.UpdateUI();
        }
        else
        {

            InventoryItemData nuevoItem = new InventoryItemData();
            nuevoItem.nombre = nombre;
            nuevoItem.count = 1;
            nuevoItem.prefab = prefab;
            inventario.Add(nuevoItem);
        }
        /* InventoryUI inventoryUI = Object.FindAnyObjectByType<InventoryUI>();
         if (inventoryUI != null && inventoryUI.inventoryPanel.activeSelf)
         {
             inventoryUI.UpdateUI();
         }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("objeto"))
        {
            colisionado = collision.gameObject;
        }
    }

    void OnDisable() 
    {
        if (GlobalInventory.Instance != null)
        {
            GlobalInventory.Instance.bosqueItems = new List<InventoryItemData>(inventario);
        }
    }

}
