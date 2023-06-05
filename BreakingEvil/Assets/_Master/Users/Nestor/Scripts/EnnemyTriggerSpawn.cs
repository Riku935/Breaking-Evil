using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyTriggerSpawn : MonoBehaviour
{
    public GameObject _spawnObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Spawn");
            _spawnObject.SetActive(true);
        }
    }
}
