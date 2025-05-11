using UnityEngine;

public class Añadir_Mejorar_Parcela2 : MonoBehaviour
{
    public GameObject parcela, terreno, parcelaGrande, recogidaH, gallinero, recogidaL, recogidaC, recogidaLe;
    private GameObject MenuParcela;
    public Transform punto, punto_grande, puntoRecogida, puntoGallinero, puntoGalli2;
    [HideInInspector] public GameObject parcelaPrefab, recogidaPrefab, gallineroPrefab;
    [HideInInspector] public bool hayParcela;
    void Start()
    {
        MenuParcela = GameObject.Find("MenuParcelas2");
    }

    public void GenerarParcela()
    {
        parcelaPrefab = Instantiate(parcela, punto.position, punto.rotation);
        parcelaPrefab.transform.SetParent(punto);
        parcelaPrefab.transform.localScale = Vector3.one * 0.9f;
        recogidaPrefab =Instantiate(recogidaH, puntoRecogida.position, puntoRecogida.rotation);
        recogidaPrefab.transform.SetParent(puntoRecogida);
        gallineroPrefab = Instantiate(gallinero, puntoGallinero.position, puntoGallinero.rotation);
        gallineroPrefab.transform.SetParent(puntoGallinero);
        hayParcela = true;
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
        Menu_Parcelas2 m = MenuParcela.GetComponent<Menu_Parcelas2>();
        if (collision.gameObject.CompareTag("Player"))
        {
            m.AbrirMenu();
        }
    }

}
