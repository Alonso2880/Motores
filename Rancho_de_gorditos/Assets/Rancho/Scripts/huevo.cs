using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class huevo : MonoBehaviour
{
    GameObject Huevo;
    MeshRenderer HuevoMesh;
    SphereCollider HuevoColl;
    //public Gallina galli;
    public int HuevoTotal=0;
    void Start()
    {
        Huevo = this.gameObject;
        HuevoMesh = GetComponent<MeshRenderer>();
        //HuevoMesh.enabled = false;
        HuevoColl = GetComponent<SphereCollider>();
        //HuevoColl.enabled = true;
       // galli = GameObject.Find("Gallina").GetComponent<Gallina>();

        /*if (galli != null)
        {
            galli.CH += ActualizarVisualizacion;
        }*/

    }

    /*void ActualizarVisualizacion(int eggCount)
    {
        bool tieneHuevos = eggCount > 0;
        HuevoMesh.enabled = tieneHuevos;
    }

    private void OnDestroy()
    {
        if (Huevo != null)
        {
            galli.CH -= ActualizarVisualizacion;
        }
    }*/

    public void Reset()
    {
        HuevoTotal = 0;
    }
    void Update()
    {

       // bool tieneHuevos = galli.huevo > 0;
        //HuevoMesh.enabled = tieneHuevos;


    }
}
