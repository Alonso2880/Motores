using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class guardar_Inventario : MonoBehaviour
{
    public static guardar_Inventario Instance { get; private set; }

    GameObject player, objeto, colisionado, huevoG;
    [HideInInspector] public List<InventoryItemData> inventario = new List<InventoryItemData>();
    [HideInInspector] public bool recogidaH = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            // Nos suscribimos al evento de escena cargada
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()

    {
        player = this.gameObject;
        objeto = GameObject.FindGameObjectWithTag("objeto");
        huevoG = GameObject.Find("Huevo");
        FindSceneReferences();

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Cada vez que cambie de escena, re-asignamos referencias
        FindSceneReferences();
    }

    void FindSceneReferences()
    {
        objeto = GameObject.FindGameObjectWithTag("objeto");
        huevoG = GameObject.Find("Huevo");
        colisionado = null;
    }


    void Update()
    {

        //Agregar item al inventario
        if (colisionado != null && Input.GetKeyDown(KeyCode.E))
        {

            if (colisionado.name == "Recogida de huevos")
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
    public void AgregarItem(string nombre, GameObject prefab)
    {
        InventoryItemData itemExiste = inventario.Find(item => item.nombre == nombre);
        InventoryUI inventoryUI = Object.FindAnyObjectByType<InventoryUI>();
        //huevo h = huevoG.GetComponent<huevo>();

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
        if (itemExiste != null)
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
}
