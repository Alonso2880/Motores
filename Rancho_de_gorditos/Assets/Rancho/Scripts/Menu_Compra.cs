using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Compra : MonoBehaviour
{
    private GameObject menu_compra;
    private Canvas canvasM;
    public Button salir;
    public Button c_gallinas;
    public Button c_ovejas;
    public Button c_vacas;
    public Button c_cerdos;
    private GameObject tienda;
    [HideInInspector] public GameObject coli;
    void Start()
    {
        c_gallinas.onClick.AddListener(() => ComprarOpciones(1));
        c_ovejas.onClick.AddListener(() => ComprarOpciones(2));
        c_vacas.onClick.AddListener(() => ComprarOpciones(3));
        c_cerdos.onClick.AddListener(() => ComprarOpciones(4));
        salir.onClick.AddListener(() => ComprarOpciones(5));

        menu_compra = this.gameObject;
        canvasM = this.GetComponent<Canvas>();
        canvasM.enabled = false;

        tienda = GameObject.Find("Tienda_Comprar");
    }

    private void ComprarOpciones(int num)
    {
        Tienda_Comprar t = tienda.GetComponent<Tienda_Comprar>();
        switch (num)
        {
            case 1:
                t.Gallina();
                CerrarMenu();
                break;
            case 2:
                t.Oveja();
                CerrarMenu();
                break;
            case 3:
                t.Vaca();
                CerrarMenu();
                break;
            case 4:
                t.Cerdo();
                CerrarMenu();
                break;

            case 5:
                CerrarMenu();
                break;
        }
    }



    public void AbrirMenu()
    {
        canvasM.enabled = true;
        Time.timeScale = 0;
    }
    private void CerrarMenu()
    {
        canvasM.enabled = false;
        Time.timeScale = 1;
    }

}
