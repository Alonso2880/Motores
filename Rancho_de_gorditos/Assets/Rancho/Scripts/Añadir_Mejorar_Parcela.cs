using UnityEngine;

public class Añadir_Mejorar_Parcela : MonoBehaviour
{
    public GameObject parcela, terreno;
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

    private void OnCollisionEnter(Collision collision)
    {
        Menu_Parcelas m = MenuParcela.GetComponent<Menu_Parcelas>();
        if (collision.gameObject.CompareTag("Player"))
        {
            m.AbrirMenu();
        }
    }

    void Update()
    {
        
    }
}
