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
    private const string secuenciaTomate = "12345";
    private const string secuenciaZanahoria = "54321";
    private const string secuenciaManzana = "12534";
    private const string secuenciaPatatas = "43521";
    private const string secuenciaPimientos = "32145";
    private const string secuenciaNaranjas = "54123";
    public bool tomate = false, zanahoria = false, manzana = false, patatas = false, pimientos = false, naranjas = false;

    
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
        if (combinacion.Length == secuenciaTomate.Length)
        {
            string comb = combinacion.ToString();
            if (comb.Contains(secuenciaTomate) && h.col.name == "BroteTomate")
            {
                
                tomate = true;
                combinacion.Clear();
                canvas.enabled = false;
            }
            else
            {
                
                combinacion.Clear();
            }
        }

        if (combinacion.Length == secuenciaZanahoria.Length)
        {
            string comb = combinacion.ToString();
            if (comb.Contains(secuenciaZanahoria))
            {

                zanahoria = true;
                combinacion.Clear();
                canvas.enabled = false;
            }
            else
            {

                combinacion.Clear();
            }
        }

        if (combinacion.Length == secuenciaManzana.Length)
        {
            string comb = combinacion.ToString();
            if (comb.Contains(secuenciaManzana))
            {

                manzana = true;
                combinacion.Clear();
                canvas.enabled = false;
            }
            else
            {

                combinacion.Clear();
            }
        }

        if (combinacion.Length == secuenciaPatatas.Length)
        {
            string comb = combinacion.ToString();
            if (comb.Contains(secuenciaPatatas))
            {

                patatas = true;
                combinacion.Clear();
                canvas.enabled = false;
            }
            else
            {

                combinacion.Clear();
            }
        }

        if (combinacion.Length == secuenciaPimientos.Length)
        {
            string comb = combinacion.ToString();
            if (comb.Contains(secuenciaPimientos))
            {

                pimientos = true;
                combinacion.Clear();
                canvas.enabled = false;
            }
            else
            {

                combinacion.Clear();
            }
        }

        if (combinacion.Length == secuenciaNaranjas.Length)
        {
            string comb = combinacion.ToString();
            if (comb.Contains(secuenciaNaranjas))
            {

                naranjas = true;
                combinacion.Clear();
                canvas.enabled = false;
            }
            else
            {

                combinacion.Clear();
            }
        }

    }
}
