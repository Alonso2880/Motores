using UnityEngine;

public class Bloqueador_Carta2 : MonoBehaviour
{
    private GameObject Buzon;
    void Start()
    {
        Buzon = GameObject.Find("MenuBuz�n");
    }


    void Update()
    {
        Buz�nUI b = Buzon.GetComponent<Buz�nUI>();
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
