using System.Collections.Generic;
using UnityEngine;

public class Hechizo : MonoBehaviour
{
    private GameObject hechizos;
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

        /*if ()
        {
            Debug.Log("Has conseguido una semilla");
            inventarioScript.AgregarItem("semilla", prefabSemilla);
             = false;
        }*/
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
            
        }

    }
}

