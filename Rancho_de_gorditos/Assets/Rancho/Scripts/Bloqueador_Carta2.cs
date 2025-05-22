using UnityEngine;

public class Bloqueador_Carta2 : MonoBehaviour
{
    private GameObject Buzon;
    void Start()
    {
        Buzon = GameObject.Find("MenuBuzón");
    }


    void Update()
    {
        BuzónUI b = Buzon.GetComponent<BuzónUI>();
        if (b.E2)
        {
            this.gameObject.SetActive(true);
        }

        if (!b.E2)
        {
            this.gameObject.SetActive(false);
        }
    }
}
