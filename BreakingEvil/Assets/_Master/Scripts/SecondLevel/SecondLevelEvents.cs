using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        reflectors.SetActive(true);
        doorAnimator.Play("DoorOpen");
    }

    private void OnDestroy()
    {
        obj = null;
    }
}
