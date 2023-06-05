using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecondLevelEvents : MonoBehaviour
{
    public static SecondLevelEvents obj;
    public GameObject reflectors;
    public GameObject door;
    public GameObject obstacle;

    Animator doorAnimator;
    Animator obstacleAnim;
    public bool inRoom = false;
    public bool isHorde = false;

    public List<GameObject> zombies;

    private void Awake()
    {
        obj = this;
    }
    private void Start()
    {
        doorAnimator = door.GetComponent<Animator>();
        obstacleAnim = obstacle.GetComponent<Animator>();
    }
    private void Update()
    {
        Obstacle();
        if (isHorde)
        {
            Horde();
        }
    }

    private void Obstacle()
    {
        if (inRoom)
        {
            obstacleAnim.Play("ObstacleFall");
        }
    }
    public void Horde()
    {
        Debug.Log("HordeDebug");
        reflectors.SetActive(true);
        doorAnimator.Play("DoorOpen");
        
        //foreach (var item in zombies)
        //{
        //    //zombiesscript = GetComponent<SwarmAlgorithms>();
        //    zombieAi = GetComponent<NavMeshAgent>();
        //    zombieAi.enabled = true;
        //    //zombiesscript.enabled = true;
        //}
        foreach(GameObject gameobject in zombies)
        {
            NavMeshAgent zombieAi = gameobject.GetComponent<NavMeshAgent>();
            SwarmAlgorithms zombiesscript = gameobject.GetComponent<SwarmAlgorithms>();
            if (zombieAi != null && zombiesscript != null)
            {
                zombieAi.enabled = true;
                zombiesscript.enabled = true;
            }
        }
    }

    private void OnDestroy()
    {
        obj = null;
    }
}
