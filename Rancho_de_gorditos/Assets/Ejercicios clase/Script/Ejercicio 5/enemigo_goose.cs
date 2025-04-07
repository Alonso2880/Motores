using UnityEngine;

public class enemigo_goose : MonoBehaviour
{
    public float velocidad = 2f;        // Velocidad de movimiento al perseguir
    public float VelRot = 0.5f;           // Velocidad de rotación
    public float detectionDistance = 10f; // Distancia máxima para detectar al jugador

    GameObject enemigo, player;

    private Vector3 E, J;

    void Start()
    {
        enemigo = this.gameObject;
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        // Posiciones actuales del enemigo y del jugador
        E = enemigo.transform.position;
        J = player.transform.position;

        // Dirección normalizada del enemigo al jugador
        Vector3 directionToPlayer = (J - E).normalized;

        // Lanzamos un raycast desde la posición del enemigo hacia el jugador
        RaycastHit hit;
        if (Physics.Raycast(E, directionToPlayer, out hit, detectionDistance))
        {
            // Si el raycast impacta al jugador, iniciamos la persecución
            if (hit.transform.gameObject == player)
            {
                Perseguir(E, J, directionToPlayer);
            }
        }
    }

    private void Perseguir(Vector3 E, Vector3 J, Vector3 N)
    {
        // Movemos al enemigo hacia el jugador
        transform.position = Vector3.MoveTowards(E, J, velocidad * Time.deltaTime);

        // Rotamos al enemigo para que mire hacia el jugador
        if (N != Vector3.zero)
        {
            Quaternion RotJugador = Quaternion.LookRotation(N);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, RotJugador, VelRot * Time.deltaTime);
        }
    }
}
