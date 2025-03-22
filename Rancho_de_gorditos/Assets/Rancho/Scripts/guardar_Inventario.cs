using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class guardar_Inventario : MonoBehaviour
{
    GameObject player, objeto, colisionado;
    [HideInInspector] public List<InventoryItemData> inventario = new List<InventoryItemData>();
    Gallina gallina;

    //Generar la gallina
    public GameObject gallinaPrefab;
    public Transform puntoSujección;
    public float fuerzaLanzamiento = 10f;

    [HideInInspector] public GameObject gallinaActual;
    [HideInInspector] public bool tieneGallina = false;


    void Start()

    {
        player = this.gameObject;
        objeto = GameObject.FindGameObjectWithTag("objeto");
        gallina = GameObject.Find("Gallina").GetComponent<Gallina>();

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

        if(Input.GetKeyDown(KeyCode.E))
        {
            RecogerGallina();
        }


        //Agregar item al inventario
        if (colisionado != null && Input.GetKeyDown(KeyCode.E))
        {
            ItemCount itemData = colisionado.GetComponent<ItemCount>();

            if(itemData != null )
            {
                //Esto controla en bucle. Si ambas condiciones son verdaderas el return termina la ejecución del bloque donde está (el forech sigue funcionando).
                //Como tenemos el collider activo, esto evita que el jugador pueda guardar huevos cuando no los hay.
                if(itemData.nombre == "Huevo(Clone)" && gallina.huevo <= 0)
                {
                    return;
                }
                
                AgregarItem(itemData.nombre, itemData.prefab);
                if(colisionado.name == "Huevo(Clone)")
                {
                    colisionado = null;

                }
                else
                {
                    Destroy(colisionado);
                    colisionado = null;
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
        

        if (itemExiste != null)
        {
            
            //Si es un huevo
            if (itemExiste.nombre == "Huevo")
            {
                itemExiste.count += gallina.huevo;
                gallina.ResetHuevos();
                
            }
            else
            {
                itemExiste.count++;
            }
            
        }
        else
        {
           //Si es un huevo
            if(nombre == "Huevo")
            {
                InventoryItemData nuevoItem = new InventoryItemData();
                nuevoItem.nombre = nombre;
                nuevoItem.count = gallina.huevo;
                nuevoItem.prefab = prefab;
                inventario.Add(nuevoItem);
                gallina.ResetHuevos();
                
            }
            else
            {
                InventoryItemData nuevoItem = new InventoryItemData();
                nuevoItem.nombre = nombre;
                nuevoItem.count = 1;
                nuevoItem.prefab = prefab;
                inventario.Add(nuevoItem);
            }
        }
    }
    
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("objeto"))
        {
            colisionado = collision.gameObject;
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
        if(scriptGallina != null)
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
        foreach(Collider col in collides)
        {
            if(col.CompareTag("Gallina") && !tieneGallina)
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
