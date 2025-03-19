using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Vender : MonoBehaviour
{
    private GameObject menu_vender;
    private Canvas canvasV;
    public Button salir;
    public Button v_huevos;
    private GameObject tienda;
    [HideInInspector] public GameObject coli;
    void Start()
    {
        v_huevos.onClick.AddListener(() => MenuVender(1));
        salir.onClick.AddListener(()=> MenuVender(2));

        tienda = GameObject.Find("Tienda_Vender");

        menu_vender = this.gameObject;
        canvasV = this.GetComponent<Canvas>();
        canvasV.enabled = false;
    }

    private void MenuVender(int n)
    {
        Tienda t = tienda.GetComponent<Tienda>();
        switch (n)
        {
            case 1:
                t.Huevo();
                CerrarMenu();
                break;

            case 2:
                CerrarMenu();
                break;
        }
    }

    public void AbrirMenu()
    {
        canvasV.enabled = true;
        Time.timeScale = 0;
    }
    private void CerrarMenu()
    {
        canvasV.enabled = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        
    }
}
