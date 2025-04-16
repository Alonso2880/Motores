using UnityEngine;

public class huerto : MonoBehaviour
{
    public GameObject semilla, planta1, planta2;
    private GameObject huertoUI, jugador, Casa;
    [HideInInspector] public GameObject semilla1Prefab, semilla2Prefab;
    public Transform huecoPlantar, huecoPlantar2;
    private bool hueco1=false, hueco2=false;
    [HideInInspector] public int crec = 1, dia;

    //private guardar_Inventario inventario;
    
    
    void Start()
    {
        huertoUI = GameObject.Find("PlantarSemilla");
        jugador = GameObject.FindGameObjectWithTag("Player");
        Casa = GameObject.Find("CasaBrujita");
        casa c = Casa.GetComponent<casa>();
        dia = c.dia;

    }

    
    void Update()
    {
        crecimiento();
    }

    public void Semilla()
    {
        guardar_Inventario i = jugador.GetComponent<guardar_Inventario>();
        InventoryItemData item = i.inventario.Find(item => item.nombre == "semilla");

        if (hueco1 == false)
        {
            if(item == null|| item.count <= 0)
            {
                Debug.Log("No hay semillas");
            }
            else
            {
                semilla1Prefab = Instantiate(semilla, huecoPlantar.position, huecoPlantar.rotation);
                semilla1Prefab.transform.SetParent(huecoPlantar);
                hueco1 = true;
                item.count--;
            }
            
        }else 
        if (hueco1 && !hueco2)
        {
            if (item == null || item.count <= 0)
            {
                Debug.Log("No hay semillas");
            }
            else
            {
                semilla2Prefab = Instantiate(semilla, huecoPlantar2.position, huecoPlantar2.rotation);
                semilla2Prefab.transform.SetParent(huecoPlantar2);
                hueco2 = true;
                item.count--;
            }
            
        }
        
    }

    private void crecimiento()
    {
        casa c = Casa.GetComponent<casa>();
        if (hueco1 = true && crec ==1)
        {
            if(dia != c.dia)
            {
                Destroy(semilla1Prefab);
                semilla1Prefab = Instantiate(planta1, huecoPlantar.position, huecoPlantar.rotation);
                semilla1Prefab.transform.SetParent(huecoPlantar);
                dia = c.dia;
                crec++;
            }
        }

        if(hueco1 =true && crec == 2)
        {
            if (dia != c.dia)
            {
                Destroy(semilla1Prefab);
                semilla1Prefab = Instantiate(planta2, huecoPlantar.position, huecoPlantar.rotation);
                semilla1Prefab.transform.SetParent(huecoPlantar);
                dia = c.dia;
                crec++;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        HuertoUI h = huertoUI.GetComponent<HuertoUI>();
        if (collision.gameObject.CompareTag("Player"))
        {
            h.inicio();
        }
    }
}
