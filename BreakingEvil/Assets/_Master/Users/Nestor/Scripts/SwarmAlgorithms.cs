using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwarmAlgorithms : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] destinations;
    private int i = 0;

  
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

    private SwarmAlgorithms[] groupMembers; // Array para almacenar los agentes del mismo grupo

    void Start()
    {
        anim = GetComponent<Animator>();

        //navMeshAgent.destination = destinations[0].transform.position;
        player = FindObjectOfType<PlayerControllerTarget>().gameObject;

        // Obtener todos los agentes con el mismo script SwarmAlgorithms
        groupMembers = FindObjectsOfType<SwarmAlgorithms>();
    }

    void Update()
    {
      
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= distanceToFollowPlayer && distanceToPlayer > _distanceToAttack)
        {
            FollowPlayer();
            followPlayer = true;

            // Si este agente está siguiendo al jugador, hacer que los demás agentes del grupo también lo sigan
            if (followPlayer)
            {
                FollowPlayerGroup();
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
            EnemyPath();
            navMeshAgent.speed = 3;
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

   

    public IEnumerator Attack()
    {
        anim.Play("Z_Attack");
        yield return new WaitForSecondsRealtime(_attackTime);
        StopCoroutine(Attack());
        if (distanceToPlayer>= _distanceToAttack)
        {
            followPlayer = true;
        }
    }
}
