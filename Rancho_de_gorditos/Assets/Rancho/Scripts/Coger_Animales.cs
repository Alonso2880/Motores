using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coger_Animales : MonoBehaviour
{
    GameObject player;
    Gallina gallina;
    public GameObject gallinaPrefab, cerdoPrefab, vacaPrefab, ovejaPrefab;
    public Transform puntoSujecci�n;
    public float fuerzaLanzamiento = 10f;

    [HideInInspector] public GameObject gallinaActual, cerdoActual, vacaActual, ovejaActual;
    [HideInInspector] public bool tieneGallina = false, tieneCerdo = false, tieneOveja = false, tieneVaca = false, g=false, c= false, v=false, o=false;
    void Start()
    {
        player = this.gameObject;
        gallina = GameObject.Find("Gallina").GetComponent<Gallina>();
    }


    void Update()
    {
        if (tieneGallina)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                LanzarGallina();
            }
        }
        if (tieneCerdo)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                LanzarCerdo();
            }
        }
        if (tieneOveja)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                LanzarOveja();
            }
        }
        if (tieneVaca)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                LanzarVaca();
            }
        }

        if (g && !c && !o && !v)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                RecogerGallina();
            }
        }

        if (c && !g && !o && !v)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                RecogerCerdo();
            }
        }

        if (o && !g && !v && !c)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                RecogerOveja();
            }
        }

        if (v && !g && !c && !o)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                RecogerVaca();
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gallina"))
        {
            g = true;
        }

        if (collision.gameObject.CompareTag("Cerdo"))
        {
            c = true;
        }

        if (collision.gameObject.CompareTag("Oveja"))
        {
            o = true;
        }

        if (collision.gameObject.CompareTag("Vaca"))
        {
            v = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gallina"))
        {
            g = false;
        }

        if (collision.gameObject.CompareTag("Cerdo"))
        {
            c = false;
        }

        if (collision.gameObject.CompareTag("Oveja"))
        {
            o = false;
        }

        if (collision.gameObject.CompareTag("Vaca"))
        {
            v = false;
        }
    }

    //Obtener
    public void ObtenerGallina()
    {
        gallinaActual = Instantiate(gallinaPrefab, puntoSujecci�n.position, puntoSujecci�n.rotation);
        gallinaActual.transform.SetParent(puntoSujecci�n);
        gallinaActual.GetComponent<Rigidbody>().isKinematic = true;

        Gallina scriptGallina = gallinaActual.GetComponent<Gallina>();
        if (scriptGallina != null)
        {
            scriptGallina.enabled = false;
        }

        tieneGallina = true;
    }

    public void ObtenerCerdo()
    {
        cerdoActual = Instantiate(cerdoPrefab, puntoSujecci�n.position, puntoSujecci�n.rotation);
        cerdoActual.transform.SetParent(puntoSujecci�n);
        cerdoActual.GetComponent<Rigidbody>().isKinematic = true;

        Gallina scriptGallina = cerdoActual.GetComponent<Gallina>();
        if (scriptGallina != null)
        {
            scriptGallina.enabled = false;
        }

        tieneCerdo = true;
    }

    public void ObtenerOveja()
    {
        ovejaActual = Instantiate(ovejaPrefab, puntoSujecci�n.position, puntoSujecci�n.rotation);
        ovejaActual.transform.SetParent(puntoSujecci�n);
        ovejaActual.GetComponent<Rigidbody>().isKinematic = true;

        Gallina scriptGallina = ovejaActual.GetComponent<Gallina>();
        if (scriptGallina != null)
        {
            scriptGallina.enabled = false;
        }

        tieneOveja = true;
    }

    public void ObtenerVaca()
    {
        vacaActual = Instantiate(vacaPrefab, puntoSujecci�n.position, puntoSujecci�n.rotation);
        vacaActual.transform.SetParent(puntoSujecci�n);
        vacaActual.GetComponent<Rigidbody>().isKinematic = true;

        Gallina scriptGallina = vacaActual.GetComponent<Gallina>();
        if (scriptGallina != null)
        {
            scriptGallina.enabled = false;
        }

        tieneVaca = true;
    }

    //Lanzar
    private void LanzarGallina()
    {
        gallinaActual.transform.SetParent(null);
        Rigidbody rb = gallinaActual.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        string scene = SceneManager.GetActiveScene().name;

        Gallina scriptGallina = gallinaActual.GetComponent<Gallina>();
        if (scriptGallina != null)
        {
            scriptGallina.enabled = true;
            scriptGallina.scriptActivo = true;
        }

        Vector3 direccionLanzamiento = transform.forward;
        rb.AddForce(direccionLanzamiento * fuerzaLanzamiento, ForceMode.Impulse);
        
        tieneGallina = false;
    }

    private void LanzarCerdo()
    {
        cerdoActual.transform.SetParent(null);
        Rigidbody rb = cerdoActual.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        string scene = SceneManager.GetActiveScene().name;

        Cerdo scriptCerdo = cerdoActual.GetComponent<Cerdo>();
        if (scriptCerdo != null)
        {
            scriptCerdo.enabled = true;
            scriptCerdo.scriptActivo = true;
        }

        Vector3 direccionLanzamiento = transform.forward;
        rb.AddForce(direccionLanzamiento * fuerzaLanzamiento, ForceMode.Impulse);

        tieneCerdo = false;
    }

    private void LanzarOveja()
    {
        ovejaActual.transform.SetParent(null);
        Rigidbody rb = ovejaActual.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        string scene = SceneManager.GetActiveScene().name;

        Oveja scriptOveja = ovejaActual.GetComponent<Oveja>();
        if (scriptOveja != null)
        {
            scriptOveja.enabled = true;
            scriptOveja.scriptActivo = true;
        }

        Vector3 direccionLanzamiento = transform.forward;
        rb.AddForce(direccionLanzamiento * fuerzaLanzamiento, ForceMode.Impulse);

        tieneOveja = false;
    }

    private void LanzarVaca()
    {
        vacaActual.transform.SetParent(null);
        Rigidbody rb = vacaActual.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        string scene = SceneManager.GetActiveScene().name;

        Vaca scriptVaca = vacaActual.GetComponent<Vaca>();
        if (scriptVaca != null)
        {
            scriptVaca.enabled = true;
            scriptVaca.scriptActivo = true;
        }

        Vector3 direccionLanzamiento = transform.forward;
        rb.AddForce(direccionLanzamiento * fuerzaLanzamiento, ForceMode.Impulse);

        tieneVaca = false;
    }


    //Recoger
    private void RecogerGallina()
    {
        Collider[] collides = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider col in collides)
        {
            if (col.CompareTag("Gallina") && !tieneGallina)
            {
                string escena = SceneManager.GetActiveScene().name;
                string prefabName = col.gameObject.name.Replace("(Clone)", "");
                

                gallinaActual = col.gameObject;

                Gallina scriptGallina = gallinaActual.GetComponent<Gallina>();
                if (scriptGallina != null)
                {
                    scriptGallina.enabled = false;
                }

                gallinaActual.transform.SetParent(puntoSujecci�n);
                gallinaActual.transform.position = puntoSujecci�n.position;
                gallinaActual.GetComponent<Rigidbody>().isKinematic = true;
                tieneGallina = true;
                g = false;
                break;
            }
        }
    }

    private void RecogerCerdo()
    {
        Collider[] collides = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider col in collides)
        {
            if (col.CompareTag("Cerdo") && !tieneCerdo)
            {
                string escena = SceneManager.GetActiveScene().name;
                string prefabName = col.gameObject.name.Replace("(Clone)", "");


                cerdoActual = col.gameObject;

                Cerdo scriptCerdo = cerdoActual.GetComponent<Cerdo>();
                if (scriptCerdo != null)
                {
                    scriptCerdo.enabled = false;
                }

                cerdoActual.transform.SetParent(puntoSujecci�n);
                cerdoActual.transform.position = puntoSujecci�n.position;
                cerdoActual.GetComponent<Rigidbody>().isKinematic = true;
                tieneCerdo = true;
                c = false;
                break;
            }
        }
    }

    private void RecogerOveja()
    {
        Collider[] collides = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider col in collides)
        {
            if (col.CompareTag("Oveja") && !tieneOveja)
            {
                string escena = SceneManager.GetActiveScene().name;
                string prefabName = col.gameObject.name.Replace("(Clone)", "");


                ovejaActual = col.gameObject;

                Oveja scriptOveja = ovejaActual.GetComponent<Oveja>();
                if (scriptOveja != null)
                {
                    scriptOveja.enabled = false;
                }

                ovejaActual.transform.SetParent(puntoSujecci�n);
                ovejaActual.transform.position = puntoSujecci�n.position;
                ovejaActual.GetComponent<Rigidbody>().isKinematic = true;
                tieneOveja = true;
                o = false;
                break;
            }
        }
    }

    private void RecogerVaca()
    {
        Collider[] collides = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider col in collides)
        {
            if (col.CompareTag("Vaca") && !tieneVaca)
            {
                string escena = SceneManager.GetActiveScene().name;
                string prefabName = col.gameObject.name.Replace("(Clone)", "");


                vacaActual = col.gameObject;

                Vaca scriptVaca = vacaActual.GetComponent<Vaca>();
                if (scriptVaca != null)
                {
                    scriptVaca.enabled = false;
                }

                vacaActual.transform.SetParent(puntoSujecci�n);
                vacaActual.transform.position = puntoSujecci�n.position;
                vacaActual.GetComponent<Rigidbody>().isKinematic = true;
                tieneVaca = true;
                v = false;
                break;
            }
        }
    }

}
