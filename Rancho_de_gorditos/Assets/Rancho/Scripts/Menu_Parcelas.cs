using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Parcelas : MonoBehaviour
{
    private GameObject baseParcelas;
    private Canvas canvasP;
    public Button Comprar;
    public Button Mejorar;
    public Button Ampliar;
    public Button Salir;
    [HideInInspector] public bool comprado=false;
    void Start()
    {
        Comprar.onClick.AddListener(() => ComprarP(1));
        Mejorar.onClick.AddListener(() => Mejoras(1));
        Ampliar.onClick.AddListener(()=> Mejoras(2));
        Salir.onClick.AddListener(() => ComprarP(2));
        Salir.onClick.AddListener(() => Mejoras(3));

        canvasP = GetComponent<Canvas>();
        canvasP.enabled = false;

        baseParcelas = GameObject.Find("Base de parcelas");



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
                    CerrarMenu();
                    comprado = true;
                    break;
                case 2:
                    CerrarMenu();
                    break;
            }
        }
      
    }

    public void Mejoras(int n)
    {
        Añadir_Mejorar_Parcela a = baseParcelas.GetComponent<Añadir_Mejorar_Parcela>();
        if (comprado)
        {
            switch (n)
            {
                case 1:

                    break;
                case 2:

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
            Comprar.gameObject.SetActive(true);
            Mejorar.gameObject.SetActive(false);
            Ampliar.gameObject.SetActive(false);

        }
        else
        {
            Comprar.gameObject.SetActive(false);
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
