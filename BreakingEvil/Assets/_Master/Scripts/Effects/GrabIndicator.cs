using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabIndicator : MonoBehaviour
{
    [SerializeField] private GameObject _grabFeed;
    [SerializeField] private float _distance=3;

    private void Update()
    {
        ParticleOn();
    }

    public void ParticleOn()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector3.Distance(player.transform.position, this.transform.position);
        Debug.Log(distance);
        if ( distance<= _distance)
        {
            _grabFeed.SetActive(true);
        }
      else _grabFeed.SetActive(false);
    }
}
