using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Parcelas : MonoBehaviour
{
    private GameObject baseParcelas, terreno, gallina;
    private Canvas canvasP;
    public Button Comprar_Gallinas;
    public Button Comprar_Vacas;
    public Button Comprar_Cerdos;
    public Button Comprar_Ovejas;
    public Button Mejorar;
    public Button Ampliar;
    public Button Salir;
    [HideInInspector] public bool comprado=false;
    void Start()
    {
        Comprar_Gallinas.onClick.AddListener(() => ComprarP(1));
        Comprar_Vacas.onClick.AddListener(() => ComprarP(2));
        Comprar_Cerdos.onClick.AddListener(() => ComprarP(3));
        Comprar_Ovejas.onClick.AddListener(() => ComprarP(4));
        Mejorar.onClick.AddListener(() => Mejoras(1));
        Ampliar.onClick.AddListener(()=> Mejoras(2));
        Salir.onClick.AddListener(() => ComprarP(5));
        Salir.onClick.AddListener(() => Mejoras(3));

        canvasP = GetComponent<Canvas>();
        canvasP.enabled = false;

        baseParcelas = GameObject.Find("Base de parcelas");
        terreno = GameObject.Find("Terreno");
        gallina = GameObject.Find("Gallina");

        



    }

    public void ComprarP(int n)
    {
        Añadir_Mejorar_Parcela a = baseParcelas.GetComponent<Añadir_Mejorar_Parcela>();
        if (comprado == false)
        {
            switch (n)
            {
                case 1:
                    a.GenerarParcela();
                    terreno.tag = "T_Gallinas";
                    CerrarMenu();
                    comprado = true;
                    break;

                case 2:
                    a.GenerarParcela();
                    terreno.tag = "T_Vacas";
                    CerrarMenu();
                    comprado = true;
                    break;

                case 3:
                    a.GenerarParcela();
                    terreno.tag = "T_Cerdos";
                    CerrarMenu();
                    comprado = true;
                    break;

                case 4:
                    a.GenerarParcela();
                    terreno.tag = "T_Ovejas";
                    CerrarMenu();
                    comprado = true;
                    break;
                case 5:
                    CerrarMenu();
                    break;
            }
        }
      
    }

    public void Mejoras(int n)
    {
        Añadir_Mejorar_Parcela a = baseParcelas.GetComponent<Añadir_Mejorar_Parcela>();
        Gallina g = gallina.GetComponent<Gallina>();
        if (comprado)
        {
            switch (n)
            {
                case 1:
                    if(terreno.tag == "T_Gallinas")
                    {
                        Gallina.multHuevo = 2;
                    }
                    CerrarMenu();
                    break;
                case 2:
                    a.AmpliarParcela();
                    CerrarMenu();
                    break;
                case 3:
                    CerrarMenu();
                    break;
            }
        }

    }

    public void AbrirMenu()
    {
        canvasP.enabled = true;
        Time.timeScale = 0;
        if(comprado == false)
        {
            Comprar_Gallinas.gameObject.SetActive(true);
            Comprar_Vacas.gameObject.SetActive(true);
            Comprar_Cerdos.gameObject.SetActive(true);
            Comprar_Ovejas.gameObject.SetActive(true);
            Mejorar.gameObject.SetActive(false);
            Ampliar.gameObject.SetActive(false);

        }
        else
        {
            Comprar_Gallinas.gameObject.SetActive(false);
            Comprar_Vacas.gameObject.SetActive(false);
            Comprar_Cerdos.gameObject.SetActive(false);
            Comprar_Ovejas.gameObject.SetActive(false);
            Mejorar.gameObject.SetActive(true);
            Ampliar.gameObject.SetActive(true);

        }
    }

    public void CerrarMenu()
    {
        canvasP.enabled = false;
        Time.timeScale = 1;
    }
    
}
