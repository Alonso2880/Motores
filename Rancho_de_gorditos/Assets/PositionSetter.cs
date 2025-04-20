using UnityEngine;

public class PositionSetter : MonoBehaviour
{
    // Posici�n deseada
    private readonly Vector3 targetPosition = new Vector3(-41.12265f, 1.07f, 1.572043f);

    void Awake()
    {
        // Establece la posici�n del transform al iniciar la escena
        transform.position = targetPosition;
    }
}

