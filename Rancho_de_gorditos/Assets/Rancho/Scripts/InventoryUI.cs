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

    public List<Image> Iconos;
    public List<Button> IconoButtons;
    public List<bool> IconosB;


    //Sprites
    public Sprite Spritehuevo;
    public Sprite Spritecarne;
    public Sprite SpriteLana;
    public Sprite SpriteLeche;
    public Sprite SpriteMadera;
    //public Sprite SpritePiedra;
    public Sprite SpriteManzana;
    public Sprite SpriteNaranja;
    public Sprite SpritePatata;
    public Sprite SpriteZanahoria;
    public Sprite SpriteTomate;
    public Sprite SpritePimiento;
    public Sprite SpriteSemillaPatata;
    public Sprite SpriteSemillaPimiento;
    public Sprite SpriteSemillaTomate;
    public Sprite SpriteSemillaZanahoria;

    //Polaroids
    public Image PolariodHuevo;
    public Image PolariodCarne;
    public Image PolariodLana;
    public Image PolariodLeche;
    public Image PolariodMadera;
    public Image PolariodPiedra;
    public Image PolariodManzana;
    public Image PolariodNaranja;
    public Image PolariodPatata;
    public Image PolariodZanahoria;
    public Image PolariodTomate;
    public Image PolariodPimiento;
    public Image PolariodSemillaPatata;
    public Image PolariodSemillaPimiento;
    public Image PolariodSemillaTomate;
    public Image PolariodSemillaZanahoria;

    //Textos
    public Image TextoHuevo;
    public Image TextoCarne;
    public Image TextoLana;
    public Image TextoLeche;
    public Image TextoMadera;
    public Image TextoPiedra;
    public Image TextoManzana;
    public Image TextoNaranja;
    public Image TextoPatata;
    public Image TextoZanahoria;
    public Image TextoTomate;
    public Image TextoPimiento;
    public Image TextoSemillaPatata;
    public Image TextoSemillaPimiento;
    public Image TextoSemillaTomate;
    public Image TextoSemillaZanahoria;


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

                DesaparecerIconos();

                MostrarIconoHuevo();
                MostrarIconoZanahoria();
            }
                adios = true;
        }

        
    }


    private void MostrarIconoHuevo()
    {
        var inventory = guardar_Inventario.Instance;
        InventoryItemData huevoItem = inventory.inventario.Find(item => item.nombre == "Huevo");

        if (huevoItem != null && huevoItem.count >= 1)
        {
            for(int i =0; i<Iconos.Count; i++)
            {
                if (!IconosB[i])
                {
                    Iconos[i].sprite = Spritehuevo;
                    Iconos[i].enabled = true;
                    IconoButtons[i].onClick.AddListener(InfoHuevo);
                    IconosB[i] = true;
                    break;
                }
                
            }


        }
        else
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (IconosB[i] && Iconos[i].sprite == Spritehuevo)
                {
                    Iconos[i].sprite = null;
                    Iconos[i].enabled = false;
                    IconoButtons[i].onClick.RemoveListener(InfoHuevo);
                    IconosB[i] = false;
                }
            }
        }
    }

    private void MostrarIconoZanahoria()
    {
        var inventory = guardar_Inventario.Instance;
        InventoryItemData ZanahoriaItem = inventory.inventario.Find(item => item.nombre == "Semilla_Zanahoria");

        if (ZanahoriaItem != null && ZanahoriaItem.count >= 1)
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (!IconosB[i])
                {
                    Iconos[i].sprite = SpriteSemillaZanahoria;
                    Iconos[i].enabled = true;
                    IconoButtons[i].onClick.AddListener(InfoSemillaZanahoria);
                    IconosB[i] = true;
                    break;
                }
                
            }


        }
        else
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (IconosB[i] && Iconos[i].sprite == SpriteSemillaZanahoria)
                {
                    Iconos[i].sprite = null;
                    Iconos[i].enabled = false;
                    IconoButtons[i].onClick.RemoveListener(InfoSemillaZanahoria);
                    IconosB[i] = false;
                }
            }
        }
    }

    //Funciones de información
    private void InfoHuevo()
    {
        DesactivarInfo();
        PolariodHuevo.enabled = true;
        TextoHuevo.enabled = true;
    }

    private void InfoSemillaZanahoria()
    {
        DesactivarInfo();
        PolariodSemillaZanahoria.enabled = true;
        TextoSemillaZanahoria.enabled=true;
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

    //Este código evita que al darle varias vecea a la I se duplicaran los sprites
    private void DesaparecerIconos()
    {
        for (int i = 0; i < Iconos.Count; i++)
        {
            if (IconosB[i])
            {
                // Elimina cualquier listener que pudiera quedarse para evitar callbacks colgando
                IconoButtons[i].onClick.RemoveAllListeners();

                // Limpia el sprite y la visibilidad
                Iconos[i].sprite = null;
                Iconos[i].enabled = false;

                // Marca el slot como vacío
                IconosB[i] = false;
            }
        }
    }

    private void DesactivarInfo()
    {
        PolariodHuevo.enabled = false;
        PolariodCarne.enabled = false;
        PolariodLana.enabled = false;
        PolariodLeche.enabled = false;
        PolariodMadera.enabled = false;
        PolariodPiedra.enabled = false;
        PolariodManzana.enabled = false;
        PolariodNaranja.enabled = false;
        PolariodPatata.enabled = false;
        PolariodZanahoria.enabled = false;
        PolariodTomate.enabled = false;
        PolariodPimiento.enabled = false;
        PolariodSemillaPatata.enabled = false;
        PolariodSemillaPimiento.enabled = false;
        PolariodSemillaTomate.enabled = false;
        PolariodSemillaZanahoria.enabled = false;

        TextoHuevo.enabled = false;
        TextoCarne.enabled = false;
        TextoLana.enabled = false;
        TextoLeche.enabled = false;
        TextoMadera.enabled = false;
        TextoPiedra.enabled = false;
        TextoManzana.enabled = false;
        TextoNaranja.enabled = false;
        TextoPatata.enabled = false;
        TextoZanahoria.enabled = false;
        TextoTomate.enabled = false;
        TextoPimiento.enabled = false;
        TextoSemillaPatata.enabled = false;
        TextoSemillaPimiento.enabled = false;
        TextoSemillaTomate.enabled = false;
        TextoSemillaZanahoria.enabled = false;
    }

}
