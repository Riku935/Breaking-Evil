using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnersPositions;
    [SerializeField] private List<GameObject> _zombies;

    [SerializeField] private float _timer=5;
    [SerializeField] private float _mindistance=8;
    [SerializeField] private int _zombieCounter=8;

    public GameObject zombiePrefab;

    private Transform _playerPosition;


    private void Start()
    {
        _playerPosition = FindObjectOfType<PlayerControllerTarget>().transform;
        StartCoroutine(GetZombie());
    }
    public IEnumerator GetZombie()
    {
        while (true)
        {          
            yield return new WaitForSecondsRealtime(_timer);
            if (_zombies.Count<=_zombieCounter)
            {
                SpawnZombie();
            }
        }
    }

    public void SpawnZombie() 
    {
       
            foreach (var spawn in _spawnersPositions)
            {
                float distance = Vector3.Distance(spawn.position, _playerPosition.position);
                if (distance >= _mindistance)
                {
                    Instantiate(zombiePrefab, spawn);
                    _zombies.Add(zombiePrefab);
                }
            }

        
    }
}
