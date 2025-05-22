using UnityEngine;

public class Bloqueador_Carta1 : MonoBehaviour
{
    private GameObject Buzon;
    void Start()
    {
        Buzon = GameObject.Find("MenuBuzón");
    }

    
    void Update()
    {
        BuzónUI b = Buzon.GetComponent<BuzónUI>();
        if (b.E1)
        {
            this.gameObject.SetActive(true);
        }

        if (!b.E1)
        {
            this.gameObject.SetActive(false);
        }
    }
}
