using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    //[SerializeField] private UnityEvent puzzle;

    public static EventManager obj;
    public float rotationSpeed = 10f;
    public bool canOpen = false;
    public int puzzleCount;
    private void Awake()
    {
        obj = this;
    }
    private void Update()
    {
        if (puzzleCount == 3)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
    private void OnDestroy()
    {
        obj = null;
    }
}
