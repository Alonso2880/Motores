using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HuertoUI : MonoBehaviour
{
    public Button Salir;
    public Button Semilla, Cosechar, comprarH, mejorar;
    private Canvas c;
    public GameObject huertoUI, prefabHuerto;
    private GameObject Huerto, terrenoHuerto;
    public Transform huecoHuerto;
    private int semillas = 2, frutas =3;
    private bool n=false;

    private huerto huScript;
    private GameObject huertoG;

    [HideInInspector] public GameObject contmonedas;

    [HideInInspector] public List<InventoryItemData> inventario = new List<InventoryItemData>();
    void Start()
    {
        c = huertoUI.GetComponent<Canvas>();
        Salir.onClick.AddListener(() => ads());
        Semilla.onClick.AddListener(() => opciones(1));
        Cosechar.onClick.AddListener(() => opciones(2));
        comprarH.onClick.AddListener(() => opciones(3));
        mejorar.onClick.AddListener(()=>  opciones(4));
        c.enabled = false;
        
        contmonedas = GameObject.Find("Canvas");
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
        Contador_Moneas cont = contmonedas.GetComponent<Contador_Moneas>();
        
        switch (i)
        {

            case 3:
                //Comprar
                if (cont.monedas >= 3)
                {
                    
                    huertoG = Instantiate(prefabHuerto, huecoHuerto.position, huecoHuerto.rotation);
                    huertoG.transform.SetParent(huecoHuerto);

                    huScript = huertoG.GetComponent<huerto>();

                    n = true;
                    cont.monedas -= 3;
                }
                else
                {
                    Debug.Log("No tienes suficientes monedas");
                }
                break;

            case 1:
                if (n)
                {
                    huScript.Semilla();
                    ads();
                }
                else
                {
                    Debug.Log("No hay huerto");
                }
                
                break;
            case 2:
                if (n)
                {
                    if (huScript.crec >= 3)
                    {
                        Destroy(huScript.semilla1Prefab);
                        guardar_Inventario inventarioScript = GameObject.FindAnyObjectByType<guardar_Inventario>();

                        if (inventarioScript != null)
                        {
                            for (int x = 0; x < semillas; x++)
                            {
                                inventarioScript.AgregarItem("semilla", huScript.semilla1Prefab);
                            }

                            for (int y = 0; y < frutas; y++)
                            {
                                inventarioScript.AgregarItem("Fruta", null);
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("No hay nada que cosechar");
                    }
                }
                else
                {
                    Debug.Log("No hay huerto");
                }

                break;

            case 4:
                if(cont.monedas >= 5)
                {
                    semillas += 1;
                    frutas += 2;
                    cont.monedas -= 5;
                }
                else
                {
                    Debug.Log("No tienes suficiente diner");
                }
                break;

        }
    }

  
    
    void Update()
    {
        
    }
}
