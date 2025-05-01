using UnityEngine;

public class Movimiento_Jugador_Rancho : MonoBehaviour
{
    public float vel, velRot, velCorrer, velCopia;
    public Animator animator;
    private float cordX, cordZ;
    private Vector3 pos;
    private const float fixedY = 0.002f;
    private GameObject Zona;

    void Start()
    {
        velCopia = vel;
        // Aseguramos la posición Y inicial
        Vector3 startPos = transform.position;
        startPos.y = fixedY;
        transform.position = startPos;
        Zona = GameObject.Find("ZonasUI");
    }

    private void OnCollisionEnter(Collision collision)
    {
        ZonasUI z = Zona.GetComponent<ZonasUI>();
        if (collision.gameObject.CompareTag("Rancho"))
        {
            z.rancho = true;
        }

        if (collision.gameObject.CompareTag("Bosque"))
        {
            z.bosque = true;
        }
    }

    void Update()
    {
        cordX = Input.GetAxis("Horizontal");
        cordZ = Input.GetAxis("Vertical");
        pos = new Vector3(cordX, 0, cordZ).normalized;

        if (pos != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(pos);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, velRot * Time.deltaTime);
        }

        transform.Translate(pos * vel * Time.deltaTime, Space.World);

        // Aplicamos animaciones de caminar
        animator.SetBool("Andar", pos != Vector3.zero);

        // Gestión de correr
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            vel = velCorrer;
            animator.SetBool("Correr", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            vel = velCopia;
            animator.SetBool("Correr", false);
        }

        // Fijar la posición en Y para evitar deriva
        Vector3 curPos = transform.position;
        curPos.y = fixedY;
        transform.position = curPos;
    }
}


