using UnityEngine;

public class huerto : MonoBehaviour
{
    public GameObject semilla, planta1, planta2;
    private GameObject huertoUI;
    [HideInInspector] public GameObject semilla1Prefab, semilla2Prefab;
    public Transform huecoPlantar, huecoPlantar2;
    private bool hueco1=false, hueco2=false;
    
    void Start()
    {
        huertoUI = GameObject.Find("PlantarSemilla");
    }

    
    void Update()
    {
        
    }

    public void Semilla()
    {
        if (hueco1 == false)
        {
            semilla1Prefab = Instantiate(semilla, huecoPlantar.position, huecoPlantar.rotation);
            semilla1Prefab.transform.SetParent(huecoPlantar);
            hueco1 = true;
        }else 
        if (hueco1 && !hueco2)
        {
            semilla2Prefab = Instantiate(semilla, huecoPlantar2.position, huecoPlantar2.rotation);
            semilla2Prefab.transform.SetParent(huecoPlantar2);
            hueco2 = true;
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
