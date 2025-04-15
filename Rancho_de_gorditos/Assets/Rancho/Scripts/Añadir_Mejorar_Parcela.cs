using UnityEngine;

public class Añadir_Mejorar_Parcela : MonoBehaviour
{
    public GameObject parcela, terreno, parcelaGrande;
    private GameObject MenuParcela;
    public Transform punto;
    [HideInInspector] public GameObject parcelaPrefab;
    [HideInInspector] public bool hayParcela;
    void Start()
    {
        MenuParcela = GameObject.Find("MenuParcelas");
    }

    public void GenerarParcela()
    {
        parcelaPrefab = Instantiate(parcela, punto.position, punto.rotation);
        parcelaPrefab.transform.SetParent(punto);
        hayParcela = true;
    }

    public void AmpliarParcela()
    {
        Destroy(parcelaPrefab);
        terreno.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        parcelaPrefab = Instantiate(parcelaGrande, punto.position, punto.rotation);
        parcelaPrefab.transform.SetParent(punto);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Menu_Parcelas m = MenuParcela.GetComponent<Menu_Parcelas>();
        if (collision.gameObject.CompareTag("Player"))
        {
            m.AbrirMenu();
        }
    }

}
