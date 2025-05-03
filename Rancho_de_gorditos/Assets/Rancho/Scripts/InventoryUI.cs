using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    [HideInInspector] public List<InventoryItemData> inventario = new List<InventoryItemData>();

    public Transform itemsParent;
    public GameObject inventoryPanel;
    public GameObject itemUIPrefab;
    private Canvas c;
    public Button salir;
    private bool adios=false;

    private GameObject player;

    public Image Icono1;
    public Button Icono1Button;
    private bool Icono1B = false;
    public Sprite Spritehuevo;

    public Image PolariodHuevo;
    public Image TextoHuevo;
    
    void Start()
    {
        
        c = inventoryPanel.GetComponent<Canvas>();
        c.enabled = false;
        salir.onClick.AddListener(() => ads());
        player = GameObject.Find("Player");

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
                {
                    UpdateUI();
                }
                adios = true;
        }

        MostrarIconos();
    }


    private void MostrarIconos()
    {
        var inventory = guardar_Inventario.Instance;
        InventoryItemData huevoItem = inventory.inventario.Find(item => item.nombre == "Huevo");

        if(huevoItem != null && huevoItem.count >= 1)
        {
            Debug.Log("Huevo");

            if (!Icono1B)
            {
                Icono1.sprite = Spritehuevo;
                Icono1.enabled = true;
                Icono1Button.onClick.AddListener(InfoHuevo);
            }
        }


    }


    private void InfoHuevo()
    {
        PolariodHuevo.enabled = true;
        TextoHuevo.enabled = true;
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
