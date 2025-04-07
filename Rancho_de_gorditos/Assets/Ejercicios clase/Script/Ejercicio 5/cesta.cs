using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cesta : MonoBehaviour
{
    private int contador = 0;
    public Canvas canva;
    public GameObject sand�a;
    public GameObject cereza;
    public GameObject manzana;
    public GameObject lim�n;
   

    private void Start()
    {
        
    }
    void Update()
    {
        felicidades f = canva.GetComponent<felicidades>();
        if(contador >= 4)
        {
            f.ya = true;
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("cereza"))
        {
            contador++;
            Destroy(cereza);
        }
        if (collision.gameObject.CompareTag("manzana"))
        {
            contador++;
            Destroy(manzana);
        }
        if (collision.gameObject.CompareTag("sand�a"))
        {
            contador++;
            Destroy(sand�a);
        }
        if (collision.gameObject.CompareTag("lim�n"))
        {
            contador++;
            Destroy(lim�n);
        }
    }


}
