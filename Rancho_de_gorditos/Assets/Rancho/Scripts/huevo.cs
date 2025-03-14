using Unity.VisualScripting;
using UnityEngine;

public class huevo : MonoBehaviour
{
    GameObject Huevo;
    MeshRenderer HuevoMesh;
    SphereCollider HuevoColl;
    Gallina galli;
    void Start()
    {
        Huevo = this.gameObject;
        HuevoMesh = GetComponent<MeshRenderer>();
        HuevoMesh.enabled = false;
        HuevoColl = GetComponent<SphereCollider>();
        HuevoColl.enabled = true;
        galli = GameObject.Find("Gallina").GetComponent<Gallina>();

        
    }

   
    void Update()
    {
        
        bool tieneHuevos = galli.huevo > 0;
        HuevoMesh.enabled = tieneHuevos;
        //HuevoColl.enabled = tieneHuevos;


    }
}
