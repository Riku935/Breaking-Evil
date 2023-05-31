using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwarmAlgorithms : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] destinations;
    private int i = 0;
    private bool isDeath = false;
    private Animator anim;

    [Header("Attack Values")]
    [SerializeField] private bool _isAttack = false;
    [SerializeField] private float _distanceToAttack = 1;
    [SerializeField] private float _attackTime = 1.5f;

    [Header("FollowPlayer----------------------")]
    [SerializeField] private bool followPlayer = false;
    private GameObject player;
    [SerializeField] private float distanceToPlayer;
    [SerializeField] private float distanceToFollowPlayer = 3f;
    [SerializeField] private float distanceToFollowPath = 2f;

    private SwarmAlgorithms leader; // Referencia al agente líder que tiene followPlayer en true

    void Start()
    {
        anim = GetComponent<Animator>();

        player = FindObjectOfType<PlayerControllerTarget>().gameObject;

        // Obtener todos los agentes con el mismo script SwarmAlgorithms
        SwarmAlgorithms[] groupMembers = FindObjectsOfType<SwarmAlgorithms>();

        // Buscar el agente líder en el grupo
        foreach (SwarmAlgorithms member in groupMembers)
        {
            if (member.followPlayer)
            {
                leader = member;
                break;
            }
        }
    }

    void Update()
    {
        if (isDeath == false)
        {
            distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= distanceToFollowPlayer && distanceToPlayer > _distanceToAttack)
            {
                followPlayer = true;
                FollowPlayer();

                // Si este agente está siguiendo al jugador, establecerlo como líder y hacer que los demás agentes lo sigan
                if (followPlayer)
                {
                    leader = this;
                    FollowPlayerGroup();
                    distanceToFollowPlayer *= 2; // Duplicar la distancia de seguimiento al jugador
                }
            }
            else if (distanceToPlayer <= _distanceToAttack)
            {
                followPlayer = false;
                navMeshAgent.speed = 0;
                StartCoroutine(Attack());
            }
            else
            {
                followPlayer = false;
                EnemyPath();
                navMeshAgent.speed = 3;
                distanceToFollowPlayer /= 2; // Restaurar la distancia de seguimiento al jugador
                ennemyIsDeath();
            }
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

        anim.Play("Z_Walk_InPlace");
    }

    public void FollowPlayer()
    {
        navMeshAgent.speed = 8;
        navMeshAgent.destination = player.transform.position;
        anim.Play("Z_Run_InPlace");
    }

    public void FollowPlayerGroup()
    {
        if (leader == null)
            return;

        foreach (SwarmAlgorithms member in FindObjectsOfType<SwarmAlgorithms>())
        {
            if (member != leader) // No aplicar al líder actual
            {
                member.navMeshAgent.destination = leader.transform.position;
            }
        }
    }

    public void StopEnemyPath()
    {
        navMeshAgent.speed = 0;
    }

    public IEnumerator Attack()
    {
        anim.Play("Z_Attack");
        yield return new WaitForSecondsRealtime(_attackTime);
        StopCoroutine(Attack());
        if (distanceToPlayer >= _distanceToAttack)
        {
            followPlayer = true;
        }
    }
    public void ennemyIsDeath()
    {
        isDeath = true;
    }
}
