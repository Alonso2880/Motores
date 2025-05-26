using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Menu_Vender : MonoBehaviour
{
    private GameObject menu_vender;
    private Canvas canvasV;
    public Button salir;
    public Button v_huevos;
    private GameObject tienda;
    [HideInInspector] public GameObject coli;
    public TMP_InputField inputCantidad;
    void Start()
    {
        v_huevos.onClick.AddListener(OnClickVender);
        salir.onClick.AddListener(CerrarMenu);

        tienda = GameObject.Find("TiendaVender");

        menu_vender = this.gameObject;
        canvasV = this.GetComponent<Canvas>();
        canvasV.enabled = false;
        inputCantidad.enabled = false;  
    }

    public void OnClickVender()
    {
        int cantidad;
        if(!int.TryParse(inputCantidad.text, out cantidad)|| cantidad <= 0)
        {
            Debug.LogWarning("Introduce un número válido de huevos");
            return;
        }

        Tienda t = tienda.GetComponent<Tienda>();
        t.Huevo(cantidad);

        CerrarMenu();
    }

    public void AbrirMenu()
    {
        canvasV.enabled = true;
        Time.timeScale = 0; 
        inputCantidad.enabled = true;
    }
    private void CerrarMenu()
    {
        canvasV.enabled = false;
        Time.timeScale = 1;
        inputCantidad.enabled = false;
    }

    void Update()
    {
        
    }
}
