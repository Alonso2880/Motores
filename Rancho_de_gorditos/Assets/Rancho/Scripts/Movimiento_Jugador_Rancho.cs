using UnityEngine;

public class Movimiento_Jugador_Rancho : MonoBehaviour
{
    public float vel, velRot, velCorrer, velCopia;
    public Animator animator;
    private float cordX, cordZ;
    private Vector3 pos; 
    
    void Start()
    {
        velCopia = vel;
    }


    void Update()
    {

        
        cordX = Input.GetAxis("Horizontal");
        cordZ = Input.GetAxis("Vertical");
        pos = new Vector3(cordX, 0, cordZ).normalized;

        if(pos != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(pos);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, velRot*Time.deltaTime);

        }

        transform.Translate(pos * vel * Time.deltaTime, Space.World);
        if(pos!= Vector3.zero)
        {
            animator.SetBool("Andar", true);
        }
        else
        {
            animator.SetBool("Andar", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            vel = velCorrer;
            animator.SetBool("Correr", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            vel= velCopia;
            animator.SetBool("Correr", false);
        }
    }
}

