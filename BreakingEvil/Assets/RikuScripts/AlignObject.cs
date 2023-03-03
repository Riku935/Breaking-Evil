using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignObject : MonoBehaviour
{
    public GameObject objectToAlign;
    public Transform hand;

    private void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            Move();
        }
    }
    private void Move()
    {
        objectToAlign.transform.position = Vector3.Lerp(objectToAlign.transform.position, hand.position, Time.deltaTime);
        objectToAlign.transform.rotation = Quaternion.Lerp(objectToAlign.transform.rotation, hand.rotation, Time.deltaTime);
    }
}
