using UnityEngine;
using UnityEngine.UI;

public class MenuPausaUI : MonoBehaviour
{
    public Canvas c;
    public Button pausa, salir;
    private GameObject ManuInicio;
    void Start()
    {
        pausa.onClick.AddListener(() => opciones(1));
        salir.onClick.AddListener(()=> opciones (2));
        c.enabled = false;

        ManuInicio = GameObject.Find("MenuInicio");
    }

    private void opciones (int n)
    {
        MenuInicio m = ManuInicio.GetComponent<MenuInicio>();
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
        }
    }
   
    void Update()
    {
        
    }
}
