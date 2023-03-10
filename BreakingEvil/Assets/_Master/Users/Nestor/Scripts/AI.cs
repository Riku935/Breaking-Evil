using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    public Transform[] destinations;
    private int i = 0;

    [Header("FollowPlayer----------------------")]
    
    public bool followPlayer, isMoving = true;
    private GameObject player;
    [SerializeField] private float distanceToPlayer;
    [SerializeField] private float distanceToFollowPlayer=3f;
    [SerializeField] private float distanceToFollowPath = 2f;



    void Start()
    {
        navMeshAgent.destination = destinations[0].transform.position;
        player = FindObjectOfType<Player_Controller>().gameObject;
    }
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distanceToPlayer <= distanceToFollowPlayer && followPlayer && isMoving)
        {
            FollowPlayer();
        }
        else if(isMoving)
        {
            EnemyPath();
        }

    }
    public void EnemyPath()
    {
        navMeshAgent.destination = destinations[i].position;
        if(Vector3.Distance(transform.position,destinations[i].position)<=distanceToFollowPath)
        {
            if(destinations[i] != destinations[destinations.Length -1])
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
    public void StopEnemyPath()
    {
        isMoving = false;
    }
}
