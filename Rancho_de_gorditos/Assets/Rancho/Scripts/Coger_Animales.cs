using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coger_Animales : MonoBehaviour
{
    GameObject player;
    Gallina gallina;
    public GameObject gallinaPrefab;
    public Transform puntoSujección;
    public float fuerzaLanzamiento = 10f;

    [HideInInspector] public GameObject gallinaActual;
    [HideInInspector] public bool tieneGallina = false;
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            RecogerGallina();
        }
    }

    public void ObtenerGallina()
    {
        gallinaActual = Instantiate(gallinaPrefab, puntoSujección.position, puntoSujección.rotation);
        gallinaActual.transform.SetParent(puntoSujección);
        gallinaActual.GetComponent<Rigidbody>().isKinematic = true;

        Gallina scriptGallina = gallinaActual.GetComponent<Gallina>();
        if (scriptGallina != null)
        {
            scriptGallina.enabled = false;
        }

        tieneGallina = true;
    }

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

                gallinaActual.transform.SetParent(puntoSujección);
                gallinaActual.transform.position = puntoSujección.position;
                gallinaActual.GetComponent<Rigidbody>().isKinematic = true;
                tieneGallina = true;
                break;
            }
        }
    }

}
