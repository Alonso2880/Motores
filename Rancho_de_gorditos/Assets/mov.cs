using UnityEngine;

public class mov : MonoBehaviour
{
    private float vel;
    private Rigidbody rb;
    private float cordX, cordY, cordZ;
    private Vector3 pos;

    void Start()
    {
        vel = 8.9f;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()      {
        cordY = rb.linearVelocity.y;  
        cordX = Input.GetAxis("Horizontal") * vel;
        cordZ = Input.GetAxis("Vertical") * vel;

        pos = new Vector3(cordX, cordY, cordZ);
        rb.linearVelocity = pos;  
    }
}
