using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAsecondLevel : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    private Animator anim;
    private GameObject player;

    public BoxCollider colliderss;

    [Header("Attack Values")]
    [SerializeField] private bool _isAttack = false;
    [SerializeField] private float _distanceToAttack = 1;
    [SerializeField] private float _attackTime = 1.5f;

    [Header("FollowPlayer----------------------")]
    [SerializeField] private bool followPlayer = false;
    [SerializeField] private float distanceToPlayer;
    [SerializeField] private float distanceToFollowPlayer = 3f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerControllerTarget>().gameObject;
    }
    private void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= distanceToFollowPlayer && distanceToPlayer > _distanceToAttack)
        {
            FollowPlayer();
            followPlayer = true;
        }
        else if (distanceToPlayer <= _distanceToAttack)
        {
            followPlayer = false;
            navMeshAgent.speed = 0;
            StartCoroutine(Attack());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            FollowPlayer();
        }
    }
    public void FollowPlayer()
    {
        navMeshAgent.speed = 8;
        navMeshAgent.destination = player.transform.position;
        anim.Play("Z_Run_InPlace");
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
}
