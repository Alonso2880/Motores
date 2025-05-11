using UnityEngine;

public class Añadir_Mejorar_Parcela : MonoBehaviour
{
    public GameObject parcela, terreno, parcelaGrande, recogidaH, gallinero;
    private GameObject MenuParcela;
<<<<<<< Updated upstream
    public Transform punto, punto_grande, puntoRecogida, puntoGallinero, puntoGalli2;
    [HideInInspector] public GameObject parcelaPrefab, recogidaPrefab, gallineroPrefab;
    [HideInInspector] public bool hayParcela;
=======
    private float dist = 1f;
    public Transform punto;
    [HideInInspector] public GameObject parcelaPrefab;
    [HideInInspector] public bool hayParcela, P_Gallinas=false, P_Vacas = false, P_Cerdos = false, P_Ovejas = false;
>>>>>>> Stashed changes
    void Start()
    {
        MenuParcela = GameObject.Find("MenuParcelas");
    }

    public void GenerarParcelaG()
    {
        parcelaPrefab = Instantiate(parcela, punto.position, punto.rotation);
        parcelaPrefab.transform.SetParent(punto);
<<<<<<< Updated upstream
        parcelaPrefab.transform.localScale = Vector3.one * 0.9f;
        recogidaPrefab =Instantiate(recogidaH, puntoRecogida.position, puntoRecogida.rotation);
        recogidaPrefab.transform.SetParent(puntoRecogida);
        gallineroPrefab = Instantiate(gallinero, puntoGallinero.position, puntoGallinero.rotation);
        gallineroPrefab.transform.SetParent(puntoGallinero);
=======
        terreno.tag = "Terreno_Gallinas";
>>>>>>> Stashed changes
        hayParcela = true;
        P_Gallinas = true;
    }

    public void GenerarParcelaV()
    {
        parcelaPrefab = Instantiate(parcela, punto.position, punto.rotation);
        parcelaPrefab.transform.SetParent(punto);
        terreno.tag = "Terreno_Vacas";
        hayParcela = true;
        P_Vacas=true;
    }

    public void GenerarParcelaC()
    {
        parcelaPrefab = Instantiate(parcela, punto.position, punto.rotation);
        parcelaPrefab.transform.SetParent(punto);
        terreno.tag = "Terreno_Cerdos";
        hayParcela = true;
        P_Cerdos=true;
    }

    public void GenerarParcelaCa()
    {
        parcelaPrefab = Instantiate(parcela, punto.position, punto.rotation);
        parcelaPrefab.transform.SetParent(punto);
        terreno.tag = "Terreno_Ovejas";
        hayParcela = true;
        P_Ovejas=true;
    }

    public void AmpliarParcela()
    {
        Destroy(parcelaPrefab);
        terreno.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        parcelaPrefab = Instantiate(parcelaGrande, punto_grande.position, punto_grande.rotation);
        parcelaPrefab.transform.localScale = Vector3.one * 0.9f;
        parcelaPrefab.transform.SetParent(punto_grande);

        Destroy(gallineroPrefab);
        gallineroPrefab = Instantiate(gallinero, puntoGalli2.position, puntoGalli2.rotation);
        gallineroPrefab.transform.SetParent(puntoGalli2);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Menu_Parcelas m = MenuParcela.GetComponent<Menu_Parcelas>();
        if (collision.gameObject.CompareTag("Player"))
        {
            m.AbrirMenu();
        }
    }

<<<<<<< Updated upstream
=======
    public void MejoraParcela()
    {
        if (P_Gallinas)
        {
            GameObject[] gallinas = GameObject.FindGameObjectsWithTag("Gallina");
        }
    }



    void Update()
    {
        
    }
>>>>>>> Stashed changes
}
