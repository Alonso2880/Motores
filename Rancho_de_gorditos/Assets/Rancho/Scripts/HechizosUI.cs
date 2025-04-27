using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections.Generic;
public class Hechizos : MonoBehaviour
{
    public Canvas canvas;
    public Button Arriba, Abajo, Centro, Derecha, Izquierda;
    private GameObject player;

    private StringBuilder combinacion;
    private const string secuenciaSemilla1 = "12345";
    public bool semilla = false;

    
    void Start()
    {
        canvas.enabled = false;
        Arriba.onClick.AddListener(() => hechi(0));
        Abajo.onClick.AddListener(()=>hechi(1));
        Centro.onClick.AddListener(()=>hechi(2));
        Derecha.onClick.AddListener(()=>hechi(3));
        Izquierda.onClick.AddListener(()=>hechi(4));
        combinacion = new StringBuilder();

        player = GameObject.Find("Player");
    }

    private void hechi(int i)
    {
        switch (i)
        {
            case 0:
                combinacion.Append('1');
                break;
            case 1:
                combinacion.Append('3');
                break;
            case 2:
                combinacion.Append('2');
                break;
            case 3:
                combinacion.Append('5');
                break;
            case 4:
                combinacion.Append('4');
                break;
        }
    }
    
    void Update()
    {
        Hechizo h = player.GetComponent<Hechizo>();
        if (combinacion.Length == secuenciaSemilla1.Length)
        {
            string comb = combinacion.ToString();
            if (comb.Contains(secuenciaSemilla1))
            {
                
                semilla = true;
                combinacion.Clear();
                canvas.enabled = false;
                //h.enZona = false;
            }
            else
            {
                
                combinacion.Clear();
               // canvas.enabled = false;
            }
        }
    }
}
