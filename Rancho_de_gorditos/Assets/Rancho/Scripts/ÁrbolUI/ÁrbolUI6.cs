using UnityEngine;
using UnityEngine.UI;
public class ÁrbolUI6 : MonoBehaviour
{
    public Button Comprar, Manzano, Naranjo, Mejorar, Salir, Cosechar;
    public Canvas c;
    public GameObject Manager, contMonedas;
    private GameObject player;
    [HideInInspector] public bool manzano = false, naranjo = false, huerto = false;
    void Start()
    {
        c.enabled = false;
        Salir.onClick.AddListener(() => ads());
        Comprar.onClick.AddListener(() => ComprarHueco());
        Manzano.onClick.AddListener(() => Plantar(1));
        Naranjo.onClick.AddListener(() => Plantar(2));
        Mejorar.onClick.AddListener(() => Mejoras());
        Cosechar.onClick.AddListener(() => CosechaR());
        player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {

    }

    public void hola()
    {
        c.enabled = true;
        Time.timeScale = 0;
    }
    private void ads()
    {
        c.enabled = false;
        Time.timeScale = 1;
    }

    private void ComprarHueco()
    {
        Contador_Moneas cont = contMonedas.GetComponent<Contador_Moneas>();
        ÁrbolManager6 a = Manager.GetComponent<ÁrbolManager6>();
        if (!huerto)
        {
            if (cont.monedas >= 5)
            {
                a.compraHuerto();
                huerto = true;
                cont.monedas -= 5;
                ads();
            }
        }
    }

    private void Plantar(int hue)
    {
        ÁrbolManager6 a = Manager.GetComponent<ÁrbolManager6>();
        guardar_Inventario g = player.GetComponent<guardar_Inventario>();
        switch (hue)
        {
            case 1:
                if (!a.plantado)
                {
                    var manzanaItem = g.inventario.Find(i => i.nombre == "Manzana");
                    if (manzanaItem != null && manzanaItem.count >= 1)
                    {
                        a.Plantar();
                        manzano = true;
                        manzanaItem.count -= 1;
                        ads();
                    }
                    else
                    {
                        Debug.Log("No tienes manzanas para plantar");
                    }

                }
                else
                {
                    Debug.Log("Ya esta plantado");
                }

                break;
            case 2:

                if (!a.plantado)
                {
                    var naranjaItem = g.inventario.Find(i => i.nombre == "Naranja");
                    if (naranjaItem != null && naranjaItem.count >= 1)
                    {
                        a.Plantar();
                        naranjo = true;
                        naranjaItem.count -= 1;
                        ads();
                    }
                    else
                    {
                        Debug.Log("No tienes naranjas para plantar");
                    }

                }
                else
                {
                    Debug.Log("Ya esta plantado");
                }

                break;
        }
    }

    private void CosechaR()
    {
        ÁrbolManager6 a = Manager.GetComponent<ÁrbolManager6>();
        guardar_Inventario g = player.GetComponent<guardar_Inventario>();
        if (a.fase == 2)
        {
            if (manzano)
            {
                g.AgregarItem("Manzana", null);
                g.AgregarItem("Manzana", null);
                g.AgregarItem("Manzana", null);
                a.fase = 0;
                a.plantado = false;
                Destroy(a.semi);
                manzano = false;
                huerto = false;
            }

            if (naranjo)
            {
                g.AgregarItem("Naranja", null);
                g.AgregarItem("Naranja", null);
                g.AgregarItem("Naranja", null);
                a.fase = 0;
                a.plantado = false;
                Destroy(a.semi);
                naranjo = false;
                huerto = false;
            }
        }
    }
    private void Mejoras()
    {

    }
    void Update()
    {

    }
}

