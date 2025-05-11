using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Parcelas : MonoBehaviour
{
    private GameObject baseParcelas, gallina;
    public GameObject terreno;
    private Canvas canvasP;
<<<<<<< Updated upstream
    public Button Comprar_Gallinas;
    public Button Comprar_Vacas;
    public Button Comprar_Cerdos;
    public Button Comprar_Ovejas;
=======
    public Button ComprarG;
    public Button ComprarV;
    public Button ComprarC;
    public Button ComprarCa;
>>>>>>> Stashed changes
    public Button Mejorar;
    public Button Ampliar;
    public Button Salir;
    [HideInInspector] public bool comprado=false;
    [HideInInspector] public GameObject contmonedas;
    void Start()
    {
<<<<<<< Updated upstream
        Comprar_Gallinas.onClick.AddListener(() => ComprarP(1));
        Comprar_Vacas.onClick.AddListener(() => ComprarP(2));
        Comprar_Cerdos.onClick.AddListener(() => ComprarP(3));
        Comprar_Ovejas.onClick.AddListener(() => ComprarP(4));
=======
        ComprarG.onClick.AddListener(() => ComprarP(1));
>>>>>>> Stashed changes
        Mejorar.onClick.AddListener(() => Mejoras(1));
        Ampliar.onClick.AddListener(()=> Mejoras(2));
        Salir.onClick.AddListener(() => ComprarP(5));
        Salir.onClick.AddListener(() => Mejoras(3));
        ComprarV.onClick.AddListener(() =>ComprarP(3));
        ComprarC.onClick.AddListener(() => ComprarP(4));
        ComprarCa.onClick.AddListener(() => ComprarP(5));

        canvasP = GetComponent<Canvas>();
        canvasP.enabled = false;

        baseParcelas = GameObject.Find("Base de parcelas");
        gallina = GameObject.Find("Gallina");
        contmonedas = GameObject.Find("Canvas");





    }

    public void ComprarP(int n)
    {
        Añadir_Mejorar_Parcela a = baseParcelas.GetComponent<Añadir_Mejorar_Parcela>();
        if (comprado == false)
        {
            switch (n)
            {
                case 1:
<<<<<<< Updated upstream
                    a.GenerarParcela();
                    terreno.tag = "T_Gallinas";
=======
                    a.GenerarParcelaG();
>>>>>>> Stashed changes
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
                case 3:
                    a.GenerarParcelaV();
                    CerrarMenu();
                    comprado = true;
                    break;
                case 4:
                    a.GenerarParcelaC();
                    CerrarMenu();
                    comprado = true;
                    break;
                case 5:
                    a.GenerarParcelaCa();
                    CerrarMenu();
                    comprado = true;
                    break;
            }
        }
      
    }

    public void Mejoras(int n)
    {
        Añadir_Mejorar_Parcela a = baseParcelas.GetComponent<Añadir_Mejorar_Parcela>();
        Gallina g = gallina.GetComponent<Gallina>();
        Contador_Moneas cont = contmonedas.GetComponent<Contador_Moneas>();
        if (comprado)
        {
            switch (n)
            {
                case 1:
                    if(cont.monedas < 4)
                    {
                        Debug.Log("Te faltan monedas");
                    }
                    else
                    {
                        if (terreno.tag == "T_Gallinas")
                        {
                            Gallina.multHuevo = 2;
                        }
                        
                        cont.monedas -= 4;
                    }
                    
                    CerrarMenu();
                    break;
                case 2:
                    if(cont.monedas < 6)
                    {
                        Debug.Log("Te faltan monedas");
                    }
                    else
                    {
                        a.AmpliarParcela();
                        cont.monedas -= 6;
                    }
                    
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
<<<<<<< Updated upstream
            Comprar_Gallinas.gameObject.SetActive(true);
            Comprar_Vacas.gameObject.SetActive(true);
            Comprar_Cerdos.gameObject.SetActive(true);
            Comprar_Ovejas.gameObject.SetActive(true);
=======
            ComprarG.gameObject.SetActive(true);
            ComprarV.gameObject.SetActive(true);
            ComprarC.gameObject.SetActive(true);
            ComprarCa.gameObject.SetActive(true);
>>>>>>> Stashed changes
            Mejorar.gameObject.SetActive(false);
            Ampliar.gameObject.SetActive(false);

        }
        else
        {
<<<<<<< Updated upstream
            Comprar_Gallinas.gameObject.SetActive(false);
            Comprar_Vacas.gameObject.SetActive(false);
            Comprar_Cerdos.gameObject.SetActive(false);
            Comprar_Ovejas.gameObject.SetActive(false);
=======
            ComprarG.gameObject.SetActive(false);
            ComprarV.gameObject.SetActive(false);
            ComprarC.gameObject.SetActive(false);
            ComprarCa.gameObject.SetActive(false);
>>>>>>> Stashed changes
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
