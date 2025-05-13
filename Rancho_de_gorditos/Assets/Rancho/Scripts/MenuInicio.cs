using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuInicio : MonoBehaviour
{
    public Canvas Menu;
    public Button Jugar, Salir;
    public bool menuIncio = false;
    private void Awake()
    {
        Menu.enabled = true;
        Time.timeScale = 0;
        Jugar.onClick.AddListener(() => Opciones(1));
        Salir.onClick.AddListener(()=>  Opciones(2));
        menuIncio = true;
    }

    private void Opciones(int n)
    {
        switch (n)
        {
            case 1:
                Menu.enabled = false;
                Time.timeScale = 1;
                menuIncio = false;
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
