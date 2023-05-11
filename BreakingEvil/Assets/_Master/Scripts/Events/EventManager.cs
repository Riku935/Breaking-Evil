using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    //[SerializeField] private UnityEvent puzzle;

    public static EventManager obj;
    public float rotationSpeed = 10f;
    public bool canOpen = false;
    public int puzzleCount;
    private Animator anim;
    private void Awake()
    {
        obj = this;
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (puzzleCount == 3)
        {
            MainDoorEvent();
        }
    }

    void MainDoorEvent()
    {
        anim.Play("OpenDoor");
    }
    private void OnDestroy()
    {
        obj = null;
    }
}
