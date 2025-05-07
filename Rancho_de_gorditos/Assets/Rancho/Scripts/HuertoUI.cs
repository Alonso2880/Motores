using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HuertoUI : MonoBehaviour
{
    public Button Zanahoria, Patata, Cerrar, ComprarHuerto, MejorarHuerto, Cosechar;
    private HuertoManager huertoManager;
    public Canvas canvas;
    public GameObject HuertoPrerfab;
    public Transform HuecoHuerto;
    private GameObject HuertoG, jugador;

    void Start()
    {
        huertoManager = Object.FindFirstObjectByType<HuertoManager>();
        Zanahoria.onClick.AddListener(() => Plantar(1));
        Patata.onClick.AddListener(() => Plantar(2));
        Cerrar.onClick.AddListener(() => CerrarUI());
        ComprarHuerto.onClick.AddListener(() => ComprarH());
        Cosechar.onClick.AddListener(() => cosechar());
        canvas.enabled = false;
        jugador = GameObject.Find("Player");
    }

    private void Plantar(int tipo)
    {
        guardar_Inventario g = jugador.GetComponent<guardar_Inventario>();
        InventoryItemData itemZa = g.inventario.Find(item => item.nombre == "Semilla_Zanahoria");
        InventoryItemData itemPa = g.inventario.Find(item => item.nombre == "Semilla_Patata");

        if (tipo == 1)
        {
            if(itemZa != null && itemZa.count >= 1)
            {
                bool exito = huertoManager.PlantarSemilla(tipo);
                itemZa.count--;
                if (!exito)
                {
                    Debug.Log("No puedes plantar: huerto lleno.");
                }
            }
            else
            {
                Debug.Log("No tienes semillas de zanahoria");
            }
        }
       
            
        CerrarUI();
    }

    private void ComprarH()
    {
        HuertoG = Instantiate(HuertoPrerfab, HuecoHuerto.position, HuecoHuerto.rotation);
        HuertoG.transform.SetParent(HuecoHuerto);
    }

    private void CerrarUI()
    {
        Time.timeScale = 1;
        canvas.enabled = false;
    }

    public void AbrirUI()
    {
        Time.timeScale = 0;
        canvas.enabled = true;

    }

    private void cosechar()
    {
        var manager = Object.FindFirstObjectByType<HuertoManager>();
        List<Planta.Tipo> tipos = manager.CosecharTodas();
        var inventarioScript = jugador.GetComponent<guardar_Inventario>();
        foreach (var tipo in tipos)
        {
            // Asumiendo que cada tipo da 1 semilla
            switch (tipo)
            {
                case Planta.Tipo.Zanahoria:
                    inventarioScript.AgregarItem("Semilla_Zanahoria", null);
                    break;
                case Planta.Tipo.Patata:
                    inventarioScript.AgregarItem("Semilla_Patata", null);
                    break;
            }
        }
    }
}
