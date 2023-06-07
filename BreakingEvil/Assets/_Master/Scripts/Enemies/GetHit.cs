using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHit : MonoBehaviour
{
    [SerializeField] private Health _enemyHealth;
    [SerializeField] private float _damagePerHit=30;
    [SerializeField] private string _tagForBullet = "Bullet";
    public AudioSource audioSource;
  //  [SerializeField] private string _tagToHitAxe = "Axe";
    [SerializeField] private List<string> _tags = new List<string>();
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(_tagForBullet))
        {
         _enemyHealth.maxHealth -= _damagePerHit;
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        foreach (var tag in _tags)
        {
            if (other.CompareTag(tag))
            {
                _enemyHealth.maxHealth -= _damagePerHit;
                audioSource.Play();

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        audioSource.Stop();
    }

}
