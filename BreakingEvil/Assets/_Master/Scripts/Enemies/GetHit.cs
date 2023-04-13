using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHit : MonoBehaviour
{
    [SerializeField] private Health _enemyHealth;
    [SerializeField] private float _damagePerHit=30;
    [SerializeField] private string _tagForBullet = "Bullet";
    [SerializeField] private string _tagToHitAxe = "Axe";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(_tagForBullet))
        {
         _enemyHealth.maxHealth -= _damagePerHit;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tagToHitAxe))
        {
            _enemyHealth.maxHealth -= _damagePerHit;
        }
    }

}
