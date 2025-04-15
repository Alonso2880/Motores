using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class guardar_Inventario : MonoBehaviour
{
    GameObject player, objeto, colisionado, huevoG;
    [HideInInspector] public List<InventoryItemData> inventario = new List<InventoryItemData>();
    Gallina gallina;

    //Generar la gallina
    public GameObject gallinaPrefab;
    public Transform puntoSujección;
    public float fuerzaLanzamiento = 10f;

    [HideInInspector] public GameObject gallinaActual;
    [HideInInspector] public bool tieneGallina = false;
    [HideInInspector] public bool recogidaH = false;


    void Start()

    {
        player = this.gameObject;
        objeto = GameObject.FindGameObjectWithTag("objeto");
        gallina = GameObject.Find("Gallina").GetComponent<Gallina>();
        huevoG = GameObject.Find("Huevo");

    }


    void Update()
    {
        //Coger gallina
        if (tieneGallina)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                LanzarGallina();
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            RecogerGallina();
        }

        

        //Agregar item al inventario
        if (colisionado != null && Input.GetKeyDown(KeyCode.E))
        {
            
            if(colisionado.name == "Recogida de huevos")
            {
                AgregarHuevo();
                Debug.Log("Hola");
            }
            else
            {
                ItemCount itemData = colisionado.GetComponent<ItemCount>();
                if (itemData != null)
                {
                    //Esto controla en bucle. Si ambas condiciones son verdaderas el return termina la ejecución del bloque donde está (el forech sigue funcionando).
                    //Como tenemos el collider activo, esto evita que el jugador pueda guardar huevos cuando no los hay.
                   /* if (itemData.nombre == "Huevo(Clone)" && gallina.huevo <= 0)
                    {
                        return;
                    }*/

                    AgregarItem(itemData.nombre, itemData.prefab);
                    Destroy(colisionado);
                    

                }
            }
            

            
        }


        /*foreach(InventoryItemData item in inventario)
         {
             Debug.Log(item.nombre + " x" + item.count);
         }*/
    }

    //Agregar item al inventario
    private void AgregarItem(string nombre, GameObject prefab)
    {
        InventoryItemData itemExiste = inventario.Find(item => item.nombre == nombre);
        InventoryUI inventoryUI = Object.FindAnyObjectByType<InventoryUI>();
        huevo h = huevoG.GetComponent<huevo>();

        if (itemExiste != null)
        {
            itemExiste.count++;
            inventoryUI.UpdateUI();
        }
        else
        {

            InventoryItemData nuevoItem = new InventoryItemData();
            nuevoItem.nombre = nombre;
            nuevoItem.count = 1;
            nuevoItem.prefab = prefab;
            inventario.Add(nuevoItem);
        }
       /* InventoryUI inventoryUI = Object.FindAnyObjectByType<InventoryUI>();
        if (inventoryUI != null && inventoryUI.inventoryPanel.activeSelf)
        {
            inventoryUI.UpdateUI();
        }*/
    }

    private void AgregarHuevo()
    {
        InventoryItemData itemExiste = inventario.Find(item => item.nombre == "Huevo");
        huevo h = huevoG.GetComponent<huevo>();
        if(itemExiste != null)
        {
            
            itemExiste.count += h.HuevoTotal;
            h.Reset();
        }
        else
        {
            InventoryItemData nuevoItem = new InventoryItemData();
            nuevoItem.nombre = "Huevo";
            nuevoItem.count = h.HuevoTotal;
            inventario.Add(nuevoItem);
            h.Reset();
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("objeto"))
        {
            colisionado = collision.gameObject;
        }
        if (collision.gameObject.CompareTag("Recogida_Huevos"))
        {
            colisionado = collision.gameObject;
            recogidaH = true;
            
        }
    }

    //Coger gallina
    public void ObtenerGallina()
    {
        gallinaActual = Instantiate(gallinaPrefab, puntoSujección.position, puntoSujección.rotation);
        gallinaActual.transform.SetParent(puntoSujección);
        gallinaActual.GetComponent<Rigidbody>().isKinematic = true;

        Gallina scriptGallina = gallinaActual.GetComponent<Gallina>();
        if (scriptGallina != null)
        {
            scriptGallina.enabled = false;
        }

        tieneGallina = true;
    }

    private void LanzarGallina()
    {
        gallinaActual.transform.SetParent(null);
        Rigidbody rb = gallinaActual.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        Gallina scriptGallina = gallinaActual.GetComponent<Gallina>();
        if (scriptGallina != null)
        {
            scriptGallina.enabled = true;
            scriptGallina.scriptActivo = true;
        }

        Vector3 direccionLanzamiento = transform.forward;
        rb.AddForce(direccionLanzamiento * fuerzaLanzamiento, ForceMode.Impulse);
        tieneGallina = false;
    }

    private void RecogerGallina()
    {
        Collider[] collides = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider col in collides)
        {
            if (col.CompareTag("Gallina") && !tieneGallina)
            {
                gallinaActual = col.gameObject;

                Gallina scriptGallina = gallinaActual.GetComponent<Gallina>();
                if (scriptGallina != null)
                {
                    scriptGallina.enabled = false;
                }

                gallinaActual.transform.SetParent(puntoSujección);
                gallinaActual.transform.position = puntoSujección.position;
                gallinaActual.GetComponent<Rigidbody>().isKinematic = true;
                tieneGallina = true;
                break;
            }
        }
    }
}
