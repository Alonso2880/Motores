using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class guardar_Inventario : MonoBehaviour
{
    GameObject player, objeto, colisionado;
    List<InventoryItemData> inventario = new List<InventoryItemData>();
    

    void Start()
    {
        player = this.gameObject;
        objeto = GameObject.FindGameObjectWithTag("objeto");
        
    }


    void Update()
    {
        if(colisionado != null && Input.GetKeyDown(KeyCode.E))
        {
            ItemCount itemData = colisionado.GetComponent<ItemCount>();

            if(itemData != null )
            {
                AgregarItem(itemData.nombre, itemData.prefab);
                Destroy(colisionado);
                colisionado = null;
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
            
            itemExiste.count++;
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("objeto"))
        {
            colisionado = collision.gameObject;
        }
    }
}
