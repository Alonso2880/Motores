using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryPanel;
    public GameObject itemUIPrefab;
    private Canvas c;
    public Button salir;
    //[HideInInspector] public guardar_Inventario inventory;
    

    
    void Start()
    {
        //inventory = FindFirstObjectByType<guardar_Inventario>(FindObjectsInactive.Include); 
        c = inventoryPanel.GetComponent<Canvas>();
        c.enabled = false;
        salir.onClick.AddListener(() => ads());

    }

    private void ads()
    {
        c.enabled = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            c.enabled = !c.enabled;
            Time.timeScale = c.enabled ? 0 : 1;
            if (c.enabled)
                UpdateUI();
        }
    }

    public void UpdateUI()
    {
        // Destruye todos los elementos viejos
        foreach (Transform child in itemsParent)
            Destroy(child.gameObject);

        // Obtén siempre la misma instancia
        var inventory = guardar_Inventario.Instance;
        if (inventory == null) return;

        // Recorre la lista
        foreach (var item in inventory.inventario)
        {
            var go = Instantiate(itemUIPrefab, itemsParent);
            go.GetComponent<TMP_Text>().text = $"{item.nombre} x{item.count}";
        }
    }
}
