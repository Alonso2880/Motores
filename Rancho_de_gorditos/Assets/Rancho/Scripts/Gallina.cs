using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Gallina : MonoBehaviour
{
    GameObject gallina;
    private Rigidbody rb;
    private Vector3 velocidadVec;
    private float velocidad;
    private bool SeMueve = true, random = true;
    private int X, Z, X1, tiempoHuevo = 3;
    public int huevo = 0;

    guardar_Inventario g;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocidad = 2.5f;
        g = GameObject.Find("Player").GetComponent<guardar_Inventario>();
        StartCoroutine("generarHuevo");
    }

    IEnumerator movimiento()
    {
        while (true)
        {
            if (SeMueve)
            {
               yield return new WaitForSeconds(1);
                velocidadVec = new Vector3(X, 0, Z)*velocidad;
                rb.linearVelocity = new Vector3(velocidadVec.x, rb.linearVelocity.y, velocidadVec.z);
                //Debug.Log("Movimiento es " + velocidadVec.x + " 0 " + velocidadVec.z);
                //yield return new WaitForSeconds(Random.Range(1, 3));
                yield return new WaitForSeconds(2);
                SeMueve = false;
                random = true;
            }
            else
            {
                //Debug.Log("Me he parado");
                rb.linearVelocity = new Vector3 (0,0,0);
                yield return new WaitForSeconds(2);
                SeMueve = true;
                
                
            }
        }
     

    }


    IEnumerator generarHuevo()
    {
        while (true) 
        {
            yield return new WaitForSeconds(tiempoHuevo);
            huevo += 1;
            //Debug.Log("El huevo que hay creado es " + huevo);

        }


    }

    public void ResetHuevos()
    {
        huevo = 0;
    }
    
    void FixedUpdate()
    {
        
            
            if (random == true)
            {
                X = Random.Range(-1, 2);
                Z = Random.Range(-1, 2);
                X1 = Random.Range(1, 3);
                random = false;
            }
            StartCoroutine("movimiento");
        
       
       
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Valla"))
        {
            //SeMueve = false;
            Debug.Log("Me he chocado");
            X = Random.Range(-1, 2);
            Z = Random.Range(-1, 2);
        }
    }
}
