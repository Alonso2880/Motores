using System.Collections.Generic;
using UnityEngine;

public class Hechizo : MonoBehaviour
{
    private GameObject hechizos;
    [HideInInspector] public GameObject col;
    public GameObject prefabSemilla;
    [HideInInspector] public List<InventoryItemData> inventario = new List<InventoryItemData>();
    [HideInInspector] public bool enZona = false;
    void Start()
    {
        hechizos = GameObject.Find("Hechizos");
    }


    void Update()
    {
        guardar_Inventario inventarioScript = GameObject.FindAnyObjectByType<guardar_Inventario>();
        Hechizos h = hechizos.GetComponent<Hechizos>();
        if (enZona && Input.GetKeyDown(KeyCode.H))
        {
            h.canvas.enabled = true;
        }

        if (h.tomate)
        {
            Debug.Log("Has conseguido un tomate");
            inventarioScript.AgregarItem("tomate", prefabSemilla);
            h.tomate = false;
        }

        if (h.zanahoria)
        {
            Debug.Log("Has conseguido una zanahoria");
            inventarioScript.AgregarItem("zanahoria", prefabSemilla);
            h.zanahoria = false;
        }

        if (h.manzana)
        {
            Debug.Log("Has conseguido una manzana");
            inventarioScript.AgregarItem("manzana", prefabSemilla);
            h.manzana = false;
        }

        if (h.patatas)
        {
            Debug.Log("Has conseguido una patata");
            inventarioScript.AgregarItem("patata", prefabSemilla);
            h.patatas = false;
        }

        if (h.pimientos)
        {
            Debug.Log("Has conseguido unos pimientos");
            inventarioScript.AgregarItem("pimientos", prefabSemilla);
            h.pimientos = false;
        }

        if (h.naranjas)
        {
            Debug.Log("Has conseguido unas naranjas");
            inventarioScript.AgregarItem("naranjas", prefabSemilla);
            h.naranjas = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlantaSemilla1"))
        {
            enZona = true;
            
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlantaSemilla1"))
        {
            enZona = false;
            col = collision.gameObject;
            
        }

    }
}

