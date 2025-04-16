using UnityEngine;

public class casa : MonoBehaviour
{
    private GameObject player, huerto;
    public int dia=0;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        huerto = GameObject.FindGameObjectWithTag("huerto");
    }


    void Update()
    {
        
    }

    private void dormir()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Has cambiado de día");
            dia++;
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dormir();
            
        }
    }
}
