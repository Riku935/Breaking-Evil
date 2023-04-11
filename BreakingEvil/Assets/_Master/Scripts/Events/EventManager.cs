using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    //[SerializeField] private UnityEvent puzzle;

    public float rotationSpeed = 10f;
    private void Start()
    {
        TestPuzzle temp = new TestPuzzle();
        temp.OnPuzzleComplete += HandleOnPuzzleComplete;
    }
    void HandleOnPuzzleComplete(GameObject sender)
    {
        print(sender.name);
    }
    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
