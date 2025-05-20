using UnityEngine;
using UnityEngine.UI;

public class MenuPausaUI : MonoBehaviour
{
    public Canvas c;
    public Button pausa, salir, ajustes;
    private GameObject ManuInicio, AjustesU;
    void Start()
    {
        pausa.onClick.AddListener(() => opciones(1));
        salir.onClick.AddListener(()=> opciones (2));
        ajustes.onClick.AddListener(()=> opciones(3));
        c.enabled = false;

        ManuInicio = GameObject.Find("MenuInicio");
        AjustesU = GameObject.Find("Ajustes");
    }

    private void opciones (int n)
    {
        MenuInicio m = ManuInicio.GetComponent<MenuInicio>();
        AjustesUI u = AjustesU.GetComponent<AjustesUI>();
        switch (n)
        {
            case 1:
                c.enabled = false;
                Time.timeScale = 1;
                break;

            case 2:
                c.enabled = false;
                m.Menu.enabled = true;
                break;
            case 3:
                c.enabled = false;
                u.inicio();
                break;
        }
    }
   
    void Update()
    {
        
    }
}
