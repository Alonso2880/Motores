using UnityEngine;

public class ObtenerMateriales : MonoBehaviour
{
    private GameObject jugador, piedra;
    private int piedras = 2;
    public GameObject piedraMat;
    void Start()
    {
        jugador = this.gameObject;
        
    }

    private void picarPiedra()
    {
        LlevarObjeto l = jugador.GetComponent<LlevarObjeto>();
        Guardar_Inventario_Bosque inventarioScript = GameObject.FindAnyObjectByType<Guardar_Inventario_Bosque>();
        if (l.picaPiedras)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {

                /*for (int a = 0; a < piedras; a++)
                {

                    inventarioScript.AgregarItem("Piedra", null);
                }*/
                inventarioScript.AgregarItem("Piedra", piedraMat);
                Destroy(piedra);
                Debug.Log("Me muero");
                piedra = null;
            }


        }
    }

    private void OnCollisionStay(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Piedra"))
        {
            
            piedra = collision.gameObject;
            picarPiedra();
            
        }
    }
}
