using UnityEngine;

public class mov : MonoBehaviour
{
    public float vel;
    private float cordX, cordZ;
    private Vector3 pos;

    void Start()
    {
        
        
    }

    void Update()
    {
         
        cordX = Input.GetAxis("Horizontal") * vel;
        cordZ = Input.GetAxis("Vertical") * vel;
        pos = new Vector3(cordX, 0, cordZ);

        transform.Translate(pos*vel*Time.deltaTime);
          
    }
}
