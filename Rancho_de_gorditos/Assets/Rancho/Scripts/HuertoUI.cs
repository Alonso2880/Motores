using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HuertoUI : MonoBehaviour
{
    public Button Salir;
    public Button Semilla;
    private Canvas c;
    public GameObject huertoUI;
    private GameObject Huerto;

    [HideInInspector] public List<InventoryItemData> inventario = new List<InventoryItemData>();
    void Start()
    {
        c = huertoUI.GetComponent<Canvas>();
        Salir.onClick.AddListener(() => ads());
        Semilla.onClick.AddListener(() => opciones(1));
        c.enabled = false;
        Huerto = GameObject.Find("Huerto");
    }

    private void ads()
    {
        c.enabled = false;
        Time.timeScale = 1;
    }

    public void inicio()
    {
        c.enabled = true;
        Time.timeScale = 0;
    }

    private void opciones(int i)
    {
        
        huerto hu = Huerto.GetComponent<huerto>();
        switch (i)
        {
            case 1:
                hu.Semilla();
                ads();
                break;
            case 2:
                if(hu.crec >= 3)
                {
                    Destroy(hu.semilla1Prefab);
                    
                }
                break;
        }
    }

  
    
    void Update()
    {
        
    }
}
