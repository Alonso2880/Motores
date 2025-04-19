using UnityEngine;
using System.Collections.Generic;

public class GlobalInventory : MonoBehaviour
{

    public static GlobalInventory Instance;

    // Items del bosque que se transferirán al rancho
    public List<InventoryItemData> bosqueItems = new List<InventoryItemData>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Evita duplicados
        }
    }
}
