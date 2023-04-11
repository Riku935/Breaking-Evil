using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPuzzle : MonoBehaviour
{
    public delegate void HandlerPuzzle(GameObject sender);
    public event HandlerPuzzle OnPuzzleComplete;
    public event HandlerPuzzle OnPuzzleFail;

    public GameObject puzzleObject;
    public Transform puzzlePosition;
    public Transform movePosition;

    public float speed = 1f;
    public bool coroutineRunning = true;

    private GameObject instance;
    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PuzzleObject")
        {
            other.gameObject.SetActive(false);
            
            StartCoroutine(PuttingPuzzle());
            PuzzleComplete();
        }
    }
    void PuzzleComplete()
    {
        if(OnPuzzleComplete != null){OnPuzzleComplete (gameObject); }
    }
    IEnumerator PuttingPuzzle()
    {
        instance = Instantiate(puzzleObject, puzzlePosition.position, puzzlePosition.rotation);
        Rigidbody rb = instance.GetComponent<Rigidbody>();
        rb.useGravity = false;
        yield return new WaitForSeconds(2f);
        while (coroutineRunning)
        {
            instance.transform.position = Vector3.MoveTowards(movePosition.position, transform.position, speed * Time.deltaTime);
            
            if (instance.transform.position == transform.position)
            {
                coroutineRunning = false;
            }
            yield return null;
        }
    }
}
