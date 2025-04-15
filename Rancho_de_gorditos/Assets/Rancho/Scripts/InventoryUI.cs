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
    private guardar_Inventario inventory;

    
    void Start()
    {
        inventory = FindFirstObjectByType<guardar_Inventario>(FindObjectsInactive.Include);
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
            Time.timeScale = 0;
            c.enabled = true;   
            if (inventoryPanel.activeSelf)
            {
                UpdateUI();
            }
        }
    }

    public void UpdateUI()
    {
        foreach (Transform child in itemsParent)
        {
            Destroy(child.gameObject);
        }

        foreach (InventoryItemData item in inventory.inventario)
        {
            GameObject itemUI = Instantiate(itemUIPrefab, itemsParent);
            itemUI.GetComponent<TMP_Text>().text = $"{item.nombre} x{item.count}";
        }
    }
}
