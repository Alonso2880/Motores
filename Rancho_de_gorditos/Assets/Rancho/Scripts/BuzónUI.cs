using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuzónUI : MonoBehaviour
{
    public Button Vercarta;
    public Button salir;
    public Canvas can;
    public GameObject panel;
    private Image i;
    void Start()
    {
        Vercarta.onClick.AddListener(() => Elegir(1));
        salir.onClick.AddListener(() => Elegir(2));
        can = this.gameObject.GetComponent<Canvas>();
        can.enabled = false;
        i = panel.GetComponent<Image>();
        i.enabled = false;
    }

    public void Elegir(int i)
    {

        switch (i)
        {
            case 1:

                carta1();
                break;
            case 2:
                cerrar();
                break; 
        }
    }

   private void carta1()
    {
        i.enabled = true;
    }

    public void abrir()
    {
        can.enabled = true;
        Time.timeScale = 0;
    }
    
    public void cerrar()
    {
        can.enabled = false;
        Time.timeScale = 1;
    }
    void Update()
    {
        
    }
}
