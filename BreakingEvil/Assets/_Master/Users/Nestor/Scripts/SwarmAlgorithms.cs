using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwarmAlgorithms : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] destinations;
    private int i = 0;

    [Header("FollowPlayer----------------------")]
    [SerializeField] private bool followPlayer = false;
    private GameObject player;
    [SerializeField] private float distanceToPlayer;
    [SerializeField] private float distanceToFollowPlayer = 3f;
    [SerializeField] private float distanceToFollowPath = 2f;

    private SwarmAlgorithms[] groupMembers; // Array para almacenar los agentes del mismo grupo

    void Start()
    {
        //navMeshAgent.destination = destinations[0].transform.position;
        player = FindObjectOfType<PlayerControllerTarget>().gameObject;

        // Obtener todos los agentes con el mismo script SwarmAlgorithms
        groupMembers = FindObjectsOfType<SwarmAlgorithms>();
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= distanceToFollowPlayer)
        {
            FollowPlayer();
            followPlayer = true;

            // Si este agente está siguiendo al jugador, hacer que los demás agentes del grupo también lo sigan
            if (followPlayer)
            {
                FollowPlayerGroup();
            }
        }
        else
        {
            EnemyPath();
        }
    }

    public void EnemyPath()
    {
        navMeshAgent.destination = destinations[i].position;
        if (Vector3.Distance(transform.position, destinations[i].position) <= distanceToFollowPath)
        {
            if (destinations[i] != destinations[destinations.Length - 1])
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }
    }

    public void FollowPlayer()
    {
        navMeshAgent.destination = player.transform.position;
    }

    public void FollowPlayerGroup()
    {
        foreach (SwarmAlgorithms member in groupMembers)
        {
            if (member != this) // No aplicar al agente actual
            {
                member.navMeshAgent.destination = player.transform.position;
            }
        }
    }

    public void StopEnemyPath()
    {
        navMeshAgent.speed = 0;
    }
}
