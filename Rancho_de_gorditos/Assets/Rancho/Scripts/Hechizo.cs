using System.Collections.Generic;
using UnityEngine;

public class Hechizo : MonoBehaviour
{
    private GameObject hechizos, Casa;
    [HideInInspector] public GameObject col;
    public GameObject prefabSemilla;
    [HideInInspector] public List<InventoryItemData> inventario = new List<InventoryItemData>();
    [HideInInspector] public bool enZona = false;
    private bool toD = false, zaD = false, maD = false, patD = false, piD = false, naD = false;
    private int d;
    void Start()
    {
        hechizos = GameObject.Find("Hechizos");
        Casa = GameObject.Find("CasaBrujita");
        d = 0;
    }


    void Update()
    {
        guardar_Inventario inventarioScript = GameObject.FindAnyObjectByType<guardar_Inventario>();
        Hechizos h = hechizos.GetComponent<Hechizos>();
        casa c = Casa.GetComponent<casa>();

        if(c.dia != d)
        {
            d= c.dia;
            toD = false;
            zaD = false;
            maD = false;
            patD = false;
            piD = false;
            naD = false;
        }

        if (enZona && Input.GetKeyDown(KeyCode.H))
        {
            h.canvas.enabled = true;

        }

        if (h.tomate && !toD)
        {
            Debug.Log("Has conseguido un tomate");
            inventarioScript.AgregarItem("Tomate", prefabSemilla);
            h.tomate = false;
            toD = true;
        }

        if (h.zanahoria && !zaD)
        {
            Debug.Log("Has conseguido una zanahoria");
            inventarioScript.AgregarItem("Zanahoria", prefabSemilla);
            h.zanahoria = false;
            zaD = true;
        }

        if (h.manzana && !maD)
        {
            Debug.Log("Has conseguido una manzana");
            inventarioScript.AgregarItem("Manzana", prefabSemilla);
            h.manzana = false;
            maD = true;
        }

        if (h.patatas && !patD)
        {
            Debug.Log("Has conseguido una patata");
            inventarioScript.AgregarItem("Patata", prefabSemilla);
            h.patatas = false;
            patD = true;
        }

        if (h.pimientos && !piD)
        {
            Debug.Log("Has conseguido unos pimientos");
            inventarioScript.AgregarItem("Pimiento", prefabSemilla);
            h.pimientos = false;
            piD = true;
        }

        if (h.naranjas && !naD)
        {
            Debug.Log("Has conseguido unas naranjas");
            inventarioScript.AgregarItem("Naranja", prefabSemilla);
            h.naranjas = false;
            naD = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlantaSemilla1"))
        {
            enZona = true;
            col = collision.gameObject;
            

        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlantaSemilla1"))
        {
            enZona = false;
            
        }

    }
}

