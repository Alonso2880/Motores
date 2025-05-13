using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuzónUI : MonoBehaviour
{
    public Button Vercarta1, Vercarta2, Vercarta3;
    public Button salir;
    public Canvas can;
    public GameObject panel, panel2, panel3;
    private Image i, i2, i3;
    private GameObject Casa;
    private bool c1 = false, c2= false, c3= false;
    void Start()
    {
        Vercarta1.onClick.AddListener(() => Elegir(1));
        salir.onClick.AddListener(() => Elegir(2));
        Vercarta2.onClick.AddListener(() => Elegir(3));
        Vercarta3.onClick.AddListener(()=>Elegir(4));

        can = this.gameObject.GetComponent<Canvas>();
        can.enabled = false;

        Casa = GameObject.Find("CasaBrujita");

        panel.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);

    }

    private void Update()
    {
        casa c = Casa.GetComponent<casa>();
       if(c.dia >= 3)
        {
            Vercarta1.gameObject.SetActive(true);
        }

       if(c.dia >= 6)
        {
            Vercarta2.gameObject.SetActive(true);
        }

        if (c.dia >= 9)
        {
            Vercarta3.gameObject.SetActive(true);
        }

    }
    public void Elegir(int i)
    {
        panel.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);

        switch (i)
        {
            case 1:
                panel.SetActive(true);
                break;
            case 2:
                cerrar();
                break;
            case 3:
                panel2.SetActive(true);
                break;
            case 4:
                panel3.SetActive(true);
                break;
        }
    }

    public void abrir()
    {
        can.enabled = true;
        Time.timeScale = 0;
        Vercarta1.gameObject.SetActive(false);
        Vercarta2.gameObject.SetActive(false);
        Vercarta3.gameObject.SetActive(false);
    }

    public void cerrar()
    {
        can.enabled = false;
        Time.timeScale = 1;
    }
}
