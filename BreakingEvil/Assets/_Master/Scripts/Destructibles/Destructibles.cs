using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructibles : MonoBehaviour
{
    [SerializeField] private GameObject[] _individualParts;

    public void Unfreeze()
    {
        foreach (var part in _individualParts)
        {
            Rigidbody rb = part.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
