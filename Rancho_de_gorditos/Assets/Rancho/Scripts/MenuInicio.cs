using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuInicio : MonoBehaviour
{
    public Canvas Menu;
    public Button Jugar, Salir;
    private void Awake()
    {
        Menu.enabled = true;
        Time.timeScale = 0;
        Jugar.onClick.AddListener(() => Opciones(1));
        Salir.onClick.AddListener(()=>  Opciones(2));
    }

    private void Opciones(int n)
    {
        switch (n)
        {
            case 1:
                Menu.enabled = false;
                Time.timeScale = 1;
                break;
            case 2:
                Application.Quit();
                break;
        }
    }
    
    void Update()
    {
        
    }
}
