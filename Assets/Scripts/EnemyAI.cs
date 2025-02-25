using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public Transform player; // Transform del jugador
    public NavMeshAgent agent; // NavMeshAgent del enemigo

    public float speed = 5f; // velocidad del enemigo

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // se obtiene el NavMeshAgent del enemigo
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized; // se obtiene la direccion del jugador
        transform.position += direction * 5 * Time.deltaTime; // se mueve el enemigo hacia el jugador

        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)); // se obtiene la rotacion para mirar al jugador
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5); // se rota el enemigo para mirar al jugador
      agent.SetDestination(player.position); // se le asigna la posicion del jugador al destino del NavMeshAgent   
    }
}
