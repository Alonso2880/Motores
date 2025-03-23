using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Gallina : MonoBehaviour
{
    GameObject gallina, lugarHuevo, huevoG;
    private Rigidbody rb;
    private Vector3 velocidadVec;
    private float velocidad;
    private bool SeMueve = true, random = true;
    public bool enterreno = false;
    [HideInInspector] public bool b = false;
    private int X, Z, X1, tiempoHuevo = 3;
    public int huevoTota = 0;
    public GameObject prefabHuevo;

    [HideInInspector] public bool scriptActivo = true;
    private Coroutine movimientoCoroutine;
    private Coroutine huevoCoroutine;


    public delegate void ContadorHuevo(int conthuevo);
    //public event ContadorHuevo CH;

    guardar_Inventario g;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocidad = 2.5f;
        g = GameObject.Find("Player").GetComponent<guardar_Inventario>();
        huevoCoroutine = StartCoroutine("generarHuevo");
        movimientoCoroutine = StartCoroutine("movimiento");
        //StartCoroutine("generarHuevo");
        lugarHuevo = GameObject.Find("LugarHuevo");

        huevoG = GameObject.Find("Huevo");
       
    }

    private void OnDisable()
    {
        scriptActivo = false;

        if (movimientoCoroutine != null)
        {
            StopCoroutine(movimientoCoroutine);
        }

        if (huevoCoroutine != null)
        {
            StopCoroutine(huevoCoroutine);
        }

        //rb.linearVelocity = Vector3.zero;
        random = true;
        SeMueve = false;
    }


    IEnumerator movimiento()
    {
        while (scriptActivo)
        {
            if (SeMueve)
            {
                //yield return new WaitForSeconds(1);
                if (!scriptActivo) yield break;


                velocidadVec = new Vector3(X, 0, Z).normalized * velocidad;
                rb.linearVelocity = new Vector3(velocidadVec.x, rb.linearVelocity.y, velocidadVec.z);
                //Debug.Log("Movimiento es " + velocidadVec.x + " 0 " + velocidadVec.z);
                //yield return new WaitForSeconds(Random.Range(1, 3));
                yield return new WaitForSeconds(3);
                SeMueve = false;
                random = true;
            }
            else
            {
                //Debug.Log("Me he parado");
                rb.linearVelocity = Vector3.zero;
                yield return new WaitForSeconds(1);
                SeMueve = true;


            }
        }


    }


    IEnumerator generarHuevo()
    {
        
        
        while (scriptActivo)
        {
            if (!enterreno)
            {
                yield return null;
                continue;
            }
            yield return new WaitForSeconds(tiempoHuevo);
            huevoTota += 1;
            huevo h = huevoG.GetComponent<huevo>();
            h.HuevoTotal += huevoTota;
            ResetHuevos();
            /*if (scriptActivo && enterreno)
            {
                huevo += 1;
                if (b == false)
                {
                    GameObject nuevoHuevo = Instantiate(prefabHuevo, lugarHuevo.transform.position, Quaternion.identity);
                    huevo huevoScript = nuevoHuevo.GetComponent<huevo>();
                    huevoScript.galli = this;
                    b = true;
                }



                CH?.Invoke(huevo);
                //Debug.Log("El huevo que hay creado es " + huevo);
            }*/
        }
    }

    public void ResetHuevos()
    {
        huevoTota = 0;
       // CH?.Invoke(huevo);
    }

    void FixedUpdate()
    {


        if (random && scriptActivo)
        {
            X = Random.Range(-1, 2);
            Z = Random.Range(-1, 2);
            X1 = Random.Range(1, 3);
            random = false;
        }
        //StartCoroutine("movimiento");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (scriptActivo && collision.gameObject.CompareTag("Valla"))
        {
            //SeMueve = false;
            //Debug.Log("Me he chocado");
            X = Random.Range(-1, 2);
            Z = Random.Range(-1, 2);
        }

        if (collision.gameObject.CompareTag("Terreno"))
        {
            enterreno = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terreno"))
        {
            enterreno = false;
        }
    }
}