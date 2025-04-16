using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HuertoUI : MonoBehaviour
{
    public Button Salir;
    public Button Semilla, Cosechar;
    private Canvas c;
    public GameObject huertoUI;
    private GameObject Huerto;
    private int semillas = 2, frutas =3;

    [HideInInspector] public List<InventoryItemData> inventario = new List<InventoryItemData>();
    void Start()
    {
        c = huertoUI.GetComponent<Canvas>();
        Salir.onClick.AddListener(() => ads());
        Semilla.onClick.AddListener(() => opciones(1));
        Cosechar.onClick.AddListener(() => opciones(2));
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
                    guardar_Inventario inventarioScript = GameObject.FindAnyObjectByType<guardar_Inventario>();

                    if(inventarioScript != null)
                    {
                        for(int x=0; x<semillas; x++)
                        {
                            inventarioScript.AgregarItem("semilla", hu.semilla1Prefab);
                        }

                        for(int y=0; y<frutas; y++)
                        {
                            inventarioScript.AgregarItem("Fruta", null);
                        }
                    }
                }
                else
                {
                    Debug.Log("No hay nada que cosechar");
                }
                break;
        }
    }

  
    
    void Update()
    {
        
    }
}
